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
    public partial class BoxModelResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private BoxModelResultService boxModelResultService { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultServiceTest() : base()
        {
            //boxModelResultService = new BoxModelResultService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private BoxModelResult GetFilledRandomBoxModelResult(string OmitPropName)
        {
            BoxModelResult boxModelResult = new BoxModelResult();

            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = 0;
            if (OmitPropName != "BoxModelResultType") boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModelResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelResult.LastUpdateContactTVItemID = 2;

            return boxModelResult;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void BoxModelResult_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelResultService boxModelResultService = new BoxModelResultService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    BoxModelResult boxModelResult = GetFilledRandomBoxModelResult("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = boxModelResultService.GetRead().Count();

                    Assert.AreEqual(boxModelResultService.GetRead().Count(), boxModelResultService.GetEdit().Count());

                    boxModelResultService.Add(boxModelResult);
                    if (boxModelResult.HasErrors)
                    {
                        Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, boxModelResultService.GetRead().Where(c => c == boxModelResult).Any());
                    boxModelResultService.Update(boxModelResult);
                    if (boxModelResult.HasErrors)
                    {
                        Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, boxModelResultService.GetRead().Count());
                    boxModelResultService.Delete(boxModelResult);
                    if (boxModelResult.HasErrors)
                    {
                        Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // boxModelResult.BoxModelResultID   (Int32)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultID = 0;
                    boxModelResultService.Update(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelResultBoxModelResultID), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultID = 10000000;
                    boxModelResultService.Update(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.BoxModelResult, CSSPModelsRes.BoxModelResultBoxModelResultID, boxModelResult.BoxModelResultID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = Error)]
                    // boxModelResult.BoxModelID   (Int32)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelID = 0;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.BoxModel, CSSPModelsRes.BoxModelResultBoxModelID, boxModelResult.BoxModelID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // boxModelResult.BoxModelResultType   (BoxModelResultTypeEnum)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)1000000;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelResultBoxModelResultType), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, -1)]
                    // boxModelResult.Volume_m3   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Volume_m3]

                    //Error: Type not implemented [Volume_m3]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.Volume_m3 = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelResultVolume_m3, "0"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, -1)]
                    // boxModelResult.Surface_m2   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Surface_m2]

                    //Error: Type not implemented [Surface_m2]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.Surface_m2 = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, CSSPModelsRes.BoxModelResultSurface_m2, "0"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // boxModelResult.Radius_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Radius_m]

                    //Error: Type not implemented [Radius_m]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.Radius_m = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultRadius_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.Radius_m = 100001.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultRadius_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 360)]
                    // boxModelResult.LeftSideDiameterLineAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideDiameterLineAngle_deg]

                    //Error: Type not implemented [LeftSideDiameterLineAngle_deg]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideDiameterLineAngle_deg = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideDiameterLineAngle_deg = 361.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // boxModelResult.CircleCenterLatitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CircleCenterLatitude]

                    //Error: Type not implemented [CircleCenterLatitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLatitude = -91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLatitude = 91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // boxModelResult.CircleCenterLongitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CircleCenterLongitude]

                    //Error: Type not implemented [CircleCenterLongitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLongitude = -181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLongitude = 181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // boxModelResult.FixLength   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // boxModelResult.FixWidth   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // boxModelResult.RectLength_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RectLength_m]

                    //Error: Type not implemented [RectLength_m]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.RectLength_m = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultRectLength_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.RectLength_m = 100001.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultRectLength_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // boxModelResult.RectWidth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [RectWidth_m]

                    //Error: Type not implemented [RectWidth_m]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.RectWidth_m = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultRectWidth_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.RectWidth_m = 100001.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultRectWidth_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 360)]
                    // boxModelResult.LeftSideLineAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideLineAngle_deg]

                    //Error: Type not implemented [LeftSideLineAngle_deg]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineAngle_deg = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineAngle_deg = 361.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // boxModelResult.LeftSideLineStartLatitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideLineStartLatitude]

                    //Error: Type not implemented [LeftSideLineStartLatitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLatitude = -91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLatitude = 91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // boxModelResult.LeftSideLineStartLongitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideLineStartLongitude]

                    //Error: Type not implemented [LeftSideLineStartLongitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLongitude = -181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLongitude = 181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // boxModelResult.BoxModelResultWeb   (BoxModelResultWeb)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultWeb = null;
                    Assert.IsNull(boxModelResult.BoxModelResultWeb);

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultWeb = new BoxModelResultWeb();
                    Assert.IsNotNull(boxModelResult.BoxModelResultWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // boxModelResult.BoxModelResultReport   (BoxModelResultReport)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultReport = null;
                    Assert.IsNull(boxModelResult.BoxModelResultReport);

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultReport = new BoxModelResultReport();
                    Assert.IsNotNull(boxModelResult.BoxModelResultReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // boxModelResult.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateDate_UTC = new DateTime();
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.BoxModelResultLastUpdateDate_UTC), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.BoxModelResultLastUpdateDate_UTC, "1980"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // boxModelResult.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateContactTVItemID = 0;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.BoxModelResultLastUpdateContactTVItemID, boxModelResult.LastUpdateContactTVItemID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateContactTVItemID = 1;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.BoxModelResultLastUpdateContactTVItemID, "Contact"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModelResult.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // boxModelResult.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void BoxModelResult_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    BoxModelResultService boxModelResultService = new BoxModelResultService(new GetParam(), dbTestDB, ContactID);
                    BoxModelResult boxModelResult = (from c in boxModelResultService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(boxModelResult);

                    BoxModelResult boxModelResultRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID, getParam);
                            Assert.IsNull(boxModelResultRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // BoxModelResult fields
                        Assert.IsNotNull(boxModelResultRet.BoxModelResultID);
                        Assert.IsNotNull(boxModelResultRet.BoxModelID);
                        Assert.IsNotNull(boxModelResultRet.BoxModelResultType);
                        Assert.IsNotNull(boxModelResultRet.Volume_m3);
                        Assert.IsNotNull(boxModelResultRet.Surface_m2);
                        Assert.IsNotNull(boxModelResultRet.Radius_m);
                        Assert.IsNotNull(boxModelResultRet.LeftSideDiameterLineAngle_deg);
                        Assert.IsNotNull(boxModelResultRet.CircleCenterLatitude);
                        Assert.IsNotNull(boxModelResultRet.CircleCenterLongitude);
                        Assert.IsNotNull(boxModelResultRet.FixLength);
                        Assert.IsNotNull(boxModelResultRet.FixWidth);
                        Assert.IsNotNull(boxModelResultRet.RectLength_m);
                        Assert.IsNotNull(boxModelResultRet.RectWidth_m);
                        Assert.IsNotNull(boxModelResultRet.LeftSideLineAngle_deg);
                        Assert.IsNotNull(boxModelResultRet.LeftSideLineStartLatitude);
                        Assert.IsNotNull(boxModelResultRet.LeftSideLineStartLongitude);
                        Assert.IsNotNull(boxModelResultRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(boxModelResultRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // BoxModelResultWeb and BoxModelResultReport fields should be null here
                            Assert.IsNull(boxModelResultRet.BoxModelResultWeb);
                            Assert.IsNull(boxModelResultRet.BoxModelResultReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // BoxModelResultWeb fields should not be null and BoxModelResultReport fields should be null here
                            if (boxModelResultRet.BoxModelResultWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.BoxModelResultWeb.LastUpdateContactTVText));
                            }
                            if (boxModelResultRet.BoxModelResultWeb.BoxModelResultTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.BoxModelResultWeb.BoxModelResultTypeText));
                            }
                            Assert.IsNull(boxModelResultRet.BoxModelResultReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // BoxModelResultWeb and BoxModelResultReport fields should NOT be null here
                            if (boxModelResultRet.BoxModelResultWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.BoxModelResultWeb.LastUpdateContactTVText));
                            }
                            if (boxModelResultRet.BoxModelResultWeb.BoxModelResultTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.BoxModelResultWeb.BoxModelResultTypeText));
                            }
                            if (boxModelResultRet.BoxModelResultReport.BoxModelResultReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.BoxModelResultReport.BoxModelResultReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of BoxModelResult
        #endregion Tests Get List of BoxModelResult

    }
}
