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
    public partial class VPResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPResultService vpResultService { get; set; }
        #endregion Properties

        #region Constructors
        public VPResultServiceTest() : base()
        {
            //vpResultService = new VPResultService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private VPResult GetFilledRandomVPResult(string OmitPropName)
        {
            VPResult vpResult = new VPResult();

            if (OmitPropName != "VPScenarioID") vpResult.VPScenarioID = 1;
            if (OmitPropName != "Ordinal") vpResult.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "Concentration_MPN_100ml") vpResult.Concentration_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Dilution") vpResult.Dilution = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "FarFieldWidth_m") vpResult.FarFieldWidth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "DispersionDistance_m") vpResult.DispersionDistance_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "TravelTime_hour") vpResult.TravelTime_hour = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") vpResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpResult.LastUpdateContactTVItemID = 2;

            return vpResult;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPResult_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPResultService vpResultService = new VPResultService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    VPResult vpResult = GetFilledRandomVPResult("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = vpResultService.GetRead().Count();

                    Assert.AreEqual(vpResultService.GetRead().Count(), vpResultService.GetEdit().Count());

                    vpResultService.Add(vpResult);
                    if (vpResult.HasErrors)
                    {
                        Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpResultService.GetRead().Where(c => c == vpResult).Any());
                    vpResultService.Update(vpResult);
                    if (vpResult.HasErrors)
                    {
                        Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpResultService.GetRead().Count());
                    vpResultService.Delete(vpResult);
                    if (vpResult.HasErrors)
                    {
                        Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // vpResult.VPResultID   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultID = 0;
                    vpResultService.Update(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPResultVPResultID), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultID = 10000000;
                    vpResultService.Update(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPResult, CSSPModelsRes.VPResultVPResultID, vpResult.VPResultID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = Error)]
                    // vpResult.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPScenarioID = 0;
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPResultVPScenarioID, vpResult.VPScenarioID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // vpResult.Ordinal   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Ordinal = -1;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultOrdinal, "0", "1000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Ordinal = 1001;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultOrdinal, "0", "1000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // vpResult.Concentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Concentration_MPN_100ml = -1;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Concentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // vpResult.Dilution   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Dilution]

                    //Error: Type not implemented [Dilution]

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Dilution = -1.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultDilution, "0", "1000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Dilution = 1000001.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultDilution, "0", "1000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // vpResult.FarFieldWidth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [FarFieldWidth_m]

                    //Error: Type not implemented [FarFieldWidth_m]

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.FarFieldWidth_m = -1.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultFarFieldWidth_m, "0", "10000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.FarFieldWidth_m = 10001.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultFarFieldWidth_m, "0", "10000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000)]
                    // vpResult.DispersionDistance_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [DispersionDistance_m]

                    //Error: Type not implemented [DispersionDistance_m]

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.DispersionDistance_m = -1.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultDispersionDistance_m, "0", "100000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.DispersionDistance_m = 100001.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultDispersionDistance_m, "0", "100000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // vpResult.TravelTime_hour   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [TravelTime_hour]

                    //Error: Type not implemented [TravelTime_hour]

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.TravelTime_hour = -1.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultTravelTime_hour, "0", "100"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.TravelTime_hour = 101.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultTravelTime_hour, "0", "100"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpResult.VPResultWeb   (VPResultWeb)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultWeb = null;
                    Assert.IsNull(vpResult.VPResultWeb);

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultWeb = new VPResultWeb();
                    Assert.IsNotNull(vpResult.VPResultWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpResult.VPResultReport   (VPResultReport)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultReport = null;
                    Assert.IsNull(vpResult.VPResultReport);

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultReport = new VPResultReport();
                    Assert.IsNotNull(vpResult.VPResultReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpResult.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateDate_UTC = new DateTime();
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPResultLastUpdateDate_UTC), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPResultLastUpdateDate_UTC, "1980"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpResult.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateContactTVItemID = 0;
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPResultLastUpdateContactTVItemID, vpResult.LastUpdateContactTVItemID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateContactTVItemID = 1;
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPResultLastUpdateContactTVItemID, "Contact"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpResult.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpResult.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetVPResultWithVPResultID(vpResult.VPResultID)
        [TestMethod]
        public void GetVPResultWithVPResultID__vpResult_VPResultID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPResultService vpResultService = new VPResultService(new GetParam(), dbTestDB, ContactID);
                    VPResult vpResult = (from c in vpResultService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpResult);

                    VPResult vpResultRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpResultService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpResultRet = vpResultService.GetVPResultWithVPResultID(vpResult.VPResultID);
                            Assert.IsNull(vpResultRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpResultRet = vpResultService.GetVPResultWithVPResultID(vpResult.VPResultID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpResultRet = vpResultService.GetVPResultWithVPResultID(vpResult.VPResultID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpResultRet = vpResultService.GetVPResultWithVPResultID(vpResult.VPResultID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // VPResult fields
                        Assert.IsNotNull(vpResultRet.VPResultID);
                        Assert.IsNotNull(vpResultRet.VPScenarioID);
                        Assert.IsNotNull(vpResultRet.Ordinal);
                        Assert.IsNotNull(vpResultRet.Concentration_MPN_100ml);
                        Assert.IsNotNull(vpResultRet.Dilution);
                        Assert.IsNotNull(vpResultRet.FarFieldWidth_m);
                        Assert.IsNotNull(vpResultRet.DispersionDistance_m);
                        Assert.IsNotNull(vpResultRet.TravelTime_hour);
                        Assert.IsNotNull(vpResultRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(vpResultRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // VPResultWeb and VPResultReport fields should be null here
                            Assert.IsNull(vpResultRet.VPResultWeb);
                            Assert.IsNull(vpResultRet.VPResultReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // VPResultWeb fields should not be null and VPResultReport fields should be null here
                            if (vpResultRet.VPResultWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultRet.VPResultWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(vpResultRet.VPResultReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // VPResultWeb and VPResultReport fields should NOT be null here
                            if (vpResultRet.VPResultWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultRet.VPResultWeb.LastUpdateContactTVText));
                            }
                            if (vpResultRet.VPResultReport.VPResultReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultRet.VPResultReport.VPResultReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultWithVPResultID(vpResult.VPResultID)

        #region Tests Generated for GetVPResultList()
        [TestMethod]
        public void GetVPResultList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPResultService vpResultService = new VPResultService(new GetParam(), dbTestDB, ContactID);
                    VPResult vpResult = (from c in vpResultService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpResult);

                    List<VPResult> vpResultList = new List<VPResult>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpResultService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            Assert.AreEqual(0, vpResultList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // VPResult fields
                        Assert.IsNotNull(vpResultList[0].VPResultID);
                        Assert.IsNotNull(vpResultList[0].VPScenarioID);
                        Assert.IsNotNull(vpResultList[0].Ordinal);
                        Assert.IsNotNull(vpResultList[0].Concentration_MPN_100ml);
                        Assert.IsNotNull(vpResultList[0].Dilution);
                        Assert.IsNotNull(vpResultList[0].FarFieldWidth_m);
                        Assert.IsNotNull(vpResultList[0].DispersionDistance_m);
                        Assert.IsNotNull(vpResultList[0].TravelTime_hour);
                        Assert.IsNotNull(vpResultList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(vpResultList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // VPResultWeb and VPResultReport fields should be null here
                            Assert.IsNull(vpResultList[0].VPResultWeb);
                            Assert.IsNull(vpResultList[0].VPResultReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // VPResultWeb fields should not be null and VPResultReport fields should be null here
                            if (vpResultList[0].VPResultWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultList[0].VPResultWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(vpResultList[0].VPResultReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // VPResultWeb and VPResultReport fields should NOT be null here
                            if (vpResultList[0].VPResultWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultList[0].VPResultWeb.LastUpdateContactTVText));
                            }
                            if (vpResultList[0].VPResultReport.VPResultReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResultList[0].VPResultReport.VPResultReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList()

        #region Tests Generated for GetVPResultList() Skip Take
        [TestMethod]
        public void GetVPResultList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<VPResult> vpResultList = new List<VPResult>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(VPResult), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        VPResultService vpResultService = new VPResultService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            Assert.AreEqual(0, vpResultList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpResultList = vpResultService.GetVPResultList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, vpResultList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() Skip Take

    }
}
