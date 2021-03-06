 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    public partial class PolSourceGroupingServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceGroupingService polSourceGroupingService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingServiceTest() : base()
        {
            //polSourceGroupingService = new PolSourceGroupingService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD
        [TestMethod]
        public void PolSourceGrouping_CRUD_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceGrouping polSourceGrouping = GetFilledRandomPolSourceGrouping("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceGroupingService.GetPolSourceGroupingList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.PolSourceGroupings select c).Count());

                    polSourceGroupingService.Add(polSourceGrouping);
                    if (polSourceGrouping.HasErrors)
                    {
                        Assert.AreEqual("", polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceGroupingService.GetPolSourceGroupingList().Where(c => c == polSourceGrouping).Any());
                    polSourceGroupingService.Update(polSourceGrouping);
                    if (polSourceGrouping.HasErrors)
                    {
                        Assert.AreEqual("", polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceGroupingService.GetPolSourceGroupingList().Count());
                    polSourceGroupingService.Delete(polSourceGrouping);
                    if (polSourceGrouping.HasErrors)
                    {
                        Assert.AreEqual("", polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceGroupingService.GetPolSourceGroupingList().Count());

                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [TestMethod]
        public void PolSourceGrouping_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    count = polSourceGroupingService.GetPolSourceGroupingList().Count();

                    PolSourceGrouping polSourceGrouping = GetFilledRandomPolSourceGrouping("");

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceGrouping.PolSourceGroupingID   (Int32)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.PolSourceGroupingID = 0;
                    polSourceGroupingService.Update(polSourceGrouping);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceGroupingID"), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.PolSourceGroupingID = 10000000;
                    polSourceGroupingService.Update(polSourceGrouping);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceGrouping", "PolSourceGroupingID", polSourceGrouping.PolSourceGroupingID.ToString()), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(10000, 100000)]
                    // polSourceGrouping.CSSPID   (Int32)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.CSSPID = 9999;
                    Assert.AreEqual(false, polSourceGroupingService.Add(polSourceGrouping));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CSSPID", "10000", "100000"), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceGroupingService.GetPolSourceGroupingList().Count());
                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.CSSPID = 100001;
                    Assert.AreEqual(false, polSourceGroupingService.Add(polSourceGrouping));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "CSSPID", "10000", "100000"), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceGroupingService.GetPolSourceGroupingList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceGrouping.GroupName   (String)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("GroupName");
                    Assert.AreEqual(false, polSourceGroupingService.Add(polSourceGrouping));
                    Assert.AreEqual(1, polSourceGrouping.ValidationResults.Count());
                    Assert.IsTrue(polSourceGrouping.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "GroupName")).Any());
                    Assert.AreEqual(null, polSourceGrouping.GroupName);
                    Assert.AreEqual(count, polSourceGroupingService.GetPolSourceGroupingList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceGrouping.Child   (String)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("Child");
                    Assert.AreEqual(false, polSourceGroupingService.Add(polSourceGrouping));
                    Assert.AreEqual(1, polSourceGrouping.ValidationResults.Count());
                    Assert.IsTrue(polSourceGrouping.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Child")).Any());
                    Assert.AreEqual(null, polSourceGrouping.Child);
                    Assert.AreEqual(count, polSourceGroupingService.GetPolSourceGroupingList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceGrouping.Hide   (String)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("Hide");
                    Assert.AreEqual(false, polSourceGroupingService.Add(polSourceGrouping));
                    Assert.AreEqual(1, polSourceGrouping.ValidationResults.Count());
                    Assert.IsTrue(polSourceGrouping.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "Hide")).Any());
                    Assert.AreEqual(null, polSourceGrouping.Hide);
                    Assert.AreEqual(count, polSourceGroupingService.GetPolSourceGroupingList().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceGrouping.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.LastUpdateDate_UTC = new DateTime();
                    polSourceGroupingService.Add(polSourceGrouping);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceGroupingService.Add(polSourceGrouping);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceGrouping.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.LastUpdateContactTVItemID = 0;
                    polSourceGroupingService.Add(polSourceGrouping);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceGrouping.LastUpdateContactTVItemID.ToString()), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceGrouping = null;
                    polSourceGrouping = GetFilledRandomPolSourceGrouping("");
                    polSourceGrouping.LastUpdateContactTVItemID = 1;
                    polSourceGroupingService.Add(polSourceGrouping);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), polSourceGrouping.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceGrouping.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceGrouping.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated Properties

        #region Tests Generated for GetPolSourceGroupingWithPolSourceGroupingID(polSourceGrouping.PolSourceGroupingID)
        [TestMethod]
        public void GetPolSourceGroupingWithPolSourceGroupingID__polSourceGrouping_PolSourceGroupingID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceGrouping polSourceGrouping = (from c in dbTestDB.PolSourceGroupings select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceGrouping);

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        polSourceGroupingService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            PolSourceGrouping polSourceGroupingRet = polSourceGroupingService.GetPolSourceGroupingWithPolSourceGroupingID(polSourceGrouping.PolSourceGroupingID);
                            CheckPolSourceGroupingFields(new List<PolSourceGrouping>() { polSourceGroupingRet });
                            Assert.AreEqual(polSourceGrouping.PolSourceGroupingID, polSourceGroupingRet.PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingWithPolSourceGroupingID(polSourceGrouping.PolSourceGroupingID)

        #region Tests Generated for GetPolSourceGroupingList()
        [TestMethod]
        public void GetPolSourceGroupingList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceGrouping polSourceGrouping = (from c in dbTestDB.PolSourceGroupings select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceGrouping);

                    List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                    polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        polSourceGroupingService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList()

        #region Tests Generated for GetPolSourceGroupingList() Skip Take
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 1, 1, "", "", "", extra);

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take

        #region Tests Generated for GetPolSourceGroupingList() Skip Take Asc
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceGroupingID", "", "", extra);

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).OrderBy(c => c.PolSourceGroupingID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take Asc

        #region Tests Generated for GetPolSourceGroupingList() Skip Take 2 Asc
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_2Asc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceGroupingID,CSSPID", "", "", extra);

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).OrderBy(c => c.PolSourceGroupingID).ThenBy(c => c.CSSPID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take 2 Asc

        #region Tests Generated for GetPolSourceGroupingList() Skip Take Asc Where
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Asc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceGroupingID", "", "PolSourceGroupingID,EQ,4", "");

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Where(c => c.PolSourceGroupingID == 4).OrderBy(c => c.PolSourceGroupingID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take Asc Where

        #region Tests Generated for GetPolSourceGroupingList() Skip Take Asc 2 Where
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Asc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceGroupingID", "", "PolSourceGroupingID,GT,2|PolSourceGroupingID,LT,5", "");

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Where(c => c.PolSourceGroupingID > 2 && c.PolSourceGroupingID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceGroupingID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take Asc 2 Where

        #region Tests Generated for GetPolSourceGroupingList() Skip Take Desc
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 1, 1, "", "PolSourceGroupingID", "", extra);

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).OrderByDescending(c => c.PolSourceGroupingID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take Desc

        #region Tests Generated for GetPolSourceGroupingList() Skip Take 2 Desc
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_2Desc_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 1, 1, "", "PolSourceGroupingID,CSSPID", "", extra);

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).OrderByDescending(c => c.PolSourceGroupingID).ThenByDescending(c => c.CSSPID).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take 2 Desc

        #region Tests Generated for GetPolSourceGroupingList() Skip Take Desc Where
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Desc_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceGroupingID", "", "PolSourceGroupingID,EQ,4", "");

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Where(c => c.PolSourceGroupingID == 4).OrderByDescending(c => c.PolSourceGroupingID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take Desc Where

        #region Tests Generated for GetPolSourceGroupingList() Skip Take Desc 2 Where
        [TestMethod]
        public void GetPolSourceGroupingList_Skip_Take_Desc_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 0, 1, "", "PolSourceGroupingID", "PolSourceGroupingID,GT,2|PolSourceGroupingID,LT,5", "");

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Where(c => c.PolSourceGroupingID > 2 && c.PolSourceGroupingID < 5).OrderByDescending(c => c.PolSourceGroupingID).Skip(0).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() Skip Take Desc 2 Where

        #region Tests Generated for GetPolSourceGroupingList() 2 Where
        [TestMethod]
        public void GetPolSourceGroupingList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "A", "B", "C", "D", "E" })
                    {
                        PolSourceGroupingService polSourceGroupingService = new PolSourceGroupingService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceGroupingService.Query = polSourceGroupingService.FillQuery(typeof(PolSourceGrouping), culture.TwoLetterISOLanguageName, 0, 10000, "", "", "PolSourceGroupingID,GT,2|PolSourceGroupingID,LT,5", extra);

                        List<PolSourceGrouping> polSourceGroupingDirectQueryList = new List<PolSourceGrouping>();
                        polSourceGroupingDirectQueryList = (from c in dbTestDB.PolSourceGroupings select c).Where(c => c.PolSourceGroupingID > 2 && c.PolSourceGroupingID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<PolSourceGrouping> polSourceGroupingList = new List<PolSourceGrouping>();
                            polSourceGroupingList = polSourceGroupingService.GetPolSourceGroupingList().ToList();
                            CheckPolSourceGroupingFields(polSourceGroupingList);
                            Assert.AreEqual(polSourceGroupingDirectQueryList[0].PolSourceGroupingID, polSourceGroupingList[0].PolSourceGroupingID);
                        }
                        else
                        {
                            //Assert.AreEqual(true, false);
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceGroupingList() 2 Where

        #region Functions private
        private void CheckPolSourceGroupingFields(List<PolSourceGrouping> polSourceGroupingList)
        {
            Assert.IsNotNull(polSourceGroupingList[0].PolSourceGroupingID);
            Assert.IsNotNull(polSourceGroupingList[0].CSSPID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceGroupingList[0].GroupName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceGroupingList[0].Child));
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceGroupingList[0].Hide));
            Assert.IsNotNull(polSourceGroupingList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceGroupingList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceGroupingList[0].HasErrors);
        }
        private PolSourceGrouping GetFilledRandomPolSourceGrouping(string OmitPropName)
        {
            PolSourceGrouping polSourceGrouping = new PolSourceGrouping();

            if (OmitPropName != "CSSPID") polSourceGrouping.CSSPID = GetRandomInt(10000, 100000);
            if (OmitPropName != "GroupName") polSourceGrouping.GroupName = GetRandomString("", 20);
            if (OmitPropName != "Child") polSourceGrouping.Child = GetRandomString("", 20);
            if (OmitPropName != "Hide") polSourceGrouping.Hide = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceGrouping.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceGrouping.LastUpdateContactTVItemID = 2;

            return polSourceGrouping;
        }
        #endregion Functions private
    }
}
