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
    public partial class MWQMSiteSampleFCTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSiteSampleFCID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSiteSampleFC GetFilledRandomMWQMSiteSampleFC(string OmitPropName)
        {
            MWQMSiteSampleFCID += 1;

            MWQMSiteSampleFC mwqmSiteSampleFC = new MWQMSiteSampleFC();

            if (OmitPropName != "Error") mwqmSiteSampleFC.Error = GetRandomString("", 20);
            if (OmitPropName != "SampleDate") mwqmSiteSampleFC.SampleDate = GetRandomDateTime();
            if (OmitPropName != "FC") mwqmSiteSampleFC.FC = GetRandomInt(1, 100000000);
            if (OmitPropName != "Sal") mwqmSiteSampleFC.Sal = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "Temp") mwqmSiteSampleFC.Temp = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "PH") mwqmSiteSampleFC.PH = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "DO") mwqmSiteSampleFC.DO = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "Depth") mwqmSiteSampleFC.Depth = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "SampCount") mwqmSiteSampleFC.SampCount = GetRandomInt(1, 1000);
            if (OmitPropName != "MinFC") mwqmSiteSampleFC.MinFC = GetRandomInt(1, 1000);
            if (OmitPropName != "MaxFC") mwqmSiteSampleFC.MaxFC = GetRandomInt(1, 1000);
            if (OmitPropName != "GeoMean") mwqmSiteSampleFC.GeoMean = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "Median") mwqmSiteSampleFC.Median = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "P90") mwqmSiteSampleFC.P90 = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "PercOver43") mwqmSiteSampleFC.PercOver43 = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "PercOver260") mwqmSiteSampleFC.PercOver260 = GetRandomFloat(1.0f, 1000.0f);

            return mwqmSiteSampleFC;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSiteSampleFC_Testing()
        {
            SetupTestHelper(culture);
            MWQMSiteSampleFCService mwqmSiteSampleFCService = new MWQMSiteSampleFCService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            MWQMSiteSampleFC mwqmSiteSampleFC = GetFilledRandomMWQMSiteSampleFC("");

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
