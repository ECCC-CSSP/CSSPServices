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
    public partial class LastUpdateAndTVTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LastUpdateAndTVTextService lastUpdateAndTVTextService { get; set; }
        #endregion Properties

        #region Constructors
        public LastUpdateAndTVTextServiceTest() : base()
        {
            //lastUpdateAndTVTextService = new LastUpdateAndTVTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private LastUpdateAndTVText GetFilledRandomLastUpdateAndTVText(string OmitPropName)
        {
            LastUpdateAndTVText lastUpdateAndTVText = new LastUpdateAndTVText();

            if (OmitPropName != "LastUpdateAndTVTextDate_UTC") lastUpdateAndTVText.LastUpdateAndTVTextDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateDate_Local") lastUpdateAndTVText.LastUpdateDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TVText") lastUpdateAndTVText.TVText = GetRandomString("", 6);

            return lastUpdateAndTVText;
        }
        #endregion Functions private
    }
}
