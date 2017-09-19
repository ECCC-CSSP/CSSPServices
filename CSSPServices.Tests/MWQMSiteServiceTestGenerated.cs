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
    public partial class MWQMSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSiteService mwqmSiteService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteServiceTest() : base()
        {
            //mwqmSiteService = new MWQMSiteService(LanguageRequest, dbTestDB, ContactID);
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
            if (OmitPropName != "MWQMSiteTVText") mwqmSite.MWQMSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") mwqmSite.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteLatestClassificationText") mwqmSite.MWQMSiteLatestClassificationText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") mwqmSite.HasErrors = true;

            return mwqmSite;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSite_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(mwqmSiteService.GetRead().Count(), mwqmSiteService.GetEdit().Count());

                mwqmSiteService.Add(mwqmSite);
                if (mwqmSite.HasErrors)
                {
                    Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mwqmSiteService.GetRead().Where(c => c == mwqmSite).Any());
                mwqmSiteService.Update(mwqmSite);
                if (mwqmSite.HasErrors)
                {
                    Assert.AreEqual("", mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mwqmSiteService.GetRead().Count());
                mwqmSiteService.Delete(mwqmSite);
                if (mwqmSite.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteID), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteID = 10000000;
                    mwqmSiteService.Update(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSite, CSSPModelsRes.MWQMSiteMWQMSiteID, mwqmSite.MWQMSiteID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
                    // mwqmSite.MWQMSiteTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVItemID = 0;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteMWQMSiteTVItemID, mwqmSite.MWQMSiteTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVItemID = 1;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteMWQMSiteTVItemID, "MWQMSite"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(8))]
                    // mwqmSite.MWQMSiteNumber   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("MWQMSiteNumber");
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(1, mwqmSite.ValidationResults.Count());
                    Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteNumber)).Any());
                    Assert.AreEqual(null, mwqmSite.MWQMSiteNumber);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteNumber = GetRandomString("", 9);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteMWQMSiteNumber, "8"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(mwqmSite.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteDescription)).Any());
                    Assert.AreEqual(null, mwqmSite.MWQMSiteDescription);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteDescription = GetRandomString("", 201);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteMWQMSiteDescription, "200"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // mwqmSite.MWQMSiteLatestClassification   (MWQMSiteLatestClassificationEnum)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)1000000;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteMWQMSiteLatestClassification), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // mwqmSite.Ordinal   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.Ordinal = -1;
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSiteOrdinal, "0", "1000"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());
                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.Ordinal = 1001;
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSiteOrdinal, "0", "1000"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmSite.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmSite.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVItemID = 0;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteLastUpdateContactTVItemID, mwqmSite.LastUpdateContactTVItemID.ToString()), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVItemID = 1;
                    mwqmSiteService.Add(mwqmSite);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteLastUpdateContactTVItemID, "Contact"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "MWQMSiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // mwqmSite.MWQMSiteTVText   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteMWQMSiteTVText, "200"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // mwqmSite.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteLastUpdateContactTVText, "200"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // mwqmSite.MWQMSiteLatestClassificationText   (String)
                    // -----------------------------------

                    mwqmSite = null;
                    mwqmSite = GetFilledRandomMWQMSite("");
                    mwqmSite.MWQMSiteLatestClassificationText = GetRandomString("", 101);
                    Assert.AreEqual(false, mwqmSiteService.Add(mwqmSite));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSiteMWQMSiteLatestClassificationText, "100"), mwqmSite.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmSiteService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSite.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmSite.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMSite_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, dbTestDB, ContactID);
                    MWQMSite mwqmSite = (from c in mwqmSiteService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmSite);

                    MWQMSite mwqmSiteRet = mwqmSiteService.GetMWQMSiteWithMWQMSiteID(mwqmSite.MWQMSiteID);
                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteID);
                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteTVItemID);
                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteNumber);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteRet.MWQMSiteNumber));
                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteDescription);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteRet.MWQMSiteDescription));
                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteLatestClassification);
                    Assert.IsNotNull(mwqmSiteRet.Ordinal);
                    Assert.IsNotNull(mwqmSiteRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(mwqmSiteRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteRet.MWQMSiteTVText));
                    Assert.IsNotNull(mwqmSiteRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteRet.LastUpdateContactTVText));
                    Assert.IsNotNull(mwqmSiteRet.MWQMSiteLatestClassificationText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmSiteRet.MWQMSiteLatestClassificationText));
                    Assert.IsNotNull(mwqmSiteRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
