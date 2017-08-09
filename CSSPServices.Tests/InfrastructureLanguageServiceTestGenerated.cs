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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 1;
            if (OmitPropName != "Language") infrastructureLanguage.Language = LanguageRequest;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") infrastructureLanguage.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") infrastructureLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") infrastructureLanguage.TranslationStatusText = GetRandomString("", 5);

            return infrastructureLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void InfrastructureLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, dbTestDB, ContactID);

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

                count = infrastructureLanguageService.GetRead().Count();

                infrastructureLanguageService.Add(infrastructureLanguage);
                if (infrastructureLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, infrastructureLanguageService.GetRead().Where(c => c == infrastructureLanguage).Any());
                infrastructureLanguageService.Update(infrastructureLanguage);
                if (infrastructureLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, infrastructureLanguageService.GetRead().Count());
                infrastructureLanguageService.Delete(infrastructureLanguage);
                if (infrastructureLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageInfrastructureLanguageID), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID", AllowableTVtypeList = Error)]
                // infrastructureLanguage.InfrastructureID   (Int32)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.InfrastructureID = 0;
                infrastructureLanguageService.Add(infrastructureLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Infrastructure, ModelsRes.InfrastructureLanguageInfrastructureID, infrastructureLanguage.InfrastructureID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // infrastructureLanguage.Language   (LanguageEnum)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.Language = (LanguageEnum)1000000;
                infrastructureLanguageService.Add(infrastructureLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageLanguage), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // infrastructureLanguage.Comment   (String)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
                Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
                Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageComment)).Any());
                Assert.AreEqual(null, infrastructureLanguage.Comment);
                Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // infrastructureLanguage.TranslationStatus   (TranslationStatusEnum)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                infrastructureLanguageService.Add(infrastructureLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageTranslationStatus), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // infrastructureLanguage.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // infrastructureLanguage.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.LastUpdateContactTVItemID = 0;
                infrastructureLanguageService.Add(infrastructureLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.LastUpdateContactTVItemID = 1;
                infrastructureLanguageService.Add(infrastructureLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "Contact"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // infrastructureLanguage.LastUpdateContactTVText   (String)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLanguageLastUpdateContactTVText, "200"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructureLanguage.LanguageText   (String)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLanguageLanguageText, "100"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // infrastructureLanguage.TranslationStatusText   (String)
                // -----------------------------------

                infrastructureLanguage = null;
                infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                infrastructureLanguage.TranslationStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.InfrastructureLanguageTranslationStatusText, "100"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // infrastructureLanguage.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void InfrastructureLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, dbTestDB, ContactID);
                InfrastructureLanguage infrastructureLanguage = (from c in infrastructureLanguageService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(infrastructureLanguage);

                InfrastructureLanguage infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                Assert.IsNotNull(infrastructureLanguageRet.InfrastructureLanguageID);
                Assert.IsNotNull(infrastructureLanguageRet.InfrastructureID);
                Assert.IsNotNull(infrastructureLanguageRet.Language);
                Assert.IsNotNull(infrastructureLanguageRet.Comment);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.Comment));
                Assert.IsNotNull(infrastructureLanguageRet.TranslationStatus);
                Assert.IsNotNull(infrastructureLanguageRet.LastUpdateDate_UTC);
                Assert.IsNotNull(infrastructureLanguageRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(infrastructureLanguageRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.LastUpdateContactTVText));
                Assert.IsNotNull(infrastructureLanguageRet.LanguageText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.LanguageText));
                Assert.IsNotNull(infrastructureLanguageRet.TranslationStatusText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageRet.TranslationStatusText));
            }
        }
        #endregion Tests Get With Key

    }
}
