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
    public partial class InfrastructureLanguageTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private InfrastructureLanguageService infrastructureLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageTest() : base()
        {
            infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 1;
            if (OmitPropName != "Language") infrastructureLanguage.Language = language;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;

            return infrastructureLanguage;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void InfrastructureLanguage_Testing()
        {

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


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // infrastructureLanguage.InfrastructureLanguageID   (Int32)
            //-----------------------------------
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.InfrastructureLanguageID = 0;
            infrastructureLanguageService.Update(infrastructureLanguage);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageInfrastructureLanguageID), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "Infrastructure", Plurial = "s", FieldID = "InfrastructureID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // infrastructureLanguage.InfrastructureID   (Int32)
            //-----------------------------------
            // InfrastructureID will automatically be initialized at 0 --> not null


            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            // InfrastructureID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructureLanguage.InfrastructureID = 1;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(1, infrastructureLanguage.InfrastructureID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());
            // InfrastructureID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructureLanguage.InfrastructureID = 2;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(2, infrastructureLanguage.InfrastructureID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());
            // InfrastructureID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructureLanguage.InfrastructureID = 0;
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLanguageInfrastructureID, "1")).Any());
            Assert.AreEqual(0, infrastructureLanguage.InfrastructureID);
            Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // infrastructureLanguage.Language   (LanguageEnum)
            //-----------------------------------
            // Language will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            // infrastructureLanguage.Comment   (String)
            //-----------------------------------
            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.InfrastructureLanguageComment)).Any());
            Assert.AreEqual(null, infrastructureLanguage.Comment);
            Assert.AreEqual(0, infrastructureLanguageService.GetRead().Count());


            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // infrastructureLanguage.TranslationStatus   (TranslationStatusEnum)
            //-----------------------------------
            // TranslationStatus will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // infrastructureLanguage.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // infrastructureLanguage.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            infrastructureLanguage.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(1, infrastructureLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            infrastructureLanguage.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.AreEqual(0, infrastructureLanguage.ValidationResults.Count());
            Assert.AreEqual(2, infrastructureLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(true, infrastructureLanguageService.Delete(infrastructureLanguage));
            Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            infrastructureLanguage.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
            Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, infrastructureLanguage.LastUpdateContactTVItemID);
            Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // infrastructureLanguage.Infrastructure   (Infrastructure)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // infrastructureLanguage.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
