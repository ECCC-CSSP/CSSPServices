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
    public partial class SpillServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SpillService spillService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillServiceTest() : base()
        {
            //spillService = new SpillService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Spill_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Spill spill = GetFilledRandomSpill("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = spillService.GetSpillList().Count();

                    Assert.AreEqual(spillService.GetSpillList().Count(), (from c in dbTestDB.Spills select c).Take(200).Count());

                    spillService.Add(spill);
                    if (spill.HasErrors)
                    {
                        Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, spillService.GetSpillList().Where(c => c == spill).Any());
                    spillService.Update(spill);
                    if (spill.HasErrors)
                    {
                        Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, spillService.GetSpillList().Count());
                    spillService.Delete(spill);
                    if (spill.HasErrors)
                    {
                        Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, spillService.GetSpillList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // spill.SpillID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillID = 0;
                    spillService.Update(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillSpillID"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.SpillID = 10000000;
                    spillService.Update(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillSpillID", spill.SpillID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
                    // spill.MunicipalityTVItemID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.MunicipalityTVItemID = 0;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillMunicipalityTVItemID", spill.MunicipalityTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.MunicipalityTVItemID = 1;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SpillMunicipalityTVItemID", "Municipality"), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
                    // spill.InfrastructureTVItemID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.InfrastructureTVItemID = 0;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillInfrastructureTVItemID", spill.InfrastructureTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.InfrastructureTVItemID = 1;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SpillInfrastructureTVItemID", "Infrastructure"), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spill.StartDateTime_Local   (DateTime)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.StartDateTime_Local = new DateTime();
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillStartDateTime_Local"), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.StartDateTime_Local = new DateTime(1979, 1, 1);
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillStartDateTime_Local", "1980"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // [CSSPBigger(OtherField = StartDateTime_Local)]
                    // spill.EndDateTime_Local   (DateTime)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.EndDateTime_Local = new DateTime(1979, 1, 1);
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillEndDateTime_Local", "1980"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000000)]
                    // spill.AverageFlow_m3_day   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [AverageFlow_m3_day]

                    //Error: Type not implemented [AverageFlow_m3_day]

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.AverageFlow_m3_day = -1.0D;
                    Assert.AreEqual(false, spillService.Add(spill));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SpillAverageFlow_m3_day", "0", "1000000"), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, spillService.GetSpillList().Count());
                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.AverageFlow_m3_day = 1000001.0D;
                    Assert.AreEqual(false, spillService.Add(spill));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SpillAverageFlow_m3_day", "0", "1000000"), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, spillService.GetSpillList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spill.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateDate_UTC = new DateTime();
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SpillLastUpdateDate_UTC"), spill.ValidationResults.FirstOrDefault().ErrorMessage);
                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SpillLastUpdateDate_UTC", "1980"), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // spill.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateContactTVItemID = 0;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SpillLastUpdateContactTVItemID", spill.LastUpdateContactTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

                    spill = null;
                    spill = GetFilledRandomSpill("");
                    spill.LastUpdateContactTVItemID = 1;
                    spillService.Add(spill);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SpillLastUpdateContactTVItemID", "Contact"), spill.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spill.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spill.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSpillWithSpillID(spill.SpillID)
        [TestMethod]
        public void GetSpillWithSpillID__spill_SpillID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Spill spill = (from c in dbTestDB.Spills select c).FirstOrDefault();
                    Assert.IsNotNull(spill);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        spillService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            Spill spillRet = spillService.GetSpillWithSpillID(spill.SpillID);
                            CheckSpillFields(new List<Spill>() { spillRet });
                            Assert.AreEqual(spill.SpillID, spillRet.SpillID);
                        }
                        else if (detail == "A")
                        {
                            Spill_A spill_ARet = spillService.GetSpill_AWithSpillID(spill.SpillID);
                            CheckSpill_AFields(new List<Spill_A>() { spill_ARet });
                            Assert.AreEqual(spill.SpillID, spill_ARet.SpillID);
                        }
                        else if (detail == "B")
                        {
                            Spill_B spill_BRet = spillService.GetSpill_BWithSpillID(spill.SpillID);
                            CheckSpill_BFields(new List<Spill_B>() { spill_BRet });
                            Assert.AreEqual(spill.SpillID, spill_BRet.SpillID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillWithSpillID(spill.SpillID)

        #region Tests Generated for GetSpillList()
        [TestMethod]
        public void GetSpillList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Spill spill = (from c in dbTestDB.Spills select c).FirstOrDefault();
                    Assert.IsNotNull(spill);

                    List<Spill> spillDirectQueryList = new List<Spill>();
                    spillDirectQueryList = (from c in dbTestDB.Spills select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        spillService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList()

        #region Tests Generated for GetSpillList() Skip Take
        [TestMethod]
        public void GetSpillList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillService.Query = spillService.FillQuery(typeof(Spill), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<Spill> spillDirectQueryList = new List<Spill>();
                        spillDirectQueryList = (from c in dbTestDB.Spills select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spillList[0].SpillID);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_AList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_BList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList() Skip Take

        #region Tests Generated for GetSpillList() Skip Take Order
        [TestMethod]
        public void GetSpillList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillService.Query = spillService.FillQuery(typeof(Spill), culture.TwoLetterISOLanguageName, 1, 1,  "SpillID", "");

                        List<Spill> spillDirectQueryList = new List<Spill>();
                        spillDirectQueryList = (from c in dbTestDB.Spills select c).Skip(1).Take(1).OrderBy(c => c.SpillID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spillList[0].SpillID);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_AList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_BList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList() Skip Take Order

        #region Tests Generated for GetSpillList() Skip Take 2Order
        [TestMethod]
        public void GetSpillList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillService.Query = spillService.FillQuery(typeof(Spill), culture.TwoLetterISOLanguageName, 1, 1, "SpillID,MunicipalityTVItemID", "");

                        List<Spill> spillDirectQueryList = new List<Spill>();
                        spillDirectQueryList = (from c in dbTestDB.Spills select c).Skip(1).Take(1).OrderBy(c => c.SpillID).ThenBy(c => c.MunicipalityTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spillList[0].SpillID);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_AList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_BList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList() Skip Take 2Order

        #region Tests Generated for GetSpillList() Skip Take Order Where
        [TestMethod]
        public void GetSpillList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillService.Query = spillService.FillQuery(typeof(Spill), culture.TwoLetterISOLanguageName, 0, 1, "SpillID", "SpillID,EQ,4", "");

                        List<Spill> spillDirectQueryList = new List<Spill>();
                        spillDirectQueryList = (from c in dbTestDB.Spills select c).Where(c => c.SpillID == 4).Skip(0).Take(1).OrderBy(c => c.SpillID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spillList[0].SpillID);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_AList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_BList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList() Skip Take Order Where

        #region Tests Generated for GetSpillList() Skip Take Order 2Where
        [TestMethod]
        public void GetSpillList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillService.Query = spillService.FillQuery(typeof(Spill), culture.TwoLetterISOLanguageName, 0, 1, "SpillID", "SpillID,GT,2|SpillID,LT,5", "");

                        List<Spill> spillDirectQueryList = new List<Spill>();
                        spillDirectQueryList = (from c in dbTestDB.Spills select c).Where(c => c.SpillID > 2 && c.SpillID < 5).Skip(0).Take(1).OrderBy(c => c.SpillID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spillList[0].SpillID);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_AList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_BList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList() Skip Take Order 2Where

        #region Tests Generated for GetSpillList() 2Where
        [TestMethod]
        public void GetSpillList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        SpillService spillService = new SpillService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillService.Query = spillService.FillQuery(typeof(Spill), culture.TwoLetterISOLanguageName, 0, 10000, "", "SpillID,GT,2|SpillID,LT,5", "");

                        List<Spill> spillDirectQueryList = new List<Spill>();
                        spillDirectQueryList = (from c in dbTestDB.Spills select c).Where(c => c.SpillID > 2 && c.SpillID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Spill> spillList = new List<Spill>();
                            spillList = spillService.GetSpillList().ToList();
                            CheckSpillFields(spillList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spillList[0].SpillID);
                        }
                        else if (detail == "A")
                        {
                            List<Spill_A> spill_AList = new List<Spill_A>();
                            spill_AList = spillService.GetSpill_AList().ToList();
                            CheckSpill_AFields(spill_AList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_AList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<Spill_B> spill_BList = new List<Spill_B>();
                            spill_BList = spillService.GetSpill_BList().ToList();
                            CheckSpill_BFields(spill_BList);
                            Assert.AreEqual(spillDirectQueryList[0].SpillID, spill_BList[0].SpillID);
                            Assert.AreEqual(spillDirectQueryList.Count, spill_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillList() 2Where

        #region Functions private
        private void CheckSpillFields(List<Spill> spillList)
        {
            Assert.IsNotNull(spillList[0].SpillID);
            Assert.IsNotNull(spillList[0].MunicipalityTVItemID);
            if (spillList[0].InfrastructureTVItemID != null)
            {
                Assert.IsNotNull(spillList[0].InfrastructureTVItemID);
            }
            Assert.IsNotNull(spillList[0].StartDateTime_Local);
            if (spillList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(spillList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(spillList[0].AverageFlow_m3_day);
            Assert.IsNotNull(spillList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spillList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(spillList[0].HasErrors);
        }
        private void CheckSpill_AFields(List<Spill_A> spill_AList)
        {
            Assert.IsNotNull(spill_AList[0].MunicipalityTVItemLanguage);
            Assert.IsNotNull(spill_AList[0].InfrastructureTVItemLanguage);
            Assert.IsNotNull(spill_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(spill_AList[0].SpillID);
            Assert.IsNotNull(spill_AList[0].MunicipalityTVItemID);
            if (spill_AList[0].InfrastructureTVItemID != null)
            {
                Assert.IsNotNull(spill_AList[0].InfrastructureTVItemID);
            }
            Assert.IsNotNull(spill_AList[0].StartDateTime_Local);
            if (spill_AList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(spill_AList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(spill_AList[0].AverageFlow_m3_day);
            Assert.IsNotNull(spill_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spill_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(spill_AList[0].HasErrors);
        }
        private void CheckSpill_BFields(List<Spill_B> spill_BList)
        {
            if (!string.IsNullOrWhiteSpace(spill_BList[0].SpillReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(spill_BList[0].SpillReportTest));
            }
            Assert.IsNotNull(spill_BList[0].MunicipalityTVItemLanguage);
            Assert.IsNotNull(spill_BList[0].InfrastructureTVItemLanguage);
            Assert.IsNotNull(spill_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(spill_BList[0].SpillID);
            Assert.IsNotNull(spill_BList[0].MunicipalityTVItemID);
            if (spill_BList[0].InfrastructureTVItemID != null)
            {
                Assert.IsNotNull(spill_BList[0].InfrastructureTVItemID);
            }
            Assert.IsNotNull(spill_BList[0].StartDateTime_Local);
            if (spill_BList[0].EndDateTime_Local != null)
            {
                Assert.IsNotNull(spill_BList[0].EndDateTime_Local);
            }
            Assert.IsNotNull(spill_BList[0].AverageFlow_m3_day);
            Assert.IsNotNull(spill_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spill_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(spill_BList[0].HasErrors);
        }
        private Spill GetFilledRandomSpill(string OmitPropName)
        {
            Spill spill = new Spill();

            if (OmitPropName != "MunicipalityTVItemID") spill.MunicipalityTVItemID = 38;
            if (OmitPropName != "InfrastructureTVItemID") spill.InfrastructureTVItemID = 40;
            if (OmitPropName != "StartDateTime_Local") spill.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") spill.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "AverageFlow_m3_day") spill.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") spill.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spill.LastUpdateContactTVItemID = 2;

            return spill;
        }
        #endregion Functions private
    }
}
