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
    public partial class EmailDistributionListServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListService emailDistributionListService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListServiceTest() : base()
        {
            //emailDistributionListService = new EmailDistributionListService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionList_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = emailDistributionListService.GetEmailDistributionListList().Count();

                    Assert.AreEqual(emailDistributionListService.GetEmailDistributionListList().Count(), (from c in dbTestDB.EmailDistributionLists select c).Take(200).Count());

                    emailDistributionListService.Add(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListService.GetEmailDistributionListList().Where(c => c == emailDistributionList).Any());
                    emailDistributionListService.Update(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListService.GetEmailDistributionListList().Count());
                    emailDistributionListService.Delete(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListService.GetEmailDistributionListList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // emailDistributionList.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListID = 0;
                    emailDistributionListService.Update(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListEmailDistributionListID"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListID = 10000000;
                    emailDistributionListService.Update(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "EmailDistributionList", "EmailDistributionListEmailDistributionListID", emailDistributionList.EmailDistributionListID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                    // emailDistributionList.CountryTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.CountryTVItemID = 0;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListCountryTVItemID", emailDistributionList.CountryTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.CountryTVItemID = 1;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListCountryTVItemID", "Country"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // emailDistributionList.Ordinal   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = -1;
                    Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EmailDistributionListOrdinal", "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListService.GetEmailDistributionListList().Count());
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = 1001;
                    Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EmailDistributionListOrdinal", "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListService.GetEmailDistributionListList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionList.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "EmailDistributionListLastUpdateDate_UTC"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EmailDistributionListLastUpdateDate_UTC", "1980"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionList.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateContactTVItemID = 0;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "EmailDistributionListLastUpdateContactTVItemID", emailDistributionList.LastUpdateContactTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateContactTVItemID = 1;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "EmailDistributionListLastUpdateContactTVItemID", "Contact"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionList.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionList.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID)
        [TestMethod]
        public void GetEmailDistributionListWithEmailDistributionListID__emailDistributionList_EmailDistributionListID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in dbTestDB.EmailDistributionLists select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        emailDistributionListService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            EmailDistributionList emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            CheckEmailDistributionListFields(new List<EmailDistributionList>() { emailDistributionListRet });
                            Assert.AreEqual(emailDistributionList.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            EmailDistributionList_A emailDistributionList_ARet = emailDistributionListService.GetEmailDistributionList_AWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            CheckEmailDistributionList_AFields(new List<EmailDistributionList_A>() { emailDistributionList_ARet });
                            Assert.AreEqual(emailDistributionList.EmailDistributionListID, emailDistributionList_ARet.EmailDistributionListID);
                        }
                        else if (detail == "B")
                        {
                            EmailDistributionList_B emailDistributionList_BRet = emailDistributionListService.GetEmailDistributionList_BWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            CheckEmailDistributionList_BFields(new List<EmailDistributionList_B>() { emailDistributionList_BRet });
                            Assert.AreEqual(emailDistributionList.EmailDistributionListID, emailDistributionList_BRet.EmailDistributionListID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID)

        #region Tests Generated for GetEmailDistributionListList()
        [TestMethod]
        public void GetEmailDistributionListList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in dbTestDB.EmailDistributionLists select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        emailDistributionListService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList()

        #region Tests Generated for GetEmailDistributionListList() Skip Take
        [TestMethod]
        public void GetEmailDistributionListList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_AList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_BList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take

        #region Tests Generated for GetEmailDistributionListList() Skip Take Order
        [TestMethod]
        public void GetEmailDistributionListList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListID", "");

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_AList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_BList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Order

        #region Tests Generated for GetEmailDistributionListList() Skip Take 2Order
        [TestMethod]
        public void GetEmailDistributionListList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListID,CountryTVItemID", "");

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Skip(1).Take(1).OrderBy(c => c.EmailDistributionListID).ThenBy(c => c.CountryTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_AList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_BList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take 2Order

        #region Tests Generated for GetEmailDistributionListList() Skip Take Order Where
        [TestMethod]
        public void GetEmailDistributionListList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "EmailDistributionListID,EQ,4", "");

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_AList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_BList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Order Where

        #region Tests Generated for GetEmailDistributionListList() Skip Take Order 2Where
        [TestMethod]
        public void GetEmailDistributionListList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5", "");

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_AList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_BList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take Order 2Where

        #region Tests Generated for GetEmailDistributionListList() 2Where
        [TestMethod]
        public void GetEmailDistributionListList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5", "");

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = (from c in dbTestDB.EmailDistributionLists select c).Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                        }
                        else if (detail == "A")
                        {
                            List<EmailDistributionList_A> emailDistributionList_AList = new List<EmailDistributionList_A>();
                            emailDistributionList_AList = emailDistributionListService.GetEmailDistributionList_AList().ToList();
                            CheckEmailDistributionList_AFields(emailDistributionList_AList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_AList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<EmailDistributionList_B> emailDistributionList_BList = new List<EmailDistributionList_B>();
                            emailDistributionList_BList = emailDistributionListService.GetEmailDistributionList_BList().ToList();
                            CheckEmailDistributionList_BFields(emailDistributionList_BList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionList_BList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionList_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() 2Where

        #region Functions private
        private void CheckEmailDistributionListFields(List<EmailDistributionList> emailDistributionListList)
        {
            Assert.IsNotNull(emailDistributionListList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListList[0].CountryTVItemID);
            Assert.IsNotNull(emailDistributionListList[0].Ordinal);
            Assert.IsNotNull(emailDistributionListList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListList[0].HasErrors);
        }
        private void CheckEmailDistributionList_AFields(List<EmailDistributionList_A> emailDistributionList_AList)
        {
            Assert.IsNotNull(emailDistributionList_AList[0].CountryTVItemLanguage);
            Assert.IsNotNull(emailDistributionList_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(emailDistributionList_AList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionList_AList[0].CountryTVItemID);
            Assert.IsNotNull(emailDistributionList_AList[0].Ordinal);
            Assert.IsNotNull(emailDistributionList_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionList_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionList_AList[0].HasErrors);
        }
        private void CheckEmailDistributionList_BFields(List<EmailDistributionList_B> emailDistributionList_BList)
        {
            if (!string.IsNullOrWhiteSpace(emailDistributionList_BList[0].EmailDistributionListReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionList_BList[0].EmailDistributionListReportTest));
            }
            Assert.IsNotNull(emailDistributionList_BList[0].CountryTVItemLanguage);
            Assert.IsNotNull(emailDistributionList_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(emailDistributionList_BList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionList_BList[0].CountryTVItemID);
            Assert.IsNotNull(emailDistributionList_BList[0].Ordinal);
            Assert.IsNotNull(emailDistributionList_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionList_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionList_BList[0].HasErrors);
        }
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "CountryTVItemID") emailDistributionList.CountryTVItemID = 5;
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;

            return emailDistributionList;
        }
        #endregion Functions private
    }
}
