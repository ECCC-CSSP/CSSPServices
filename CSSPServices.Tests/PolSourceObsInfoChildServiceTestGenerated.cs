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
    public partial class PolSourceObsInfoChildServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObsInfoChildService polSourceObsInfoChildService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildServiceTest() : base()
        {
            //polSourceObsInfoChildService = new PolSourceObsInfoChildService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private PolSourceObsInfoChild GetFilledRandomPolSourceObsInfoChild(string OmitPropName)
        {
            PolSourceObsInfoChild polSourceObsInfoChild = new PolSourceObsInfoChild();

            if (OmitPropName != "PolSourceObsInfo") polSourceObsInfoChild.PolSourceObsInfo = (PolSourceObsInfoEnum)GetRandomEnumType(typeof(PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoChildStart") polSourceObsInfoChild.PolSourceObsInfoChildStart = (PolSourceObsInfoEnum)GetRandomEnumType(typeof(PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoText") polSourceObsInfoChild.PolSourceObsInfoText = GetRandomString("", 5);
            if (OmitPropName != "PolSourceObsInfoChildStartText") polSourceObsInfoChild.PolSourceObsInfoChildStartText = GetRandomString("", 5);

            return polSourceObsInfoChild;
        }
        #endregion Functions private
    }
}
