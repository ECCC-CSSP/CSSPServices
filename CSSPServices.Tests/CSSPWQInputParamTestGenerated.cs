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
    public partial class CSSPWQInputParamTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int CSSPWQInputParamID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputParamTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPWQInputParam GetFilledRandomCSSPWQInputParam(string OmitPropName)
        {
            CSSPWQInputParamID += 1;

            CSSPWQInputParam cSSPWQInputParam = new CSSPWQInputParam();

            if (OmitPropName != "CSSPWQInputType") cSSPWQInputParam.CSSPWQInputType = (CSSPWQInputTypeEnum)GetRandomEnumType(typeof(CSSPWQInputTypeEnum));
            if (OmitPropName != "Name") cSSPWQInputParam.Name = GetRandomString("", 5);
            if (OmitPropName != "TVItemID") cSSPWQInputParam.TVItemID = GetRandomInt(1, 11);

            return cSSPWQInputParam;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CSSPWQInputParam_Testing()
        {
            SetupTestHelper(culture);
            CSSPWQInputParamService cSSPWQInputParamService = new CSSPWQInputParamService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            CSSPWQInputParam cSSPWQInputParam = GetFilledRandomCSSPWQInputParam("");

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
