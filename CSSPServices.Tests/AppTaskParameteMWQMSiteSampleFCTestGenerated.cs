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
    public partial class AppTaskParameteMWQMSiteSampleFCTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AppTaskParameteMWQMSiteSampleFCID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskParameteMWQMSiteSampleFCTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private AppTaskParameteMWQMSiteSampleFC GetFilledRandomAppTaskParameteMWQMSiteSampleFC(string OmitPropName)
        {
            AppTaskParameteMWQMSiteSampleFCID += 1;

            AppTaskParameteMWQMSiteSampleFC appTaskParameteMWQMSiteSampleFC = new AppTaskParameteMWQMSiteSampleFC();

            if (OmitPropName != "Error") appTaskParameteMWQMSiteSampleFC.Error = GetRandomString("", 5);
            SampleDate = GetRandomSomethingElse(),
            FC = GetRandomSomethingElse(),
            if (OmitPropName != "Sal") appTaskParameteMWQMSiteSampleFC.Sal = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "Temp") appTaskParameteMWQMSiteSampleFC.Temp = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "PH") appTaskParameteMWQMSiteSampleFC.PH = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "DO") appTaskParameteMWQMSiteSampleFC.DO = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "Depth") appTaskParameteMWQMSiteSampleFC.Depth = GetRandomFloat(1.0f, 5.0f)
            SampCount = GetRandomSomethingElse(),
            MinFC = GetRandomSomethingElse(),
            MaxFC = GetRandomSomethingElse(),
            if (OmitPropName != "GeoMean") appTaskParameteMWQMSiteSampleFC.GeoMean = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "Median") appTaskParameteMWQMSiteSampleFC.Median = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "P90") appTaskParameteMWQMSiteSampleFC.P90 = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "PercOver43") appTaskParameteMWQMSiteSampleFC.PercOver43 = GetRandomFloat(1.0f, 5.0f)
            if (OmitPropName != "PercOver260") appTaskParameteMWQMSiteSampleFC.PercOver260 = GetRandomFloat(1.0f, 5.0f)

            return appTaskParameteMWQMSiteSampleFC;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void AppTaskParameteMWQMSiteSampleFC_Testing()
        {
            SetupTestHelper(culture);
            AppTaskParameteMWQMSiteSampleFCService appTaskParameteMWQMSiteSampleFCService = new AppTaskParameteMWQMSiteSampleFCService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
