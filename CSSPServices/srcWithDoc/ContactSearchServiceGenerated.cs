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
    ///     <para>bonjour ContactSearch</para>
    /// </summary>
    public partial class ContactSearchService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactSearchService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            ContactSearch contactSearch = validationContext.ObjectInstance as ContactSearch;
            contactSearch.HasErrors = false;

            if (contactSearch.ContactID < 1)
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "ContactSearchContactID", "1"), new[] { "ContactID" });
            }

            if (contactSearch.ContactTVItemID < 1)
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "ContactSearchContactTVItemID", "1"), new[] { "ContactTVItemID" });
            }

            if (string.IsNullOrWhiteSpace(contactSearch.FullName))
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ContactSearchFullName"), new[] { "FullName" });
            }

            if (!string.IsNullOrWhiteSpace(contactSearch.FullName) && contactSearch.FullName.Length > 255)
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ContactSearchFullName", "255"), new[] { "FullName" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}