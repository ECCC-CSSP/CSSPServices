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
    public partial class PolSourceObservationIssueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueServiceTest() : base()
        {
            //polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceObservationIssue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceObservationIssueService.GetPolSourceObservationIssueList().Count();

                    Assert.AreEqual(polSourceObservationIssueService.GetPolSourceObservationIssueList().Count(), (from c in dbTestDB.PolSourceObservationIssues select c).Take(200).Count());

                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceObservationIssueService.GetPolSourceObservationIssueList().Where(c => c == polSourceObservationIssue).Any());
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());
                    polSourceObservationIssueService.Delete(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 0;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssuePolSourceObservationIssueID"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 10000000;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservationIssue", "PolSourceObservationIssuePolSourceObservationIssueID", polSourceObservationIssue.PolSourceObservationIssueID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID", AllowableTVtypeList = )]
                    // polSourceObservationIssue.PolSourceObservationID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationIssuePolSourceObservationID", polSourceObservationIssue.PolSourceObservationID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // polSourceObservationIssue.ObservationInfo   (String)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssueObservationInfo")).Any());
                    Assert.AreEqual(null, polSourceObservationIssue.ObservationInfo);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "PolSourceObservationIssueObservationInfo", "250"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // polSourceObservationIssue.Ordinal   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = -1;
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceObservationIssueOrdinal", "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = 1001;
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PolSourceObservationIssueOrdinal", "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // polSourceObservationIssue.ExtraComment   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateDate_UTC = new DateTime();
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationIssueLastUpdateDate_UTC"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceObservationIssueLastUpdateDate_UTC", "1980"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceObservationIssueLastUpdateContactTVItemID", polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 1;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceObservationIssueLastUpdateContactTVItemID", "Contact"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID)
        [TestMethod]
        public void GetPolSourceObservationIssueWithPolSourceObservationIssueID__polSourceObservationIssue_PolSourceObservationIssueID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in dbTestDB.PolSourceObservationIssues select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservationIssue);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        polSourceObservationIssueService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            PolSourceObservationIssue polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                            CheckPolSourceObservationIssueFields(new List<PolSourceObservationIssue>() { polSourceObservationIssueRet });
                            Assert.AreEqual(polSourceObservationIssue.PolSourceObservationIssueID, polSourceObservationIssueRet.PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            PolSourceObservationIssue_A polSourceObservationIssue_ARet = polSourceObservationIssueService.GetPolSourceObservationIssue_AWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                            CheckPolSourceObservationIssue_AFields(new List<PolSourceObservationIssue_A>() { polSourceObservationIssue_ARet });
                            Assert.AreEqual(polSourceObservationIssue.PolSourceObservationIssueID, polSourceObservationIssue_ARet.PolSourceObservationIssueID);
                        }
                        else if (detail == "B")
                        {
                            PolSourceObservationIssue_B polSourceObservationIssue_BRet = polSourceObservationIssueService.GetPolSourceObservationIssue_BWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                            CheckPolSourceObservationIssue_BFields(new List<PolSourceObservationIssue_B>() { polSourceObservationIssue_BRet });
                            Assert.AreEqual(polSourceObservationIssue.PolSourceObservationIssueID, polSourceObservationIssue_BRet.PolSourceObservationIssueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID)

        #region Tests Generated for GetPolSourceObservationIssueList()
        [TestMethod]
        public void GetPolSourceObservationIssueList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in dbTestDB.PolSourceObservationIssues select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservationIssue);

                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        polSourceObservationIssueService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList()

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take
        [TestMethod]
        public void GetPolSourceObservationIssueList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Order
        [TestMethod]
        public void GetPolSourceObservationIssueList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationIssueID", "");

                        List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Skip(1).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Order

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take 2Order
        [TestMethod]
        public void GetPolSourceObservationIssueList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationIssueID,PolSourceObservationID", "");

                        List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Skip(1).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ThenBy(c => c.PolSourceObservationID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take 2Order

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Order Where
        [TestMethod]
        public void GetPolSourceObservationIssueList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "PolSourceObservationIssueID,EQ,4", "");

                        List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Order Where

        #region Tests Generated for GetPolSourceObservationIssueList() Skip Take Order 2Where
        [TestMethod]
        public void GetPolSourceObservationIssueList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5", "");

                        List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() Skip Take Order 2Where

        #region Tests Generated for GetPolSourceObservationIssueList() 2Where
        [TestMethod]
        public void GetPolSourceObservationIssueList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5", "");

                        List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                        polSourceObservationIssueDirectQueryList = (from c in dbTestDB.PolSourceObservationIssues select c).Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            CheckPolSourceObservationIssueFields(polSourceObservationIssueList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        }
                        else if (detail == "A")
                        {
                            List<PolSourceObservationIssue_A> polSourceObservationIssue_AList = new List<PolSourceObservationIssue_A>();
                            polSourceObservationIssue_AList = polSourceObservationIssueService.GetPolSourceObservationIssue_AList().ToList();
                            CheckPolSourceObservationIssue_AFields(polSourceObservationIssue_AList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<PolSourceObservationIssue_B> polSourceObservationIssue_BList = new List<PolSourceObservationIssue_B>();
                            polSourceObservationIssue_BList = polSourceObservationIssueService.GetPolSourceObservationIssue_BList().ToList();
                            CheckPolSourceObservationIssue_BFields(polSourceObservationIssue_BList);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
                            Assert.AreEqual(polSourceObservationIssueDirectQueryList.Count, polSourceObservationIssue_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() 2Where

        #region Functions private
        private void CheckPolSourceObservationIssueFields(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            Assert.IsNotNull(polSourceObservationIssueList[0].PolSourceObservationIssueID);
            Assert.IsNotNull(polSourceObservationIssueList[0].PolSourceObservationID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ObservationInfo));
            Assert.IsNotNull(polSourceObservationIssueList[0].Ordinal);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment));
            }
            Assert.IsNotNull(polSourceObservationIssueList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationIssueList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationIssueList[0].HasErrors);
        }
        private void CheckPolSourceObservationIssue_AFields(List<PolSourceObservationIssue_A> polSourceObservationIssue_AList)
        {
            Assert.IsNotNull(polSourceObservationIssue_AList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationIssue_AList[0].PolSourceObservationIssueID);
            Assert.IsNotNull(polSourceObservationIssue_AList[0].PolSourceObservationID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssue_AList[0].ObservationInfo));
            Assert.IsNotNull(polSourceObservationIssue_AList[0].Ordinal);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue_AList[0].ExtraComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssue_AList[0].ExtraComment));
            }
            Assert.IsNotNull(polSourceObservationIssue_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationIssue_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationIssue_AList[0].HasErrors);
        }
        private void CheckPolSourceObservationIssue_BFields(List<PolSourceObservationIssue_B> polSourceObservationIssue_BList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue_BList[0].PolSourceObservationIssueReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssue_BList[0].PolSourceObservationIssueReportTest));
            }
            Assert.IsNotNull(polSourceObservationIssue_BList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationIssue_BList[0].PolSourceObservationIssueID);
            Assert.IsNotNull(polSourceObservationIssue_BList[0].PolSourceObservationID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssue_BList[0].ObservationInfo));
            Assert.IsNotNull(polSourceObservationIssue_BList[0].Ordinal);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssue_BList[0].ExtraComment))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssue_BList[0].ExtraComment));
            }
            Assert.IsNotNull(polSourceObservationIssue_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationIssue_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationIssue_BList[0].HasErrors);
        }
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "ExtraComment") polSourceObservationIssue.ExtraComment = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            return polSourceObservationIssue;
        }
        #endregion Functions private
    }
}
