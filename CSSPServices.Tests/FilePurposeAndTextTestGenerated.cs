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
    public partial class FilePurposeAndTextTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int FilePurposeAndTextID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private FilePurposeAndText GetFilledRandomFilePurposeAndText(string OmitPropName)
        {
            FilePurposeAndTextID += 1;

            FilePurposeAndText filePurposeAndText = new FilePurposeAndText();

            if (OmitPropName != "FilePurpose") filePurposeAndText.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FilePurposeText") filePurposeAndText.FilePurposeText = GetRandomString("", 5);

            return filePurposeAndText;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void FilePurposeAndText_Testing()
        {
            SetupTestHelper(culture);
            FilePurposeAndTextService filePurposeAndTextService = new FilePurposeAndTextService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            FilePurposeAndText filePurposeAndText = GetFilledRandomFilePurposeAndText("");

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
