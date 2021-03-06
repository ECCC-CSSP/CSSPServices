/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.LastUpdateAndTVText](CSSPModels.LastUpdateAndTVText.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class LastUpdateAndTVTextService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB LastUpdateAndTVTexts table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public LastUpdateAndTVTextService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all LastUpdateAndTVTextService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LastUpdateAndTVText lastUpdateAndTVText = validationContext.ObjectInstance as LastUpdateAndTVText;
            lastUpdateAndTVText.HasErrors = false;

            if (lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC.Year == 1)
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateAndTVTextDate_UTC"), new[] { "LastUpdateAndTVTextDate_UTC" });
            }
            else
            {
                if (lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC.Year < 1980)
                {
                lastUpdateAndTVText.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateAndTVTextDate_UTC", "1980"), new[] { "LastUpdateAndTVTextDate_UTC" });
                }
            }

            if (lastUpdateAndTVText.LastUpdateDate_Local.Year == 1)
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_Local"), new[] { "LastUpdateDate_Local" });
            }
            else
            {
                if (lastUpdateAndTVText.LastUpdateDate_Local.Year < 1980)
                {
                lastUpdateAndTVText.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_Local", "1980"), new[] { "LastUpdateDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(lastUpdateAndTVText.TVText))
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVText"), new[] { "TVText" });
            }

            if (!string.IsNullOrWhiteSpace(lastUpdateAndTVText.TVText) && (lastUpdateAndTVText.TVText.Length < 1 || lastUpdateAndTVText.TVText.Length > 200))
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "TVText", "1", "200"), new[] { "TVText" });
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                lastUpdateAndTVText.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
