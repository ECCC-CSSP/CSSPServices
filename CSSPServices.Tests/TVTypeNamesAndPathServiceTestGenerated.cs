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
    public partial class TVTypeNamesAndPathServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVTypeNamesAndPathService tvTypeNamesAndPathService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathServiceTest() : base()
        {
            //tvTypeNamesAndPathService = new TVTypeNamesAndPathService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private TVTypeNamesAndPath GetFilledRandomTVTypeNamesAndPath(string OmitPropName)
        {
            TVTypeNamesAndPath tvTypeNamesAndPath = new TVTypeNamesAndPath();

            if (OmitPropName != "TVTypeName") tvTypeNamesAndPath.TVTypeName = GetRandomString("", 6);
            if (OmitPropName != "Index") tvTypeNamesAndPath.Index = GetRandomInt(1, 11);
            if (OmitPropName != "TVPath") tvTypeNamesAndPath.TVPath = GetRandomString("", 6);

            return tvTypeNamesAndPath;
        }
        #endregion Functions private
    }
}
