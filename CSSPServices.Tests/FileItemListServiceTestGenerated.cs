 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
