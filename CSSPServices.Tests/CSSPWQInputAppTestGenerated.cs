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
    public partial class CSSPWQInputAppTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int CSSPWQInputAppID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPWQInputAppTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPWQInputApp GetFilledRandomCSSPWQInputApp(string OmitPropName)
        {
            CSSPWQInputAppID += 1;

            CSSPWQInputApp cSSPWQInputApp = new CSSPWQInputApp();

            if (OmitPropName != "AccessCode") cSSPWQInputApp.AccessCode = GetRandomString("", 5);
            if (OmitPropName != "ActiveYear") cSSPWQInputApp.ActiveYear = GetRandomString("", 4);
            if (OmitPropName != "DailyDuplicatePrecisionCriteria") cSSPWQInputApp.DailyDuplicatePrecisionCriteria = GetRandomFloat(0, 100);
            if (OmitPropName != "IntertechDuplicatePrecisionCriteria") cSSPWQInputApp.IntertechDuplicatePrecisionCriteria = GetRandomFloat(0, 100);
            if (OmitPropName != "IncludeLaboratoryQAQC") cSSPWQInputApp.IncludeLaboratoryQAQC = true;
            if (OmitPropName != "ApprovalCode") cSSPWQInputApp.ApprovalCode = GetRandomString("", 5);
            if (OmitPropName != "ApprovalDate") cSSPWQInputApp.ApprovalDate = GetRandomDateTime();

            return cSSPWQInputApp;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CSSPWQInputApp_Testing()
        {
            SetupTestHelper(culture);
            CSSPWQInputAppService cSSPWQInputAppService = new CSSPWQInputAppService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            CSSPWQInputApp cSSPWQInputApp = GetFilledRandomCSSPWQInputApp("");

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
