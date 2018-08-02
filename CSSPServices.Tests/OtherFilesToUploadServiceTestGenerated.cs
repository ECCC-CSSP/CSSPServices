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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void OtherFilesToUpload_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    OtherFilesToUploadService otherFilesToUploadService = new OtherFilesToUploadService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetOtherFilesToUploadWithOtherFilesToUploadID(otherFilesToUpload.OtherFilesToUploadID)
        #endregion Tests Generated for GetOtherFilesToUploadWithOtherFilesToUploadID(otherFilesToUpload.OtherFilesToUploadID)

        #region Tests Generated for GetOtherFilesToUploadList()
        #endregion Tests Generated for GetOtherFilesToUploadList()

        #region Tests Generated for GetOtherFilesToUploadList() Skip Take
        #endregion Tests Generated for GetOtherFilesToUploadList() Skip Take

        #region Tests Generated for GetOtherFilesToUploadList() Skip Take Order
        #endregion Tests Generated for GetOtherFilesToUploadList() Skip Take Order

        #region Tests Generated for GetOtherFilesToUploadList() Skip Take 2Order
        #endregion Tests Generated for GetOtherFilesToUploadList() Skip Take 2Order

        #region Tests Generated for GetOtherFilesToUploadList() Skip Take Order Where
        #endregion Tests Generated for GetOtherFilesToUploadList() Skip Take Order Where

        #region Tests Generated for GetOtherFilesToUploadList() Skip Take Order 2Where
        #endregion Tests Generated for GetOtherFilesToUploadList() Skip Take Order 2Where

        #region Tests Generated for GetOtherFilesToUploadList() 2Where
        #endregion Tests Generated for GetOtherFilesToUploadList() 2Where

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
