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
    public partial class CalDecayTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CalDecayService calDecayService { get; set; }
        #endregion Properties

        #region Constructors
        public CalDecayTest() : base()
        {
            calDecayService = new CalDecayService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private CalDecay GetFilledRandomCalDecay(string OmitPropName)
        {
            CalDecay calDecay = new CalDecay();

            if (OmitPropName != "Error") calDecay.Error = GetRandomString("", 5);
            if (OmitPropName != "Decay") calDecay.Decay = GetRandomDouble(0.0D, 10.0D);

            return calDecay;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void CalDecay_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            CalDecay calDecay = GetFilledRandomCalDecay("");

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
