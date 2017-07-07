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
    public partial class CSSPObjectExistAttributeTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int CSSPObjectExistAttributeID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPObjectExistAttributeTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CSSPObjectExistAttribute GetFilledRandomCSSPObjectExistAttribute(string OmitPropName)
        {
            CSSPObjectExistAttributeID += 1;

            CSSPObjectExistAttribute cSSPObjectExistAttribute = new CSSPObjectExistAttribute();

            if (OmitPropName != "TableName") cSSPObjectExistAttribute.TableName = GetRandomString("", 5);
            if (OmitPropName != "ErrorMessage") cSSPObjectExistAttribute.ErrorMessage = GetRandomString("", 5);
            if (OmitPropName != "ErrorMessageResourceName") cSSPObjectExistAttribute.ErrorMessageResourceName = GetRandomString("", 5);
            //Error: Type not implemented [ErrorMessageResourceType]

            return cSSPObjectExistAttribute;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CSSPObjectExistAttribute_Testing()
        {
            SetupTestHelper(culture);
            CSSPObjectExistAttributeService cSSPObjectExistAttributeService = new CSSPObjectExistAttributeService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            CSSPObjectExistAttribute cSSPObjectExistAttribute = GetFilledRandomCSSPObjectExistAttribute("");
            Assert.AreEqual(true, cSSPObjectExistAttributeService.Add(cSSPObjectExistAttribute));
            Assert.AreEqual(true, cSSPObjectExistAttributeService.GetRead().Where(c => c == cSSPObjectExistAttribute).Any());
            NeedToFindAValueToChangeForUpdateForClass_CSSPObjectExistAttribute;

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
