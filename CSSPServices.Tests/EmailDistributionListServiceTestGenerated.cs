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

        #region Functions public
        #endregion Functions public

        #region Functions private
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionList_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new GetParam(), dbTestDB, ContactID);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListEmailDistributionListID), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListID = 10000000;
                    emailDistributionListService.Update(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.EmailDistributionList, CSSPModelsRes.EmailDistributionListEmailDistributionListID, emailDistributionList.EmailDistributionListID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                    // emailDistributionList.CountryTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.CountryTVItemID = 0;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListCountryTVItemID, emailDistributionList.CountryTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.CountryTVItemID = 1;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListCountryTVItemID, "Country"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // emailDistributionList.Ordinal   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = -1;
                    Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.EmailDistributionListOrdinal, "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.Ordinal = 1001;
                    Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.EmailDistributionListOrdinal, "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionList.EmailDistributionListWeb   (EmailDistributionListWeb)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListWeb = null;
                    Assert.IsNull(emailDistributionList.EmailDistributionListWeb);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListWeb = new EmailDistributionListWeb();
                    Assert.IsNotNull(emailDistributionList.EmailDistributionListWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionList.EmailDistributionListReport   (EmailDistributionListReport)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListReport = null;
                    Assert.IsNull(emailDistributionList.EmailDistributionListReport);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.EmailDistributionListReport = new EmailDistributionListReport();
                    Assert.IsNotNull(emailDistributionList.EmailDistributionListReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionList.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateDate_UTC = new DateTime();
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.EmailDistributionListLastUpdateDate_UTC), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.EmailDistributionListLastUpdateDate_UTC, "1980"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionList.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateContactTVItemID = 0;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.EmailDistributionListLastUpdateContactTVItemID, emailDistributionList.LastUpdateContactTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionList = null;
                    emailDistributionList = GetFilledRandomEmailDistributionList("");
                    emailDistributionList.LastUpdateContactTVItemID = 1;
                    emailDistributionListService.Add(emailDistributionList);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.EmailDistributionListLastUpdateContactTVItemID, "Contact"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new GetParam(), dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in emailDistributionListService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    EmailDistributionList emailDistributionListRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                            Assert.IsNull(emailDistributionListRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // EmailDistributionList fields
                        Assert.IsNotNull(emailDistributionListRet.EmailDistributionListID);
                        Assert.IsNotNull(emailDistributionListRet.CountryTVItemID);
                        Assert.IsNotNull(emailDistributionListRet.Ordinal);
                        Assert.IsNotNull(emailDistributionListRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(emailDistributionListRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // EmailDistributionListWeb and EmailDistributionListReport fields should be null here
                            Assert.IsNull(emailDistributionListRet.EmailDistributionListWeb);
                            Assert.IsNull(emailDistributionListRet.EmailDistributionListReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // EmailDistributionListWeb fields should not be null and EmailDistributionListReport fields should be null here
                            if (emailDistributionListRet.EmailDistributionListWeb.CountryTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.EmailDistributionListWeb.CountryTVText));
                            }
                            if (emailDistributionListRet.EmailDistributionListWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.EmailDistributionListWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(emailDistributionListRet.EmailDistributionListReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // EmailDistributionListWeb and EmailDistributionListReport fields should NOT be null here
                            if (emailDistributionListRet.EmailDistributionListWeb.CountryTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.EmailDistributionListWeb.CountryTVText));
                            }
                            if (emailDistributionListRet.EmailDistributionListWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.EmailDistributionListWeb.LastUpdateContactTVText));
                            }
                            if (emailDistributionListRet.EmailDistributionListReport.EmailDistributionReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.EmailDistributionListReport.EmailDistributionReportTest));
                            }
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
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(new GetParam(), dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in emailDistributionListService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        emailDistributionListService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            Assert.AreEqual(0, emailDistributionListList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // EmailDistributionList fields
                        Assert.IsNotNull(emailDistributionListList[0].EmailDistributionListID);
                        Assert.IsNotNull(emailDistributionListList[0].CountryTVItemID);
                        Assert.IsNotNull(emailDistributionListList[0].Ordinal);
                        Assert.IsNotNull(emailDistributionListList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(emailDistributionListList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // EmailDistributionListWeb and EmailDistributionListReport fields should be null here
                            Assert.IsNull(emailDistributionListList[0].EmailDistributionListWeb);
                            Assert.IsNull(emailDistributionListList[0].EmailDistributionListReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // EmailDistributionListWeb fields should not be null and EmailDistributionListReport fields should be null here
                            if (emailDistributionListList[0].EmailDistributionListWeb.CountryTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListList[0].EmailDistributionListWeb.CountryTVText));
                            }
                            if (emailDistributionListList[0].EmailDistributionListWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListList[0].EmailDistributionListWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(emailDistributionListList[0].EmailDistributionListReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // EmailDistributionListWeb and EmailDistributionListReport fields should NOT be null here
                            if (emailDistributionListList[0].EmailDistributionListWeb.CountryTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListList[0].EmailDistributionListWeb.CountryTVText));
                            }
                            if (emailDistributionListList[0].EmailDistributionListWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListList[0].EmailDistributionListWeb.LastUpdateContactTVText));
                            }
                            if (emailDistributionListList[0].EmailDistributionListReport.EmailDistributionReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListList[0].EmailDistributionListReport.EmailDistributionReportTest));
                            }
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
                    List<EmailDistributionList> emailDistributionListList = new List<EmailDistributionList>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(EmailDistributionList), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        EmailDistributionListService emailDistributionListService = new EmailDistributionListService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                            Assert.AreEqual(0, emailDistributionListList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            emailDistributionListList = emailDistributionListService.GetEmailDistributionListList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, emailDistributionListList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetEmailDistributionListList() Skip Take

    }
}
