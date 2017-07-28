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
    public partial class RegisterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RegisterService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Register register = validationContext.ObjectInstance as Register;

            if (string.IsNullOrWhiteSpace(register.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterLoginEmail), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(register.LoginEmail) && (register.LoginEmail.Length < 6 || register.LoginEmail.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterLoginEmail, "6", "255"), new[] { "LoginEmail" });
            }

            if (string.IsNullOrWhiteSpace(register.FirstName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterFirstName), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(register.FirstName) && (register.FirstName.Length < 1 || register.FirstName.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterFirstName, "1", "100"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(register.Initial) && register.Initial.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RegisterInitial, "50"), new[] { "Initial" });
            }

            if (string.IsNullOrWhiteSpace(register.LastName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterLastName), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(register.LastName) && (register.LastName.Length < 1 || register.LastName.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterLastName, "1", "100"), new[] { "LastName" });
            }

            if (string.IsNullOrWhiteSpace(register.WebName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterWebName), new[] { "WebName" });
            }

            if (!string.IsNullOrWhiteSpace(register.WebName) && (register.WebName.Length < 1 || register.WebName.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterWebName, "1", "100"), new[] { "WebName" });
            }

            if (string.IsNullOrWhiteSpace(register.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterPassword), new[] { "Password" });
            }

            if (!string.IsNullOrWhiteSpace(register.Password) && (register.Password.Length < 6 || register.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterPassword, "6", "100"), new[] { "Password" });
            }

            if (string.IsNullOrWhiteSpace(register.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterConfirmPassword), new[] { "ConfirmPassword" });
            }

            if (!string.IsNullOrWhiteSpace(register.ConfirmPassword) && (register.ConfirmPassword.Length < 6 || register.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterConfirmPassword, "6", "100"), new[] { "ConfirmPassword" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
