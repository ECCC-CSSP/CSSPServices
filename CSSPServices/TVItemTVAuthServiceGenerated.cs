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
        public TVItemTVAuthService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemTVAuth tvItemTVAuth = validationContext.ObjectInstance as TVItemTVAuth;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //TVItemUserAuthID is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(tvItemTVAuth.TVText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVAuthTVText), new[] { ModelsRes.TVItemTVAuthTVText });
            }

            //TVItemID1 is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Error no min or max length set
            if (tvItemTVAuth.TVItemUserAuthID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemTVAuthTVItemUserAuthID, "1"), new[] { ModelsRes.TVItemTVAuthTVItemUserAuthID });
            }

            if (!string.IsNullOrWhiteSpace(tvItemTVAuth.TVText) && (tvItemTVAuth.TVText.Length < 1) || (tvItemTVAuth.TVText.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemTVAuthTVText, "1", "255"), new[] { ModelsRes.TVItemTVAuthTVText });
            }

            if (tvItemTVAuth.TVItemID1 < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemTVAuthTVItemID1, "1"), new[] { ModelsRes.TVItemTVAuthTVItemID1 });
            }

            // TVTypeStr no min or max length set
            // TVAuth no min or max length set

        }
        #endregion Validation

    }
}
