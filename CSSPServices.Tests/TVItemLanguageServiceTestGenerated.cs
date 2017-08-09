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
    public partial class TVItemLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemLanguageService tvItemLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageServiceTest() : base()
        {
            //tvItemLanguageService = new TVItemLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemLanguage GetFilledRandomTVItemLanguage(string OmitPropName)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            if (OmitPropName != "TVItemID") tvItemLanguage.TVItemID = 1;
            if (OmitPropName != "Language") tvItemLanguage.Language = LanguageRequest;
            if (OmitPropName != "TVText") tvItemLanguage.TVText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") tvItemLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LastUpdateContactTVText") tvItemLanguage.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "LanguageText") tvItemLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") tvItemLanguage.TranslationStatusText = GetRandomString("", 5);

            return tvItemLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                TVItemLanguage tvItemLanguage = GetFilledRandomTVItemLanguage("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = tvItemLanguageService.GetRead().Count();

                tvItemLanguageService.Add(tvItemLanguage);
                if (tvItemLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tvItemLanguageService.GetRead().Where(c => c == tvItemLanguage).Any());
                tvItemLanguageService.Update(tvItemLanguage);
                if (tvItemLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tvItemLanguageService.GetRead().Count());
                tvItemLanguageService.Delete(tvItemLanguage);
                if (tvItemLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // tvItemLanguage.TVItemLanguageID   (Int32)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.TVItemLanguageID = 0;
                tvItemLanguageService.Update(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVItemLanguageID), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemLanguage.TVItemID   (Int32)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.TVItemID = 0;
                tvItemLanguageService.Add(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageTVItemID, tvItemLanguage.TVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.TVItemID = 2;
                tvItemLanguageService.Add(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLanguageTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvItemLanguage.Language   (LanguageEnum)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.Language = (LanguageEnum)1000000;
                tvItemLanguageService.Add(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageLanguage), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(200))]
                // tvItemLanguage.TVText   (String)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("TVText");
                Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                Assert.AreEqual(1, tvItemLanguage.ValidationResults.Count());
                Assert.IsTrue(tvItemLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTVText)).Any());
                Assert.AreEqual(null, tvItemLanguage.TVText);
                Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.TVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTVText, "200"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvItemLanguage.TranslationStatus   (TranslationStatusEnum)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                tvItemLanguageService.Add(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLanguageTranslationStatus), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // tvItemLanguage.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // tvItemLanguage.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.LastUpdateContactTVItemID = 0;
                tvItemLanguageService.Add(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, tvItemLanguage.LastUpdateContactTVItemID.ToString()), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.LastUpdateContactTVItemID = 1;
                tvItemLanguageService.Add(tvItemLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLanguageLastUpdateContactTVItemID, "Contact"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemLanguage.LastUpdateContactTVText   (String)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageLastUpdateContactTVText, "200"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvItemLanguage.LanguageText   (String)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageLanguageText, "100"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvItemLanguage.TranslationStatusText   (String)
                // -----------------------------------

                tvItemLanguage = null;
                tvItemLanguage = GetFilledRandomTVItemLanguage("");
                tvItemLanguage.TranslationStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, tvItemLanguageService.Add(tvItemLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLanguageTranslationStatusText, "100"), tvItemLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tvItemLanguage.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVItemLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, dbTestDB, ContactID);
                TVItemLanguage tvItemLanguage = (from c in tvItemLanguageService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(tvItemLanguage);

                TVItemLanguage tvItemLanguageRet = tvItemLanguageService.GetTVItemLanguageWithTVItemLanguageID(tvItemLanguage.TVItemLanguageID);
                Assert.IsNotNull(tvItemLanguageRet.TVItemLanguageID);
                Assert.IsNotNull(tvItemLanguageRet.TVItemID);
                Assert.IsNotNull(tvItemLanguageRet.Language);
                Assert.IsNotNull(tvItemLanguageRet.TVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageRet.TVText));
                Assert.IsNotNull(tvItemLanguageRet.TranslationStatus);
                Assert.IsNotNull(tvItemLanguageRet.LastUpdateDate_UTC);
                Assert.IsNotNull(tvItemLanguageRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(tvItemLanguageRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageRet.LastUpdateContactTVText));
                Assert.IsNotNull(tvItemLanguageRet.LanguageText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageRet.LanguageText));
                Assert.IsNotNull(tvItemLanguageRet.TranslationStatusText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLanguageRet.TranslationStatusText));
            }
        }
        #endregion Tests Get With Key

    }
}
