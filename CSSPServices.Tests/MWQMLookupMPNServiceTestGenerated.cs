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
            //Error: property [MWQMLookupMPNWeb] and type [MWQMLookupMPN] is  not implemented
            //Error: property [MWQMLookupMPNReport] and type [MWQMLookupMPN] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") mwqmLookupMPN.HasErrors = true;

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
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, dbTestDB, ContactID);

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

                    //Error: Type not implemented [MWQMLookupMPNWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // mwqmLookupMPN.MWQMLookupMPNReport   (MWQMLookupMPNReport)
                    // -----------------------------------

                    //Error: Type not implemented [MWQMLookupMPNReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmLookupMPN.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // mwqmLookupMPN.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMLookupMPN_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, dbTestDB, ContactID);
                    MWQMLookupMPN mwqmLookupMPN = (from c in mwqmLookupMPNService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmLookupMPN);

                    MWQMLookupMPN mwqmLookupMPNRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(mwqmLookupMPNRet.MWQMLookupMPNID);
                        Assert.IsNotNull(mwqmLookupMPNRet.Tubes10);
                        Assert.IsNotNull(mwqmLookupMPNRet.Tubes1);
                        Assert.IsNotNull(mwqmLookupMPNRet.Tubes01);
                        Assert.IsNotNull(mwqmLookupMPNRet.MPN_100ml);
                        Assert.IsNotNull(mwqmLookupMPNRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(mwqmLookupMPNRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (mwqmLookupMPNRet.MWQMLookupMPNWeb != null)
                            {
                                Assert.IsNull(mwqmLookupMPNRet.MWQMLookupMPNWeb);
                            }
                            if (mwqmLookupMPNRet.MWQMLookupMPNReport != null)
                            {
                                Assert.IsNull(mwqmLookupMPNRet.MWQMLookupMPNReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (mwqmLookupMPNRet.MWQMLookupMPNWeb != null)
                            {
                                Assert.IsNotNull(mwqmLookupMPNRet.MWQMLookupMPNWeb);
                            }
                            if (mwqmLookupMPNRet.MWQMLookupMPNReport != null)
                            {
                                Assert.IsNotNull(mwqmLookupMPNRet.MWQMLookupMPNReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of MWQMLookupMPN
        #endregion Tests Get List of MWQMLookupMPN

    }
}
