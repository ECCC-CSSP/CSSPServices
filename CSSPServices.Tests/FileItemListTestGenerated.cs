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
    public partial class FileItemListTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int FileItemListID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemListTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private FileItemList GetFilledRandomFileItemList(string OmitPropName)
        {
            FileItemListID += 1;

            FileItemList fileItemList = new FileItemList();

            if (OmitPropName != "Text") fileItemList.Text = GetRandomString("", 5);
            if (OmitPropName != "FileName") fileItemList.FileName = GetRandomString("", 5);

            return fileItemList;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void FileItemList_Testing()
        {
            SetupTestHelper(culture);
            FileItemListService fileItemListService = new FileItemListService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            FileItemList fileItemList = GetFilledRandomFileItemList("");

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
