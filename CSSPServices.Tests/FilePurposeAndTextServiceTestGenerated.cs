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
    public partial class FilePurposeAndTextServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private FilePurposeAndTextService filePurposeAndTextService { get; set; }
        #endregion Properties

        #region Constructors
        public FilePurposeAndTextServiceTest() : base()
        {
            //filePurposeAndTextService = new FilePurposeAndTextService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private FilePurposeAndText GetFilledRandomFilePurposeAndText(string OmitPropName)
        {
            FilePurposeAndText filePurposeAndText = new FilePurposeAndText();

            if (OmitPropName != "FilePurpose") filePurposeAndText.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FilePurposeText") filePurposeAndText.FilePurposeText = GetRandomString("", 5);

            return filePurposeAndText;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void FilePurposeAndText_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    FilePurposeAndTextService filePurposeAndTextService = new FilePurposeAndTextService(new GetParam(), dbTestDB, ContactID);

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
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetFilePurposeAndTextWithFilePurposeAndTextID(filePurposeAndText.FilePurposeAndTextID)
        #endregion Tests Generated for GetFilePurposeAndTextWithFilePurposeAndTextID(filePurposeAndText.FilePurposeAndTextID)

        #region Tests Generated for GetFilePurposeAndTextList()
        #endregion Tests Generated for GetFilePurposeAndTextList()

        #region Tests Generated for GetFilePurposeAndTextList() Skip Take
        #endregion Tests Generated for GetFilePurposeAndTextList() Skip Take

    }
}
