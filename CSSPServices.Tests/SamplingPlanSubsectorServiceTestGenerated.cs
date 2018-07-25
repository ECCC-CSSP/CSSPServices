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
    public partial class SamplingPlanSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SamplingPlanSubsectorService samplingPlanSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorServiceTest() : base()
        {
            //samplingPlanSubsectorService = new SamplingPlanSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void SamplingPlanSubsector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    SamplingPlanSubsector samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = samplingPlanSubsectorService.GetRead().Count();

                    Assert.AreEqual(samplingPlanSubsectorService.GetRead().Count(), samplingPlanSubsectorService.GetEdit().Count());

                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanSubsectorService.GetRead().Where(c => c == samplingPlanSubsector).Any());
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanSubsectorService.GetRead().Count());
                    samplingPlanSubsectorService.Delete(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, samplingPlanSubsectorService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // samplingPlanSubsector.SamplingPlanSubsectorID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorID = 0;
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorID = 10000000;
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsector, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID, samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = Error)]
                    // samplingPlanSubsector.SamplingPlanID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanID, samplingPlanSubsector.SamplingPlanID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // samplingPlanSubsector.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SubsectorTVItemID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID, samplingPlanSubsector.SubsectorTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SubsectorTVItemID = 1;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "Subsector"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.SamplingPlanSubsectorWeb   (SamplingPlanSubsectorWeb)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorWeb = null;
                    Assert.IsNull(samplingPlanSubsector.SamplingPlanSubsectorWeb);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorWeb = new SamplingPlanSubsectorWeb();
                    Assert.IsNotNull(samplingPlanSubsector.SamplingPlanSubsectorWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.SamplingPlanSubsectorReport   (SamplingPlanSubsectorReport)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorReport = null;
                    Assert.IsNull(samplingPlanSubsector.SamplingPlanSubsectorReport);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorReport = new SamplingPlanSubsectorReport();
                    Assert.IsNotNull(samplingPlanSubsector.SamplingPlanSubsectorReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanSubsector.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateDate_UTC = new DateTime();
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC, "1980"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanSubsector.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateContactTVItemID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateContactTVItemID = 1;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "Contact"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // samplingPlanSubsector.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID)
        [TestMethod]
        public void GetSamplingPlanSubsectorWithSamplingPlanSubsectorID__samplingPlanSubsector_SamplingPlanSubsectorID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanSubsector samplingPlanSubsector = (from c in samplingPlanSubsectorService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsector);

                    SamplingPlanSubsector samplingPlanSubsectorRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                            Assert.IsNull(samplingPlanSubsectorRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(new List<SamplingPlanSubsector>() { samplingPlanSubsectorRet }, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID)

        #region Tests Generated for GetSamplingPlanSubsectorList()
        [TestMethod]
        public void GetSamplingPlanSubsectorList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    SamplingPlanSubsector samplingPlanSubsector = (from c in samplingPlanSubsectorService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsector);

                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList()

        #region Tests Generated for GetSamplingPlanSubsectorList() Skip Take
        [TestMethod]
        public void GetSamplingPlanSubsectorList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorDirectQueryList = samplingPlanSubsectorService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                        Assert.AreEqual(1, samplingPlanSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() Skip Take

        #region Tests Generated for GetSamplingPlanSubsectorList() Skip Take Order
        [TestMethod]
        public void GetSamplingPlanSubsectorList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanSubsectorID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorDirectQueryList = samplingPlanSubsectorService.GetRead().Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                        Assert.AreEqual(1, samplingPlanSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() Skip Take Order

        #region Tests Generated for GetSamplingPlanSubsectorList() Skip Take 2Order
        [TestMethod]
        public void GetSamplingPlanSubsectorList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanSubsectorID,SamplingPlanID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorDirectQueryList = samplingPlanSubsectorService.GetRead().Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ThenBy(c => c.SamplingPlanID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                        Assert.AreEqual(1, samplingPlanSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() Skip Take 2Order

        #region Tests Generated for GetSamplingPlanSubsectorList() Skip Take Order Where
        [TestMethod]
        public void GetSamplingPlanSubsectorList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorID", "SamplingPlanSubsectorID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorDirectQueryList = samplingPlanSubsectorService.GetRead().Where(c => c.SamplingPlanSubsectorID == 4).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                        Assert.AreEqual(1, samplingPlanSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() Skip Take Order Where

        #region Tests Generated for GetSamplingPlanSubsectorList() Skip Take Order 2Where
        [TestMethod]
        public void GetSamplingPlanSubsectorList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorID", "SamplingPlanSubsectorID,GT,2|SamplingPlanSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorDirectQueryList = samplingPlanSubsectorService.GetRead().Where(c => c.SamplingPlanSubsectorID > 2 && c.SamplingPlanSubsectorID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                        Assert.AreEqual(1, samplingPlanSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() Skip Take Order 2Where

        #region Tests Generated for GetSamplingPlanSubsectorList() 2Where
        [TestMethod]
        public void GetSamplingPlanSubsectorList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 0, 10000, "", "SamplingPlanSubsectorID,GT,2|SamplingPlanSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        samplingPlanSubsectorDirectQueryList = samplingPlanSubsectorService.GetRead().Where(c => c.SamplingPlanSubsectorID > 2 && c.SamplingPlanSubsectorID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            Assert.AreEqual(0, samplingPlanSubsectorList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList, entityQueryDetailType);
                        Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                        Assert.AreEqual(2, samplingPlanSubsectorList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() 2Where

        #region Functions private
        private void CheckSamplingPlanSubsectorFields(List<SamplingPlanSubsector> samplingPlanSubsectorList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // SamplingPlanSubsector fields
            Assert.IsNotNull(samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].SubsectorTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorList[0].LastUpdateContactTVItemID);

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // SamplingPlanSubsectorWeb and SamplingPlanSubsectorReport fields should be null here
                Assert.IsNull(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb);
                Assert.IsNull(samplingPlanSubsectorList[0].SamplingPlanSubsectorReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // SamplingPlanSubsectorWeb fields should not be null and SamplingPlanSubsectorReport fields should be null here
                if (!string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.SubsectorTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.SubsectorTVText));
                }
                if (!string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.LastUpdateContactTVText));
                }
                Assert.IsNull(samplingPlanSubsectorList[0].SamplingPlanSubsectorReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // SamplingPlanSubsectorWeb and SamplingPlanSubsectorReport fields should NOT be null here
                if (samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.SubsectorTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.SubsectorTVText));
                }
                if (samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorWeb.LastUpdateContactTVText));
                }
                if (samplingPlanSubsectorList[0].SamplingPlanSubsectorReport.SamplingPlanSubsectorReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorList[0].SamplingPlanSubsectorReport.SamplingPlanSubsectorReportTest));
                }
            }
        }
        private SamplingPlanSubsector GetFilledRandomSamplingPlanSubsector(string OmitPropName)
        {
            SamplingPlanSubsector samplingPlanSubsector = new SamplingPlanSubsector();

            if (OmitPropName != "SamplingPlanID") samplingPlanSubsector.SamplingPlanID = 1;
            if (OmitPropName != "SubsectorTVItemID") samplingPlanSubsector.SubsectorTVItemID = 11;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsector.LastUpdateContactTVItemID = 2;

            return samplingPlanSubsector;
        }
        #endregion Functions private
    }
}
