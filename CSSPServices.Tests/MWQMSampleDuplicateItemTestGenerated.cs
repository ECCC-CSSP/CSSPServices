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
        private MWQMSampleDuplicateItemService mwqmSampleDuplicateItemService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleDuplicateItemTest() : base()
        {
            mwqmSampleDuplicateItemService = new MWQMSampleDuplicateItemService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSampleDuplicateItem GetFilledRandomMWQMSampleDuplicateItem(string OmitPropName)
        {
            MWQMSampleDuplicateItem mwqmSampleDuplicateItem = new MWQMSampleDuplicateItem();

            if (OmitPropName != "ParentSite") mwqmSampleDuplicateItem.ParentSite = GetRandomString("", 6);
            if (OmitPropName != "DuplicateSite") mwqmSampleDuplicateItem.DuplicateSite = GetRandomString("", 6);

            return mwqmSampleDuplicateItem;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSampleDuplicateItem_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

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
