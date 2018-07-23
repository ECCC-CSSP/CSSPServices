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
        public TVFileService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileTVFileID), new[] { "TVFileID" });
                }

                if (!GetRead().Where(c => c.TVFileID == tvFile.TVFileID).Any())
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVFile, CSSPModelsRes.TVFileTVFileID, tvFile.TVFileID.ToString()), new[] { "TVFileID" });
                }
            }

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVFileTVFileTVItemID, tvFile.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVFileTVFileTVItemID, "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (tvFile.TemplateTVType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvFile.TemplateTVType);
                if (tvFile.TemplateTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileTemplateTVType), new[] { "TemplateTVType" });
                }
            }

            if (tvFile.ReportTypeID != null)
            {
                ReportType ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == tvFile.ReportTypeID select c).FirstOrDefault();

                if (ReportTypeReportTypeID == null)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.ReportType, CSSPModelsRes.TVFileReportTypeID, (tvFile.ReportTypeID == null ? "" : tvFile.ReportTypeID.ToString())), new[] { "ReportTypeID" });
                }
            }

            //Parameters has no StringLength Attribute

            if (tvFile.Year != null)
            {
                if (tvFile.Year < 1980 || tvFile.Year > 2050)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileYear, "1980", "2050"), new[] { "Year" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFile.Language);
            if (tvFile.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLanguage), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)tvFile.FilePurpose);
            if (tvFile.FilePurpose == FilePurposeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileFilePurpose), new[] { "FilePurpose" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)tvFile.FileType);
            if (tvFile.FileType == FileTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileFileType), new[] { "FileType" });
            }

            if (tvFile.FileSize_kb < 0 || tvFile.FileSize_kb > 100000000)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVFileFileSize_kb, "0", "100000000"), new[] { "FileSize_kb" });
            }

            //FileInfo has no StringLength Attribute

            if (tvFile.FileCreatedDate_UTC.Year == 1)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileFileCreatedDate_UTC), new[] { "FileCreatedDate_UTC" });
            }
            else
            {
                if (tvFile.FileCreatedDate_UTC.Year < 1980)
                {
                tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVFileFileCreatedDate_UTC, "1980"), new[] { "FileCreatedDate_UTC" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ClientFilePath) && tvFile.ClientFilePath.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVFileClientFilePath, "250"), new[] { "ClientFilePath" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFileName))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileServerFileName), new[] { "ServerFileName" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFileName) && tvFile.ServerFileName.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVFileServerFileName, "250"), new[] { "ServerFileName" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFilePath))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileServerFilePath), new[] { "ServerFilePath" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFilePath) && tvFile.ServerFilePath.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVFileServerFilePath, "250"), new[] { "ServerFilePath" });
            }

            if (tvFile.LastUpdateDate_UTC.Year == 1)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVFileLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFile.LastUpdateDate_UTC.Year < 1980)
                {
                tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TVFileLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVFileLastUpdateContactTVItemID, tvFile.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVFileLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
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
            IQueryable<TVFile> tvFileQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TVFileID == TVFileID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tvFileQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTVFileWeb(tvFileQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTVFileReport(tvFileQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TVFile> GetTVFileList()
        {
            IQueryable<TVFile> tvFileQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        tvFileQuery = EnhanceQueryStatements<TVFile>(tvFileQuery) as IQueryable<TVFile>;

                        return tvFileQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        tvFileQuery = FillTVFileWeb(tvFileQuery);

                        tvFileQuery = EnhanceQueryStatements<TVFile>(tvFileQuery) as IQueryable<TVFile>;

                        return tvFileQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        tvFileQuery = FillTVFileReport(tvFileQuery);

                        tvFileQuery = EnhanceQueryStatements<TVFile>(tvFileQuery) as IQueryable<TVFile>;

                        return tvFileQuery;
                    }
                default:
                    {
                        tvFileQuery = tvFileQuery.Where(c => c.TVFileID == 0);

                        return tvFileQuery;
                    }
            }
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
        public IQueryable<TVFile> GetRead()
        {
            IQueryable<TVFile> tvFileQuery = db.TVFiles.AsNoTracking();

            return tvFileQuery;
        }
        public IQueryable<TVFile> GetEdit()
        {
            IQueryable<TVFile> tvFileQuery = db.TVFiles;

            return tvFileQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TVFileFillWeb
        private IQueryable<TVFile> FillTVFileWeb(IQueryable<TVFile> tvFileQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> FilePurposeEnumList = enums.GetEnumTextOrderedList(typeof(FilePurposeEnum));
            List<EnumIDAndText> FileTypeEnumList = enums.GetEnumTextOrderedList(typeof(FileTypeEnum));

            tvFileQuery = (from c in tvFileQuery
                let TVFileTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVFileTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TVFile
                    {
                        TVFileID = c.TVFileID,
                        TVFileTVItemID = c.TVFileTVItemID,
                        TemplateTVType = c.TemplateTVType,
                        ReportTypeID = c.ReportTypeID,
                        Parameters = c.Parameters,
                        Year = c.Year,
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
                        TVFileWeb = new TVFileWeb
                        {
                            TVFileTVText = TVFileTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            TemplateTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TemplateTVType
                                select e.EnumText).FirstOrDefault(),
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            FilePurposeText = (from e in FilePurposeEnumList
                                where e.EnumID == (int?)c.FilePurpose
                                select e.EnumText).FirstOrDefault(),
                            FileTypeText = (from e in FileTypeEnumList
                                where e.EnumID == (int?)c.FileType
                                select e.EnumText).FirstOrDefault(),
                        },
                        TVFileReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tvFileQuery;
        }
        #endregion Functions private Generated TVFileFillWeb

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
