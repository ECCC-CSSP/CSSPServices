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
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Search search = validationContext.ObjectInstance as Search;

            if (string.IsNullOrWhiteSpace(search.value))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.Searchvalue), new[] { ModelsRes.Searchvalue });
            }

            if (!string.IsNullOrWhiteSpace(search.value) && (search.value.Length < 1 || search.value.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.Searchvalue, "1", "255"), new[] { ModelsRes.Searchvalue });
            }

            //id (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (search.id < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.Searchid, "1"), new[] { ModelsRes.Searchid });
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
