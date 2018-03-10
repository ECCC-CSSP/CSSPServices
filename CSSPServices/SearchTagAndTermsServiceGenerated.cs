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
    ///     <para>bonjour SearchTagAndTerms</para>
    /// </summary>
    public partial class SearchTagAndTermsService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SearchTagAndTermsSearchTag), new[] { "SearchTag" });
            }

            if (!string.IsNullOrWhiteSpace(searchTagAndTerms.SearchTagText) && searchTagAndTerms.SearchTagText.Length > 100)
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SearchTagAndTermsSearchTagText, "100"), new[] { "SearchTagText" });
            }

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
