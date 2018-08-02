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
    public partial class SpillLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SpillLanguageService spillLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageServiceTest() : base()
        {
            //spillLanguageService = new SpillLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SpillLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = spillLanguageService.GetRead().Count();

                    Assert.AreEqual(spillLanguageService.GetRead().Count(), spillLanguageService.GetEdit().Count());

                    spillLanguageService.Add(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, spillLanguageService.GetRead().Where(c => c == spillLanguage).Any());
                    spillLanguageService.Update(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, spillLanguageService.GetRead().Count());
                    spillLanguageService.Delete(spillLanguage);
                    if (spillLanguage.HasErrors)
                    {
                        Assert.AreEqual("", spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, spillLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // spillLanguage.SpillLanguageID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageID = 0;
                    spillLanguageService.Update(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageSpillLanguageID), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageID = 10000000;
                    spillLanguageService.Update(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SpillLanguage, CSSPModelsRes.SpillLanguageSpillLanguageID, spillLanguage.SpillLanguageID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID", AllowableTVtypeList = )]
                    // spillLanguage.SpillID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillID = 0;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Spill, CSSPModelsRes.SpillLanguageSpillID, spillLanguage.SpillID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // spillLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.Language = (LanguageEnum)1000000;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageLanguage), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // spillLanguage.SpillComment   (String)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
                    Assert.AreEqual(false, spillLanguageService.Add(spillLanguage));
                    Assert.AreEqual(1, spillLanguage.ValidationResults.Count());
                    Assert.IsTrue(spillLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageSpillComment)).Any());
                    Assert.AreEqual(null, spillLanguage.SpillComment);
                    Assert.AreEqual(count, spillLanguageService.GetRead().Count());


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // spillLanguage.TranslationStatus   (TranslationStatusEnum)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageTranslationStatus), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // spillLanguage.SpillLanguageWeb   (SpillLanguageWeb)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageWeb = null;
                    Assert.IsNull(spillLanguage.SpillLanguageWeb);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageWeb = new SpillLanguageWeb();
                    Assert.IsNotNull(spillLanguage.SpillLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // spillLanguage.SpillLanguageReport   (SpillLanguageReport)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageReport = null;
                    Assert.IsNull(spillLanguage.SpillLanguageReport);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.SpillLanguageReport = new SpillLanguageReport();
                    Assert.IsNotNull(spillLanguage.SpillLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // spillLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateDate_UTC = new DateTime();
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLanguageLastUpdateDate_UTC), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillLanguageLastUpdateDate_UTC, "1980"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // spillLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateContactTVItemID = 0;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillLanguageLastUpdateContactTVItemID, spillLanguage.LastUpdateContactTVItemID.ToString()), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    spillLanguage = null;
                    spillLanguage = GetFilledRandomSpillLanguage("");
                    spillLanguage.LastUpdateContactTVItemID = 1;
                    spillLanguageService.Add(spillLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillLanguageLastUpdateContactTVItemID, "Contact"), spillLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spillLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // spillLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID)
        [TestMethod]
        public void GetSpillLanguageWithSpillLanguageID__spillLanguage_SpillLanguageID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SpillLanguage spillLanguage = (from c in spillLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(spillLanguage);

                    SpillLanguage spillLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        spillLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                            Assert.IsNull(spillLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageRet = spillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(new List<SpillLanguage>() { spillLanguageRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageWithSpillLanguageID(spillLanguage.SpillLanguageID)

        #region Tests Generated for GetSpillLanguageList()
        [TestMethod]
        public void GetSpillLanguageList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SpillLanguage spillLanguage = (from c in spillLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(spillLanguage);

                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        spillLanguageService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList()

        #region Tests Generated for GetSpillLanguageList() Skip Take
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        spillLanguageDirectQueryList = spillLanguageService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                        Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                        Assert.AreEqual(1, spillLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take

        #region Tests Generated for GetSpillLanguageList() Skip Take Order
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 1, 1,  "SpillLanguageID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        spillLanguageDirectQueryList = spillLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.SpillLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                        Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                        Assert.AreEqual(1, spillLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take Order

        #region Tests Generated for GetSpillLanguageList() Skip Take 2Order
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 1, 1, "SpillLanguageID,SpillID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        spillLanguageDirectQueryList = spillLanguageService.GetRead().Skip(1).Take(1).OrderBy(c => c.SpillLanguageID).ThenBy(c => c.SpillID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                        Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                        Assert.AreEqual(1, spillLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take 2Order

        #region Tests Generated for GetSpillLanguageList() Skip Take Order Where
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 0, 1, "SpillLanguageID", "SpillLanguageID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        spillLanguageDirectQueryList = spillLanguageService.GetRead().Where(c => c.SpillLanguageID == 4).Skip(0).Take(1).OrderBy(c => c.SpillLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                        Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                        Assert.AreEqual(1, spillLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take Order Where

        #region Tests Generated for GetSpillLanguageList() Skip Take Order 2Where
        [TestMethod]
        public void GetSpillLanguageList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 0, 1, "SpillLanguageID", "SpillLanguageID,GT,2|SpillLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        spillLanguageDirectQueryList = spillLanguageService.GetRead().Where(c => c.SpillLanguageID > 2 && c.SpillLanguageID < 5).Skip(0).Take(1).OrderBy(c => c.SpillLanguageID).ToList();

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                        Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                        Assert.AreEqual(1, spillLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() Skip Take Order 2Where

        #region Tests Generated for GetSpillLanguageList() 2Where
        [TestMethod]
        public void GetSpillLanguageList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SpillLanguage> spillLanguageList = new List<SpillLanguage>();
                    List<SpillLanguage> spillLanguageDirectQueryList = new List<SpillLanguage>();
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SpillLanguageService spillLanguageService = new SpillLanguageService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        spillLanguageService.Query = spillLanguageService.FillQuery(typeof(SpillLanguage), culture.TwoLetterISOLanguageName, 0, 10000, "", "SpillLanguageID,GT,2|SpillLanguageID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        spillLanguageDirectQueryList = spillLanguageService.GetRead().Where(c => c.SpillLanguageID > 2 && c.SpillLanguageID < 5).ToList();

                        if (entityQueryDetailType == null)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                            Assert.AreEqual(0, spillLanguageList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            spillLanguageList = spillLanguageService.GetSpillLanguageList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSpillLanguageFields(spillLanguageList, entityQueryDetailType);
                        Assert.AreEqual(spillLanguageDirectQueryList[0].SpillLanguageID, spillLanguageList[0].SpillLanguageID);
                        Assert.AreEqual(2, spillLanguageList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSpillLanguageList() 2Where

        #region Functions private
        private void CheckSpillLanguageFields(List<SpillLanguage> spillLanguageList, EntityQueryDetailTypeEnum? entityQueryDetailType)
        {
            // SpillLanguage fields
            Assert.IsNotNull(spillLanguageList[0].SpillLanguageID);
            Assert.IsNotNull(spillLanguageList[0].SpillID);
            Assert.IsNotNull(spillLanguageList[0].Language);
            Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillComment));
            Assert.IsNotNull(spillLanguageList[0].TranslationStatus);
            Assert.IsNotNull(spillLanguageList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(spillLanguageList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // SpillLanguageWeb and SpillLanguageReport fields should be null here
                Assert.IsNull(spillLanguageList[0].SpillLanguageWeb);
                Assert.IsNull(spillLanguageList[0].SpillLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // SpillLanguageWeb fields should not be null and SpillLanguageReport fields should be null here
                Assert.IsNotNull(spillLanguageList[0].SpillLanguageWeb.LastUpdateContactTVItemLanguage);
                if (!string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageWeb.TranslationStatusText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageWeb.TranslationStatusText));
                }
                Assert.IsNull(spillLanguageList[0].SpillLanguageReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // SpillLanguageWeb and SpillLanguageReport fields should NOT be null here
                Assert.IsNotNull(spillLanguageList[0].SpillLanguageWeb.LastUpdateContactTVItemLanguage);
                if (spillLanguageList[0].SpillLanguageWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageWeb.LanguageText));
                }
                if (spillLanguageList[0].SpillLanguageWeb.TranslationStatusText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageWeb.TranslationStatusText));
                }
                if (spillLanguageList[0].SpillLanguageReport.SpillLanguageReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillLanguageReport.SpillLanguageReportTest));
                }
            }
        }
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = LanguageRequest;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;

            return spillLanguage;
        }
        #endregion Functions private
    }
}
