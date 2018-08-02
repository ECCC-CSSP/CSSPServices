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
    public partial class TideLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideLocationService tideLocationService { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationServiceTest() : base()
        {
            //tideLocationService = new TideLocationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideLocation_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideLocation tideLocation = GetFilledRandomTideLocation("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tideLocationService.GetRead().Count();

                    Assert.AreEqual(tideLocationService.GetRead().Count(), tideLocationService.GetEdit().Count());

                    tideLocationService.Add(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tideLocationService.GetRead().Where(c => c == tideLocation).Any());
                    tideLocationService.Update(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tideLocationService.GetRead().Count());
                    tideLocationService.Delete(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideLocation.TideLocationID   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationID = 0;
                    tideLocationService.Update(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationTideLocationID), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationID = 10000000;
                    tideLocationService.Update(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideLocation, CSSPModelsRes.TideLocationTideLocationID, tideLocation.TideLocationID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideLocation.Zone   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Zone = -1;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationZone, "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Zone = 10001;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationZone, "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideLocation.Name   (String)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("Name");
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(1, tideLocation.ValidationResults.Count());
                    Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationName)).Any());
                    Assert.AreEqual(null, tideLocation.Name);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideLocationName, "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideLocation.Prov   (String)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("Prov");
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(1, tideLocation.ValidationResults.Count());
                    Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationProv)).Any());
                    Assert.AreEqual(null, tideLocation.Prov);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Prov = GetRandomString("", 101);
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideLocationProv, "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // tideLocation.sid   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.sid = -1;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationsid, "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.sid = 100001;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationsid, "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-90, 90)]
                    // tideLocation.Lat   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Lat]

                    //Error: Type not implemented [Lat]

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lat = -91.0D;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLat, "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lat = 91.0D;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLat, "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-180, 180)]
                    // tideLocation.Lng   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Lng]

                    //Error: Type not implemented [Lng]

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lng = -181.0D;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLng, "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lng = 181.0D;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLng, "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideLocation.TideLocationWeb   (TideLocationWeb)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationWeb = null;
                    Assert.IsNull(tideLocation.TideLocationWeb);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationWeb = new TideLocationWeb();
                    Assert.IsNotNull(tideLocation.TideLocationWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideLocation.TideLocationReport   (TideLocationReport)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationReport = null;
                    Assert.IsNull(tideLocation.TideLocationReport);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationReport = new TideLocationReport();
                    Assert.IsNotNull(tideLocation.TideLocationReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideLocation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateDate_UTC = new DateTime();
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationLastUpdateDate_UTC), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TideLocationLastUpdateDate_UTC, "1980"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideLocation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateContactTVItemID = 0;
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideLocationLastUpdateContactTVItemID, tideLocation.LastUpdateContactTVItemID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateContactTVItemID = 1;
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideLocationLastUpdateContactTVItemID, "Contact"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideLocation.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideLocation.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTideLocationWithTideLocationID(tideLocation.TideLocationID)
        [TestMethod]
        public void GetTideLocationWithTideLocationID__tideLocation_TideLocationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideLocation tideLocation = (from c in tideLocationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideLocation);

                    TideLocation tideLocationRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideLocationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tideLocationRet = tideLocationService.GetTideLocationWithTideLocationID(tideLocation.TideLocationID);
                            Assert.IsNull(tideLocationRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationRet = tideLocationService.GetTideLocationWithTideLocationID(tideLocation.TideLocationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationRet = tideLocationService.GetTideLocationWithTideLocationID(tideLocation.TideLocationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationRet = tideLocationService.GetTideLocationWithTideLocationID(tideLocation.TideLocationID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(new List<TideLocation>() { tideLocationRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationWithTideLocationID(tideLocation.TideLocationID)

        #region Tests Generated for GetTideLocationList()
        [TestMethod]
        public void GetTideLocationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TideLocation tideLocation = (from c in tideLocationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideLocation);

                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideLocationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList()

        #region Tests Generated for GetTideLocationList() Skip Take
        [TestMethod]
        public void GetTideLocationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideLocationDirectQueryList = tideLocationService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                        Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                        Assert.AreEqual(1, tideLocationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take

        #region Tests Generated for GetTideLocationList() Skip Take Order
        [TestMethod]
        public void GetTideLocationList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1,  "TideLocationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideLocationDirectQueryList = tideLocationService.GetRead().Skip(1).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                        Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                        Assert.AreEqual(1, tideLocationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Order

        #region Tests Generated for GetTideLocationList() Skip Take 2Order
        [TestMethod]
        public void GetTideLocationList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "TideLocationID,Zone", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideLocationDirectQueryList = tideLocationService.GetRead().Skip(1).Take(1).OrderBy(c => c.TideLocationID).ThenBy(c => c.Zone).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                        Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                        Assert.AreEqual(1, tideLocationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take 2Order

        #region Tests Generated for GetTideLocationList() Skip Take Order Where
        [TestMethod]
        public void GetTideLocationList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "TideLocationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideLocationDirectQueryList = tideLocationService.GetRead().Where(c => c.TideLocationID == 4).Skip(0).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                        Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                        Assert.AreEqual(1, tideLocationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Order Where

        #region Tests Generated for GetTideLocationList() Skip Take Order 2Where
        [TestMethod]
        public void GetTideLocationList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "TideLocationID,GT,2|TideLocationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideLocationDirectQueryList = tideLocationService.GetRead().Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).Skip(0).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                        Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                        Assert.AreEqual(1, tideLocationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() Skip Take Order 2Where

        #region Tests Generated for GetTideLocationList() 2Where
        [TestMethod]
        public void GetTideLocationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideLocation> tideLocationList = new List<TideLocation>();
                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 10000, "", "TideLocationID,GT,2|TideLocationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tideLocationDirectQueryList = tideLocationService.GetRead().Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            Assert.AreEqual(0, tideLocationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTideLocationFields(tideLocationList, entityQueryDetailType);
                        Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                        Assert.AreEqual(2, tideLocationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() 2Where

        #region Functions private
        private void CheckTideLocationFields(List<TideLocation> tideLocationList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // TideLocation fields
            Assert.IsNotNull(tideLocationList[0].TideLocationID);
            Assert.IsNotNull(tideLocationList[0].Zone);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationList[0].Prov));
            Assert.IsNotNull(tideLocationList[0].sid);
            Assert.IsNotNull(tideLocationList[0].Lat);
            Assert.IsNotNull(tideLocationList[0].Lng);
            Assert.IsNotNull(tideLocationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideLocationList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TideLocationWeb and TideLocationReport fields should be null here
                Assert.IsNull(tideLocationList[0].TideLocationWeb);
                Assert.IsNull(tideLocationList[0].TideLocationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TideLocationWeb fields should not be null and TideLocationReport fields should be null here
                Assert.IsNotNull(tideLocationList[0].TideLocationWeb.LastUpdateContactTVItemLanguage);
                Assert.IsNull(tideLocationList[0].TideLocationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TideLocationWeb and TideLocationReport fields should NOT be null here
                Assert.IsNotNull(tideLocationList[0].TideLocationWeb.LastUpdateContactTVItemLanguage);
                if (tideLocationList[0].TideLocationReport.TideLocationReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationList[0].TideLocationReport.TideLocationReportTest));
                }
            }
        }
        private TideLocation GetFilledRandomTideLocation(string OmitPropName)
        {
            TideLocation tideLocation = new TideLocation();

            if (OmitPropName != "Zone") tideLocation.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "Name") tideLocation.Name = GetRandomString("", 5);
            if (OmitPropName != "Prov") tideLocation.Prov = GetRandomString("", 5);
            if (OmitPropName != "sid") tideLocation.sid = GetRandomInt(0, 100000);
            if (OmitPropName != "Lat") tideLocation.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") tideLocation.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideLocation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideLocation.LastUpdateContactTVItemID = 2;

            return tideLocation;
        }
        #endregion Functions private
    }
}
