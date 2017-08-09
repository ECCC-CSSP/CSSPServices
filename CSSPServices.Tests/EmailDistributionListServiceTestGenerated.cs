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
            if (OmitPropName != "RegionName") emailDistributionList.RegionName = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "CountryTVText") emailDistributionList.CountryTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") emailDistributionList.LastUpdateContactTVText = GetRandomString("", 5);

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

                emailDistributionListService.Add(emailDistributionList);
                if (emailDistributionList.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, emailDistributionListService.GetRead().Where(c => c == emailDistributionList).Any());
                emailDistributionListService.Update(emailDistributionList);
                if (emailDistributionList.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, emailDistributionListService.GetRead().Count());
                emailDistributionListService.Delete(emailDistributionList);
                if (emailDistributionList.ValidationResults.Count() > 0)
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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListEmailDistributionListID), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                // emailDistributionList.CountryTVItemID   (Int32)
                // -----------------------------------

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.CountryTVItemID = 0;
                emailDistributionListService.Add(emailDistributionList);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListCountryTVItemID, emailDistributionList.CountryTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.CountryTVItemID = 1;
                emailDistributionListService.Add(emailDistributionList);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListCountryTVItemID, "Country"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(100))]
                // emailDistributionList.RegionName   (String)
                // -----------------------------------

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("RegionName");
                Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                Assert.AreEqual(1, emailDistributionList.ValidationResults.Count());
                Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListRegionName)).Any());
                Assert.AreEqual(null, emailDistributionList.RegionName);
                Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.RegionName = GetRandomString("", 101);
                Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListRegionName, "100"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 1000)]
                // emailDistributionList.Ordinal   (Int32)
                // -----------------------------------

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.Ordinal = -1;
                Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.Ordinal = 1001;
                Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

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
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, emailDistributionList.LastUpdateContactTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.LastUpdateContactTVItemID = 1;
                emailDistributionListService.Add(emailDistributionList);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, "Contact"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "CountryTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // emailDistributionList.CountryTVText   (String)
                // -----------------------------------

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.CountryTVText = GetRandomString("", 201);
                Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListCountryTVText, "200"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // emailDistributionList.LastUpdateContactTVText   (String)
                // -----------------------------------

                emailDistributionList = null;
                emailDistributionList = GetFilledRandomEmailDistributionList("");
                emailDistributionList.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListLastUpdateContactTVText, "200"), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // emailDistributionList.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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

                EmailDistributionListService emailDistributionListService = new EmailDistributionListService(LanguageRequest, dbTestDB, ContactID);
                EmailDistributionList emailDistributionList = (from c in emailDistributionListService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(emailDistributionList);

                EmailDistributionList emailDistributionListRet = emailDistributionListService.GetEmailDistributionListWithEmailDistributionListID(emailDistributionList.EmailDistributionListID);
                Assert.IsNotNull(emailDistributionListRet.EmailDistributionListID);
                Assert.IsNotNull(emailDistributionListRet.CountryTVItemID);
                Assert.IsNotNull(emailDistributionListRet.RegionName);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.RegionName));
                Assert.IsNotNull(emailDistributionListRet.Ordinal);
                Assert.IsNotNull(emailDistributionListRet.LastUpdateDate_UTC);
                Assert.IsNotNull(emailDistributionListRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(emailDistributionListRet.CountryTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.CountryTVText));
                Assert.IsNotNull(emailDistributionListRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
