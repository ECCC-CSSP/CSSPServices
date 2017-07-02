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
    public partial class VPScenarioIDAndRawResultsTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int VPScenarioIDAndRawResultsID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioIDAndRawResultsTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenarioIDAndRawResults GetFilledRandomVPScenarioIDAndRawResults(string OmitPropName)
        {
            VPScenarioIDAndRawResultsID += 1;

            VPScenarioIDAndRawResults vpScenarioIDAndRawResults = new VPScenarioIDAndRawResults();

            if (OmitPropName != "VPScenarioID") vpScenarioIDAndRawResults.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "RawResults") vpScenarioIDAndRawResults.RawResults = GetRandomString("", 5);

            return vpScenarioIDAndRawResults;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPScenarioIDAndRawResults_Testing()
        {
            SetupTestHelper(culture);
            VPScenarioIDAndRawResultsService vpScenarioIDAndRawResultsService = new VPScenarioIDAndRawResultsService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
