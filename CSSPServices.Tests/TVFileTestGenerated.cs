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

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.TVFileID = 0;
            tvFileService.Update(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileTVFileID), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.File)]
            // tvFile.TVFileTVItemID   (Int32)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.TVFileTVItemID = 0;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileTVFileTVItemID, tvFile.TVFileTVItemID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.TVFileTVItemID = 1;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVFileTVFileTVItemID, "File"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.TemplateTVType   (TVTypeEnum)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.TemplateTVType = (TVTypeEnum)1000000;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileTemplateTVType), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.Language   (LanguageEnum)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.Language = (LanguageEnum)1000000;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguage), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.FilePurpose   (FilePurposeEnum)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.FilePurpose = (FilePurposeEnum)1000000;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFilePurpose), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvFile.FileType   (FileTypeEnum)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.FileType = (FileTypeEnum)1000000;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileType), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000000)]
            // tvFile.FileSize_kb   (Int32)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.FileSize_kb = -1;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvFileService.GetRead().Count());
            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.FileSize_kb = 1000001;
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileClientFilePath, "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.ServerFileName = GetRandomString("", 251);
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileServerFileName, "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
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
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.ServerFilePath = GetRandomString("", 251);
            Assert.AreEqual(false, tvFileService.Add(tvFile));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileServerFilePath, "250"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvFileService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvFile.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvFile.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.LastUpdateContactTVItemID = 0;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileLastUpdateContactTVItemID, tvFile.LastUpdateContactTVItemID.ToString()), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);

            tvFile = null;
            tvFile = GetFilledRandomTVFile("");
            tvFile.LastUpdateContactTVItemID = 1;
            tvFileService.Add(tvFile);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVFileLastUpdateContactTVItemID, "Contact"), tvFile.ValidationResults.FirstOrDefault().ErrorMessage);


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
