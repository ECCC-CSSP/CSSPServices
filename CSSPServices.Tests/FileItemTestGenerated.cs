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
    public partial class FileItemTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int FileItemID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private FileItem GetFilledRandomFileItem(string OmitPropName)
        {
            FileItemID += 1;

            FileItem fileItem = new FileItem();

            if (OmitPropName != "Name") fileItem.Name = GetRandomString("", 5);
            if (OmitPropName != "TVItemID") fileItem.TVItemID = GetRandomInt(1, 11);

            return fileItem;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void FileItem_Testing()
        {
            SetupTestHelper(culture);
            FileItemService fileItemService = new FileItemService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            FileItem fileItem = GetFilledRandomFileItem("");

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
