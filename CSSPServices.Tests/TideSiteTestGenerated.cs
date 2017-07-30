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
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteID = 0;
            tideSiteService.Update(tideSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteTideSiteID), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.TideSite)]
            // tideSite.TideSiteTVItemID   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteTVItemID = 0;
            tideSiteService.Add(tideSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideSiteTideSiteTVItemID, tideSite.TideSiteTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteTVItemID = 1;
            tideSiteService.Add(tideSite);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideSiteTideSiteTVItemID, "TideSite"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


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
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.WebTideModel = GetRandomString("", 101);
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideSiteWebTideModel, "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(-100, 100)]
            // tideSite.WebTideDatum_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [WebTideDatum_m]

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.WebTideDatum_m = -101.0D;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());
            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.WebTideDatum_m = 101.0D;
            Assert.AreEqual(false, tideSiteService.Add(tideSite));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tideSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tideSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tideSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.LastUpdateContactTVItemID = 0;
            tideSiteService.Add(tideSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideSiteLastUpdateContactTVItemID, tideSite.LastUpdateContactTVItemID.ToString()), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.LastUpdateContactTVItemID = 1;
            tideSiteService.Add(tideSite);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideSiteLastUpdateContactTVItemID, "Contact"), tideSite.ValidationResults.FirstOrDefault().ErrorMessage);


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
