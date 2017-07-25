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
    public partial class NewContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public NewContactService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            NewContact newContact = validationContext.ObjectInstance as NewContact;

            if (string.IsNullOrWhiteSpace(newContact.LoginEmail))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.NewContactLoginEmail), new[] { ModelsRes.NewContactLoginEmail });
            }

            if (!string.IsNullOrWhiteSpace(newContact.LoginEmail) && (newContact.LoginEmail.Length < 1 || newContact.LoginEmail.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.NewContactLoginEmail, "1", "200"), new[] { ModelsRes.NewContactLoginEmail });
            }

            if (string.IsNullOrWhiteSpace(newContact.FirstName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.NewContactFirstName), new[] { ModelsRes.NewContactFirstName });
            }

            if (!string.IsNullOrWhiteSpace(newContact.FirstName) && (newContact.FirstName.Length < 1 || newContact.FirstName.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.NewContactFirstName, "1", "200"), new[] { ModelsRes.NewContactFirstName });
            }

            if (string.IsNullOrWhiteSpace(newContact.LastName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.NewContactLastName), new[] { ModelsRes.NewContactLastName });
            }

            if (!string.IsNullOrWhiteSpace(newContact.LastName) && (newContact.LastName.Length < 1 || newContact.LastName.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.NewContactLastName, "1", "200"), new[] { ModelsRes.NewContactLastName });
            }

            if (!string.IsNullOrWhiteSpace(newContact.Initial) && newContact.Initial.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.NewContactInitial, "50"), new[] { ModelsRes.NewContactInitial });
            }

            if (newContact.ContactTitle != null)
            {
                retStr = enums.ContactTitleOK(newContact.ContactTitle);
                if (newContact.ContactTitle == ContactTitleEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.NewContactContactTitle });
                }
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
