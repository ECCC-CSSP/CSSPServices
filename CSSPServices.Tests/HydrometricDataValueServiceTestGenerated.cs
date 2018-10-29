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
    public partial class HydrometricDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private HydrometricDataValueService hydrometricDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueServiceTest() : base()
        {
            //hydrometricDataValueService = new HydrometricDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void HydrometricDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    HydrometricDataValue hydrometricDataValue = GetFilledRandomHydrometricDataValue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = hydrometricDataValueService.GetHydrometricDataValueList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.HydrometricDataValues select c).Count());

                    hydrometricDataValueService.Add(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, hydrometricDataValueService.GetHydrometricDataValueList().Where(c => c == hydrometricDataValue).Any());
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, hydrometricDataValueService.GetHydrometricDataValueList().Count());
                    hydrometricDataValueService.Delete(hydrometricDataValue);
                    if (hydrometricDataValue.HasErrors)
                    {
                        Assert.AreEqual("", hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // hydrometricDataValue.HydrometricDataValueID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueID = 0;
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueHydrometricDataValueID"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricDataValueID = 10000000;
                    hydrometricDataValueService.Update(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueHydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
                    // hydrometricDataValue.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.HydrometricSiteID = 0;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricDataValueHydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.DateTime_Local   (DateTime)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DateTime_Local = new DateTime();
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueDateTime_Local"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DateTime_Local = new DateTime(1979, 1, 1);
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricDataValueDateTime_Local", "1980"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // hydrometricDataValue.Keep   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // hydrometricDataValue.StorageDataType   (StorageDataTypeEnum)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)1000000;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueStorageDataType"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // hydrometricDataValue.HasBeenRead   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // hydrometricDataValue.Discharge_m3_s   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [Discharge_m3_s]

                    //CSSPError: Type not implemented [Discharge_m3_s]

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Discharge_m3_s = -1.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueDischarge_m3_s", "0", "100000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Discharge_m3_s = 100001.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueDischarge_m3_s", "0", "100000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 100000)]
                    // hydrometricDataValue.DischargeEntered_m3_s   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [DischargeEntered_m3_s]

                    //CSSPError: Type not implemented [DischargeEntered_m3_s]

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DischargeEntered_m3_s = -1.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueDischargeEntered_m3_s", "0", "100000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.DischargeEntered_m3_s = 100001.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueDischargeEntered_m3_s", "0", "100000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [Range(0, 10000)]
                    // hydrometricDataValue.Level_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [Level_m]

                    //CSSPError: Type not implemented [Level_m]

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Level_m = -1.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueLevel_m", "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.Level_m = 10001.0D;
                    Assert.AreEqual(false, hydrometricDataValueService.Add(hydrometricDataValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueLevel_m", "0", "10000"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, hydrometricDataValueService.GetHydrometricDataValueList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // hydrometricDataValue.HourlyValues   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // hydrometricDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateDate_UTC = new DateTime();
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueLastUpdateDate_UTC"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricDataValueLastUpdateDate_UTC", "1980"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // hydrometricDataValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateContactTVItemID = 0;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricDataValueLastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    hydrometricDataValue = null;
                    hydrometricDataValue = GetFilledRandomHydrometricDataValue("");
                    hydrometricDataValue.LastUpdateContactTVItemID = 1;
                    hydrometricDataValueService.Add(hydrometricDataValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricDataValueLastUpdateContactTVItemID", "Contact"), hydrometricDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricDataValue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // hydrometricDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID)
        [TestMethod]
        public void GetHydrometricDataValueWithHydrometricDataValueID__hydrometricDataValue_HydrometricDataValueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    HydrometricDataValue hydrometricDataValue = (from c in dbTestDB.HydrometricDataValues select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricDataValue);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        hydrometricDataValueService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            HydrometricDataValue hydrometricDataValueRet = hydrometricDataValueService.GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                            CheckHydrometricDataValueFields(new List<HydrometricDataValue>() { hydrometricDataValueRet });
                            Assert.AreEqual(hydrometricDataValue.HydrometricDataValueID, hydrometricDataValueRet.HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            HydrometricDataValueExtraA hydrometricDataValueExtraARet = hydrometricDataValueService.GetHydrometricDataValueExtraAWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                            CheckHydrometricDataValueExtraAFields(new List<HydrometricDataValueExtraA>() { hydrometricDataValueExtraARet });
                            Assert.AreEqual(hydrometricDataValue.HydrometricDataValueID, hydrometricDataValueExtraARet.HydrometricDataValueID);
                        }
                        else if (extra == "ExtraB")
                        {
                            HydrometricDataValueExtraB hydrometricDataValueExtraBRet = hydrometricDataValueService.GetHydrometricDataValueExtraBWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID);
                            CheckHydrometricDataValueExtraBFields(new List<HydrometricDataValueExtraB>() { hydrometricDataValueExtraBRet });
                            Assert.AreEqual(hydrometricDataValue.HydrometricDataValueID, hydrometricDataValueExtraBRet.HydrometricDataValueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueWithHydrometricDataValueID(hydrometricDataValue.HydrometricDataValueID)

        #region Tests Generated for GetHydrometricDataValueList()
        [TestMethod]
        public void GetHydrometricDataValueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    HydrometricDataValue hydrometricDataValue = (from c in dbTestDB.HydrometricDataValues select c).FirstOrDefault();
                    Assert.IsNotNull(hydrometricDataValue);

                    List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                    hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        hydrometricDataValueService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList()

        #region Tests Generated for GetHydrometricDataValueList() Skip Take
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraAList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraBList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take

        #region Tests Generated for GetHydrometricDataValueList() Skip Take Order
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 1, 1,  "HydrometricDataValueID", "");

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Skip(1).Take(1).OrderBy(c => c.HydrometricDataValueID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraAList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraBList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take Order

        #region Tests Generated for GetHydrometricDataValueList() Skip Take 2Order
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 1, 1, "HydrometricDataValueID,HydrometricSiteID", "");

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Skip(1).Take(1).OrderBy(c => c.HydrometricDataValueID).ThenBy(c => c.HydrometricSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraAList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraBList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take 2Order

        #region Tests Generated for GetHydrometricDataValueList() Skip Take Order Where
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricDataValueID", "HydrometricDataValueID,EQ,4", "");

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == 4).Skip(0).Take(1).OrderBy(c => c.HydrometricDataValueID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraAList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraBList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take Order Where

        #region Tests Generated for GetHydrometricDataValueList() Skip Take Order 2Where
        [TestMethod]
        public void GetHydrometricDataValueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 0, 1, "HydrometricDataValueID", "HydrometricDataValueID,GT,2|HydrometricDataValueID,LT,5", "");

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID > 2 && c.HydrometricDataValueID < 5).Skip(0).Take(1).OrderBy(c => c.HydrometricDataValueID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraAList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraBList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() Skip Take Order 2Where

        #region Tests Generated for GetHydrometricDataValueList() 2Where
        [TestMethod]
        public void GetHydrometricDataValueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        HydrometricDataValueService hydrometricDataValueService = new HydrometricDataValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        hydrometricDataValueService.Query = hydrometricDataValueService.FillQuery(typeof(HydrometricDataValue), culture.TwoLetterISOLanguageName, 0, 10000, "", "HydrometricDataValueID,GT,2|HydrometricDataValueID,LT,5", "");

                        List<HydrometricDataValue> hydrometricDataValueDirectQueryList = new List<HydrometricDataValue>();
                        hydrometricDataValueDirectQueryList = (from c in dbTestDB.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID > 2 && c.HydrometricDataValueID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<HydrometricDataValue> hydrometricDataValueList = new List<HydrometricDataValue>();
                            hydrometricDataValueList = hydrometricDataValueService.GetHydrometricDataValueList().ToList();
                            CheckHydrometricDataValueFields(hydrometricDataValueList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueList[0].HydrometricDataValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList = new List<HydrometricDataValueExtraA>();
                            hydrometricDataValueExtraAList = hydrometricDataValueService.GetHydrometricDataValueExtraAList().ToList();
                            CheckHydrometricDataValueExtraAFields(hydrometricDataValueExtraAList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraAList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList = new List<HydrometricDataValueExtraB>();
                            hydrometricDataValueExtraBList = hydrometricDataValueService.GetHydrometricDataValueExtraBList().ToList();
                            CheckHydrometricDataValueExtraBFields(hydrometricDataValueExtraBList);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList[0].HydrometricDataValueID, hydrometricDataValueExtraBList[0].HydrometricDataValueID);
                            Assert.AreEqual(hydrometricDataValueDirectQueryList.Count, hydrometricDataValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetHydrometricDataValueList() 2Where

        #region Functions private
        private void CheckHydrometricDataValueFields(List<HydrometricDataValue> hydrometricDataValueList)
        {
            Assert.IsNotNull(hydrometricDataValueList[0].HydrometricDataValueID);
            Assert.IsNotNull(hydrometricDataValueList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricDataValueList[0].DateTime_Local);
            Assert.IsNotNull(hydrometricDataValueList[0].Keep);
            Assert.IsNotNull(hydrometricDataValueList[0].StorageDataType);
            Assert.IsNotNull(hydrometricDataValueList[0].HasBeenRead);
            if (hydrometricDataValueList[0].Discharge_m3_s != null)
            {
                Assert.IsNotNull(hydrometricDataValueList[0].Discharge_m3_s);
            }
            if (hydrometricDataValueList[0].DischargeEntered_m3_s != null)
            {
                Assert.IsNotNull(hydrometricDataValueList[0].DischargeEntered_m3_s);
            }
            if (hydrometricDataValueList[0].Level_m != null)
            {
                Assert.IsNotNull(hydrometricDataValueList[0].Level_m);
            }
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueList[0].HourlyValues));
            }
            Assert.IsNotNull(hydrometricDataValueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricDataValueList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricDataValueList[0].HasErrors);
        }
        private void CheckHydrometricDataValueExtraAFields(List<HydrometricDataValueExtraA> hydrometricDataValueExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueExtraAList[0].StorageDataTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraAList[0].StorageDataTypeText));
            }
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].HydrometricDataValueID);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].DateTime_Local);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].Keep);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].StorageDataType);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].HasBeenRead);
            if (hydrometricDataValueExtraAList[0].Discharge_m3_s != null)
            {
                Assert.IsNotNull(hydrometricDataValueExtraAList[0].Discharge_m3_s);
            }
            if (hydrometricDataValueExtraAList[0].DischargeEntered_m3_s != null)
            {
                Assert.IsNotNull(hydrometricDataValueExtraAList[0].DischargeEntered_m3_s);
            }
            if (hydrometricDataValueExtraAList[0].Level_m != null)
            {
                Assert.IsNotNull(hydrometricDataValueExtraAList[0].Level_m);
            }
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueExtraAList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraAList[0].HourlyValues));
            }
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricDataValueExtraAList[0].HasErrors);
        }
        private void CheckHydrometricDataValueExtraBFields(List<HydrometricDataValueExtraB> hydrometricDataValueExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].HydrometricDataValueReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].HydrometricDataValueReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].StorageDataTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].StorageDataTypeText));
            }
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].HydrometricDataValueID);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].HydrometricSiteID);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].DateTime_Local);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].Keep);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].StorageDataType);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].HasBeenRead);
            if (hydrometricDataValueExtraBList[0].Discharge_m3_s != null)
            {
                Assert.IsNotNull(hydrometricDataValueExtraBList[0].Discharge_m3_s);
            }
            if (hydrometricDataValueExtraBList[0].DischargeEntered_m3_s != null)
            {
                Assert.IsNotNull(hydrometricDataValueExtraBList[0].DischargeEntered_m3_s);
            }
            if (hydrometricDataValueExtraBList[0].Level_m != null)
            {
                Assert.IsNotNull(hydrometricDataValueExtraBList[0].Level_m);
            }
            if (!string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].HourlyValues))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(hydrometricDataValueExtraBList[0].HourlyValues));
            }
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(hydrometricDataValueExtraBList[0].HasErrors);
        }
        private HydrometricDataValue GetFilledRandomHydrometricDataValue(string OmitPropName)
        {
            HydrometricDataValue hydrometricDataValue = new HydrometricDataValue();

            if (OmitPropName != "HydrometricSiteID") hydrometricDataValue.HydrometricSiteID = 1;
            if (OmitPropName != "DateTime_Local") hydrometricDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") hydrometricDataValue.Keep = true;
            if (OmitPropName != "StorageDataType") hydrometricDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "HasBeenRead") hydrometricDataValue.HasBeenRead = true;
            if (OmitPropName != "Discharge_m3_s") hydrometricDataValue.Discharge_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "DischargeEntered_m3_s") hydrometricDataValue.DischargeEntered_m3_s = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "Level_m") hydrometricDataValue.Level_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "HourlyValues") hydrometricDataValue.HourlyValues = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") hydrometricDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") hydrometricDataValue.LastUpdateContactTVItemID = 2;

            return hydrometricDataValue;
        }
        #endregion Functions private
    }
}
