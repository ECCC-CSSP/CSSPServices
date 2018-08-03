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
    public partial class LabSheetServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private LabSheetService labSheetService { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetServiceTest() : base()
        {
            //labSheetService = new LabSheetService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void LabSheet_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    LabSheet labSheet = GetFilledRandomLabSheet("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = labSheetService.GetRead().Count();

                    Assert.AreEqual(labSheetService.GetRead().Count(), labSheetService.GetEdit().Count());

                    labSheetService.Add(labSheet);
                    if (labSheet.HasErrors)
                    {
                        Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, labSheetService.GetRead().Where(c => c == labSheet).Any());
                    labSheetService.Update(labSheet);
                    if (labSheet.HasErrors)
                    {
                        Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, labSheetService.GetRead().Count());
                    labSheetService.Delete(labSheet);
                    if (labSheet.HasErrors)
                    {
                        Assert.AreEqual("", labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // labSheet.LabSheetID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetID = 0;
                    labSheetService.Update(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetLabSheetID"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetID = 10000000;
                    labSheetService.Update(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetLabSheetID", labSheet.LabSheetID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, -1)]
                    // labSheet.OtherServerLabSheetID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.OtherServerLabSheetID = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "LabSheetOtherServerLabSheetID", "1"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID", AllowableTVtypeList = )]
                    // labSheet.SamplingPlanID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SamplingPlanID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "LabSheetSamplingPlanID", labSheet.SamplingPlanID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250, MinimumLength = 1)]
                    // labSheet.SamplingPlanName   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("SamplingPlanName");
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(1, labSheet.ValidationResults.Count());
                    Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "LabSheetSamplingPlanName")).Any());
                    Assert.AreEqual(null, labSheet.SamplingPlanName);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SamplingPlanName = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetSamplingPlanName", "1", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1980, -1)]
                    // labSheet.Year   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Year = 1979;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MinValueIs_, "LabSheetYear", "1980"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 12)]
                    // labSheet.Month   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Month = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetMonth", "1", "12"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Month = 13;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetMonth", "1", "12"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 31)]
                    // labSheet.Day   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Day = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDay", "1", "31"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.Day = 32;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDay", "1", "31"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(1, 100)]
                    // labSheet.RunNumber   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.RunNumber = 0;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetRunNumber", "1", "100"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.RunNumber = 101;
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetRunNumber", "1", "100"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                    // labSheet.SubsectorTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SubsectorTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetSubsectorTVItemID", labSheet.SubsectorTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SubsectorTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetSubsectorTVItemID", "Subsector"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMRun)]
                    // labSheet.MWQMRunTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.MWQMRunTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetMWQMRunTVItemID", labSheet.MWQMRunTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.MWQMRunTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetMWQMRunTVItemID", "MWQMRun"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.SamplingPlanType   (SamplingPlanTypeEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SamplingPlanType = (SamplingPlanTypeEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetSamplingPlanType"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.SampleType   (SampleTypeEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.SampleType = (SampleTypeEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetSampleType"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.LabSheetType   (LabSheetTypeEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetType = (LabSheetTypeEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetLabSheetType"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // labSheet.LabSheetStatus   (LabSheetStatusEnum)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LabSheetStatus = (LabSheetStatusEnum)1000000;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetLabSheetStatus"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250, MinimumLength = 1)]
                    // labSheet.FileName   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("FileName");
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(1, labSheet.ValidationResults.Count());
                    Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "LabSheetFileName")).Any());
                    Assert.AreEqual(null, labSheet.FileName);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.FileName = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetFileName", "1", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheet.FileLastModifiedDate_Local   (DateTime)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.FileLastModifiedDate_Local = new DateTime();
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetFileLastModifiedDate_Local"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.FileLastModifiedDate_Local = new DateTime(1979, 1, 1);
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetFileLastModifiedDate_Local", "1980"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // labSheet.FileContent   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("FileContent");
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(1, labSheet.ValidationResults.Count());
                    Assert.IsTrue(labSheet.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "LabSheetFileContent")).Any());
                    Assert.AreEqual(null, labSheet.FileContent);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheet.AcceptedOrRejectedByContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.AcceptedOrRejectedByContactTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetAcceptedOrRejectedByContactTVItemID", labSheet.AcceptedOrRejectedByContactTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.AcceptedOrRejectedByContactTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetAcceptedOrRejectedByContactTVItemID", "Contact"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheet.AcceptedOrRejectedDateTime   (DateTime)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.AcceptedOrRejectedDateTime = new DateTime(1979, 1, 1);
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetAcceptedOrRejectedDateTime", "1980"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // labSheet.RejectReason   (String)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.RejectReason = GetRandomString("", 251);
                    Assert.AreEqual(false, labSheetService.Add(labSheet));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetRejectReason", "250"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, labSheetService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // labSheet.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LastUpdateDate_UTC = new DateTime();
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "LabSheetLastUpdateDate_UTC"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);
                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetLastUpdateDate_UTC", "1980"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // labSheet.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LastUpdateContactTVItemID = 0;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetLastUpdateContactTVItemID", labSheet.LastUpdateContactTVItemID.ToString()), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);

                    labSheet = null;
                    labSheet = GetFilledRandomLabSheet("");
                    labSheet.LastUpdateContactTVItemID = 1;
                    labSheetService.Add(labSheet);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetLastUpdateContactTVItemID", "Contact"), labSheet.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheet.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // labSheet.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetLabSheetWithLabSheetID(labSheet.LabSheetID)
        [TestMethod]
        public void GetLabSheetWithLabSheetID__labSheet_LabSheetID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    LabSheet labSheet = (from c in labSheetService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            LabSheet labSheetRet = labSheetService.GetLabSheetWithLabSheetID(labSheet.LabSheetID);
                            CheckLabSheetFields(new List<LabSheet>() { labSheetRet });
                            Assert.AreEqual(labSheet.LabSheetID, labSheetRet.LabSheetID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            LabSheetWeb labSheetWebRet = labSheetService.GetLabSheetWebWithLabSheetID(labSheet.LabSheetID);
                            CheckLabSheetWebFields(new List<LabSheetWeb>() { labSheetWebRet });
                            Assert.AreEqual(labSheet.LabSheetID, labSheetWebRet.LabSheetID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            LabSheetReport labSheetReportRet = labSheetService.GetLabSheetReportWithLabSheetID(labSheet.LabSheetID);
                            CheckLabSheetReportFields(new List<LabSheetReport>() { labSheetReportRet });
                            Assert.AreEqual(labSheet.LabSheetID, labSheetReportRet.LabSheetID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetWithLabSheetID(labSheet.LabSheetID)

        #region Tests Generated for GetLabSheetList()
        [TestMethod]
        public void GetLabSheetList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    LabSheet labSheet = (from c in labSheetService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(labSheet);

                    List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                    labSheetDirectQueryList = labSheetService.GetRead().Take(100).ToList();

                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        labSheetService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList()

        #region Tests Generated for GetLabSheetList() Skip Take
        [TestMethod]
        public void GetLabSheetList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                        labSheetDirectQueryList = labSheetService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetWebList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetReportList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList() Skip Take

        #region Tests Generated for GetLabSheetList() Skip Take Order
        [TestMethod]
        public void GetLabSheetList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), culture.TwoLetterISOLanguageName, 1, 1,  "LabSheetID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                        labSheetDirectQueryList = labSheetService.GetRead().Skip(1).Take(1).OrderBy(c => c.LabSheetID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetWebList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetReportList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList() Skip Take Order

        #region Tests Generated for GetLabSheetList() Skip Take 2Order
        [TestMethod]
        public void GetLabSheetList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), culture.TwoLetterISOLanguageName, 1, 1, "LabSheetID,OtherServerLabSheetID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                        labSheetDirectQueryList = labSheetService.GetRead().Skip(1).Take(1).OrderBy(c => c.LabSheetID).ThenBy(c => c.OtherServerLabSheetID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetWebList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetReportList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList() Skip Take 2Order

        #region Tests Generated for GetLabSheetList() Skip Take Order Where
        [TestMethod]
        public void GetLabSheetList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetID", "LabSheetID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                        labSheetDirectQueryList = labSheetService.GetRead().Where(c => c.LabSheetID == 4).Skip(0).Take(1).OrderBy(c => c.LabSheetID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetWebList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetReportList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList() Skip Take Order Where

        #region Tests Generated for GetLabSheetList() Skip Take Order 2Where
        [TestMethod]
        public void GetLabSheetList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), culture.TwoLetterISOLanguageName, 0, 1, "LabSheetID", "LabSheetID,GT,2|LabSheetID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                        labSheetDirectQueryList = labSheetService.GetRead().Where(c => c.LabSheetID > 2 && c.LabSheetID < 5).Skip(0).Take(1).OrderBy(c => c.LabSheetID).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetWebList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetReportList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList() Skip Take Order 2Where

        #region Tests Generated for GetLabSheetList() 2Where
        [TestMethod]
        public void GetLabSheetList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (EntityQueryDetailTypeEnum? entityQueryDetailType in new List<EntityQueryDetailTypeEnum?>() { null, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        LabSheetService labSheetService = new LabSheetService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        labSheetService.Query = labSheetService.FillQuery(typeof(LabSheet), culture.TwoLetterISOLanguageName, 0, 10000, "", "LabSheetID,GT,2|LabSheetID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        List<LabSheet> labSheetDirectQueryList = new List<LabSheet>();
                        labSheetDirectQueryList = labSheetService.GetRead().Where(c => c.LabSheetID > 2 && c.LabSheetID < 5).ToList();

                        if (entityQueryDetailType == null || entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            List<LabSheet> labSheetList = new List<LabSheet>();
                            labSheetList = labSheetService.GetLabSheetList().ToList();
                            CheckLabSheetFields(labSheetList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            List<LabSheetWeb> labSheetWebList = new List<LabSheetWeb>();
                            labSheetWebList = labSheetService.GetLabSheetWebList().ToList();
                            CheckLabSheetWebFields(labSheetWebList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetWebList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetWebList.Count);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            List<LabSheetReport> labSheetReportList = new List<LabSheetReport>();
                            labSheetReportList = labSheetService.GetLabSheetReportList().ToList();
                            CheckLabSheetReportFields(labSheetReportList);
                            Assert.AreEqual(labSheetDirectQueryList[0].LabSheetID, labSheetReportList[0].LabSheetID);
                            Assert.AreEqual(labSheetDirectQueryList.Count, labSheetReportList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetLabSheetList() 2Where

        #region Functions private
        private void CheckLabSheetFields(List<LabSheet> labSheetList)
        {
            Assert.IsNotNull(labSheetList[0].LabSheetID);
            Assert.IsNotNull(labSheetList[0].OtherServerLabSheetID);
            Assert.IsNotNull(labSheetList[0].SamplingPlanID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetList[0].SamplingPlanName));
            Assert.IsNotNull(labSheetList[0].Year);
            Assert.IsNotNull(labSheetList[0].Month);
            Assert.IsNotNull(labSheetList[0].Day);
            Assert.IsNotNull(labSheetList[0].RunNumber);
            Assert.IsNotNull(labSheetList[0].SubsectorTVItemID);
            if (labSheetList[0].MWQMRunTVItemID != null)
            {
                Assert.IsNotNull(labSheetList[0].MWQMRunTVItemID);
            }
            Assert.IsNotNull(labSheetList[0].SamplingPlanType);
            Assert.IsNotNull(labSheetList[0].SampleType);
            Assert.IsNotNull(labSheetList[0].LabSheetType);
            Assert.IsNotNull(labSheetList[0].LabSheetStatus);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetList[0].FileName));
            Assert.IsNotNull(labSheetList[0].FileLastModifiedDate_Local);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetList[0].FileContent));
            if (labSheetList[0].AcceptedOrRejectedByContactTVItemID != null)
            {
                Assert.IsNotNull(labSheetList[0].AcceptedOrRejectedByContactTVItemID);
            }
            if (labSheetList[0].AcceptedOrRejectedDateTime != null)
            {
                Assert.IsNotNull(labSheetList[0].AcceptedOrRejectedDateTime);
            }
            if (!string.IsNullOrWhiteSpace(labSheetList[0].RejectReason))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetList[0].RejectReason));
            }
            Assert.IsNotNull(labSheetList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(labSheetList[0].HasErrors);
        }
        private void CheckLabSheetWebFields(List<LabSheetWeb> labSheetWebList)
        {
            Assert.IsNotNull(labSheetWebList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(labSheetWebList[0].MWQMRunTVItemLanguage);
            Assert.IsNotNull(labSheetWebList[0].AcceptedOrRejectedByContactTVItemLanguage);
            Assert.IsNotNull(labSheetWebList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(labSheetWebList[0].SamplingPlanTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].SamplingPlanTypeText));
            }
            if (!string.IsNullOrWhiteSpace(labSheetWebList[0].SampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].SampleTypeText));
            }
            if (!string.IsNullOrWhiteSpace(labSheetWebList[0].LabSheetTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].LabSheetTypeText));
            }
            if (!string.IsNullOrWhiteSpace(labSheetWebList[0].LabSheetStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].LabSheetStatusText));
            }
            Assert.IsNotNull(labSheetWebList[0].LabSheetID);
            Assert.IsNotNull(labSheetWebList[0].OtherServerLabSheetID);
            Assert.IsNotNull(labSheetWebList[0].SamplingPlanID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].SamplingPlanName));
            Assert.IsNotNull(labSheetWebList[0].Year);
            Assert.IsNotNull(labSheetWebList[0].Month);
            Assert.IsNotNull(labSheetWebList[0].Day);
            Assert.IsNotNull(labSheetWebList[0].RunNumber);
            Assert.IsNotNull(labSheetWebList[0].SubsectorTVItemID);
            if (labSheetWebList[0].MWQMRunTVItemID != null)
            {
                Assert.IsNotNull(labSheetWebList[0].MWQMRunTVItemID);
            }
            Assert.IsNotNull(labSheetWebList[0].SamplingPlanType);
            Assert.IsNotNull(labSheetWebList[0].SampleType);
            Assert.IsNotNull(labSheetWebList[0].LabSheetType);
            Assert.IsNotNull(labSheetWebList[0].LabSheetStatus);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].FileName));
            Assert.IsNotNull(labSheetWebList[0].FileLastModifiedDate_Local);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].FileContent));
            if (labSheetWebList[0].AcceptedOrRejectedByContactTVItemID != null)
            {
                Assert.IsNotNull(labSheetWebList[0].AcceptedOrRejectedByContactTVItemID);
            }
            if (labSheetWebList[0].AcceptedOrRejectedDateTime != null)
            {
                Assert.IsNotNull(labSheetWebList[0].AcceptedOrRejectedDateTime);
            }
            if (!string.IsNullOrWhiteSpace(labSheetWebList[0].RejectReason))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetWebList[0].RejectReason));
            }
            Assert.IsNotNull(labSheetWebList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetWebList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(labSheetWebList[0].HasErrors);
        }
        private void CheckLabSheetReportFields(List<LabSheetReport> labSheetReportList)
        {
            if (!string.IsNullOrWhiteSpace(labSheetReportList[0].LabSheetReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].LabSheetReportTest));
            }
            Assert.IsNotNull(labSheetReportList[0].SubsectorTVItemLanguage);
            Assert.IsNotNull(labSheetReportList[0].MWQMRunTVItemLanguage);
            Assert.IsNotNull(labSheetReportList[0].AcceptedOrRejectedByContactTVItemLanguage);
            Assert.IsNotNull(labSheetReportList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(labSheetReportList[0].SamplingPlanTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].SamplingPlanTypeText));
            }
            if (!string.IsNullOrWhiteSpace(labSheetReportList[0].SampleTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].SampleTypeText));
            }
            if (!string.IsNullOrWhiteSpace(labSheetReportList[0].LabSheetTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].LabSheetTypeText));
            }
            if (!string.IsNullOrWhiteSpace(labSheetReportList[0].LabSheetStatusText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].LabSheetStatusText));
            }
            Assert.IsNotNull(labSheetReportList[0].LabSheetID);
            Assert.IsNotNull(labSheetReportList[0].OtherServerLabSheetID);
            Assert.IsNotNull(labSheetReportList[0].SamplingPlanID);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].SamplingPlanName));
            Assert.IsNotNull(labSheetReportList[0].Year);
            Assert.IsNotNull(labSheetReportList[0].Month);
            Assert.IsNotNull(labSheetReportList[0].Day);
            Assert.IsNotNull(labSheetReportList[0].RunNumber);
            Assert.IsNotNull(labSheetReportList[0].SubsectorTVItemID);
            if (labSheetReportList[0].MWQMRunTVItemID != null)
            {
                Assert.IsNotNull(labSheetReportList[0].MWQMRunTVItemID);
            }
            Assert.IsNotNull(labSheetReportList[0].SamplingPlanType);
            Assert.IsNotNull(labSheetReportList[0].SampleType);
            Assert.IsNotNull(labSheetReportList[0].LabSheetType);
            Assert.IsNotNull(labSheetReportList[0].LabSheetStatus);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].FileName));
            Assert.IsNotNull(labSheetReportList[0].FileLastModifiedDate_Local);
            Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].FileContent));
            if (labSheetReportList[0].AcceptedOrRejectedByContactTVItemID != null)
            {
                Assert.IsNotNull(labSheetReportList[0].AcceptedOrRejectedByContactTVItemID);
            }
            if (labSheetReportList[0].AcceptedOrRejectedDateTime != null)
            {
                Assert.IsNotNull(labSheetReportList[0].AcceptedOrRejectedDateTime);
            }
            if (!string.IsNullOrWhiteSpace(labSheetReportList[0].RejectReason))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(labSheetReportList[0].RejectReason));
            }
            Assert.IsNotNull(labSheetReportList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(labSheetReportList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(labSheetReportList[0].HasErrors);
        }
        private LabSheet GetFilledRandomLabSheet(string OmitPropName)
        {
            LabSheet labSheet = new LabSheet();

            if (OmitPropName != "OtherServerLabSheetID") labSheet.OtherServerLabSheetID = GetRandomInt(1, 11);
            if (OmitPropName != "SamplingPlanID") labSheet.SamplingPlanID = 1;
            if (OmitPropName != "SamplingPlanName") labSheet.SamplingPlanName = GetRandomString("", 6);
            if (OmitPropName != "Year") labSheet.Year = GetRandomInt(1980, 1990);
            if (OmitPropName != "Month") labSheet.Month = GetRandomInt(1, 12);
            if (OmitPropName != "Day") labSheet.Day = GetRandomInt(1, 31);
            if (OmitPropName != "RunNumber") labSheet.RunNumber = GetRandomInt(1, 100);
            if (OmitPropName != "SubsectorTVItemID") labSheet.SubsectorTVItemID = 11;
            if (OmitPropName != "MWQMRunTVItemID") labSheet.MWQMRunTVItemID = 46;
            if (OmitPropName != "SamplingPlanType") labSheet.SamplingPlanType = (SamplingPlanTypeEnum)GetRandomEnumType(typeof(SamplingPlanTypeEnum));
            if (OmitPropName != "SampleType") labSheet.SampleType = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "LabSheetType") labSheet.LabSheetType = (LabSheetTypeEnum)GetRandomEnumType(typeof(LabSheetTypeEnum));
            if (OmitPropName != "LabSheetStatus") labSheet.LabSheetStatus = (LabSheetStatusEnum)GetRandomEnumType(typeof(LabSheetStatusEnum));
            if (OmitPropName != "FileName") labSheet.FileName = GetRandomString("", 6);
            if (OmitPropName != "FileLastModifiedDate_Local") labSheet.FileLastModifiedDate_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "FileContent") labSheet.FileContent = GetRandomString("", 20);
            if (OmitPropName != "AcceptedOrRejectedByContactTVItemID") labSheet.AcceptedOrRejectedByContactTVItemID = 2;
            if (OmitPropName != "AcceptedOrRejectedDateTime") labSheet.AcceptedOrRejectedDateTime = new DateTime(2005, 3, 6);
            if (OmitPropName != "RejectReason") labSheet.RejectReason = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") labSheet.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") labSheet.LastUpdateContactTVItemID = 2;

            return labSheet;
        }
        #endregion Functions private
    }
}
