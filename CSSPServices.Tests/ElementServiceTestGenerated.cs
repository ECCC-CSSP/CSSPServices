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
            //CSSPError: property [NodeList] and type [Element] is  not implemented

            return element;
        }
        #endregion Functions private
    }
}
