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
    public partial class FileItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private FileItemService fileItemService { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemServiceTest() : base()
        {
            //fileItemService = new FileItemService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private FileItem GetFilledRandomFileItem(string OmitPropName)
        {
            FileItem fileItem = new FileItem();

            if (OmitPropName != "Name") fileItem.Name = GetRandomString("", 5);
            if (OmitPropName != "TVItemID") fileItem.TVItemID = GetRandomInt(1, 11);

            return fileItem;
        }
        #endregion Functions private
    }
}
