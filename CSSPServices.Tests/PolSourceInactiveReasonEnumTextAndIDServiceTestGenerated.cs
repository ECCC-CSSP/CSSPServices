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
    public partial class PolSourceInactiveReasonEnumTextAndIDServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceInactiveReasonEnumTextAndIDService polSourceInactiveReasonEnumTextAndIDService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndIDServiceTest() : base()
        {
            //polSourceInactiveReasonEnumTextAndIDService = new PolSourceInactiveReasonEnumTextAndIDService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private PolSourceInactiveReasonEnumTextAndID GetFilledRandomPolSourceInactiveReasonEnumTextAndID(string OmitPropName)
        {
            PolSourceInactiveReasonEnumTextAndID polSourceInactiveReasonEnumTextAndID = new PolSourceInactiveReasonEnumTextAndID();

            if (OmitPropName != "Text") polSourceInactiveReasonEnumTextAndID.Text = GetRandomString("", 20);
            if (OmitPropName != "ID") polSourceInactiveReasonEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceInactiveReasonEnumTextAndID;
        }
        #endregion Functions private
    }
}
