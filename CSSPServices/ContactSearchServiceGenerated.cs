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
    public partial class ContactSearchService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ContactSearchService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //ContactID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contactSearch.ContactID < 1)
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactSearchContactID, "1"), new[] { "ContactID" });
            }

            //ContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (contactSearch.ContactTVItemID < 1)
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactSearchContactTVItemID, "1"), new[] { "ContactTVItemID" });
            }

            if (string.IsNullOrWhiteSpace(contactSearch.FullName))
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactSearchFullName), new[] { "FullName" });
            }

            if (!string.IsNullOrWhiteSpace(contactSearch.FullName) && contactSearch.FullName.Length > 255)
            {
                contactSearch.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.ContactSearchFullName, "255"), new[] { "FullName" });
            }

            //HasErrors (bool) is required but no testing needed 

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
