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
    public partial class NodeLayerTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int NodeLayerID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public NodeLayerTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private NodeLayer GetFilledRandomNodeLayer(string OmitPropName)
        {
            NodeLayerID += 1;

            NodeLayer nodeLayer = new NodeLayer();

            if (OmitPropName != "Layer") nodeLayer.Layer = GetRandomInt(1, 100);
            if (OmitPropName != "Z") nodeLayer.Z = GetRandomFloat(1.0f, 1000.0f);

            return nodeLayer;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void NodeLayer_Testing()
        {
            SetupTestHelper(culture);
            NodeLayerService nodeLayerService = new NodeLayerService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            NodeLayer nodeLayer = GetFilledRandomNodeLayer("");

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
