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
    public partial class CSSPDateAfterYearTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int CSSPDateAfterYearID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDateAfterYearTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPDateAfterYear GetFilledRandomCSSPDateAfterYear(string OmitPropName)
        {
            CSSPDateAfterYearID += 1;

            CSSPDateAfterYear cSSPDateAfterYear = new CSSPDateAfterYear();

            if (OmitPropName != "Year") cSSPDateAfterYear.Year = GetRandomInt(1, 5);
            if (OmitPropName != "ErrorMessage") cSSPDateAfterYear.ErrorMessage = GetRandomString("", 5);
            if (OmitPropName != "ErrorMessageResourceName") cSSPDateAfterYear.ErrorMessageResourceName = GetRandomString("", 5);
            //Error: Type not implemented [ErrorMessageResourceType]

            return cSSPDateAfterYear;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CSSPDateAfterYear_Testing()
        {
            SetupTestHelper(culture);
            CSSPDateAfterYearService cSSPDateAfterYearService = new CSSPDateAfterYearService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            CSSPDateAfterYear cSSPDateAfterYear = GetFilledRandomCSSPDateAfterYear("");
            Assert.AreEqual(true, cSSPDateAfterYearService.Add(cSSPDateAfterYear));
            Assert.AreEqual(true, cSSPDateAfterYearService.GetRead().Where(c => c == cSSPDateAfterYear).Any());
            NeedToFindAValueToChangeForUpdateForClass_CSSPDateAfterYear;

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
