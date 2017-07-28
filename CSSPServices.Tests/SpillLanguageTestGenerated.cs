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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class SpillLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SpillLanguageService spillLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageTest() : base()
        {
            spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = language;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;

            return spillLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void SpillLanguage_Testing()
        {

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
            // [CSSPExist(TypeName = "Spill", Plurial = "s", FieldID = "SpillID", TVType = TVTypeEnum.Error)]
            // spillLanguage.SpillID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillID = 0;
            spillLanguageService.Add(spillLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.Spill, ModelsRes.SpillLanguageSpillID, spillLanguage.SpillID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            // SpillID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.Language   (LanguageEnum)
            // -----------------------------------

            // Language will automatically be initialized at 0 --> not null


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
            Assert.AreEqual(0, spillLanguageService.GetRead().Count());


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            // TranslationStatus will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spillLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // spillLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateContactTVItemID = 0;
            spillLanguageService.Add(spillLanguage);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLanguageLastUpdateContactTVItemID, spillLanguage.LastUpdateContactTVItemID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // spillLanguage.Spill   (Spill)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // spillLanguage.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
