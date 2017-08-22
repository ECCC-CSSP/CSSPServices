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
    public partial class SearchTagAndTermsService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SearchTagAndTerms searchTagAndTerms = validationContext.ObjectInstance as SearchTagAndTerms;
            searchTagAndTerms.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(SearchTagEnum), (int?)searchTagAndTerms.SearchTag);
            if (searchTagAndTerms.SearchTag == SearchTagEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SearchTagAndTermsSearchTag), new[] { "SearchTag" });
            }

            if (!string.IsNullOrWhiteSpace(searchTagAndTerms.SearchTagText) && searchTagAndTerms.SearchTagText.Length > 100)
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SearchTagAndTermsSearchTagText, "100"), new[] { "SearchTagText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
