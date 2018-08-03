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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationPolSourceObservationID"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceObservationID = 10000000;
                    polSourceObservationService.Update(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceObservation", "PolSourceObservationPolSourceObservationID", polSourceObservation.PolSourceObservationID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "PolSourceSite", ExistPlurial = "s", ExistFieldID = "PolSourceSiteID", AllowableTVtypeList = )]
                    // polSourceObservation.PolSourceSiteID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.PolSourceSiteID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceObservationPolSourceSiteID", polSourceObservation.PolSourceSiteID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.ObservationDate_Local   (DateTime)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ObservationDate_Local = new DateTime();
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationObservationDate_Local"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ObservationDate_Local = new DateTime(1979, 1, 1);
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceObservationObservationDate_Local", "1980"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.ContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceObservationContactTVItemID", polSourceObservation.ContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.ContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceObservationContactTVItemID", "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // polSourceObservation.Observation_ToBeDeleted   (String)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("Observation_ToBeDeleted");
                    Assert.AreEqual(false, polSourceObservationService.Add(polSourceObservation));
                    Assert.AreEqual(1, polSourceObservation.ValidationResults.Count());
                    Assert.IsTrue(polSourceObservation.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationObservation_ToBeDeleted")).Any());
                    Assert.AreEqual(null, polSourceObservation.Observation_ToBeDeleted);
                    Assert.AreEqual(count, polSourceObservationService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // polSourceObservation.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateDate_UTC = new DateTime();
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "PolSourceObservationLastUpdateDate_UTC"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "PolSourceObservationLastUpdateDate_UTC", "1980"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // polSourceObservation.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 0;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "PolSourceObservationLastUpdateContactTVItemID", polSourceObservation.LastUpdateContactTVItemID.ToString()), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);

                    polSourceObservation = null;
                    polSourceObservation = GetFilledRandomPolSourceObservation("");
                    polSourceObservation.LastUpdateContactTVItemID = 1;
                    polSourceObservationService.Add(polSourceObservation);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "PolSourceObservationLastUpdateContactTVItemID", "Contact"), polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);


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

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceObservationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            PolSourceObservation polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            CheckPolSourceObservationFields(new List<PolSourceObservation>() { polSourceObservationRet });
                            Assert.AreEqual(polSourceObservation.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            PolSourceObservationWeb polSourceObservationWebRet = polSourceObservationService.GetPolSourceObservationWebWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            CheckPolSourceObservationWebFields(new List<PolSourceObservationWeb>() { polSourceObservationWebRet });
                            Assert.AreEqual(polSourceObservation.PolSourceObservationID, polSourceObservationWebRet.PolSourceObservationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            PolSourceObservationReport polSourceObservationReportRet = polSourceObservationService.GetPolSourceObservationReportWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            CheckPolSourceObservationReportFields(new List<PolSourceObservationReport>() { polSourceObservationReportRet });
                            Assert.AreEqual(polSourceObservation.PolSourceObservationID, polSourceObservationReportRet.PolSourceObservationID);
                        }
                        else
                        {
                            // nothing for now
                        }
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

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        polSourceObservationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationWebList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationReportList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationWebList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationReportList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationID,PolSourceSiteID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Skip(1).Take(1).OrderBy(c => c.PolSourceObservationID).ThenBy(c => c.PolSourceSiteID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationWebList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationReportList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "PolSourceObservationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Where(c => c.PolSourceObservationID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationWebList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationReportList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationWebList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationReportList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = polSourceObservationService.GetRead().Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<PolSourceObservationWeb> polSourceObservationWebList = new List<PolSourceObservationWeb>();
                            polSourceObservationWebList = polSourceObservationService.GetPolSourceObservationWebList().ToList();
                            CheckPolSourceObservationWebFields(polSourceObservationWebList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationWebList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<PolSourceObservationReport> polSourceObservationReportList = new List<PolSourceObservationReport>();
                            polSourceObservationReportList = polSourceObservationService.GetPolSourceObservationReportList().ToList();
                            CheckPolSourceObservationReportFields(polSourceObservationReportList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationReportList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetPolSourceObservationList() 2Where

        #region Functions private
        private void CheckPolSourceObservationFields(List<PolSourceObservation> polSourceObservationList)
        {
            Assert.IsNotNull(polSourceObservationList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationList[0].HasErrors);
        }
        private void CheckPolSourceObservationWebFields(List<PolSourceObservationWeb> polSourceObservationWebList)
        {
            Assert.IsNotNull(polSourceObservationWebList[0].PolSourceSiteTVItemLanguage);
            Assert.IsNotNull(polSourceObservationWebList[0].ContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationWebList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationWebList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationWebList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationWebList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationWebList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationWebList[0].HasErrors);
        }
        private void CheckPolSourceObservationReportFields(List<PolSourceObservationReport> polSourceObservationReportList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceObservationReportList[0].PolSourceObservationReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationReportList[0].PolSourceObservationReportTest));
            }
            Assert.IsNotNull(polSourceObservationReportList[0].PolSourceSiteTVItemLanguage);
            Assert.IsNotNull(polSourceObservationReportList[0].ContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationReportList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationReportList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationReportList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationReportList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationReportList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationReportList[0].HasErrors);
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
