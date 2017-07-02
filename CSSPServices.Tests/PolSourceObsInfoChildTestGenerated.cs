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
        private int PolSourceObsInfoChildID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObsInfoChildTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private PolSourceObsInfoChild GetFilledRandomPolSourceObsInfoChild(string OmitPropName)
        {
            PolSourceObsInfoChildID += 1;

            PolSourceObsInfoChild polSourceObsInfoChild = new PolSourceObsInfoChild();

            if (OmitPropName != "PolSourceObsInfo") polSourceObsInfoChild.PolSourceObsInfo = (CSSPEnums.PolSourceObsInfoEnum)GetRandomEnumType(typeof(CSSPEnums.PolSourceObsInfoEnum));
            if (OmitPropName != "PolSourceObsInfoChildStart") polSourceObsInfoChild.PolSourceObsInfoChildStart = (CSSPEnums.PolSourceObsInfoEnum)GetRandomEnumType(typeof(CSSPEnums.PolSourceObsInfoEnum));

            return polSourceObsInfoChild;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void PolSourceObsInfoChild_Testing()
        {
            SetupTestHelper(culture);
            PolSourceObsInfoChildService polSourceObsInfoChildService = new PolSourceObsInfoChildService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

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
