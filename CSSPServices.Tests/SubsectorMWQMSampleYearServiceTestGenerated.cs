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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SubsectorMWQMSampleYear_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SubsectorMWQMSampleYearService subsectorMWQMSampleYearService = new SubsectorMWQMSampleYearService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

        #region Tests Generated for GetSubsectorMWQMSampleYearWithSubsectorMWQMSampleYearID(subsectorMWQMSampleYear.SubsectorMWQMSampleYearID)
        #endregion Tests Generated for GetSubsectorMWQMSampleYearWithSubsectorMWQMSampleYearID(subsectorMWQMSampleYear.SubsectorMWQMSampleYearID)

        #region Tests Generated for GetSubsectorMWQMSampleYearList()
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList()

        #region Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take

        #region Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take Order
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take Order

        #region Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take 2Order
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take 2Order

        #region Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take Order Where
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take Order Where

        #region Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take Order 2Where
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList() Skip Take Order 2Where

        #region Tests Generated for GetSubsectorMWQMSampleYearList() 2Where
        #endregion Tests Generated for GetSubsectorMWQMSampleYearList() 2Where

        #region Functions private
        private SubsectorMWQMSampleYear GetFilledRandomSubsectorMWQMSampleYear(string OmitPropName)
        {
            SubsectorMWQMSampleYear subsectorMWQMSampleYear = new SubsectorMWQMSampleYear();

            if (OmitPropName != "SubsectorTVItemID") subsectorMWQMSampleYear.SubsectorTVItemID = GetRandomInt(1, 11);
            // should implement a Range for the property Year and type SubsectorMWQMSampleYear
            if (OmitPropName != "EarliestDate") subsectorMWQMSampleYear.EarliestDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "LatestDate") subsectorMWQMSampleYear.LatestDate = new DateTime(2005, 3, 6);

            return subsectorMWQMSampleYear;
        }
        #endregion Functions private
    }
}
