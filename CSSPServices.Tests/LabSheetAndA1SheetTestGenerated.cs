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
    public partial class LabSheetAndA1SheetTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private LabSheetAndA1SheetService labSheetAndA1SheetService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetAndA1SheetTest() : base()
        {
            labSheetAndA1SheetService = new LabSheetAndA1SheetService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetAndA1Sheet GetFilledRandomLabSheetAndA1Sheet(string OmitPropName)
        {
            LabSheetAndA1Sheet labSheetAndA1Sheet = new LabSheetAndA1Sheet();


            return labSheetAndA1Sheet;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetAndA1Sheet_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            LabSheetAndA1Sheet labSheetAndA1Sheet = GetFilledRandomLabSheetAndA1Sheet("");

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
