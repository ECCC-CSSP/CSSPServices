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
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvFile.TVFileID   (Int32)
            // -----------------------------------

            tvFile = GetFilledRandomTVFile("");
            tvFile.TVFileID = 0;
            tvFileService.Update(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileTVFileID), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.File)]
            // [Range(1, -1)]
            // tvFile.TVFileTVItemID   (Int32)
            // -----------------------------------

            // TVFileTVItemID will automatically be initialized at 0 --> not null


            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // TVFileTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvFile.TVFileTVItemID = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.TVFileTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // TVFileTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvFile.TVFileTVItemID = 2;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(2, tvFile.TVFileTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // TVFileTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvFile.TVFileTVItemID = 0;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileTVFileTVItemID, "1")).Any());
            Assert.AreEqual(0, tvFile.TVFileTVItemID);
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.TemplateTVType   (TVTypeEnum)
            // -----------------------------------

            // TemplateTVType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.Language   (LanguageEnum)
            // -----------------------------------

            // Language will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.FilePurpose   (FilePurposeEnum)
            // -----------------------------------

            // FilePurpose will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.FileType   (FileTypeEnum)
            // -----------------------------------

            // FileType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000000)]
            // tvFile.FileSize_kb   (Int32)
            // -----------------------------------

            // FileSize_kb will automatically be initialized at 0 --> not null


            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // FileSize_kb has Min [0] and Max [1000000]. At Min should return true and no errors
            tvFile.FileSize_kb = 0;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(0, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            tvFile.FileSize_kb = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            tvFile.FileSize_kb = -1;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000")).Any());
            Assert.AreEqual(-1, tvFile.FileSize_kb);
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Max should return true and no errors
            tvFile.FileSize_kb = 1000000;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1000000, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            tvFile.FileSize_kb = 999999;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(999999, tvFile.FileSize_kb);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // FileSize_kb has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            tvFile.FileSize_kb = 1000001;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000")).Any());
            Assert.AreEqual(1000001, tvFile.FileSize_kb);
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // tvFile.FileInfo   (String)
            // -----------------------------------


            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvFile.FileCreatedDate_UTC   (DateTime)
            // -----------------------------------

            // FileCreatedDate_UTC will automatically be initialized at 0 --> not null


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

            // ClientFilePath has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string tvFileClientFilePathMin = GetRandomString("", 250);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            tvFileClientFilePathMin = GetRandomString("", 249);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // ClientFilePath has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            tvFileClientFilePathMin = GetRandomString("", 251);
            tvFile.ClientFilePath = tvFileClientFilePathMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileClientFilePath, "250")).Any());
            Assert.AreEqual(tvFileClientFilePathMin, tvFile.ClientFilePath);
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
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFileName)).Any());
            Assert.AreEqual(null, tvFile.ServerFileName);
            Assert.AreEqual(0, tvFileService.GetRead().Count());


            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // ServerFileName has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string tvFileServerFileNameMin = GetRandomString("", 250);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            tvFileServerFileNameMin = GetRandomString("", 249);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // ServerFileName has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            tvFileServerFileNameMin = GetRandomString("", 251);
            tvFile.ServerFileName = tvFileServerFileNameMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileServerFileName, "250")).Any());
            Assert.AreEqual(tvFileServerFileNameMin, tvFile.ServerFileName);
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
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFilePath)).Any());
            Assert.AreEqual(null, tvFile.ServerFilePath);
            Assert.AreEqual(0, tvFileService.GetRead().Count());


            tvFile = null;
            tvFile = GetFilledRandomTVFile("");

            // ServerFilePath has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string tvFileServerFilePathMin = GetRandomString("", 250);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            tvFileServerFilePathMin = GetRandomString("", 249);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // ServerFilePath has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            tvFileServerFilePathMin = GetRandomString("", 251);
            tvFile.ServerFilePath = tvFileServerFilePathMin;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileServerFilePath, "250")).Any());
            Assert.AreEqual(tvFileServerFilePathMin, tvFile.ServerFilePath);
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvFile.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // tvFile.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvFile.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(1, tvFile.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvFile.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvFileService.Add(tvFile));
            Assert.AreEqual(0, tvFile.ValidationResults.Count());
            Assert.AreEqual(2, tvFile.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvFileService.Delete(tvFile));
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvFile.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.IsTrue(tvFile.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvFile.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvFile.TVFileLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvFile.TVFileTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvFile.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
