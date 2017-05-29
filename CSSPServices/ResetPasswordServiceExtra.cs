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
            AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

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

                AspNetUser aspNetUser = new AspNetUser()
                {
                    Email = "unique" + resetPassword.Email,
                    Password = resetPassword.Password
                };

                if (!aspNetUserService.Add(aspNetUser))
                {
                    validationResults = aspNetUser.ValidationResults;
                    return false;
                }

                if (!aspNetUserService.Delete(aspNetUser))
                {
                    validationResults = aspNetUser.ValidationResults;
                    return false;
                }

                aspNetUser = aspNetUserService.GetRead().Where(c => c.Email == resetPassword.Email).FirstOrDefault();
                if (aspNetUser == null)
                {
                    validationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.AspNetUser, ModelsRes.ResetPasswordEmail, resetPassword.Email)) };
                    return false;
                }

                aspNetUser.Password = resetPassword.Password;

                if (!aspNetUserService.Update(aspNetUser))
                {
                    validationResults = aspNetUser.ValidationResults;
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
