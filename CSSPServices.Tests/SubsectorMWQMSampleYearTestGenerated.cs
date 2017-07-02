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
    public partial class SubsectorMWQMSampleYearTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int SubsectorMWQMSampleYearID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SubsectorMWQMSampleYear GetFilledRandomSubsectorMWQMSampleYear(string OmitPropName)
        {
            SubsectorMWQMSampleYearID += 1;

            SubsectorMWQMSampleYear subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();

            if (OmitPropName != "SubsectorTVItemID") subsectorMWQMSampleYear.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Year") subsectorMWQMSampleYear.Year = GetRandomInt(1, 5);
            if (OmitPropName != "EarliestDate") subsectorMWQMSampleYear.EarliestDate = GetRandomDateTime();
            if (OmitPropName != "LatestDate") subsectorMWQMSampleYear.LatestDate = GetRandomDateTime();

            return subsectorMWQMSampleYear;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SubsectorMWQMSampleYear_Testing()
        {
            SetupTestHelper(culture);
            SubsectorMWQMSampleYearService subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
