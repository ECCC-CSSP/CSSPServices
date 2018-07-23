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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MapObj GetFilledRandomMapObj(string OmitPropName)
        {
            MapObj mapObj = new MapObj();

            if (OmitPropName != "MapInfoID") mapObj.MapInfoID = GetRandomInt(1, 11);
            if (OmitPropName != "MapInfoDrawType") mapObj.MapInfoDrawType = (MapInfoDrawTypeEnum)GetRandomEnumType(typeof(MapInfoDrawTypeEnum));
            if (OmitPropName != "MapInfoDrawTypeText") mapObj.MapInfoDrawTypeText = GetRandomString("", 5);

            return mapObj;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MapObj_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MapObjService mapObjService = new MapObjService(new GetParam(), dbTestDB, ContactID);

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
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMapObjWithMapObjID(mapObj.MapObjID)
        #endregion Tests Generated for GetMapObjWithMapObjID(mapObj.MapObjID)

        #region Tests Generated for GetMapObjList()
        #endregion Tests Generated for GetMapObjList()

        #region Tests Generated for GetMapObjList() Skip Take
        #endregion Tests Generated for GetMapObjList() Skip Take

    }
}
