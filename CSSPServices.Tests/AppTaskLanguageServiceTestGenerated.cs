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
    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AppTaskLanguageService appTaskLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {
            //appTaskLanguageService = new AppTaskLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void AppTaskLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = appTaskLanguageService.GetAppTaskLanguageList().Count();

                    Assert.AreEqual(appTaskLanguageService.GetAppTaskLanguageList().Count(), (from c in dbTestDB.AppTaskLanguages select c).Take(200).Count());

                    appTaskLanguageService.Add(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, appTaskLanguageService.GetAppTaskLanguageList().Where(c => c == appTaskLanguage).Any());
                    appTaskLanguageService.Update(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, appTaskLanguageService.GetAppTaskLanguageList().Count());
                    appTaskLanguageService.Delete(appTaskLanguage);
                    if (appTaskLanguage.HasErrors)
                    {
                        Assert.AreEqual("", appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // appTaskLanguage.AppTaskLanguageID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageID = 0;
                    appTaskLanguageService.Update(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageAppTaskLanguageID"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskLanguageID = 10000000;
                    appTaskLanguageService.Update(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageAppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID", AllowableTVtypeList = )]
                    // appTaskLanguage.AppTaskID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.AppTaskID = 0;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskLanguageAppTaskID", appTaskLanguage.AppTaskID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTaskLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.Language = (LanguageEnum)1000000;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageLanguage"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // appTaskLanguage.StatusText   (String)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.StatusText = GetRandomString("", 251);
                    Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "AppTaskLanguageStatusText", "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // appTaskLanguage.ErrorText   (String)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.ErrorText = GetRandomString("", 251);
                    Assert.AreEqual(false, appTaskLanguageService.Add(appTaskLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "AppTaskLanguageErrorText", "250"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, appTaskLanguageService.GetAppTaskLanguageList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // appTaskLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageTranslationStatus"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // appTaskLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateDate_UTC = new DateTime();
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageLastUpdateDate_UTC"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AppTaskLanguageLastUpdateDate_UTC", "1980"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // appTaskLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateContactTVItemID = 0;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AppTaskLanguageLastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    appTaskLanguage = null;
                    appTaskLanguage = GetFilledRandomAppTaskLanguage("");
                    appTaskLanguage.LastUpdateContactTVItemID = 1;
                    appTaskLanguageService.Add(appTaskLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AppTaskLanguageLastUpdateContactTVItemID", "Contact"), appTaskLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTaskLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // appTaskLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID)
        [TestMethod]
        public void GetAppTaskLanguageWithAppTaskLanguageID__appTaskLanguage_AppTaskLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTaskLanguage appTaskLanguage = (from c in dbTestDB.AppTaskLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(appTaskLanguage);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        appTaskLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            AppTaskLanguage appTaskLanguageRet = appTaskLanguageService.GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                            CheckAppTaskLanguageFields(new List<AppTaskLanguage>() { appTaskLanguageRet });
                            Assert.AreEqual(appTaskLanguage.AppTaskLanguageID, appTaskLanguageRet.AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            AppTaskLanguageExtraA appTaskLanguageExtraARet = appTaskLanguageService.GetAppTaskLanguageExtraAWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                            CheckAppTaskLanguageExtraAFields(new List<AppTaskLanguageExtraA>() { appTaskLanguageExtraARet });
                            Assert.AreEqual(appTaskLanguage.AppTaskLanguageID, appTaskLanguageExtraARet.AppTaskLanguageID);
                        }
                        else if (detail == "ExtraB")
                        {
                            AppTaskLanguageExtraB appTaskLanguageExtraBRet = appTaskLanguageService.GetAppTaskLanguageExtraBWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID);
                            CheckAppTaskLanguageExtraBFields(new List<AppTaskLanguageExtraB>() { appTaskLanguageExtraBRet });
                            Assert.AreEqual(appTaskLanguage.AppTaskLanguageID, appTaskLanguageExtraBRet.AppTaskLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageWithAppTaskLanguageID(appTaskLanguage.AppTaskLanguageID)

        #region Tests Generated for GetAppTaskLanguageList()
        [TestMethod]
        public void GetAppTaskLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    AppTaskLanguage appTaskLanguage = (from c in dbTestDB.AppTaskLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(appTaskLanguage);

                    List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                    appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        appTaskLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList()

        #region Tests Generated for GetAppTaskLanguageList() Skip Take
        [TestMethod]
        public void GetAppTaskLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                        appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraAList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraBList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Order
        [TestMethod]
        public void GetAppTaskLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "AppTaskLanguageID", "");

                        List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                        appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Skip(1).Take(1).OrderBy(c => c.AppTaskLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraAList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraBList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Order

        #region Tests Generated for GetAppTaskLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetAppTaskLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 1, 1, "AppTaskLanguageID,AppTaskID", "");

                        List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                        appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Skip(1).Take(1).OrderBy(c => c.AppTaskLanguageID).ThenBy(c => c.AppTaskID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraAList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraBList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take 2Order

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetAppTaskLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskLanguageID", "AppTaskLanguageID,EQ,4", "");

                        List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                        appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.AppTaskLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraAList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraBList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Order Where

        #region Tests Generated for GetAppTaskLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetAppTaskLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 1, "AppTaskLanguageID", "AppTaskLanguageID,GT,2|AppTaskLanguageID,LT,5", "");

                        List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                        appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID > 2 && c.AppTaskLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.AppTaskLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraAList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraBList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetAppTaskLanguageList() 2Where
        [TestMethod]
        public void GetAppTaskLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AppTaskLanguageService appTaskLanguageService = new AppTaskLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        appTaskLanguageService.Query = appTaskLanguageService.FillQuery(typeof(AppTaskLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "AppTaskLanguageID,GT,2|AppTaskLanguageID,LT,5", "");

                        List<AppTaskLanguage> appTaskLanguageDirectQueryList = new List<AppTaskLanguage>();
                        appTaskLanguageDirectQueryList = (from c in dbTestDB.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID > 2 && c.AppTaskLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<AppTaskLanguage> appTaskLanguageList = new List<AppTaskLanguage>();
                            appTaskLanguageList = appTaskLanguageService.GetAppTaskLanguageList().ToList();
                            CheckAppTaskLanguageFields(appTaskLanguageList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageList[0].AppTaskLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AppTaskLanguageExtraA> appTaskLanguageExtraAList = new List<AppTaskLanguageExtraA>();
                            appTaskLanguageExtraAList = appTaskLanguageService.GetAppTaskLanguageExtraAList().ToList();
                            CheckAppTaskLanguageExtraAFields(appTaskLanguageExtraAList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraAList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AppTaskLanguageExtraB> appTaskLanguageExtraBList = new List<AppTaskLanguageExtraB>();
                            appTaskLanguageExtraBList = appTaskLanguageService.GetAppTaskLanguageExtraBList().ToList();
                            CheckAppTaskLanguageExtraBFields(appTaskLanguageExtraBList);
                            Assert.AreEqual(appTaskLanguageDirectQueryList[0].AppTaskLanguageID, appTaskLanguageExtraBList[0].AppTaskLanguageID);
                            Assert.AreEqual(appTaskLanguageDirectQueryList.Count, appTaskLanguageExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAppTaskLanguageList() 2Where

        #region Functions private
        private void CheckAppTaskLanguageFields(List<AppTaskLanguage> appTaskLanguageList)
        {
            Assert.IsNotNull(appTaskLanguageList[0].AppTaskLanguageID);
            Assert.IsNotNull(appTaskLanguageList[0].AppTaskID);
            Assert.IsNotNull(appTaskLanguageList[0].Language);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].StatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageList[0].ErrorText));
            }
            Assert.IsNotNull(appTaskLanguageList[0].TranslationStatus);
            Assert.IsNotNull(appTaskLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskLanguageList[0].HasErrors);
        }
        private void CheckAppTaskLanguageExtraAFields(List<AppTaskLanguageExtraA> appTaskLanguageExtraAList)
        {
            Assert.IsNotNull(appTaskLanguageExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].TranslationStatusText));
            }
            Assert.IsNotNull(appTaskLanguageExtraAList[0].AppTaskLanguageID);
            Assert.IsNotNull(appTaskLanguageExtraAList[0].AppTaskID);
            Assert.IsNotNull(appTaskLanguageExtraAList[0].Language);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].StatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].StatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].ErrorText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraAList[0].ErrorText));
            }
            Assert.IsNotNull(appTaskLanguageExtraAList[0].TranslationStatus);
            Assert.IsNotNull(appTaskLanguageExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskLanguageExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskLanguageExtraAList[0].HasErrors);
        }
        private void CheckAppTaskLanguageExtraBFields(List<AppTaskLanguageExtraB> appTaskLanguageExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].AppTaskLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].AppTaskLanguageReportTest));
            }
            Assert.IsNotNull(appTaskLanguageExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].TranslationStatusText));
            }
            Assert.IsNotNull(appTaskLanguageExtraBList[0].AppTaskLanguageID);
            Assert.IsNotNull(appTaskLanguageExtraBList[0].AppTaskID);
            Assert.IsNotNull(appTaskLanguageExtraBList[0].Language);
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].StatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].StatusText));
            }
            if (!string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].ErrorText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(appTaskLanguageExtraBList[0].ErrorText));
            }
            Assert.IsNotNull(appTaskLanguageExtraBList[0].TranslationStatus);
            Assert.IsNotNull(appTaskLanguageExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(appTaskLanguageExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(appTaskLanguageExtraBList[0].HasErrors);
        }
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = LanguageRequest;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            return appTaskLanguage;
        }
        #endregion Functions private
    }
}
