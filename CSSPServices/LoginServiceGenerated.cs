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

            if (string.IsNullOrWhiteSpace(login.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LoginLoginEmail), new[] { ModelsRes.LoginLoginEmail });
            }

            if (!string.IsNullOrWhiteSpace(login.LoginEmail) && (login.LoginEmail.Length < 6 || login.LoginEmail.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LoginLoginEmail, "6", "200"), new[] { ModelsRes.LoginLoginEmail });
            }

            if (string.IsNullOrWhiteSpace(login.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LoginPassword), new[] { ModelsRes.LoginPassword });
            }

            if (!string.IsNullOrWhiteSpace(login.Password) && (login.Password.Length < 6 || login.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LoginPassword, "6", "100"), new[] { ModelsRes.LoginPassword });
            }

            if (string.IsNullOrWhiteSpace(login.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LoginConfirmPassword), new[] { ModelsRes.LoginConfirmPassword });
            }

            if (!string.IsNullOrWhiteSpace(login.ConfirmPassword) && (login.ConfirmPassword.Length < 6 || login.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LoginConfirmPassword, "6", "100"), new[] { ModelsRes.LoginConfirmPassword });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
