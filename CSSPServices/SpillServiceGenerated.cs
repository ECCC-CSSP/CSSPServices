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
    public partial class SpillService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public SpillService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            Spill spill = validationContext.ObjectInstance as Spill;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (spill.SpillID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillSpillID), new[] { ModelsRes.SpillSpillID });
                }
            }

            //SpillID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MunicipalityTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spill.MunicipalityTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillMunicipalityTVItemID, "1"), new[] { ModelsRes.SpillMunicipalityTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillMunicipalityTVItemID, spill.MunicipalityTVItemID.ToString()), new[] { ModelsRes.SpillMunicipalityTVItemID });
            }

            if (spill.InfrastructureTVItemID != null)
            {
                if (spill.InfrastructureTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillInfrastructureTVItemID, "1"), new[] { ModelsRes.SpillInfrastructureTVItemID });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillInfrastructureTVItemID, spill.InfrastructureTVItemID.ToString()), new[] { ModelsRes.SpillInfrastructureTVItemID });
                }
            }

            if (spill.StartDateTime_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillStartDateTime_Local), new[] { ModelsRes.SpillStartDateTime_Local });
            }

            if (spill.StartDateTime_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillStartDateTime_Local, "1980"), new[] { ModelsRes.SpillStartDateTime_Local });
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillEndDateTime_Local, "1980"), new[] { ModelsRes.SpillEndDateTime_Local });
            }

            if (spill.StartDateTime_Local < spill.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.SpillEndDateTime_Local, ModelsRes.SpillStartDateTime_Local), new[] { ModelsRes.SpillEndDateTime_Local });
            }

            //AverageFlow_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SpillAverageFlow_m3_day, "0", "1000000"), new[] { ModelsRes.SpillAverageFlow_m3_day });
            }

            if (spill.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLastUpdateDate_UTC), new[] { ModelsRes.SpillLastUpdateDate_UTC });
            }

            if (spill.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillLastUpdateDate_UTC, "1980"), new[] { ModelsRes.SpillLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spill.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SpillLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLastUpdateContactTVItemID, spill.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.SpillLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Add(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public bool AddRange(List<Spill> spillList)
        {
            foreach (Spill spill in spillList)
            {
                spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
                if (spill.ValidationResults.Count() > 0) return false;
            }

            db.Spills.AddRange(spillList);

            if (!TryToSaveRange(spillList)) return false;

            return true;
        }
        public bool Delete(Spill spill)
        {
            if (!db.Spills.Where(c => c.SpillID == spill.SpillID).Any())
            {
                spill.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Spills.Remove(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public bool DeleteRange(List<Spill> spillList)
        {
            foreach (Spill spill in spillList)
            {
                if (!db.Spills.Where(c => c.SpillID == spill.SpillID).Any())
                {
                    spillList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Spills.RemoveRange(spillList);

            if (!TryToSaveRange(spillList)) return false;

            return true;
        }
        public bool Update(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Update(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public bool UpdateRange(List<Spill> spillList)
        {
            foreach (Spill spill in spillList)
            {
                spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
                if (spill.ValidationResults.Count() > 0) return false;
            }
            db.Spills.UpdateRange(spillList);

            if (!TryToSaveRange(spillList)) return false;

            return true;
        }
        public IQueryable<Spill> GetRead()
        {
            return db.Spills.AsNoTracking();
        }
        public IQueryable<Spill> GetEdit()
        {
            return db.Spills;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(Spill spill)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spill.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<Spill> spillList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spillList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
