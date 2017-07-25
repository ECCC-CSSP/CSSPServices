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

            if (string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVTypeName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeNamesAndPathTVTypeName), new[] { ModelsRes.TVTypeNamesAndPathTVTypeName });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVTypeName) && (tvTypeNamesAndPath.TVTypeName.Length < 1 || tvTypeNamesAndPath.TVTypeName.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVTypeNamesAndPathTVTypeName, "1", "255"), new[] { ModelsRes.TVTypeNamesAndPathTVTypeName });
            }

            //Index (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvTypeNamesAndPath.Index < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeNamesAndPathIndex, "1"), new[] { ModelsRes.TVTypeNamesAndPathIndex });
            }

            if (string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVPath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeNamesAndPathTVPath), new[] { ModelsRes.TVTypeNamesAndPathTVPath });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVPath) && (tvTypeNamesAndPath.TVPath.Length < 1 || tvTypeNamesAndPath.TVPath.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVTypeNamesAndPathTVPath, "1", "255"), new[] { ModelsRes.TVTypeNamesAndPathTVPath });
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
