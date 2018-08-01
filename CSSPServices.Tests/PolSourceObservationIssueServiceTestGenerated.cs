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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = polSourceObservationIssueService.GetRead().Count();

                    Assert.AreEqual(polSourceObservationIssueService.GetRead().Count(), polSourceObservationIssueService.GetEdit().Count());

                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceObservationIssueService.GetRead().Where(c => c == polSourceObservationIssue).Any());
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceObservationIssueService.GetRead().Count());
                    polSourceObservationIssueService.Delete(polSourceObservationIssue);
                    if (polSourceObservationIssue.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueID = 10000000;
                    polSourceObservationIssueService.Update(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservationIssue, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationIssueID, polSourceObservationIssue.PolSourceObservationIssueID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID", AllowableTVtypeList = )]
                    // polSourceObservationIssue.PolSourceObservationID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationIssuePolSourceObservationID, polSourceObservationIssue.PolSourceObservationID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // polSourceObservationIssue.ObservationInfo   (String)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(1, polSourceObservationIssue.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservationIssue.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssueObservationInfo)).Any());
                    Assert.AreEqual(null, polSourceObservationIssue.ObservationInfo);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.PolSourceObservationIssueObservationInfo, "250"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // polSourceObservationIssue.Ordinal   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = -1;
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.Ordinal = 1001;
                    Assert.AreEqual(false, polSourceObservationIssueService.Add(polSourceObservationIssue));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.PolSourceObservationIssueOrdinal, "0", "1000"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, polSourceObservationIssueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // polSourceObservationIssue.ExtraComment   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.PolSourceObservationIssueWeb   (PolSourceObservationIssueWeb)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueWeb = null;
                    Assert.IsNull(polSourceObservationIssue.PolSourceObservationIssueWeb);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueWeb = new PolSourceObservationIssueWeb();
                    Assert.IsNotNull(polSourceObservationIssue.PolSourceObservationIssueWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceObservationIssue.PolSourceObservationIssueReport   (PolSourceObservationIssueReport)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueReport = null;
                    Assert.IsNull(polSourceObservationIssue.PolSourceObservationIssueReport);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.PolSourceObservationIssueReport = new PolSourceObservationIssueReport();
                    Assert.IsNotNull(polSourceObservationIssue.PolSourceObservationIssueReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateDate_UTC = new DateTime();
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationIssueLastUpdateDate_UTC), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceObservationIssueLastUpdateDate_UTC, "1980"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 0;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, polSourceObservationIssue.LastUpdateContactTVItemID.ToString()), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservationIssue = null;
                    polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
                    polSourceObservationIssue.LastUpdateContactTVItemID = 1;
                    polSourceObservationIssueService.Add(polSourceObservationIssue);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationIssueLastUpdateContactTVItemID, "Contact"), polSourceObservationIssue.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationIssueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservationIssue);

                    PolSourceObservationIssue polSourceObservationIssueRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceObservationIssueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                            Assert.IsNull(polSourceObservationIssueRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueRet = polSourceObservationIssueService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssue.PolSourceObservationIssueID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(new List<PolSourceObservationIssue>() { polSourceObservationIssueRet }, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservationIssue polSourceObservationIssue = (from c in polSourceObservationIssueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservationIssue);

                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceObservationIssueService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationIssueDirectQueryList = polSourceObservationIssueService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        Assert.AreEqual(1, polSourceObservationIssueList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationIssueID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationIssueDirectQueryList = polSourceObservationIssueService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        Assert.AreEqual(1, polSourceObservationIssueList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationIssueID,PolSourceObservationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationIssueDirectQueryList = polSourceObservationIssueService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ThenBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        Assert.AreEqual(1, polSourceObservationIssueList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "PolSourceObservationIssueID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationIssueDirectQueryList = polSourceObservationIssueService.GetRead().Where(c => c.PolSourceObservationIssueID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        Assert.AreEqual(1, polSourceObservationIssueList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationIssueID", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationIssueDirectQueryList = polSourceObservationIssueService.GetRead().Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationIssueID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        Assert.AreEqual(1, polSourceObservationIssueList.Count);
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservationIssue> polSourceObservationIssueList = new List<PolSourceObservationIssue>();
                    List<PolSourceObservationIssue> polSourceObservationIssueDirectQueryList = new List<PolSourceObservationIssue>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationIssueService.Query = polSourceObservationIssueService.FillQuery(typeof(PolSourceObservationIssue), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceObservationIssueID,GT,2|PolSourceObservationIssueID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationIssueDirectQueryList = polSourceObservationIssueService.GetRead().Where(c => c.PolSourceObservationIssueID > 2 && c.PolSourceObservationIssueID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                            Assert.AreEqual(0, polSourceObservationIssueList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationIssueList = polSourceObservationIssueService.GetPolSourceObservationIssueList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationIssueFields(polSourceObservationIssueList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationIssueDirectQueryList[0].PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);
                        Assert.AreEqual(2, polSourceObservationIssueList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationIssueList() 2Where

        #region Functions private
        private void CheckPolSourceObservationIssueFields(List<PolSourceObservationIssue> polSourceObservationIssueList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // PolSourceObservationIssue fields
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

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // PolSourceObservationIssueWeb and PolSourceObservationIssueReport fields should be null here
                Assert.IsNull(polSourceObservationIssueList[0].PolSourceObservationIssueWeb);
                Assert.IsNull(polSourceObservationIssueList[0].PolSourceObservationIssueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // PolSourceObservationIssueWeb fields should not be null and PolSourceObservationIssueReport fields should be null here
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].PolSourceObservationIssueWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].PolSourceObservationIssueWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(polSourceObservationIssueList[0].PolSourceObservationIssueReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // PolSourceObservationIssueWeb and PolSourceObservationIssueReport fields should NOT be null here
                if (polSourceObservationIssueList[0].PolSourceObservationIssueWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].PolSourceObservationIssueWeb.LastUpdateContactTVText));
                }
                if (polSourceObservationIssueList[0].PolSourceObservationIssueReport.PolSourceObservationIssueReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].PolSourceObservationIssueReport.PolSourceObservationIssueReportTest));
                }
            }
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
