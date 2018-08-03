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
    public partial class TVTextLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVTextLanguageService tvTextLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTextLanguageServiceTest() : base()
        {
            //tvTextLanguageService = new TVTextLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private TVTextLanguage GetFilledRandomTVTextLanguage(string OmitPropName)
        {
            TVTextLanguage tvTextLanguage = new TVTextLanguage();

            if (OmitPropName != "TVText") tvTextLanguage.TVText = GetRandomString("", 20);
            if (OmitPropName != "Language") tvTextLanguage.Language = LanguageRequest;
            if (OmitPropName != "LanguageText") tvTextLanguage.LanguageText = GetRandomString("", 5);

            return tvTextLanguage;
        }
        #endregion Functions private
    }
}
