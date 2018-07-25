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
    public partial class CalDecayServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private CalDecayService calDecayService { get; set; }
        #endregion Properties

        #region Constructors
        public CalDecayServiceTest() : base()
        {
            //calDecayService = new CalDecayService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void CalDecay_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    CalDecayService calDecayService = new CalDecayService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    CalDecay calDecay = GetFilledRandomCalDecay("");

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

        #region Tests Generated for GetCalDecayWithCalDecayID(calDecay.CalDecayID)
        #endregion Tests Generated for GetCalDecayWithCalDecayID(calDecay.CalDecayID)

        #region Tests Generated for GetCalDecayList()
        #endregion Tests Generated for GetCalDecayList()

        #region Tests Generated for GetCalDecayList() Skip Take
        #endregion Tests Generated for GetCalDecayList() Skip Take

        #region Tests Generated for GetCalDecayList() Skip Take Order
        #endregion Tests Generated for GetCalDecayList() Skip Take Order

        #region Tests Generated for GetCalDecayList() Skip Take 2Order
        #endregion Tests Generated for GetCalDecayList() Skip Take 2Order

        #region Tests Generated for GetCalDecayList() Skip Take Order Where
        #endregion Tests Generated for GetCalDecayList() Skip Take Order Where

        #region Tests Generated for GetCalDecayList() Skip Take Order 2Where
        #endregion Tests Generated for GetCalDecayList() Skip Take Order 2Where

        #region Tests Generated for GetCalDecayList() 2Where
        #endregion Tests Generated for GetCalDecayList() 2Where

        #region Functions private
        private CalDecay GetFilledRandomCalDecay(string OmitPropName)
        {
            CalDecay calDecay = new CalDecay();

            if (OmitPropName != "Error") calDecay.Error = GetRandomString("", 5);
            if (OmitPropName != "Decay") calDecay.Decay = GetRandomDouble(0.0D, 10.0D);

            return calDecay;
        }
        #endregion Functions private
    }
}
