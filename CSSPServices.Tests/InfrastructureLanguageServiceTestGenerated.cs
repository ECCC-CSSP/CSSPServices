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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in dbTestDB.InfrastructureLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        infrastructureLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            InfrastructureLanguage infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            CheckInfrastructureLanguageFields(new List<InfrastructureLanguage>() { infrastructureLanguageRet });
                            Assert.AreEqual(infrastructureLanguage.InfrastructureLanguageID, infrastructureLanguageRet.InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            InfrastructureLanguageExtraA infrastructureLanguageExtraARet = infrastructureLanguageService.GetInfrastructureLanguageExtraAWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            CheckInfrastructureLanguageExtraAFields(new List<InfrastructureLanguageExtraA>() { infrastructureLanguageExtraARet });
                            Assert.AreEqual(infrastructureLanguage.InfrastructureLanguageID, infrastructureLanguageExtraARet.InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraB")
                        {
                            InfrastructureLanguageExtraB infrastructureLanguageExtraBRet = infrastructureLanguageService.GetInfrastructureLanguageExtraBWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            CheckInfrastructureLanguageExtraBFields(new List<InfrastructureLanguageExtraB>() { infrastructureLanguageExtraBRet });
                            Assert.AreEqual(infrastructureLanguage.InfrastructureLanguageID, infrastructureLanguageExtraBRet.InfrastructureLanguageID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in dbTestDB.InfrastructureLanguages select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        infrastructureLanguageService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "InfrastructureLanguageID", "");

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1, "InfrastructureLanguageID,InfrastructureID", "");

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Skip(1).Take(1).OrderBy(c => c.InfrastructureLanguageID).ThenBy(c => c.InfrastructureID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureLanguageID", "InfrastructureLanguageID,EQ,4", "");

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureLanguageID", "InfrastructureLanguageID,GT,2|InfrastructureLanguageID,LT,5", "");

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID > 2 && c.InfrastructureLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "InfrastructureLanguageID,GT,2|InfrastructureLanguageID,LT,5", "");

                        List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                        infrastructureLanguageDirectQueryList = (from c in dbTestDB.InfrastructureLanguages select c).Where(c => c.InfrastructureLanguageID > 2 && c.InfrastructureLanguageID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            CheckInfrastructureLanguageFields(infrastructureLanguageList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList = new List<InfrastructureLanguageExtraA>();
                            infrastructureLanguageExtraAList = infrastructureLanguageService.GetInfrastructureLanguageExtraAList().ToList();
                            CheckInfrastructureLanguageExtraAFields(infrastructureLanguageExtraAList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList = new List<InfrastructureLanguageExtraB>();
                            infrastructureLanguageExtraBList = infrastructureLanguageService.GetInfrastructureLanguageExtraBList().ToList();
                            CheckInfrastructureLanguageExtraBFields(infrastructureLanguageExtraBList);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
                            Assert.AreEqual(infrastructureLanguageDirectQueryList.Count, infrastructureLanguageExtraBList.Count);
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
        private void CheckInfrastructureLanguageExtraAFields(List<InfrastructureLanguageExtraA> infrastructureLanguageExtraAList)
        {
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageExtraAList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraAList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageExtraAList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraAList[0].TranslationStatusText));
            }
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].InfrastructureLanguageID);
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraAList[0].Comment));
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].TranslationStatus);
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureLanguageExtraAList[0].HasErrors);
        }
        private void CheckInfrastructureLanguageExtraBFields(List<InfrastructureLanguageExtraB> infrastructureLanguageExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].InfrastructureLanguageReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].InfrastructureLanguageReportTest));
            }
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].TranslationStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].TranslationStatusText));
            }
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].InfrastructureLanguageID);
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageExtraBList[0].Comment));
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].TranslationStatus);
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(infrastructureLanguageExtraBList[0].HasErrors);
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
