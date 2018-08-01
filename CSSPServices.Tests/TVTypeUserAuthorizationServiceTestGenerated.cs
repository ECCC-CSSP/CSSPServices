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

                    count = tvTypeUserAuthorizationService.GetRead().Count();

                    Assert.AreEqual(tvTypeUserAuthorizationService.GetRead().Count(), tvTypeUserAuthorizationService.GetEdit().Count());

                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvTypeUserAuthorizationService.GetRead().Where(c => c == tvTypeUserAuthorization).Any());
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvTypeUserAuthorizationService.GetRead().Count());
                    tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationID = 10000000;
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVTypeUserAuthorization, CSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID, tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvTypeUserAuthorization.ContactTVItemID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.ContactTVItemID = 0;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVTypeUserAuthorizationContactTVItemID, tvTypeUserAuthorization.ContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.ContactTVItemID = 1;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVTypeUserAuthorizationContactTVItemID, "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvTypeUserAuthorization.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVType = (TVTypeEnum)1000000;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVType), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVAuth), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.TVTypeUserAuthorizationWeb   (TVTypeUserAuthorizationWeb)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationWeb = null;
                    Assert.IsNull(tvTypeUserAuthorization.TVTypeUserAuthorizationWeb);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationWeb = new TVTypeUserAuthorizationWeb();
                    Assert.IsNotNull(tvTypeUserAuthorization.TVTypeUserAuthorizationWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.TVTypeUserAuthorizationReport   (TVTypeUserAuthorizationReport)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationReport = null;
                    Assert.IsNull(tvTypeUserAuthorization.TVTypeUserAuthorizationReport);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationReport = new TVTypeUserAuthorizationReport();
                    Assert.IsNotNull(tvTypeUserAuthorization.TVTypeUserAuthorizationReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime();
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC, "1980"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    TVTypeUserAuthorization tvTypeUserAuthorization = (from c in tvTypeUserAuthorizationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvTypeUserAuthorization);

                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvTypeUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                            Assert.IsNull(tvTypeUserAuthorizationRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(new List<TVTypeUserAuthorization>() { tvTypeUserAuthorizationRet }, entityQueryDetailType);
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
                    TVTypeUserAuthorization tvTypeUserAuthorization = (from c in tvTypeUserAuthorizationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvTypeUserAuthorization);

                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvTypeUserAuthorizationService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
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
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvTypeUserAuthorizationDirectQueryList = tvTypeUserAuthorizationService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual(1, tvTypeUserAuthorizationList.Count);
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
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1,  "TVTypeUserAuthorizationID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvTypeUserAuthorizationDirectQueryList = tvTypeUserAuthorizationService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual(1, tvTypeUserAuthorizationList.Count);
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
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 1, 1, "TVTypeUserAuthorizationID,ContactTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvTypeUserAuthorizationDirectQueryList = tvTypeUserAuthorizationService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ThenBy(c => c.ContactTVItemID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual(1, tvTypeUserAuthorizationList.Count);
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
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVTypeUserAuthorizationID", "TVTypeUserAuthorizationID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvTypeUserAuthorizationDirectQueryList = tvTypeUserAuthorizationService.GetRead().Where(c => c.TVTypeUserAuthorizationID == 4).Skip(0).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual(1, tvTypeUserAuthorizationList.Count);
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
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 0, 1, "TVTypeUserAuthorizationID", "TVTypeUserAuthorizationID,GT,2|TVTypeUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvTypeUserAuthorizationDirectQueryList = tvTypeUserAuthorizationService.GetRead().Where(c => c.TVTypeUserAuthorizationID > 2 && c.TVTypeUserAuthorizationID < 5).Skip(0).Take(1).OrderBy(c => c.TVTypeUserAuthorizationID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual(1, tvTypeUserAuthorizationList.Count);
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
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = new List<TVTypeUserAuthorization>();
                    List<TVTypeUserAuthorization> tvTypeUserAuthorizationDirectQueryList = new List<TVTypeUserAuthorization>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvTypeUserAuthorizationService.Query = tvTypeUserAuthorizationService.FillQuery(typeof(TVTypeUserAuthorization), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVTypeUserAuthorizationID,GT,2|TVTypeUserAuthorizationID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvTypeUserAuthorizationDirectQueryList = tvTypeUserAuthorizationService.GetRead().Where(c => c.TVTypeUserAuthorizationID > 2 && c.TVTypeUserAuthorizationID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                            Assert.AreEqual(0, tvTypeUserAuthorizationList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvTypeUserAuthorizationList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVTypeUserAuthorizationFields(tvTypeUserAuthorizationList, entityQueryDetailType);
                        Assert.AreEqual(tvTypeUserAuthorizationDirectQueryList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
                        Assert.AreEqual(2, tvTypeUserAuthorizationList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVTypeUserAuthorizationList() 2Where

        #region Functions private
        private void CheckTVTypeUserAuthorizationFields(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // TVTypeUserAuthorization fields
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].ContactTVItemID);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].TVType);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].TVAuth);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvTypeUserAuthorizationList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TVTypeUserAuthorizationWeb and TVTypeUserAuthorizationReport fields should be null here
                Assert.IsNull(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb);
                Assert.IsNull(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TVTypeUserAuthorizationWeb fields should not be null and TVTypeUserAuthorizationReport fields should be null here
                if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.ContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.ContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVTypeText));
                }
                if (!string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVAuthText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVAuthText));
                }
                Assert.IsNull(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TVTypeUserAuthorizationWeb and TVTypeUserAuthorizationReport fields should NOT be null here
                if (tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.ContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.ContactTVText));
                }
                if (tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.LastUpdateContactTVText));
                }
                if (tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVTypeText));
                }
                if (tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVAuthText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationWeb.TVAuthText));
                }
                if (tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationReport.TVTypeUserAuthorizationReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationReport.TVTypeUserAuthorizationReportTest));
                }
            }
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
