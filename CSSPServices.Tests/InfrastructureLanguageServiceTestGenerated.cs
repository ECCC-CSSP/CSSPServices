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
    public partial class InfrastructureLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private InfrastructureLanguageService infrastructureLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageServiceTest() : base()
        {
            //infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void InfrastructureLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    InfrastructureLanguage infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = infrastructureLanguageService.GetInfrastructureLanguageList().Count();

                    Assert.AreEqual(infrastructureLanguageService.GetInfrastructureLanguageList().Count(), (from c in dbTestDB.InfrastructureLanguages select c).Take(200).Count());

                    infrastructureLanguageService.Add(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, infrastructureLanguageService.GetInfrastructureLanguageList().Where(c => c == infrastructureLanguage).Any());
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, infrastructureLanguageService.GetInfrastructureLanguageList().Count());
                    infrastructureLanguageService.Delete(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, infrastructureLanguageService.GetInfrastructureLanguageList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // infrastructureLanguage.InfrastructureLanguageID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageID = 0;
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageInfrastructureLanguageID"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageID = 10000000;
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "InfrastructureLanguage", "InfrastructureLanguageInfrastructureLanguageID", infrastructureLanguage.InfrastructureLanguageID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID", AllowableTVtypeList = )]
                    // infrastructureLanguage.InfrastructureID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureID = 0;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureLanguageInfrastructureID", infrastructureLanguage.InfrastructureID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // infrastructureLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.Language = (LanguageEnum)1000000;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageLanguage"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // infrastructureLanguage.Comment   (String)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
                    Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                    Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
                    Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageComment")).Any());
                    Assert.AreEqual(null, infrastructureLanguage.Comment);
                    Assert.AreEqual(count, infrastructureLanguageService.GetInfrastructureLanguageList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // infrastructureLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageTranslationStatus"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // infrastructureLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateDate_UTC = new DateTime();
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "InfrastructureLanguageLastUpdateDate_UTC"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "InfrastructureLanguageLastUpdateDate_UTC", "1980"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // infrastructureLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateContactTVItemID = 0;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureLanguageLastUpdateContactTVItemID", infrastructureLanguage.LastUpdateContactTVItemID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateContactTVItemID = 1;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureLanguageLastUpdateContactTVItemID", "Contact"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructureLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructureLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID)
        [TestMethod]
        public void GetInfrastructureLanguageWithInfrastructureLanguageID__infrastructureLanguage_InfrastructureLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in dbTestDB.InfrastructureLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        infrastructureLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            InfrastructureLanguage infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            CheckInfrastructureLanguageFields(new List<InfrastructureLanguage>() { infrastructureLanguageRet });
                            Assert.AreEqual(infrastructureLanguage.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            InfrastructureLanguageWeb infrastructureLanguageWebRet = infrastructureLanguageService.GetInfrastructureLanguageWebWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            CheckInfrastructureLanguageWebFields(new List<InfrastructureLanguageWeb>() { infrastructureLanguageWebRet });
                            Assert.AreEqual(infrastructureLanguage.InfrastructureLanguageID, infrastructureLanguageWebRet.InfrastructureLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            InfrastructureLanguageReport infrastructureLanguageReportRet = infrastructureLanguageService.GetInfrastructureLanguageReportWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            CheckInfrastructureLanguageReportFields(new List<InfrastructureLanguageReport>() { infrastructureLanguageReportRet });
                            Assert.AreEqual(infrastructureLanguage.InfrastructureLanguageID, infrastructureLanguageReportRet.InfrastructureLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID)

        #region Tests Generated for GetInfrastructureLanguageList()
        [TestMethod]
        public void GetInfrastructureLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in dbTestDB.InfrastructureLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        infrastructureLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList()

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageWebList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageReportList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take Order
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "InfrastructureLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageWebList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageReportList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take Order

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1, "InfrastructureLanguageID,InfrastructureID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureLanguageID).ThenBy(c => c.InfrastructureID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageWebList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageReportList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take 2Order

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureLanguageID", "InfrastructureLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageWebList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageReportList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take Order Where

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureLanguageID", "InfrastructureLanguageID,GT,2|InfrastructureLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID > 2 && c.InfrastructureLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageWebList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageReportList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetInfrastructureLanguageList() 2Where
        [TestMethod]
        public void GetInfrastructureLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "InfrastructureLanguageID,GT,2|InfrastructureLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID > 2 && c.InfrastructureLanguageID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<InfrastructureLanguageWeb> infrastructureLanguageWebList = new List<InfrastructureLanguageWeb>();
                            infrastructureLanguageWebList = infrastructureLanguageService.GetInfrastructureLanguageWebList().ToList();
                            CheckInfrastructureLanguageWebFields(infrastructureLanguageWebList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageWebList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<InfrastructureLanguageReport> infrastructureLanguageReportList = new List<InfrastructureLanguageReport>();
                            infrastructureLanguageReportList = infrastructureLanguageService.GetInfrastructureLanguageReportList().ToList();
                            CheckInfrastructureLanguageReportFields(infrastructureLanguageReportList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageReportList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() 2Where

        #region Functions private
        private void CheckInfrastructureLanguageFields(List<InfrastructureLanguage> infrastructureLanguageList)
        {
            Assert.IsNotNull(infrastructureLanguageList[0].InfrastructureLanguageID);
            Assert.IsNotNull(infrastructureLanguageList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].Comment));
            Assert.IsNotNull(infrastructureLanguageList[0].TranslationStatus);
            Assert.IsNotNull(infrastructureLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureLanguageList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureLanguageList[0].HasErrors);
        }
        private void CheckInfrastructureLanguageWebFields(List<InfrastructureLanguageWeb> infrastructureLanguageWebList)
        {
            Assert.IsNotNull(infrastructureLanguageWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageWebList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageWebList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageWebList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageWebList[0].TranslationStatusText));
            }
            Assert.IsNotNull(infrastructureLanguageWebList[0].InfrastructureLanguageID);
            Assert.IsNotNull(infrastructureLanguageWebList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureLanguageWebList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageWebList[0].Comment));
            Assert.IsNotNull(infrastructureLanguageWebList[0].TranslationStatus);
            Assert.IsNotNull(infrastructureLanguageWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureLanguageWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureLanguageWebList[0].HasErrors);
        }
        private void CheckInfrastructureLanguageReportFields(List<InfrastructureLanguageReport> infrastructureLanguageReportList)
        {
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].InfrastructureLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].InfrastructureLanguageReportTest));
            }
            Assert.IsNotNull(infrastructureLanguageReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].TranslationStatusText));
            }
            Assert.IsNotNull(infrastructureLanguageReportList[0].InfrastructureLanguageID);
            Assert.IsNotNull(infrastructureLanguageReportList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureLanguageReportList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageReportList[0].Comment));
            Assert.IsNotNull(infrastructureLanguageReportList[0].TranslationStatus);
            Assert.IsNotNull(infrastructureLanguageReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureLanguageReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureLanguageReportList[0].HasErrors);
        }
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 1;
            if (OmitPropName != "Language") infrastructureLanguage.Language = LanguageRequest;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;

            return infrastructureLanguage;
        }
        #endregion Functions private
    }
}
