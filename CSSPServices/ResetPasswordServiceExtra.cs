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
            using (CSSPWebToolsDBContext db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB))
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
            //ContactLoginService contactLoginService = new ContactLoginService(LanguageRequest, db, ContactID);

            //using (TransactionScope ts = new TransactionScope())
            //{
            //    IEnumerable<ValidationResult> validationResults = Validate(new ValidationContext(resetPassword), ActionDBTypeEnum.Create);
            //    if (validationResults.Count() > 0)
            //    {
            //        return false;
            //    }

            //    ResetPassword resetPasswordRet = GetRead().Where(c => c.Code == resetPassword.Code && c.Email == resetPassword.Email).FirstOrDefault();
            //    if (resetPasswordRet == null)
            //    {
            //        validationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ResetPassword, CSSPModelsRes.ResetPasswordCode + "," + CSSPModelsRes.ResetPasswordEmail, resetPassword.Code + "," + resetPassword.Email)) };
            //        return false;
            //    }

            //    ContactLogin contactLogin = contactLoginService.GetEdit().Where(c => c.LoginEmail == resetPassword.Email).FirstOrDefault();
            //    if (contactLogin == null)
            //    {
            //        validationResults = new List<ValidationResult>() { new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Contact, CSSPModelsRes.ResetPasswordEmail, resetPassword.Email)) };
            //        return false;
            //    }

            //    // -------------------------------------------------------------
            //    // todo create passwordhash and save it to Contact
            //    // -------------------------------------------------------------

            //    contactLogin.PasswordHash = contactLogin.PasswordHash; // should be the new password hash
            //    //aspNetUser.Password = resetPassword.Password;

            //    if (!contactLoginService.Update(contactLogin))
            //    {
            //        validationResults = contactLogin.ValidationResults;
            //        return false;
            //    };

            //    if (!Delete(resetPasswordRet))
            //    {
            //        validationResults = resetPasswordRet.ValidationResults;
            //        return false;
            //    }

            //    ts.Complete();
            //}
            return true;
        }
        #endregion Function public

        #region Function private
        private IQueryable<ResetPassword> FillResetPasswordReport(IQueryable<ResetPassword> resetPasswordQuery, string FilterAndOrderText)
        {
            resetPasswordQuery = (from c in resetPasswordQuery
                                  let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                  select new ResetPassword
                                  {
                                      ResetPasswordID = c.ResetPasswordID,
                                      Email = c.Email,
                                      ExpireDate_Local = c.ExpireDate_Local,
                                      Code = c.Code,
                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                      ResetPasswordWeb = new ResetPasswordWeb
                                      {
                                          LastUpdateContactTVText = LastUpdateContactTVText,
                                          //Password = Password,
                                          //ConfirmPassword = ConfirmPassword,
                                      },
                                      ResetPasswordReport = new ResetPasswordReport
                                      {
                                          ResetPasswordReportTest = "ResetPasswordReportTest",
                                      },
                                      HasErrors = false,
                                      ValidationResults = null,
                                  });

            return resetPasswordQuery;
        }
        #endregion Functions private    
    }
}
