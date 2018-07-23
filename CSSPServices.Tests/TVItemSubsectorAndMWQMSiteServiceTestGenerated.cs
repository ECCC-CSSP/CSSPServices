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
    public partial class TVItemSubsectorAndMWQMSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemSubsectorAndMWQMSiteService tvItemSubsectorAndMWQMSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemSubsectorAndMWQMSiteServiceTest() : base()
        {
            //tvItemSubsectorAndMWQMSiteService = new TVItemSubsectorAndMWQMSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemSubsectorAndMWQMSite GetFilledRandomTVItemSubsectorAndMWQMSite(string OmitPropName)
        {
            TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite = new TVItemSubsectorAndMWQMSite();


            return tvItemSubsectorAndMWQMSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemSubsectorAndMWQMSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemSubsectorAndMWQMSiteService tvItemSubsectorAndMWQMSiteService = new TVItemSubsectorAndMWQMSiteService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite = GetFilledRandomTVItemSubsectorAndMWQMSite("");

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

        #region Tests Generated for GetTVItemSubsectorAndMWQMSiteWithTVItemSubsectorAndMWQMSiteID(tvItemSubsectorAndMWQMSite.TVItemSubsectorAndMWQMSiteID)
        #endregion Tests Generated for GetTVItemSubsectorAndMWQMSiteWithTVItemSubsectorAndMWQMSiteID(tvItemSubsectorAndMWQMSite.TVItemSubsectorAndMWQMSiteID)

        #region Tests Generated for GetTVItemSubsectorAndMWQMSiteList()
        #endregion Tests Generated for GetTVItemSubsectorAndMWQMSiteList()

        #region Tests Generated for GetTVItemSubsectorAndMWQMSiteList() Skip Take
        #endregion Tests Generated for GetTVItemSubsectorAndMWQMSiteList() Skip Take

    }
}
