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
    public partial class ReportTypeLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportTypeLanguageService reportTypeLanguageService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeLanguageServiceTest() : base()
        {
            //reportTypeLanguageService = new ReportTypeLanguageService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ReportTypeLanguage GetFilledRandomReportTypeLanguage(string OmitPropName)
        {
            ReportTypeLanguage reportTypeLanguage = new ReportTypeLanguage();

            if (OmitPropName != "ReportTypeID") reportTypeLanguage.ReportTypeID = 1;
            if (OmitPropName != "Language") reportTypeLanguage.Language = LanguageRequest;
            if (OmitPropName != "Name") reportTypeLanguage.Name = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusName") reportTypeLanguage.TranslationStatusName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Description") reportTypeLanguage.Description = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusDescription") reportTypeLanguage.TranslationStatusDescription = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "StartOfFileName") reportTypeLanguage.StartOfFileName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusStartOfFileName") reportTypeLanguage.TranslationStatusStartOfFileName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") reportTypeLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportTypeLanguage.LastUpdateContactTVItemID = 2;

            return reportTypeLanguage;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportTypeLanguage_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportTypeLanguage reportTypeLanguage = GetFilledRandomReportTypeLanguage("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportTypeLanguageService.GetRead().Count();

                    Assert.AreEqual(reportTypeLanguageService.GetRead().Count(), reportTypeLanguageService.GetEdit().Count());

                    reportTypeLanguageService.Add(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportTypeLanguageService.GetRead().Where(c => c == reportTypeLanguage).Any());
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportTypeLanguageService.GetRead().Count());
                    reportTypeLanguageService.Delete(reportTypeLanguage);
                    if (reportTypeLanguage.HasErrors)
                    {
                        Assert.AreEqual("", reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportTypeLanguage.ReportTypeLanguageID   (Int32)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageID = 0;
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageReportTypeLanguageID), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageID = 10000000;
                    reportTypeLanguageService.Update(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportTypeLanguage, CSSPModelsRes.ReportTypeLanguageReportTypeLanguageID, reportTypeLanguage.ReportTypeLanguageID.ToString()), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = Error)]
                    // reportTypeLanguage.ReportTypeID   (Int32)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeID = 0;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.ReportTypeLanguageReportTypeID, reportTypeLanguage.ReportTypeID.ToString()), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.Language   (LanguageEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Language = (LanguageEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageLanguage), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportTypeLanguage.Name   (String)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("Name");
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(1, reportTypeLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportTypeLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageName)).Any());
                    Assert.AreEqual(null, reportTypeLanguage.Name);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Name = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeLanguageName, "100"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.TranslationStatusName   (TranslationStatusEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.TranslationStatusName = (TranslationStatusEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageTranslationStatusName), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(1000))]
                    // reportTypeLanguage.Description   (String)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("Description");
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(1, reportTypeLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportTypeLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageDescription)).Any());
                    Assert.AreEqual(null, reportTypeLanguage.Description);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.Description = GetRandomString("", 1001);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeLanguageDescription, "1000"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.TranslationStatusDescription   (TranslationStatusEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.TranslationStatusDescription = (TranslationStatusEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageTranslationStatusDescription), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportTypeLanguage.StartOfFileName   (String)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("StartOfFileName");
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(1, reportTypeLanguage.ValidationResults.Count());
                    Assert.IsTrue(reportTypeLanguage.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageStartOfFileName)).Any());
                    Assert.AreEqual(null, reportTypeLanguage.StartOfFileName);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.StartOfFileName = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeLanguageService.Add(reportTypeLanguage));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeLanguageStartOfFileName, "100"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeLanguageService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportTypeLanguage.TranslationStatusStartOfFileName   (TranslationStatusEnum)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.TranslationStatusStartOfFileName = (TranslationStatusEnum)1000000;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageTranslationStatusStartOfFileName), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportTypeLanguage.ReportTypeLanguageWeb   (ReportTypeLanguageWeb)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageWeb = null;
                    Assert.IsNull(reportTypeLanguage.ReportTypeLanguageWeb);

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageWeb = new ReportTypeLanguageWeb();
                    Assert.IsNotNull(reportTypeLanguage.ReportTypeLanguageWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportTypeLanguage.ReportTypeLanguageReport   (ReportTypeLanguageReport)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageReport = null;
                    Assert.IsNull(reportTypeLanguage.ReportTypeLanguageReport);

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.ReportTypeLanguageReport = new ReportTypeLanguageReport();
                    Assert.IsNotNull(reportTypeLanguage.ReportTypeLanguageReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportTypeLanguage.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateDate_UTC = new DateTime();
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLanguageLastUpdateDate_UTC), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportTypeLanguageLastUpdateDate_UTC, "1980"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportTypeLanguage.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateContactTVItemID = 0;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportTypeLanguageLastUpdateContactTVItemID, reportTypeLanguage.LastUpdateContactTVItemID.ToString()), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportTypeLanguage = null;
                    reportTypeLanguage = GetFilledRandomReportTypeLanguage("");
                    reportTypeLanguage.LastUpdateContactTVItemID = 1;
                    reportTypeLanguageService.Add(reportTypeLanguage);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportTypeLanguageLastUpdateContactTVItemID, "Contact"), reportTypeLanguage.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportTypeLanguage.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportTypeLanguage.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void ReportTypeLanguage_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    ReportTypeLanguageService reportTypeLanguageService = new ReportTypeLanguageService(new GetParam(), dbTestDB, ContactID);
                    ReportTypeLanguage reportTypeLanguage = (from c in reportTypeLanguageService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportTypeLanguage);

                    ReportTypeLanguage reportTypeLanguageRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            reportTypeLanguageRet = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID, getParam);
                            Assert.IsNull(reportTypeLanguageRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            reportTypeLanguageRet = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            reportTypeLanguageRet = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            reportTypeLanguageRet = reportTypeLanguageService.GetReportTypeLanguageWithReportTypeLanguageID(reportTypeLanguage.ReportTypeLanguageID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ReportTypeLanguage fields
                        Assert.IsNotNull(reportTypeLanguageRet.ReportTypeLanguageID);
                        Assert.IsNotNull(reportTypeLanguageRet.ReportTypeID);
                        Assert.IsNotNull(reportTypeLanguageRet.Language);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.Name));
                        Assert.IsNotNull(reportTypeLanguageRet.TranslationStatusName);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.Description));
                        Assert.IsNotNull(reportTypeLanguageRet.TranslationStatusDescription);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.StartOfFileName));
                        Assert.IsNotNull(reportTypeLanguageRet.TranslationStatusStartOfFileName);
                        Assert.IsNotNull(reportTypeLanguageRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(reportTypeLanguageRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ReportTypeLanguageWeb and ReportTypeLanguageReport fields should be null here
                            Assert.IsNull(reportTypeLanguageRet.ReportTypeLanguageWeb);
                            Assert.IsNull(reportTypeLanguageRet.ReportTypeLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ReportTypeLanguageWeb fields should not be null and ReportTypeLanguageReport fields should be null here
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.LastUpdateContactTVText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.LanguageText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusNameText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusNameText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusDescriptionText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusDescriptionText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusStartOfFileNameText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusStartOfFileNameText));
                            }
                            Assert.IsNull(reportTypeLanguageRet.ReportTypeLanguageReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ReportTypeLanguageWeb and ReportTypeLanguageReport fields should NOT be null here
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.LastUpdateContactTVText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.LanguageText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.LanguageText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusNameText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusNameText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusDescriptionText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusDescriptionText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusStartOfFileNameText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageWeb.TranslationStatusStartOfFileNameText));
                            }
                            if (reportTypeLanguageRet.ReportTypeLanguageReport.ReportTypeLanguageReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeLanguageRet.ReportTypeLanguageReport.ReportTypeLanguageReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of ReportTypeLanguage
        #endregion Tests Get List of ReportTypeLanguage

    }
}
