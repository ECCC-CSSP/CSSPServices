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
    ///     <para>bonjour TVFullText</para>
    /// </summary>
    public partial class TVFullTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFullTextService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFullText tvFullText = validationContext.ObjectInstance as TVFullText;
            tvFullText.HasErrors = false;

            if (string.IsNullOrWhiteSpace(tvFullText.TVPath))
            {
                tvFullText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFullTextTVPath), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.TVPath) && (tvFullText.TVPath.Length < 1 || tvFullText.TVPath.Length > 255))
            {
                tvFullText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.TVFullTextTVPath, "1", "255"), new[] { "TVPath" });
            }

            if (string.IsNullOrWhiteSpace(tvFullText.FullText))
            {
                tvFullText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFullTextFullText), new[] { "FullText" });
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.FullText) && (tvFullText.FullText.Length < 1 || tvFullText.FullText.Length > 255))
            {
                tvFullText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.TVFullTextFullText, "1", "255"), new[] { "FullText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvFullText.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
