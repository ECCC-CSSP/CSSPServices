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

                    count = tvFileService.GetRead().Count();

                    Assert.AreEqual(tvFileService.GetRead().Count(), tvFileService.GetEdit().Count());

                    tvFileService.Add(tvFile);
                    if (tvFile.HasErrors)
                    {
                        Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvFileService.GetRead().Where(c => c == tvFile).Any());
                    tvFileService.Update(tvFile);
                    if (tvFile.HasErrors)
                    {
                        Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvFileService.GetRead().Count());
                    tvFileService.Delete(tvFile);
                    if (tvFile.HasErrors)
                    {
                        Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileTVFileID), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileID = 10000000;
                    tvFileService.Update(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVFile, CSSPModelsRes.TVFileTVFileID, tvFile.TVFileID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
                    // tvFile.TVFileTVItemID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileTVItemID = 0;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVFileTVFileTVItemID, tvFile.TVFileTVItemID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileTVItemID = 1;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVFileTVFileTVItemID, "File"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // tvFile.TemplateTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TemplateTVType = (TVTypeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileTemplateTVType), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = Error)]
                    // tvFile.ReportTypeID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ReportTypeID = 0;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.TVFileReportTypeID, tvFile.ReportTypeID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileYear, "1980", "2050"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.Year = 2051;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileYear, "1980", "2050"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.Language   (LanguageEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.Language = (LanguageEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguage), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.FilePurpose   (FilePurposeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FilePurpose = (FilePurposeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileFilePurpose), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.FileType   (FileTypeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileType = (FileTypeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileFileType), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100000000)]
                    // tvFile.FileSize_kb   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileSize_kb = -1;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileFileSize_kb, "0", "100000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileSize_kb = 100000001;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileFileSize_kb, "0", "100000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileFileCreatedDate_UTC), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileCreatedDate_UTC = new DateTime(1979, 1, 1);
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVFileFileCreatedDate_UTC, "1980"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVFileClientFilePath, "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvFile.ServerFileName   (String)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("ServerFileName");
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(1, tvFile.ValidationResults.Count());
                    Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileServerFileName)).Any());
                    Assert.AreEqual(null, tvFile.ServerFileName);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ServerFileName = GetRandomString("", 251);
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVFileServerFileName, "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [StringLength(250))]
                    // tvFile.ServerFilePath   (String)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("ServerFilePath");
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(1, tvFile.ValidationResults.Count());
                    Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileServerFilePath)).Any());
                    Assert.AreEqual(null, tvFile.ServerFilePath);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.ServerFilePath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVFileServerFilePath, "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvFile.TVFileWeb   (TVFileWeb)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileWeb = null;
                    Assert.IsNull(tvFile.TVFileWeb);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileWeb = new TVFileWeb();
                    Assert.IsNotNull(tvFile.TVFileWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvFile.TVFileReport   (TVFileReport)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileReport = null;
                    Assert.IsNull(tvFile.TVFileReport);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TVFileReport = new TVFileReport();
                    Assert.IsNotNull(tvFile.TVFileReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvFile.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateDate_UTC = new DateTime();
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLastUpdateDate_UTC), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVFileLastUpdateDate_UTC, "1980"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvFile.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateContactTVItemID = 0;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVFileLastUpdateContactTVItemID, tvFile.LastUpdateContactTVItemID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.LastUpdateContactTVItemID = 1;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVFileLastUpdateContactTVItemID, "Contact"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    TVFile tvFile = (from c in tvFileService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFile);

                    TVFile tvFileRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvFileService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID);
                            Assert.IsNull(tvFileRet);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID);
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID);
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(new List<TVFile>() { tvFileRet }, entityQueryDetailType);
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
                    TVFile tvFile = (from c in tvFileService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFile);

                    List<TVFile> tvFileList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        tvFileService.Query.EntityQueryDetailType = entityQueryDetailType;

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
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
                    List<TVFile> tvFileList = new List<TVFile>();
                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 1, 1, "", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvFileDirectQueryList = tvFileService.GetRead().Skip(1).Take(1).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
                        Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        Assert.AreEqual(1, tvFileList.Count);
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
                    List<TVFile> tvFileList = new List<TVFile>();
                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 1, 1,  "TVFileID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvFileDirectQueryList = tvFileService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVFileID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
                        Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        Assert.AreEqual(1, tvFileList.Count);
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
                    List<TVFile> tvFileList = new List<TVFile>();
                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 1, 1, "TVFileID,TVFileTVItemID", "", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvFileDirectQueryList = tvFileService.GetRead().Skip(1).Take(1).OrderBy(c => c.TVFileID).ThenBy(c => c.TVFileTVItemID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
                        Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        Assert.AreEqual(1, tvFileList.Count);
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
                    List<TVFile> tvFileList = new List<TVFile>();
                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 0, 1, "TVFileID", "TVFileID,EQ,4", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvFileDirectQueryList = tvFileService.GetRead().Where(c => c.TVFileID == 4).Skip(0).Take(1).OrderBy(c => c.TVFileID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
                        Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        Assert.AreEqual(1, tvFileList.Count);
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
                    List<TVFile> tvFileList = new List<TVFile>();
                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 0, 1, "TVFileID", "TVFileID,GT,2|TVFileID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvFileDirectQueryList = tvFileService.GetRead().Where(c => c.TVFileID > 2 && c.TVFileID < 5).Skip(0).Take(1).OrderBy(c => c.TVFileID).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
                        Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        Assert.AreEqual(1, tvFileList.Count);
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
                    List<TVFile> tvFileList = new List<TVFile>();
                    List<TVFile> tvFileDirectQueryList = new List<TVFile>();
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailType in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        TVFileService tvFileService = new TVFileService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        tvFileService.Query = tvFileService.FillQuery(typeof(TVFile), culture.TwoLetterISOLanguageName, 0, 10000, "", "TVFileID,GT,2|TVFileID,LT,5", entityQueryDetailType, EntityQueryTypeEnum.AsNoTracking);

                        tvFileDirectQueryList = tvFileService.GetRead().Where(c => c.TVFileID > 2 && c.TVFileID < 5).ToList();

                        if (entityQueryDetailType == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                            Assert.AreEqual(0, tvFileList.Count);
                            continue;
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            tvFileList = tvFileService.GetTVFileList().ToList();
                        }
                        else
                        {
                            // nothing for now
                        }
                        CheckTVFileFields(tvFileList, entityQueryDetailType);
                        Assert.AreEqual(tvFileDirectQueryList[0].TVFileID, tvFileList[0].TVFileID);
                        Assert.AreEqual(2, tvFileList.Count);
                    }
                }
            }
        }
        #endregion Tests Generated for GetTVFileList() 2Where

        #region Functions private
        private void CheckTVFileFields(List<TVFile> tvFileList, EntityQueryDetailTypeEnum entityQueryDetailType)
        {
            // TVFile fields
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

            if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityOnly)
            {
                // TVFileWeb and TVFileReport fields should be null here
                Assert.IsNull(tvFileList[0].TVFileWeb);
                Assert.IsNull(tvFileList[0].TVFileReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityWeb)
            {
                // TVFileWeb fields should not be null and TVFileReport fields should be null here
                if (!string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.TVFileTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.TVFileTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.LastUpdateContactTVText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.LastUpdateContactTVText));
                }
                if (!string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.TemplateTVTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.TemplateTVTypeText));
                }
                if (!string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.LanguageText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.LanguageText));
                }
                if (!string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.FilePurposeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.FilePurposeText));
                }
                if (!string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.FileTypeText))
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.FileTypeText));
                }
                Assert.IsNull(tvFileList[0].TVFileReport);
            }
            else if (entityQueryDetailType == EntityQueryDetailTypeEnum.EntityReport)
            {
                // TVFileWeb and TVFileReport fields should NOT be null here
                if (tvFileList[0].TVFileWeb.TVFileTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.TVFileTVText));
                }
                if (tvFileList[0].TVFileWeb.LastUpdateContactTVText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.LastUpdateContactTVText));
                }
                if (tvFileList[0].TVFileWeb.TemplateTVTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.TemplateTVTypeText));
                }
                if (tvFileList[0].TVFileWeb.LanguageText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.LanguageText));
                }
                if (tvFileList[0].TVFileWeb.FilePurposeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.FilePurposeText));
                }
                if (tvFileList[0].TVFileWeb.FileTypeText != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileWeb.FileTypeText));
                }
                if (tvFileList[0].TVFileReport.TVFileReportTest != null)
                {
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileList[0].TVFileReport.TVFileReportTest));
                }
            }
        }
        private TVFile GetFilledRandomTVFile(string OmitPropName)
        {
            TVFile tvFile = new TVFile();

            if (OmitPropName != "TVFileTVItemID") tvFile.TVFileTVItemID = 38;
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
