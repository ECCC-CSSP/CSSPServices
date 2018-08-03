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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 10000000;
                    samplingPlanSubsectorSiteService.Update(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID", samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID", AllowableTVtypeList = )]
                    // samplingPlanSubsectorSite.SamplingPlanSubsectorID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorSiteSamplingPlanSubsectorID", samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // samplingPlanSubsectorSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.MWQMSiteTVItemID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorSiteMWQMSiteTVItemID", samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.MWQMSiteTVItemID = 1;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorSiteMWQMSiteTVItemID", "MWQMSite"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // samplingPlanSubsectorSite.IsDuplicate   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanSubsectorSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime();
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSiteLastUpdateDate_UTC"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanSubsectorSiteLastUpdateDate_UTC", "1980"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanSubsectorSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateContactTVItemID = 0;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorSiteLastUpdateContactTVItemID", samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsectorSite = null;
                    samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");
                    samplingPlanSubsectorSite.LastUpdateContactTVItemID = 1;
                    samplingPlanSubsectorSiteService.Add(samplingPlanSubsectorSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorSiteLastUpdateContactTVItemID", "Contact"), samplingPlanSubsectorSite.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                            CheckSamplingPlanSubsectorSiteFields(new List<SamplingPlanSubsectorSite>() { samplingPlanSubsectorSiteRet });
                            Assert.AreEqual(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            SamplingPlanSubsectorSiteWeb samplingPlanSubsectorSiteWebRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                            CheckSamplingPlanSubsectorSiteWebFields(new List<SamplingPlanSubsectorSiteWeb>() { samplingPlanSubsectorSiteWebRet });
                            Assert.AreEqual(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebRet.SamplingPlanSubsectorSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            SamplingPlanSubsectorSiteReport samplingPlanSubsectorSiteReportRet = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportWithSamplingPlanSubsectorSiteID(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
                            CheckSamplingPlanSubsectorSiteReportFields(new List<SamplingPlanSubsectorSiteReport>() { samplingPlanSubsectorSiteReportRet });
                            Assert.AreEqual(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportRet.SamplingPlanSubsectorSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                    samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorSiteService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanSubsectorSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanSubsectorSiteID,SamplingPlanSubsectorID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ThenBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "SamplingPlanSubsectorSiteID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Where(c => c.SamplingPlanSubsectorSiteID == 4).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorSiteID", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorSiteService.Query = samplingPlanSubsectorSiteService.FillQuery(typeof(SamplingPlanSubsectorSite), culture.TwoLetterISOLanguageName, 0, 10000, "", "SamplingPlanSubsectorSiteID,GT,2|SamplingPlanSubsectorSiteID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteDirectQueryList = new List<SamplingPlanSubsectorSite>();
                        samplingPlanSubsectorSiteDirectQueryList = samplingPlanSubsectorSiteService.GetRead().Where(c => c.SamplingPlanSubsectorSiteID > 2 && c.SamplingPlanSubsectorSiteID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                            samplingPlanSubsectorSiteList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList().ToList();
                            CheckSamplingPlanSubsectorSiteFields(samplingPlanSubsectorSiteList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList = new List<SamplingPlanSubsectorSiteWeb>();
                            samplingPlanSubsectorSiteWebList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteWebList().ToList();
                            CheckSamplingPlanSubsectorSiteWebFields(samplingPlanSubsectorSiteWebList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList = new List<SamplingPlanSubsectorSiteReport>();
                            samplingPlanSubsectorSiteReportList = samplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteReportList().ToList();
                            CheckSamplingPlanSubsectorSiteReportFields(samplingPlanSubsectorSiteReportList);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList[0].SamplingPlanSubsectorSiteID, samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
                            Assert.AreEqual(samplingPlanSubsectorSiteDirectQueryList.Count, samplingPlanSubsectorSiteReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() 2Where

        #region Functions private
        private void CheckSamplingPlanSubsectorSiteFields(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].IsDuplicate);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteList[0].HasErrors);
        }
        private void CheckSamplingPlanSubsectorSiteWebFields(List<SamplingPlanSubsectorSiteWeb> samplingPlanSubsectorSiteWebList)
        {
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorSiteID);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].IsDuplicate);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteWebList[0].HasErrors);
        }
        private void CheckSamplingPlanSubsectorSiteReportFields(List<SamplingPlanSubsectorSiteReport> samplingPlanSubsectorSiteReportList)
        {
            if (!string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteReportTest));
            }
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].MWQMSiteTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorSiteID);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].MWQMSiteTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].IsDuplicate);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorSiteReportList[0].HasErrors);
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
