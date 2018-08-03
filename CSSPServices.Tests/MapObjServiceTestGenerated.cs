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
    public partial class MapObjServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MapObjService mapObjService { get; set; }
        #endregion Properties

        #region Constructors
        public MapObjServiceTest() : base()
        {
            //mapObjService = new MapObjService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private MapObj GetFilledRandomMapObj(string OmitPropName)
        {
            MapObj mapObj = new MapObj();

            if (OmitPropName != "MapInfoID") mapObj.MapInfoID = GetRandomInt(1, 11);
            if (OmitPropName != "MapInfoDrawType") mapObj.MapInfoDrawType = (MapInfoDrawTypeEnum)GetRandomEnumType(typeof(MapInfoDrawTypeEnum));
            if (OmitPropName != "MapInfoDrawTypeText") mapObj.MapInfoDrawTypeText = GetRandomString("", 5);
            //Error: property [CoordList] and type [MapObj] is  not implemented

            return mapObj;
        }
        #endregion Functions private
    }
}
