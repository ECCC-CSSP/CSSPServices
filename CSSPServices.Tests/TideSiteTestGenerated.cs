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
    public partial class TideSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TideSiteService tideSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteTest() : base()
        {
            tideSiteService = new TideSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 13;
            if (OmitPropName != "WebTideModel") tideSite.WebTideModel = GetRandomString("", 5);
            if (OmitPropName != "WebTideDatum_m") tideSite.WebTideDatum_m = GetRandomDouble(-100.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            return tideSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TideSite tideSite = GetFilledRandomTideSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tideSiteService.GetRead().Count();

            tideSiteService.Add(tideSite);
            if (tideSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tideSiteService.GetRead().Where(c => c == tideSite).Any());
            tideSiteService.Update(tideSite);
            if (tideSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tideSiteService.GetRead().Count());
            tideSiteService.Delete(tideSite);
            if (tideSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tideSite.TideSiteID   (Int32)
            // -----------------------------------

            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteID = 0;
            tideSiteService.Update(tideSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteTideSiteID), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.TideSite)]
            // [Range(1, -1)]
            // tideSite.TideSiteTVItemID   (Int32)
            // -----------------------------------

            // TideSiteTVItemID will automatically be initialized at 0 --> not null


            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideSite.TideSiteTVItemID = 1;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(1, tideSite.TideSiteTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideSite.TideSiteTVItemID = 2;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(2, tideSite.TideSiteTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideSite.TideSiteTVItemID = 0;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideSiteTideSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, tideSite.TideSiteTVItemID);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // tideSite.WebTideModel   (String)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("WebTideModel");
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.AreEqual(1, tideSite.ValidationResults.Count());
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteWebTideModel)).Any());
            Assert.AreEqual(null, tideSite.WebTideModel);
            Assert.AreEqual(0, tideSiteService.GetRead().Count());


            tideSite = null;
            tideSite = GetFilledRandomTideSite("");

            // WebTideModel has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string tideSiteWebTideModelMin = GetRandomString("", 100);
            tideSite.WebTideModel = tideSiteWebTideModelMin;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(tideSiteWebTideModelMin, tideSite.WebTideModel);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // WebTideModel has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            tideSiteWebTideModelMin = GetRandomString("", 99);
            tideSite.WebTideModel = tideSiteWebTideModelMin;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(tideSiteWebTideModelMin, tideSite.WebTideModel);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // WebTideModel has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            tideSiteWebTideModelMin = GetRandomString("", 101);
            tideSite.WebTideModel = tideSiteWebTideModelMin;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideSiteWebTideModel, "100")).Any());
            Assert.AreEqual(tideSiteWebTideModelMin, tideSite.WebTideModel);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-100, 100)]
            // tideSite.WebTideDatum_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [WebTideDatum_m]


            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            // WebTideDatum_m has Min [-100.0D] and Max [100.0D]. At Min should return true and no errors
            tideSite.WebTideDatum_m = -100.0D;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(-100.0D, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100.0D] and Max [100.0D]. At Min + 1 should return true and no errors
            tideSite.WebTideDatum_m = -99.0D;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(-99.0D, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100.0D] and Max [100.0D]. At Min - 1 should return false with one error
            tideSite.WebTideDatum_m = -101.0D;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100")).Any());
            Assert.AreEqual(-101.0D, tideSite.WebTideDatum_m);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100.0D] and Max [100.0D]. At Max should return true and no errors
            tideSite.WebTideDatum_m = 100.0D;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(100.0D, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100.0D] and Max [100.0D]. At Max - 1 should return true and no errors
            tideSite.WebTideDatum_m = 99.0D;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(99.0D, tideSite.WebTideDatum_m);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // WebTideDatum_m has Min [-100.0D] and Max [100.0D]. At Max + 1 should return false with one error
            tideSite.WebTideDatum_m = 101.0D;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100")).Any());
            Assert.AreEqual(101.0D, tideSite.WebTideDatum_m);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tideSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // tideSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideSite.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(1, tideSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideSite.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tideSiteService.Add(tideSite));
            Assert.AreEqual(0, tideSite.ValidationResults.Count());
            Assert.AreEqual(2, tideSite.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideSiteService.Delete(tideSite));
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideSite.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.IsTrue(tideSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideSiteLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tideSite.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tideSite.TideSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tideSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
