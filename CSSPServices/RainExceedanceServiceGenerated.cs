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
    public partial class RainExceedanceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RainExceedance rainExceedance = validationContext.ObjectInstance as RainExceedance;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (rainExceedance.RainExceedanceID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceRainExceedanceID), new[] { ModelsRes.RainExceedanceRainExceedanceID });
                }
            }

            //RainExceedanceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //YearRound (bool) is required but no testing needed 

            if (rainExceedance.StartDate_Local != null && ((DateTime)rainExceedance.StartDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RainExceedanceStartDate_Local, "1980"), new[] { ModelsRes.RainExceedanceStartDate_Local });
            }

            if (rainExceedance.EndDate_Local != null && ((DateTime)rainExceedance.EndDate_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RainExceedanceEndDate_Local, "1980"), new[] { ModelsRes.RainExceedanceEndDate_Local });
            }

            if (rainExceedance.StartDate < rainExceedance.EndDate_Local)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.RainExceedanceEndDate_Local, ModelsRes.RainExceedanceStartDate), new[] { ModelsRes.RainExceedanceEndDate_Local });
            }

            if (rainExceedance.RainMaximum_mm != null)
            {
                if (rainExceedance.RainMaximum_mm < 0 || rainExceedance.RainMaximum_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), new[] { ModelsRes.RainExceedanceRainMaximum_mm });
                }
            }

            if (rainExceedance.RainExtreme_mm != null)
            {
                if (rainExceedance.RainExtreme_mm < 0 || rainExceedance.RainExtreme_mm > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), new[] { ModelsRes.RainExceedanceRainExtreme_mm });
                }
            }

            //DaysPriorToStart (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (rainExceedance.DaysPriorToStart < 0 || rainExceedance.DaysPriorToStart > 30)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), new[] { ModelsRes.RainExceedanceDaysPriorToStart });
            }

            //RepeatEveryYear (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceProvinceTVItemIDs), new[] { ModelsRes.RainExceedanceProvinceTVItemIDs });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs) && rainExceedance.ProvinceTVItemIDs.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceProvinceTVItemIDs, "250"), new[] { ModelsRes.RainExceedanceProvinceTVItemIDs });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceSubsectorTVItemIDs), new[] { ModelsRes.RainExceedanceSubsectorTVItemIDs });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs) && rainExceedance.SubsectorTVItemIDs.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceSubsectorTVItemIDs, "250"), new[] { ModelsRes.RainExceedanceSubsectorTVItemIDs });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceClimateSiteTVItemIDs), new[] { ModelsRes.RainExceedanceClimateSiteTVItemIDs });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs) && rainExceedance.ClimateSiteTVItemIDs.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceClimateSiteTVItemIDs, "250"), new[] { ModelsRes.RainExceedanceClimateSiteTVItemIDs });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceEmailDistributionListIDs), new[] { ModelsRes.RainExceedanceEmailDistributionListIDs });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs) && rainExceedance.EmailDistributionListIDs.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceEmailDistributionListIDs, "250"), new[] { ModelsRes.RainExceedanceEmailDistributionListIDs });
            }

            if (rainExceedance.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceLastUpdateDate_UTC), new[] { ModelsRes.RainExceedanceLastUpdateDate_UTC });
            }
            else
            {
                if (rainExceedance.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RainExceedanceLastUpdateDate_UTC, "1980"), new[] { ModelsRes.RainExceedanceLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (rainExceedance.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.RainExceedanceLastUpdateContactTVItemID, "1"), new[] { ModelsRes.RainExceedanceLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RainExceedanceLastUpdateContactTVItemID, rainExceedance.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.RainExceedanceLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(RainExceedance rainExceedance)
        {
            rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Create);
            if (rainExceedance.ValidationResults.Count() > 0) return false;

            db.RainExceedances.Add(rainExceedance);

            if (!TryToSave(rainExceedance)) return false;

            return true;
        }
        public bool AddRange(List<RainExceedance> rainExceedanceList)
        {
            foreach (RainExceedance rainExceedance in rainExceedanceList)
            {
                rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Create);
                if (rainExceedance.ValidationResults.Count() > 0) return false;
            }

            db.RainExceedances.AddRange(rainExceedanceList);

            if (!TryToSaveRange(rainExceedanceList)) return false;

            return true;
        }
        public bool Delete(RainExceedance rainExceedance)
        {
            if (!db.RainExceedances.Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
            {
                rainExceedance.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", rainExceedance.RainExceedanceID.ToString())) }.AsEnumerable();
                return false;
            }

            db.RainExceedances.Remove(rainExceedance);

            if (!TryToSave(rainExceedance)) return false;

            return true;
        }
        public bool DeleteRange(List<RainExceedance> rainExceedanceList)
        {
            foreach (RainExceedance rainExceedance in rainExceedanceList)
            {
                if (!db.RainExceedances.Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
                {
                    rainExceedanceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceID", rainExceedance.RainExceedanceID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.RainExceedances.RemoveRange(rainExceedanceList);

            if (!TryToSaveRange(rainExceedanceList)) return false;

            return true;
        }
        public bool Update(RainExceedance rainExceedance)
        {
            rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Update);
            if (rainExceedance.ValidationResults.Count() > 0) return false;

            db.RainExceedances.Update(rainExceedance);

            if (!TryToSave(rainExceedance)) return false;

            return true;
        }
        public bool UpdateRange(List<RainExceedance> rainExceedanceList)
        {
            foreach (RainExceedance rainExceedance in rainExceedanceList)
            {
                rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Update);
                if (rainExceedance.ValidationResults.Count() > 0) return false;
            }
            db.RainExceedances.UpdateRange(rainExceedanceList);

            if (!TryToSaveRange(rainExceedanceList)) return false;

            return true;
        }
        public IQueryable<RainExceedance> GetRead()
        {
            return db.RainExceedances.AsNoTracking();
        }
        public IQueryable<RainExceedance> GetEdit()
        {
            return db.RainExceedances;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(RainExceedance rainExceedance)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                rainExceedance.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<RainExceedance> rainExceedanceList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                rainExceedanceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
