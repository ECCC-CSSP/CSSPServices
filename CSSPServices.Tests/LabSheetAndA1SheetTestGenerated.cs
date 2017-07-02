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
        private int LabSheetAndA1SheetID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetAndA1SheetTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private LabSheetAndA1Sheet GetFilledRandomLabSheetAndA1Sheet(string OmitPropName)
        {
            LabSheetAndA1SheetID += 1;

            LabSheetAndA1Sheet labSheetAndA1Sheet = new LabSheetAndA1Sheet();


            return labSheetAndA1Sheet;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void LabSheetAndA1Sheet_Testing()
        {
            SetupTestHelper(culture);
            LabSheetAndA1SheetService labSheetAndA1SheetService = new LabSheetAndA1SheetService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
