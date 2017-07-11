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
    public partial class TVLocationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVLocationService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVLocation tvLocation = validationContext.ObjectInstance as TVLocation;

            if (string.IsNullOrWhiteSpace(tvLocation.Error))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVLocationError), new[] { ModelsRes.TVLocationError });
            }

            //Error has no StringLength Attribute

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvLocation.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVLocationTVItemID, "1"), new[] { ModelsRes.TVLocationTVItemID });
            }

            if (string.IsNullOrWhiteSpace(tvLocation.TVText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVLocationTVText), new[] { ModelsRes.TVLocationTVText });
            }

            if (!string.IsNullOrWhiteSpace(tvLocation.TVText) && (tvLocation.TVText.Length < 1 || tvLocation.TVText.Length > 255))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVLocationTVText, "1", "255"), new[] { ModelsRes.TVLocationTVText });
            }

                //Error: Type not implemented [TVType] of type [TVTypeEnum]

                //Error: Type not implemented [TVType] of type [TVTypeEnum]
                //Error: Type not implemented [SubTVType] of type [TVTypeEnum]

                //Error: Type not implemented [SubTVType] of type [TVTypeEnum]
            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
