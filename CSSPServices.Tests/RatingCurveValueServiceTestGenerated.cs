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
    public partial class RatingCurveValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RatingCurveValueService ratingCurveValueService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueServiceTest() : base()
        {
            //ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurveValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    RatingCurveValue ratingCurveValue = GetFilledRandomRatingCurveValue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = ratingCurveValueService.GetRead().Count();

                    Assert.AreEqual(ratingCurveValueService.GetRead().Count(), ratingCurveValueService.GetEdit().Count());

                    ratingCurveValueService.Add(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, ratingCurveValueService.GetRead().Where(c => c == ratingCurveValue).Any());
                    ratingCurveValueService.Update(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, ratingCurveValueService.GetRead().Count());
                    ratingCurveValueService.Delete(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // ratingCurveValue.RatingCurveValueID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueID = 0;
                    ratingCurveValueService.Update(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveValueRatingCurveValueID), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueID = 10000000;
                    ratingCurveValueService.Update(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurveValue, CSSPModelsRes.RatingCurveValueRatingCurveValueID, ratingCurveValue.RatingCurveValueID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID", AllowableTVtypeList = )]
                    // ratingCurveValue.RatingCurveID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveID = 0;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurve, CSSPModelsRes.RatingCurveValueRatingCurveID, ratingCurveValue.RatingCurveID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // ratingCurveValue.StageValue_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [StageValue_m]

                    //Error: Type not implemented [StageValue_m]

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.StageValue_m = -1.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueStageValue_m, "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.StageValue_m = 1001.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueStageValue_m, "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // ratingCurveValue.DischargeValue_m3_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DischargeValue_m3_s]

                    //Error: Type not implemented [DischargeValue_m3_s]

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.DischargeValue_m3_s = -1.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RatingCurveValueDischargeValue_m3_s, "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // ratingCurveValue.RatingCurveValueWeb   (RatingCurveValueWeb)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueWeb = null;
                    Assert.IsNull(ratingCurveValue.RatingCurveValueWeb);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueWeb = new RatingCurveValueWeb();
                    Assert.IsNotNull(ratingCurveValue.RatingCurveValueWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // ratingCurveValue.RatingCurveValueReport   (RatingCurveValueReport)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueReport = null;
                    Assert.IsNull(ratingCurveValue.RatingCurveValueReport);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueReport = new RatingCurveValueReport();
                    Assert.IsNotNull(ratingCurveValue.RatingCurveValueReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // ratingCurveValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateDate_UTC = new DateTime();
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveValueLastUpdateDate_UTC), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RatingCurveValueLastUpdateDate_UTC, "1980"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // ratingCurveValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateContactTVItemID = 0;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID, ratingCurveValue.LastUpdateContactTVItemID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateContactTVItemID = 1;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RatingCurveValueLastUpdateContactTVItemID, "Contact"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurveValue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurveValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID)
        [TestMethod]
        public void GetRatingCurveValueWithRatingCurveValueID__ratingCurveValue_RatingCurveValueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurveValue ratingCurveValue = (from c in ratingCurveValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    RatingCurveValue ratingCurveValueRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ratingCurveValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                            Assert.IsNull(ratingCurveValueRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(new List<RatingCurveValue>() { ratingCurveValueRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID)

        #region Tests Generated for GetRatingCurveValueList()
        [TestMethod]
        public void GetRatingCurveValueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurveValue ratingCurveValue = (from c in ratingCurveValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ratingCurveValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList()

        #region Tests Generated for GetRatingCurveValueList() Skip Take
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveValueDirectQueryList = ratingCurveValueService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        Assert.AreEqual(1, ratingCurveValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take

        #region Tests Generated for GetRatingCurveValueList() Skip Take Order
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 1, 1,  "RatingCurveValueID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveValueDirectQueryList = ratingCurveValueService.GetRead().Skip(1).Take(1).OrderBy(c => c.RatingCurveValueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        Assert.AreEqual(1, ratingCurveValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take Order

        #region Tests Generated for GetRatingCurveValueList() Skip Take 2Order
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 1, 1, "RatingCurveValueID,RatingCurveID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveValueDirectQueryList = ratingCurveValueService.GetRead().Skip(1).Take(1).OrderBy(c => c.RatingCurveValueID).ThenBy(c => c.RatingCurveID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        Assert.AreEqual(1, ratingCurveValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take 2Order

        #region Tests Generated for GetRatingCurveValueList() Skip Take Order Where
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveValueID", "RatingCurveValueID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveValueDirectQueryList = ratingCurveValueService.GetRead().Where(c => c.RatingCurveValueID == 4).Skip(0).Take(1).OrderBy(c => c.RatingCurveValueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        Assert.AreEqual(1, ratingCurveValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take Order Where

        #region Tests Generated for GetRatingCurveValueList() Skip Take Order 2Where
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveValueID", "RatingCurveValueID,GT,2|RatingCurveValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveValueDirectQueryList = ratingCurveValueService.GetRead().Where(c => c.RatingCurveValueID > 2 && c.RatingCurveValueID < 5).Skip(0).Take(1).OrderBy(c => c.RatingCurveValueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        Assert.AreEqual(1, ratingCurveValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take Order 2Where

        #region Tests Generated for GetRatingCurveValueList() 2Where
        [TestMethod]
        public void GetRatingCurveValueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 0, 10000, "", "RatingCurveValueID,GT,2|RatingCurveValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveValueDirectQueryList = ratingCurveValueService.GetRead().Where(c => c.RatingCurveValueID > 2 && c.RatingCurveValueID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            Assert.AreEqual(0, ratingCurveValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveValueFields(ratingCurveValueList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        Assert.AreEqual(2, ratingCurveValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() 2Where

        #region Functions private
        private void CheckRatingCurveValueFields(List<RatingCurveValue> ratingCurveValueList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // RatingCurveValue fields
            Assert.IsNotNull(ratingCurveValueList[0].RatingCurveValueID);
            Assert.IsNotNull(ratingCurveValueList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveValueList[0].StageValue_m);
            Assert.IsNotNull(ratingCurveValueList[0].DischargeValue_m3_s);
            Assert.IsNotNull(ratingCurveValueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveValueList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // RatingCurveValueWeb and RatingCurveValueReport fields should be null here
                Assert.IsNull(ratingCurveValueList[0].RatingCurveValueWeb);
                Assert.IsNull(ratingCurveValueList[0].RatingCurveValueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // RatingCurveValueWeb fields should not be null and RatingCurveValueReport fields should be null here
                Assert.IsNotNull(ratingCurveValueList[0].RatingCurveValueWeb.LastUpdateContactTVItemLanguage);
                Assert.IsNull(ratingCurveValueList[0].RatingCurveValueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // RatingCurveValueWeb and RatingCurveValueReport fields should NOT be null here
                Assert.IsNotNull(ratingCurveValueList[0].RatingCurveValueWeb.LastUpdateContactTVItemLanguage);
                if (ratingCurveValueList[0].RatingCurveValueReport.RatingCurveValueReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveValueList[0].RatingCurveValueReport.RatingCurveValueReportTest));
                }
            }
        }
        private RatingCurveValue GetFilledRandomRatingCurveValue(string OmitPropName)
        {
            RatingCurveValue ratingCurveValue = new RatingCurveValue();

            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = 1;
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;

            return ratingCurveValue;
        }
        #endregion Functions private
    }
}
