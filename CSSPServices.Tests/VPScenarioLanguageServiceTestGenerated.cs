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
    public partial class VPScenarioLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VPScenarioLanguageService vpScenarioLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageServiceTest() : base()
        {
            //vpScenarioLanguageService = new VPScenarioLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void VPScenarioLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    VPScenarioLanguage vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = vpScenarioLanguageService.GetRead().Count();

                    Assert.AreEqual(vpScenarioLanguageService.GetRead().Count(), vpScenarioLanguageService.GetEdit().Count());

                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, vpScenarioLanguageService.GetRead().Where(c => c == vpScenarioLanguage).Any());
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, vpScenarioLanguageService.GetRead().Count());
                    vpScenarioLanguageService.Delete(vpScenarioLanguage);
                    if (vpScenarioLanguage.HasErrors)
                    {
                        Assert.AreEqual("", vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // vpScenarioLanguage.VPScenarioLanguageID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 0;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageVPScenarioLanguageID"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 10000000;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenarioLanguage", "VPScenarioLanguageVPScenarioLanguageID", vpScenarioLanguage.VPScenarioLanguageID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
                    // vpScenarioLanguage.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioLanguageVPScenarioID", vpScenarioLanguage.VPScenarioID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.Language = (LanguageEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageLanguage"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // vpScenarioLanguage.VPScenarioName   (String)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
                    Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageVPScenarioName")).Any());
                    Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioName = GetRandomString("", 101);
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "VPScenarioLanguageVPScenarioName", "100"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageTranslationStatus"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpScenarioLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime();
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLanguageLastUpdateDate_UTC"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPScenarioLanguageLastUpdateDate_UTC", "1980"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpScenarioLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPScenarioLanguageLastUpdateContactTVItemID", vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 1;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "VPScenarioLanguageLastUpdateContactTVItemID", "Contact"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID)
        [TestMethod]
        public void GetVPScenarioLanguageWithVPScenarioLanguageID__vpScenarioLanguage_VPScenarioLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenarioLanguage vpScenarioLanguage = (from c in vpScenarioLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenarioLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpScenarioLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            VPScenarioLanguage vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                            CheckVPScenarioLanguageFields(new List<VPScenarioLanguage>() { vpScenarioLanguageRet });
                            Assert.AreEqual(vpScenarioLanguage.VPScenarioLanguageID, vpScenarioLanguageRet.VPScenarioLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            VPScenarioLanguageWeb vpScenarioLanguageWebRet = vpScenarioLanguageService.GetVPScenarioLanguageWebWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                            CheckVPScenarioLanguageWebFields(new List<VPScenarioLanguageWeb>() { vpScenarioLanguageWebRet });
                            Assert.AreEqual(vpScenarioLanguage.VPScenarioLanguageID, vpScenarioLanguageWebRet.VPScenarioLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            VPScenarioLanguageReport vpScenarioLanguageReportRet = vpScenarioLanguageService.GetVPScenarioLanguageReportWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                            CheckVPScenarioLanguageReportFields(new List<VPScenarioLanguageReport>() { vpScenarioLanguageReportRet });
                            Assert.AreEqual(vpScenarioLanguage.VPScenarioLanguageID, vpScenarioLanguageReportRet.VPScenarioLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID)

        #region Tests Generated for GetVPScenarioLanguageList()
        [TestMethod]
        public void GetVPScenarioLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    VPScenarioLanguage vpScenarioLanguage = (from c in vpScenarioLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(vpScenarioLanguage);

                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpScenarioLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList()

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageWebList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageReportList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Order
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "VPScenarioLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageWebList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageReportList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Order

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "VPScenarioLanguageID,VPScenarioID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.VPScenarioLanguageID).ThenBy(c => c.VPScenarioID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageWebList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageReportList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take 2Order

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "VPScenarioLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Where(c => c.VPScenarioLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageWebList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageReportList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Order Where

        #region Tests Generated for GetVPScenarioLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetVPScenarioLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageWebList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageReportList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetVPScenarioLanguageList() 2Where
        [TestMethod]
        public void GetVPScenarioLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            CheckVPScenarioLanguageFields(vpScenarioLanguageList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<VPScenarioLanguageWeb> vpScenarioLanguageWebList = new List<VPScenarioLanguageWeb>();
                            vpScenarioLanguageWebList = vpScenarioLanguageService.GetVPScenarioLanguageWebList().ToList();
                            CheckVPScenarioLanguageWebFields(vpScenarioLanguageWebList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageWebList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<VPScenarioLanguageReport> vpScenarioLanguageReportList = new List<VPScenarioLanguageReport>();
                            vpScenarioLanguageReportList = vpScenarioLanguageService.GetVPScenarioLanguageReportList().ToList();
                            CheckVPScenarioLanguageReportFields(vpScenarioLanguageReportList);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageReportList[0].VPScenarioLanguageID);
                            Assert.AreEqual(vpScenarioLanguageDirectQueryList.Count, vpScenarioLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() 2Where

        #region Functions private
        private void CheckVPScenarioLanguageFields(List<VPScenarioLanguage> vpScenarioLanguageList)
        {
            Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioLanguageID);
            Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioName));
            Assert.IsNotNull(vpScenarioLanguageList[0].TranslationStatus);
            Assert.IsNotNull(vpScenarioLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpScenarioLanguageList[0].HasErrors);
        }
        private void CheckVPScenarioLanguageWebFields(List<VPScenarioLanguageWeb> vpScenarioLanguageWebList)
        {
            Assert.IsNotNull(vpScenarioLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguageWebList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageWebList[0].TranslationStatusText));
            }
            Assert.IsNotNull(vpScenarioLanguageWebList[0].VPScenarioLanguageID);
            Assert.IsNotNull(vpScenarioLanguageWebList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageWebList[0].VPScenarioName));
            Assert.IsNotNull(vpScenarioLanguageWebList[0].TranslationStatus);
            Assert.IsNotNull(vpScenarioLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpScenarioLanguageWebList[0].HasErrors);
        }
        private void CheckVPScenarioLanguageReportFields(List<VPScenarioLanguageReport> vpScenarioLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].VPScenarioLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].VPScenarioLanguageReportTest));
            }
            Assert.IsNotNull(vpScenarioLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].TranslationStatusText));
            }
            Assert.IsNotNull(vpScenarioLanguageReportList[0].VPScenarioLanguageID);
            Assert.IsNotNull(vpScenarioLanguageReportList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageReportList[0].VPScenarioName));
            Assert.IsNotNull(vpScenarioLanguageReportList[0].TranslationStatus);
            Assert.IsNotNull(vpScenarioLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(vpScenarioLanguageReportList[0].HasErrors);
        }
        private VPScenarioLanguage GetFilledRandomVPScenarioLanguage(string OmitPropName)
        {
            VPScenarioLanguage vpScenarioLanguage = new VPScenarioLanguage();

            if (OmitPropName != "VPScenarioID") vpScenarioLanguage.VPScenarioID = 1;
            if (OmitPropName != "Language") vpScenarioLanguage.Language = LanguageRequest;
            if (OmitPropName != "VPScenarioName") vpScenarioLanguage.VPScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") vpScenarioLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") vpScenarioLanguage.LastUpdateContactTVItemID = 2;

            return vpScenarioLanguage;
        }
        #endregion Functions private
    }
}
