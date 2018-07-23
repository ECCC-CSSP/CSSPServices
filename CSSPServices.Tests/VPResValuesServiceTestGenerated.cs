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
    public partial class VPResValuesServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPResValuesService vpResValuesService { get; set; }
        #endregion Properties

        #region Constructors
        public VPResValuesServiceTest() : base()
        {
            //vpResValuesService = new VPResValuesService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPResValues GetFilledRandomVPResValues(string OmitPropName)
        {
            VPResValues vpResValues = new VPResValues();

            if (OmitPropName != "Conc") vpResValues.Conc = GetRandomInt(0, 10);
            // should implement a Range for the property Dilu and type VPResValues
            // should implement a Range for the property FarfieldWidth and type VPResValues
            // should implement a Range for the property Distance and type VPResValues
            // should implement a Range for the property TheTime and type VPResValues
            // should implement a Range for the property Decay and type VPResValues

            return vpResValues;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPResValues_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPResValuesService vpResValuesService = new VPResValuesService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    VPResValues vpResValues = GetFilledRandomVPResValues("");

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

        #region Tests Generated for GetVPResValuesWithVPResValuesID(vpResValues.VPResValuesID)
        #endregion Tests Generated for GetVPResValuesWithVPResValuesID(vpResValues.VPResValuesID)

        #region Tests Generated for GetVPResValuesList()
        #endregion Tests Generated for GetVPResValuesList()

        #region Tests Generated for GetVPResValuesList() Skip Take
        #endregion Tests Generated for GetVPResValuesList() Skip Take

    }
}
