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
        private MWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateTest() : base()
        {
            mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSiteStartEndDate GetFilledRandomMWQMSiteStartEndDate(string OmitPropName)
        {
            MWQMSiteStartEndDate mwqmSiteStartEndDate = new MWQMSiteStartEndDate();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSiteStartEndDate.MWQMSiteTVItemID = 19;
            if (OmitPropName != "StartDate") mwqmSiteStartEndDate.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmSiteStartEndDate.EndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;

            return mwqmSiteStartEndDate;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSiteStartEndDate_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMSiteStartEndDate mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmSiteStartEndDateService.GetRead().Count();

            mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmSiteStartEndDateService.GetRead().Where(c => c == mwqmSiteStartEndDate).Any());
            mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmSiteStartEndDateService.GetRead().Count());
            mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmSiteStartEndDateService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSiteStartEndDate.MWQMSiteStartEndDateID   (Int32)
            // -----------------------------------

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
            mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 0;
            mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.MWQMSite)]
            // mwqmSiteStartEndDate.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
            mwqmSiteStartEndDate.MWQMSiteTVItemID = 0;
            mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

            // MWQMSiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSiteStartEndDate.StartDate   (DateTime)
            // -----------------------------------

            // StartDate will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDate)]
            // mwqmSiteStartEndDate.EndDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSiteStartEndDate.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // mwqmSiteStartEndDate.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSiteStartEndDate = null;
            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
            mwqmSiteStartEndDate.LastUpdateContactTVItemID = 0;
            mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mwqmSiteStartEndDate.MWQMSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mwqmSiteStartEndDate.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
