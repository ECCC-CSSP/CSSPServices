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
    public partial class NodeServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private NodeService nodeService { get; set; }
        #endregion Properties

        #region Constructors
        public NodeServiceTest() : base()
        {
            //nodeService = new NodeService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Node_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    NodeService nodeService = new NodeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Node node = GetFilledRandomNode("");

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

        #region Tests Generated for GetNodeWithNodeID(node.NodeID)
        #endregion Tests Generated for GetNodeWithNodeID(node.NodeID)

        #region Tests Generated for GetNodeList()
        #endregion Tests Generated for GetNodeList()

        #region Tests Generated for GetNodeList() Skip Take
        #endregion Tests Generated for GetNodeList() Skip Take

        #region Tests Generated for GetNodeList() Skip Take Order
        #endregion Tests Generated for GetNodeList() Skip Take Order

        #region Tests Generated for GetNodeList() Skip Take 2Order
        #endregion Tests Generated for GetNodeList() Skip Take 2Order

        #region Tests Generated for GetNodeList() Skip Take Order Where
        #endregion Tests Generated for GetNodeList() Skip Take Order Where

        #region Tests Generated for GetNodeList() Skip Take Order 2Where
        #endregion Tests Generated for GetNodeList() Skip Take Order 2Where

        #region Tests Generated for GetNodeList() 2Where
        #endregion Tests Generated for GetNodeList() 2Where

        #region Functions private
        private Node GetFilledRandomNode(string OmitPropName)
        {
            Node node = new Node();

            if (OmitPropName != "ID") node.ID = GetRandomInt(1, 1000000);
            // should implement a Range for the property X and type Node
            // should implement a Range for the property Y and type Node
            // should implement a Range for the property Z and type Node
            // should implement a Range for the property Code and type Node
            // should implement a Range for the property Value and type Node
            //Error: property [ElementList] and type [Node] is  not implemented
            //Error: property [ConnectNodeList] and type [Node] is  not implemented

            return node;
        }
        #endregion Functions private
    }
}
