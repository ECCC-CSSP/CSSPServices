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
    ///     <para>bonjour VPScenarioIDAndRawResults</para>
    /// </summary>
    public partial class VPScenarioIDAndRawResultsService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioIDAndRawResultsService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPScenarioIDAndRawResults vpScenarioIDAndRawResults = validationContext.ObjectInstance as VPScenarioIDAndRawResults;
            vpScenarioIDAndRawResults.HasErrors = false;

            if (vpScenarioIDAndRawResults.VPScenarioID < 1)
            {
                vpScenarioIDAndRawResults.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.VPScenarioIDAndRawResultsVPScenarioID, "1"), new[] { "VPScenarioID" });
            }

            if (string.IsNullOrWhiteSpace(vpScenarioIDAndRawResults.RawResults))
            {
                vpScenarioIDAndRawResults.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioIDAndRawResultsRawResults), new[] { "RawResults" });
            }

            //RawResults has no StringLength Attribute

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpScenarioIDAndRawResults.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
