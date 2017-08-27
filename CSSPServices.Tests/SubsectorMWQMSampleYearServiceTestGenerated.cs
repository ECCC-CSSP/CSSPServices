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
    public partial class SubsectorMWQMSampleYearServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SubsectorMWQMSampleYearService subsectorMWQMSampleYearService { get; set; }
        #endregion Properties

        #region Constructors
        public SubsectorMWQMSampleYearServiceTest() : base()
        {
            //subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SubsectorMWQMSampleYear GetFilledRandomSubsectorMWQMSampleYear(string OmitPropName)
        {
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();

            if (OmitPropName != "SubsectorTVItemID") subsectorMWQMSampleYear.SubsectorTVItemID = GetRandomInt(1, 11);
            // should implement a Range for the property Year and type SubsectorMWQMSampleYear
            if (OmitPropName != "EarliestDate") subsectorMWQMSampleYear.EarliestDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "LatestDate") subsectorMWQMSampleYear.LatestDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "HasErrors") subsectorMWQMSampleYear.HasErrors = true;

            return subsectorMWQMSampleYear;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SubsectorMWQMSampleYear_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SubsectorMWQMSampleYearService subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(LanguageRequest, dbTestDB, ContactID);

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
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}
