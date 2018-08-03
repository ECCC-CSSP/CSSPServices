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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = emailDistributionListService.GetRead().Count();

                    Assert.AreEqual(emailDistributionListService.GetRead().Count(), emailDistributionListService.GetEdit().Count());

                    emailDistributionListService.Add(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, emailDistributionListService.GetRead().Where(c => c == emailDistributionList).Any());
                    emailDistributionListService.Update(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, emailDistributionListService.GetRead().Count());
                    emailDistributionListService.Delete(emailDistributionList);
                    if (emailDistributionList.HasErrors)
                    {
                        Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

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
                    Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = 1001;
                    Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "EmailDistributionListOrdinal", "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in emailDistributionListService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            EmailDistributionList emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            CheckEmailDistributionListFields(new List<EmailDistributionList>() { emailDistributionListRet });
                            Assert.AreEqual(emailDistributionList.EmailDistributionListID, emailDistributionListRet.EmailDistributionListID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            EmailDistributionListWeb emailDistributionListWebRet = emailDistributionListService.GetEmailDistributionListWebWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            CheckEmailDistributionListWebFields(new List<EmailDistributionListWeb>() { emailDistributionListWebRet });
                            Assert.AreEqual(emailDistributionList.EmailDistributionListID, emailDistributionListWebRet.EmailDistributionListID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            EmailDistributionListReport emailDistributionListReportRet = emailDistributionListService.GetEmailDistributionListReportWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            CheckEmailDistributionListReportFields(new List<EmailDistributionListReport>() { emailDistributionListReportRet });
                            Assert.AreEqual(emailDistributionList.EmailDistributionListID, emailDistributionListReportRet.EmailDistributionListID);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in emailDistributionListService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                    emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListWebList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListReportList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1,  "EmailDistributionListID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Skip(1).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListWebList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListReportList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 1, 1, "EmailDistributionListID,CountryTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Skip(1).Take(1).OrderBy(c => c.EmailDistributionListID).ThenBy(c => c.CountryTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListWebList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListReportList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "EmailDistributionListID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Where(c => c.EmailDistributionListID == 4).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListWebList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListReportList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 1, "EmailDistributionListID", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).Skip(0).Take(1).OrderBy(c => c.EmailDistributionListID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListWebList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListReportList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        emailDistributionListService.Query = emailDistributionListService.FillQuery(typeof(EmailDistributionList), culture.TwoLetterISOLanguageName, 0, 10000, "", "EmailDistributionListID,GT,2|EmailDistributionListID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<EmailDistributionList> emailDistributionListDirectQueryList = new List<EmailDistributionList>();
                        emailDistributionListDirectQueryList = emailDistributionListService.GetRead().Where(c => c.EmailDistributionListID > 2 && c.EmailDistributionListID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            CheckEmailDistributionListFields(emailDistributionListList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<EmailDistributionListWeb> emailDistributionListWebList = new List<EmailDistributionListWeb>();
                            emailDistributionListWebList = emailDistributionListService.GetEmailDistributionListWebList().ToList();
                            CheckEmailDistributionListWebFields(emailDistributionListWebList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListWebList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<EmailDistributionListReport> emailDistributionListReportList = new List<EmailDistributionListReport>();
                            emailDistributionListReportList = emailDistributionListService.GetEmailDistributionListReportList().ToList();
                            CheckEmailDistributionListReportFields(emailDistributionListReportList);
                            Assert.AreEqual(emailDistributionListDirectQueryList[0].EmailDistributionListID, emailDistributionListReportList[0].EmailDistributionListID);
                            Assert.AreEqual(emailDistributionListDirectQueryList.Count, emailDistributionListReportList.Count);
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
        private void CheckEmailDistributionListWebFields(List<EmailDistributionListWeb> emailDistributionListWebList)
        {
            Assert.IsNotNull(emailDistributionListWebList[0].CountryTVItemLanguage);
            Assert.IsNotNull(emailDistributionListWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(emailDistributionListWebList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListWebList[0].CountryTVItemID);
            Assert.IsNotNull(emailDistributionListWebList[0].Ordinal);
            Assert.IsNotNull(emailDistributionListWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListWebList[0].HasErrors);
        }
        private void CheckEmailDistributionListReportFields(List<EmailDistributionListReport> emailDistributionListReportList)
        {
            if (!string.IsNullOrWhiteSpace(emailDistributionListReportList[0].EmailDistributionListReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListReportList[0].EmailDistributionListReportTest));
            }
            Assert.IsNotNull(emailDistributionListReportList[0].CountryTVItemLanguage);
            Assert.IsNotNull(emailDistributionListReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(emailDistributionListReportList[0].EmailDistributionListID);
            Assert.IsNotNull(emailDistributionListReportList[0].CountryTVItemID);
            Assert.IsNotNull(emailDistributionListReportList[0].Ordinal);
            Assert.IsNotNull(emailDistributionListReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(emailDistributionListReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(emailDistributionListReportList[0].HasErrors);
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
