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
        private ElementService elementService { get; set; }
        #endregion Properties

        #region Constructors
        public ElementTest() : base()
        {
            elementService = new ElementService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "Value") element.Value = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "XNode0") element.XNode0 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "YNode0") element.YNode0 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "ZNode0") element.ZNode0 = GetRandomDouble(1.0D, 1000.0D);

            return element;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Element_Testing()
        {

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
