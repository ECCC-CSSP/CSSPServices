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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Element_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ElementService elementService = new ElementService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetElementWithElementID(element.ElementID)
        #endregion Tests Generated for GetElementWithElementID(element.ElementID)

        #region Tests Generated for GetElementList()
        #endregion Tests Generated for GetElementList()

        #region Tests Generated for GetElementList() Skip Take
        #endregion Tests Generated for GetElementList() Skip Take

        #region Tests Generated for GetElementList() Skip Take Order
        #endregion Tests Generated for GetElementList() Skip Take Order

        #region Tests Generated for GetElementList() Skip Take 2Order
        #endregion Tests Generated for GetElementList() Skip Take 2Order

        #region Tests Generated for GetElementList() Skip Take Order Where
        #endregion Tests Generated for GetElementList() Skip Take Order Where

        #region Tests Generated for GetElementList() Skip Take Order 2Where
        #endregion Tests Generated for GetElementList() Skip Take Order 2Where

        #region Tests Generated for GetElementList() 2Where
        #endregion Tests Generated for GetElementList() 2Where

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
            //Error: property [NodeList] and type [Element] is  not implemented

            return element;
        }
        #endregion Functions private
    }
}
