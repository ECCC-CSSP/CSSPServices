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
    public partial class FileItemListServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private FileItemListService fileItemListService { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemListServiceTest() : base()
        {
            //fileItemListService = new FileItemListService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void FileItemList_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    FileItemListService fileItemListService = new FileItemListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    FileItemList fileItemList = GetFilledRandomFileItemList("");

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

        #region Tests Generated for GetFileItemListWithFileItemListID(fileItemList.FileItemListID)
        #endregion Tests Generated for GetFileItemListWithFileItemListID(fileItemList.FileItemListID)

        #region Tests Generated for GetFileItemListList()
        #endregion Tests Generated for GetFileItemListList()

        #region Tests Generated for GetFileItemListList() Skip Take
        #endregion Tests Generated for GetFileItemListList() Skip Take

        #region Tests Generated for GetFileItemListList() Skip Take Order
        #endregion Tests Generated for GetFileItemListList() Skip Take Order

        #region Tests Generated for GetFileItemListList() Skip Take 2Order
        #endregion Tests Generated for GetFileItemListList() Skip Take 2Order

        #region Tests Generated for GetFileItemListList() Skip Take Order Where
        #endregion Tests Generated for GetFileItemListList() Skip Take Order Where

        #region Tests Generated for GetFileItemListList() Skip Take Order 2Where
        #endregion Tests Generated for GetFileItemListList() Skip Take Order 2Where

        #region Tests Generated for GetFileItemListList() 2Where
        #endregion Tests Generated for GetFileItemListList() 2Where

        #region Functions private
        private FileItemList GetFilledRandomFileItemList(string OmitPropName)
        {
            FileItemList fileItemList = new FileItemList();

            if (OmitPropName != "Text") fileItemList.Text = GetRandomString("", 6);
            if (OmitPropName != "FileName") fileItemList.FileName = GetRandomString("", 6);

            return fileItemList;
        }
        #endregion Functions private
    }
}
