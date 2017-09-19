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
    ///     <para>bonjour TVTypeNamesAndPath</para>
    /// </summary>
    public partial class TVTypeNamesAndPathService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVTypeNamesAndPath tvTypeNamesAndPath = validationContext.ObjectInstance as TVTypeNamesAndPath;
            tvTypeNamesAndPath.HasErrors = false;

            if (string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVTypeName))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeNamesAndPathTVTypeName), new[] { "TVTypeName" });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVTypeName) && (tvTypeNamesAndPath.TVTypeName.Length < 1 || tvTypeNamesAndPath.TVTypeName.Length > 255))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.TVTypeNamesAndPathTVTypeName, "1", "255"), new[] { "TVTypeName" });
            }

            //Index (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvTypeNamesAndPath.Index < 1)
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.TVTypeNamesAndPathIndex, "1"), new[] { "Index" });
            }

            if (string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVPath))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeNamesAndPathTVPath), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVPath) && (tvTypeNamesAndPath.TVPath.Length < 1 || tvTypeNamesAndPath.TVPath.Length > 255))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.TVTypeNamesAndPathTVPath, "1", "255"), new[] { "TVPath" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
