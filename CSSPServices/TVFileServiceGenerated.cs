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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVFile tvFile = validationContext.ObjectInstance as TVFile;

            //TVFileID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVFileID has no Range Attribute

            //TVFileTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVFileTVItemID has no Range Attribute

                //Error: Type not implemented [TemplateTVType] of type [TVTypeEnum]

                //Error: Type not implemented [TemplateTVType] of type [TVTypeEnum]
                //Error: Type not implemented [Language] of type [LanguageEnum]

                //Error: Type not implemented [Language] of type [LanguageEnum]
                //Error: Type not implemented [FilePurpose] of type [FilePurposeEnum]

                //Error: Type not implemented [FilePurpose] of type [FilePurposeEnum]
                //Error: Type not implemented [FileType] of type [FileTypeEnum]

                //Error: Type not implemented [FileType] of type [FileTypeEnum]
            //FileSize_kb (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FileSize_kb has no Range Attribute

            if (string.IsNullOrWhiteSpace(tvFile.FileInfo))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileInfo), new[] { ModelsRes.TVFileFileInfo });
            }

            //FileInfo has no StringLength Attribute

            if (tvFile.FileCreatedDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileFileCreatedDate_UTC), new[] { ModelsRes.TVFileFileCreatedDate_UTC });
            }

                //Error: Type not implemented [FromWater] of type [Nullable`1]

            if (string.IsNullOrWhiteSpace(tvFile.ClientFilePath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileClientFilePath), new[] { ModelsRes.TVFileClientFilePath });
            }

            //ClientFilePath has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(tvFile.ServerFileName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFileName), new[] { ModelsRes.TVFileServerFileName });
            }

            //ServerFileName has no StringLength Attribute

            if (string.IsNullOrWhiteSpace(tvFile.ServerFilePath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileServerFilePath), new[] { ModelsRes.TVFileServerFilePath });
            }

            //ServerFilePath has no StringLength Attribute

            if (tvFile.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVFileLastUpdateDate_UTC), new[] { ModelsRes.TVFileLastUpdateDate_UTC });
            }

            if (tvFile.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVFileLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVFileLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvFile.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVFileLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVFileLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvFile.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVFileLastUpdateContactTVItemID, tvFile.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVFileLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
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
        #endregion Functions public

        #region Functions private
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
        #endregion Functions private
    }
}
