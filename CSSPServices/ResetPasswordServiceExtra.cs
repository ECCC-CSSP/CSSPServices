using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace CSSPServices
{
    public partial class ResetPasswordService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        public string CleanResetPasswordWithEmail(string Email)
        {
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryNoDBShape))
            {
                db.ResetPasswords.RemoveRange((from r in db.ResetPasswords
                                               where r.Email == Email
                                               && r.ExpireDate_Local < DateTime.Today
                                               select r));

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    return ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "");
                }
            }
            return "";
        }
        public bool ResetPasswordDB(ResetPassword resetPassword)
        {
            ContactService contactService = new ContactService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            using (TransactionScope ts = new TransactionScope())
            {
                IEnumerable<ValidationResult> validationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Create);
                if (validationResults.Count() > 0)
                {
                    return false;
                }

                ResetPassword resetPasswordRet = GetRead().Where(c => c.Code == resetPassword.Code && c.Email == resetPassword.Email).FirstOrDefault();
                if (resetPasswordRet == null)
                {
                    validationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.ResetPassword, ModelsRes.ResetPasswordCode + "," + ModelsRes.ResetPasswordEmail, resetPassword.Code + "," + resetPassword.Email)) };
                    return false;
                }

                Contact contact = contactService.GetEdit().Where(c => c.LoginEmail == resetPassword.Email).FirstOrDefault();
                if (contact == null)
                {
                    validationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Contact, ModelsRes.ResetPasswordEmail, resetPassword.Email)) };
                    return false;
                }

                // -------------------------------------------------------------
                // todo create passwordhash and save it to Contact
                // -------------------------------------------------------------

                contact.PasswordHash = contact.PasswordHash; // should be the new password hash
                //aspNetUser.Password = resetPassword.Password;

                if (!contactService.Update(contact))
                {
                    validationResults = contact.ValidationResults;
                    return false;
                };

                if (!Delete(resetPasswordRet))
                {
                    validationResults = resetPasswordRet.ValidationResults;
                    return false;
                }

                ts.Complete();
            }
            return true;
        }
        #endregion Function public

        #region Function private
        #endregion Functions private    
    }
}
