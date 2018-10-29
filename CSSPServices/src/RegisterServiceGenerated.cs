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
    ///     <para>bonjour Register</para>
    /// </summary>
    public partial class RegisterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RegisterService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Register register = validationContext.ObjectInstance as Register;
            register.HasErrors = false;

            if (string.IsNullOrWhiteSpace(register.LoginEmail))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RegisterLoginEmail"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(register.LoginEmail) && (register.LoginEmail.Length < 6 || register.LoginEmail.Length > 255))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "RegisterLoginEmail", "6", "255"), new[] { "LoginEmail" });
            }

            if (string.IsNullOrWhiteSpace(register.FirstName))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RegisterFirstName"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(register.FirstName) && (register.FirstName.Length < 1 || register.FirstName.Length > 100))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "RegisterFirstName", "1", "100"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(register.Initial) && register.Initial.Length > 50)
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RegisterInitial", "50"), new[] { "Initial" });
            }

            if (string.IsNullOrWhiteSpace(register.LastName))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RegisterLastName"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(register.LastName) && (register.LastName.Length < 1 || register.LastName.Length > 100))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "RegisterLastName", "1", "100"), new[] { "LastName" });
            }

            if (string.IsNullOrWhiteSpace(register.WebName))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RegisterWebName"), new[] { "WebName" });
            }

            if (!string.IsNullOrWhiteSpace(register.WebName) && (register.WebName.Length < 1 || register.WebName.Length > 100))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "RegisterWebName", "1", "100"), new[] { "WebName" });
            }

            if (string.IsNullOrWhiteSpace(register.Password))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RegisterPassword"), new[] { "Password" });
            }

            if (!string.IsNullOrWhiteSpace(register.Password) && (register.Password.Length < 6 || register.Password.Length > 100))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "RegisterPassword", "6", "100"), new[] { "Password" });
            }

            if (string.IsNullOrWhiteSpace(register.ConfirmPassword))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RegisterConfirmPassword"), new[] { "ConfirmPassword" });
            }

            if (!string.IsNullOrWhiteSpace(register.ConfirmPassword) && (register.ConfirmPassword.Length < 6 || register.ConfirmPassword.Length > 100))
            {
                register.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "RegisterConfirmPassword", "6", "100"), new[] { "ConfirmPassword" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                register.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
