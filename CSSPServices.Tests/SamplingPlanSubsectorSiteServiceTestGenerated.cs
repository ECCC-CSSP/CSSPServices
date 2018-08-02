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
    public partial class SamplingPlanSubsectorSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteServiceTest() : base()
        {
            //samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanSubsectorSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = samplingPlanSubsectorSiteService.GetRead().Count();

                    Assert.AreEqual(samplingPlanSubsectorSiteService.GetRead().Count(), samplingPlanSubsectorSiteService.GetEdit().Count());

                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    if (samplingPlanSubsectorSite.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanSubsectorSiteService.GetRead().Where(c => c == samplingPlanSubsectorSite).Any());
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    if (samplingPlanSubsectorSite.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanSubsectorSiteService.GetRead().Count());
                    samplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite);
                    if (samplingPlanSubsectorSite.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, samplingPlanSubsectorSiteService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 0;
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 10000000;
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsectorSite, CSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID, samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID", AllowableTVtypeList = )]
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsector, CSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "MWQMSite"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteWeb   (SamplingPlanSubsectorSiteWeb)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteWeb = null;
                    Assert.IsNull(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteWeb);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteWeb = new SamplingPlanSubsectorSiteWeb();
                    Assert.IsNotNull(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorSiteReport   (SamplingPlanSubsectorSiteReport)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteReport = null;
                    Assert.IsNull(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteReport);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteReport = new SamplingPlanSubsectorSiteReport();
                    Assert.IsNotNull(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime();
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC, "1980"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "Contact"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsectorSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsectorSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID)
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID__samplingPlanSubsectorSite_SamplingPlanSubsectorSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in samplingPlanSubsectorSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsectorSite);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                            Assert.IsNull(samplingPlanSubsectorSiteRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(new List<SamplingPlanSubsectorSite>() { samplingPlanSubsectorSiteRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID)

        #region Tests Generated for GetSamplingPlanSubsectorSiteList()
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in samplingPlanSubsectorSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsectorSite);

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList()

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual(1, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Order
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanSubsectorSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual(1, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Order

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take 2Order
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanSubsectorSiteID,SamplingPlanSubsectorID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ThenBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual(1, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take 2Order

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Order Where
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "SamplingPlanSubsectorSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Where(c => c.SamplingPlanSubsectorSiteID == 4).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual(1, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Order Where

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Order 2Where
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual(1, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take Order 2Where

        #region Tests Generated for GetSamplingPlanSubsectorSiteList() 2Where
        [TestMethod]
        public void GetSamplingPlanSubsectorSiteList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                        Assert.AreEqual(2, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() 2Where

        #region Functions private
        private void CheckSamplingPlanSubsectorSiteFields(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // SamplingPlanSubsectorSite fields
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].IsDuplicate);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // SamplingPlanSubsectorSiteWeb and SamplingPlanSubsectorSiteReport fields should be null here
                Assert.IsNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb);
                Assert.IsNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // SamplingPlanSubsectorSiteWeb fields should not be null and SamplingPlanSubsectorSiteReport fields should be null here
                Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.MWQMSiteTVItemLanguage);
                Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.LastUpdateContactTVItemLanguage);
                Assert.IsNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // SamplingPlanSubsectorSiteWeb and SamplingPlanSubsectorSiteReport fields should NOT be null here
                Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.MWQMSiteTVItemLanguage);
                Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.LastUpdateContactTVItemLanguage);
                if (samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport.SamplingPlanSubsectorSiteReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport.SamplingPlanSubsectorSiteReportTest));
                }
            }
        }
        private SamplingPlanSubsectorSite GetFilledRandomSamplingPlanSubsectorSite(string OmitPropName)
        {
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();

            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            if (OmitPropName != "MWQMSiteTVItemID") samplingPlanSubsectorSite.MWQMSiteTVItemID = 40;
            if (OmitPropName != "IsDuplicate") samplingPlanSubsectorSite.IsDuplicate = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;

            return samplingPlanSubsectorSite;
        }
        #endregion Functions private
    }
}
