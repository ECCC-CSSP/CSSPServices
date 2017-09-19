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
    ///     <para>bonjour TVTextLanguage</para>
    /// </summary>
    public partial class TVTextLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTextLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTextLanguage tvTextLanguage = validationContext.ObjectInstance as TVTextLanguage;
            tvTextLanguage.HasErrors = false;

            if (string.IsNullOrWhiteSpace(tvTextLanguage.TVText))
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTextLanguageTVText), new[] { "TVText" });
            }

            //TVText has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvTextLanguage.Language);
            if (tvTextLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTextLanguageLanguage), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(tvTextLanguage.LanguageText) && tvTextLanguage.LanguageText.Length > 100)
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVTextLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvTextLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
