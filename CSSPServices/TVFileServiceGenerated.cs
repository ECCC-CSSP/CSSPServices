using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class TVFileService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFile tvFile = validationContext.ObjectInstance as TVFile;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvFile.TVFileID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileTVFileID), new[] { "TVFileID" });
                }
            }

            //TVFileID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVFileTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileTVFileTVItemID, tvFile.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVFileTVFileTVItemID, "File"), new[] { "TVFileTVItemID" });
                }
            }

            retStr = enums.TVTypeOK(tvFile.TemplateTVType);
            if (tvFile.TemplateTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileTemplateTVType), new[] { "TemplateTVType" });
            }

            retStr = enums.LanguageOK(tvFile.Language);
            if (tvFile.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLanguage), new[] { "Language" });
            }

            retStr = enums.FilePurposeOK(tvFile.FilePurpose);
            if (tvFile.FilePurpose == FilePurposeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFilePurpose), new[] { "FilePurpose" });
            }

            retStr = enums.FileTypeOK(tvFile.FileType);
            if (tvFile.FileType == FileTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileType), new[] { "FileType" });
            }

            //FileSize_kb (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvFile.FileSize_kb < 0 || tvFile.FileSize_kb > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVFileFileSize_kb, "0", "1000000"), new[] { "FileSize_kb" });
            }

            //FileInfo has no StringLength Attribute

            if (tvFile.FileCreatedDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileCreatedDate_UTC), new[] { "FileCreatedDate_UTC" });
            }
            else
            {
                if (tvFile.FileCreatedDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVFileFileCreatedDate_UTC, "1980"), new[] { "FileCreatedDate_UTC" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ClientFilePath) && tvFile.ClientFilePath.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileClientFilePath, "250"), new[] { "ClientFilePath" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFileName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFileName), new[] { "ServerFileName" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFileName) && tvFile.ServerFileName.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileServerFileName, "250"), new[] { "ServerFileName" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFilePath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFilePath), new[] { "ServerFilePath" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFilePath) && tvFile.ServerFilePath.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileServerFilePath, "250"), new[] { "ServerFilePath" });
            }

            if (tvFile.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFile.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVFileLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileLastUpdateContactTVItemID, tvFile.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVFileLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFile.TemplateTVTypeText) && tvFile.TemplateTVTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileTemplateTVTypeText, "100"), new[] { "TemplateTVTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.LanguageText) && tvFile.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.FilePurposeText) && tvFile.FilePurposeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileFilePurposeText, "100"), new[] { "FilePurposeText" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.FileTypeText) && tvFile.FileTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVFileFileTypeText, "100"), new[] { "FileTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVFile GetTVFileWithTVFileID(int TVFileID)
        {
            IQueryable<TVFile> tvFileQuery = (from c in GetRead()
                                                where c.TVFileID == TVFileID
                                                select c);

            return FillTVFile(tvFileQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TVFile tvFile)
        {
            tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Create);
            if (tvFile.ValidationResults.Count() > 0) return false;

            db.TVFiles.Add(tvFile);

            if (!TryToSave(tvFile)) return false;

            return true;
        }
        public bool AddRange(List<TVFile> tvFileList)
        {
            foreach (TVFile tvFile in tvFileList)
            {
                tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Create);
                if (tvFile.ValidationResults.Count() > 0) return false;
            }

            db.TVFiles.AddRange(tvFileList);

            if (!TryToSaveRange(tvFileList)) return false;

            return true;
        }
        public bool Delete(TVFile tvFile)
        {
            if (!db.TVFiles.Where(c => c.TVFileID == tvFile.TVFileID).Any())
            {
                tvFile.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFile.TVFileID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVFiles.Remove(tvFile);

            if (!TryToSave(tvFile)) return false;

            return true;
        }
        public bool DeleteRange(List<TVFile> tvFileList)
        {
            foreach (TVFile tvFile in tvFileList)
            {
                if (!db.TVFiles.Where(c => c.TVFileID == tvFile.TVFileID).Any())
                {
                    tvFileList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFile.TVFileID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVFiles.RemoveRange(tvFileList);

            if (!TryToSaveRange(tvFileList)) return false;

            return true;
        }
        public bool Update(TVFile tvFile)
        {
            tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Update);
            if (tvFile.ValidationResults.Count() > 0) return false;

            db.TVFiles.Update(tvFile);

            if (!TryToSave(tvFile)) return false;

            return true;
        }
        public bool UpdateRange(List<TVFile> tvFileList)
        {
            foreach (TVFile tvFile in tvFileList)
            {
                tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Update);
                if (tvFile.ValidationResults.Count() > 0) return false;
            }
            db.TVFiles.UpdateRange(tvFileList);

            if (!TryToSaveRange(tvFileList)) return false;

            return true;
        }
        public IQueryable<TVFile> GetRead()
        {
            return db.TVFiles.AsNoTracking();
        }
        public IQueryable<TVFile> GetEdit()
        {
            return db.TVFiles;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TVFile> FillTVFile(IQueryable<TVFile> tvFileQuery)
        {
            List<TVFile> TVFileList = (from c in tvFileQuery
                                         select new TVFile
                                         {
                                             TVFileID = c.TVFileID,
                                             TVFileTVItemID = c.TVFileTVItemID,
                                             TemplateTVType = c.TemplateTVType,
                                             Language = c.Language,
                                             FilePurpose = c.FilePurpose,
                                             FileType = c.FileType,
                                             FileSize_kb = c.FileSize_kb,
                                             FileInfo = c.FileInfo,
                                             FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                             FromWater = c.FromWater,
                                             ClientFilePath = c.ClientFilePath,
                                             ServerFileName = c.ServerFileName,
                                             ServerFilePath = c.ServerFilePath,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TVFile tvFile in TVFileList)
            {
                tvFile.TemplateTVTypeText = enums.GetEnumText_TVTypeEnum(tvFile.TemplateTVType);
                tvFile.LanguageText = enums.GetEnumText_LanguageEnum(tvFile.Language);
                tvFile.FilePurposeText = enums.GetEnumText_FilePurposeEnum(tvFile.FilePurpose);
                tvFile.FileTypeText = enums.GetEnumText_FileTypeEnum(tvFile.FileType);
            }

            return TVFileList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(TVFile tvFile)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvFile.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVFile> tvFileList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvFileList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
