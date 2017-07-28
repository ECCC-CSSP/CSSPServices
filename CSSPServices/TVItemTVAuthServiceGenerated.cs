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
    public partial class TVItemTVAuthService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemTVAuthService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemTVAuth tvItemTVAuth = validationContext.ObjectInstance as TVItemTVAuth;

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.Error))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVAuthError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            //TVItemUserAuthID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemTVAuth.TVItemUserAuthID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemTVAuthTVItemUserAuthID, "1"), new[] { "TVItemUserAuthID" });
            }

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVAuthTVText), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVText) && (tvItemTVAuth.TVText.Length < 1 || tvItemTVAuth.TVText.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemTVAuthTVText, "1", "255"), new[] { "TVText" });
            }

            //TVItemID1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemTVAuth.TVItemID1 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemTVAuthTVItemID1, "1"), new[] { "TVItemID1" });
            }

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVTypeStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVAuthTVTypeStr), new[] { "TVTypeStr" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVTypeStr) && (tvItemTVAuth.TVTypeStr.Length < 1 || tvItemTVAuth.TVTypeStr.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemTVAuthTVTypeStr, "1", "255"), new[] { "TVTypeStr" });
            }

                //Error: Type not implemented [TVAuth] of type [TVAuthEnum]

                //Error: Type not implemented [TVAuth] of type [TVAuthEnum]
            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
