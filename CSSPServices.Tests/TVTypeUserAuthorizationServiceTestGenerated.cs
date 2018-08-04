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
    public partial class TVTypeUserAuthorizationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationServiceTest() : base()
        {
            //tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVTypeUserAuthorization_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVTypeUserAuthorization tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().Count();

                    Assert.AreEqual(tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().Count(), (from c in dbTestDB.TVTypeUserAuthorizations select c).Take(200).Count());

                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().Where(c => c == tvTypeUserAuthorization).Any());
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().Count());
                    tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvTypeUserAuthorization.TVTypeUserAuthorizationID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationTVTypeUserAuthorizationID"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationID = 10000000;
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVTypeUserAuthorization", "TVTypeUserAuthorizationTVTypeUserAuthorizationID", tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvTypeUserAuthorization.ContactTVItemID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.ContactTVItemID = 0;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVTypeUserAuthorizationContactTVItemID", tvTypeUserAuthorization.ContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.ContactTVItemID = 1;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVTypeUserAuthorizationContactTVItemID", "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvTypeUserAuthorization.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVType = (TVTypeEnum)1000000;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationTVType"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationTVAuth"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime();
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVTypeUserAuthorizationLastUpdateDate_UTC"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVTypeUserAuthorizationLastUpdateDate_UTC", "1980"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVTypeUserAuthorizationLastUpdateContactTVItemID", tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVTypeUserAuthorizationLastUpdateContactTVItemID", "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID)
        [TestMethod]
        public void GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID__tvTypeUserAuthorization_TVTypeUserAuthorizationID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVTypeUserAuthorization tvTypeUserAuthorization = (from c in dbTestDB.TVTypeUserAuthorizations select c).FirstOrDefault();
                    Assert.IsNotNull(tvTypeUserAuthorization);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvTypeUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            TVTypeUserAuthorization tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                            CheckTVTypeUserAuthorizationFields(new List<TVTypeUserAuthorization>() { tvTypeUserAuthorizationRet });
                            Assert.AreEqual(tvTypeUserAuthorization.TVTypeUserAuthorizationID, tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            TVTypeUserAuthorizationWeb tvTypeUserAuthorizationWebRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                            CheckTVTypeUserAuthorizationWebFields(new List<TVTypeUserAuthorizationWeb>() { tvTypeUserAuthorizationWebRet });
                            Assert.AreEqual(tvTypeUserAuthorization.TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebRet.TVTypeUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            TVTypeUserAuthorizationReport tvTypeUserAuthorizationReportRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                            CheckTVTypeUserAuthorizationReportFields(new List<TVTypeUserAuthorizationReport>() { tvTypeUserAuthorizationReportRet });
                            Assert.AreEqual(tvTypeUserAuthorization.TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportRet.TVTypeUserAuthorizationID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID)

        #region Tests Generated for GetTVTypeUserAuthorizationList()
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVTypeUserAuthorization tvTypeUserAuthorization = (from c in dbTestDB.TVTypeUserAuthorizations select c).FirstOrDefault();
                    Assert.IsNotNull(tvTypeUserAuthorization);

                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvTypeUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList()

        #region Tests Generated for GetTVTypeUserAuthorizationList() Skip Take
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                        tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() Skip Take

        #region Tests Generated for GetTVTypeUserAuthorizationList() Skip Take Order
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1,  "TVTypeUserAuthorizationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                        tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Skip(1).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() Skip Take Order

        #region Tests Generated for GetTVTypeUserAuthorizationList() Skip Take 2Order
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "TVTypeUserAuthorizationID,ContactTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                        tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Skip(1).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ThenBy(c => c.ContactTVItemID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() Skip Take 2Order

        #region Tests Generated for GetTVTypeUserAuthorizationList() Skip Take Order Where
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVTypeUserAuthorizationID", "TVTypeUserAuthorizationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                        tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID == 4).Skip(0).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() Skip Take Order Where

        #region Tests Generated for GetTVTypeUserAuthorizationList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVTypeUserAuthorizationID", "TVTypeUserAuthorizationID,GT,2|TVTypeUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                        tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID > 2 && c.TVTypeUserAuthorizationID < 5).Skip(0).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() Skip Take Order 2Where

        #region Tests Generated for GetTVTypeUserAuthorizationList() 2Where
        [TestMethod]
        public void GetTVTypeUserAuthorizationList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVTypeUserAuthorizationID,GT,2|TVTypeUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                        tvTypeUserAuthorizationDirectQueryList = (from c in dbTestDB.TVTypeUserAuthorizations select c).Where(c => c.TVTypeUserAuthorizationID > 2 && c.TVTypeUserAuthorizationID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList = new List<TVTypeUserAuthorizationWeb>();
                            tvTypeUserAuthorizationWebList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWebList().ToList();
                            CheckTVTypeUserAuthorizationWebFields(tvTypeUserAuthorizationWebList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList = new List<TVTypeUserAuthorizationReport>();
                            tvTypeUserAuthorizationReportList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationReportList().ToList();
                            CheckTVTypeUserAuthorizationReportFields(tvTypeUserAuthorizationReportList);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
                            Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList.Count, tvTypeUserAuthorizationReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() 2Where

        #region Functions private
        private void CheckTVTypeUserAuthorizationFields(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].ContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].TVType);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].TVAuth);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].HasErrors);
        }
        private void CheckTVTypeUserAuthorizationWebFields(List<TVTypeUserAuthorizationWeb> tvTypeUserAuthorizationWebList)
        {
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].ContactTVItemLanguage);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationWebList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationWebList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationWebList[0].TVAuthText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationWebList[0].TVAuthText));
            }
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].TVTypeUserAuthorizationID);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].ContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].TVType);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].TVAuth);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationWebList[0].HasErrors);
        }
        private void CheckTVTypeUserAuthorizationReportFields(List<TVTypeUserAuthorizationReport> tvTypeUserAuthorizationReportList)
        {
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationReportTest));
            }
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].ContactTVItemLanguage);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationReportList[0].TVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationReportList[0].TVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationReportList[0].TVAuthText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationReportList[0].TVAuthText));
            }
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].TVTypeUserAuthorizationID);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].ContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].TVType);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].TVAuth);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationReportList[0].HasErrors);
        }
        private TVTypeUserAuthorization GetFilledRandomTVTypeUserAuthorization(string OmitPropName)
        {
            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvTypeUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVType") tvTypeUserAuthorization.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVAuth") tvTypeUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;

            return tvTypeUserAuthorization;
        }
        #endregion Functions private
    }
}
