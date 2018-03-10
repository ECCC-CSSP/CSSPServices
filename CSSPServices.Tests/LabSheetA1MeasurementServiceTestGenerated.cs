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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class LabSheetA1MeasurementServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetA1MeasurementService labSheetA1MeasurementService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetA1MeasurementServiceTest() : base()
        {
            //labSheetA1MeasurementService = new LabSheetA1MeasurementService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetA1Measurement GetFilledRandomLabSheetA1Measurement(string OmitPropName)
        {
            LabSheetA1Measurement labSheetA1Measurement = new LabSheetA1Measurement();

            if (OmitPropName != "Site") labSheetA1Measurement.Site = GetRandomString("", 20);
            if (OmitPropName != "TVItemID") labSheetA1Measurement.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Time") labSheetA1Measurement.Time = new DateTime(2005, 3, 6);
            // should implement a Range for the property MPN and type LabSheetA1Measurement
            // should implement a Range for the property Tube10 and type LabSheetA1Measurement
            // should implement a Range for the property Tube1_0 and type LabSheetA1Measurement
            // should implement a Range for the property Tube0_1 and type LabSheetA1Measurement
            // should implement a Range for the property Salinity and type LabSheetA1Measurement
            // should implement a Range for the property Temperature and type LabSheetA1Measurement
            if (OmitPropName != "ProcessedBy") labSheetA1Measurement.ProcessedBy = GetRandomString("", 20);
            if (OmitPropName != "SampleType") labSheetA1Measurement.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "SiteComment") labSheetA1Measurement.SiteComment = GetRandomString("", 20);
            if (OmitPropName != "SampleTypeText") labSheetA1Measurement.SampleTypeText = GetRandomString("", 5);

            return labSheetA1Measurement;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheetA1Measurement_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetA1MeasurementService labSheetA1MeasurementService = new LabSheetA1MeasurementService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LabSheetA1Measurement labSheetA1Measurement = GetFilledRandomLabSheetA1Measurement("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

        #region Tests Generated Get List of LabSheetA1Measurement
        #endregion Tests Get List of LabSheetA1Measurement

    }
}
