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
    public partial class TVItemSubsectorAndMWQMSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemSubsectorAndMWQMSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemSubsectorAndMWQMSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemSubsectorAndMWQMSite GetFilledRandomTVItemSubsectorAndMWQMSite(string OmitPropName)
        {
            TVItemSubsectorAndMWQMSiteID += 1;

            TVItemSubsectorAndMWQMSite tvItemSubsectorAndMWQMSite = new TVItemSubsectorAndMWQMSite();


            return tvItemSubsectorAndMWQMSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemSubsectorAndMWQMSite_Testing()
        {
            SetupTestHelper(culture);
            TVItemSubsectorAndMWQMSiteService tvItemSubsectorAndMWQMSiteService = new TVItemSubsectorAndMWQMSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
