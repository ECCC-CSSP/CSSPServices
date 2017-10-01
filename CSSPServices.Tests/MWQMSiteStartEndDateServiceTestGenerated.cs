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

            // Need to implement (no items found, would need to add at least one in the TestDB) [MWQMSiteStartEndDate MWQMSiteTVItemID TVItem TVItemID]
            if (OmitPropName != "StartDate") mwqmSiteStartEndDate.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmSiteStartEndDate.EndDate = new DateTime(2005, 3, 7);
            //Error: property [MWQMSiteStartEndDateWeb] and type [MWQMSiteStartEndDate] is  not implemented
            //Error: property [MWQMSiteStartEndDateReport] and type [MWQMSiteStartEndDate] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") mwqmSiteStartEndDate.HasErrors = true;

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
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

                    Assert.AreEqual(mwqmSiteStartEndDateService.GetRead().Count(), mwqmSiteStartEndDateService.GetEdit().Count());

                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    if (mwqmSiteStartEndDate.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmSiteStartEndDateService.GetRead().Where(c => c == mwqmSiteStartEndDate).Any());
                    mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
                    if (mwqmSiteStartEndDate.HasErrors)
                    {
                        Assert.AreEqual("", mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmSiteStartEndDateService.GetRead().Count());
                    mwqmSiteStartEndDateService.Delete(mwqmSiteStartEndDate);
                    if (mwqmSiteStartEndDate.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 10000000;
                    mwqmSiteStartEndDateService.Update(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSiteStartEndDate, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID, mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSiteStartEndDate.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteTVItemID = 0;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.MWQMSiteTVItemID = 1;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "MWQMSite"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.MWQMSiteStartEndDateWeb   (MWQMSiteStartEndDateWeb)
                    // -----------------------------------

                    //Error: Type not implemented [MWQMSiteStartEndDateWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.MWQMSiteStartEndDateReport   (MWQMSiteStartEndDateReport)
                    // -----------------------------------

                    //Error: Type not implemented [MWQMSiteStartEndDateReport]


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
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSiteStartEndDate = null;
                    mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");
                    mwqmSiteStartEndDate.LastUpdateContactTVItemID = 1;
                    mwqmSiteStartEndDateService.Add(mwqmSiteStartEndDate);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "Contact"), mwqmSiteStartEndDate.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSiteStartEndDate.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteStartEndDateService mwqmSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, dbTestDB, ContactID);
                    MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in mwqmSiteStartEndDateService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSiteStartEndDate);

                    MWQMSiteStartEndDate mwqmSiteStartEndDateRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmSiteStartEndDateRet = mwqmSiteStartEndDateService.GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(mwqmSiteStartEndDate.MWQMSiteStartEndDateID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(mwqmSiteStartEndDateRet.MWQMSiteStartEndDateID);
                        Assert.IsNotNull(mwqmSiteStartEndDateRet.MWQMSiteTVItemID);
                        Assert.IsNotNull(mwqmSiteStartEndDateRet.StartDate);
                        if (mwqmSiteStartEndDateRet.EndDate != null)
                        {
                            Assert.IsNotNull(mwqmSiteStartEndDateRet.EndDate);
                        }
                        Assert.IsNotNull(mwqmSiteStartEndDateRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmSiteStartEndDateRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (mwqmSiteStartEndDateRet.MWQMSiteStartEndDateWeb != null)
                            {
                                Assert.IsNull(mwqmSiteStartEndDateRet.MWQMSiteStartEndDateWeb);
                            }
                            if (mwqmSiteStartEndDateRet.MWQMSiteStartEndDateReport != null)
                            {
                                Assert.IsNull(mwqmSiteStartEndDateRet.MWQMSiteStartEndDateReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (mwqmSiteStartEndDateRet.MWQMSiteStartEndDateWeb != null)
                            {
                                Assert.IsNotNull(mwqmSiteStartEndDateRet.MWQMSiteStartEndDateWeb);
                            }
                            if (mwqmSiteStartEndDateRet.MWQMSiteStartEndDateReport != null)
                            {
                                Assert.IsNotNull(mwqmSiteStartEndDateRet.MWQMSiteStartEndDateReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MWQMSiteStartEndDate
        #endregion Tests Get List of MWQMSiteStartEndDate

    }
}
