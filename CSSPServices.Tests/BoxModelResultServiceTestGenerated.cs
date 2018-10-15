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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void BoxModelResult_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = boxModelResultService.GetBoxModelResultList().Count();

                    Assert.AreEqual(boxModelResultService.GetBoxModelResultList().Count(), (from c in dbTestDB.BoxModelResults select c).Take(200).Count());

                    boxModelResultService.Add(boxModelResult);
                    if (boxModelResult.HasErrors)
                    {
                        Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, boxModelResultService.GetBoxModelResultList().Where(c => c == boxModelResult).Any());
                    boxModelResultService.Update(boxModelResult);
                    if (boxModelResult.HasErrors)
                    {
                        Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResultService.Delete(boxModelResult);
                    if (boxModelResult.HasErrors)
                    {
                        Assert.AreEqual("", boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultBoxModelResultID"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultID = 10000000;
                    boxModelResultService.Update(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModelResult", "BoxModelResultBoxModelResultID", boxModelResult.BoxModelResultID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = )]
                    // boxModelResult.BoxModelID   (Int32)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelID = 0;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelResultBoxModelID", boxModelResult.BoxModelID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // boxModelResult.BoxModelResultType   (BoxModelResultTypeEnum)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)1000000;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultBoxModelResultType"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "BoxModelResultVolume_m3", "0"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "BoxModelResultSurface_m2", "0"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRadius_m", "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.Radius_m = 100001.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRadius_m", "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 360)]
                    // boxModelResult.LeftSideDiameterLineAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideDiameterLineAngle_deg]

                    //Error: Type not implemented [LeftSideDiameterLineAngle_deg]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideDiameterLineAngle_deg = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideDiameterLineAngle_deg", "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideDiameterLineAngle_deg = 361.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideDiameterLineAngle_deg", "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-90, 90)]
                    // boxModelResult.CircleCenterLatitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CircleCenterLatitude]

                    //Error: Type not implemented [CircleCenterLatitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLatitude = -91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultCircleCenterLatitude", "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLatitude = 91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultCircleCenterLatitude", "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-180, 180)]
                    // boxModelResult.CircleCenterLongitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [CircleCenterLongitude]

                    //Error: Type not implemented [CircleCenterLongitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLongitude = -181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultCircleCenterLongitude", "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.CircleCenterLongitude = 181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultCircleCenterLongitude", "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRectLength_m", "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.RectLength_m = 100001.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRectLength_m", "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRectWidth_m", "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.RectWidth_m = 100001.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRectWidth_m", "0", "100000"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 360)]
                    // boxModelResult.LeftSideLineAngle_deg   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideLineAngle_deg]

                    //Error: Type not implemented [LeftSideLineAngle_deg]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineAngle_deg = -1.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineAngle_deg", "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineAngle_deg = 361.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineAngle_deg", "0", "360"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-90, 90)]
                    // boxModelResult.LeftSideLineStartLatitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideLineStartLatitude]

                    //Error: Type not implemented [LeftSideLineStartLatitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLatitude = -91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineStartLatitude", "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLatitude = 91.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineStartLatitude", "-90", "90"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(-180, 180)]
                    // boxModelResult.LeftSideLineStartLongitude   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [LeftSideLineStartLongitude]

                    //Error: Type not implemented [LeftSideLineStartLongitude]

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLongitude = -181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineStartLongitude", "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LeftSideLineStartLongitude = 181.0D;
                    Assert.AreEqual(false, boxModelResultService.Add(boxModelResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineStartLongitude", "-180", "180"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, boxModelResultService.GetBoxModelResultList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // boxModelResult.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateDate_UTC = new DateTime();
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultLastUpdateDate_UTC"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "BoxModelResultLastUpdateDate_UTC", "1980"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // boxModelResult.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateContactTVItemID = 0;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelResultLastUpdateContactTVItemID", boxModelResult.LastUpdateContactTVItemID.ToString()), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    boxModelResult = null;
                    boxModelResult = GetFilledRandomBoxModelResult("");
                    boxModelResult.LastUpdateContactTVItemID = 1;
                    boxModelResultService.Add(boxModelResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelResultLastUpdateContactTVItemID", "Contact"), boxModelResult.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated for GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID)
        [TestMethod]
        public void GetBoxModelResultWithBoxModelResultID__boxModelResult_BoxModelResultID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    BoxModelResult boxModelResult = (from c in dbTestDB.BoxModelResults select c).FirstOrDefault();
                    Assert.IsNotNull(boxModelResult);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        boxModelResultService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            BoxModelResult boxModelResultRet = boxModelResultService.GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID);
                            CheckBoxModelResultFields(new List<BoxModelResult>() { boxModelResultRet });
                            Assert.AreEqual(boxModelResult.BoxModelResultID, boxModelResultRet.BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            BoxModelResultExtraA boxModelResultExtraARet = boxModelResultService.GetBoxModelResultExtraAWithBoxModelResultID(boxModelResult.BoxModelResultID);
                            CheckBoxModelResultExtraAFields(new List<BoxModelResultExtraA>() { boxModelResultExtraARet });
                            Assert.AreEqual(boxModelResult.BoxModelResultID, boxModelResultExtraARet.BoxModelResultID);
                        }
                        else if (detail == "ExtraB")
                        {
                            BoxModelResultExtraB boxModelResultExtraBRet = boxModelResultService.GetBoxModelResultExtraBWithBoxModelResultID(boxModelResult.BoxModelResultID);
                            CheckBoxModelResultExtraBFields(new List<BoxModelResultExtraB>() { boxModelResultExtraBRet });
                            Assert.AreEqual(boxModelResult.BoxModelResultID, boxModelResultExtraBRet.BoxModelResultID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultWithBoxModelResultID(boxModelResult.BoxModelResultID)

        #region Tests Generated for GetBoxModelResultList()
        [TestMethod]
        public void GetBoxModelResultList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    BoxModelResult boxModelResult = (from c in dbTestDB.BoxModelResults select c).FirstOrDefault();
                    Assert.IsNotNull(boxModelResult);

                    List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                    boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        boxModelResultService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList()

        #region Tests Generated for GetBoxModelResultList() Skip Take
        [TestMethod]
        public void GetBoxModelResultList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                        boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultList[0].BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraAList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraBList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList() Skip Take

        #region Tests Generated for GetBoxModelResultList() Skip Take Order
        [TestMethod]
        public void GetBoxModelResultList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), culture.TwoLetterISOLanguageName, 1, 1,  "BoxModelResultID", "");

                        List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                        boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Skip(1).Take(1).OrderBy(c => c.BoxModelResultID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultList[0].BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraAList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraBList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList() Skip Take Order

        #region Tests Generated for GetBoxModelResultList() Skip Take 2Order
        [TestMethod]
        public void GetBoxModelResultList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), culture.TwoLetterISOLanguageName, 1, 1, "BoxModelResultID,BoxModelID", "");

                        List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                        boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Skip(1).Take(1).OrderBy(c => c.BoxModelResultID).ThenBy(c => c.BoxModelID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultList[0].BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraAList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraBList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList() Skip Take 2Order

        #region Tests Generated for GetBoxModelResultList() Skip Take Order Where
        [TestMethod]
        public void GetBoxModelResultList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), culture.TwoLetterISOLanguageName, 0, 1, "BoxModelResultID", "BoxModelResultID,EQ,4", "");

                        List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                        boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Where(c => c.BoxModelResultID == 4).Skip(0).Take(1).OrderBy(c => c.BoxModelResultID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultList[0].BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraAList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraBList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList() Skip Take Order Where

        #region Tests Generated for GetBoxModelResultList() Skip Take Order 2Where
        [TestMethod]
        public void GetBoxModelResultList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), culture.TwoLetterISOLanguageName, 0, 1, "BoxModelResultID", "BoxModelResultID,GT,2|BoxModelResultID,LT,5", "");

                        List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                        boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Where(c => c.BoxModelResultID > 2 && c.BoxModelResultID < 5).Skip(0).Take(1).OrderBy(c => c.BoxModelResultID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultList[0].BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraAList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraBList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList() Skip Take Order 2Where

        #region Tests Generated for GetBoxModelResultList() 2Where
        [TestMethod]
        public void GetBoxModelResultList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        BoxModelResultService boxModelResultService = new BoxModelResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        boxModelResultService.Query = boxModelResultService.FillQuery(typeof(BoxModelResult), culture.TwoLetterISOLanguageName, 0, 10000, "", "BoxModelResultID,GT,2|BoxModelResultID,LT,5", "");

                        List<BoxModelResult> boxModelResultDirectQueryList = new List<BoxModelResult>();
                        boxModelResultDirectQueryList = (from c in dbTestDB.BoxModelResults select c).Where(c => c.BoxModelResultID > 2 && c.BoxModelResultID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<BoxModelResult> boxModelResultList = new List<BoxModelResult>();
                            boxModelResultList = boxModelResultService.GetBoxModelResultList().ToList();
                            CheckBoxModelResultFields(boxModelResultList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultList[0].BoxModelResultID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<BoxModelResultExtraA> boxModelResultExtraAList = new List<BoxModelResultExtraA>();
                            boxModelResultExtraAList = boxModelResultService.GetBoxModelResultExtraAList().ToList();
                            CheckBoxModelResultExtraAFields(boxModelResultExtraAList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraAList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<BoxModelResultExtraB> boxModelResultExtraBList = new List<BoxModelResultExtraB>();
                            boxModelResultExtraBList = boxModelResultService.GetBoxModelResultExtraBList().ToList();
                            CheckBoxModelResultExtraBFields(boxModelResultExtraBList);
                            Assert.AreEqual(boxModelResultDirectQueryList[0].BoxModelResultID, boxModelResultExtraBList[0].BoxModelResultID);
                            Assert.AreEqual(boxModelResultDirectQueryList.Count, boxModelResultExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetBoxModelResultList() 2Where

        #region Functions private
        private void CheckBoxModelResultFields(List<BoxModelResult> boxModelResultList)
        {
            Assert.IsNotNull(boxModelResultList[0].BoxModelResultID);
            Assert.IsNotNull(boxModelResultList[0].BoxModelID);
            Assert.IsNotNull(boxModelResultList[0].BoxModelResultType);
            Assert.IsNotNull(boxModelResultList[0].Volume_m3);
            Assert.IsNotNull(boxModelResultList[0].Surface_m2);
            Assert.IsNotNull(boxModelResultList[0].Radius_m);
            if (boxModelResultList[0].LeftSideDiameterLineAngle_deg != null)
            {
                Assert.IsNotNull(boxModelResultList[0].LeftSideDiameterLineAngle_deg);
            }
            if (boxModelResultList[0].CircleCenterLatitude != null)
            {
                Assert.IsNotNull(boxModelResultList[0].CircleCenterLatitude);
            }
            if (boxModelResultList[0].CircleCenterLongitude != null)
            {
                Assert.IsNotNull(boxModelResultList[0].CircleCenterLongitude);
            }
            Assert.IsNotNull(boxModelResultList[0].FixLength);
            Assert.IsNotNull(boxModelResultList[0].FixWidth);
            Assert.IsNotNull(boxModelResultList[0].RectLength_m);
            Assert.IsNotNull(boxModelResultList[0].RectWidth_m);
            if (boxModelResultList[0].LeftSideLineAngle_deg != null)
            {
                Assert.IsNotNull(boxModelResultList[0].LeftSideLineAngle_deg);
            }
            if (boxModelResultList[0].LeftSideLineStartLatitude != null)
            {
                Assert.IsNotNull(boxModelResultList[0].LeftSideLineStartLatitude);
            }
            if (boxModelResultList[0].LeftSideLineStartLongitude != null)
            {
                Assert.IsNotNull(boxModelResultList[0].LeftSideLineStartLongitude);
            }
            Assert.IsNotNull(boxModelResultList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelResultList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelResultList[0].HasErrors);
        }
        private void CheckBoxModelResultExtraAFields(List<BoxModelResultExtraA> boxModelResultExtraAList)
        {
            Assert.IsNotNull(boxModelResultExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(boxModelResultExtraAList[0].BoxModelResultTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultExtraAList[0].BoxModelResultTypeText));
            }
            Assert.IsNotNull(boxModelResultExtraAList[0].BoxModelResultID);
            Assert.IsNotNull(boxModelResultExtraAList[0].BoxModelID);
            Assert.IsNotNull(boxModelResultExtraAList[0].BoxModelResultType);
            Assert.IsNotNull(boxModelResultExtraAList[0].Volume_m3);
            Assert.IsNotNull(boxModelResultExtraAList[0].Surface_m2);
            Assert.IsNotNull(boxModelResultExtraAList[0].Radius_m);
            if (boxModelResultExtraAList[0].LeftSideDiameterLineAngle_deg != null)
            {
                Assert.IsNotNull(boxModelResultExtraAList[0].LeftSideDiameterLineAngle_deg);
            }
            if (boxModelResultExtraAList[0].CircleCenterLatitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraAList[0].CircleCenterLatitude);
            }
            if (boxModelResultExtraAList[0].CircleCenterLongitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraAList[0].CircleCenterLongitude);
            }
            Assert.IsNotNull(boxModelResultExtraAList[0].FixLength);
            Assert.IsNotNull(boxModelResultExtraAList[0].FixWidth);
            Assert.IsNotNull(boxModelResultExtraAList[0].RectLength_m);
            Assert.IsNotNull(boxModelResultExtraAList[0].RectWidth_m);
            if (boxModelResultExtraAList[0].LeftSideLineAngle_deg != null)
            {
                Assert.IsNotNull(boxModelResultExtraAList[0].LeftSideLineAngle_deg);
            }
            if (boxModelResultExtraAList[0].LeftSideLineStartLatitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraAList[0].LeftSideLineStartLatitude);
            }
            if (boxModelResultExtraAList[0].LeftSideLineStartLongitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraAList[0].LeftSideLineStartLongitude);
            }
            Assert.IsNotNull(boxModelResultExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelResultExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelResultExtraAList[0].HasErrors);
        }
        private void CheckBoxModelResultExtraBFields(List<BoxModelResultExtraB> boxModelResultExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(boxModelResultExtraBList[0].BoxModelResultReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultExtraBList[0].BoxModelResultReportTest));
            }
            Assert.IsNotNull(boxModelResultExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(boxModelResultExtraBList[0].BoxModelResultTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(boxModelResultExtraBList[0].BoxModelResultTypeText));
            }
            Assert.IsNotNull(boxModelResultExtraBList[0].BoxModelResultID);
            Assert.IsNotNull(boxModelResultExtraBList[0].BoxModelID);
            Assert.IsNotNull(boxModelResultExtraBList[0].BoxModelResultType);
            Assert.IsNotNull(boxModelResultExtraBList[0].Volume_m3);
            Assert.IsNotNull(boxModelResultExtraBList[0].Surface_m2);
            Assert.IsNotNull(boxModelResultExtraBList[0].Radius_m);
            if (boxModelResultExtraBList[0].LeftSideDiameterLineAngle_deg != null)
            {
                Assert.IsNotNull(boxModelResultExtraBList[0].LeftSideDiameterLineAngle_deg);
            }
            if (boxModelResultExtraBList[0].CircleCenterLatitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraBList[0].CircleCenterLatitude);
            }
            if (boxModelResultExtraBList[0].CircleCenterLongitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraBList[0].CircleCenterLongitude);
            }
            Assert.IsNotNull(boxModelResultExtraBList[0].FixLength);
            Assert.IsNotNull(boxModelResultExtraBList[0].FixWidth);
            Assert.IsNotNull(boxModelResultExtraBList[0].RectLength_m);
            Assert.IsNotNull(boxModelResultExtraBList[0].RectWidth_m);
            if (boxModelResultExtraBList[0].LeftSideLineAngle_deg != null)
            {
                Assert.IsNotNull(boxModelResultExtraBList[0].LeftSideLineAngle_deg);
            }
            if (boxModelResultExtraBList[0].LeftSideLineStartLatitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraBList[0].LeftSideLineStartLatitude);
            }
            if (boxModelResultExtraBList[0].LeftSideLineStartLongitude != null)
            {
                Assert.IsNotNull(boxModelResultExtraBList[0].LeftSideLineStartLongitude);
            }
            Assert.IsNotNull(boxModelResultExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(boxModelResultExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(boxModelResultExtraBList[0].HasErrors);
        }
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

            return boxModelResult;
        }
        #endregion Functions private
    }
}
