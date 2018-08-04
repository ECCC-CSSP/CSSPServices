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

                    count = tideLocationService.GetTideLocationList().Count();

                    Assert.AreEqual(tideLocationService.GetTideLocationList().Count(), (from c in dbTestDB.TideLocations select c).Take(200).Count());

                    tideLocationService.Add(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tideLocationService.GetTideLocationList().Where(c => c == tideLocation).Any());
                    tideLocationService.Update(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tideLocationService.GetTideLocationList().Count());
                    tideLocationService.Delete(tideLocation);
                    if (tideLocation.HasErrors)
                    {
                        Assert.AreEqual("", tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TideLocationTideLocationID"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.TideLocationID = 10000000;
                    tideLocationService.Update(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationTideLocationID", tideLocation.TideLocationID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideLocation.Zone   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Zone = -1;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationZone", "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Zone = 10001;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationZone", "0", "10000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideLocation.Name   (String)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("Name");
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(1, tideLocation.ValidationResults.Count());
                    Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TideLocationName")).Any());
                    Assert.AreEqual(null, tideLocation.Name);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TideLocationName", "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideLocation.Prov   (String)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("Prov");
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(1, tideLocation.ValidationResults.Count());
                    Assert.IsTrue(tideLocation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TideLocationProv")).Any());
                    Assert.AreEqual(null, tideLocation.Prov);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Prov = GetRandomString("", 101);
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TideLocationProv", "100"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // tideLocation.sid   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.sid = -1;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationsid", "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.sid = 100001;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationsid", "0", "100000"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationLat", "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lat = 91.0D;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationLat", "-90", "90"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationLng", "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.Lng = 181.0D;
                    Assert.AreEqual(false, tideLocationService.Add(tideLocation));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationLng", "-180", "180"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideLocationService.GetTideLocationList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideLocation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateDate_UTC = new DateTime();
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TideLocationLastUpdateDate_UTC"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TideLocationLastUpdateDate_UTC", "1980"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideLocation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateContactTVItemID = 0;
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideLocationLastUpdateContactTVItemID", tideLocation.LastUpdateContactTVItemID.ToString()), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideLocation = null;
                    tideLocation = GetFilledRandomTideLocation("");
                    tideLocation.LastUpdateContactTVItemID = 1;
                    tideLocationService.Add(tideLocation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TideLocationLastUpdateContactTVItemID", "Contact"), tideLocation.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    TideLocation tideLocation = (from c in dbTestDB.TideLocations select c).FirstOrDefault();
                    Assert.IsNotNull(tideLocation);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideLocationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            TideLocation tideLocationRet = tideLocationService.GetTideLocationWithTideLocationID(tideLocation.TideLocationID);
                            CheckTideLocationFields(new List<TideLocation>() { tideLocationRet });
                            Assert.AreEqual(tideLocation.TideLocationID, tideLocationRet.TideLocationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            TideLocationWeb tideLocationWebRet = tideLocationService.GetTideLocationWebWithTideLocationID(tideLocation.TideLocationID);
                            CheckTideLocationWebFields(new List<TideLocationWeb>() { tideLocationWebRet });
                            Assert.AreEqual(tideLocation.TideLocationID, tideLocationWebRet.TideLocationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            TideLocationReport tideLocationReportRet = tideLocationService.GetTideLocationReportWithTideLocationID(tideLocation.TideLocationID);
                            CheckTideLocationReportFields(new List<TideLocationReport>() { tideLocationReportRet });
                            Assert.AreEqual(tideLocation.TideLocationID, tideLocationReportRet.TideLocationID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    TideLocation tideLocation = (from c in dbTestDB.TideLocations select c).FirstOrDefault();
                    Assert.IsNotNull(tideLocation);

                    List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                    tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideLocationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                        tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationWebList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationReportList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1,  "TideLocationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                        tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Skip(1).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationWebList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationReportList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 1, 1, "TideLocationID,Zone", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                        tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Skip(1).Take(1).OrderBy(c => c.TideLocationID).ThenBy(c => c.Zone).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationWebList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationReportList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "TideLocationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                        tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID == 4).Skip(0).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationWebList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationReportList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 1, "TideLocationID", "TideLocationID,GT,2|TideLocationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                        tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).Skip(0).Take(1).OrderBy(c => c.TideLocationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationWebList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationReportList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TideLocationService tideLocationService = new TideLocationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tideLocationService.Query = tideLocationService.FillQuery(typeof(TideLocation), culture.TwoLetterISOLanguageName, 0, 10000, "", "TideLocationID,GT,2|TideLocationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TideLocation> tideLocationDirectQueryList = new List<TideLocation>();
                        tideLocationDirectQueryList = (from c in dbTestDB.TideLocations select c).Where(c => c.TideLocationID > 2 && c.TideLocationID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TideLocation> tideLocationList = new List<TideLocation>();
                            tideLocationList = tideLocationService.GetTideLocationList().ToList();
                            CheckTideLocationFields(tideLocationList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TideLocationWeb> tideLocationWebList = new List<TideLocationWeb>();
                            tideLocationWebList = tideLocationService.GetTideLocationWebList().ToList();
                            CheckTideLocationWebFields(tideLocationWebList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationWebList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TideLocationReport> tideLocationReportList = new List<TideLocationReport>();
                            tideLocationReportList = tideLocationService.GetTideLocationReportList().ToList();
                            CheckTideLocationReportFields(tideLocationReportList);
                            Assert.AreEqual(tideLocationDirectQueryList[0].TideLocationID, tideLocationReportList[0].TideLocationID);
                            Assert.AreEqual(tideLocationDirectQueryList.Count, tideLocationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideLocationList() 2Where

        #region Functions private
        private void CheckTideLocationFields(List<TideLocation> tideLocationList)
        {
            Assert.IsNotNull(tideLocationList[0].TideLocationID);
            Assert.IsNotNull(tideLocationList[0].Zone);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationList[0].Prov));
            Assert.IsNotNull(tideLocationList[0].sid);
            Assert.IsNotNull(tideLocationList[0].Lat);
            Assert.IsNotNull(tideLocationList[0].Lng);
            Assert.IsNotNull(tideLocationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideLocationList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideLocationList[0].HasErrors);
        }
        private void CheckTideLocationWebFields(List<TideLocationWeb> tideLocationWebList)
        {
            Assert.IsNotNull(tideLocationWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(tideLocationWebList[0].TideLocationID);
            Assert.IsNotNull(tideLocationWebList[0].Zone);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationWebList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationWebList[0].Prov));
            Assert.IsNotNull(tideLocationWebList[0].sid);
            Assert.IsNotNull(tideLocationWebList[0].Lat);
            Assert.IsNotNull(tideLocationWebList[0].Lng);
            Assert.IsNotNull(tideLocationWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideLocationWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideLocationWebList[0].HasErrors);
        }
        private void CheckTideLocationReportFields(List<TideLocationReport> tideLocationReportList)
        {
            if (!string.IsNullOrWhiteSpace(tideLocationReportList[0].TideLocationReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationReportList[0].TideLocationReportTest));
            }
            Assert.IsNotNull(tideLocationReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(tideLocationReportList[0].TideLocationID);
            Assert.IsNotNull(tideLocationReportList[0].Zone);
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationReportList[0].Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tideLocationReportList[0].Prov));
            Assert.IsNotNull(tideLocationReportList[0].sid);
            Assert.IsNotNull(tideLocationReportList[0].Lat);
            Assert.IsNotNull(tideLocationReportList[0].Lng);
            Assert.IsNotNull(tideLocationReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tideLocationReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tideLocationReportList[0].HasErrors);
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
