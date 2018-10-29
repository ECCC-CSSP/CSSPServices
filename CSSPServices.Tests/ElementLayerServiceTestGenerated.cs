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
    public partial class ElementLayerServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ElementLayerService elementLayerService { get; set; }
        #endregion Properties

        #region Constructors
        public ElementLayerServiceTest() : base()
        {
            //elementLayerService = new ElementLayerService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private ElementLayer GetFilledRandomElementLayer(string OmitPropName)
        {
            ElementLayer elementLayer = new ElementLayer();

            if (OmitPropName != "Layer") elementLayer.Layer = GetRandomInt(1, 1000);
            // should implement a Range for the property ZMin and type ElementLayer
            // should implement a Range for the property ZMax and type ElementLayer
            //CSSPError: property [Element] and type [ElementLayer] is  not implemented

            return elementLayer;
        }
        #endregion Functions private
    }
}
