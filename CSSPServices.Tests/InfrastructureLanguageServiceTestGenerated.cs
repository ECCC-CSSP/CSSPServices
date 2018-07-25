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
    public partial class InfrastructureLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private InfrastructureLanguageService infrastructureLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageServiceTest() : base()
        {
            //infrastructureLanguageService = new InfrastructureLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void InfrastructureLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    InfrastructureLanguage infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = infrastructureLanguageService.GetRead().Count();

                    Assert.AreEqual(infrastructureLanguageService.GetRead().Count(), infrastructureLanguageService.GetEdit().Count());

                    infrastructureLanguageService.Add(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, infrastructureLanguageService.GetRead().Where(c => c == infrastructureLanguage).Any());
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, infrastructureLanguageService.GetRead().Count());
                    infrastructureLanguageService.Delete(infrastructureLanguage);
                    if (infrastructureLanguage.HasErrors)
                    {
                        Assert.AreEqual("", infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // infrastructureLanguage.InfrastructureLanguageID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageID = 0;
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageID = 10000000;
                    infrastructureLanguageService.Update(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.InfrastructureLanguage, CSSPModelsRes.InfrastructureLanguageInfrastructureLanguageID, infrastructureLanguage.InfrastructureLanguageID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID", AllowableTVtypeList = Error)]
                    // infrastructureLanguage.InfrastructureID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureID = 0;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Infrastructure, CSSPModelsRes.InfrastructureLanguageInfrastructureID, infrastructureLanguage.InfrastructureID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // infrastructureLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.Language = (LanguageEnum)1000000;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageLanguage), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // infrastructureLanguage.Comment   (String)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
                    Assert.AreEqual(false, infrastructureLanguageService.Add(infrastructureLanguage));
                    Assert.AreEqual(1, infrastructureLanguage.ValidationResults.Count());
                    Assert.IsTrue(infrastructureLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageComment)).Any());
                    Assert.AreEqual(null, infrastructureLanguage.Comment);
                    Assert.AreEqual(count, infrastructureLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // infrastructureLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageTranslationStatus), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // infrastructureLanguage.InfrastructureLanguageWeb   (InfrastructureLanguageWeb)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageWeb = null;
                    Assert.IsNull(infrastructureLanguage.InfrastructureLanguageWeb);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageWeb = new InfrastructureLanguageWeb();
                    Assert.IsNotNull(infrastructureLanguage.InfrastructureLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // infrastructureLanguage.InfrastructureLanguageReport   (InfrastructureLanguageReport)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageReport = null;
                    Assert.IsNull(infrastructureLanguage.InfrastructureLanguageReport);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.InfrastructureLanguageReport = new InfrastructureLanguageReport();
                    Assert.IsNotNull(infrastructureLanguage.InfrastructureLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // infrastructureLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateDate_UTC = new DateTime();
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.InfrastructureLanguageLastUpdateDate_UTC, "1980"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // infrastructureLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateContactTVItemID = 0;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, infrastructureLanguage.LastUpdateContactTVItemID.ToString()), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    infrastructureLanguage = null;
                    infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
                    infrastructureLanguage.LastUpdateContactTVItemID = 1;
                    infrastructureLanguageService.Add(infrastructureLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.InfrastructureLanguageLastUpdateContactTVItemID, "Contact"), infrastructureLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructureLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // infrastructureLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID)
        [TestMethod]
        public void GetInfrastructureLanguageWithInfrastructureLanguageID__infrastructureLanguage_InfrastructureLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in infrastructureLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    InfrastructureLanguage infrastructureLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        infrastructureLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                            Assert.IsNull(infrastructureLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageRet = infrastructureLanguageService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(new List<InfrastructureLanguage>() { infrastructureLanguageRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguage.InfrastructureLanguageID)

        #region Tests Generated for GetInfrastructureLanguageList()
        [TestMethod]
        public void GetInfrastructureLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    InfrastructureLanguage infrastructureLanguage = (from c in infrastructureLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(infrastructureLanguage);

                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        infrastructureLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList()

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        infrastructureLanguageDirectQueryList = infrastructureLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                        Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        Assert.AreEqual(1, infrastructureLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take Order
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "InfrastructureLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        infrastructureLanguageDirectQueryList = infrastructureLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                        Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        Assert.AreEqual(1, infrastructureLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take Order

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 1, 1, "InfrastructureLanguageID,InfrastructureID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        infrastructureLanguageDirectQueryList = infrastructureLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.InfrastructureLanguageID).ThenBy(c => c.InfrastructureID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                        Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        Assert.AreEqual(1, infrastructureLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take 2Order

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureLanguageID", "InfrastructureLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        infrastructureLanguageDirectQueryList = infrastructureLanguageService.GetRead().Where(c => c.InfrastructureLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                        Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        Assert.AreEqual(1, infrastructureLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take Order Where

        #region Tests Generated for GetInfrastructureLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetInfrastructureLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 1, "InfrastructureLanguageID", "InfrastructureLanguageID,GT,2|InfrastructureLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        infrastructureLanguageDirectQueryList = infrastructureLanguageService.GetRead().Where(c => c.InfrastructureLanguageID > 2 && c.InfrastructureLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.InfrastructureLanguageID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                        Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        Assert.AreEqual(1, infrastructureLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetInfrastructureLanguageList() 2Where
        [TestMethod]
        public void GetInfrastructureLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<InfrastructureLanguage> infrastructureLanguageList = new List<InfrastructureLanguage>();
                    List<InfrastructureLanguage> infrastructureLanguageDirectQueryList = new List<InfrastructureLanguage>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        InfrastructureLanguageService infrastructureLanguageService = new InfrastructureLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        infrastructureLanguageService.Query = infrastructureLanguageService.FillQuery(typeof(InfrastructureLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "InfrastructureLanguageID,GT,2|InfrastructureLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        infrastructureLanguageDirectQueryList = infrastructureLanguageService.GetRead().Where(c => c.InfrastructureLanguageID > 2 && c.InfrastructureLanguageID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                            Assert.AreEqual(0, infrastructureLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            infrastructureLanguageList = infrastructureLanguageService.GetInfrastructureLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckInfrastructureLanguageFields(infrastructureLanguageList, entityQueryDetailType);
                        Assert.AreEqual(infrastructureLanguageDirectQueryList[0].InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);
                        Assert.AreEqual(2, infrastructureLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetInfrastructureLanguageList() 2Where

        #region Functions private
        private void CheckInfrastructureLanguageFields(List<InfrastructureLanguage> infrastructureLanguageList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // InfrastructureLanguage fields
            Assert.IsNotNull(infrastructureLanguageList[0].InfrastructureLanguageID);
            Assert.IsNotNull(infrastructureLanguageList[0].InfrastructureID);
            Assert.IsNotNull(infrastructureLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].Comment));
            Assert.IsNotNull(infrastructureLanguageList[0].TranslationStatus);
            Assert.IsNotNull(infrastructureLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(infrastructureLanguageList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // InfrastructureLanguageWeb and InfrastructureLanguageReport fields should be null here
                Assert.IsNull(infrastructureLanguageList[0].InfrastructureLanguageWeb);
                Assert.IsNull(infrastructureLanguageList[0].InfrastructureLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // InfrastructureLanguageWeb fields should not be null and InfrastructureLanguageReport fields should be null here
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.TranslationStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.TranslationStatusText));
                }
                Assert.IsNull(infrastructureLanguageList[0].InfrastructureLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // InfrastructureLanguageWeb and InfrastructureLanguageReport fields should NOT be null here
                if (infrastructureLanguageList[0].InfrastructureLanguageWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.LastUpdateContactTVText));
                }
                if (infrastructureLanguageList[0].InfrastructureLanguageWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.LanguageText));
                }
                if (infrastructureLanguageList[0].InfrastructureLanguageWeb.TranslationStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageWeb.TranslationStatusText));
                }
                if (infrastructureLanguageList[0].InfrastructureLanguageReport.InfrastructureLanguageReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].InfrastructureLanguageReport.InfrastructureLanguageReportTest));
                }
            }
        }
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 1;
            if (OmitPropName != "Language") infrastructureLanguage.Language = LanguageRequest;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;

            return infrastructureLanguage;
        }
        #endregion Functions private
    }
}
