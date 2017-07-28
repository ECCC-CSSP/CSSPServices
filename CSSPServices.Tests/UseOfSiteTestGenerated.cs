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
        private UseOfSiteService useOfSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteTest() : base()
        {
            useOfSiteService = new UseOfSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private UseOfSite GetFilledRandomUseOfSite(string OmitPropName)
        {
            UseOfSite useOfSite = new UseOfSite();

            if (OmitPropName != "SiteTVItemID") useOfSite.SiteTVItemID = 2;
            if (OmitPropName != "SubsectorTVItemID") useOfSite.SubsectorTVItemID = 11;
            if (OmitPropName != "SiteType") useOfSite.SiteType = (SiteTypeEnum)GetRandomEnumType(typeof(SiteTypeEnum));
            if (OmitPropName != "Ordinal") useOfSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "StartYear") useOfSite.StartYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "EndYear") useOfSite.EndYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "UseWeight") useOfSite.UseWeight = true;
            if (OmitPropName != "Weight_perc") useOfSite.Weight_perc = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "UseEquation") useOfSite.UseEquation = true;
            if (OmitPropName != "Param1") useOfSite.Param1 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param2") useOfSite.Param2 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param3") useOfSite.Param3 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param4") useOfSite.Param4 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") useOfSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") useOfSite.LastUpdateContactTVItemID = 2;

            return useOfSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void UseOfSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            UseOfSite useOfSite = GetFilledRandomUseOfSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = useOfSiteService.GetRead().Count();

            useOfSiteService.Add(useOfSite);
            if (useOfSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, useOfSiteService.GetRead().Where(c => c == useOfSite).Any());
            useOfSiteService.Update(useOfSite);
            if (useOfSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, useOfSiteService.GetRead().Count());
            useOfSiteService.Delete(useOfSite);
            if (useOfSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // useOfSite.UseOfSiteID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.UseOfSiteID = 0;
            useOfSiteService.Update(useOfSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteUseOfSiteID), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // useOfSite.SiteTVItemID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.SiteTVItemID = 0;
            useOfSiteService.Add(useOfSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteSiteTVItemID, useOfSite.SiteTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // SiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
            // useOfSite.SubsectorTVItemID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.SubsectorTVItemID = 0;
            useOfSiteService.Add(useOfSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteSubsectorTVItemID, useOfSite.SubsectorTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // SubsectorTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // useOfSite.SiteType   (SiteTypeEnum)
            // -----------------------------------

            // SiteType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // useOfSite.Ordinal   (Int32)
            // -----------------------------------

            // Ordinal will automatically be initialized at 0 --> not null

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            useOfSite.Ordinal = 0;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            useOfSite.Ordinal = 1;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            useOfSite.Ordinal = -1;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, useOfSite.Ordinal);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            useOfSite.Ordinal = 1000;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1000, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            useOfSite.Ordinal = 999;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(999, useOfSite.Ordinal);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            useOfSite.Ordinal = 1001;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, useOfSite.Ordinal);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(1980, 2050)]
            // useOfSite.StartYear   (Int32)
            // -----------------------------------

            // StartYear will automatically be initialized at 0 --> not null

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // StartYear has Min [1980] and Max [2050]. At Min should return true and no errors
            useOfSite.StartYear = 1980;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1980, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Min + 1 should return true and no errors
            useOfSite.StartYear = 1981;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1981, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Min - 1 should return false with one error
            useOfSite.StartYear = 1979;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050")).Any());
            Assert.AreEqual(1979, useOfSite.StartYear);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Max should return true and no errors
            useOfSite.StartYear = 2050;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2050, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Max - 1 should return true and no errors
            useOfSite.StartYear = 2049;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2049, useOfSite.StartYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // StartYear has Min [1980] and Max [2050]. At Max + 1 should return false with one error
            useOfSite.StartYear = 2051;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050")).Any());
            Assert.AreEqual(2051, useOfSite.StartYear);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(1980, 2050)]
            // useOfSite.EndYear   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // EndYear has Min [1980] and Max [2050]. At Min should return true and no errors
            useOfSite.EndYear = 1980;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1980, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Min + 1 should return true and no errors
            useOfSite.EndYear = 1981;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1981, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Min - 1 should return false with one error
            useOfSite.EndYear = 1979;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050")).Any());
            Assert.AreEqual(1979, useOfSite.EndYear);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Max should return true and no errors
            useOfSite.EndYear = 2050;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2050, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Max - 1 should return true and no errors
            useOfSite.EndYear = 2049;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(2049, useOfSite.EndYear);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // EndYear has Min [1980] and Max [2050]. At Max + 1 should return false with one error
            useOfSite.EndYear = 2051;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050")).Any());
            Assert.AreEqual(2051, useOfSite.EndYear);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // useOfSite.UseWeight   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // useOfSite.Weight_perc   (Double)
            // -----------------------------------

            //Error: Type not implemented [Weight_perc]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Weight_perc has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            useOfSite.Weight_perc = 0.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, useOfSite.Weight_perc);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Weight_perc has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            useOfSite.Weight_perc = 1.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, useOfSite.Weight_perc);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Weight_perc has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            useOfSite.Weight_perc = -1.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteWeight_perc, "0", "100")).Any());
            Assert.AreEqual(-1.0D, useOfSite.Weight_perc);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Weight_perc has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            useOfSite.Weight_perc = 100.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(100.0D, useOfSite.Weight_perc);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Weight_perc has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            useOfSite.Weight_perc = 99.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(99.0D, useOfSite.Weight_perc);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Weight_perc has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            useOfSite.Weight_perc = 101.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteWeight_perc, "0", "100")).Any());
            Assert.AreEqual(101.0D, useOfSite.Weight_perc);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // useOfSite.UseEquation   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // useOfSite.Param1   (Double)
            // -----------------------------------

            //Error: Type not implemented [Param1]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Param1 has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            useOfSite.Param1 = 0.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, useOfSite.Param1);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param1 has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            useOfSite.Param1 = 1.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, useOfSite.Param1);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param1 has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            useOfSite.Param1 = -1.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam1, "0", "100")).Any());
            Assert.AreEqual(-1.0D, useOfSite.Param1);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param1 has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            useOfSite.Param1 = 100.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(100.0D, useOfSite.Param1);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param1 has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            useOfSite.Param1 = 99.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(99.0D, useOfSite.Param1);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param1 has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            useOfSite.Param1 = 101.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam1, "0", "100")).Any());
            Assert.AreEqual(101.0D, useOfSite.Param1);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // useOfSite.Param2   (Double)
            // -----------------------------------

            //Error: Type not implemented [Param2]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Param2 has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            useOfSite.Param2 = 0.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, useOfSite.Param2);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param2 has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            useOfSite.Param2 = 1.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, useOfSite.Param2);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param2 has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            useOfSite.Param2 = -1.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam2, "0", "100")).Any());
            Assert.AreEqual(-1.0D, useOfSite.Param2);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param2 has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            useOfSite.Param2 = 100.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(100.0D, useOfSite.Param2);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param2 has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            useOfSite.Param2 = 99.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(99.0D, useOfSite.Param2);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param2 has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            useOfSite.Param2 = 101.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam2, "0", "100")).Any());
            Assert.AreEqual(101.0D, useOfSite.Param2);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // useOfSite.Param3   (Double)
            // -----------------------------------

            //Error: Type not implemented [Param3]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Param3 has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            useOfSite.Param3 = 0.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, useOfSite.Param3);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param3 has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            useOfSite.Param3 = 1.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, useOfSite.Param3);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param3 has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            useOfSite.Param3 = -1.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam3, "0", "100")).Any());
            Assert.AreEqual(-1.0D, useOfSite.Param3);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param3 has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            useOfSite.Param3 = 100.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(100.0D, useOfSite.Param3);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param3 has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            useOfSite.Param3 = 99.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(99.0D, useOfSite.Param3);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param3 has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            useOfSite.Param3 = 101.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam3, "0", "100")).Any());
            Assert.AreEqual(101.0D, useOfSite.Param3);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 100)]
            // useOfSite.Param4   (Double)
            // -----------------------------------

            //Error: Type not implemented [Param4]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            // Param4 has Min [0.0D] and Max [100.0D]. At Min should return true and no errors
            useOfSite.Param4 = 0.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(0.0D, useOfSite.Param4);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param4 has Min [0.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            useOfSite.Param4 = 1.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(1.0D, useOfSite.Param4);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param4 has Min [0.0D] and Max [100.0D]. At Min - 1 should return false with one error
            useOfSite.Param4 = -1.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam4, "0", "100")).Any());
            Assert.AreEqual(-1.0D, useOfSite.Param4);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param4 has Min [0.0D] and Max [100.0D]. At Max should return true and no errors
            useOfSite.Param4 = 100.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(100.0D, useOfSite.Param4);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param4 has Min [0.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            useOfSite.Param4 = 99.0D;
            Assert.AreEqual(true, useOfSiteService.Add(useOfSite));
            Assert.AreEqual(0, useOfSite.ValidationResults.Count());
            Assert.AreEqual(99.0D, useOfSite.Param4);
            Assert.AreEqual(true, useOfSiteService.Delete(useOfSite));
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());
            // Param4 has Min [0.0D] and Max [100.0D]. At Max + 1 should return false with one error
            useOfSite.Param4 = 101.0D;
            Assert.AreEqual(false, useOfSiteService.Add(useOfSite));
            Assert.IsTrue(useOfSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam4, "0", "100")).Any());
            Assert.AreEqual(101.0D, useOfSite.Param4);
            Assert.AreEqual(count, useOfSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // useOfSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // useOfSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.LastUpdateContactTVItemID = 0;
            useOfSiteService.Add(useOfSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteLastUpdateContactTVItemID, useOfSite.LastUpdateContactTVItemID.ToString()), useOfSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // useOfSite.SiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // useOfSite.SubsectorTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // useOfSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
