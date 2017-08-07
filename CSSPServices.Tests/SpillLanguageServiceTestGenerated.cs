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
    public partial class SpillLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SpillLanguageService spillLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageServiceTest() : base()
        {
            //spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = LanguageRequest;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "LanguageText") spillLanguage.LanguageText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") spillLanguage.TranslationStatusText = GetRandomString("", 5);

            return spillLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SpillLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SpillLanguageService spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = spillLanguageService.GetRead().Count();

                spillLanguageService.Add(spillLanguage);
                if (spillLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, spillLanguageService.GetRead().Where(c => c == spillLanguage).Any());
                spillLanguageService.Update(spillLanguage);
                if (spillLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, spillLanguageService.GetRead().Count());
                spillLanguageService.Delete(spillLanguage);
                if (spillLanguage.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, spillLanguageService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // spillLanguage.SpillLanguageID   (Int32)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.SpillLanguageID = 0;
                spillLanguageService.Update(spillLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillLanguageID), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "Spill", Plurial = "s", FieldID = "SpillID", AllowableTVtypeList = Error)]
                // spillLanguage.SpillID   (Int32)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.SpillID = 0;
                spillLanguageService.Add(spillLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Spill, ModelsRes.SpillLanguageSpillID, spillLanguage.SpillID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // spillLanguage.Language   (LanguageEnum)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.Language = (LanguageEnum)1000000;
                spillLanguageService.Add(spillLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageLanguage), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // spillLanguage.SpillComment   (String)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
                Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
                Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
                Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageSpillComment)).Any());
                Assert.AreEqual(null, spillLanguage.SpillComment);
                Assert.AreEqual(count, spillLanguageService.GetRead().Count());


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // spillLanguage.TranslationStatus   (TranslationStatusEnum)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                spillLanguageService.Add(spillLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLanguageTranslationStatus), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // spillLanguage.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // spillLanguage.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.LastUpdateContactTVItemID = 0;
                spillLanguageService.Add(spillLanguage);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLanguageLastUpdateContactTVItemID, spillLanguage.LastUpdateContactTVItemID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.LastUpdateContactTVItemID = 1;
                spillLanguageService.Add(spillLanguage);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SpillLanguageLastUpdateContactTVItemID, "Contact"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // spillLanguage.LanguageText   (String)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.LanguageText = GetRandomString("", 101);
                Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillLanguageLanguageText, "100"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, spillLanguageService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // spillLanguage.TranslationStatusText   (String)
                // -----------------------------------

                spillLanguage = null;
                spillLanguage = GetFilledRandomSpillLanguage("");
                spillLanguage.TranslationStatusText = GetRandomString("", 101);
                Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillLanguageTranslationStatusText, "100"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, spillLanguageService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // spillLanguage.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void SpillLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                SpillLanguageService spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);

                SpillLanguage spillLanguage = (from c in spillLanguageService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(spillLanguage);

                SpillLanguage spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                Assert.AreEqual(spillLanguage.SpillLanguageID, spillLanguageRet.SpillLanguageID);
            }
        }
        #endregion Tests Get With Key

    }
}
