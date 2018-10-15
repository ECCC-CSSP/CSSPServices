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
    public partial class RatingCurveServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private RatingCurveService ratingCurveService { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveServiceTest() : base()
        {
            //ratingCurveService = new RatingCurveService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void RatingCurve_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    RatingCurve ratingCurve = GetFilledRandomRatingCurve("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = ratingCurveService.GetRatingCurveList().Count();

                    Assert.AreEqual(ratingCurveService.GetRatingCurveList().Count(), (from c in dbTestDB.RatingCurves select c).Take(200).Count());

                    ratingCurveService.Add(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, ratingCurveService.GetRatingCurveList().Where(c => c == ratingCurve).Any());
                    ratingCurveService.Update(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, ratingCurveService.GetRatingCurveList().Count());
                    ratingCurveService.Delete(ratingCurve);
                    if (ratingCurve.HasErrors)
                    {
                        Assert.AreEqual("", ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, ratingCurveService.GetRatingCurveList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // ratingCurve.RatingCurveID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveID = 0;
                    ratingCurveService.Update(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "RatingCurveRatingCurveID"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveID = 10000000;
                    ratingCurveService.Update(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RatingCurve", "RatingCurveRatingCurveID", ratingCurve.RatingCurveID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "HydrometricSite", ExistPlurial = "s", ExistFieldID = "HydrometricSiteID", AllowableTVtypeList = )]
                    // ratingCurve.HydrometricSiteID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.HydrometricSiteID = 0;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "RatingCurveHydrometricSiteID", ratingCurve.HydrometricSiteID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(50))]
                    // ratingCurve.RatingCurveNumber   (String)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("RatingCurveNumber");
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(1, ratingCurve.ValidationResults.Count());
                    Assert.IsTrue(ratingCurve.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "RatingCurveRatingCurveNumber")).Any());
                    Assert.AreEqual(null, ratingCurve.RatingCurveNumber);
                    Assert.AreEqual(count, ratingCurveService.GetRatingCurveList().Count());

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.RatingCurveNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, ratingCurveService.Add(ratingCurve));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "RatingCurveRatingCurveNumber", "50"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, ratingCurveService.GetRatingCurveList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // ratingCurve.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateDate_UTC = new DateTime();
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "RatingCurveLastUpdateDate_UTC"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);
                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RatingCurveLastUpdateDate_UTC", "1980"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // ratingCurve.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVItemID = 0;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RatingCurveLastUpdateContactTVItemID", ratingCurve.LastUpdateContactTVItemID.ToString()), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);

                    ratingCurve = null;
                    ratingCurve = GetFilledRandomRatingCurve("");
                    ratingCurve.LastUpdateContactTVItemID = 1;
                    ratingCurveService.Add(ratingCurve);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "RatingCurveLastUpdateContactTVItemID", "Contact"), ratingCurve.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurve.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // ratingCurve.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID)
        [TestMethod]
        public void GetRatingCurveWithRatingCurveID__ratingCurve_RatingCurveID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in dbTestDB.RatingCurves select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ratingCurveService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            RatingCurve ratingCurveRet = ratingCurveService.GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID);
                            CheckRatingCurveFields(new List<RatingCurve>() { ratingCurveRet });
                            Assert.AreEqual(ratingCurve.RatingCurveID, ratingCurveRet.RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            RatingCurveExtraA ratingCurveExtraARet = ratingCurveService.GetRatingCurveExtraAWithRatingCurveID(ratingCurve.RatingCurveID);
                            CheckRatingCurveExtraAFields(new List<RatingCurveExtraA>() { ratingCurveExtraARet });
                            Assert.AreEqual(ratingCurve.RatingCurveID, ratingCurveExtraARet.RatingCurveID);
                        }
                        else if (detail == "ExtraB")
                        {
                            RatingCurveExtraB ratingCurveExtraBRet = ratingCurveService.GetRatingCurveExtraBWithRatingCurveID(ratingCurve.RatingCurveID);
                            CheckRatingCurveExtraBFields(new List<RatingCurveExtraB>() { ratingCurveExtraBRet });
                            Assert.AreEqual(ratingCurve.RatingCurveID, ratingCurveExtraBRet.RatingCurveID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveWithRatingCurveID(ratingCurve.RatingCurveID)

        #region Tests Generated for GetRatingCurveList()
        [TestMethod]
        public void GetRatingCurveList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    RatingCurve ratingCurve = (from c in dbTestDB.RatingCurves select c).FirstOrDefault();
                    Assert.IsNotNull(ratingCurve);

                    List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                    ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ratingCurveService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList()

        #region Tests Generated for GetRatingCurveList() Skip Take
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                        ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraAList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraBList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take

        #region Tests Generated for GetRatingCurveList() Skip Take Order
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 1, 1,  "RatingCurveID", "");

                        List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                        ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Skip(1).Take(1).OrderBy(c => c.RatingCurveID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraAList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraBList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take Order

        #region Tests Generated for GetRatingCurveList() Skip Take 2Order
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 1, 1, "RatingCurveID,HydrometricSiteID", "");

                        List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                        ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Skip(1).Take(1).OrderBy(c => c.RatingCurveID).ThenBy(c => c.HydrometricSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraAList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraBList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take 2Order

        #region Tests Generated for GetRatingCurveList() Skip Take Order Where
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveID", "RatingCurveID,EQ,4", "");

                        List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                        ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Where(c => c.RatingCurveID == 4).Skip(0).Take(1).OrderBy(c => c.RatingCurveID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraAList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraBList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take Order Where

        #region Tests Generated for GetRatingCurveList() Skip Take Order 2Where
        [TestMethod]
        public void GetRatingCurveList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 0, 1, "RatingCurveID", "RatingCurveID,GT,2|RatingCurveID,LT,5", "");

                        List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                        ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Where(c => c.RatingCurveID > 2 && c.RatingCurveID < 5).Skip(0).Take(1).OrderBy(c => c.RatingCurveID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraAList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraBList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() Skip Take Order 2Where

        #region Tests Generated for GetRatingCurveList() 2Where
        [TestMethod]
        public void GetRatingCurveList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        RatingCurveService ratingCurveService = new RatingCurveService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        ratingCurveService.Query = ratingCurveService.FillQuery(typeof(RatingCurve), culture.TwoLetterISOLanguageName, 0, 10000, "", "RatingCurveID,GT,2|RatingCurveID,LT,5", "");

                        List<RatingCurve> ratingCurveDirectQueryList = new List<RatingCurve>();
                        ratingCurveDirectQueryList = (from c in dbTestDB.RatingCurves select c).Where(c => c.RatingCurveID > 2 && c.RatingCurveID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<RatingCurve> ratingCurveList = new List<RatingCurve>();
                            ratingCurveList = ratingCurveService.GetRatingCurveList().ToList();
                            CheckRatingCurveFields(ratingCurveList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveList[0].RatingCurveID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<RatingCurveExtraA> ratingCurveExtraAList = new List<RatingCurveExtraA>();
                            ratingCurveExtraAList = ratingCurveService.GetRatingCurveExtraAList().ToList();
                            CheckRatingCurveExtraAFields(ratingCurveExtraAList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraAList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<RatingCurveExtraB> ratingCurveExtraBList = new List<RatingCurveExtraB>();
                            ratingCurveExtraBList = ratingCurveService.GetRatingCurveExtraBList().ToList();
                            CheckRatingCurveExtraBFields(ratingCurveExtraBList);
                            Assert.AreEqual(ratingCurveDirectQueryList[0].RatingCurveID, ratingCurveExtraBList[0].RatingCurveID);
                            Assert.AreEqual(ratingCurveDirectQueryList.Count, ratingCurveExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetRatingCurveList() 2Where

        #region Functions private
        private void CheckRatingCurveFields(List<RatingCurve> ratingCurveList)
        {
            Assert.IsNotNull(ratingCurveList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveList[0].HydrometricSiteID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveList[0].RatingCurveNumber));
            Assert.IsNotNull(ratingCurveList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(ratingCurveList[0].HasErrors);
        }
        private void CheckRatingCurveExtraAFields(List<RatingCurveExtraA> ratingCurveExtraAList)
        {
            Assert.IsNotNull(ratingCurveExtraAList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(ratingCurveExtraAList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveExtraAList[0].HydrometricSiteID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveExtraAList[0].RatingCurveNumber));
            Assert.IsNotNull(ratingCurveExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(ratingCurveExtraAList[0].HasErrors);
        }
        private void CheckRatingCurveExtraBFields(List<RatingCurveExtraB> ratingCurveExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(ratingCurveExtraBList[0].RatingCurveReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveExtraBList[0].RatingCurveReportTest));
            }
            Assert.IsNotNull(ratingCurveExtraBList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(ratingCurveExtraBList[0].RatingCurveID);
            Assert.IsNotNull(ratingCurveExtraBList[0].HydrometricSiteID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(ratingCurveExtraBList[0].RatingCurveNumber));
            Assert.IsNotNull(ratingCurveExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(ratingCurveExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(ratingCurveExtraBList[0].HasErrors);
        }
        private RatingCurve GetFilledRandomRatingCurve(string OmitPropName)
        {
            RatingCurve ratingCurve = new RatingCurve();

            if (OmitPropName != "HydrometricSiteID") ratingCurve.HydrometricSiteID = 1;
            if (OmitPropName != "RatingCurveNumber") ratingCurve.RatingCurveNumber = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurve.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurve.LastUpdateContactTVItemID = 2;

            return ratingCurve;
        }
        #endregion Functions private
    }
}
