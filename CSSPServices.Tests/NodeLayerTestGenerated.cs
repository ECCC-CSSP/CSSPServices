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
        private NodeLayerService nodeLayerService { get; set; }
        #endregion Properties

        #region Constructors
        public NodeLayerTest() : base()
        {
            nodeLayerService = new NodeLayerService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private NodeLayer GetFilledRandomNodeLayer(string OmitPropName)
        {
            NodeLayer nodeLayer = new NodeLayer();

            if (OmitPropName != "Layer") nodeLayer.Layer = GetRandomInt(1, 100);
            // should implement a Range for the property Z and type NodeLayer

            return nodeLayer;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void NodeLayer_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            NodeLayer nodeLayer = GetFilledRandomNodeLayer("");

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
