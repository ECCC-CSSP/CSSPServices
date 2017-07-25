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
        private SubsectorMWQMSampleYearService subsectorMWQMSampleYearService { get; set; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearTest() : base()
        {
            subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SubsectorMWQMSampleYear GetFilledRandomSubsectorMWQMSampleYear(string OmitPropName)
        {
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();

            if (OmitPropName != "SubsectorTVItemID") subsectorMWQMSampleYear.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "Year") subsectorMWQMSampleYear.Year = GetRandomInt(1, 1000);
            if (OmitPropName != "EarliestDate") subsectorMWQMSampleYear.EarliestDate = GetRandomDateTime();
            if (OmitPropName != "LatestDate") subsectorMWQMSampleYear.LatestDate = GetRandomDateTime();

            return subsectorMWQMSampleYear;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SubsectorMWQMSampleYear_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            SubsectorMWQMSampleYear subsectorMWQMSampleYear = GetFilledRandomSubsectorMWQMSampleYear("");

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
