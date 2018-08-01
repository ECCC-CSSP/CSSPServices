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
    public partial class RatingCurveServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RatingCurveService ratingCurveService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveServiceTest() : base()
        {
            //ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurve_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    RatingCurve ratingCurve = GetFilledRandomRatingCurve("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = ratingCurveService.GetRead().Count();

                    Assert.AreEqual(ratingCurveService.GetRead().Count(), ratingCurveService.GetEdit().Count());

                    ratingCurveService.Add(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, ratingCurveService.GetRead().Where(c => c == ratingCurve).Any());
                    ratingCurveService.Update(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, ratingCurveService.GetRead().Count());
                    ratingCurveService.Delete(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // ratingCurve.RatingCurveID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveID = 0;
                    ratingCurveService.Update(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveRatingCurveID), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveID = 10000000;
                    ratingCurveService.Update(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RatingCurve, CSSPModelsRes.RatingCurveRatingCurveID, ratingCurve.RatingCurveID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
                    // ratingCurve.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.HydrometricSiteID = 0;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricSite, CSSPModelsRes.RatingCurveHydrometricSiteID, ratingCurve.HydrometricSiteID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // ratingCurve.RatingCurveNumber   (String)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(1, ratingCurve.ValidationResults.Count());
                    Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveRatingCurveNumber)).Any());
                    Assert.AreEqual(null, ratingCurve.RatingCurveNumber);
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RatingCurveRatingCurveNumber, "50"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // ratingCurve.RatingCurveWeb   (RatingCurveWeb)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveWeb = null;
                    Assert.IsNull(ratingCurve.RatingCurveWeb);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveWeb = new RatingCurveWeb();
                    Assert.IsNotNull(ratingCurve.RatingCurveWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // ratingCurve.RatingCurveReport   (RatingCurveReport)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveReport = null;
                    Assert.IsNull(ratingCurve.RatingCurveReport);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveReport = new RatingCurveReport();
                    Assert.IsNotNull(ratingCurve.RatingCurveReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // ratingCurve.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateDate_UTC = new DateTime();
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RatingCurveLastUpdateDate_UTC), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RatingCurveLastUpdateDate_UTC, "1980"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // ratingCurve.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVItemID = 0;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RatingCurveLastUpdateContactTVItemID, ratingCurve.LastUpdateContactTVItemID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVItemID = 1;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RatingCurveLastUpdateContactTVItemID, "Contact"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurve.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurve.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID)
        [TestMethod]
        public void GetRatingCurveWithRatingCurveID__ratingCurve_RatingCurveID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in ratingCurveService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    RatingCurve ratingCurveRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ratingCurveService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                            Assert.IsNull(ratingCurveRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(new List<RatingCurve>() { ratingCurveRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID)

        #region Tests Generated for GetRatingCurveList()
        [TestMethod]
        public void GetRatingCurveList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in ratingCurveService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ratingCurveService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList()

        #region Tests Generated for GetRatingCurveList() Skip Take
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveDirectQueryList = ratingCurveService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        Assert.AreEqual(1, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take

        #region Tests Generated for GetRatingCurveList() Skip Take Order
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 1, 1,  "RatingCurveID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveDirectQueryList = ratingCurveService.GetRead().Skip(1).Take(1).OrderBy(c => c.RatingCurveID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        Assert.AreEqual(1, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take Order

        #region Tests Generated for GetRatingCurveList() Skip Take 2Order
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 1, 1, "RatingCurveID,HydrometricSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveDirectQueryList = ratingCurveService.GetRead().Skip(1).Take(1).OrderBy(c => c.RatingCurveID).ThenBy(c => c.HydrometricSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        Assert.AreEqual(1, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take 2Order

        #region Tests Generated for GetRatingCurveList() Skip Take Order Where
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveID", "RatingCurveID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveDirectQueryList = ratingCurveService.GetRead().Where(c => c.RatingCurveID == 4).Skip(0).Take(1).OrderBy(c => c.RatingCurveID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        Assert.AreEqual(1, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take Order Where

        #region Tests Generated for GetRatingCurveList() Skip Take Order 2Where
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveID", "RatingCurveID,GT,2|RatingCurveID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveDirectQueryList = ratingCurveService.GetRead().Where(c => c.RatingCurveID > 2 && c.RatingCurveID < 5).Skip(0).Take(1).OrderBy(c => c.RatingCurveID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        Assert.AreEqual(1, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take Order 2Where

        #region Tests Generated for GetRatingCurveList() 2Where
        [TestMethod]
        public void GetRatingCurveList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 0, 10000, "", "RatingCurveID,GT,2|RatingCurveID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        ratingCurveDirectQueryList = ratingCurveService.GetRead().Where(c => c.RatingCurveID > 2 && c.RatingCurveID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            Assert.AreEqual(0, ratingCurveList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckRatingCurveFields(ratingCurveList, entityQueryDetailType);
                        Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        Assert.AreEqual(2, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() 2Where

        #region Functions private
        private void CheckRatingCurveFields(List<RatingCurve> ratingCurveList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // RatingCurve fields
            Assert.IsNotNull(ratingCurveList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveList[0].HydrometricSiteID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveNumber));
            Assert.IsNotNull(ratingCurveList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // RatingCurveWeb and RatingCurveReport fields should be null here
                Assert.IsNull(ratingCurveList[0].RatingCurveWeb);
                Assert.IsNull(ratingCurveList[0].RatingCurveReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // RatingCurveWeb fields should not be null and RatingCurveReport fields should be null here
                if (!string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(ratingCurveList[0].RatingCurveReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // RatingCurveWeb and RatingCurveReport fields should NOT be null here
                if (ratingCurveList[0].RatingCurveWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveWeb.LastUpdateContactTVText));
                }
                if (ratingCurveList[0].RatingCurveReport.RatingCurveReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveReport.RatingCurveReportTest));
                }
            }
        }
        private RatingCurve GetFilledRandomRatingCurve(string OmitPropName)
        {
            RatingCurve ratingCurve = new RatingCurve();

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = 1;
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurve.LastUpdateContactTVItemID = 2;

            return ratingCurve;
        }
        #endregion Functions private
    }
}
