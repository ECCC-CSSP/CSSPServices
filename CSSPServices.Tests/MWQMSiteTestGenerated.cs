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
    public partial class MWQMSiteTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSiteService mwqmSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteTest() : base()
        {
            mwqmSiteService = new MWQMSiteService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSite GetFilledRandomMWQMSite(string OmitPropName)
        {
            MWQMSite mwqmSite = new MWQMSite();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSite.MWQMSiteTVItemID = 19;
            if (OmitPropName != "MWQMSiteNumber") mwqmSite.MWQMSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteDescription") mwqmSite.MWQMSiteDescription = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteLatestClassification") mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)GetRandomEnumType(typeof(MWQMSiteLatestClassificationEnum));
            if (OmitPropName != "Ordinal") mwqmSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSite.LastUpdateContactTVItemID = 2;

            return mwqmSite;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSite_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMSite mwqmSite = GetFilledRandomMWQMSite("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmSiteService.GetRead().Count();

            mwqmSiteService.Add(mwqmSite);
            if (mwqmSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmSiteService.GetRead().Where(c => c == mwqmSite).Any());
            mwqmSiteService.Update(mwqmSite);
            if (mwqmSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmSiteService.GetRead().Count());
            mwqmSiteService.Delete(mwqmSite);
            if (mwqmSite.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSite.MWQMSiteID   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteID = 0;
            mwqmSiteService.Update(mwqmSite);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteID), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMSite)]
            // mwqmSite.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteTVItemID = 0;
            mwqmSiteService.Add(mwqmSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteMWQMSiteTVItemID, mwqmSite.MWQMSiteTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(8))]
            // mwqmSite.MWQMSiteNumber   (String)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("MWQMSiteNumber");
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteNumber)).Any());
            Assert.AreEqual(null, mwqmSite.MWQMSiteNumber);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            // MWQMSiteNumber has MinLength [empty] and MaxLength [8]. At Max should return true and no errors
            string mwqmSiteMWQMSiteNumberMin = GetRandomString("", 8);
            mwqmSite.MWQMSiteNumber = mwqmSiteMWQMSiteNumberMin;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(mwqmSiteMWQMSiteNumberMin, mwqmSite.MWQMSiteNumber);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // MWQMSiteNumber has MinLength [empty] and MaxLength [8]. At Max - 1 should return true and no errors
            mwqmSiteMWQMSiteNumberMin = GetRandomString("", 7);
            mwqmSite.MWQMSiteNumber = mwqmSiteMWQMSiteNumberMin;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(mwqmSiteMWQMSiteNumberMin, mwqmSite.MWQMSiteNumber);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // MWQMSiteNumber has MinLength [empty] and MaxLength [8]. At Max + 1 should return false with one error
            mwqmSiteMWQMSiteNumberMin = GetRandomString("", 9);
            mwqmSite.MWQMSiteNumber = mwqmSiteMWQMSiteNumberMin;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteMWQMSiteNumber, "8")).Any());
            Assert.AreEqual(mwqmSiteMWQMSiteNumberMin, mwqmSite.MWQMSiteNumber);
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(200))]
            // mwqmSite.MWQMSiteDescription   (String)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("MWQMSiteDescription");
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteDescription)).Any());
            Assert.AreEqual(null, mwqmSite.MWQMSiteDescription);
            Assert.AreEqual(0, mwqmSiteService.GetRead().Count());

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            // MWQMSiteDescription has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string mwqmSiteMWQMSiteDescriptionMin = GetRandomString("", 200);
            mwqmSite.MWQMSiteDescription = mwqmSiteMWQMSiteDescriptionMin;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(mwqmSiteMWQMSiteDescriptionMin, mwqmSite.MWQMSiteDescription);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // MWQMSiteDescription has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            mwqmSiteMWQMSiteDescriptionMin = GetRandomString("", 199);
            mwqmSite.MWQMSiteDescription = mwqmSiteMWQMSiteDescriptionMin;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(mwqmSiteMWQMSiteDescriptionMin, mwqmSite.MWQMSiteDescription);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // MWQMSiteDescription has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            mwqmSiteMWQMSiteDescriptionMin = GetRandomString("", 201);
            mwqmSite.MWQMSiteDescription = mwqmSiteMWQMSiteDescriptionMin;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteMWQMSiteDescription, "200")).Any());
            Assert.AreEqual(mwqmSiteMWQMSiteDescriptionMin, mwqmSite.MWQMSiteDescription);
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmSite.MWQMSiteLatestClassification   (MWQMSiteLatestClassificationEnum)
            // -----------------------------------

            // MWQMSiteLatestClassification will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // mwqmSite.Ordinal   (Int32)
            // -----------------------------------

            // Ordinal will automatically be initialized at 0 --> not null

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            mwqmSite.Ordinal = 0;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            mwqmSite.Ordinal = 1;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            mwqmSite.Ordinal = -1;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, mwqmSite.Ordinal);
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            mwqmSite.Ordinal = 1000;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(1000, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            mwqmSite.Ordinal = 999;
            Assert.AreEqual(true, mwqmSiteService.Add(mwqmSite));
            Assert.AreEqual(0, mwqmSite.ValidationResults.Count());
            Assert.AreEqual(999, mwqmSite.Ordinal);
            Assert.AreEqual(true, mwqmSiteService.Delete(mwqmSite));
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            mwqmSite.Ordinal = 1001;
            Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
            Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, mwqmSite.Ordinal);
            Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mwqmSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.LastUpdateContactTVItemID = 0;
            mwqmSiteService.Add(mwqmSite);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteLastUpdateContactTVItemID, mwqmSite.LastUpdateContactTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mwqmSite.MWQMSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mwqmSite.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
