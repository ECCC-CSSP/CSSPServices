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
    ///     <para>bonjour LabSheetA1Measurement</para>
    /// </summary>
    public partial class LabSheetA1MeasurementService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetA1Measurement labSheetA1Measurement = validationContext.ObjectInstance as LabSheetA1Measurement;
            labSheetA1Measurement.HasErrors = false;

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.Site))
            {
                labSheetA1Measurement.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetA1MeasurementSite), new[] { "Site" });
            }

            //Site has no StringLength Attribute

            if (labSheetA1Measurement.TVItemID < 1)
            {
                labSheetA1Measurement.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.LabSheetA1MeasurementTVItemID, "1"), new[] { "TVItemID" });
            }

            //MPN has no Range Attribute

            //Tube10 has no Range Attribute

            //Tube1_0 has no Range Attribute

            //Tube0_1 has no Range Attribute

            //Salinity has no Range Attribute

            //Temperature has no Range Attribute

            //ProcessedBy has no StringLength Attribute

            if (labSheetA1Measurement.SampleType != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetA1Measurement.SampleType);
                if (labSheetA1Measurement.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    labSheetA1Measurement.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetA1MeasurementSampleType), new[] { "SampleType" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheetA1Measurement.SiteComment))
            {
                labSheetA1Measurement.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetA1MeasurementSiteComment), new[] { "SiteComment" });
            }

            //SiteComment has no StringLength Attribute

            if (!string.IsNullOrWhiteSpace(labSheetA1Measurement.SampleTypeText) && labSheetA1Measurement.SampleTypeText.Length > 100)
            {
                labSheetA1Measurement.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetA1MeasurementSampleTypeText, "100"), new[] { "SampleTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                labSheetA1Measurement.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
