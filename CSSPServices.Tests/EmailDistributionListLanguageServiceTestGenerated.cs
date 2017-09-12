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
    public partial class EmailDistributionListLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private EmailDistributionListLanguageService emailDistributionListLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListLanguageServiceTest() : base()
        {
            //emailDistributionListLanguageService = new EmailDistributionListLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private EmailDistributionListLanguage GetFilledRandomEmailDistributionListLanguage(string OmitPropName)
        {
            EmailDistributionListLanguage emailDistributionListLanguage = new EmailDistributionListLanguage();

            if (OmitPropName != "EmailDistributionListID") emailDistributionListLanguage.EmailDistributionListID = 0;
            if (OmitPropName != "Language") emailDistributionListLanguage.Language = LanguageRequest;
            if (OmitPropName != "RegionName") emailDistributionListLanguage.RegionName = GetRandomString("", 6);
            if (OmitPropName != "TranslationStatus") emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionListLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionListLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") emailDistributionListLanguage.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") emailDistributionListLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") emailDistributionListLanguage.TranslationStatusText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") emailDistributionListLanguage.HasErrors = true;

            return emailDistributionListLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void EmailDistributionListLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    EmailDistributionListLanguage emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                count = emailDistributionListLanguageService.GetRead().Count();

                Assert.AreEqual(emailDistributionListLanguageService.GetRead().Count(), emailDistributionListLanguageService.GetEdit().Count());

                emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                if (emailDistributionListLanguage.HasErrors)
                {
                    Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, emailDistributionListLanguageService.GetRead().Where(c => c == emailDistributionListLanguage).Any());
                emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                if (emailDistributionListLanguage.HasErrors)
                {
                    Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, emailDistributionListLanguageService.GetRead().Count());
                emailDistributionListLanguageService.Delete(emailDistributionListLanguage);
                if (emailDistributionListLanguage.HasErrors)
                {
                    Assert.AreEqual("", emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // emailDistributionListLanguage.EmailDistributionListLanguageID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageID = 0;
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListLanguageID = 10000000;
                    emailDistributionListLanguageService.Update(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionListLanguage, ModelsRes.EmailDistributionListLanguageEmailDistributionListLanguageID, emailDistributionListLanguage.EmailDistributionListLanguageID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID", AllowableTVtypeList = Error)]
                    // emailDistributionListLanguage.EmailDistributionListID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.EmailDistributionListID = 0;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.EmailDistributionList, ModelsRes.EmailDistributionListLanguageEmailDistributionListID, emailDistributionListLanguage.EmailDistributionListID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.Language = (LanguageEnum)1000000;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLanguageLanguage), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100, MinimumLength = 1)]
                    // emailDistributionListLanguage.RegionName   (String)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("RegionName");
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(1, emailDistributionListLanguage.ValidationResults.Count());
                    Assert.IsTrue(emailDistributionListLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLanguageRegionName)).Any());
                    Assert.AreEqual(null, emailDistributionListLanguage.RegionName);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.RegionName = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.EmailDistributionListLanguageRegionName, "1", "100"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // emailDistributionListLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLanguageTranslationStatus), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // emailDistributionListLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // emailDistributionListLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 0;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID, emailDistributionListLanguage.LastUpdateContactTVItemID.ToString()), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVItemID = 1;
                    emailDistributionListLanguageService.Add(emailDistributionListLanguage);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.EmailDistributionListLanguageLastUpdateContactTVItemID, "Contact"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // emailDistributionListLanguage.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListLanguageLastUpdateContactTVText, "200"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // emailDistributionListLanguage.LanguageText   (String)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.LanguageText = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListLanguageLanguageText, "100"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // emailDistributionListLanguage.TranslationStatusText   (String)
                    // -----------------------------------

                    emailDistributionListLanguage = null;
                    emailDistributionListLanguage = GetFilledRandomEmailDistributionListLanguage("");
                    emailDistributionListLanguage.TranslationStatusText = GetRandomString("", 101);
                    Assert.AreEqual(false, emailDistributionListLanguageService.Add(emailDistributionListLanguage));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListLanguageTranslationStatusText, "100"), emailDistributionListLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, emailDistributionListLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListLanguage.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // emailDistributionListLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void EmailDistributionListLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    EmailDistributionListLanguageService emailDistributionListLanguageService = new EmailDistributionListLanguageService(LanguageRequest, dbTestDB, ContactID);
                    EmailDistributionListLanguage emailDistributionListLanguage = (from c in emailDistributionListLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(emailDistributionListLanguage);

                    EmailDistributionListLanguage emailDistributionListLanguageRet = emailDistributionListLanguageService.GetEmailDistributionListLanguageWithEmailDistributionListLanguageID(emailDistributionListLanguage.EmailDistributionListLanguageID);
                    Assert.IsNotNull(emailDistributionListLanguageRet.EmailDistributionListLanguageID);
                    Assert.IsNotNull(emailDistributionListLanguageRet.EmailDistributionListID);
                    Assert.IsNotNull(emailDistributionListLanguageRet.Language);
                    Assert.IsNotNull(emailDistributionListLanguageRet.RegionName);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageRet.RegionName));
                    Assert.IsNotNull(emailDistributionListLanguageRet.TranslationStatus);
                    Assert.IsNotNull(emailDistributionListLanguageRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(emailDistributionListLanguageRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(emailDistributionListLanguageRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageRet.LastUpdateContactTVText));
                    Assert.IsNotNull(emailDistributionListLanguageRet.LanguageText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageRet.LanguageText));
                    Assert.IsNotNull(emailDistributionListLanguageRet.TranslationStatusText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(emailDistributionListLanguageRet.TranslationStatusText));
                    Assert.IsNotNull(emailDistributionListLanguageRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
