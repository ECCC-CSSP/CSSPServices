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
    public partial class ReportSectionLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportSectionLanguageService reportSectionLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionLanguageServiceTest() : base()
        {
            //reportSectionLanguageService = new ReportSectionLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ReportSectionLanguage GetFilledRandomReportSectionLanguage(string OmitPropName)
        {
            ReportSectionLanguage reportSectionLanguage = new ReportSectionLanguage();

            if (OmitPropName != "ReportSectionID") reportSectionLanguage.ReportSectionID = 1;
            if (OmitPropName != "Language") reportSectionLanguage.Language = LanguageRequest;
            if (OmitPropName != "ReportSectionName") reportSectionLanguage.ReportSectionName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusReportSectionName") reportSectionLanguage.TranslationStatusReportSectionName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "ReportSectionText") reportSectionLanguage.ReportSectionText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusReportSectionText") reportSectionLanguage.TranslationStatusReportSectionText = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") reportSectionLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportSectionLanguage.LastUpdateContactTVItemID = 2;

            return reportSectionLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportSectionLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportSectionLanguage reportSectionLanguage = GetFilledRandomReportSectionLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportSectionLanguageService.GetRead().Count();

                    Assert.AreEqual(reportSectionLanguageService.GetRead().Count(), reportSectionLanguageService.GetEdit().Count());

                    reportSectionLanguageService.Add(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportSectionLanguageService.GetRead().Where(c => c == reportSectionLanguage).Any());
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportSectionLanguageService.GetRead().Count());
                    reportSectionLanguageService.Delete(reportSectionLanguage);
                    if (reportSectionLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportSectionLanguage.ReportSectionLanguageID   (Int32)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageID = 0;
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageReportSectionLanguageID), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageID = 10000000;
                    reportSectionLanguageService.Update(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSectionLanguage, CSSPModelsRes.ReportSectionLanguageReportSectionLanguageID, reportSectionLanguage.ReportSectionLanguageID.ToString()), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = Error)]
                    // reportSectionLanguage.ReportSectionID   (Int32)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionID = 0;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportSection, CSSPModelsRes.ReportSectionLanguageReportSectionID, reportSectionLanguage.ReportSectionID.ToString()), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportSectionLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.Language = (LanguageEnum)1000000;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageLanguage), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportSectionLanguage.ReportSectionName   (String)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("ReportSectionName");
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(1, reportSectionLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportSectionLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageReportSectionName)).Any());
                    Assert.AreEqual(null, reportSectionLanguage.ReportSectionName);
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionName = GetRandomString("", 101);
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportSectionLanguageReportSectionName, "100"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportSectionLanguage.TranslationStatusReportSectionName   (TranslationStatusEnum)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.TranslationStatusReportSectionName = (TranslationStatusEnum)1000000;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageTranslationStatusReportSectionName), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(10000))]
                    // reportSectionLanguage.ReportSectionText   (String)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("ReportSectionText");
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(1, reportSectionLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportSectionLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageReportSectionText)).Any());
                    Assert.AreEqual(null, reportSectionLanguage.ReportSectionText);
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionText = GetRandomString("", 10001);
                    Assert.AreEqual(false, reportSectionLanguageService.Add(reportSectionLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportSectionLanguageReportSectionText, "10000"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportSectionLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportSectionLanguage.TranslationStatusReportSectionText   (TranslationStatusEnum)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.TranslationStatusReportSectionText = (TranslationStatusEnum)1000000;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageTranslationStatusReportSectionText), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportSectionLanguage.ReportSectionLanguageWeb   (ReportSectionLanguageWeb)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageWeb = null;
                    Assert.IsNull(reportSectionLanguage.ReportSectionLanguageWeb);

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageWeb = new ReportSectionLanguageWeb();
                    Assert.IsNotNull(reportSectionLanguage.ReportSectionLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportSectionLanguage.ReportSectionLanguageReport   (ReportSectionLanguageReport)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageReport = null;
                    Assert.IsNull(reportSectionLanguage.ReportSectionLanguageReport);

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.ReportSectionLanguageReport = new ReportSectionLanguageReport();
                    Assert.IsNotNull(reportSectionLanguage.ReportSectionLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportSectionLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateDate_UTC = new DateTime();
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportSectionLanguageLastUpdateDate_UTC), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportSectionLanguageLastUpdateDate_UTC, "1980"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportSectionLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateContactTVItemID = 0;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportSectionLanguageLastUpdateContactTVItemID, reportSectionLanguage.LastUpdateContactTVItemID.ToString()), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportSectionLanguage = null;
                    reportSectionLanguage = GetFilledRandomReportSectionLanguage("");
                    reportSectionLanguage.LastUpdateContactTVItemID = 1;
                    reportSectionLanguageService.Add(reportSectionLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportSectionLanguageLastUpdateContactTVItemID, "Contact"), reportSectionLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSectionLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportSectionLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ReportSectionLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportSectionLanguageService reportSectionLanguageService = new ReportSectionLanguageService(LanguageRequest, dbTestDB, ContactID);
                    ReportSectionLanguage reportSectionLanguage = (from c in reportSectionLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportSectionLanguage);

                    ReportSectionLanguage reportSectionLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            reportSectionLanguageRet = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            reportSectionLanguageRet = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            reportSectionLanguageRet = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            reportSectionLanguageRet = reportSectionLanguageService.GetReportSectionLanguageWithReportSectionLanguageID(reportSectionLanguage.ReportSectionLanguageID, EntityQueryDetailTypeEnum.EntityReport);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ReportSectionLanguage fields
                        Assert.IsNotNull(reportSectionLanguageRet.ReportSectionLanguageID);
                        Assert.IsNotNull(reportSectionLanguageRet.ReportSectionID);
                        Assert.IsNotNull(reportSectionLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionName));
                        Assert.IsNotNull(reportSectionLanguageRet.TranslationStatusReportSectionName);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionText));
                        Assert.IsNotNull(reportSectionLanguageRet.TranslationStatusReportSectionText);
                        Assert.IsNotNull(reportSectionLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(reportSectionLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ReportSectionLanguageWeb and ReportSectionLanguageReport fields should be null here
                            Assert.IsNull(reportSectionLanguageRet.ReportSectionLanguageWeb);
                            Assert.IsNull(reportSectionLanguageRet.ReportSectionLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ReportSectionLanguageWeb fields should not be null and ReportSectionLanguageReport fields should be null here
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.LastUpdateContactTVText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.LanguageText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameTextText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameTextText));
                            }
                            Assert.IsNull(reportSectionLanguageRet.ReportSectionLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ReportSectionLanguageWeb and ReportSectionLanguageReport fields should NOT be null here
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.LastUpdateContactTVText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.LanguageText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameTextText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageWeb.TranslationStatusReportSectionNameTextText));
                            }
                            if (reportSectionLanguageRet.ReportSectionLanguageReport.ReportSectionLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportSectionLanguageRet.ReportSectionLanguageReport.ReportSectionLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ReportSectionLanguage
        #endregion Tests Get List of ReportSectionLanguage

    }
}
