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
    public partial class LastUpdateAndTVTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LastUpdateAndTVText lastUpdateAndTVText = validationContext.ObjectInstance as LastUpdateAndTVText;

            if (string.IsNullOrWhiteSpace(lastUpdateAndTVText.Error))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LastUpdateAndTVTextError), new[] { ModelsRes.LastUpdateAndTVTextError });
            }

            //Error has no StringLength Attribute

            if (lastUpdateAndTVText.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LastUpdateAndTVTextLastUpdateDate_UTC), new[] { ModelsRes.LastUpdateAndTVTextLastUpdateDate_UTC });
            }

            if (lastUpdateAndTVText.LastUpdateDate_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LastUpdateAndTVTextLastUpdateDate_Local), new[] { ModelsRes.LastUpdateAndTVTextLastUpdateDate_Local });
            }

            if (string.IsNullOrWhiteSpace(lastUpdateAndTVText.TVText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LastUpdateAndTVTextTVText), new[] { ModelsRes.LastUpdateAndTVTextTVText });
            }

            if (!string.IsNullOrWhiteSpace(lastUpdateAndTVText.TVText) && (lastUpdateAndTVText.TVText.Length < 1 || lastUpdateAndTVText.TVText.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LastUpdateAndTVTextTVText, "1", "200"), new[] { ModelsRes.LastUpdateAndTVTextTVText });
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
