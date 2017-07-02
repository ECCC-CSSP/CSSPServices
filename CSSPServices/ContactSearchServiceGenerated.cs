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
        public ContactSearchService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            ContactSearch contactSearch = validationContext.ObjectInstance as ContactSearch;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //ContactID is required but no testing needed as it is automatically set to 0

            //ContactTVItemID is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(contactSearch.FullName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.ContactSearchFullName), new[] { ModelsRes.ContactSearchFullName });
            }

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (contactSearch.ContactID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactSearchContactID, "1"), new[] { ModelsRes.ContactSearchContactID });
            }

            if (contactSearch.ContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.ContactSearchContactTVItemID, "1"), new[] { ModelsRes.ContactSearchContactTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(contactSearch.FullName) && (contactSearch.FullName.Length < 1) || (contactSearch.FullName.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.ContactSearchFullName, "1", "255"), new[] { ModelsRes.ContactSearchFullName });
            }


        }
        #endregion Validation

    }
}
