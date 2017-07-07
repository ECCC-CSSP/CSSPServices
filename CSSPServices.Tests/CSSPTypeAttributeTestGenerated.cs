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
    public partial class CSSPTypeAttributeTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int CSSPTypeAttributeID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPTypeAttributeTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPTypeAttribute GetFilledRandomCSSPTypeAttribute(string OmitPropName)
        {
            CSSPTypeAttributeID += 1;

            CSSPTypeAttribute cSSPTypeAttribute = new CSSPTypeAttribute();

            if (OmitPropName != "ErrorMessage") cSSPTypeAttribute.ErrorMessage = GetRandomString("", 5);
            if (OmitPropName != "ErrorMessageResourceName") cSSPTypeAttribute.ErrorMessageResourceName = GetRandomString("", 5);
            //Error: Type not implemented [ErrorMessageResourceType]

            return cSSPTypeAttribute;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CSSPTypeAttribute_Testing()
        {
            SetupTestHelper(culture);
            CSSPTypeAttributeService cSSPTypeAttributeService = new CSSPTypeAttributeService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            CSSPTypeAttribute cSSPTypeAttribute = GetFilledRandomCSSPTypeAttribute("");
            Assert.AreEqual(true, cSSPTypeAttributeService.Add(cSSPTypeAttribute));
            Assert.AreEqual(true, cSSPTypeAttributeService.GetRead().Where(c => c == cSSPTypeAttribute).Any());
            NeedToFindAValueToChangeForUpdateForClass_CSSPTypeAttribute;

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
