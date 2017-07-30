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
    public partial class OtherFilesToUploadTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private OtherFilesToUploadService otherFilesToUploadService { get; set; }
        #endregion Properties

        #region Constructors
        public OtherFilesToUploadTest() : base()
        {
            otherFilesToUploadService = new OtherFilesToUploadService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private OtherFilesToUpload GetFilledRandomOtherFilesToUpload(string OmitPropName)
        {
            OtherFilesToUpload otherFilesToUpload = new OtherFilesToUpload();

            if (OmitPropName != "Error") otherFilesToUpload.Error = GetRandomString("", 20);
            if (OmitPropName != "MikeScenarioID") otherFilesToUpload.MikeScenarioID = GetRandomInt(1, 11);

            return otherFilesToUpload;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void OtherFilesToUpload_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            OtherFilesToUpload otherFilesToUpload = GetFilledRandomOtherFilesToUpload("");

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
