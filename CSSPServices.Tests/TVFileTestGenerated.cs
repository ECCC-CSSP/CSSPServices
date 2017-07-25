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
        private TVFileService tvFileService { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileTest() : base()
        {
            tvFileService = new TVFileService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVFile GetFilledRandomTVFile(string OmitPropName)
        {
            TVFile tvFile = new TVFile();

            if (OmitPropName != "TVFileTVItemID") tvFile.TVFileTVItemID = 17;
            if (OmitPropName != "TemplateTVType") tvFile.TemplateTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "Language") tvFile.Language = language;
            if (OmitPropName != "FilePurpose") tvFile.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FileType") tvFile.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "FileSize_kb") tvFile.FileSize_kb = GetRandomInt(0, 1000000);
            if (OmitPropName != "FileInfo") tvFile.FileInfo = GetRandomString("", 20);
            if (OmitPropName != "FileCreatedDate_UTC") tvFile.FileCreatedDate_UTC = GetRandomDateTime();
            if (OmitPropName != "FromWater") tvFile.FromWater = true;
            if (OmitPropName != "ClientFilePath") tvFile.ClientFilePath = GetRandomString("", 5);
            if (OmitPropName != "ServerFileName") tvFile.ServerFileName = GetRandomString("", 5);
            if (OmitPropName != "ServerFilePath") tvFile.ServerFilePath = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") tvFile.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvFile.LastUpdateContactTVItemID = 2;

            return tvFile;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVFile_Testing()
        {

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

            tvFileService.Add(tvFile);
            if (tvFile.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvFileService.GetRead().Where(c => c == tvFile).Any());
            tvFileService.Update(tvFile);
            if (tvFile.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvFileService.GetRead().Count());
            tvFileService.Delete(tvFile);
            if (tvFile.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVFileTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TemplateTVType]

            //Error: Type not implemented [Language]

            //Error: Type not implemented [FilePurpose]

            //Error: Type not implemented [FileType]

            // FileSize_kb will automatically be initialized at 0 --> not null

            tvFile = null;
            tvFile = GetFilledRandomTVFile("FileInfo");
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(1, tvFile.ValidationResults.Count());
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileInfo)).Any());
            Assert.AreEqual(null, tvFile.FileInfo);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

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

            //Error: Type not implemented [TVFileLanguages]

            //Error: Type not implemented [TVFileTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVFileID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVFileTVItemID] of type [Int32]
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
            // doing property [FileSize_kb] of type [Int32]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // FileSize_kb has Min [0] and Max [1000000]. At Min should return true and no errors
            tvFile.FileSize_kb = 0;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(0, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            tvFile.FileSize_kb = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            tvFile.FileSize_kb = -1;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000")).Any());
            Assert.AreEqual(-1, tvFile.FileSize_kb);
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Max should return true and no errors
            tvFile.FileSize_kb = 1000000;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1000000, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            tvFile.FileSize_kb = 999999;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(999999, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(0, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            tvFile.FileSize_kb = 1000001;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000")).Any());
            Assert.AreEqual(1000001, tvFile.FileSize_kb);
            Assert.AreEqual(0, tvFileService.GetRead().Count());

            //-----------------------------------
            // doing property [FileInfo] of type [String]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            //-----------------------------------
            // doing property [FileCreatedDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [FromWater] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [ClientFilePath] of type [String]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            //-----------------------------------
            // doing property [ServerFileName] of type [String]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            //-----------------------------------
            // doing property [ServerFilePath] of type [String]
            //-----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [TVFileLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVFileTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
