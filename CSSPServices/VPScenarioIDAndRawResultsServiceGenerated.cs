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
    public partial class VPScenarioIDAndRawResultsService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioIDAndRawResultsService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            VPScenarioIDAndRawResults vpScenarioIDAndRawResults = validationContext.ObjectInstance as VPScenarioIDAndRawResults;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //VPScenarioID is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (vpScenarioIDAndRawResults.VPScenarioID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.VPScenarioIDAndRawResultsVPScenarioID, "1"), new[] { ModelsRes.VPScenarioIDAndRawResultsVPScenarioID });
            }

            // RawResults no min or max length set

        }
        #endregion Validation

    }
}
