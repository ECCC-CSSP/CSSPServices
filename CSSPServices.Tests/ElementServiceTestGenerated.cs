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
    public partial class ElementServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ElementService elementService { get; set; }
        #endregion Properties

        #region Constructors
        public ElementServiceTest() : base()
        {
            //elementService = new ElementService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Element GetFilledRandomElement(string OmitPropName)
        {
            Element element = new Element();

            if (OmitPropName != "ID") element.ID = GetRandomInt(1, 11);
            if (OmitPropName != "Type") element.Type = GetRandomInt(1, 11);
            if (OmitPropName != "NumbOfNodes") element.NumbOfNodes = GetRandomInt(1, 11);
            // should implement a Range for the property Value and type Element
            // should implement a Range for the property XNode0 and type Element
            // should implement a Range for the property YNode0 and type Element
            // should implement a Range for the property ZNode0 and type Element

            return element;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Element_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                ElementService elementService = new ElementService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                Element element = GetFilledRandomElement("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}