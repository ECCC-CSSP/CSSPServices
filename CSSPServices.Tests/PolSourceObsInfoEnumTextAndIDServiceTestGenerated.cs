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
    public partial class PolSourceObsInfoEnumTextAndIDServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObsInfoEnumTextAndIDService polSourceObsInfoEnumTextAndIDService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoEnumTextAndIDServiceTest() : base()
        {
            //polSourceObsInfoEnumTextAndIDService = new PolSourceObsInfoEnumTextAndIDService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private PolSourceObsInfoEnumTextAndID GetFilledRandomPolSourceObsInfoEnumTextAndID(string OmitPropName)
        {
            PolSourceObsInfoEnumTextAndID polSourceObsInfoEnumTextAndID = new PolSourceObsInfoEnumTextAndID();

            if (OmitPropName != "Text") polSourceObsInfoEnumTextAndID.Text = GetRandomString("", 20);
            if (OmitPropName != "ID") polSourceObsInfoEnumTextAndID.ID = GetRandomInt(1, 11);

            return polSourceObsInfoEnumTextAndID;
        }
        #endregion Functions private
    }
}
