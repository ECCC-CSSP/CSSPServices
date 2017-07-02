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
        public RegisterService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            Register register = validationContext.ObjectInstance as Register;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (string.IsNullOrWhiteSpace(register.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterLoginEmail), new[] { ModelsRes.RegisterLoginEmail });
            }

            if (string.IsNullOrWhiteSpace(register.FirstName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterFirstName), new[] { ModelsRes.RegisterFirstName });
            }

            if (string.IsNullOrWhiteSpace(register.LastName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterLastName), new[] { ModelsRes.RegisterLastName });
            }

            if (string.IsNullOrWhiteSpace(register.WebName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterWebName), new[] { ModelsRes.RegisterWebName });
            }

            if (string.IsNullOrWhiteSpace(register.Password))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterPassword), new[] { ModelsRes.RegisterPassword });
            }

            if (string.IsNullOrWhiteSpace(register.ConfirmPassword))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RegisterConfirmPassword), new[] { ModelsRes.RegisterConfirmPassword });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(register.LoginEmail) && (register.LoginEmail.Length < 6) || (register.LoginEmail.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterLoginEmail, "6", "255"), new[] { ModelsRes.RegisterLoginEmail });
            }

            if (!string.IsNullOrWhiteSpace(register.FirstName) && (register.FirstName.Length < 1) || (register.FirstName.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterFirstName, "1", "100"), new[] { ModelsRes.RegisterFirstName });
            }

            if (!string.IsNullOrWhiteSpace(register.Initial) && (register.Initial.Length < 0) || (register.Initial.Length > 50))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterInitial, "0", "50"), new[] { ModelsRes.RegisterInitial });
            }

            if (!string.IsNullOrWhiteSpace(register.LastName) && (register.LastName.Length < 1) || (register.LastName.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterLastName, "1", "100"), new[] { ModelsRes.RegisterLastName });
            }

            if (!string.IsNullOrWhiteSpace(register.WebName) && (register.WebName.Length < 1) || (register.WebName.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterWebName, "1", "100"), new[] { ModelsRes.RegisterWebName });
            }

            if (!string.IsNullOrWhiteSpace(register.Password) && (register.Password.Length < 6) || (register.Password.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterPassword, "6", "100"), new[] { ModelsRes.RegisterPassword });
            }

            if (!string.IsNullOrWhiteSpace(register.ConfirmPassword) && (register.ConfirmPassword.Length < 6) || (register.ConfirmPassword.Length > 100))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.RegisterConfirmPassword, "6", "100"), new[] { ModelsRes.RegisterConfirmPassword });
            }

                //LoginEmail will need to implement Email Not Mapped

        }
        #endregion Validation

    }
}
