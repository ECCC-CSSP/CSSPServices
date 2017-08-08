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
    public partial class MWQMSiteStartEndDateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateServiceTest() : base()
        {
            //mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "MWQMSiteTVText") mwqmSiteStartEndDate.MWQMSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") mwqmSiteStartEndDate.LastUpdateContactTVText = GetRandomString("", 5);

            return mwqmSiteStartEndDate;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSiteStartEndDate_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, dbTestDB, ContactID);

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
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                // mwqmSiteStartEndDate.MWQMSiteTVItemID   (Int32)
                // -----------------------------------

                mwqmSiteStartEndDate = null;
                mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                mwqmSiteStartEndDate.MWQMSiteTVItemID = 0;
                mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSiteStartEndDate = null;
                mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                mwqmSiteStartEndDate.MWQMSiteTVItemID = 1;
                mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "MWQMSite"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSiteStartEndDate.StartDate   (DateTime)
                // -----------------------------------


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


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mwqmSiteStartEndDate.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mwqmSiteStartEndDate = null;
                mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                mwqmSiteStartEndDate.LastUpdateContactTVItemID = 0;
                mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSiteStartEndDate = null;
                mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                mwqmSiteStartEndDate.LastUpdateContactTVItemID = 1;
                mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "Contact"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MWQMSiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSiteStartEndDate.MWQMSiteTVText   (String)
                // -----------------------------------

                mwqmSiteStartEndDate = null;
                mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                mwqmSiteStartEndDate.MWQMSiteTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVText, "200"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSiteStartEndDateService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSiteStartEndDate.LastUpdateContactTVText   (String)
                // -----------------------------------

                mwqmSiteStartEndDate = null;
                mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                mwqmSiteStartEndDate.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVText, "200"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSiteStartEndDateService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mwqmSiteStartEndDate.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMSiteStartEndDate_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, dbTestDB, ContactID);
                MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in mwqmSiteStartEndDateService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(mwqmSiteStartEndDate);

                MWQMSiteStartEndDate mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                Assert.AreEqual(mwqmSiteStartEndDate.MWQMSiteStartEndDateID, mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);
                Assert.AreEqual(mwqmSiteStartEndDate.MWQMSiteTVItemID, mwqmSiteStartEndDateRet.MWQMSiteTVItemID);
                Assert.AreEqual(mwqmSiteStartEndDate.StartDate, mwqmSiteStartEndDateRet.StartDate);
                Assert.AreEqual(mwqmSiteStartEndDate.EndDate, mwqmSiteStartEndDateRet.EndDate);
                Assert.AreEqual(mwqmSiteStartEndDate.LastUpdateDate_UTC, mwqmSiteStartEndDateRet.LastUpdateDate_UTC);
                Assert.AreEqual(mwqmSiteStartEndDate.LastUpdateContactTVItemID, mwqmSiteStartEndDateRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(mwqmSiteStartEndDateRet.MWQMSiteTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateRet.MWQMSiteTVText));
                Assert.IsNotNull(mwqmSiteStartEndDateRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteStartEndDateRet.LastUpdateContactTVText));
            }
        }
        #endregion Tests Get With Key

    }
}
