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
    public partial class VectorTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VectorService vectorService { get; set; }
        #endregion Properties

        #region Constructors
        public VectorTest() : base()
        {
            vectorService = new VectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Vector GetFilledRandomVector(string OmitPropName)
        {
            Vector vector = new Vector();


            return vector;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Vector_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Vector vector = GetFilledRandomVector("");

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
