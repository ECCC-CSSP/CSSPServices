 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
            //CSSPError: property [ElementList] and type [Node] is  not implemented
            //CSSPError: property [ConnectNodeList] and type [Node] is  not implemented

            return node;
        }
        #endregion Functions private
    }
}
