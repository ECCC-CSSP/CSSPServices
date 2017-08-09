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
    public partial class RTBStringPosServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RTBStringPosService rTBStringPosService { get; set; }
        #endregion Properties

        #region Constructors
        public RTBStringPosServiceTest() : base()
        {
            //rTBStringPosService = new RTBStringPosService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private RTBStringPos GetFilledRandomRTBStringPos(string OmitPropName)
        {
            RTBStringPos rTBStringPos = new RTBStringPos();

            if (OmitPropName != "StartPos") rTBStringPos.StartPos = GetRandomInt(0, 10);
            if (OmitPropName != "EndPos") rTBStringPos.EndPos = GetRandomInt(0, 10);
            if (OmitPropName != "Text") rTBStringPos.Text = GetRandomString("", 20);
            if (OmitPropName != "TagText") rTBStringPos.TagText = GetRandomString("", 20);

            return rTBStringPos;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RTBStringPos_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                RTBStringPosService rTBStringPosService = new RTBStringPosService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                RTBStringPos rTBStringPos = GetFilledRandomRTBStringPos("");

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
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        #endregion Tests Get With Key

    }
}