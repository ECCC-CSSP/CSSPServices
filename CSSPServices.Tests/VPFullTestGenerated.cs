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
    public partial class VPFullTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private VPFullService vpFullService { get; set; }
        #endregion Properties

        #region Constructors
        public VPFullTest() : base()
        {
            vpFullService = new VPFullService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPFull GetFilledRandomVPFull(string OmitPropName)
        {
            VPFull vpFull = new VPFull();


            return vpFull;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void VPFull_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            VPFull vpFull = GetFilledRandomVPFull("");

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
