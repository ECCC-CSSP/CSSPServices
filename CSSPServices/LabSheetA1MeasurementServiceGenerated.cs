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
        public LabSheetA1MeasurementService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetA1Measurement labSheetA1Measurement = validationContext.ObjectInstance as LabSheetA1Measurement;

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.Site))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1MeasurementSite), new[] { ModelsRes.LabSheetA1MeasurementSite });
            }

            //Site has no StringLength Attribute

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheetA1Measurement.TVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetA1MeasurementTVItemID, "1"), new[] { ModelsRes.LabSheetA1MeasurementTVItemID });
            }

            //MPN has no Range Attribute

            //Tube10 has no Range Attribute

            //Tube1_0 has no Range Attribute

            //Tube0_1 has no Range Attribute

            //Salinity has no Range Attribute

            //Temperature (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Temperature has no Range Attribute

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.ProcessedBy))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1MeasurementProcessedBy), new[] { ModelsRes.LabSheetA1MeasurementProcessedBy });
            }

            //ProcessedBy has no StringLength Attribute

                //Error: Type not implemented [SampleType] of type [SampleTypeEnum]
            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.SiteComment))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetA1MeasurementSiteComment), new[] { ModelsRes.LabSheetA1MeasurementSiteComment });
            }

            //SiteComment has no StringLength Attribute

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
