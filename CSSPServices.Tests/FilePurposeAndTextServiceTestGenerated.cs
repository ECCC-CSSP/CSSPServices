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

        #region Functions private
        private FilePurposeAndText GetFilledRandomFilePurposeAndText(string OmitPropName)
        {
            FilePurposeAndText filePurposeAndText = new FilePurposeAndText();

            if (OmitPropName != "FilePurpose") filePurposeAndText.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FilePurposeText") filePurposeAndText.FilePurposeText = GetRandomString("", 5);

            return filePurposeAndText;
        }
        #endregion Functions private
    }
}
