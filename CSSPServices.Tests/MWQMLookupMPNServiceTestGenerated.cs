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
    public partial class MWQMLookupMPNServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMLookupMPNService mwqmLookupMPNService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNServiceTest() : base()
        {
            //mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = 0;
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = 14;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            return mwqmLookupMPN;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMLookupMPN_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    MWQMLookupMPN mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = mwqmLookupMPNService.GetRead().Count();

                    Assert.AreEqual(mwqmLookupMPNService.GetRead().Count(), mwqmLookupMPNService.GetEdit().Count());

                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    if (mwqmLookupMPN.HasErrors)
                    {
                        Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmLookupMPNService.GetRead().Where(c => c == mwqmLookupMPN).Any());
                    mwqmLookupMPNService.Update(mwqmLookupMPN);
                    if (mwqmLookupMPN.HasErrors)
                    {
                        Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmLookupMPNService.GetRead().Count());
                    mwqmLookupMPNService.Delete(mwqmLookupMPN);
                    if (mwqmLookupMPN.HasErrors)
                    {
                        Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // mwqmLookupMPN.MWQMLookupMPNID   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNID = 0;
                    mwqmLookupMPNService.Update(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMLookupMPNMWQMLookupMPNID), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNID = 10000000;
                    mwqmLookupMPNService.Update(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMLookupMPN, CSSPModelsRes.MWQMLookupMPNMWQMLookupMPNID, mwqmLookupMPN.MWQMLookupMPNID.ToString()), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmLookupMPN.Tubes10   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes10 = -1;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes10, "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes10 = 6;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes10, "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmLookupMPN.Tubes1   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes1 = -1;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes1, "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes1 = 6;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes1, "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmLookupMPN.Tubes01   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes01 = -1;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes01, "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes01 = 6;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes01, "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 10000)]
                    // mwqmLookupMPN.MPN_100ml   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MPN_100ml = 0;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MPN_100ml = 10001;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmLookupMPN.MWQMLookupMPNWeb   (MWQMLookupMPNWeb)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNWeb = null;
                    Assert.IsNull(mwqmLookupMPN.MWQMLookupMPNWeb);

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNWeb = new MWQMLookupMPNWeb();
                    Assert.IsNotNull(mwqmLookupMPN.MWQMLookupMPNWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmLookupMPN.MWQMLookupMPNReport   (MWQMLookupMPNReport)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNReport = null;
                    Assert.IsNull(mwqmLookupMPN.MWQMLookupMPNReport);

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNReport = new MWQMLookupMPNReport();
                    Assert.IsNotNull(mwqmLookupMPN.MWQMLookupMPNReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmLookupMPN.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateDate_UTC = new DateTime();
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMLookupMPNLastUpdateDate_UTC), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMLookupMPNLastUpdateDate_UTC, "1980"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmLookupMPN.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateContactTVItemID = 0;
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateContactTVItemID = 1;
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "Contact"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmLookupMPN.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmLookupMPN.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID)
        [TestMethod]
        public void GetMWQMLookupMPNWithMWQMLookupMPNID__mwqmLookupMPN_MWQMLookupMPNID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new GetParam(), dbTestDB, ContactID);
                    MWQMLookupMPN mwqmLookupMPN = (from c in mwqmLookupMPNService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmLookupMPN);

                    MWQMLookupMPN mwqmLookupMPNRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmLookupMPNService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                            Assert.IsNull(mwqmLookupMPNRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MWQMLookupMPN fields
                        Assert.IsNotNull(mwqmLookupMPNRet.MWQMLookupMPNID);
                        Assert.IsNotNull(mwqmLookupMPNRet.Tubes10);
                        Assert.IsNotNull(mwqmLookupMPNRet.Tubes1);
                        Assert.IsNotNull(mwqmLookupMPNRet.Tubes01);
                        Assert.IsNotNull(mwqmLookupMPNRet.MPN_100ml);
                        Assert.IsNotNull(mwqmLookupMPNRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmLookupMPNRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MWQMLookupMPNWeb and MWQMLookupMPNReport fields should be null here
                            Assert.IsNull(mwqmLookupMPNRet.MWQMLookupMPNWeb);
                            Assert.IsNull(mwqmLookupMPNRet.MWQMLookupMPNReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MWQMLookupMPNWeb fields should not be null and MWQMLookupMPNReport fields should be null here
                            if (mwqmLookupMPNRet.MWQMLookupMPNWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNRet.MWQMLookupMPNWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(mwqmLookupMPNRet.MWQMLookupMPNReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MWQMLookupMPNWeb and MWQMLookupMPNReport fields should NOT be null here
                            if (mwqmLookupMPNRet.MWQMLookupMPNWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNRet.MWQMLookupMPNWeb.LastUpdateContactTVText));
                            }
                            if (mwqmLookupMPNRet.MWQMLookupMPNReport.MWQMLookupMPNReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNRet.MWQMLookupMPNReport.MWQMLookupMPNReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID)

        #region Tests Generated for GetMWQMLookupMPNList()
        [TestMethod]
        public void GetMWQMLookupMPNList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new GetParam(), dbTestDB, ContactID);
                    MWQMLookupMPN mwqmLookupMPN = (from c in mwqmLookupMPNService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmLookupMPN);

                    List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        mwqmLookupMPNService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            Assert.AreEqual(0, mwqmLookupMPNList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // MWQMLookupMPN fields
                        Assert.IsNotNull(mwqmLookupMPNList[0].MWQMLookupMPNID);
                        Assert.IsNotNull(mwqmLookupMPNList[0].Tubes10);
                        Assert.IsNotNull(mwqmLookupMPNList[0].Tubes1);
                        Assert.IsNotNull(mwqmLookupMPNList[0].Tubes01);
                        Assert.IsNotNull(mwqmLookupMPNList[0].MPN_100ml);
                        Assert.IsNotNull(mwqmLookupMPNList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmLookupMPNList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // MWQMLookupMPNWeb and MWQMLookupMPNReport fields should be null here
                            Assert.IsNull(mwqmLookupMPNList[0].MWQMLookupMPNWeb);
                            Assert.IsNull(mwqmLookupMPNList[0].MWQMLookupMPNReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // MWQMLookupMPNWeb fields should not be null and MWQMLookupMPNReport fields should be null here
                            if (mwqmLookupMPNList[0].MWQMLookupMPNWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNList[0].MWQMLookupMPNWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(mwqmLookupMPNList[0].MWQMLookupMPNReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // MWQMLookupMPNWeb and MWQMLookupMPNReport fields should NOT be null here
                            if (mwqmLookupMPNList[0].MWQMLookupMPNWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNList[0].MWQMLookupMPNWeb.LastUpdateContactTVText));
                            }
                            if (mwqmLookupMPNList[0].MWQMLookupMPNReport.MWQMLookupMPNReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNList[0].MWQMLookupMPNReport.MWQMLookupMPNReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList()

        #region Tests Generated for GetMWQMLookupMPNList() Skip Take
        [TestMethod]
        public void GetMWQMLookupMPNList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(MWQMLookupMPN), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            Assert.AreEqual(0, mwqmLookupMPNList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, mwqmLookupMPNList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() Skip Take

    }
}
