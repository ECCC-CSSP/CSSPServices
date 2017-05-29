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
    public partial class MWQMSiteStartEndDateTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMSiteStartEndDateID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSiteStartEndDate GetFilledRandomMWQMSiteStartEndDate(string OmitPropName)
        {
            MWQMSiteStartEndDateID += 1;

            MWQMSiteStartEndDate mwqmSiteStartEndDate = new MWQMSiteStartEndDate();

            if (OmitPropName != "MWQMSiteStartEndDateID") mwqmSiteStartEndDate.MWQMSiteStartEndDateID = MWQMSiteStartEndDateID;
            if (OmitPropName != "MWQMSiteTVItemID") mwqmSiteStartEndDate.MWQMSiteTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "StartDate") mwqmSiteStartEndDate.StartDate = GetRandomDateTime();
            if (OmitPropName != "EndDate") mwqmSiteStartEndDate.EndDate = GetRandomDateTime();
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSiteStartEndDate.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSiteStartEndDate.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmSiteStartEndDate;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSiteStartEndDate_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MWQMSiteStartEndDate mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(true, mwqmSiteStartEndDateService.GetRead().Where(c => c == mwqmSiteStartEndDate).Any());
            mwqmSiteStartEndDate.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate));
            Assert.AreEqual(1, mwqmSiteStartEndDateService.GetRead().Count());
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("StartDate");
            Assert.AreEqual(false, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(1, mwqmSiteStartEndDate.ValidationResults.Count());
            Assert.IsTrue(mwqmSiteStartEndDate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateStartDate)).Any());
            Assert.IsTrue(mwqmSiteStartEndDate.StartDate.Year < 1900);
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(1, mwqmSiteStartEndDate.ValidationResults.Count());
            Assert.IsTrue(mwqmSiteStartEndDate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMSiteStartEndDateID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MWQMSiteTVItemID] of type [int]
            //-----------------------------------

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSiteStartEndDate.MWQMSiteTVItemID = 1;
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDate.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSiteStartEndDate.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSiteStartEndDate.MWQMSiteTVItemID = 2;
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDate.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSiteStartEndDate.MWQMSiteTVItemID);
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());
            // MWQMSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSiteStartEndDate.MWQMSiteTVItemID = 0;
            Assert.AreEqual(false, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.IsTrue(mwqmSiteStartEndDate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSiteStartEndDate.MWQMSiteTVItemID);
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());

            //-----------------------------------
            // doing property [StartDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDate] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSiteStartEndDate.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDate.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSiteStartEndDate.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDate.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSiteStartEndDate.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate));
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSiteStartEndDate.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
            Assert.IsTrue(mwqmSiteStartEndDate.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSiteStartEndDate.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmSiteStartEndDateService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
