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
    public partial class VectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VectorService vectorService { get; set; }
        #endregion Properties

        #region Constructors
        public VectorServiceTest() : base()
        {
            //vectorService = new VectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private Vector GetFilledRandomVector(string OmitPropName)
        {
            Vector vector = new Vector();

            //Error: property [StartNode] and type [Vector] is  not implemented
            //Error: property [EndNode] and type [Vector] is  not implemented

            return vector;
        }
        #endregion Functions private
    }
}
