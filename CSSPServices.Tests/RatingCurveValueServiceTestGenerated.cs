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
    public partial class RatingCurveValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RatingCurveValueService ratingCurveValueService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueServiceTest() : base()
        {
            //ratingCurveValueService = new RatingCurveValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurveValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    RatingCurveValue ratingCurveValue = GetFilledRandomRatingCurveValue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = ratingCurveValueService.GetRatingCurveValueList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.RatingCurveValues select c).Count());

                    ratingCurveValueService.Add(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, ratingCurveValueService.GetRatingCurveValueList().Where(c => c == ratingCurveValue).Any());
                    ratingCurveValueService.Update(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, ratingCurveValueService.GetRatingCurveValueList().Count());
                    ratingCurveValueService.Delete(ratingCurveValue);
                    if (ratingCurveValue.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // ratingCurveValue.RatingCurveValueID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueID = 0;
                    ratingCurveValueService.Update(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "RatingCurveValueRatingCurveValueID"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveValueID = 10000000;
                    ratingCurveValueService.Update(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurveValue", "RatingCurveValueRatingCurveValueID", ratingCurveValue.RatingCurveValueID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID", AllowableTVtypeList = )]
                    // ratingCurveValue.RatingCurveID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.RatingCurveID = 0;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveValueRatingCurveID", ratingCurveValue.RatingCurveID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // ratingCurveValue.StageValue_m   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [StageValue_m]

                    //CSSPError: Type not implemented [StageValue_m]

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.StageValue_m = -1.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RatingCurveValueStageValue_m", "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.StageValue_m = 1001.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RatingCurveValueStageValue_m", "0", "1000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // ratingCurveValue.DischargeValue_m3_s   (Double)
                    // -----------------------------------

                    //CSSPError: Type not implemented [DischargeValue_m3_s]

                    //CSSPError: Type not implemented [DischargeValue_m3_s]

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.DischargeValue_m3_s = -1.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RatingCurveValueDischargeValue_m3_s", "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
                    Assert.AreEqual(false, ratingCurveValueService.Add(ratingCurveValue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RatingCurveValueDischargeValue_m3_s", "0", "1000000"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // ratingCurveValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateDate_UTC = new DateTime();
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "RatingCurveValueLastUpdateDate_UTC"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RatingCurveValueLastUpdateDate_UTC", "1980"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // ratingCurveValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateContactTVItemID = 0;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RatingCurveValueLastUpdateContactTVItemID", ratingCurveValue.LastUpdateContactTVItemID.ToString()), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurveValue = null;
                    ratingCurveValue = GetFilledRandomRatingCurveValue("");
                    ratingCurveValue.LastUpdateContactTVItemID = 1;
                    ratingCurveValueService.Add(ratingCurveValue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "RatingCurveValueLastUpdateContactTVItemID", "Contact"), ratingCurveValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurveValue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurveValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID)
        [TestMethod]
        public void GetRatingCurveValueWithRatingCurveValueID__ratingCurveValue_RatingCurveValueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurveValue ratingCurveValue = (from c in dbTestDB.RatingCurveValues select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ratingCurveValueService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            RatingCurveValue ratingCurveValueRet = ratingCurveValueService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                            CheckRatingCurveValueFields(new List<RatingCurveValue>() { ratingCurveValueRet });
                            Assert.AreEqual(ratingCurveValue.RatingCurveValueID, ratingCurveValueRet.RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            RatingCurveValueExtraA ratingCurveValueExtraARet = ratingCurveValueService.GetRatingCurveValueExtraAWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                            CheckRatingCurveValueExtraAFields(new List<RatingCurveValueExtraA>() { ratingCurveValueExtraARet });
                            Assert.AreEqual(ratingCurveValue.RatingCurveValueID, ratingCurveValueExtraARet.RatingCurveValueID);
                        }
                        else if (extra == "ExtraB")
                        {
                            RatingCurveValueExtraB ratingCurveValueExtraBRet = ratingCurveValueService.GetRatingCurveValueExtraBWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID);
                            CheckRatingCurveValueExtraBFields(new List<RatingCurveValueExtraB>() { ratingCurveValueExtraBRet });
                            Assert.AreEqual(ratingCurveValue.RatingCurveValueID, ratingCurveValueExtraBRet.RatingCurveValueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueWithRatingCurveValueID(ratingCurveValue.RatingCurveValueID)

        #region Tests Generated for GetRatingCurveValueList()
        [TestMethod]
        public void GetRatingCurveValueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurveValue ratingCurveValue = (from c in dbTestDB.RatingCurveValues select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurveValue);

                    List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                    ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ratingCurveValueService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList()

        #region Tests Generated for GetRatingCurveValueList() Skip Take
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                        ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraAList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraBList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take

        #region Tests Generated for GetRatingCurveValueList() Skip Take Order
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 1, 1,  "RatingCurveValueID", "");

                        List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                        ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Skip(1).Take(1).OrderBy(c => c.RatingCurveValueID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraAList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraBList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take Order

        #region Tests Generated for GetRatingCurveValueList() Skip Take 2Order
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 1, 1, "RatingCurveValueID,RatingCurveID", "");

                        List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                        ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Skip(1).Take(1).OrderBy(c => c.RatingCurveValueID).ThenBy(c => c.RatingCurveID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraAList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraBList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take 2Order

        #region Tests Generated for GetRatingCurveValueList() Skip Take Order Where
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveValueID", "RatingCurveValueID,EQ,4", "");

                        List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                        ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Where(c => c.RatingCurveValueID == 4).Skip(0).Take(1).OrderBy(c => c.RatingCurveValueID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraAList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraBList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take Order Where

        #region Tests Generated for GetRatingCurveValueList() Skip Take Order 2Where
        [TestMethod]
        public void GetRatingCurveValueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveValueID", "RatingCurveValueID,GT,2|RatingCurveValueID,LT,5", "");

                        List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                        ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Where(c => c.RatingCurveValueID > 2 && c.RatingCurveValueID < 5).Skip(0).Take(1).OrderBy(c => c.RatingCurveValueID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraAList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraBList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() Skip Take Order 2Where

        #region Tests Generated for GetRatingCurveValueList() 2Where
        [TestMethod]
        public void GetRatingCurveValueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveValueService ratingCurveValueService = new RatingCurveValueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveValueService.Query = ratingCurveValueService.FillQuery(typeof(RatingCurveValue), culture.TwoLetterISOLanguageName, 0, 10000, "", "RatingCurveValueID,GT,2|RatingCurveValueID,LT,5", "");

                        List<RatingCurveValue> ratingCurveValueDirectQueryList = new List<RatingCurveValue>();
                        ratingCurveValueDirectQueryList = (from c in dbTestDB.RatingCurveValues select c).Where(c => c.RatingCurveValueID > 2 && c.RatingCurveValueID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<RatingCurveValue> ratingCurveValueList = new List<RatingCurveValue>();
                            ratingCurveValueList = ratingCurveValueService.GetRatingCurveValueList().ToList();
                            CheckRatingCurveValueFields(ratingCurveValueList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<RatingCurveValueExtraA> ratingCurveValueExtraAList = new List<RatingCurveValueExtraA>();
                            ratingCurveValueExtraAList = ratingCurveValueService.GetRatingCurveValueExtraAList().ToList();
                            CheckRatingCurveValueExtraAFields(ratingCurveValueExtraAList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraAList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<RatingCurveValueExtraB> ratingCurveValueExtraBList = new List<RatingCurveValueExtraB>();
                            ratingCurveValueExtraBList = ratingCurveValueService.GetRatingCurveValueExtraBList().ToList();
                            CheckRatingCurveValueExtraBFields(ratingCurveValueExtraBList);
                            Assert.AreEqual(ratingCurveValueDirectQueryList[0].RatingCurveValueID, ratingCurveValueExtraBList[0].RatingCurveValueID);
                            Assert.AreEqual(ratingCurveValueDirectQueryList.Count, ratingCurveValueExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveValueList() 2Where

        #region Functions private
        private void CheckRatingCurveValueFields(List<RatingCurveValue> ratingCurveValueList)
        {
            Assert.IsNotNull(ratingCurveValueList[0].RatingCurveValueID);
            Assert.IsNotNull(ratingCurveValueList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveValueList[0].StageValue_m);
            Assert.IsNotNull(ratingCurveValueList[0].DischargeValue_m3_s);
            Assert.IsNotNull(ratingCurveValueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveValueList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(ratingCurveValueList[0].HasErrors);
        }
        private void CheckRatingCurveValueExtraAFields(List<RatingCurveValueExtraA> ratingCurveValueExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveValueExtraAList[0].LastUpdateContactText));
            Assert.IsNotNull(ratingCurveValueExtraAList[0].RatingCurveValueID);
            Assert.IsNotNull(ratingCurveValueExtraAList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveValueExtraAList[0].StageValue_m);
            Assert.IsNotNull(ratingCurveValueExtraAList[0].DischargeValue_m3_s);
            Assert.IsNotNull(ratingCurveValueExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveValueExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(ratingCurveValueExtraAList[0].HasErrors);
        }
        private void CheckRatingCurveValueExtraBFields(List<RatingCurveValueExtraB> ratingCurveValueExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(ratingCurveValueExtraBList[0].RatingCurveValueReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveValueExtraBList[0].RatingCurveValueReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveValueExtraBList[0].LastUpdateContactText));
            Assert.IsNotNull(ratingCurveValueExtraBList[0].RatingCurveValueID);
            Assert.IsNotNull(ratingCurveValueExtraBList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveValueExtraBList[0].StageValue_m);
            Assert.IsNotNull(ratingCurveValueExtraBList[0].DischargeValue_m3_s);
            Assert.IsNotNull(ratingCurveValueExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveValueExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(ratingCurveValueExtraBList[0].HasErrors);
        }
        private RatingCurveValue GetFilledRandomRatingCurveValue(string OmitPropName)
        {
            RatingCurveValue ratingCurveValue = new RatingCurveValue();

            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = 1;
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;

            return ratingCurveValue;
        }
        #endregion Functions private
    }
}
