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
    public partial class PolSourceObsInfoChildServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObsInfoChildService polSourceObsInfoChildService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildServiceTest() : base()
        {
            //polSourceObsInfoChildService = new PolSourceObsInfoChildService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObsInfoChild GetFilledRandomPolSourceObsInfoChild(string OmitPropName)
        {
            PolSourceObsInfoChild polSourceObsInfoChild = new PolSourceObsInfoChild();

            if (OmitPropName != "PolSourceObsInfo") polSourceObsInfoChild.PolSourceObsInfo = (PolSourceObsInfoEnum)GetRandomEnumType(typeof(PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoChildStart") polSourceObsInfoChild.PolSourceObsInfoChildStart = (PolSourceObsInfoEnum)GetRandomEnumType(typeof(PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoText") polSourceObsInfoChild.PolSourceObsInfoText = GetRandomString("", 5);
            if (OmitPropName != "PolSourceObsInfoChildStartText") polSourceObsInfoChild.PolSourceObsInfoChildStartText = GetRandomString("", 5);

            return polSourceObsInfoChild;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceObsInfoChild_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObsInfoChildService polSourceObsInfoChildService = new PolSourceObsInfoChildService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObsInfoChild polSourceObsInfoChild = GetFilledRandomPolSourceObsInfoChild("");

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

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

        #region Tests Generated Get List of PolSourceObsInfoChild
        #endregion Tests Get List of PolSourceObsInfoChild

    }
}
