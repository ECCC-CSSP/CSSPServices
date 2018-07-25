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
    public partial class MWQMSiteSampleFCServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSiteSampleFCService mwqmSiteSampleFCService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteSampleFCServiceTest() : base()
        {
            //mwqmSiteSampleFCService = new MWQMSiteSampleFCService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSiteSampleFC_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteSampleFCService mwqmSiteSampleFCService = new MWQMSiteSampleFCService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMSiteSampleFC mwqmSiteSampleFC = GetFilledRandomMWQMSiteSampleFC("");

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

        #region Tests Generated for GetMWQMSiteSampleFCWithMWQMSiteSampleFCID(mwqmSiteSampleFC.MWQMSiteSampleFCID)
        #endregion Tests Generated for GetMWQMSiteSampleFCWithMWQMSiteSampleFCID(mwqmSiteSampleFC.MWQMSiteSampleFCID)

        #region Tests Generated for GetMWQMSiteSampleFCList()
        #endregion Tests Generated for GetMWQMSiteSampleFCList()

        #region Tests Generated for GetMWQMSiteSampleFCList() Skip Take
        #endregion Tests Generated for GetMWQMSiteSampleFCList() Skip Take

        #region Tests Generated for GetMWQMSiteSampleFCList() Skip Take Order
        #endregion Tests Generated for GetMWQMSiteSampleFCList() Skip Take Order

        #region Tests Generated for GetMWQMSiteSampleFCList() Skip Take 2Order
        #endregion Tests Generated for GetMWQMSiteSampleFCList() Skip Take 2Order

        #region Tests Generated for GetMWQMSiteSampleFCList() Skip Take Order Where
        #endregion Tests Generated for GetMWQMSiteSampleFCList() Skip Take Order Where

        #region Tests Generated for GetMWQMSiteSampleFCList() Skip Take Order 2Where
        #endregion Tests Generated for GetMWQMSiteSampleFCList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMSiteSampleFCList() 2Where
        #endregion Tests Generated for GetMWQMSiteSampleFCList() 2Where

        #region Functions private
        private MWQMSiteSampleFC GetFilledRandomMWQMSiteSampleFC(string OmitPropName)
        {
            MWQMSiteSampleFC mwqmSiteSampleFC = new MWQMSiteSampleFC();

            if (OmitPropName != "Error") mwqmSiteSampleFC.Error = GetRandomString("", 20);
            if (OmitPropName != "SampleDate") mwqmSiteSampleFC.SampleDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "FC") mwqmSiteSampleFC.FC = GetRandomInt(1, 100000000);
            // should implement a Range for the property Sal and type MWQMSiteSampleFC
            // should implement a Range for the property Temp and type MWQMSiteSampleFC
            // should implement a Range for the property PH and type MWQMSiteSampleFC
            // should implement a Range for the property DO and type MWQMSiteSampleFC
            // should implement a Range for the property Depth and type MWQMSiteSampleFC
            // should implement a Range for the property SampCount and type MWQMSiteSampleFC
            // should implement a Range for the property MinFC and type MWQMSiteSampleFC
            // should implement a Range for the property MaxFC and type MWQMSiteSampleFC
            // should implement a Range for the property GeoMean and type MWQMSiteSampleFC
            // should implement a Range for the property Median and type MWQMSiteSampleFC
            // should implement a Range for the property P90 and type MWQMSiteSampleFC
            // should implement a Range for the property PercOver43 and type MWQMSiteSampleFC
            // should implement a Range for the property PercOver260 and type MWQMSiteSampleFC

            return mwqmSiteSampleFC;
        }
        #endregion Functions private
    }
}
