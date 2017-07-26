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
    public partial class PolSourceObsInfoChildTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private PolSourceObsInfoChildService polSourceObsInfoChildService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildTest() : base()
        {
            polSourceObsInfoChildService = new PolSourceObsInfoChildService(LanguageRequest, dbTestDB, ContactID);
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

            return polSourceObsInfoChild;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObsInfoChild_Testing()
        {

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
        #endregion Tests Generated
    }
}
