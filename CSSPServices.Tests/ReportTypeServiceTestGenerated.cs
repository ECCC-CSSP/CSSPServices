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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void ReportType_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = reportTypeService.GetReportTypeList().Count();

                    Assert.AreEqual(count, (from c in dbTestDB.ReportTypes select c).Count());

                    reportTypeService.Add(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, reportTypeService.GetReportTypeList().Where(c => c == reportType).Any());
                    reportTypeService.Update(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, reportTypeService.GetReportTypeList().Count());
                    reportTypeService.Delete(reportType);
                    if (reportType.HasErrors)
                    {
                        Assert.AreEqual("", reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, reportTypeService.GetReportTypeList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeReportTypeID"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.ReportTypeID = 10000000;
                    reportTypeService.Update(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeReportTypeID", reportType.ReportTypeID.ToString()), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportType.TVType   (TVTypeEnum)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.TVType = (TVTypeEnum)1000000;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeTVType"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // reportType.FileType   (FileTypeEnum)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.FileType = (FileTypeEnum)1000000;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeFileType"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(100))]
                    // reportType.UniqueCode   (String)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("UniqueCode");
                    Assert.AreEqual(false, reportTypeService.Add(reportType));
                    Assert.AreEqual(1, reportType.ValidationResults.Count());
                    Assert.IsTrue(reportType.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "ReportTypeUniqueCode")).Any());
                    Assert.AreEqual(null, reportType.UniqueCode);
                    Assert.AreEqual(count, reportTypeService.GetReportTypeList().Count());

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.UniqueCode = GetRandomString("", 101);
                    Assert.AreEqual(false, reportTypeService.Add(reportType));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "ReportTypeUniqueCode", "100"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, reportTypeService.GetReportTypeList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // reportType.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateDate_UTC = new DateTime();
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "ReportTypeLastUpdateDate_UTC"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);
                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "ReportTypeLastUpdateDate_UTC", "1980"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // reportType.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateContactTVItemID = 0;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "ReportTypeLastUpdateContactTVItemID", reportType.LastUpdateContactTVItemID.ToString()), reportType.ValidationResults.FirstOrDefault().ErrorMessage);

                    reportType = null;
                    reportType = GetFilledRandomReportType("");
                    reportType.LastUpdateContactTVItemID = 1;
                    reportTypeService.Add(reportType);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "ReportTypeLastUpdateContactTVItemID", "Contact"), reportType.ValidationResults.FirstOrDefault().ErrorMessage);


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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportType reportType = (from c in dbTestDB.ReportTypes select c).FirstOrDefault();
                    Assert.IsNotNull(reportType);

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        reportTypeService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            ReportType reportTypeRet = reportTypeService.GetReportTypeWithReportTypeID(reportType.ReportTypeID);
                            CheckReportTypeFields(new List<ReportType>() { reportTypeRet });
                            Assert.AreEqual(reportType.ReportTypeID, reportTypeRet.ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            ReportTypeExtraA reportTypeExtraARet = reportTypeService.GetReportTypeExtraAWithReportTypeID(reportType.ReportTypeID);
                            CheckReportTypeExtraAFields(new List<ReportTypeExtraA>() { reportTypeExtraARet });
                            Assert.AreEqual(reportType.ReportTypeID, reportTypeExtraARet.ReportTypeID);
                        }
                        else if (extra == "ExtraB")
                        {
                            ReportTypeExtraB reportTypeExtraBRet = reportTypeService.GetReportTypeExtraBWithReportTypeID(reportType.ReportTypeID);
                            CheckReportTypeExtraBFields(new List<ReportTypeExtraB>() { reportTypeExtraBRet });
                            Assert.AreEqual(reportType.ReportTypeID, reportTypeExtraBRet.ReportTypeID);
                        }
                        else
                        {
                            // nothing for now
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    ReportType reportType = (from c in dbTestDB.ReportTypes select c).FirstOrDefault();
                    Assert.IsNotNull(reportType);

                    List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                    reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Take(200).ToList();

                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        reportTypeService.Query.Extra = extra;

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
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

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraAList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraBList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take

        #region Tests Generated for GetReportTypeList() Skip Take Order
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 1, 1,  "ReportTypeID", "");

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Skip(1).Take(1).OrderBy(c => c.ReportTypeID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraAList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraBList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take Order

        #region Tests Generated for GetReportTypeList() Skip Take 2Order
        [TestMethod]
        public void GetReportTypeList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 1, 1, "ReportTypeID,TVType", "");

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Skip(1).Take(1).OrderBy(c => c.ReportTypeID).ThenBy(c => c.TVType).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraAList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraBList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take 2Order

        #region Tests Generated for GetReportTypeList() Skip Take Order Where
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeID", "ReportTypeID,EQ,4", "");

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Where(c => c.ReportTypeID == 4).Skip(0).Take(1).OrderBy(c => c.ReportTypeID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraAList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraBList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take Order Where

        #region Tests Generated for GetReportTypeList() Skip Take Order 2Where
        [TestMethod]
        public void GetReportTypeList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 0, 1, "ReportTypeID", "ReportTypeID,GT,2|ReportTypeID,LT,5", "");

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Where(c => c.ReportTypeID > 2 && c.ReportTypeID < 5).Skip(0).Take(1).OrderBy(c => c.ReportTypeID).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraAList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraBList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() Skip Take Order 2Where

        #region Tests Generated for GetReportTypeList() 2Where
        [TestMethod]
        public void GetReportTypeList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string extra in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        ReportTypeService reportTypeService = new ReportTypeService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        reportTypeService.Query = reportTypeService.FillQuery(typeof(ReportType), culture.TwoLetterISOLanguageName, 0, 10000, "", "ReportTypeID,GT,2|ReportTypeID,LT,5", "");

                        List<ReportType> reportTypeDirectQueryList = new List<ReportType>();
                        reportTypeDirectQueryList = (from c in dbTestDB.ReportTypes select c).Where(c => c.ReportTypeID > 2 && c.ReportTypeID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(extra))
                        {
                            List<ReportType> reportTypeList = new List<ReportType>();
                            reportTypeList = reportTypeService.GetReportTypeList().ToList();
                            CheckReportTypeFields(reportTypeList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeList[0].ReportTypeID);
                        }
                        else if (extra == "ExtraA")
                        {
                            List<ReportTypeExtraA> reportTypeExtraAList = new List<ReportTypeExtraA>();
                            reportTypeExtraAList = reportTypeService.GetReportTypeExtraAList().ToList();
                            CheckReportTypeExtraAFields(reportTypeExtraAList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraAList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraAList.Count);
                        }
                        else if (extra == "ExtraB")
                        {
                            List<ReportTypeExtraB> reportTypeExtraBList = new List<ReportTypeExtraB>();
                            reportTypeExtraBList = reportTypeService.GetReportTypeExtraBList().ToList();
                            CheckReportTypeExtraBFields(reportTypeExtraBList);
                            Assert.AreEqual(reportTypeDirectQueryList[0].ReportTypeID, reportTypeExtraBList[0].ReportTypeID);
                            Assert.AreEqual(reportTypeDirectQueryList.Count, reportTypeExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetReportTypeList() 2Where

        #region Functions private
        private void CheckReportTypeFields(List<ReportType> reportTypeList)
        {
            Assert.IsNotNull(reportTypeList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeList[0].TVType);
            Assert.IsNotNull(reportTypeList[0].FileType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeList[0].UniqueCode));
            Assert.IsNotNull(reportTypeList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeList[0].HasErrors);
        }
        private void CheckReportTypeExtraAFields(List<ReportTypeExtraA> reportTypeExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeExtraAList[0].LastUpdateContactText));
            Assert.IsNotNull(reportTypeExtraAList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeExtraAList[0].TVType);
            Assert.IsNotNull(reportTypeExtraAList[0].FileType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeExtraAList[0].UniqueCode));
            Assert.IsNotNull(reportTypeExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeExtraAList[0].HasErrors);
        }
        private void CheckReportTypeExtraBFields(List<ReportTypeExtraB> reportTypeExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(reportTypeExtraBList[0].ReportTypeReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeExtraBList[0].ReportTypeReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeExtraBList[0].LastUpdateContactText));
            Assert.IsNotNull(reportTypeExtraBList[0].ReportTypeID);
            Assert.IsNotNull(reportTypeExtraBList[0].TVType);
            Assert.IsNotNull(reportTypeExtraBList[0].FileType);
            Assert.IsFalse(string.IsNullOrWhiteSpace(reportTypeExtraBList[0].UniqueCode));
            Assert.IsNotNull(reportTypeExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(reportTypeExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(reportTypeExtraBList[0].HasErrors);
        }
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
    }
}
