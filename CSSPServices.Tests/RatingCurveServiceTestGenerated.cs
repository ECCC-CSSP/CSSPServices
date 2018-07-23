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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurve_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new GetParam(), dbTestDB, ContactID);

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
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = Error)]
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
                    RatingCurveService ratingCurveService = new RatingCurveService(new GetParam(), dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in ratingCurveService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    RatingCurve ratingCurveRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ratingCurveService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
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
                        // RatingCurve fields
                        Assert.IsNotNull(ratingCurveRet.RatingCurveID);
                        Assert.IsNotNull(ratingCurveRet.HydrometricSiteID);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveRet.RatingCurveNumber));
                        Assert.IsNotNull(ratingCurveRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(ratingCurveRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // RatingCurveWeb and RatingCurveReport fields should be null here
                            Assert.IsNull(ratingCurveRet.RatingCurveWeb);
                            Assert.IsNull(ratingCurveRet.RatingCurveReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // RatingCurveWeb fields should not be null and RatingCurveReport fields should be null here
                            if (ratingCurveRet.RatingCurveWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveRet.RatingCurveWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(ratingCurveRet.RatingCurveReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // RatingCurveWeb and RatingCurveReport fields should NOT be null here
                            if (ratingCurveRet.RatingCurveWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveRet.RatingCurveWeb.LastUpdateContactTVText));
                            }
                            if (ratingCurveRet.RatingCurveReport.RatingCurveReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveRet.RatingCurveReport.RatingCurveReportTest));
                            }
                        }
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
                    RatingCurveService ratingCurveService = new RatingCurveService(new GetParam(), dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in ratingCurveService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        ratingCurveService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
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
                            if (ratingCurveList[0].RatingCurveWeb.LastUpdateContactTVText != null)
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
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(RatingCurve), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        RatingCurveService ratingCurveService = new RatingCurveService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
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

                        Assert.AreEqual(getParam.Take, ratingCurveList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take

    }
}
