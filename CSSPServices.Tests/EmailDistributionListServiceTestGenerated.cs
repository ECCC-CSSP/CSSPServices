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

            // Need to implement (no items found, would need to add at least one in the TestDB) [EmailDistributionList CountryTVItemID TVItem TVItemID]
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            //Error: property [EmailDistributionListWeb] and type [EmailDistributionList] is  not implemented
            //Error: property [EmailDistributionListReport] and type [EmailDistributionList] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") emailDistributionList.HasErrors = true;

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
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(LanguageRequest, dbTestDB, ContactID);

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

                    //Error: Type not implemented [EmailDistributionListWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // emailDistributionList.EmailDistributionListReport   (EmailDistributionListReport)
                    // -----------------------------------

                    //Error: Type not implemented [EmailDistributionListReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionList.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionList.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void EmailDistributionList_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListService emailDistributionListService = new EmailDistributionListService(LanguageRequest, dbTestDB, ContactID);
                    EmailDistributionList emailDistributionList = (from c in emailDistributionListService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionList);

                    EmailDistributionList emailDistributionListRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(emailDistributionListRet.EmailDistributionListID);
                        Assert.IsNotNull(emailDistributionListRet.CountryTVItemID);
                        Assert.IsNotNull(emailDistributionListRet.Ordinal);
                        Assert.IsNotNull(emailDistributionListRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(emailDistributionListRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (emailDistributionListRet.EmailDistributionListWeb != null)
                            {
                                Assert.IsNull(emailDistributionListRet.EmailDistributionListWeb);
                            }
                            if (emailDistributionListRet.EmailDistributionListReport != null)
                            {
                                Assert.IsNull(emailDistributionListRet.EmailDistributionListReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (emailDistributionListRet.EmailDistributionListWeb != null)
                            {
                                Assert.IsNotNull(emailDistributionListRet.EmailDistributionListWeb);
                            }
                            if (emailDistributionListRet.EmailDistributionListReport != null)
                            {
                                Assert.IsNotNull(emailDistributionListRet.EmailDistributionListReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of EmailDistributionList
        #endregion Tests Get List of EmailDistributionList

    }
}
