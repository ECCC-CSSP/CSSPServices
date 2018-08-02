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
    public partial class TideDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideDataValueService tideDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueServiceTest() : base()
        {
            //tideDataValueService = new TideDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideDataValue tideDataValue = GetFilledRandomTideDataValue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tideDataValueService.GetRead().Count();

                    Assert.AreEqual(tideDataValueService.GetRead().Count(), tideDataValueService.GetEdit().Count());

                    tideDataValueService.Add(tideDataValue);
                    if (tideDataValue.HasErrors)
                    {
                        Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tideDataValueService.GetRead().Where(c => c == tideDataValue).Any());
                    tideDataValueService.Update(tideDataValue);
                    if (tideDataValue.HasErrors)
                    {
                        Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tideDataValueService.GetRead().Count());
                    tideDataValueService.Delete(tideDataValue);
                    if (tideDataValue.HasErrors)
                    {
                        Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideDataValue.TideDataValueID   (Int32)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueID = 0;
                    tideDataValueService.Update(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueTideDataValueID), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueID = 10000000;
                    tideDataValueService.Update(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideDataValue, CSSPModelsRes.TideDataValueTideDataValueID, tideDataValue.TideDataValueID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
                    // tideDataValue.TideSiteTVItemID   (Int32)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideSiteTVItemID = 0;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideDataValueTideSiteTVItemID, tideDataValue.TideSiteTVItemID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideSiteTVItemID = 1;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideDataValueTideSiteTVItemID, "TideSite"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideDataValue.DateTime_Local   (DateTime)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.DateTime_Local = new DateTime();
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueDateTime_Local), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.DateTime_Local = new DateTime(1979, 1, 1);
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TideDataValueDateTime_Local, "1980"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // tideDataValue.Keep   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tideDataValue.TideDataType   (TideDataTypeEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataType = (TideDataTypeEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueTideDataType), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tideDataValue.StorageDataType   (StorageDataTypeEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.StorageDataType = (StorageDataTypeEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueStorageDataType), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideDataValue.Depth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Depth_m]

                    //Error: Type not implemented [Depth_m]

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.Depth_m = -1.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideDataValueDepth_m, "0", "10000"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.Depth_m = 10001.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideDataValueDepth_m, "0", "10000"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10)]
                    // tideDataValue.UVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [UVelocity_m_s]

                    //Error: Type not implemented [UVelocity_m_s]

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.UVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideDataValueUVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.UVelocity_m_s = 11.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideDataValueUVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10)]
                    // tideDataValue.VVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [VVelocity_m_s]

                    //Error: Type not implemented [VVelocity_m_s]

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.VVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideDataValueVVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.VVelocity_m_s = 11.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideDataValueVVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // tideDataValue.TideStart   (TideTextEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideStart = (TideTextEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueTideStart), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // tideDataValue.TideEnd   (TideTextEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideEnd = (TideTextEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueTideEnd), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideDataValue.TideDataValueWeb   (TideDataValueWeb)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueWeb = null;
                    Assert.IsNull(tideDataValue.TideDataValueWeb);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueWeb = new TideDataValueWeb();
                    Assert.IsNotNull(tideDataValue.TideDataValueWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideDataValue.TideDataValueReport   (TideDataValueReport)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueReport = null;
                    Assert.IsNull(tideDataValue.TideDataValueReport);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueReport = new TideDataValueReport();
                    Assert.IsNotNull(tideDataValue.TideDataValueReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateDate_UTC = new DateTime();
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideDataValueLastUpdateDate_UTC), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TideDataValueLastUpdateDate_UTC, "1980"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideDataValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateContactTVItemID = 0;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideDataValueLastUpdateContactTVItemID, tideDataValue.LastUpdateContactTVItemID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateContactTVItemID = 1;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideDataValueLastUpdateContactTVItemID, "Contact"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideDataValue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID)
        [TestMethod]
        public void GetTideDataValueWithTideDataValueID__tideDataValue_TideDataValueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideDataValue tideDataValue = (from c in tideDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideDataValue);

                    TideDataValue tideDataValueRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideDataValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueRet = tideDataValueService.GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID);
                            Assert.IsNull(tideDataValueRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueRet = tideDataValueService.GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueRet = tideDataValueService.GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueRet = tideDataValueService.GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(new List<TideDataValue>() { tideDataValueRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID)

        #region Tests Generated for GetTideDataValueList()
        [TestMethod]
        public void GetTideDataValueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideDataValue tideDataValue = (from c in tideDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideDataValue);

                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideDataValueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList()

        #region Tests Generated for GetTideDataValueList() Skip Take
        [TestMethod]
        public void GetTideDataValueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    List<TideDataValue> tideDataValueDirectQueryList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideDataValueDirectQueryList = tideDataValueService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                        Assert.AreEqual(tideDataValueDirectQueryList[0].TideDataValueID, tideDataValueList[0].TideDataValueID);
                        Assert.AreEqual(1, tideDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList() Skip Take

        #region Tests Generated for GetTideDataValueList() Skip Take Order
        [TestMethod]
        public void GetTideDataValueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    List<TideDataValue> tideDataValueDirectQueryList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), culture.TwoLetterISOLanguageName, 1, 1,  "TideDataValueID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideDataValueDirectQueryList = tideDataValueService.GetRead().Skip(1).Take(1).OrderBy(c => c.TideDataValueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                        Assert.AreEqual(tideDataValueDirectQueryList[0].TideDataValueID, tideDataValueList[0].TideDataValueID);
                        Assert.AreEqual(1, tideDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList() Skip Take Order

        #region Tests Generated for GetTideDataValueList() Skip Take 2Order
        [TestMethod]
        public void GetTideDataValueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    List<TideDataValue> tideDataValueDirectQueryList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), culture.TwoLetterISOLanguageName, 1, 1, "TideDataValueID,TideSiteTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideDataValueDirectQueryList = tideDataValueService.GetRead().Skip(1).Take(1).OrderBy(c => c.TideDataValueID).ThenBy(c => c.TideSiteTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                        Assert.AreEqual(tideDataValueDirectQueryList[0].TideDataValueID, tideDataValueList[0].TideDataValueID);
                        Assert.AreEqual(1, tideDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList() Skip Take 2Order

        #region Tests Generated for GetTideDataValueList() Skip Take Order Where
        [TestMethod]
        public void GetTideDataValueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    List<TideDataValue> tideDataValueDirectQueryList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), culture.TwoLetterISOLanguageName, 0, 1, "TideDataValueID", "TideDataValueID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideDataValueDirectQueryList = tideDataValueService.GetRead().Where(c => c.TideDataValueID == 4).Skip(0).Take(1).OrderBy(c => c.TideDataValueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                        Assert.AreEqual(tideDataValueDirectQueryList[0].TideDataValueID, tideDataValueList[0].TideDataValueID);
                        Assert.AreEqual(1, tideDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList() Skip Take Order Where

        #region Tests Generated for GetTideDataValueList() Skip Take Order 2Where
        [TestMethod]
        public void GetTideDataValueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    List<TideDataValue> tideDataValueDirectQueryList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), culture.TwoLetterISOLanguageName, 0, 1, "TideDataValueID", "TideDataValueID,GT,2|TideDataValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideDataValueDirectQueryList = tideDataValueService.GetRead().Where(c => c.TideDataValueID > 2 && c.TideDataValueID < 5).Skip(0).Take(1).OrderBy(c => c.TideDataValueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                        Assert.AreEqual(tideDataValueDirectQueryList[0].TideDataValueID, tideDataValueList[0].TideDataValueID);
                        Assert.AreEqual(1, tideDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList() Skip Take Order 2Where

        #region Tests Generated for GetTideDataValueList() 2Where
        [TestMethod]
        public void GetTideDataValueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideDataValue> tideDataValueList = new List<TideDataValue>();
                    List<TideDataValue> tideDataValueDirectQueryList = new List<TideDataValue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideDataValueService tideDataValueService = new TideDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideDataValueService.Query = tideDataValueService.FillQuery(typeof(TideDataValue), culture.TwoLetterISOLanguageName, 0, 10000, "", "TideDataValueID,GT,2|TideDataValueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideDataValueDirectQueryList = tideDataValueService.GetRead().Where(c => c.TideDataValueID > 2 && c.TideDataValueID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                            Assert.AreEqual(0, tideDataValueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideDataValueList = tideDataValueService.GetTideDataValueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideDataValueFields(tideDataValueList, entityQueryDetailType);
                        Assert.AreEqual(tideDataValueDirectQueryList[0].TideDataValueID, tideDataValueList[0].TideDataValueID);
                        Assert.AreEqual(2, tideDataValueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideDataValueList() 2Where

        #region Functions private
        private void CheckTideDataValueFields(List<TideDataValue> tideDataValueList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // TideDataValue fields
            Assert.IsNotNull(tideDataValueList[0].TideDataValueID);
            Assert.IsNotNull(tideDataValueList[0].TideSiteTVItemID);
            Assert.IsNotNull(tideDataValueList[0].DateTime_Local);
            Assert.IsNotNull(tideDataValueList[0].Keep);
            Assert.IsNotNull(tideDataValueList[0].TideDataType);
            Assert.IsNotNull(tideDataValueList[0].StorageDataType);
            Assert.IsNotNull(tideDataValueList[0].Depth_m);
            Assert.IsNotNull(tideDataValueList[0].UVelocity_m_s);
            Assert.IsNotNull(tideDataValueList[0].VVelocity_m_s);
            if (tideDataValueList[0].TideStart != null)
            {
                Assert.IsNotNull(tideDataValueList[0].TideStart);
            }
            if (tideDataValueList[0].TideEnd != null)
            {
                Assert.IsNotNull(tideDataValueList[0].TideEnd);
            }
            Assert.IsNotNull(tideDataValueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideDataValueList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TideDataValueWeb and TideDataValueReport fields should be null here
                Assert.IsNull(tideDataValueList[0].TideDataValueWeb);
                Assert.IsNull(tideDataValueList[0].TideDataValueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TideDataValueWeb fields should not be null and TideDataValueReport fields should be null here
                Assert.IsNotNull(tideDataValueList[0].TideDataValueWeb.TideSiteTVItemLanguage);
                Assert.IsNotNull(tideDataValueList[0].TideDataValueWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideDataTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideDataTypeText));
                }
                if (!string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.StorageDataTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.StorageDataTypeText));
                }
                if (!string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideStartText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideStartText));
                }
                if (!string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideEndText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideEndText));
                }
                Assert.IsNull(tideDataValueList[0].TideDataValueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TideDataValueWeb and TideDataValueReport fields should NOT be null here
                Assert.IsNotNull(tideDataValueList[0].TideDataValueWeb.TideSiteTVItemLanguage);
                Assert.IsNotNull(tideDataValueList[0].TideDataValueWeb.LastUpdateContactTVItemLanguage);
                if (tideDataValueList[0].TideDataValueWeb.TideDataTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideDataTypeText));
                }
                if (tideDataValueList[0].TideDataValueWeb.StorageDataTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.StorageDataTypeText));
                }
                if (tideDataValueList[0].TideDataValueWeb.TideStartText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideStartText));
                }
                if (tideDataValueList[0].TideDataValueWeb.TideEndText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueWeb.TideEndText));
                }
                if (tideDataValueList[0].TideDataValueReport.TideDataValueReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueList[0].TideDataValueReport.TideDataValueReportTest));
                }
            }
        }
        private TideDataValue GetFilledRandomTideDataValue(string OmitPropName)
        {
            TideDataValue tideDataValue = new TideDataValue();

            if (OmitPropName != "TideSiteTVItemID") tideDataValue.TideSiteTVItemID = 34;
            if (OmitPropName != "DateTime_Local") tideDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") tideDataValue.Keep = true;
            if (OmitPropName != "TideDataType") tideDataValue.TideDataType = (TideDataTypeEnum)GetRandomEnumType(typeof(TideDataTypeEnum));
            if (OmitPropName != "StorageDataType") tideDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Depth_m") tideDataValue.Depth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "UVelocity_m_s") tideDataValue.UVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "VVelocity_m_s") tideDataValue.VVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "TideStart") tideDataValue.TideStart = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "TideEnd") tideDataValue.TideEnd = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tideDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideDataValue.LastUpdateContactTVItemID = 2;

            return tideDataValue;
        }
        #endregion Functions private
    }
}
