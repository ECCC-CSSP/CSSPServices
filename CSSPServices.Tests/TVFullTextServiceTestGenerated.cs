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
    public partial class TVFullTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVFullTextService tvFullTextService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFullTextServiceTest() : base()
        {
            //tvFullTextService = new TVFullTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private TVFullText GetFilledRandomTVFullText(string OmitPropName)
        {
            TVFullText tvFullText = new TVFullText();

            if (OmitPropName != "TVPath") tvFullText.TVPath = GetRandomString("", 6);
            if (OmitPropName != "FullText") tvFullText.FullText = GetRandomString("", 6);

            return tvFullText;
        }
        #endregion Functions private
    }
}
