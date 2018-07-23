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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanSubsectorSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new GetParam(), dbTestDB, ContactID);

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
                    // [CSSPExist(ExistTypeName = "SamplingPlanSubsector", ExistPlurial = "s", ExistFieldID = "SamplingPlanSubsectorID", AllowableTVtypeList = Error)]
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
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new GetParam(), dbTestDB, ContactID);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in samplingPlanSubsectorSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsectorSite);

                    SamplingPlanSubsectorSite samplingPlanSubsectorSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorSiteService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
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
                        // SamplingPlanSubsectorSite fields
                        Assert.IsNotNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteID);
                        Assert.IsNotNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorID);
                        Assert.IsNotNull(samplingPlanSubsectorSiteRet.MWQMSiteTVItemID);
                        Assert.IsNotNull(samplingPlanSubsectorSiteRet.IsDuplicate);
                        Assert.IsNotNull(samplingPlanSubsectorSiteRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(samplingPlanSubsectorSiteRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // SamplingPlanSubsectorSiteWeb and SamplingPlanSubsectorSiteReport fields should be null here
                            Assert.IsNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb);
                            Assert.IsNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // SamplingPlanSubsectorSiteWeb fields should not be null and SamplingPlanSubsectorSiteReport fields should be null here
                            if (samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.MWQMSiteTVText));
                            }
                            if (samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // SamplingPlanSubsectorSiteWeb and SamplingPlanSubsectorSiteReport fields should NOT be null here
                            if (samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.MWQMSiteTVText));
                            }
                            if (samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText));
                            }
                            if (samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteReport.SamplingPlanSubsectorSiteReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteRet.SamplingPlanSubsectorSiteReport.SamplingPlanSubsectorSiteReportTest));
                            }
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
                    SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(new GetParam(), dbTestDB, ContactID);
                    SamplingPlanSubsectorSite samplingPlanSubsectorSite = (from c in samplingPlanSubsectorSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsectorSite);

                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorSiteService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
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
                            if (samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.MWQMSiteTVText));
                            }
                            if (samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // SamplingPlanSubsectorSiteWeb and SamplingPlanSubsectorSiteReport fields should NOT be null here
                            if (samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.MWQMSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.MWQMSiteTVText));
                            }
                            if (samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteWeb.LastUpdateContactTVText));
                            }
                            if (samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport.SamplingPlanSubsectorSiteReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorSiteList[0].SamplingPlanSubsectorSiteReport.SamplingPlanSubsectorSiteReportTest));
                            }
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
                    List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = new List<SamplingPlanSubsectorSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(SamplingPlanSubsectorSite), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        SamplingPlanSubsectorSiteService samplingPlanSubsectorSiteService = new SamplingPlanSubsectorSiteService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
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

                        Assert.AreEqual(getParam.Take, samplingPlanSubsectorSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorSiteList() Skip Take

    }
}
