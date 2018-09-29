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
        public TVTypeNamesAndPathService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTypeNamesAndPathTVTypeName"), new[] { "TVTypeName" });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVTypeName) && (tvTypeNamesAndPath.TVTypeName.Length < 1 || tvTypeNamesAndPath.TVTypeName.Length > 255))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TVTypeNamesAndPathTVTypeName", "1", "255"), new[] { "TVTypeName" });
            }

            if (tvTypeNamesAndPath.Index < 1)
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "TVTypeNamesAndPathIndex", "1"), new[] { "Index" });
            }

            if (string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVPath))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVTypeNamesAndPathTVPath"), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvTypeNamesAndPath.TVPath) && (tvTypeNamesAndPath.TVPath.Length < 1 || tvTypeNamesAndPath.TVPath.Length > 255))
            {
                tvTypeNamesAndPath.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TVTypeNamesAndPathTVPath", "1", "255"), new[] { "TVPath" });
            }

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
