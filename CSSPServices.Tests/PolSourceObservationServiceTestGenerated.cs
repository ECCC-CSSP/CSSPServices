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
    public partial class PolSourceObservationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private PolSourceObservationService polSourceObservationService { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationServiceTest() : base()
        {
            //polSourceObservationService = new PolSourceObservationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void PolSourceObservation_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    PolSourceObservation polSourceObservation = GetFilledRandomPolSourceObservation("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = polSourceObservationService.GetRead().Count();

                    Assert.AreEqual(polSourceObservationService.GetRead().Count(), polSourceObservationService.GetEdit().Count());

                    polSourceObservationService.Add(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceObservationService.GetRead().Where(c => c == polSourceObservation).Any());
                    polSourceObservationService.Update(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceObservationService.GetRead().Count());
                    polSourceObservationService.Delete(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // polSourceObservation.PolSourceObservationID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationID = 0;
                    polSourceObservationService.Update(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationPolSourceObservationID), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationID = 10000000;
                    polSourceObservationService.Update(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationPolSourceObservationID, polSourceObservation.PolSourceObservationID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID", AllowableTVtypeList = )]
                    // polSourceObservation.PolSourceSiteID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceSiteID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceSite, CSSPModelsRes.PolSourceObservationPolSourceSiteID, polSourceObservation.PolSourceSiteID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.ObservationDate_Local   (DateTime)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ObservationDate_Local = new DateTime();
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationObservationDate_Local), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ObservationDate_Local = new DateTime(1979, 1, 1);
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceObservationObservationDate_Local, "1980"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.ContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationContactTVItemID, polSourceObservation.ContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationContactTVItemID, "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceObservation.Observation_ToBeDeleted   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationObservation_ToBeDeleted)).Any());
                    Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceObservation.PolSourceObservationWeb   (PolSourceObservationWeb)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationWeb = null;
                    Assert.IsNull(polSourceObservation.PolSourceObservationWeb);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationWeb = new PolSourceObservationWeb();
                    Assert.IsNotNull(polSourceObservation.PolSourceObservationWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // polSourceObservation.PolSourceObservationReport   (PolSourceObservationReport)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationReport = null;
                    Assert.IsNull(polSourceObservation.PolSourceObservationReport);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationReport = new PolSourceObservationReport();
                    Assert.IsNotNull(polSourceObservation.PolSourceObservationReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateDate_UTC = new DateTime();
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationLastUpdateDate_UTC), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceObservationLastUpdateDate_UTC, "1980"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID, polSourceObservation.LastUpdateContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID, "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservation.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // polSourceObservation.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID)
        [TestMethod]
        public void GetPolSourceObservationWithPolSourceObservationID__polSourceObservation_PolSourceObservationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in polSourceObservationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                    PolSourceObservation polSourceObservationRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceObservationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            Assert.IsNull(polSourceObservationRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(new List<PolSourceObservation>() { polSourceObservationRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID)

        #region Tests Generated for GetPolSourceObservationList()
        [TestMethod]
        public void GetPolSourceObservationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in polSourceObservationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceObservationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList()

        #region Tests Generated for GetPolSourceObservationList() Skip Take
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        Assert.AreEqual(1, polSourceObservationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take

        #region Tests Generated for GetPolSourceObservationList() Skip Take Order
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        Assert.AreEqual(1, polSourceObservationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Order

        #region Tests Generated for GetPolSourceObservationList() Skip Take 2Order
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationID,PolSourceSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceObservationID).ThenBy(c => c.PolSourceSiteID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        Assert.AreEqual(1, polSourceObservationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take 2Order

        #region Tests Generated for GetPolSourceObservationList() Skip Take Order Where
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "PolSourceObservationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Where(c => c.PolSourceObservationID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        Assert.AreEqual(1, polSourceObservationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Order Where

        #region Tests Generated for GetPolSourceObservationList() Skip Take Order 2Where
        [TestMethod]
        public void GetPolSourceObservationList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        Assert.AreEqual(1, polSourceObservationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() Skip Take Order 2Where

        #region Tests Generated for GetPolSourceObservationList() 2Where
        [TestMethod]
        public void GetPolSourceObservationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            Assert.AreEqual(0, polSourceObservationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckPolSourceObservationFields(polSourceObservationList, entityQueryDetailType);
                        Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        Assert.AreEqual(2, polSourceObservationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() 2Where

        #region Functions private
        private void CheckPolSourceObservationFields(List<PolSourceObservation> polSourceObservationList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // PolSourceObservation fields
            Assert.IsNotNull(polSourceObservationList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // PolSourceObservationWeb and PolSourceObservationReport fields should be null here
                Assert.IsNull(polSourceObservationList[0].PolSourceObservationWeb);
                Assert.IsNull(polSourceObservationList[0].PolSourceObservationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // PolSourceObservationWeb fields should not be null and PolSourceObservationReport fields should be null here
                if (!string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.PolSourceSiteTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.PolSourceSiteTVText));
                }
                if (!string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.ContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.ContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(polSourceObservationList[0].PolSourceObservationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // PolSourceObservationWeb and PolSourceObservationReport fields should NOT be null here
                if (polSourceObservationList[0].PolSourceObservationWeb.PolSourceSiteTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.PolSourceSiteTVText));
                }
                if (polSourceObservationList[0].PolSourceObservationWeb.ContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.ContactTVText));
                }
                if (polSourceObservationList[0].PolSourceObservationWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationWeb.LastUpdateContactTVText));
                }
                if (polSourceObservationList[0].PolSourceObservationReport.PolSourceObservationReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].PolSourceObservationReport.PolSourceObservationReportTest));
                }
            }
        }
        private PolSourceObservation GetFilledRandomPolSourceObservation(string OmitPropName)
        {
            PolSourceObservation polSourceObservation = new PolSourceObservation();

            if (OmitPropName != "PolSourceSiteID") polSourceObservation.PolSourceSiteID = 1;
            if (OmitPropName != "ObservationDate_Local") polSourceObservation.ObservationDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "ContactTVItemID") polSourceObservation.ContactTVItemID = 2;
            if (OmitPropName != "Observation_ToBeDeleted") polSourceObservation.Observation_ToBeDeleted = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservation.LastUpdateContactTVItemID = 2;

            return polSourceObservation;
        }
        #endregion Functions private
    }
}
