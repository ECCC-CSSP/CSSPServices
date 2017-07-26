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
    public partial class ElementLayerTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ElementLayerService elementLayerService { get; set; }
        #endregion Properties

        #region Constructors
        public ElementLayerTest() : base()
        {
            elementLayerService = new ElementLayerService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ElementLayer GetFilledRandomElementLayer(string OmitPropName)
        {
            ElementLayer elementLayer = new ElementLayer();

            if (OmitPropName != "Layer") elementLayer.Layer = GetRandomInt(1, 1000);
            // should implement a Range for the property ZMin and type ElementLayer
            // should implement a Range for the property ZMax and type ElementLayer

            return elementLayer;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void ElementLayer_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            ElementLayer elementLayer = GetFilledRandomElementLayer("");

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
        #endregion Tests Generated
    }
}
