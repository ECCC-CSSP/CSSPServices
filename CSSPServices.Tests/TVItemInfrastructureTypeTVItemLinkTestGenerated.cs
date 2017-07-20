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
    public partial class TVItemInfrastructureTypeTVItemLinkTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemInfrastructureTypeTVItemLinkID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemInfrastructureTypeTVItemLink GetFilledRandomTVItemInfrastructureTypeTVItemLink(string OmitPropName)
        {
            TVItemInfrastructureTypeTVItemLinkID += 1;

            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = new TVItemInfrastructureTypeTVItemLink();

            if (OmitPropName != "InfrastructureType") tvItemInfrastructureTypeTVItemLink.InfrastructureType = (InfrastructureTypeEnum)GetRandomEnumType(typeof(InfrastructureTypeEnum));
            if (OmitPropName != "SeeOtherTVItemID") tvItemInfrastructureTypeTVItemLink.SeeOtherTVItemID = GetRandomInt(1, 1000);

            return tvItemInfrastructureTypeTVItemLink;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemInfrastructureTypeTVItemLink_Testing()
        {
            SetupTestHelper(culture);
            TVItemInfrastructureTypeTVItemLinkService tvItemInfrastructureTypeTVItemLinkService = new TVItemInfrastructureTypeTVItemLinkService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            TVItemInfrastructureTypeTVItemLink tvItemInfrastructureTypeTVItemLink = GetFilledRandomTVItemInfrastructureTypeTVItemLink("");

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
