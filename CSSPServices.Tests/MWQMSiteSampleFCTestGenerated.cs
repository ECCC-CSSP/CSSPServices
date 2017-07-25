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
            if (OmitPropName != "Sal") mwqmSiteSampleFC.Sal = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Temp") mwqmSiteSampleFC.Temp = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PH") mwqmSiteSampleFC.PH = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "DO") mwqmSiteSampleFC.DO = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Depth") mwqmSiteSampleFC.Depth = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "SampCount") mwqmSiteSampleFC.SampCount = GetRandomInt(1, 1000);
            if (OmitPropName != "MinFC") mwqmSiteSampleFC.MinFC = GetRandomInt(1, 1000);
            if (OmitPropName != "MaxFC") mwqmSiteSampleFC.MaxFC = GetRandomInt(1, 1000);
            if (OmitPropName != "GeoMean") mwqmSiteSampleFC.GeoMean = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Median") mwqmSiteSampleFC.Median = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "P90") mwqmSiteSampleFC.P90 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PercOver43") mwqmSiteSampleFC.PercOver43 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "PercOver260") mwqmSiteSampleFC.PercOver260 = GetRandomDouble(1.0D, 1000.0D);

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
