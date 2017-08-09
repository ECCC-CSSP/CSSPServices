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

            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = 1;
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
            if (OmitPropName != "LastUpdateContactTVText") boxModelResult.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "BoxModelResultTypeText") boxModelResult.BoxModelResultTypeText = GetRandomString("", 5);

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

                BoxModelResultService boxModelResultService = new BoxModelResultService(LanguageRequest, dbTestDB, ContactID);

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

                boxModelResultService.Add(boxModelResult);
                if (boxModelResult.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, boxModelResultService.GetRead().Where(c => c == boxModelResult).Any());
                boxModelResultService.Update(boxModelResult);
                if (boxModelResult.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, boxModelResultService.GetRead().Count());
                boxModelResultService.Delete(boxModelResult);
                if (boxModelResult.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultID), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = Error)]
                // boxModelResult.BoxModelID   (Int32)
                // -----------------------------------

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.BoxModelID = 0;
                boxModelResultService.Add(boxModelResult);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelResultBoxModelID, boxModelResult.BoxModelID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // boxModelResult.BoxModelResultType   (BoxModelResultTypeEnum)
                // -----------------------------------

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)1000000;
                boxModelResultService.Add(boxModelResult);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultType), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, -1)]
                // boxModelResult.Volume_m3   (Double)
                // -----------------------------------

                //Error: Type not implemented [Volume_m3]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.Volume_m3 = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultVolume_m3, "0"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, -1)]
                // boxModelResult.Surface_m2   (Double)
                // -----------------------------------

                //Error: Type not implemented [Surface_m2]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.Surface_m2 = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultSurface_m2, "0"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100000)]
                // boxModelResult.Radius_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [Radius_m]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.Radius_m = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.Radius_m = 100001.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 360)]
                // boxModelResult.LeftSideDiameterLineAngle_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [LeftSideDiameterLineAngle_deg]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideDiameterLineAngle_deg = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideDiameterLineAngle_deg = 361.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-90, 90)]
                // boxModelResult.CircleCenterLatitude   (Double)
                // -----------------------------------

                //Error: Type not implemented [CircleCenterLatitude]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.CircleCenterLatitude = -91.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.CircleCenterLatitude = 91.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-180, 180)]
                // boxModelResult.CircleCenterLongitude   (Double)
                // -----------------------------------

                //Error: Type not implemented [CircleCenterLongitude]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.CircleCenterLongitude = -181.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.CircleCenterLongitude = 181.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
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

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.RectLength_m = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.RectLength_m = 100001.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100000)]
                // boxModelResult.RectWidth_m   (Double)
                // -----------------------------------

                //Error: Type not implemented [RectWidth_m]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.RectWidth_m = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.RectWidth_m = 100001.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 360)]
                // boxModelResult.LeftSideLineAngle_deg   (Double)
                // -----------------------------------

                //Error: Type not implemented [LeftSideLineAngle_deg]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideLineAngle_deg = -1.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideLineAngle_deg = 361.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-90, 90)]
                // boxModelResult.LeftSideLineStartLatitude   (Double)
                // -----------------------------------

                //Error: Type not implemented [LeftSideLineStartLatitude]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideLineStartLatitude = -91.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideLineStartLatitude = 91.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(-180, 180)]
                // boxModelResult.LeftSideLineStartLongitude   (Double)
                // -----------------------------------

                //Error: Type not implemented [LeftSideLineStartLongitude]

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideLineStartLongitude = -181.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());
                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LeftSideLineStartLongitude = 181.0D;
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // boxModelResult.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // boxModelResult.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LastUpdateContactTVItemID = 0;
                boxModelResultService.Add(boxModelResult);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelResultLastUpdateContactTVItemID, boxModelResult.LastUpdateContactTVItemID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LastUpdateContactTVItemID = 1;
                boxModelResultService.Add(boxModelResult);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "Contact"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // boxModelResult.LastUpdateContactTVText   (String)
                // -----------------------------------

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelResultLastUpdateContactTVText, "200"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // boxModelResult.BoxModelResultTypeText   (String)
                // -----------------------------------

                boxModelResult = null;
                boxModelResult = GetFilledRandomBoxModelResult("");
                boxModelResult.BoxModelResultTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelResultBoxModelResultTypeText, "100"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, boxModelResultService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // boxModelResult.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                BoxModelResultService boxModelResultService = new BoxModelResultService(LanguageRequest, dbTestDB, ContactID);
                BoxModelResult boxModelResult = (from c in boxModelResultService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(boxModelResult);

                BoxModelResult boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID);
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

                Assert.IsNotNull(boxModelResultRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.LastUpdateContactTVText));
                Assert.IsNotNull(boxModelResultRet.BoxModelResultTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultRet.BoxModelResultTypeText));
            }
        }
        #endregion Tests Get With Key

    }
}
