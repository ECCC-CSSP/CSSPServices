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
    public partial class MWQMSampleDuplicateItemTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSampleDuplicateItemID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleDuplicateItemTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSampleDuplicateItem GetFilledRandomMWQMSampleDuplicateItem(string OmitPropName)
        {
            MWQMSampleDuplicateItemID += 1;

            MWQMSampleDuplicateItem mwqmSampleDuplicateItem = new MWQMSampleDuplicateItem();

            if (OmitPropName != "ParentSite") mwqmSampleDuplicateItem.ParentSite = GetRandomString("", 5);
            if (OmitPropName != "DuplicateSite") mwqmSampleDuplicateItem.DuplicateSite = GetRandomString("", 5);

            return mwqmSampleDuplicateItem;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSampleDuplicateItem_Testing()
        {
            SetupTestHelper(culture);
            MWQMSampleDuplicateItemService mwqmSampleDuplicateItemService = new MWQMSampleDuplicateItemService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            MWQMSampleDuplicateItem mwqmSampleDuplicateItem = GetFilledRandomMWQMSampleDuplicateItem("");

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
