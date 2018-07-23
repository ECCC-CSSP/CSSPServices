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
    public partial class VPFullServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPFullService vpFullService { get; set; }
        #endregion Properties

        #region Constructors
        public VPFullServiceTest() : base()
        {
            //vpFullService = new VPFullService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPFull GetFilledRandomVPFull(string OmitPropName)
        {
            VPFull vpFull = new VPFull();


            return vpFull;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPFull_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPFullService vpFullService = new VPFullService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    VPFull vpFull = GetFilledRandomVPFull("");

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

        #region Tests Generated for GetVPFullWithVPFullID(vpFull.VPFullID)
        #endregion Tests Generated for GetVPFullWithVPFullID(vpFull.VPFullID)

        #region Tests Generated for GetVPFullList()
        #endregion Tests Generated for GetVPFullList()

        #region Tests Generated for GetVPFullList() Skip Take
        #endregion Tests Generated for GetVPFullList() Skip Take

    }
}
