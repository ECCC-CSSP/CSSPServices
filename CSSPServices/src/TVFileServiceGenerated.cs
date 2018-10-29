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
    /// <summary>
    ///     <para>bonjour TVFile</para>
    /// </summary>
    public partial class TVFileService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVFileService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFile tvFile = validationContext.ObjectInstance as TVFile;
            tvFile.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tvFile.TVFileID == 0)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileTVFileID"), new[] { "TVFileID" });
                }

                if (!(from c in db.TVFiles select c).Where(c => c.TVFileID == tvFile.TVFileID).Any())
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileTVFileID", tvFile.TVFileID.ToString()), new[] { "TVFileID" });
                }
            }

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVFileTVItemID", tvFile.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileTVFileTVItemID", "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (tvFile.TemplateTVType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvFile.TemplateTVType);
                if (tvFile.TemplateTVType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileTemplateTVType"), new[] { "TemplateTVType" });
                }
            }

            if (tvFile.ReportTypeID != null)
            {
                ReportType ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == tvFile.ReportTypeID select c).FirstOrDefault();

                if (ReportTypeReportTypeID == null)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "TVFileReportTypeID", (tvFile.ReportTypeID == null ? "" : tvFile.ReportTypeID.ToString())), new[] { "ReportTypeID" });
                }
            }

            //Parameters has no StringLength Attribute

            if (tvFile.Year != null)
            {
                if (tvFile.Year < 1980 || tvFile.Year > 2050)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVFileYear", "1980", "2050"), new[] { "Year" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFile.Language);
            if (tvFile.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileLanguage"), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)tvFile.FilePurpose);
            if (tvFile.FilePurpose == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileFilePurpose"), new[] { "FilePurpose" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)tvFile.FileType);
            if (tvFile.FileType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileFileType"), new[] { "FileType" });
            }

            if (tvFile.FileSize_kb < 0 || tvFile.FileSize_kb > 100000000)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TVFileFileSize_kb", "0", "100000000"), new[] { "FileSize_kb" });
            }

            //FileInfo has no StringLength Attribute

            if (tvFile.FileCreatedDate_UTC.Year == 1)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileFileCreatedDate_UTC"), new[] { "FileCreatedDate_UTC" });
            }
            else
            {
                if (tvFile.FileCreatedDate_UTC.Year < 1980)
                {
                tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVFileFileCreatedDate_UTC", "1980"), new[] { "FileCreatedDate_UTC" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ClientFilePath) && tvFile.ClientFilePath.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVFileClientFilePath", "250"), new[] { "ClientFilePath" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFileName))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileServerFileName"), new[] { "ServerFileName" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFileName) && tvFile.ServerFileName.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVFileServerFileName", "250"), new[] { "ServerFileName" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFilePath))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileServerFilePath"), new[] { "ServerFilePath" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFilePath) && tvFile.ServerFilePath.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TVFileServerFilePath", "250"), new[] { "ServerFilePath" });
            }

            if (tvFile.LastUpdateDate_UTC.Year == 1)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFile.LastUpdateDate_UTC.Year < 1980)
                {
                tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TVFileLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileLastUpdateContactTVItemID", tvFile.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TVFile GetTVFileWithTVFileID(int TVFileID)
        {
            return (from c in db.TVFiles
                    where c.TVFileID == TVFileID
                    select c).FirstOrDefault();

        }
        public IQueryable<TVFile> GetTVFileList()
        {
            IQueryable<TVFile> TVFileQuery = (from c in db.TVFiles select c);

            TVFileQuery = EnhanceQueryStatements<TVFile>(TVFileQuery) as IQueryable<TVFile>;

            return TVFileQuery;
        }
        public TVFileExtraA GetTVFileExtraAWithTVFileID(int TVFileID)
        {
            return FillTVFileExtraA().Where(c => c.TVFileID == TVFileID).FirstOrDefault();

        }
        public IQueryable<TVFileExtraA> GetTVFileExtraAList()
        {
            IQueryable<TVFileExtraA> TVFileExtraAQuery = FillTVFileExtraA();

            TVFileExtraAQuery = EnhanceQueryStatements<TVFileExtraA>(TVFileExtraAQuery) as IQueryable<TVFileExtraA>;

            return TVFileExtraAQuery;
        }
        public TVFileExtraB GetTVFileExtraBWithTVFileID(int TVFileID)
        {
            return FillTVFileExtraB().Where(c => c.TVFileID == TVFileID).FirstOrDefault();

        }
        public IQueryable<TVFileExtraB> GetTVFileExtraBList()
        {
            IQueryable<TVFileExtraB> TVFileExtraBQuery = FillTVFileExtraB();

            TVFileExtraBQuery = EnhanceQueryStatements<TVFileExtraB>(TVFileExtraBQuery) as IQueryable<TVFileExtraB>;

            return TVFileExtraBQuery;
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
        public bool Delete(TVFile tvFile)
        {
            tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Delete);
            if (tvFile.ValidationResults.Count() > 0) return false;

            db.TVFiles.Remove(tvFile);

            if (!TryToSave(tvFile)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
