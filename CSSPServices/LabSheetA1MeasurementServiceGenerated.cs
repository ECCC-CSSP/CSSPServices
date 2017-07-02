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
    public partial class LabSheetA1MeasurementService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetA1Measurement labSheetA1Measurement = validationContext.ObjectInstance as LabSheetA1Measurement;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            //TVItemID is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            // Site no min or max length set
            if (labSheetA1Measurement.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetA1MeasurementTVItemID, "1"), new[] { ModelsRes.LabSheetA1MeasurementTVItemID });
            }

            // MPN no min or max length set
            // Tube10 no min or max length set
            // Tube1_0 no min or max length set
            // Tube0_1 no min or max length set
            // Salinity no min or max length set
            // Temperature no min or max length set
            // ProcessedBy no min or max length set
            // SampleType no min or max length set
            // SiteComment no min or max length set

        }
        #endregion Validation

    }
}
