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
    public partial class TVFileServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVFileService tvFileService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileServiceTest() : base()
        {
            //tvFileService = new TVFileService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVFile_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVFile tvFile = GetFilledRandomTVFile("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    count = tvFileService.GetTVFileList().Count();

                    Assert.AreEqual(tvFileService.GetTVFileList().Count(), (from c in dbTestDB.TVFiles select c).Take(200).Count());

                    tvFileService.Add(tvFile);
                    if (tvFile.HasErrors)
                    {
                        Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvFileService.GetTVFileList().Where(c => c == tvFile).Any());
                    tvFileService.Update(tvFile);
                    if (tvFile.HasErrors)
                    {
                        Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvFileService.GetTVFileList().Count());
                    tvFileService.Delete(tvFile);
                    if (tvFile.HasErrors)
                    {
                        Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvFile.TVFileID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileID = 0;
                    tvFileService.Update(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileTVFileID"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileID = 10000000;
                    tvFileService.Update(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileTVFileID", tvFile.TVFileID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // tvFile.TVFileTVItemID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileTVItemID = 0;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVFileTVItemID", tvFile.TVFileTVItemID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileTVItemID = 1;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileTVFileTVItemID", "File"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // tvFile.TemplateTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TemplateTVType = (TVTypeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileTemplateTVType"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = )]
                    // tvFile.ReportTypeID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ReportTypeID = 0;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "TVFileReportTypeID", tvFile.ReportTypeID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // tvFile.Parameters   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [Range(1980, 2050)]
                    // tvFile.Year   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.Year = 1979;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVFileYear", "1980", "2050"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.Year = 2051;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVFileYear", "1980", "2050"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.Language   (LanguageEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.Language = (LanguageEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguage"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.FilePurpose   (FilePurposeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FilePurpose = (FilePurposeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileFilePurpose"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.FileType   (FileTypeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileType = (FileTypeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileFileType"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000000)]
                    // tvFile.FileSize_kb   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileSize_kb = -1;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVFileFileSize_kb", "0", "100000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileSize_kb = 100000001;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVFileFileSize_kb", "0", "100000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // tvFile.FileInfo   (String)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvFile.FileCreatedDate_UTC   (DateTime)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileCreatedDate_UTC = new DateTime();
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileFileCreatedDate_UTC"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileCreatedDate_UTC = new DateTime(1979, 1, 1);
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVFileFileCreatedDate_UTC", "1980"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is Nullable
                    // tvFile.FromWater   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(250))]
                    // tvFile.ClientFilePath   (String)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ClientFilePath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TVFileClientFilePath", "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvFile.ServerFileName   (String)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("ServerFileName");
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(1, tvFile.ValidationResults.Count());
                    Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TVFileServerFileName")).Any());
                    Assert.AreEqual(null, tvFile.ServerFileName);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ServerFileName = GetRandomString("", 251);
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TVFileServerFileName", "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvFile.ServerFilePath   (String)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("ServerFilePath");
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(1, tvFile.ValidationResults.Count());
                    Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, "TVFileServerFilePath")).Any());
                    Assert.AreEqual(null, tvFile.ServerFilePath);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ServerFilePath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "TVFileServerFilePath", "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetTVFileList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvFile.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateDate_UTC = new DateTime();
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "TVFileLastUpdateDate_UTC"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVFileLastUpdateDate_UTC", "1980"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvFile.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateContactTVItemID = 0;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileLastUpdateContactTVItemID", tvFile.LastUpdateContactTVItemID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateContactTVItemID = 1;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileLastUpdateContactTVItemID", "Contact"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvFile.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvFile.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVFileWithTVFileID(tvFile.TVFileID)
        [TestMethod]
        public void GetTVFileWithTVFileID__tvFile_TVFileID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVFile tvFile = (from c in dbTestDB.TVFiles select c).FirstOrDefault();
                    Assert.IsNotNull(tvFile);

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvFileService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            TVFile tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID);
                            CheckTVFileFields(new List<TVFile>() { tvFileRet });
                            Assert.AreEqual(tvFile.TVFileID, tvFileRet.TVFileID);
                        }
                        else if (detail == "A")
                        {
                            TVFile_A tvFile_ARet = tvFileService.GetTVFile_AWithTVFileID(tvFile.TVFileID);
                            CheckTVFile_AFields(new List<TVFile_A>() { tvFile_ARet });
                            Assert.AreEqual(tvFile.TVFileID, tvFile_ARet.TVFileID);
                        }
                        else if (detail == "B")
                        {
                            TVFile_B tvFile_BRet = tvFileService.GetTVFile_BWithTVFileID(tvFile.TVFileID);
                            CheckTVFile_BFields(new List<TVFile_B>() { tvFile_BRet });
                            Assert.AreEqual(tvFile.TVFileID, tvFile_BRet.TVFileID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileWithTVFileID(tvFile.TVFileID)

        #region Tests Generated for GetTVFileList()
        [TestMethod]
        public void GetTVFileList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    TVFile tvFile = (from c in dbTestDB.TVFiles select c).FirstOrDefault();
                    Assert.IsNotNull(tvFile);

                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        tvFileService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList()

        #region Tests Generated for GetTVFileList() Skip Take
        [TestMethod]
        public void GetTVFileList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                        tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_AList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_BList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() Skip Take

        #region Tests Generated for GetTVFileList() Skip Take Order
        [TestMethod]
        public void GetTVFileList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 1, 1,  "TVFileID", "");

                        List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                        tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Skip(1).Take(1).OrderBy(c => c.TVFileID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_AList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_BList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() Skip Take Order

        #region Tests Generated for GetTVFileList() Skip Take 2Order
        [TestMethod]
        public void GetTVFileList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 1, 1, "TVFileID,TVFileTVItemID", "");

                        List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                        tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Skip(1).Take(1).OrderBy(c => c.TVFileID).ThenBy(c => c.TVFileTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_AList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_BList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() Skip Take 2Order

        #region Tests Generated for GetTVFileList() Skip Take Order Where
        [TestMethod]
        public void GetTVFileList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 0, 1, "TVFileID", "TVFileID,EQ,4", "");

                        List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                        tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Where(c => c.TVFileID == 4).Skip(0).Take(1).OrderBy(c => c.TVFileID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_AList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_BList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() Skip Take Order Where

        #region Tests Generated for GetTVFileList() Skip Take Order 2Where
        [TestMethod]
        public void GetTVFileList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 0, 1, "TVFileID", "TVFileID,GT,2|TVFileID,LT,5", "");

                        List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                        tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Where(c => c.TVFileID > 2 && c.TVFileID < 5).Skip(0).Take(1).OrderBy(c => c.TVFileID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_AList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_BList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() Skip Take Order 2Where

        #region Tests Generated for GetTVFileList() 2Where
        [TestMethod]
        public void GetTVFileList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "_A", "_B", "_C", "_D", "_E" })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVFileID,GT,2|TVFileID,LT,5", "");

                        List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                        tvFileDirectQueryList = (from c in dbTestDB.TVFiles select c).Where(c => c.TVFileID > 2 && c.TVFileID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<TVFile> tvFileList = new List<TVFile>();
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            CheckTVFileFields(tvFileList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        }
                        else if (detail == "A")
                        {
                            List<TVFile_A> tvFile_AList = new List<TVFile_A>();
                            tvFile_AList = tvFileService.GetTVFile_AList().ToList();
                            CheckTVFile_AFields(tvFile_AList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_AList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_AList.Count);
                        }
                        else if (detail == "B")
                        {
                            List<TVFile_B> tvFile_BList = new List<TVFile_B>();
                            tvFile_BList = tvFileService.GetTVFile_BList().ToList();
                            CheckTVFile_BFields(tvFile_BList);
                            Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFile_BList[0].TVFileID);
                            Assert.AreEqual(tvFileDirectQueryList.Count, tvFile_BList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() 2Where

        #region Functions private
        private void CheckTVFileFields(List<TVFile> tvFileList)
        {
            Assert.IsNotNull(tvFileList[0].TVFileID);
            Assert.IsNotNull(tvFileList[0].TVFileTVItemID);
            if (tvFileList[0].TemplateTVType != null)
            {
                Assert.IsNotNull(tvFileList[0].TemplateTVType);
            }
            if (tvFileList[0].ReportTypeID != null)
            {
                Assert.IsNotNull(tvFileList[0].ReportTypeID);
            }
            if (!string.IsNullOrWhiteSpace(tvFileList[0].Parameters))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].Parameters));
            }
            if (tvFileList[0].Year != null)
            {
                Assert.IsNotNull(tvFileList[0].Year);
            }
            Assert.IsNotNull(tvFileList[0].Language);
            Assert.IsNotNull(tvFileList[0].FilePurpose);
            Assert.IsNotNull(tvFileList[0].FileType);
            Assert.IsNotNull(tvFileList[0].FileSize_kb);
            if (!string.IsNullOrWhiteSpace(tvFileList[0].FileInfo))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].FileInfo));
            }
            Assert.IsNotNull(tvFileList[0].FileCreatedDate_UTC);
            if (tvFileList[0].FromWater != null)
            {
                Assert.IsNotNull(tvFileList[0].FromWater);
            }
            if (!string.IsNullOrWhiteSpace(tvFileList[0].ClientFilePath))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].ClientFilePath));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].ServerFileName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].ServerFilePath));
            Assert.IsNotNull(tvFileList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFileList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFileList[0].HasErrors);
        }
        private void CheckTVFile_AFields(List<TVFile_A> tvFile_AList)
        {
            Assert.IsNotNull(tvFile_AList[0].TVFileTVItemLanguage);
            Assert.IsNotNull(tvFile_AList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].TemplateTVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].TemplateTVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].FilePurposeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].FilePurposeText));
            }
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].FileTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].FileTypeText));
            }
            Assert.IsNotNull(tvFile_AList[0].TVFileID);
            Assert.IsNotNull(tvFile_AList[0].TVFileTVItemID);
            if (tvFile_AList[0].TemplateTVType != null)
            {
                Assert.IsNotNull(tvFile_AList[0].TemplateTVType);
            }
            if (tvFile_AList[0].ReportTypeID != null)
            {
                Assert.IsNotNull(tvFile_AList[0].ReportTypeID);
            }
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].Parameters))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].Parameters));
            }
            if (tvFile_AList[0].Year != null)
            {
                Assert.IsNotNull(tvFile_AList[0].Year);
            }
            Assert.IsNotNull(tvFile_AList[0].Language);
            Assert.IsNotNull(tvFile_AList[0].FilePurpose);
            Assert.IsNotNull(tvFile_AList[0].FileType);
            Assert.IsNotNull(tvFile_AList[0].FileSize_kb);
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].FileInfo))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].FileInfo));
            }
            Assert.IsNotNull(tvFile_AList[0].FileCreatedDate_UTC);
            if (tvFile_AList[0].FromWater != null)
            {
                Assert.IsNotNull(tvFile_AList[0].FromWater);
            }
            if (!string.IsNullOrWhiteSpace(tvFile_AList[0].ClientFilePath))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].ClientFilePath));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].ServerFileName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_AList[0].ServerFilePath));
            Assert.IsNotNull(tvFile_AList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFile_AList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFile_AList[0].HasErrors);
        }
        private void CheckTVFile_BFields(List<TVFile_B> tvFile_BList)
        {
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].TVFileReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].TVFileReportTest));
            }
            Assert.IsNotNull(tvFile_BList[0].TVFileTVItemLanguage);
            Assert.IsNotNull(tvFile_BList[0].LastUpdateContactTVItemLanguage);
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].TemplateTVTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].TemplateTVTypeText));
            }
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].LanguageText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].LanguageText));
            }
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].FilePurposeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].FilePurposeText));
            }
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].FileTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].FileTypeText));
            }
            Assert.IsNotNull(tvFile_BList[0].TVFileID);
            Assert.IsNotNull(tvFile_BList[0].TVFileTVItemID);
            if (tvFile_BList[0].TemplateTVType != null)
            {
                Assert.IsNotNull(tvFile_BList[0].TemplateTVType);
            }
            if (tvFile_BList[0].ReportTypeID != null)
            {
                Assert.IsNotNull(tvFile_BList[0].ReportTypeID);
            }
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].Parameters))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].Parameters));
            }
            if (tvFile_BList[0].Year != null)
            {
                Assert.IsNotNull(tvFile_BList[0].Year);
            }
            Assert.IsNotNull(tvFile_BList[0].Language);
            Assert.IsNotNull(tvFile_BList[0].FilePurpose);
            Assert.IsNotNull(tvFile_BList[0].FileType);
            Assert.IsNotNull(tvFile_BList[0].FileSize_kb);
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].FileInfo))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].FileInfo));
            }
            Assert.IsNotNull(tvFile_BList[0].FileCreatedDate_UTC);
            if (tvFile_BList[0].FromWater != null)
            {
                Assert.IsNotNull(tvFile_BList[0].FromWater);
            }
            if (!string.IsNullOrWhiteSpace(tvFile_BList[0].ClientFilePath))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].ClientFilePath));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].ServerFileName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFile_BList[0].ServerFilePath));
            Assert.IsNotNull(tvFile_BList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(tvFile_BList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(tvFile_BList[0].HasErrors);
        }
        private TVFile GetFilledRandomTVFile(string OmitPropName)
        {
            TVFile tvFile = new TVFile();

            if (OmitPropName != "TVFileTVItemID") tvFile.TVFileTVItemID = 41;
            if (OmitPropName != "TemplateTVType") tvFile.TemplateTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ReportTypeID") tvFile.ReportTypeID = 1;
            if (OmitPropName != "Parameters") tvFile.Parameters = GetRandomString("", 20);
            if (OmitPropName != "Year") tvFile.Year = GetRandomInt(1980, 2050);
            if (OmitPropName != "Language") tvFile.Language = LanguageRequest;
            if (OmitPropName != "FilePurpose") tvFile.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FileType") tvFile.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "FileSize_kb") tvFile.FileSize_kb = GetRandomInt(0, 100000000);
            if (OmitPropName != "FileInfo") tvFile.FileInfo = GetRandomString("", 20);
            if (OmitPropName != "FileCreatedDate_UTC") tvFile.FileCreatedDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "FromWater") tvFile.FromWater = true;
            if (OmitPropName != "ClientFilePath") tvFile.ClientFilePath = GetRandomString("", 5);
            if (OmitPropName != "ServerFileName") tvFile.ServerFileName = GetRandomString("", 5);
            if (OmitPropName != "ServerFilePath") tvFile.ServerFilePath = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") tvFile.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFile.LastUpdateContactTVItemID = 2;

            return tvFile;
        }
        #endregion Functions private
    }
}
