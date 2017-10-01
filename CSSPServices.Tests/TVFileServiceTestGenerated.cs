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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFile GetFilledRandomTVFile(string OmitPropName)
        {
            TVFile tvFile = new TVFile();

            // Need to implement (no items found, would need to add at least one in the TestDB) [TVFile TVFileTVItemID TVItem TVItemID]
            if (OmitPropName != "TemplateTVType") tvFile.TemplateTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "Language") tvFile.Language = LanguageRequest;
            if (OmitPropName != "FilePurpose") tvFile.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FileType") tvFile.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "FileSize_kb") tvFile.FileSize_kb = GetRandomInt(0, 1000000);
            if (OmitPropName != "FileInfo") tvFile.FileInfo = GetRandomString("", 20);
            if (OmitPropName != "FileCreatedDate_UTC") tvFile.FileCreatedDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "FromWater") tvFile.FromWater = true;
            if (OmitPropName != "ClientFilePath") tvFile.ClientFilePath = GetRandomString("", 5);
            if (OmitPropName != "ServerFileName") tvFile.ServerFileName = GetRandomString("", 5);
            if (OmitPropName != "ServerFilePath") tvFile.ServerFilePath = GetRandomString("", 5);
            //Error: property [TVFileWeb] and type [TVFile] is  not implemented
            //Error: property [TVFileReport] and type [TVFile] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") tvFile.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFile.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") tvFile.HasErrors = true;

            return tvFile;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVFile_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileService tvFileService = new TVFileService(LanguageRequest, dbTestDB, ContactID);

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
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvFile.TemplateTVType   (TVTypeEnum)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.TemplateTVType = (TVTypeEnum)1000000;
                    tvFileService.Add(tvFile);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileTemplateTVType), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


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
                    // [Range(0, 1000000)]
                    // tvFile.FileSize_kb   (Int32)
                    // -----------------------------------

                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileSize_kb = -1;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileFileSize_kb, "0", "1000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvFileService.GetRead().Count());
                    tvFile = null;
                    tvFile = GetFilledRandomTVFile("");
                    tvFile.FileSize_kb = 1000001;
                    Assert.AreEqual(false, tvFileService.Add(tvFile));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileFileSize_kb, "0", "1000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
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

                    //Error: Type not implemented [TVFileWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvFile.TVFileReport   (TVFileReport)
                    // -----------------------------------

                    //Error: Type not implemented [TVFileReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvFile.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


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


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvFile.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVFile_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVFileService tvFileService = new TVFileService(LanguageRequest, dbTestDB, ContactID);
                    TVFile tvFile = (from c in tvFileService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvFile);

                    TVFile tvFileRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvFileRet = tvFileService.GetTVFileWithTVFileID(tvFile.TVFileID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(tvFileRet.TVFileID);
                        Assert.IsNotNull(tvFileRet.TVFileTVItemID);
                        Assert.IsNotNull(tvFileRet.TemplateTVType);
                        Assert.IsNotNull(tvFileRet.Language);
                        Assert.IsNotNull(tvFileRet.FilePurpose);
                        Assert.IsNotNull(tvFileRet.FileType);
                        Assert.IsNotNull(tvFileRet.FileSize_kb);
                        if (tvFileRet.FileInfo != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileRet.FileInfo));
                        }
                        Assert.IsNotNull(tvFileRet.FileCreatedDate_UTC);
                        if (tvFileRet.FromWater != null)
                        {
                            Assert.IsNotNull(tvFileRet.FromWater);
                        }
                        if (tvFileRet.ClientFilePath != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileRet.ClientFilePath));
                        }
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileRet.ServerFileName));
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tvFileRet.ServerFilePath));
                        Assert.IsNotNull(tvFileRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tvFileRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (tvFileRet.TVFileWeb != null)
                            {
                                Assert.IsNull(tvFileRet.TVFileWeb);
                            }
                            if (tvFileRet.TVFileReport != null)
                            {
                                Assert.IsNull(tvFileRet.TVFileReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (tvFileRet.TVFileWeb != null)
                            {
                                Assert.IsNotNull(tvFileRet.TVFileWeb);
                            }
                            if (tvFileRet.TVFileReport != null)
                            {
                                Assert.IsNotNull(tvFileRet.TVFileReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of TVFile
        #endregion Tests Get List of TVFile

    }
}
