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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPResult_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = vpResultService.GetVPResultList().Count();

                    Assert.AreEqual(vpResultService.GetVPResultList().Count(), (from c in dbTestDB.VPResults select c).Take(200).Count());

                    vpResultService.Add(vpResult);
                    if (vpResult.HasErrors)
                    {
                        Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpResultService.GetVPResultList().Where(c => c == vpResult).Any());
                    vpResultService.Update(vpResult);
                    if (vpResult.HasErrors)
                    {
                        Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpResultService.GetVPResultList().Count());
                    vpResultService.Delete(vpResult);
                    if (vpResult.HasErrors)
                    {
                        Assert.AreEqual("", vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPResultVPResultID"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPResultID = 10000000;
                    vpResultService.Update(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPResult", "VPResultVPResultID", vpResult.VPResultID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
                    // vpResult.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.VPScenarioID = 0;
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPResultVPScenarioID", vpResult.VPScenarioID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // vpResult.Ordinal   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Ordinal = -1;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultOrdinal", "0", "1000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Ordinal = 1001;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultOrdinal", "0", "1000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // vpResult.Concentration_MPN_100ml   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Concentration_MPN_100ml = -1;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultConcentration_MPN_100ml", "0", "10000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Concentration_MPN_100ml = 10000001;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultConcentration_MPN_100ml", "0", "10000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultDilution", "0", "1000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.Dilution = 1000001.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultDilution", "0", "1000000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultFarFieldWidth_m", "0", "10000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.FarFieldWidth_m = 10001.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultFarFieldWidth_m", "0", "10000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultDispersionDistance_m", "0", "100000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.DispersionDistance_m = 100001.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultDispersionDistance_m", "0", "100000"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultTravelTime_hour", "0", "100"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.TravelTime_hour = 101.0D;
                    Assert.AreEqual(false, vpResultService.Add(vpResult));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPResultTravelTime_hour", "0", "100"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpResultService.GetVPResultList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpResult.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateDate_UTC = new DateTime();
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPResultLastUpdateDate_UTC"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPResultLastUpdateDate_UTC", "1980"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpResult.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateContactTVItemID = 0;
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPResultLastUpdateContactTVItemID", vpResult.LastUpdateContactTVItemID.ToString()), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpResult = null;
                    vpResult = GetFilledRandomVPResult("");
                    vpResult.LastUpdateContactTVItemID = 1;
                    vpResultService.Add(vpResult);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "VPResultLastUpdateContactTVItemID", "Contact"), vpResult.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPResult vpResult = (from c in dbTestDB.VPResults select c).FirstOrDefault();
                    Assert.IsNotNull(vpResult);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        vpResultService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            VPResult vpResultRet = vpResultService.GetVPResultWithVPResultID(vpResult.VPResultID);
                            CheckVPResultFields(new List<VPResult>() { vpResultRet });
                            Assert.AreEqual(vpResult.VPResultID, vpResultRet.VPResultID);
                        }
                        else if (detail == "A")
                        {
                            VPResult_A vpResult_ARet = vpResultService.GetVPResult_AWithVPResultID(vpResult.VPResultID);
                            CheckVPResult_AFields(new List<VPResult_A>() { vpResult_ARet });
                            Assert.AreEqual(vpResult.VPResultID, vpResult_ARet.VPResultID);
                        }
                        else if (detail == "B")
                        {
                            VPResult_B vpResult_BRet = vpResultService.GetVPResult_BWithVPResultID(vpResult.VPResultID);
                            CheckVPResult_BFields(new List<VPResult_B>() { vpResult_BRet });
                            Assert.AreEqual(vpResult.VPResultID, vpResult_BRet.VPResultID);
                        }
                        else
                        {
                            // nothing for now
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
                    VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPResult vpResult = (from c in dbTestDB.VPResults select c).FirstOrDefault();
                    Assert.IsNotNull(vpResult);

                    List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                    vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        vpResultService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
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
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                        vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResultList[0].VPResultID);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_AList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_BList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() Skip Take

        #region Tests Generated for GetVPResultList() Skip Take Order
        [TestMethod]
        public void GetVPResultList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), culture.TwoLetterISOLanguageName, 1, 1,  "VPResultID", "");

                        List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                        vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Skip(1).Take(1).OrderBy(c => c.VPResultID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResultList[0].VPResultID);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_AList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_BList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() Skip Take Order

        #region Tests Generated for GetVPResultList() Skip Take 2Order
        [TestMethod]
        public void GetVPResultList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), culture.TwoLetterISOLanguageName, 1, 1, "VPResultID,VPScenarioID", "");

                        List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                        vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Skip(1).Take(1).OrderBy(c => c.VPResultID).ThenBy(c => c.VPScenarioID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResultList[0].VPResultID);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_AList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_BList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() Skip Take 2Order

        #region Tests Generated for GetVPResultList() Skip Take Order Where
        [TestMethod]
        public void GetVPResultList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), culture.TwoLetterISOLanguageName, 0, 1, "VPResultID", "VPResultID,EQ,4", "");

                        List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                        vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Where(c => c.VPResultID == 4).Skip(0).Take(1).OrderBy(c => c.VPResultID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResultList[0].VPResultID);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_AList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_BList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() Skip Take Order Where

        #region Tests Generated for GetVPResultList() Skip Take Order 2Where
        [TestMethod]
        public void GetVPResultList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), culture.TwoLetterISOLanguageName, 0, 1, "VPResultID", "VPResultID,GT,2|VPResultID,LT,5", "");

                        List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                        vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Where(c => c.VPResultID > 2 && c.VPResultID < 5).Skip(0).Take(1).OrderBy(c => c.VPResultID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResultList[0].VPResultID);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_AList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_BList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() Skip Take Order 2Where

        #region Tests Generated for GetVPResultList() 2Where
        [TestMethod]
        public void GetVPResultList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        VPResultService vpResultService = new VPResultService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpResultService.Query = vpResultService.FillQuery(typeof(VPResult), culture.TwoLetterISOLanguageName, 0, 10000, "", "VPResultID,GT,2|VPResultID,LT,5", "");

                        List<VPResult> vpResultDirectQueryList = new List<VPResult>();
                        vpResultDirectQueryList = (from c in dbTestDB.VPResults select c).Where(c => c.VPResultID > 2 && c.VPResultID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<VPResult> vpResultList = new List<VPResult>();
                            vpResultList = vpResultService.GetVPResultList().ToList();
                            CheckVPResultFields(vpResultList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResultList[0].VPResultID);
                        }
                        else if (detail == "A")
                        {
                            List<VPResult_A> vpResult_AList = new List<VPResult_A>();
                            vpResult_AList = vpResultService.GetVPResult_AList().ToList();
                            CheckVPResult_AFields(vpResult_AList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_AList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<VPResult_B> vpResult_BList = new List<VPResult_B>();
                            vpResult_BList = vpResultService.GetVPResult_BList().ToList();
                            CheckVPResult_BFields(vpResult_BList);
                            Assert.AreEqual(vpResultDirectQueryList[0].VPResultID, vpResult_BList[0].VPResultID);
                            Assert.AreEqual(vpResultDirectQueryList.Count, vpResult_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPResultList() 2Where

        #region Functions private
        private void CheckVPResultFields(List<VPResult> vpResultList)
        {
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
            Assert.IsNotNull(vpResultList[0].HasErrors);
        }
        private void CheckVPResult_AFields(List<VPResult_A> vpResult_AList)
        {
            Assert.IsNotNull(vpResult_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(vpResult_AList[0].VPResultID);
            Assert.IsNotNull(vpResult_AList[0].VPScenarioID);
            Assert.IsNotNull(vpResult_AList[0].Ordinal);
            Assert.IsNotNull(vpResult_AList[0].Concentration_MPN_100ml);
            Assert.IsNotNull(vpResult_AList[0].Dilution);
            Assert.IsNotNull(vpResult_AList[0].FarFieldWidth_m);
            Assert.IsNotNull(vpResult_AList[0].DispersionDistance_m);
            Assert.IsNotNull(vpResult_AList[0].TravelTime_hour);
            Assert.IsNotNull(vpResult_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpResult_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpResult_AList[0].HasErrors);
        }
        private void CheckVPResult_BFields(List<VPResult_B> vpResult_BList)
        {
            if (!string.IsNullOrWhiteSpace(vpResult_BList[0].VPResultReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpResult_BList[0].VPResultReportTest));
            }
            Assert.IsNotNull(vpResult_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(vpResult_BList[0].VPResultID);
            Assert.IsNotNull(vpResult_BList[0].VPScenarioID);
            Assert.IsNotNull(vpResult_BList[0].Ordinal);
            Assert.IsNotNull(vpResult_BList[0].Concentration_MPN_100ml);
            Assert.IsNotNull(vpResult_BList[0].Dilution);
            Assert.IsNotNull(vpResult_BList[0].FarFieldWidth_m);
            Assert.IsNotNull(vpResult_BList[0].DispersionDistance_m);
            Assert.IsNotNull(vpResult_BList[0].TravelTime_hour);
            Assert.IsNotNull(vpResult_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpResult_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpResult_BList[0].HasErrors);
        }
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
    }
}
