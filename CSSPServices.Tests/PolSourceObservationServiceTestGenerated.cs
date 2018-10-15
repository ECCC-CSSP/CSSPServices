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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
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

                    count = polSourceObservationService.GetPolSourceObservationList().Count();

                    Assert.AreEqual(polSourceObservationService.GetPolSourceObservationList().Count(), (from c in dbTestDB.PolSourceObservations select c).Take(200).Count());

                    polSourceObservationService.Add(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, polSourceObservationService.GetPolSourceObservationList().Where(c => c == polSourceObservation).Any());
                    polSourceObservationService.Update(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, polSourceObservationService.GetPolSourceObservationList().Count());
                    polSourceObservationService.Delete(polSourceObservation);
                    if (polSourceObservation.HasErrors)
                    {
                        Assert.AreEqual("", polSourceObservation.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, polSourceObservationService.GetPolSourceObservationList().Count());

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
                    Assert.AreEqual(count, polSourceObservationService.GetPolSourceObservationList().Count());


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in dbTestDB.PolSourceObservations select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        polSourceObservationService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            PolSourceObservation polSourceObservationRet = polSourceObservationService.GetPolSourceObservationWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            CheckPolSourceObservationFields(new List<PolSourceObservation>() { polSourceObservationRet });
                            Assert.AreEqual(polSourceObservation.PolSourceObservationID, polSourceObservationRet.PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            PolSourceObservationExtraA polSourceObservationExtraARet = polSourceObservationService.GetPolSourceObservationExtraAWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            CheckPolSourceObservationExtraAFields(new List<PolSourceObservationExtraA>() { polSourceObservationExtraARet });
                            Assert.AreEqual(polSourceObservation.PolSourceObservationID, polSourceObservationExtraARet.PolSourceObservationID);
                        }
                        else if (detail == "ExtraB")
                        {
                            PolSourceObservationExtraB polSourceObservationExtraBRet = polSourceObservationService.GetPolSourceObservationExtraBWithPolSourceObservationID(polSourceObservation.PolSourceObservationID);
                            CheckPolSourceObservationExtraBFields(new List<PolSourceObservationExtraB>() { polSourceObservationExtraBRet });
                            Assert.AreEqual(polSourceObservation.PolSourceObservationID, polSourceObservationExtraBRet.PolSourceObservationID);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    PolSourceObservation polSourceObservation = (from c in dbTestDB.PolSourceObservations select c).FirstOrDefault();
                    Assert.IsNotNull(polSourceObservation);

                    List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                    polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        polSourceObservationService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraAList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraBList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1,  "PolSourceObservationID", "");

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Skip(1).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraAList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraBList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 1, 1, "PolSourceObservationID,PolSourceSiteID", "");

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Skip(1).Take(1).OrderBy(c => c.PolSourceObservationID).ThenBy(c => c.PolSourceSiteID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraAList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraBList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "PolSourceObservationID,EQ,4", "");

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID == 4).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraAList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraBList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 1, "PolSourceObservationID", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5", "");

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).Skip(0).Take(1).OrderBy(c => c.PolSourceObservationID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraAList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraBList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        PolSourceObservationService polSourceObservationService = new PolSourceObservationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        polSourceObservationService.Query = polSourceObservationService.FillQuery(typeof(PolSourceObservation), culture.TwoLetterISOLanguageName, 0, 10000, "", "PolSourceObservationID,GT,2|PolSourceObservationID,LT,5", "");

                        List<PolSourceObservation> polSourceObservationDirectQueryList = new List<PolSourceObservation>();
                        polSourceObservationDirectQueryList = (from c in dbTestDB.PolSourceObservations select c).Where(c => c.PolSourceObservationID > 2 && c.PolSourceObservationID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<PolSourceObservation> polSourceObservationList = new List<PolSourceObservation>();
                            polSourceObservationList = polSourceObservationService.GetPolSourceObservationList().ToList();
                            CheckPolSourceObservationFields(polSourceObservationList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationList[0].PolSourceObservationID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<PolSourceObservationExtraA> polSourceObservationExtraAList = new List<PolSourceObservationExtraA>();
                            polSourceObservationExtraAList = polSourceObservationService.GetPolSourceObservationExtraAList().ToList();
                            CheckPolSourceObservationExtraAFields(polSourceObservationExtraAList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraAList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<PolSourceObservationExtraB> polSourceObservationExtraBList = new List<PolSourceObservationExtraB>();
                            polSourceObservationExtraBList = polSourceObservationService.GetPolSourceObservationExtraBList().ToList();
                            CheckPolSourceObservationExtraBFields(polSourceObservationExtraBList);
                            Assert.AreEqual(polSourceObservationDirectQueryList[0].PolSourceObservationID, polSourceObservationExtraBList[0].PolSourceObservationID);
                            Assert.AreEqual(polSourceObservationDirectQueryList.Count, polSourceObservationExtraBList.Count);
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
        private void CheckPolSourceObservationExtraAFields(List<PolSourceObservationExtraA> polSourceObservationExtraAList)
        {
            Assert.IsNotNull(polSourceObservationExtraAList[0].PolSourceSiteTVItemLanguage);
            Assert.IsNotNull(polSourceObservationExtraAList[0].ContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationExtraAList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationExtraAList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationExtraAList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationExtraAList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationExtraAList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationExtraAList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationExtraAList[0].HasErrors);
        }
        private void CheckPolSourceObservationExtraBFields(List<PolSourceObservationExtraB> polSourceObservationExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceObservationExtraBList[0].PolSourceObservationReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationExtraBList[0].PolSourceObservationReportTest));
            }
            Assert.IsNotNull(polSourceObservationExtraBList[0].PolSourceSiteTVItemLanguage);
            Assert.IsNotNull(polSourceObservationExtraBList[0].ContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationExtraBList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(polSourceObservationExtraBList[0].PolSourceObservationID);
            Assert.IsNotNull(polSourceObservationExtraBList[0].PolSourceSiteID);
            Assert.IsNotNull(polSourceObservationExtraBList[0].ObservationDate_Local);
            Assert.IsNotNull(polSourceObservationExtraBList[0].ContactTVItemID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(polSourceObservationExtraBList[0].Observation_ToBeDeleted));
            Assert.IsNotNull(polSourceObservationExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(polSourceObservationExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(polSourceObservationExtraBList[0].HasErrors);
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
