/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.NewContact](CSSPModels.NewContact.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [ContactTitleEnum](CSSPEnums.ContactTitleEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class NewContactService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB NewContacts table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public NewContactService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all NewContactService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            NewContact newContact = validationContext.ObjectInstance as NewContact;
            newContact.HasErrors = false;

            if (string.IsNullOrWhiteSpace(newContact.LoginEmail))
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LoginEmail"), new[] { "LoginEmail" });
            }

            if (!string.IsNullOrWhiteSpace(newContact.LoginEmail) && (newContact.LoginEmail.Length < 1 || newContact.LoginEmail.Length > 200))
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LoginEmail", "1", "200"), new[] { "LoginEmail" });
            }

            if (string.IsNullOrWhiteSpace(newContact.FirstName))
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FirstName"), new[] { "FirstName" });
            }

            if (!string.IsNullOrWhiteSpace(newContact.FirstName) && (newContact.FirstName.Length < 1 || newContact.FirstName.Length > 200))
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "FirstName", "1", "200"), new[] { "FirstName" });
            }

            if (string.IsNullOrWhiteSpace(newContact.LastName))
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastName"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(newContact.LastName) && (newContact.LastName.Length < 1 || newContact.LastName.Length > 200))
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LastName", "1", "200"), new[] { "LastName" });
            }

            if (!string.IsNullOrWhiteSpace(newContact.Initial) && newContact.Initial.Length > 50)
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "Initial", "50"), new[] { "Initial" });
            }

            if (newContact.ContactTitle != null)
            {
                retStr = enums.EnumTypeOK(typeof(ContactTitleEnum), (int?)newContact.ContactTitle);
                if (newContact.ContactTitle == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    newContact.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactTitle"), new[] { "ContactTitle" });
                }
            }

            if (!string.IsNullOrWhiteSpace(newContact.ContactTitleText) && newContact.ContactTitleText.Length > 100)
            {
                newContact.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactTitleText", "100"), new[] { "ContactTitleText" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                newContact.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
