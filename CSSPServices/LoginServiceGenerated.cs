using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    /// <summary>
    ///     <para>bonjour Login</para>
    /// </summary>
    public partial class LoginService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LoginService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Login login = validationContext.ObjectInstance as Login;
            login.HasErrors = false;

            if (string.IsNullOrWhiteSpace(login.LoginEmail))
            {
                login.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LoginLoginEmail), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(login.LoginEmail) && (login.LoginEmail.Length < 6 || login.LoginEmail.Length > 200))
            {
                login.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LoginLoginEmail, "6", "200"), new[] { "LoginEmail" });
            }

            if (string.IsNullOrWhiteSpace(login.Password))
            {
                login.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LoginPassword), new[] { "Password" });
            }

            if (!string.IsNullOrWhiteSpace(login.Password) && (login.Password.Length < 6 || login.Password.Length > 100))
            {
                login.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LoginPassword, "6", "100"), new[] { "Password" });
            }

            if (string.IsNullOrWhiteSpace(login.ConfirmPassword))
            {
                login.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LoginConfirmPassword), new[] { "ConfirmPassword" });
            }

            if (!string.IsNullOrWhiteSpace(login.ConfirmPassword) && (login.ConfirmPassword.Length < 6 || login.ConfirmPassword.Length > 100))
            {
                login.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LoginConfirmPassword, "6", "100"), new[] { "ConfirmPassword" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                login.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
