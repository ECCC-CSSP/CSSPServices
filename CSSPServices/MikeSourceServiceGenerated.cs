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
    public partial class MikeSourceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            MikeSource mikeSource = validationContext.ObjectInstance as MikeSource;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mikeSource.MikeSourceID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceMikeSourceID), new[] { ModelsRes.MikeSourceMikeSourceID });
                }
            }

            //MikeSourceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeSourceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSource.MikeSourceTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceMikeSourceTVItemID, "1"), new[] { ModelsRes.MikeSourceMikeSourceTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceMikeSourceTVItemID, mikeSource.MikeSourceTVItemID.ToString()), new[] { ModelsRes.MikeSourceMikeSourceTVItemID });
            }

            //IsContinuous (bool) is required but no testing needed 

            //Include (bool) is required but no testing needed 

            //IsRiver (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceSourceNumberString), new[] { ModelsRes.MikeSourceSourceNumberString });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceSourceNumberString, "50"), new[] { ModelsRes.MikeSourceSourceNumberString });
            }

            if (mikeSource.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceLastUpdateDate_UTC), new[] { ModelsRes.MikeSourceLastUpdateDate_UTC });
            }

            if (mikeSource.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeSourceLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MikeSourceLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSource.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MikeSourceLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceLastUpdateContactTVItemID, mikeSource.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MikeSourceLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Add(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool AddRange(List<MikeSource> mikeSourceList)
        {
            foreach (MikeSource mikeSource in mikeSourceList)
            {
                mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
                if (mikeSource.ValidationResults.Count() > 0) return false;
            }

            db.MikeSources.AddRange(mikeSourceList);

            if (!TryToSaveRange(mikeSourceList)) return false;

            return true;
        }
        public bool Delete(MikeSource mikeSource)
        {
            if (!db.MikeSources.Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
            {
                mikeSource.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MikeSources.Remove(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool DeleteRange(List<MikeSource> mikeSourceList)
        {
            foreach (MikeSource mikeSource in mikeSourceList)
            {
                if (!db.MikeSources.Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    mikeSourceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MikeSources.RemoveRange(mikeSourceList);

            if (!TryToSaveRange(mikeSourceList)) return false;

            return true;
        }
        public bool Update(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Update(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool UpdateRange(List<MikeSource> mikeSourceList)
        {
            foreach (MikeSource mikeSource in mikeSourceList)
            {
                mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
                if (mikeSource.ValidationResults.Count() > 0) return false;
            }
            db.MikeSources.UpdateRange(mikeSourceList);

            if (!TryToSaveRange(mikeSourceList)) return false;

            return true;
        }
        public IQueryable<MikeSource> GetRead()
        {
            return db.MikeSources.AsNoTracking();
        }
        public IQueryable<MikeSource> GetEdit()
        {
            return db.MikeSources;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MikeSource mikeSource)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSource.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MikeSource> mikeSourceList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSourceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
