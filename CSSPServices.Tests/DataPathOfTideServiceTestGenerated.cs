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
    public partial class DataPathOfTideServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private DataPathOfTideService dataPathOfTideService { get; set; }
        #endregion Properties

        #region Constructors
        public DataPathOfTideServiceTest() : base()
        {
            //dataPathOfTideService = new DataPathOfTideService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void DataPathOfTide_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    DataPathOfTideService dataPathOfTideService = new DataPathOfTideService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    DataPathOfTide dataPathOfTide = GetFilledRandomDataPathOfTide("");

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

        #region Tests Generated for GetDataPathOfTideWithDataPathOfTideID(dataPathOfTide.DataPathOfTideID)
        #endregion Tests Generated for GetDataPathOfTideWithDataPathOfTideID(dataPathOfTide.DataPathOfTideID)

        #region Tests Generated for GetDataPathOfTideList()
        #endregion Tests Generated for GetDataPathOfTideList()

        #region Tests Generated for GetDataPathOfTideList() Skip Take
        #endregion Tests Generated for GetDataPathOfTideList() Skip Take

        #region Tests Generated for GetDataPathOfTideList() Skip Take Order
        #endregion Tests Generated for GetDataPathOfTideList() Skip Take Order

        #region Tests Generated for GetDataPathOfTideList() Skip Take 2Order
        #endregion Tests Generated for GetDataPathOfTideList() Skip Take 2Order

        #region Tests Generated for GetDataPathOfTideList() Skip Take Order Where
        #endregion Tests Generated for GetDataPathOfTideList() Skip Take Order Where

        #region Tests Generated for GetDataPathOfTideList() Skip Take Order 2Where
        #endregion Tests Generated for GetDataPathOfTideList() Skip Take Order 2Where

        #region Tests Generated for GetDataPathOfTideList() 2Where
        #endregion Tests Generated for GetDataPathOfTideList() 2Where

        #region Functions private
        private DataPathOfTide GetFilledRandomDataPathOfTide(string OmitPropName)
        {
            DataPathOfTide dataPathOfTide = new DataPathOfTide();

            if (OmitPropName != "Text") dataPathOfTide.Text = GetRandomString("", 6);
            if (OmitPropName != "WebTideDataSet") dataPathOfTide.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "WebTideDataSetText") dataPathOfTide.WebTideDataSetText = GetRandomString("", 5);

            return dataPathOfTide;
        }
        #endregion Functions private
    }
}
