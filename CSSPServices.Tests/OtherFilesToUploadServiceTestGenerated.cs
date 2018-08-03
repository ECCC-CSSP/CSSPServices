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
    public partial class OtherFilesToUploadServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private OtherFilesToUploadService otherFilesToUploadService { get; set; }
        #endregion Properties

        #region Constructors
        public OtherFilesToUploadServiceTest() : base()
        {
            //otherFilesToUploadService = new OtherFilesToUploadService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private OtherFilesToUpload GetFilledRandomOtherFilesToUpload(string OmitPropName)
        {
            OtherFilesToUpload otherFilesToUpload = new OtherFilesToUpload();

            if (OmitPropName != "Error") otherFilesToUpload.Error = GetRandomString("", 20);
            if (OmitPropName != "MikeScenarioID") otherFilesToUpload.MikeScenarioID = GetRandomInt(1, 11);
            //Error: property [TVFileList] and type [OtherFilesToUpload] is  not implemented

            return otherFilesToUpload;
        }
        #endregion Functions private
    }
}
