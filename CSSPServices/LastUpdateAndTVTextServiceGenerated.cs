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
    ///     <para>bonjour LastUpdateAndTVText</para>
    /// </summary>
    public partial class LastUpdateAndTVTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LastUpdateAndTVText lastUpdateAndTVText = validationContext.ObjectInstance as LastUpdateAndTVText;
            lastUpdateAndTVText.HasErrors = false;

            if (string.IsNullOrWhiteSpace(lastUpdateAndTVText.Error))
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndTVTextError), new[] { "Error" });
            }

            //Error has no StringLength Attribute

            if (lastUpdateAndTVText.LastUpdateDate_UTC.Year == 1)
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndTVTextLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (lastUpdateAndTVText.LastUpdateDate_UTC.Year < 1980)
                {
                lastUpdateAndTVText.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LastUpdateAndTVTextLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            if (lastUpdateAndTVText.LastUpdateDate_Local.Year == 1)
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndTVTextLastUpdateDate_Local), new[] { "LastUpdateDate_Local" });
            }
            else
            {
                if (lastUpdateAndTVText.LastUpdateDate_Local.Year < 1980)
                {
                lastUpdateAndTVText.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LastUpdateAndTVTextLastUpdateDate_Local, "1980"), new[] { "LastUpdateDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(lastUpdateAndTVText.TVText))
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LastUpdateAndTVTextTVText), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(lastUpdateAndTVText.TVText) && (lastUpdateAndTVText.TVText.Length < 1 || lastUpdateAndTVText.TVText.Length > 200))
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.LastUpdateAndTVTextTVText, "1", "200"), new[] { "TVText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
