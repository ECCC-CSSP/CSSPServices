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
    public partial class SearchService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SearchService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            Search search = validationContext.ObjectInstance as Search;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (string.IsNullOrWhiteSpace(search.value))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.Searchvalue), new[] { ModelsRes.Searchvalue });
            }

            //id is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (!string.IsNullOrWhiteSpace(search.value) && (search.value.Length < 1) || (search.value.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.Searchvalue, "1", "255"), new[] { ModelsRes.Searchvalue });
            }

            if (search.id < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.Searchid, "1"), new[] { ModelsRes.Searchid });
            }


        }
        #endregion Validation

    }
}
