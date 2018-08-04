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
    public partial class SpillLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SpillLanguageService spillLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageServiceTest() : base()
        {
            //spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SpillLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = spillLanguageService.GetSpillLanguageList().Count();

                    Assert.AreEqual(spillLanguageService.GetSpillLanguageList().Count(), (from c in dbTestDB.SpillLanguages select c).Take(200).Count());

                    spillLanguageService.Add(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, spillLanguageService.GetSpillLanguageList().Where(c => c == spillLanguage).Any());
                    spillLanguageService.Update(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, spillLanguageService.GetSpillLanguageList().Count());
                    spillLanguageService.Delete(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, spillLanguageService.GetSpillLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // spillLanguage.SpillLanguageID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageID = 0;
                    spillLanguageService.Update(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageSpillLanguageID"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageID = 10000000;
                    spillLanguageService.Update(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SpillLanguage", "SpillLanguageSpillLanguageID", spillLanguage.SpillLanguageID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID", AllowableTVtypeList = )]
                    // spillLanguage.SpillID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillID = 0;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillLanguageSpillID", spillLanguage.SpillID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // spillLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.Language = (LanguageEnum)1000000;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageLanguage"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // spillLanguage.SpillComment   (String)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
                    Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
                    Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
                    Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "SpillLanguageSpillComment")).Any());
                    Assert.AreEqual(null, spillLanguage.SpillComment);
                    Assert.AreEqual(count, spillLanguageService.GetSpillLanguageList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // spillLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageTranslationStatus"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spillLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateDate_UTC = new DateTime();
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillLanguageLastUpdateDate_UTC"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillLanguageLastUpdateDate_UTC", "1980"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // spillLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateContactTVItemID = 0;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillLanguageLastUpdateContactTVItemID", spillLanguage.LastUpdateContactTVItemID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateContactTVItemID = 1;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SpillLanguageLastUpdateContactTVItemID", "Contact"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spillLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spillLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID)
        [TestMethod]
        public void GetSpillLanguageWithSpillLanguageID__spillLanguage_SpillLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SpillLanguage spillLanguage = (from c in dbTestDB.SpillLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(spillLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        spillLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            SpillLanguage spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                            CheckSpillLanguageFields(new List<SpillLanguage>() { spillLanguageRet });
                            Assert.AreEqual(spillLanguage.SpillLanguageID, spillLanguageRet.SpillLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            SpillLanguageWeb spillLanguageWebRet = spillLanguageService.GetSpillLanguageWebWithSpillLanguageID(spillLanguage.SpillLanguageID);
                            CheckSpillLanguageWebFields(new List<SpillLanguageWeb>() { spillLanguageWebRet });
                            Assert.AreEqual(spillLanguage.SpillLanguageID, spillLanguageWebRet.SpillLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            SpillLanguageReport spillLanguageReportRet = spillLanguageService.GetSpillLanguageReportWithSpillLanguageID(spillLanguage.SpillLanguageID);
                            CheckSpillLanguageReportFields(new List<SpillLanguageReport>() { spillLanguageReportRet });
                            Assert.AreEqual(spillLanguage.SpillLanguageID, spillLanguageReportRet.SpillLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID)

        #region Tests Generated for GetSpillLanguageList()
        [TestMethod]
        public void GetSpillLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SpillLanguage spillLanguage = (from c in dbTestDB.SpillLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(spillLanguage);

                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        spillLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList()

        #region Tests Generated for GetSpillLanguageList() Skip Take
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                        spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageWebList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageReportList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take

        #region Tests Generated for GetSpillLanguageList() Skip Take Order
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "SpillLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                        spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Skip(1).Take(1).OrderBy(c => c.SpillLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageWebList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageReportList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take Order

        #region Tests Generated for GetSpillLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 1, 1, "SpillLanguageID,SpillID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                        spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Skip(1).Take(1).OrderBy(c => c.SpillLanguageID).ThenBy(c => c.SpillID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageWebList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageReportList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take 2Order

        #region Tests Generated for GetSpillLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 0, 1, "SpillLanguageID", "SpillLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                        spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Where(c => c.SpillLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.SpillLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageWebList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageReportList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take Order Where

        #region Tests Generated for GetSpillLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 0, 1, "SpillLanguageID", "SpillLanguageID,GT,2|SpillLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                        spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Where(c => c.SpillLanguageID > 2 && c.SpillLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.SpillLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageWebList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageReportList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetSpillLanguageList() 2Where
        [TestMethod]
        public void GetSpillLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "SpillLanguageID,GT,2|SpillLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                        spillLanguageDirectQueryList = (from c in dbTestDB.SpillLanguages select c).Where(c => c.SpillLanguageID > 2 && c.SpillLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            CheckSpillLanguageFields(spillLanguageList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SpillLanguageWeb> spillLanguageWebList = new List<SpillLanguageWeb>();
                            spillLanguageWebList = spillLanguageService.GetSpillLanguageWebList().ToList();
                            CheckSpillLanguageWebFields(spillLanguageWebList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageWebList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SpillLanguageReport> spillLanguageReportList = new List<SpillLanguageReport>();
                            spillLanguageReportList = spillLanguageService.GetSpillLanguageReportList().ToList();
                            CheckSpillLanguageReportFields(spillLanguageReportList);
                            Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageReportList[0].SpillLanguageID);
                            Assert.AreEqual(spillLanguageDirectQueryList.Count, spillLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() 2Where

        #region Functions private
        private void CheckSpillLanguageFields(List<SpillLanguage> spillLanguageList)
        {
            Assert.IsNotNull(spillLanguageList[0].SpillLanguageID);
            Assert.IsNotNull(spillLanguageList[0].SpillID);
            Assert.IsNotNull(spillLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillComment));
            Assert.IsNotNull(spillLanguageList[0].TranslationStatus);
            Assert.IsNotNull(spillLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spillLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(spillLanguageList[0].HasErrors);
        }
        private void CheckSpillLanguageWebFields(List<SpillLanguageWeb> spillLanguageWebList)
        {
            Assert.IsNotNull(spillLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(spillLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(spillLanguageWebList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageWebList[0].TranslationStatusText));
            }
            Assert.IsNotNull(spillLanguageWebList[0].SpillLanguageID);
            Assert.IsNotNull(spillLanguageWebList[0].SpillID);
            Assert.IsNotNull(spillLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageWebList[0].SpillComment));
            Assert.IsNotNull(spillLanguageWebList[0].TranslationStatus);
            Assert.IsNotNull(spillLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spillLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(spillLanguageWebList[0].HasErrors);
        }
        private void CheckSpillLanguageReportFields(List<SpillLanguageReport> spillLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(spillLanguageReportList[0].SpillLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageReportList[0].SpillLanguageReportTest));
            }
            Assert.IsNotNull(spillLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(spillLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(spillLanguageReportList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageReportList[0].TranslationStatusText));
            }
            Assert.IsNotNull(spillLanguageReportList[0].SpillLanguageID);
            Assert.IsNotNull(spillLanguageReportList[0].SpillID);
            Assert.IsNotNull(spillLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageReportList[0].SpillComment));
            Assert.IsNotNull(spillLanguageReportList[0].TranslationStatus);
            Assert.IsNotNull(spillLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spillLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(spillLanguageReportList[0].HasErrors);
        }
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = LanguageRequest;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;

            return spillLanguage;
        }
        #endregion Functions private
    }
}
