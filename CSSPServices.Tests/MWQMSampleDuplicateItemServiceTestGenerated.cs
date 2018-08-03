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
    public partial class MWQMSampleDuplicateItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSampleDuplicateItemService mwqmSampleDuplicateItemService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleDuplicateItemServiceTest() : base()
        {
            //mwqmSampleDuplicateItemService = new MWQMSampleDuplicateItemService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private MWQMSampleDuplicateItem GetFilledRandomMWQMSampleDuplicateItem(string OmitPropName)
        {
            MWQMSampleDuplicateItem mwqmSampleDuplicateItem = new MWQMSampleDuplicateItem();

            if (OmitPropName != "ParentSite") mwqmSampleDuplicateItem.ParentSite = GetRandomString("", 6);
            if (OmitPropName != "DuplicateSite") mwqmSampleDuplicateItem.DuplicateSite = GetRandomString("", 6);

            return mwqmSampleDuplicateItem;
        }
        #endregion Functions private
    }
}
