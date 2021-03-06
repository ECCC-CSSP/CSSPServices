/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
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
    public partial class SearchTagAndTermsService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SearchTagAndTerms searchTagAndTerms = validationContext.ObjectInstance as SearchTagAndTerms;
            searchTagAndTerms.HasErrors = false;

            retStr = enums.EnumTypeOK(typeof(SearchTagEnum), (int?)searchTagAndTerms.SearchTag);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SearchTag"), new[] { "SearchTag" });
            }

            if (!string.IsNullOrWhiteSpace(searchTagAndTerms.SearchTagText) && searchTagAndTerms.SearchTagText.Length > 100)
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SearchTagText", "100"), new[] { "SearchTagText" });
            }

                //CSSPError: Type not implemented [SearchTermList] of type [List`1]

            //SearchTermList has no StringLength Attribute

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                searchTagAndTerms.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
