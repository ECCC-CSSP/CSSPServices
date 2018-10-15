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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMLookupMPN_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = mwqmLookupMPNService.GetMWQMLookupMPNList().Count();

                    Assert.AreEqual(mwqmLookupMPNService.GetMWQMLookupMPNList().Count(), (from c in dbTestDB.MWQMLookupMPNs select c).Take(200).Count());

                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    if (mwqmLookupMPN.HasErrors)
                    {
                        Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, mwqmLookupMPNService.GetMWQMLookupMPNList().Where(c => c == mwqmLookupMPN).Any());
                    mwqmLookupMPNService.Update(mwqmLookupMPN);
                    if (mwqmLookupMPN.HasErrors)
                    {
                        Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
                    mwqmLookupMPNService.Delete(mwqmLookupMPN);
                    if (mwqmLookupMPN.HasErrors)
                    {
                        Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMLookupMPNMWQMLookupMPNID"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MWQMLookupMPNID = 10000000;
                    mwqmLookupMPNService.Update(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNMWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString()), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmLookupMPN.Tubes10   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes10 = -1;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes10", "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes10 = 6;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes10", "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmLookupMPN.Tubes1   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes1 = -1;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes1", "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes1 = 6;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes1", "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 5)]
                    // mwqmLookupMPN.Tubes01   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes01 = -1;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes01", "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.Tubes01 = 6;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes01", "0", "5"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 10000)]
                    // mwqmLookupMPN.MPN_100ml   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MPN_100ml = 0;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNMPN_100ml", "1", "10000"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.MPN_100ml = 10001;
                    Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNMPN_100ml", "1", "10000"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // mwqmLookupMPN.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateDate_UTC = new DateTime();
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "MWQMLookupMPNLastUpdateDate_UTC"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMLookupMPNLastUpdateDate_UTC", "1980"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // mwqmLookupMPN.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateContactTVItemID = 0;
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMLookupMPNLastUpdateContactTVItemID", mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

                    mwqmLookupMPN = null;
                    mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
                    mwqmLookupMPN.LastUpdateContactTVItemID = 1;
                    mwqmLookupMPNService.Add(mwqmLookupMPN);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMLookupMPNLastUpdateContactTVItemID", "Contact"), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMLookupMPN mwqmLookupMPN = (from c in dbTestDB.MWQMLookupMPNs select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmLookupMPN);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmLookupMPNService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            MWQMLookupMPN mwqmLookupMPNRet = mwqmLookupMPNService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                            CheckMWQMLookupMPNFields(new List<MWQMLookupMPN>() { mwqmLookupMPNRet });
                            Assert.AreEqual(mwqmLookupMPN.MWQMLookupMPNID, mwqmLookupMPNRet.MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            MWQMLookupMPNExtraA mwqmLookupMPNExtraARet = mwqmLookupMPNService.GetMWQMLookupMPNExtraAWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                            CheckMWQMLookupMPNExtraAFields(new List<MWQMLookupMPNExtraA>() { mwqmLookupMPNExtraARet });
                            Assert.AreEqual(mwqmLookupMPN.MWQMLookupMPNID, mwqmLookupMPNExtraARet.MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraB")
                        {
                            MWQMLookupMPNExtraB mwqmLookupMPNExtraBRet = mwqmLookupMPNService.GetMWQMLookupMPNExtraBWithMWQMLookupMPNID(mwqmLookupMPN.MWQMLookupMPNID);
                            CheckMWQMLookupMPNExtraBFields(new List<MWQMLookupMPNExtraB>() { mwqmLookupMPNExtraBRet });
                            Assert.AreEqual(mwqmLookupMPN.MWQMLookupMPNID, mwqmLookupMPNExtraBRet.MWQMLookupMPNID);
                        }
                        else
                        {
                            // nothing for now
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    MWQMLookupMPN mwqmLookupMPN = (from c in dbTestDB.MWQMLookupMPNs select c).FirstOrDefault();
                    Assert.IsNotNull(mwqmLookupMPN);

                    List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                    mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        mwqmLookupMPNService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                        mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() Skip Take

        #region Tests Generated for GetMWQMLookupMPNList() Skip Take Order
        [TestMethod]
        public void GetMWQMLookupMPNList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), culture.TwoLetterISOLanguageName, 1, 1,  "MWQMLookupMPNID", "");

                        List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                        mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Skip(1).Take(1).OrderBy(c => c.MWQMLookupMPNID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() Skip Take Order

        #region Tests Generated for GetMWQMLookupMPNList() Skip Take 2Order
        [TestMethod]
        public void GetMWQMLookupMPNList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), culture.TwoLetterISOLanguageName, 1, 1, "MWQMLookupMPNID,Tubes10", "");

                        List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                        mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Skip(1).Take(1).OrderBy(c => c.MWQMLookupMPNID).ThenBy(c => c.Tubes10).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() Skip Take 2Order

        #region Tests Generated for GetMWQMLookupMPNList() Skip Take Order Where
        [TestMethod]
        public void GetMWQMLookupMPNList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), culture.TwoLetterISOLanguageName, 0, 1, "MWQMLookupMPNID", "MWQMLookupMPNID,EQ,4", "");

                        List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                        mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Where(c => c.MWQMLookupMPNID == 4).Skip(0).Take(1).OrderBy(c => c.MWQMLookupMPNID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() Skip Take Order Where

        #region Tests Generated for GetMWQMLookupMPNList() Skip Take Order 2Where
        [TestMethod]
        public void GetMWQMLookupMPNList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), culture.TwoLetterISOLanguageName, 0, 1, "MWQMLookupMPNID", "MWQMLookupMPNID,GT,2|MWQMLookupMPNID,LT,5", "");

                        List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                        mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Where(c => c.MWQMLookupMPNID > 2 && c.MWQMLookupMPNID < 5).Skip(0).Take(1).OrderBy(c => c.MWQMLookupMPNID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() Skip Take Order 2Where

        #region Tests Generated for GetMWQMLookupMPNList() 2Where
        [TestMethod]
        public void GetMWQMLookupMPNList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        mwqmLookupMPNService.Query = mwqmLookupMPNService.FillQuery(typeof(MWQMLookupMPN), culture.TwoLetterISOLanguageName, 0, 10000, "", "MWQMLookupMPNID,GT,2|MWQMLookupMPNID,LT,5", "");

                        List<MWQMLookupMPN> mwqmLookupMPNDirectQueryList = new List<MWQMLookupMPN>();
                        mwqmLookupMPNDirectQueryList = (from c in dbTestDB.MWQMLookupMPNs select c).Where(c => c.MWQMLookupMPNID > 2 && c.MWQMLookupMPNID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<MWQMLookupMPN> mwqmLookupMPNList = new List<MWQMLookupMPN>();
                            mwqmLookupMPNList = mwqmLookupMPNService.GetMWQMLookupMPNList().ToList();
                            CheckMWQMLookupMPNFields(mwqmLookupMPNList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList = new List<MWQMLookupMPNExtraA>();
                            mwqmLookupMPNExtraAList = mwqmLookupMPNService.GetMWQMLookupMPNExtraAList().ToList();
                            CheckMWQMLookupMPNExtraAFields(mwqmLookupMPNExtraAList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList = new List<MWQMLookupMPNExtraB>();
                            mwqmLookupMPNExtraBList = mwqmLookupMPNService.GetMWQMLookupMPNExtraBList().ToList();
                            CheckMWQMLookupMPNExtraBFields(mwqmLookupMPNExtraBList);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList[0].MWQMLookupMPNID, mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
                            Assert.AreEqual(mwqmLookupMPNDirectQueryList.Count, mwqmLookupMPNExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetMWQMLookupMPNList() 2Where

        #region Functions private
        private void CheckMWQMLookupMPNFields(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
            Assert.IsNotNull(mwqmLookupMPNList[0].MWQMLookupMPNID);
            Assert.IsNotNull(mwqmLookupMPNList[0].Tubes10);
            Assert.IsNotNull(mwqmLookupMPNList[0].Tubes1);
            Assert.IsNotNull(mwqmLookupMPNList[0].Tubes01);
            Assert.IsNotNull(mwqmLookupMPNList[0].MPN_100ml);
            Assert.IsNotNull(mwqmLookupMPNList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmLookupMPNList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmLookupMPNList[0].HasErrors);
        }
        private void CheckMWQMLookupMPNExtraAFields(List<MWQMLookupMPNExtraA> mwqmLookupMPNExtraAList)
        {
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].MWQMLookupMPNID);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].Tubes10);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].Tubes1);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].Tubes01);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].MPN_100ml);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmLookupMPNExtraAList[0].HasErrors);
        }
        private void CheckMWQMLookupMPNExtraBFields(List<MWQMLookupMPNExtraB> mwqmLookupMPNExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(mwqmLookupMPNExtraBList[0].MWQMLookupMPNReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(mwqmLookupMPNExtraBList[0].MWQMLookupMPNReportTest));
            }
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].MWQMLookupMPNID);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].Tubes10);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].Tubes1);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].Tubes01);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].MPN_100ml);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(mwqmLookupMPNExtraBList[0].HasErrors);
        }
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(2, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = 14;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            return mwqmLookupMPN;
        }
        #endregion Functions private
    }
}
