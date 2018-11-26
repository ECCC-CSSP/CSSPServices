/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [TVFileController](CSSPWebAPI.Controllers.TVFileController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.TVFile](CSSPModels.TVFile.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [TVTypeEnum](CSSPEnums.TVTypeEnum.html), [LanguageEnum](CSSPEnums.LanguageEnum.html), [FilePurposeEnum](CSSPEnums.FilePurposeEnum.html), [FileTypeEnum](CSSPEnums.FileTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class TVFileService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB TVFiles table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public TVFileService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all TVFileService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TVFileID"), new[] { "TVFileID" });
                }

                if (!(from c in db.TVFiles select c).Where(c => c.TVFileID == tvFile.TVFileID).Any())
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVFile", "TVFileID", tvFile.TVFileID.ToString()), new[] { "TVFileID" });
                }
            }

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVFileTVItemID", tvFile.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TVFileTVItemID", "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (tvFile.TemplateTVType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)tvFile.TemplateTVType);
                if (tvFile.TemplateTVType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TemplateTVType"), new[] { "TemplateTVType" });
                }
            }

            if (tvFile.ReportTypeID != null)
            {
                ReportType ReportTypeReportTypeID = (from c in db.ReportTypes where c.ReportTypeID == tvFile.ReportTypeID select c).FirstOrDefault();

                if (ReportTypeReportTypeID == null)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "ReportType", "ReportTypeID", (tvFile.ReportTypeID == null ? "" : tvFile.ReportTypeID.ToString())), new[] { "ReportTypeID" });
                }
            }

            //Parameters has no StringLength Attribute

            if (tvFile.Year != null)
            {
                if (tvFile.Year < 1980 || tvFile.Year > 2050)
                {
                    tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Year", "1980", "2050"), new[] { "Year" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)tvFile.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(FilePurposeEnum), (int?)tvFile.FilePurpose);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FilePurpose"), new[] { "FilePurpose" });
            }

            retStr = enums.EnumTypeOK(typeof(FileTypeEnum), (int?)tvFile.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileType"), new[] { "FileType" });
            }

            if (tvFile.FileSize_kb < 0 || tvFile.FileSize_kb > 100000000)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FileSize_kb", "0", "100000000"), new[] { "FileSize_kb" });
            }

            //FileInfo has no StringLength Attribute

            if (tvFile.FileCreatedDate_UTC.Year == 1)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileCreatedDate_UTC"), new[] { "FileCreatedDate_UTC" });
            }
            else
            {
                if (tvFile.FileCreatedDate_UTC.Year < 1980)
                {
                tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "FileCreatedDate_UTC", "1980"), new[] { "FileCreatedDate_UTC" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ClientFilePath) && tvFile.ClientFilePath.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ClientFilePath", "250"), new[] { "ClientFilePath" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFileName))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ServerFileName"), new[] { "ServerFileName" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFileName) && tvFile.ServerFileName.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ServerFileName", "250"), new[] { "ServerFileName" });
            }

            if (string.IsNullOrWhiteSpace(tvFile.ServerFilePath))
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "ServerFilePath"), new[] { "ServerFilePath" });
            }

            if (!string.IsNullOrWhiteSpace(tvFile.ServerFilePath) && tvFile.ServerFilePath.Length > 250)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ServerFilePath", "250"), new[] { "ServerFilePath" });
            }

            if (tvFile.LastUpdateDate_UTC.Year == 1)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvFile.LastUpdateDate_UTC.Year < 1980)
                {
                tvFile.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tvFile.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", tvFile.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        /// <summary>
        /// Gets the TVFile model with the TVFileID identifier
        /// </summary>
        /// <param name="TVFileID">Is the identifier of [TVFiles](CSSPModels.TVFile.html) table of CSSPDB</param>
        /// <returns>[TVFile](CSSPModels.TVFile.html) object connected to the CSSPDB</returns>
        public TVFile GetTVFileWithTVFileID(int TVFileID)
        {
            return (from c in db.TVFiles
                    where c.TVFileID == TVFileID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVFile](CSSPModels.TVFile.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVFile](CSSPModels.TVFile.html)</returns>
        public IQueryable<TVFile> GetTVFileList()
        {
            IQueryable<TVFile> TVFileQuery = (from c in db.TVFiles select c);

            TVFileQuery = EnhanceQueryStatements<TVFile>(TVFileQuery) as IQueryable<TVFile>;

            return TVFileQuery;
        }
        /// <summary>
        /// Gets the TVFileExtraA model with the TVFileID identifier
        /// </summary>
        /// <param name="TVFileID">Is the identifier of [TVFiles](CSSPModels.TVFile.html) table of CSSPDB</param>
        /// <returns>[TVFileExtraA](CSSPModels.TVFileExtraA.html) object connected to the CSSPDB</returns>
        public TVFileExtraA GetTVFileExtraAWithTVFileID(int TVFileID)
        {
            return FillTVFileExtraA().Where(c => c.TVFileID == TVFileID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVFileExtraA](CSSPModels.TVFileExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVFileExtraA](CSSPModels.TVFileExtraA.html)</returns>
        public IQueryable<TVFileExtraA> GetTVFileExtraAList()
        {
            IQueryable<TVFileExtraA> TVFileExtraAQuery = FillTVFileExtraA();

            TVFileExtraAQuery = EnhanceQueryStatements<TVFileExtraA>(TVFileExtraAQuery) as IQueryable<TVFileExtraA>;

            return TVFileExtraAQuery;
        }
        /// <summary>
        /// Gets the TVFileExtraB model with the TVFileID identifier
        /// </summary>
        /// <param name="TVFileID">Is the identifier of [TVFiles](CSSPModels.TVFile.html) table of CSSPDB</param>
        /// <returns>[TVFileExtraB](CSSPModels.TVFileExtraB.html) object connected to the CSSPDB</returns>
        public TVFileExtraB GetTVFileExtraBWithTVFileID(int TVFileID)
        {
            return FillTVFileExtraB().Where(c => c.TVFileID == TVFileID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [TVFileExtraB](CSSPModels.TVFileExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [TVFileExtraB](CSSPModels.TVFileExtraB.html)</returns>
        public IQueryable<TVFileExtraB> GetTVFileExtraBList()
        {
            IQueryable<TVFileExtraB> TVFileExtraBQuery = FillTVFileExtraB();

            TVFileExtraBQuery = EnhanceQueryStatements<TVFileExtraB>(TVFileExtraBQuery) as IQueryable<TVFileExtraB>;

            return TVFileExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [TVFile](CSSPModels.TVFile.html) item in CSSPDB
        /// </summary>
        /// <param name="tvFile">Is the TVFile item the client want to add to CSSPDB</param>
        /// <returns>true if TVFile item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(TVFile tvFile)
        {
            tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Create);
            if (tvFile.ValidationResults.Count() > 0) return false;

            db.TVFiles.Add(tvFile);

            if (!TryToSave(tvFile)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [TVFile](CSSPModels.TVFile.html) item in CSSPDB
        /// </summary>
        /// <param name="tvFile">Is the TVFile item the client want to add to CSSPDB. What's important here is the TVFileID</param>
        /// <returns>true if TVFile item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(TVFile tvFile)
        {
            tvFile.ValidationResults = Validate(new ValidationContext(tvFile), ActionDBTypeEnum.Delete);
            if (tvFile.ValidationResults.Count() > 0) return false;

            db.TVFiles.Remove(tvFile);

            if (!TryToSave(tvFile)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [TVFile](CSSPModels.TVFile.html) item in CSSPDB
        /// </summary>
        /// <param name="tvFile">Is the TVFile item the client want to add to CSSPDB. What's important here is the TVFileID</param>
        /// <returns>true if TVFile item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [TVFile](CSSPModels.TVFile.html) item
        /// </summary>
        /// <param name="tvFile">Is the TVFile item the client want to add to CSSPDB. What's important here is the TVFileID</param>
        /// <returns>true if TVFile item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
