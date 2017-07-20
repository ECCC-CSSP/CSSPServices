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
    public partial class TVTypeNamesAndPathTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVTypeNamesAndPathID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVTypeNamesAndPath GetFilledRandomTVTypeNamesAndPath(string OmitPropName)
        {
            TVTypeNamesAndPathID += 1;

            TVTypeNamesAndPath tvTypeNamesAndPath = new TVTypeNamesAndPath();

            if (OmitPropName != "TVTypeName") tvTypeNamesAndPath.TVTypeName = GetRandomString("", 5);
            if (OmitPropName != "Index") tvTypeNamesAndPath.Index = GetRandomInt(1, 11);
            if (OmitPropName != "TVPath") tvTypeNamesAndPath.TVPath = GetRandomString("", 5);

            return tvTypeNamesAndPath;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVTypeNamesAndPath_Testing()
        {
            SetupTestHelper(culture);
            TVTypeNamesAndPathService tvTypeNamesAndPathService = new TVTypeNamesAndPathService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            TVTypeNamesAndPath tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");

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
