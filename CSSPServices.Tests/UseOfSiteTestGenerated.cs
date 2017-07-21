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
    public partial class UseOfSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int UseOfSiteID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private UseOfSite GetFilledRandomUseOfSite(string OmitPropName)
        {
            UseOfSiteID += 1;

            UseOfSite useOfSite = new UseOfSite();

            if (OmitPropName != "UseOfSiteID") useOfSite.UseOfSiteID = UseOfSiteID;
            if (OmitPropName != "SiteTVItemID") useOfSite.SiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "SubsectorTVItemID") useOfSite.SubsectorTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "SiteType") useOfSite.SiteType = (SiteTypeEnum)GetRandomEnumType(typeof(SiteTypeEnum));
            if (OmitPropName != "Ordinal") useOfSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "StartYear") useOfSite.StartYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "EndYear") useOfSite.EndYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "UseWeight") useOfSite.UseWeight = true;
            if (OmitPropName != "Weight_perc") useOfSite.Weight_perc = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "UseEquation") useOfSite.UseEquation = true;
            if (OmitPropName != "Param1") useOfSite.Param1 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Param2") useOfSite.Param2 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Param3") useOfSite.Param3 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "Param4") useOfSite.Param4 = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") useOfSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") useOfSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return useOfSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void UseOfSite_Testing()
        {
            SetupTestHelper(culture);
            UseOfSiteService useOfSiteService = new UseOfSiteService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            UseOfSite useOfSite = GetFilledRandomUseOfSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(true, useOfSiteService.GetRead().Where(c => c == useOfSite).Any());
            useOfSite.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, useOfSiteService.Update(useOfSite));
            Assert.AreEqual(1, useOfSiteService.GetRead().Count());
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // SiteTVItemID will automatically be initialized at 0 --> not null

            // SubsectorTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [SiteType]

            // Ordinal will automatically be initialized at 0 --> not null

            // StartYear will automatically be initialized at 0 --> not null

            //Error: Type not implemented [Weight_perc]

            //Error: Type not implemented [Param1]

            //Error: Type not implemented [Param2]

            //Error: Type not implemented [Param3]

            //Error: Type not implemented [Param4]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("LastUpdateDate_UTC");
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(1, useOfSite.ValidationResults.Count());
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteLastUpdateDate_UTC)).Any());
            Assert.IsTrue(useOfSite.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [SiteTVItem]

            //Error: Type not implemented [SubsectorTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [UseOfSiteID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [SiteTVItemID] of type [Int32]
            //-----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // SiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            useOfSite.SiteTVItemID = 1;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1, useOfSite.SiteTVItemID);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // SiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            useOfSite.SiteTVItemID = 2;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2, useOfSite.SiteTVItemID);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // SiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            useOfSite.SiteTVItemID = 0;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.UseOfSiteSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, useOfSite.SiteTVItemID);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [SubsectorTVItemID] of type [Int32]
            //-----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            useOfSite.SubsectorTVItemID = 1;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1, useOfSite.SubsectorTVItemID);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            useOfSite.SubsectorTVItemID = 2;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2, useOfSite.SubsectorTVItemID);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // SubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            useOfSite.SubsectorTVItemID = 0;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.UseOfSiteSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, useOfSite.SubsectorTVItemID);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [SiteType] of type [SiteTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Ordinal] of type [Int32]
            //-----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            useOfSite.Ordinal = 0;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            useOfSite.Ordinal = 1;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            useOfSite.Ordinal = -1;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, useOfSite.Ordinal);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            useOfSite.Ordinal = 1000;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1000, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            useOfSite.Ordinal = 999;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(999, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            useOfSite.Ordinal = 1001;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, useOfSite.Ordinal);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [StartYear] of type [Int32]
            //-----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // StartYear has Min [1980] and Max [2050]. At Min should return true and no errors
            useOfSite.StartYear = 1980;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1980, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Min + 1 should return true and no errors
            useOfSite.StartYear = 1981;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1981, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Min - 1 should return false with one error
            useOfSite.StartYear = 1979;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050")).Any());
            Assert.AreEqual(1979, useOfSite.StartYear);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Max should return true and no errors
            useOfSite.StartYear = 2050;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2050, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Max - 1 should return true and no errors
            useOfSite.StartYear = 2049;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2049, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Max + 1 should return false with one error
            useOfSite.StartYear = 2051;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050")).Any());
            Assert.AreEqual(2051, useOfSite.StartYear);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [EndYear] of type [Int32]
            //-----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // EndYear has Min [1980] and Max [2050]. At Min should return true and no errors
            useOfSite.EndYear = 1980;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1980, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Min + 1 should return true and no errors
            useOfSite.EndYear = 1981;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1981, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Min - 1 should return false with one error
            useOfSite.EndYear = 1979;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050")).Any());
            Assert.AreEqual(1979, useOfSite.EndYear);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Max should return true and no errors
            useOfSite.EndYear = 2050;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2050, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Max - 1 should return true and no errors
            useOfSite.EndYear = 2049;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2049, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Max + 1 should return false with one error
            useOfSite.EndYear = 2051;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050")).Any());
            Assert.AreEqual(2051, useOfSite.EndYear);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [UseWeight] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [Weight_perc] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [UseEquation] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [Param1] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Param2] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Param3] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [Param4] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            useOfSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1, useOfSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            useOfSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2, useOfSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            useOfSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.UseOfSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, useOfSite.LastUpdateContactTVItemID);
            Assert.AreEqual(0, useOfSiteService.GetRead().Count());

            //-----------------------------------
            // doing property [SiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [SubsectorTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
