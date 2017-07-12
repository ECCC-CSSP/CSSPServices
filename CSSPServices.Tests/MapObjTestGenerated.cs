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
    public partial class MapObjTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MapObjID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MapObjTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapObj GetFilledRandomMapObj(string OmitPropName)
        {
            MapObjID += 1;

            MapObj mapObj = new MapObj();

            if (OmitPropName != "MapInfoID") mapObj.MapInfoID = GetRandomInt(1, 11);
            if (OmitPropName != "MapInfoDrawType") mapObj.MapInfoDrawType = (MapInfoDrawTypeEnum)GetRandomEnumType(typeof(MapInfoDrawTypeEnum));

            return mapObj;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MapObj_Testing()
        {
            SetupTestHelper(culture);
            MapObjService mapObjService = new MapObjService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            MapObj mapObj = GetFilledRandomMapObj("");

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
