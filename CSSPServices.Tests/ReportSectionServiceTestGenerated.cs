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
    public partial class ReportSectionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportSectionService reportSectionService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionServiceTest() : base()
        {
            //reportSectionService = new ReportSectionService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ReportSection GetFilledRandomReportSection(string OmitPropName)
        {
            ReportSection reportSection = new ReportSection();

            if (OmitPropName != "ReportTypeID") reportSection.ReportTypeID = 1;
            // Need to implement (no items found, would need to add at least one in the TestDB) [ReportSection TVItemID TVItem TVItemID]
            if (OmitPropName != "Ordinal") reportSection.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "IsStatic") reportSection.IsStatic = true;
            if (OmitPropName != "ParentReportSectionID") reportSection.ParentReportSectionID = 1;
            if (OmitPropName != "Year") reportSection.Year = GetRandomInt(1979, 2050);
            if (OmitPropName != "Locked") reportSection.Locked = true;
            if (OmitPropName != "TemplateReportSectionID") reportSection.TemplateReportSectionID = 1;
            if (OmitPropName != "LastUpdateDate_UTC") reportSection.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportSection.LastUpdateContactTVItemID = 2;

            return reportSection;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportSection_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionService reportSectionService = new ReportSectionService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportSection reportSection = GetFilledRandomReportSection("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportSectionService.GetRead().Count();

                    Assert.AreEqual(reportSectionService.GetRead().Count(), reportSectionService.GetEdit().Count());

                    reportSectionService.Add(reportSection);
                    if (reportSection.HasErrors)
                    {
                        Assert.AreEqual("", reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportSectionService.GetRead().Where(c => c == reportSection).Any());
                    reportSectionService.Update(reportSection);
                    if (reportSection.HasErrors)
                    {
                        Assert.AreEqual("", reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportSectionService.GetRead().Count());
                    reportSectionService.Delete(reportSection);
                    if (reportSection.HasErrors)
                    {
                        Assert.AreEqual("", reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportSection.ReportSectionID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionID = 0;
                    reportSectionService.Update(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionReportSectionID), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionID = 10000000;
                    reportSectionService.Update(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionReportSectionID, reportSection.ReportSectionID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = Error)]
                    // reportSection.ReportTypeID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportTypeID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.ReportSectionReportTypeID, reportSection.ReportTypeID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Error)]
                    // reportSection.TVItemID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.TVItemID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportSectionTVItemID, reportSection.TVItemID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.TVItemID = 1;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportSectionTVItemID, "Error"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 1000)]
                    // reportSection.Ordinal   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Ordinal = -1;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ReportSectionOrdinal, "0", "1000"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());
                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Ordinal = 1001;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ReportSectionOrdinal, "0", "1000"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // reportSection.IsStatic   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = Error)]
                    // reportSection.ParentReportSectionID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ParentReportSectionID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionParentReportSectionID, reportSection.ParentReportSectionID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [Range(1979, 2050)]
                    // reportSection.Year   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Year = 1978;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ReportSectionYear, "1979", "2050"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());
                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.Year = 2051;
                    Assert.AreEqual(false, reportSectionService.Add(reportSection));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.ReportSectionYear, "1979", "2050"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // reportSection.Locked   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = Error)]
                    // reportSection.TemplateReportSectionID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.TemplateReportSectionID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionTemplateReportSectionID, reportSection.TemplateReportSectionID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportSection.ReportSectionWeb   (ReportSectionWeb)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionWeb = null;
                    Assert.IsNull(reportSection.ReportSectionWeb);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionWeb = new ReportSectionWeb();
                    Assert.IsNotNull(reportSection.ReportSectionWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportSection.ReportSectionReport   (ReportSectionReport)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionReport = null;
                    Assert.IsNull(reportSection.ReportSectionReport);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.ReportSectionReport = new ReportSectionReport();
                    Assert.IsNotNull(reportSection.ReportSectionReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportSection.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateDate_UTC = new DateTime();
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLastUpdateDate_UTC), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportSectionLastUpdateDate_UTC, "1980"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportSection.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateContactTVItemID = 0;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportSectionLastUpdateContactTVItemID, reportSection.LastUpdateContactTVItemID.ToString()), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSection = null;
                    reportSection = GetFilledRandomReportSection("");
                    reportSection.LastUpdateContactTVItemID = 1;
                    reportSectionService.Add(reportSection);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportSectionLastUpdateContactTVItemID, "Contact"), reportSection.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSection.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSection.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ReportSection_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionService reportSectionService = new ReportSectionService(LanguageRequest, dbTestDB, ContactID);
                    ReportSection reportSection = (from c in reportSectionService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportSection);

                    ReportSection reportSectionRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            reportSectionRet = reportSectionService.GetReportSectionWithReportSectionID(reportSection.ReportSectionID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            reportSectionRet = reportSectionService.GetReportSectionWithReportSectionID(reportSection.ReportSectionID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            reportSectionRet = reportSectionService.GetReportSectionWithReportSectionID(reportSection.ReportSectionID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            reportSectionRet = reportSectionService.GetReportSectionWithReportSectionID(reportSection.ReportSectionID, EntityQueryDetailTypeEnum.EntityReport);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ReportSection fields
                        Assert.IsNotNull(reportSectionRet.ReportSectionID);
                        Assert.IsNotNull(reportSectionRet.ReportTypeID);
                        if (reportSectionRet.TVItemID != null)
                        {
                            Assert.IsNotNull(reportSectionRet.TVItemID);
                        }
                        Assert.IsNotNull(reportSectionRet.Ordinal);
                        Assert.IsNotNull(reportSectionRet.IsStatic);
                        if (reportSectionRet.ParentReportSectionID != null)
                        {
                            Assert.IsNotNull(reportSectionRet.ParentReportSectionID);
                        }
                        if (reportSectionRet.Year != null)
                        {
                            Assert.IsNotNull(reportSectionRet.Year);
                        }
                        Assert.IsNotNull(reportSectionRet.Locked);
                        if (reportSectionRet.TemplateReportSectionID != null)
                        {
                            Assert.IsNotNull(reportSectionRet.TemplateReportSectionID);
                        }
                        Assert.IsNotNull(reportSectionRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(reportSectionRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ReportSectionWeb and ReportSectionReport fields should be null here
                            Assert.IsNull(reportSectionRet.ReportSectionWeb);
                            Assert.IsNull(reportSectionRet.ReportSectionReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ReportSectionWeb fields should not be null and ReportSectionReport fields should be null here
                            if (reportSectionRet.ReportSectionWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionWeb.LastUpdateContactTVText));
                            }
                            if (reportSectionRet.ReportSectionWeb.ReportSectionName != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionWeb.ReportSectionName));
                            }
                            if (reportSectionRet.ReportSectionWeb.ReportSectionText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionWeb.ReportSectionText));
                            }
                            Assert.IsNull(reportSectionRet.ReportSectionReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ReportSectionWeb and ReportSectionReport fields should NOT be null here
                            if (reportSectionRet.ReportSectionWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionWeb.LastUpdateContactTVText));
                            }
                            if (reportSectionRet.ReportSectionWeb.ReportSectionName != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionWeb.ReportSectionName));
                            }
                            if (reportSectionRet.ReportSectionWeb.ReportSectionText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionWeb.ReportSectionText));
                            }
                            if (reportSectionRet.ReportSectionReport.ReportSectionReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionRet.ReportSectionReport.ReportSectionReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ReportSection
        #endregion Tests Get List of ReportSection

    }
}
