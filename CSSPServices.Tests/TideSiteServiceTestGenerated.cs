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
    public partial class TideSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideSiteService tideSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteServiceTest() : base()
        {
            //tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 34;
            if (OmitPropName != "WebTideModel") tideSite.WebTideModel = GetRandomString("", 5);
            if (OmitPropName != "WebTideDatum_m") tideSite.WebTideDatum_m = GetRandomDouble(-100.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            return tideSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideSite tideSite = GetFilledRandomTideSite("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tideSiteService.GetRead().Count();

                    Assert.AreEqual(tideSiteService.GetRead().Count(), tideSiteService.GetEdit().Count());

                    tideSiteService.Add(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tideSiteService.GetRead().Where(c => c == tideSite).Any());
                    tideSiteService.Update(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tideSiteService.GetRead().Count());
                    tideSiteService.Delete(tideSite);
                    if (tideSite.HasErrors)
                    {
                        Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideSite.TideSiteID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 0;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteTideSiteID), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteID = 10000000;
                    tideSiteService.Update(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideSite, CSSPModelsRes.TideSiteTideSiteID, tideSite.TideSiteID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
                    // tideSite.TideSiteTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideSiteTideSiteTVItemID, tideSite.TideSiteTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideSiteTideSiteTVItemID, "TideSite"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // tideSite.WebTideModel   (String)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("WebTideModel");
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(1, tideSite.ValidationResults.Count());
                    Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteWebTideModel)).Any());
                    Assert.AreEqual(null, tideSite.WebTideModel);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideModel = GetRandomString("", 101);
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideSiteWebTideModel, "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(-100, 100)]
                    // tideSite.WebTideDatum_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [WebTideDatum_m]

                    //Error: Type not implemented [WebTideDatum_m]

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideDatum_m = -101.0D;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideSiteWebTideDatum_m, "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.WebTideDatum_m = 101.0D;
                    Assert.AreEqual(false, tideSiteService.Add(tideSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideSiteWebTideDatum_m, "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideSite.TideSiteWeb   (TideSiteWeb)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteWeb = null;
                    Assert.IsNull(tideSite.TideSiteWeb);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteWeb = new TideSiteWeb();
                    Assert.IsNotNull(tideSite.TideSiteWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tideSite.TideSiteReport   (TideSiteReport)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteReport = null;
                    Assert.IsNull(tideSite.TideSiteReport);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.TideSiteReport = new TideSiteReport();
                    Assert.IsNotNull(tideSite.TideSiteReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateDate_UTC = new DateTime();
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideSiteLastUpdateDate_UTC), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TideSiteLastUpdateDate_UTC, "1980"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 0;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideSiteLastUpdateContactTVItemID, tideSite.LastUpdateContactTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideSite = null;
                    tideSite = GetFilledRandomTideSite("");
                    tideSite.LastUpdateContactTVItemID = 1;
                    tideSiteService.Add(tideSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideSiteLastUpdateContactTVItemID, "Contact"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideSite.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTideSiteWithTideSiteID(tideSite.TideSiteID)
        [TestMethod]
        public void GetTideSiteWithTideSiteID__tideSite_TideSiteID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new GetParam(), dbTestDB, ContactID);
                    TideSite tideSite = (from c in tideSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    TideSite tideSiteRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideSiteService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                            Assert.IsNull(tideSiteRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideSiteRet = tideSiteService.GetTideSiteWithTideSiteID(tideSite.TideSiteID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // TideSite fields
                        Assert.IsNotNull(tideSiteRet.TideSiteID);
                        Assert.IsNotNull(tideSiteRet.TideSiteTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.WebTideModel));
                        Assert.IsNotNull(tideSiteRet.WebTideDatum_m);
                        Assert.IsNotNull(tideSiteRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tideSiteRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TideSiteWeb and TideSiteReport fields should be null here
                            Assert.IsNull(tideSiteRet.TideSiteWeb);
                            Assert.IsNull(tideSiteRet.TideSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TideSiteWeb fields should not be null and TideSiteReport fields should be null here
                            if (tideSiteRet.TideSiteWeb.TideSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.TideSiteWeb.TideSiteTVText));
                            }
                            if (tideSiteRet.TideSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.TideSiteWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(tideSiteRet.TideSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TideSiteWeb and TideSiteReport fields should NOT be null here
                            if (tideSiteRet.TideSiteWeb.TideSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.TideSiteWeb.TideSiteTVText));
                            }
                            if (tideSiteRet.TideSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.TideSiteWeb.LastUpdateContactTVText));
                            }
                            if (tideSiteRet.TideSiteReport.TideSiteReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteRet.TideSiteReport.TideSiteReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteWithTideSiteID(tideSite.TideSiteID)

        #region Tests Generated for GetTideSiteList()
        [TestMethod]
        public void GetTideSiteList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideSiteService tideSiteService = new TideSiteService(new GetParam(), dbTestDB, ContactID);
                    TideSite tideSite = (from c in tideSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideSite);

                    List<TideSite> tideSiteList = new List<TideSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tideSiteService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            Assert.AreEqual(0, tideSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // TideSite fields
                        Assert.IsNotNull(tideSiteList[0].TideSiteID);
                        Assert.IsNotNull(tideSiteList[0].TideSiteTVItemID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].WebTideModel));
                        Assert.IsNotNull(tideSiteList[0].WebTideDatum_m);
                        Assert.IsNotNull(tideSiteList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(tideSiteList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // TideSiteWeb and TideSiteReport fields should be null here
                            Assert.IsNull(tideSiteList[0].TideSiteWeb);
                            Assert.IsNull(tideSiteList[0].TideSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // TideSiteWeb fields should not be null and TideSiteReport fields should be null here
                            if (tideSiteList[0].TideSiteWeb.TideSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteWeb.TideSiteTVText));
                            }
                            if (tideSiteList[0].TideSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(tideSiteList[0].TideSiteReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // TideSiteWeb and TideSiteReport fields should NOT be null here
                            if (tideSiteList[0].TideSiteWeb.TideSiteTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteWeb.TideSiteTVText));
                            }
                            if (tideSiteList[0].TideSiteWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteWeb.LastUpdateContactTVText));
                            }
                            if (tideSiteList[0].TideSiteReport.TideSiteReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteReport.TideSiteReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList()

        #region Tests Generated for GetTideSiteList() Skip Take
        [TestMethod]
        public void GetTideSiteList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<TideSite> tideSiteList = new List<TideSite>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(TideSite), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        TideSiteService tideSiteService = new TideSiteService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                            Assert.AreEqual(0, tideSiteList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tideSiteList = tideSiteService.GetTideSiteList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, tideSiteList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTideSiteList() Skip Take

    }
}
