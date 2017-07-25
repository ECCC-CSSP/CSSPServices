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
        private MapObjService mapObjService { get; set; }
        #endregion Properties

        #region Constructors
        public MapObjTest() : base()
        {
            mapObjService = new MapObjService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapObj GetFilledRandomMapObj(string OmitPropName)
        {
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

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

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
