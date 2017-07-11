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
    public partial class TVFullTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFullTextService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFullText tvFullText = validationContext.ObjectInstance as TVFullText;

            if (string.IsNullOrWhiteSpace(tvFullText.TVPath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFullTextTVPath), new[] { ModelsRes.TVFullTextTVPath });
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.TVPath) && (tvFullText.TVPath.Length < 1 || tvFullText.TVPath.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFullTextTVPath, "1", "255"), new[] { ModelsRes.TVFullTextTVPath });
            }

            if (string.IsNullOrWhiteSpace(tvFullText.FullText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFullTextFullText), new[] { ModelsRes.TVFullTextFullText });
            }

            if (!string.IsNullOrWhiteSpace(tvFullText.FullText) && (tvFullText.FullText.Length < 1 || tvFullText.FullText.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFullTextFullText, "1", "255"), new[] { ModelsRes.TVFullTextFullText });
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
