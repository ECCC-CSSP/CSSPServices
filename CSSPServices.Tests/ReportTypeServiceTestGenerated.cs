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
    public partial class ReportTypeServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private ReportTypeService reportTypeService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeServiceTest() : base()
        {
            //reportTypeService = new ReportTypeService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private ReportType GetFilledRandomReportType(string OmitPropName)
        {
            ReportType reportType = new ReportType();

            if (OmitPropName != "TVType") reportType.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "FileType") reportType.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "UniqueCode") reportType.UniqueCode = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") reportType.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportType.LastUpdateContactTVItemID = 2;

            return reportType;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportType_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new GetParam(), dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    ReportType reportType = GetFilledRandomReportType("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = reportTypeService.GetRead().Count();

                    Assert.AreEqual(reportTypeService.GetRead().Count(), reportTypeService.GetEdit().Count());

                    reportTypeService.Add(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportTypeService.GetRead().Where(c => c == reportType).Any());
                    reportTypeService.Update(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportTypeService.GetRead().Count());
                    reportTypeService.Delete(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportTypeService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // reportType.ReportTypeID   (Int32)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeID = 0;
                    reportTypeService.Update(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeReportTypeID), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeID = 10000000;
                    reportTypeService.Update(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.ReportTypeReportTypeID, reportType.ReportTypeID.ToString()), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportType.TVType   (TVTypeEnum)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.TVType = (TVTypeEnum)1000000;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeTVType), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportType.FileType   (FileTypeEnum)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.FileType = (FileTypeEnum)1000000;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeFileType), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportType.UniqueCode   (String)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("UniqueCode");
                    Assert.AreEqual(false, reportTypeService.Add(reportType));
                    Assert.AreEqual(1, reportType.ValidationResults.Count());
                    Assert.IsTrue(reportType.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeUniqueCode)).Any());
                    Assert.AreEqual(null, reportType.UniqueCode);
                    Assert.AreEqual(count, reportTypeService.GetRead().Count());

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.UniqueCode = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeService.Add(reportType));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.ReportTypeUniqueCode, "100"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportType.ReportTypeWeb   (ReportTypeWeb)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeWeb = null;
                    Assert.IsNull(reportType.ReportTypeWeb);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeWeb = new ReportTypeWeb();
                    Assert.IsNotNull(reportType.ReportTypeWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // reportType.ReportTypeReport   (ReportTypeReport)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeReport = null;
                    Assert.IsNull(reportType.ReportTypeReport);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeReport = new ReportTypeReport();
                    Assert.IsNotNull(reportType.ReportTypeReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportType.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateDate_UTC = new DateTime();
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.ReportTypeLastUpdateDate_UTC), reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.ReportTypeLastUpdateDate_UTC, "1980"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportType.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateContactTVItemID = 0;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.ReportTypeLastUpdateContactTVItemID, reportType.LastUpdateContactTVItemID.ToString()), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateContactTVItemID = 1;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.ReportTypeLastUpdateContactTVItemID, "Contact"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportType.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // reportType.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetReportTypeWithReportTypeID(reportType.ReportTypeID)
        [TestMethod]
        public void GetReportTypeWithReportTypeID__reportType_ReportTypeID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new GetParam(), dbTestDB, ContactID);
                    ReportType reportType = (from c in reportTypeService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportType);

                    ReportType reportTypeRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportTypeService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            reportTypeRet = reportTypeService.GetReportTypeWithReportTypeID(reportType.ReportTypeID);
                            Assert.IsNull(reportTypeRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            reportTypeRet = reportTypeService.GetReportTypeWithReportTypeID(reportType.ReportTypeID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            reportTypeRet = reportTypeService.GetReportTypeWithReportTypeID(reportType.ReportTypeID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            reportTypeRet = reportTypeService.GetReportTypeWithReportTypeID(reportType.ReportTypeID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ReportType fields
                        Assert.IsNotNull(reportTypeRet.ReportTypeID);
                        Assert.IsNotNull(reportTypeRet.TVType);
                        Assert.IsNotNull(reportTypeRet.FileType);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeRet.UniqueCode));
                        Assert.IsNotNull(reportTypeRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(reportTypeRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ReportTypeWeb and ReportTypeReport fields should be null here
                            Assert.IsNull(reportTypeRet.ReportTypeWeb);
                            Assert.IsNull(reportTypeRet.ReportTypeReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ReportTypeWeb fields should not be null and ReportTypeReport fields should be null here
                            if (reportTypeRet.ReportTypeWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeRet.ReportTypeWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(reportTypeRet.ReportTypeReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ReportTypeWeb and ReportTypeReport fields should NOT be null here
                            if (reportTypeRet.ReportTypeWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeRet.ReportTypeWeb.LastUpdateContactTVText));
                            }
                            if (reportTypeRet.ReportTypeReport.ReportTypeReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeRet.ReportTypeReport.ReportTypeReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeWithReportTypeID(reportType.ReportTypeID)

        #region Tests Generated for GetReportTypeList()
        [TestMethod]
        public void GetReportTypeList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new GetParam(), dbTestDB, ContactID);
                    ReportType reportType = (from c in reportTypeService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(reportType);

                    List<ReportType> reportTypeList = new List<ReportType>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        reportTypeService.GetParam.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            Assert.AreEqual(0, reportTypeList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        // ReportType fields
                        Assert.IsNotNull(reportTypeList[0].ReportTypeID);
                        Assert.IsNotNull(reportTypeList[0].TVType);
                        Assert.IsNotNull(reportTypeList[0].FileType);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeList[0].UniqueCode));
                        Assert.IsNotNull(reportTypeList[0].LastUpdateDate_UTC);
                        Assert.IsNotNull(reportTypeList[0].LastUpdateContactTVItemID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // ReportTypeWeb and ReportTypeReport fields should be null here
                            Assert.IsNull(reportTypeList[0].ReportTypeWeb);
                            Assert.IsNull(reportTypeList[0].ReportTypeReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // ReportTypeWeb fields should not be null and ReportTypeReport fields should be null here
                            if (reportTypeList[0].ReportTypeWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeList[0].ReportTypeWeb.LastUpdateContactTVText));
                            }
                            Assert.IsNull(reportTypeList[0].ReportTypeReport);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // ReportTypeWeb and ReportTypeReport fields should NOT be null here
                            if (reportTypeList[0].ReportTypeWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeList[0].ReportTypeWeb.LastUpdateContactTVText));
                            }
                            if (reportTypeList[0].ReportTypeReport.ReportTypeReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeList[0].ReportTypeReport.ReportTypeReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList()

        #region Tests Generated for GetReportTypeList() Skip Take
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    List<ReportType> reportTypeList = new List<ReportType>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        GetParamService getParamService = new GetParamService(new GetParam(), dbTestDB, ContactID);

                        GetParam getParam = getParamService.FillProp(typeof(ReportType), "en", 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);
                        ReportTypeService reportTypeService = new ReportTypeService(getParam, dbTestDB, ContactID);

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            Assert.AreEqual(0, reportTypeList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }

                        Assert.AreEqual(getParam.Take, reportTypeList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take

    }
}
