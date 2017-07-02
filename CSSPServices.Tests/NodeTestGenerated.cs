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
    public partial class NodeTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int NodeID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public NodeTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Node GetFilledRandomNode(string OmitPropName)
        {
            NodeID += 1;

            Node node = new Node();

            if (OmitPropName != "ID") node.ID = GetRandomInt(1, 1000000);
            if (OmitPropName != "X") node.X = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "Y") node.Y = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "Z") node.Z = GetRandomFloat(1.0f, 5.0f);
            if (OmitPropName != "Code") node.Code = GetRandomInt(1, 5);
            if (OmitPropName != "Value") node.Value = GetRandomFloat(1.0f, 5.0f);

            return node;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Node_Testing()
        {
            SetupTestHelper(culture);
            NodeService nodeService = new NodeService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
