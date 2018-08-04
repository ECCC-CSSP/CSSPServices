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

                    count = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().Count();

                    Assert.AreEqual(samplingPlanSubsectorService.GetSamplingPlanSubsectorList().Count(), (from c in dbTestDB.SamplingPlanSubsectors select c).Take(200).Count());

                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, samplingPlanSubsectorService.GetSamplingPlanSubsectorList().Where(c => c == samplingPlanSubsector).Any());
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, samplingPlanSubsectorService.GetSamplingPlanSubsectorList().Count());
                    samplingPlanSubsectorService.Delete(samplingPlanSubsector);
                    if (samplingPlanSubsector.HasErrors)
                    {
                        Assert.AreEqual("", samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, samplingPlanSubsectorService.GetSamplingPlanSubsectorList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSamplingPlanSubsectorID"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanSubsectorID = 10000000;
                    samplingPlanSubsectorService.Update(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorSamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = )]
                    // samplingPlanSubsector.SamplingPlanID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SamplingPlanID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanSubsectorSamplingPlanID", samplingPlanSubsector.SamplingPlanID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // samplingPlanSubsector.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SubsectorTVItemID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorSubsectorTVItemID", samplingPlanSubsector.SubsectorTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.SubsectorTVItemID = 1;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorSubsectorTVItemID", "Subsector"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // samplingPlanSubsector.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateDate_UTC = new DateTime();
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorLastUpdateDate_UTC"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanSubsectorLastUpdateDate_UTC", "1980"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // samplingPlanSubsector.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateContactTVItemID = 0;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorLastUpdateContactTVItemID", samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                    samplingPlanSubsector = null;
                    samplingPlanSubsector = GetFilledRandomSamplingPlanSubsector("");
                    samplingPlanSubsector.LastUpdateContactTVItemID = 1;
                    samplingPlanSubsectorService.Add(samplingPlanSubsector);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorLastUpdateContactTVItemID", "Contact"), samplingPlanSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    SamplingPlanSubsector samplingPlanSubsector = (from c in dbTestDB.SamplingPlanSubsectors select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsector);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            SamplingPlanSubsector samplingPlanSubsectorRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                            CheckSamplingPlanSubsectorFields(new List<SamplingPlanSubsector>() { samplingPlanSubsectorRet });
                            Assert.AreEqual(samplingPlanSubsector.SamplingPlanSubsectorID, samplingPlanSubsectorRet.SamplingPlanSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            SamplingPlanSubsectorWeb samplingPlanSubsectorWebRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                            CheckSamplingPlanSubsectorWebFields(new List<SamplingPlanSubsectorWeb>() { samplingPlanSubsectorWebRet });
                            Assert.AreEqual(samplingPlanSubsector.SamplingPlanSubsectorID, samplingPlanSubsectorWebRet.SamplingPlanSubsectorID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            SamplingPlanSubsectorReport samplingPlanSubsectorReportRet = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportWithSamplingPlanSubsectorID(samplingPlanSubsector.SamplingPlanSubsectorID);
                            CheckSamplingPlanSubsectorReportFields(new List<SamplingPlanSubsectorReport>() { samplingPlanSubsectorReportRet });
                            Assert.AreEqual(samplingPlanSubsector.SamplingPlanSubsectorID, samplingPlanSubsectorReportRet.SamplingPlanSubsectorID);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    SamplingPlanSubsector samplingPlanSubsector = (from c in dbTestDB.SamplingPlanSubsectors select c).FirstOrDefault();
                    Assert.IsNotNull(samplingPlanSubsector);

                    List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                    samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Take(200).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        samplingPlanSubsectorService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                        samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 1, 1,  "SamplingPlanSubsectorID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                        samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 1, 1, "SamplingPlanSubsectorID,SamplingPlanID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                        samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Skip(1).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ThenBy(c => c.SamplingPlanID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorID", "SamplingPlanSubsectorID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                        samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID == 4).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 0, 1, "SamplingPlanSubsectorID", "SamplingPlanSubsectorID,GT,2|SamplingPlanSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                        samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID > 2 && c.SamplingPlanSubsectorID < 5).Skip(0).Take(1).OrderBy(c => c.SamplingPlanSubsectorID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
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
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        SamplingPlanSubsectorService samplingPlanSubsectorService = new SamplingPlanSubsectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        samplingPlanSubsectorService.Query = samplingPlanSubsectorService.FillQuery(typeof(SamplingPlanSubsector), culture.TwoLetterISOLanguageName, 0, 10000, "", "SamplingPlanSubsectorID,GT,2|SamplingPlanSubsectorID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<SamplingPlanSubsector> samplingPlanSubsectorDirectQueryList = new List<SamplingPlanSubsector>();
                        samplingPlanSubsectorDirectQueryList = (from c in dbTestDB.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID > 2 && c.SamplingPlanSubsectorID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<SamplingPlanSubsector> samplingPlanSubsectorList = new List<SamplingPlanSubsector>();
                            samplingPlanSubsectorList = samplingPlanSubsectorService.GetSamplingPlanSubsectorList().ToList();
                            CheckSamplingPlanSubsectorFields(samplingPlanSubsectorList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList = new List<SamplingPlanSubsectorWeb>();
                            samplingPlanSubsectorWebList = samplingPlanSubsectorService.GetSamplingPlanSubsectorWebList().ToList();
                            CheckSamplingPlanSubsectorWebFields(samplingPlanSubsectorWebList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList = new List<SamplingPlanSubsectorReport>();
                            samplingPlanSubsectorReportList = samplingPlanSubsectorService.GetSamplingPlanSubsectorReportList().ToList();
                            CheckSamplingPlanSubsectorReportFields(samplingPlanSubsectorReportList);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList[0].SamplingPlanSubsectorID, samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
                            Assert.AreEqual(samplingPlanSubsectorDirectQueryList.Count, samplingPlanSubsectorReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetSamplingPlanSubsectorList() 2Where

        #region Functions private
        private void CheckSamplingPlanSubsectorFields(List<SamplingPlanSubsector> samplingPlanSubsectorList)
        {
            Assert.IsNotNull(samplingPlanSubsectorList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].SubsectorTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorList[0].HasErrors);
        }
        private void CheckSamplingPlanSubsectorWebFields(List<SamplingPlanSubsectorWeb> samplingPlanSubsectorWebList)
        {
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].SubsectorTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorWebList[0].HasErrors);
        }
        private void CheckSamplingPlanSubsectorReportFields(List<SamplingPlanSubsectorReport> samplingPlanSubsectorReportList)
        {
            if (!string.IsNullOrWhiteSpace(samplingPlanSubsectorReportList[0].SamplingPlanSubsectorReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(samplingPlanSubsectorReportList[0].SamplingPlanSubsectorReportTest));
            }
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].LastUpdateContactTVItemLanguage);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].SamplingPlanSubsectorID);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].SamplingPlanID);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].SubsectorTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(samplingPlanSubsectorReportList[0].HasErrors);
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
