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
    public partial class ElementTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int ElementID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public ElementTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Element GetFilledRandomElement(string OmitPropName)
        {
            ElementID += 1;

            Element element = new Element();

            if (OmitPropName != "ID") element.ID = GetRandomInt(1, 11);
            if (OmitPropName != "Type") element.Type = GetRandomInt(1, 11);
            if (OmitPropName != "NumbOfNodes") element.NumbOfNodes = GetRandomInt(1, 11);
            if (OmitPropName != "Value") element.Value = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "XNode0") element.XNode0 = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "YNode0") element.YNode0 = GetRandomFloat(1.0f, 1000.0f);
            if (OmitPropName != "ZNode0") element.ZNode0 = GetRandomFloat(1.0f, 1000.0f);

            return element;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Element_Testing()
        {
            SetupTestHelper(culture);
            ElementService elementService = new ElementService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            Element element = GetFilledRandomElement("");

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
