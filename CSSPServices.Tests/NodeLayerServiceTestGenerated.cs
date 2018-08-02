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
    public partial class NodeLayerServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private NodeLayerService nodeLayerService { get; set; }
        #endregion Properties

        #region Constructors
        public NodeLayerServiceTest() : base()
        {
            //nodeLayerService = new NodeLayerService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void NodeLayer_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    NodeLayerService nodeLayerService = new NodeLayerService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetNodeLayerWithNodeLayerID(nodeLayer.NodeLayerID)
        #endregion Tests Generated for GetNodeLayerWithNodeLayerID(nodeLayer.NodeLayerID)

        #region Tests Generated for GetNodeLayerList()
        #endregion Tests Generated for GetNodeLayerList()

        #region Tests Generated for GetNodeLayerList() Skip Take
        #endregion Tests Generated for GetNodeLayerList() Skip Take

        #region Tests Generated for GetNodeLayerList() Skip Take Order
        #endregion Tests Generated for GetNodeLayerList() Skip Take Order

        #region Tests Generated for GetNodeLayerList() Skip Take 2Order
        #endregion Tests Generated for GetNodeLayerList() Skip Take 2Order

        #region Tests Generated for GetNodeLayerList() Skip Take Order Where
        #endregion Tests Generated for GetNodeLayerList() Skip Take Order Where

        #region Tests Generated for GetNodeLayerList() Skip Take Order 2Where
        #endregion Tests Generated for GetNodeLayerList() Skip Take Order 2Where

        #region Tests Generated for GetNodeLayerList() 2Where
        #endregion Tests Generated for GetNodeLayerList() 2Where

        #region Functions private
        private NodeLayer GetFilledRandomNodeLayer(string OmitPropName)
        {
            NodeLayer nodeLayer = new NodeLayer();

            if (OmitPropName != "Layer") nodeLayer.Layer = GetRandomInt(1, 100);
            // should implement a Range for the property Z and type NodeLayer
            //Error: property [Node] and type [NodeLayer] is  not implemented

            return nodeLayer;
        }
        #endregion Functions private
    }
}
