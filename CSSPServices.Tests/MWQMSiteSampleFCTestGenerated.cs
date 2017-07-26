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
        private MWQMSiteSampleFCService mwqmSiteSampleFCService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCTest() : base()
        {
            mwqmSiteSampleFCService = new MWQMSiteSampleFCService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSiteSampleFC GetFilledRandomMWQMSiteSampleFC(string OmitPropName)
        {
            MWQMSiteSampleFC mwqmSiteSampleFC = new MWQMSiteSampleFC();

            if (OmitPropName != "Error") mwqmSiteSampleFC.Error = GetRandomString("", 20);
            if (OmitPropName != "SampleDate") mwqmSiteSampleFC.SampleDate = GetRandomDateTime();
            if (OmitPropName != "FC") mwqmSiteSampleFC.FC = GetRandomInt(1, 100000000);
            // should implement a Range for the property Sal and type MWQMSiteSampleFC
            // should implement a Range for the property Temp and type MWQMSiteSampleFC
            // should implement a Range for the property PH and type MWQMSiteSampleFC
            // should implement a Range for the property DO and type MWQMSiteSampleFC
            // should implement a Range for the property Depth and type MWQMSiteSampleFC
            // should implement a Range for the property SampCount and type MWQMSiteSampleFC
            // should implement a Range for the property MinFC and type MWQMSiteSampleFC
            // should implement a Range for the property MaxFC and type MWQMSiteSampleFC
            // should implement a Range for the property GeoMean and type MWQMSiteSampleFC
            // should implement a Range for the property Median and type MWQMSiteSampleFC
            // should implement a Range for the property P90 and type MWQMSiteSampleFC
            // should implement a Range for the property PercOver43 and type MWQMSiteSampleFC
            // should implement a Range for the property PercOver260 and type MWQMSiteSampleFC

            return mwqmSiteSampleFC;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSiteSampleFC_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMSiteSampleFC mwqmSiteSampleFC = GetFilledRandomMWQMSiteSampleFC("");

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
        #endregion Tests Generated
    }
}
