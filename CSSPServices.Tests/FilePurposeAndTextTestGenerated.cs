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
    public partial class FilePurposeAndTextTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private FilePurposeAndTextService filePurposeAndTextService { get; set; }
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextTest() : base()
        {
            filePurposeAndTextService = new FilePurposeAndTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private FilePurposeAndText GetFilledRandomFilePurposeAndText(string OmitPropName)
        {
            FilePurposeAndText filePurposeAndText = new FilePurposeAndText();

            if (OmitPropName != "FilePurpose") filePurposeAndText.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FilePurposeText") filePurposeAndText.FilePurposeText = GetRandomString("", 6);

            return filePurposeAndText;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void FilePurposeAndText_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            FilePurposeAndText filePurposeAndText = GetFilledRandomFilePurposeAndText("");

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
