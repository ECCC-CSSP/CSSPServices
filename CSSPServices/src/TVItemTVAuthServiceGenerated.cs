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
    ///     <para>bonjour TVItemTVAuth</para>
    /// </summary>
    public partial class TVItemTVAuthService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemTVAuthService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemTVAuth tvItemTVAuth = validationContext.ObjectInstance as TVItemTVAuth;
            tvItemTVAuth.HasErrors = false;

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.Error))
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVAuthError"), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (tvItemTVAuth.TVItemUserAuthID < 1)
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "TVItemTVAuthTVItemUserAuthID", "1"), new[] { "TVItemUserAuthID" });
            }

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVText))
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVAuthTVText"), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVText) && (tvItemTVAuth.TVText.Length < 1 || tvItemTVAuth.TVText.Length > 255))
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TVItemTVAuthTVText", "1", "255"), new[] { "TVText" });
            }

            if (tvItemTVAuth.TVItemID1 < 1)
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "TVItemTVAuthTVItemID1", "1"), new[] { "TVItemID1" });
            }

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVTypeStr))
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVAuthTVTypeStr"), new[] { "TVTypeStr" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVTypeStr) && (tvItemTVAuth.TVTypeStr.Length < 1 || tvItemTVAuth.TVTypeStr.Length > 255))
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TVItemTVAuthTVTypeStr", "1", "255"), new[] { "TVTypeStr" });
            }

            retStr = enums.EnumTypeOK(typeof(TVAuthEnum), (int?)tvItemTVAuth.TVAuth);
            if (tvItemTVAuth.TVAuth == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVItemTVAuthTVAuth"), new[] { "TVAuth" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVAuthText) && tvItemTVAuth.TVAuthText.Length > 100)
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVItemTVAuthTVAuthText", "100"), new[] { "TVAuthText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tvItemTVAuth.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}