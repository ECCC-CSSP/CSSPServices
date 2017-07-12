using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class LabSheetA1MeasurementTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int LabSheetA1MeasurementID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetA1Measurement GetFilledRandomLabSheetA1Measurement(string OmitPropName)
        {
            LabSheetA1MeasurementID += 1;

            LabSheetA1Measurement labSheetA1Measurement = new LabSheetA1Measurement();

            if (OmitPropName != "Site") labSheetA1Measurement.Site = GetRandomString("", 20);
            if (OmitPropName != "TVItemID") labSheetA1Measurement.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Time") labSheetA1Measurement.Time = GetRandomDateTime();
            if (OmitPropName != "MPN") labSheetA1Measurement.MPN = GetRandomInt(1, 1000);
            if (OmitPropName != "Tube10") labSheetA1Measurement.Tube10 = GetRandomInt(1, 1000);
            if (OmitPropName != "Tube1_0") labSheetA1Measurement.Tube1_0 = GetRandomInt(1, 1000);
            if (OmitPropName != "Tube0_1") labSheetA1Measurement.Tube0_1 = GetRandomInt(1, 1000);
            if (OmitPropName != "Salinity") labSheetA1Measurement.Salinity = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "Temperature") labSheetA1Measurement.Temperature = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "ProcessedBy") labSheetA1Measurement.ProcessedBy = GetRandomString("", 20);
            if (OmitPropName != "SampleType") labSheetA1Measurement.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetA1Measurement.SiteComment = GetRandomString("", 20);

            return labSheetA1Measurement;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetA1Measurement_Testing()
        {
            SetupTestHelper(culture);
            LabSheetA1MeasurementService labSheetA1MeasurementService = new LabSheetA1MeasurementService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            LabSheetA1Measurement labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


        }
        #endregion Tests Generated
    }
}
