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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageID = 10000000;
                    vpScenarioLanguageService.Update(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenarioLanguage, CSSPModelsRes.VPScenarioLanguageVPScenarioLanguageID, vpScenarioLanguage.VPScenarioLanguageID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID", AllowableTVtypeList = )]
                    // vpScenarioLanguage.VPScenarioID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPScenarioLanguageVPScenarioID, vpScenarioLanguage.VPScenarioID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // vpScenarioLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.Language = (LanguageEnum)1000000;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageLanguage), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // vpScenarioLanguage.VPScenarioName   (String)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("VPScenarioName");
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(1, vpScenarioLanguage.ValidationResults.Count());
                    Assert.IsTrue(vpScenarioLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageVPScenarioName)).Any());
                    Assert.AreEqual(null, vpScenarioLanguage.VPScenarioName);
                    Assert.AreEqual(count, vpScenarioLanguageService.GetRead().Count());

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioName = GetRandomString("", 101);
                    Assert.AreEqual(false, vpScenarioLanguageService.Add(vpScenarioLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.VPScenarioLanguageVPScenarioName, "100"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageTranslationStatus), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.VPScenarioLanguageWeb   (VPScenarioLanguageWeb)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageWeb = null;
                    Assert.IsNull(vpScenarioLanguage.VPScenarioLanguageWeb);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageWeb = new VPScenarioLanguageWeb();
                    Assert.IsNotNull(vpScenarioLanguage.VPScenarioLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // vpScenarioLanguage.VPScenarioLanguageReport   (VPScenarioLanguageReport)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageReport = null;
                    Assert.IsNull(vpScenarioLanguage.VPScenarioLanguageReport);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.VPScenarioLanguageReport = new VPScenarioLanguageReport();
                    Assert.IsNotNull(vpScenarioLanguage.VPScenarioLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // vpScenarioLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime();
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPScenarioLanguageLastUpdateDate_UTC, "1980"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // vpScenarioLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 0;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, vpScenarioLanguage.LastUpdateContactTVItemID.ToString()), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    vpScenarioLanguage = null;
                    vpScenarioLanguage = GetFilledRandomVPScenarioLanguage("");
                    vpScenarioLanguage.LastUpdateContactTVItemID = 1;
                    vpScenarioLanguageService.Add(vpScenarioLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioLanguageLastUpdateContactTVItemID, "Contact"), vpScenarioLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    VPScenarioLanguage vpScenarioLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpScenarioLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                            Assert.IsNull(vpScenarioLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageRet = vpScenarioLanguageService.GetVPScenarioLanguageWithVPScenarioLanguageID(vpScenarioLanguage.VPScenarioLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(new List<VPScenarioLanguage>() { vpScenarioLanguageRet }, entityQueryDetailType);
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

                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        vpScenarioLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
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
                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                        Assert.AreEqual(1, vpScenarioLanguageList.Count);
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
                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "VPScenarioLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                        Assert.AreEqual(1, vpScenarioLanguageList.Count);
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
                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 1, 1, "VPScenarioLanguageID,VPScenarioID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.VPScenarioLanguageID).ThenBy(c => c.VPScenarioID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                        Assert.AreEqual(1, vpScenarioLanguageList.Count);
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
                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "VPScenarioLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Where(c => c.VPScenarioLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                        Assert.AreEqual(1, vpScenarioLanguageList.Count);
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
                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 1, "VPScenarioLanguageID", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.VPScenarioLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                        Assert.AreEqual(1, vpScenarioLanguageList.Count);
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
                    List<VPScenarioLanguage> vpScenarioLanguageList = new List<VPScenarioLanguage>();
                    List<VPScenarioLanguage> vpScenarioLanguageDirectQueryList = new List<VPScenarioLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        VPScenarioLanguageService vpScenarioLanguageService = new VPScenarioLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        vpScenarioLanguageService.Query = vpScenarioLanguageService.FillQuery(typeof(VPScenarioLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "VPScenarioLanguageID,GT,2|VPScenarioLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        vpScenarioLanguageDirectQueryList = vpScenarioLanguageService.GetRead().Where(c => c.VPScenarioLanguageID > 2 && c.VPScenarioLanguageID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                            Assert.AreEqual(0, vpScenarioLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            vpScenarioLanguageList = vpScenarioLanguageService.GetVPScenarioLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckVPScenarioLanguageFields(vpScenarioLanguageList, entityQueryDetailType);
                        Assert.AreEqual(vpScenarioLanguageDirectQueryList[0].VPScenarioLanguageID, vpScenarioLanguageList[0].VPScenarioLanguageID);
                        Assert.AreEqual(2, vpScenarioLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetVPScenarioLanguageList() 2Where

        #region Functions private
        private void CheckVPScenarioLanguageFields(List<VPScenarioLanguage> vpScenarioLanguageList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // VPScenarioLanguage fields
            Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioLanguageID);
            Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioID);
            Assert.IsNotNull(vpScenarioLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioName));
            Assert.IsNotNull(vpScenarioLanguageList[0].TranslationStatus);
            Assert.IsNotNull(vpScenarioLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(vpScenarioLanguageList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // VPScenarioLanguageWeb and VPScenarioLanguageReport fields should be null here
                Assert.IsNull(vpScenarioLanguageList[0].VPScenarioLanguageWeb);
                Assert.IsNull(vpScenarioLanguageList[0].VPScenarioLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // VPScenarioLanguageWeb fields should not be null and VPScenarioLanguageReport fields should be null here
                Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioLanguageWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageWeb.TranslationStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageWeb.TranslationStatusText));
                }
                Assert.IsNull(vpScenarioLanguageList[0].VPScenarioLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // VPScenarioLanguageWeb and VPScenarioLanguageReport fields should NOT be null here
                Assert.IsNotNull(vpScenarioLanguageList[0].VPScenarioLanguageWeb.LastUpdateContactTVItemLanguage);
                if (vpScenarioLanguageList[0].VPScenarioLanguageWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageWeb.LanguageText));
                }
                if (vpScenarioLanguageList[0].VPScenarioLanguageWeb.TranslationStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageWeb.TranslationStatusText));
                }
                if (vpScenarioLanguageList[0].VPScenarioLanguageReport.VPScenarioLanguageReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(vpScenarioLanguageList[0].VPScenarioLanguageReport.VPScenarioLanguageReportTest));
                }
            }
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
