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
    public partial class VPScenarioIDAndRawResultsServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPScenarioIDAndRawResultsService vpScenarioIDAndRawResultsService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioIDAndRawResultsServiceTest() : base()
        {
            //vpScenarioIDAndRawResultsService = new VPScenarioIDAndRawResultsService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPScenarioIDAndRawResults GetFilledRandomVPScenarioIDAndRawResults(string OmitPropName)
        {
            VPScenarioIDAndRawResults vpScenarioIDAndRawResults = new VPScenarioIDAndRawResults();

            if (OmitPropName != "VPScenarioID") vpScenarioIDAndRawResults.VPScenarioID = GetRandomInt(1, 11);
            if (OmitPropName != "RawResults") vpScenarioIDAndRawResults.RawResults = GetRandomString("", 20);
            if (OmitPropName != "HasErrors") vpScenarioIDAndRawResults.HasErrors = true;

            return vpScenarioIDAndRawResults;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPScenarioIDAndRawResults_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                VPScenarioIDAndRawResultsService vpScenarioIDAndRawResultsService = new VPScenarioIDAndRawResultsService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                VPScenarioIDAndRawResults vpScenarioIDAndRawResults = GetFilledRandomVPScenarioIDAndRawResults("");

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
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}
