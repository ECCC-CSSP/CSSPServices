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

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class TVFileTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVFileID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFile GetFilledRandomTVFile(string OmitPropName)
        {
            TVFileID += 1;

            TVFile tvFile = new TVFile();

            if (OmitPropName != "TVFileID") tvFile.TVFileID = TVFileID;
            if (OmitPropName != "TVFileTVItemID") tvFile.TVFileTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TemplateTVType") tvFile.TemplateTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "Language") tvFile.Language = language;
            if (OmitPropName != "FilePurpose") tvFile.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FileType") tvFile.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "FileSize_kb") tvFile.FileSize_kb = GetRandomInt(0, 100000);
            if (OmitPropName != "FileInfo") tvFile.FileInfo = GetRandomString("", 5);
            if (OmitPropName != "FileCreatedDate_UTC") tvFile.FileCreatedDate_UTC = GetRandomDateTime();
            if (OmitPropName != "FromWater") tvFile.FromWater = true;
            if (OmitPropName != "ClientFilePath") tvFile.ClientFilePath = GetRandomString("", 7);
            if (OmitPropName != "ServerFileName") tvFile.ServerFileName = GetRandomString("", 7);
            if (OmitPropName != "ServerFilePath") tvFile.ServerFilePath = GetRandomString("", 7);
            if (OmitPropName != "LastUpdateDate_UTC") tvFile.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvFile.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvFile;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVFile_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            TVFileService tvFileService = new TVFileService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            TVFile tvFile = GetFilledRandomTVFile("");
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(true, tvFileService.GetRead().Where(c => c == tvFile).Any());
            tvFile.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvFileService.Update(tvFile));
            Assert.AreEqual(1, tvFileService.GetRead().Count());
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVFileTVItemID will automatically be initialized at 0 --> not null

            tvFile = null;
            tvFile = GetFilledRandomTVFile("TemplateTVType");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileTemplateTVType)).Any());
            Assert.AreEqual(TVTypeEnum.Error, tvFile.TemplateTVType);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("Language");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguage)).Any());
            Assert.AreEqual(LanguageEnum.Error, tvFile.Language);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("FilePurpose");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFilePurpose)).Any());
            Assert.AreEqual(FilePurposeEnum.Error, tvFile.FilePurpose);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("FileType");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileType)).Any());
            Assert.AreEqual(FileTypeEnum.Error, tvFile.FileType);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // FileSize_kb will automatically be initialized at 0 --> not null

            tvFile = null;
            tvFile = GetFilledRandomTVFile("FileCreatedDate_UTC");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileCreatedDate_UTC)).Any());
            Assert.IsTrue(tvFile.FileCreatedDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("ServerFileName");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFileName)).Any());
            Assert.AreEqual(null, tvFile.ServerFileName);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("ServerFilePath");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFilePath)).Any());
            Assert.AreEqual(null, tvFile.ServerFilePath);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvFile.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVFileID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVFileTVItemID] of type [int]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // TVFileTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvFile.TVFileTVItemID = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.TVFileTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // TVFileTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvFile.TVFileTVItemID = 2;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(2, tvFile.TVFileTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // TVFileTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvFile.TVFileTVItemID = 0;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileTVFileTVItemID, "1")).Any());
            Assert.AreEqual(0, tvFile.TVFileTVItemID);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [TemplateTVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Language] of type [LanguageEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FilePurpose] of type [FilePurposeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FileType] of type [FileTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [FileSize_kb] of type [int]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // FileSize_kb has Min [0] and Max [100000]. At Min should return true and no errors
            tvFile.FileSize_kb = 0;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(0, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [100000]. At Min + 1 should return true and no errors
            tvFile.FileSize_kb = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [100000]. At Min - 1 should return false with one error
            tvFile.FileSize_kb = -1;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "100000")).Any());
            Assert.AreEqual(-1, tvFile.FileSize_kb);
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [100000]. At Max should return true and no errors
            tvFile.FileSize_kb = 100000;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(100000, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [100000]. At Max - 1 should return true and no errors
            tvFile.FileSize_kb = 99999;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(99999, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [100000]. At Max + 1 should return false with one error
            tvFile.FileSize_kb = 100001;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "100000")).Any());
            Assert.AreEqual(100001, tvFile.FileSize_kb);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [FileInfo] of type [string]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // FileInfo has MinLength [0] and MaxLength [empty]. At Min should return true and no errors
            string tvFileFileInfoMin = GetRandomString("", 0);
            tvFile.FileInfo = tvFileFileInfoMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileFileInfoMin, tvFile.FileInfo);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // FileInfo has MinLength [0] and MaxLength [empty]. At Min + 1 should return true and no errors
            tvFileFileInfoMin = GetRandomString("", 1);
            tvFile.FileInfo = tvFileFileInfoMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileFileInfoMin, tvFile.FileInfo);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [FileCreatedDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [FromWater] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClientFilePath] of type [string]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // ClientFilePath has MinLength [2] and MaxLength [250]. At Min should return true and no errors
            string tvFileClientFilePathMin = GetRandomString("", 2);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [2] and MaxLength [250]. At Min + 1 should return true and no errors
            tvFileClientFilePathMin = GetRandomString("", 3);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [2] and MaxLength [250]. At Min - 1 should return false with one error
            tvFileClientFilePathMin = GetRandomString("", 1);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFileClientFilePath, "2", "250")).Any());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [2] and MaxLength [250]. At Max should return true and no errors
            tvFileClientFilePathMin = GetRandomString("", 250);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [2] and MaxLength [250]. At Max - 1 should return true and no errors
            tvFileClientFilePathMin = GetRandomString("", 249);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [2] and MaxLength [250]. At Max + 1 should return false with one error
            tvFileClientFilePathMin = GetRandomString("", 251);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFileClientFilePath, "2", "250")).Any());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [ServerFileName] of type [string]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // ServerFileName has MinLength [2] and MaxLength [250]. At Min should return true and no errors
            string tvFileServerFileNameMin = GetRandomString("", 2);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [2] and MaxLength [250]. At Min + 1 should return true and no errors
            tvFileServerFileNameMin = GetRandomString("", 3);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [2] and MaxLength [250]. At Min - 1 should return false with one error
            tvFileServerFileNameMin = GetRandomString("", 1);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFileServerFileName, "2", "250")).Any());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [2] and MaxLength [250]. At Max should return true and no errors
            tvFileServerFileNameMin = GetRandomString("", 250);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [2] and MaxLength [250]. At Max - 1 should return true and no errors
            tvFileServerFileNameMin = GetRandomString("", 249);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [2] and MaxLength [250]. At Max + 1 should return false with one error
            tvFileServerFileNameMin = GetRandomString("", 251);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFileServerFileName, "2", "250")).Any());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [ServerFilePath] of type [string]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // ServerFilePath has MinLength [2] and MaxLength [250]. At Min should return true and no errors
            string tvFileServerFilePathMin = GetRandomString("", 2);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [2] and MaxLength [250]. At Min + 1 should return true and no errors
            tvFileServerFilePathMin = GetRandomString("", 3);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [2] and MaxLength [250]. At Min - 1 should return false with one error
            tvFileServerFilePathMin = GetRandomString("", 1);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFileServerFilePath, "2", "250")).Any());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [2] and MaxLength [250]. At Max should return true and no errors
            tvFileServerFilePathMin = GetRandomString("", 250);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [2] and MaxLength [250]. At Max - 1 should return true and no errors
            tvFileServerFilePathMin = GetRandomString("", 249);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [2] and MaxLength [250]. At Max + 1 should return false with one error
            tvFileServerFilePathMin = GetRandomString("", 251);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVFileServerFilePath, "2", "250")).Any());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvFile.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvFile.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(2, tvFile.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvFile.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvFile.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
