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
    public partial class OtherFilesToUploadTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int OtherFilesToUploadID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public OtherFilesToUploadTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private OtherFilesToUpload GetFilledRandomOtherFilesToUpload(string OmitPropName)
        {
            OtherFilesToUploadID += 1;

            OtherFilesToUpload otherFilesToUpload = new OtherFilesToUpload();

            if (OmitPropName != "Error") otherFilesToUpload.Error = GetRandomString("", 5);
            if (OmitPropName != "MikeScenarioID") otherFilesToUpload.MikeScenarioID = GetRandomInt(1, 11);

            return otherFilesToUpload;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void OtherFilesToUpload_Testing()
        {
            SetupTestHelper(culture);
            OtherFilesToUploadService otherFilesToUploadService = new OtherFilesToUploadService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
