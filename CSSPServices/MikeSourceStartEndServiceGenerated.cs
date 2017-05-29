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
    public partial class MikeSourceStartEndService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MikeSourceStartEnd mikeSourceStartEnd = validationContext.ObjectInstance as MikeSourceStartEnd;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mikeSourceStartEnd.MikeSourceStartEndID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndMikeSourceStartEndID), new[] { ModelsRes.MikeSourceStartEndMikeSourceStartEndID });
                }
            }

            //MikeSourceID (int) is required but no testing needed as it is automatically set to 0

            if (mikeSourceStartEnd.StartDateAndTime_Local == null || mikeSourceStartEnd.StartDateAndTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndStartDateAndTime_Local), new[] { ModelsRes.MikeSourceStartEndStartDateAndTime_Local });
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local == null || mikeSourceStartEnd.EndDateAndTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndEndDateAndTime_Local), new[] { ModelsRes.MikeSourceStartEndEndDateAndTime_Local });
            }

            //SourceFlowStart_m3_day (float) is required but no testing needed as it is automatically set to 0.0f

            //SourceFlowEnd_m3_day (float) is required but no testing needed as it is automatically set to 0.0f

            //SourcePollutionStart_MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            //SourcePollutionEnd_MPN_100ml (int) is required but no testing needed as it is automatically set to 0

            //SourceTemperatureStart_C (float) is required but no testing needed as it is automatically set to 0.0f

            //SourceTemperatureEnd_C (float) is required but no testing needed as it is automatically set to 0.0f

            //SourceSalinityStart_PSU (float) is required but no testing needed as it is automatically set to 0.0f

            //SourceSalinityEnd_PSU (float) is required but no testing needed as it is automatically set to 0.0f

            if (mikeSourceStartEnd.LastUpdateDate_UTC == null || mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndLastUpdateDate_UTC), new[] { ModelsRes.MikeSourceStartEndLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mikeSourceStartEnd.MikeSourceID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceStartEndMikeSourceID, "1"), new[] { ModelsRes.MikeSourceStartEndMikeSourceID });
            }

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), new[] { ModelsRes.MikeSourceStartEndSourceFlowStart_m3_day });
            }

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), new[] { ModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day });
            }

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 20000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "20000000"), new[] { ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml });
            }

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 20000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "20000000"), new[] { ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml });
            }

            if (mikeSourceStartEnd.SourceTemperatureStart_C < 0 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "0", "40"), new[] { ModelsRes.MikeSourceStartEndSourceTemperatureStart_C });
            }

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < 0 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "0", "40"), new[] { ModelsRes.MikeSourceStartEndSourceTemperatureEnd_C });
            }

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), new[] { ModelsRes.MikeSourceStartEndSourceSalinityStart_PSU });
            }

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), new[] { ModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU });
            }

            if (mikeSourceStartEnd.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MikeSourceStartEndLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Create);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;

            db.MikeSourceStartEnds.Add(mikeSourceStartEnd);

            if (!TryToSave(mikeSourceStartEnd)) return false;

            return true;
        }
        public bool AddRange(List<MikeSourceStartEnd> mikeSourceStartEndList)
        {
            foreach (MikeSourceStartEnd mikeSourceStartEnd in mikeSourceStartEndList)
            {
                mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Create);
                if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;
            }

            db.MikeSourceStartEnds.AddRange(mikeSourceStartEndList);

            if (!TryToSaveRange(mikeSourceStartEndList)) return false;

            return true;
        }
        public bool Delete(MikeSourceStartEnd mikeSourceStartEnd)
        {
            if (!db.MikeSourceStartEnds.Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
            {
                mikeSourceStartEnd.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MikeSourceStartEnds.Remove(mikeSourceStartEnd);

            if (!TryToSave(mikeSourceStartEnd)) return false;

            return true;
        }
        public bool DeleteRange(List<MikeSourceStartEnd> mikeSourceStartEndList)
        {
            foreach (MikeSourceStartEnd mikeSourceStartEnd in mikeSourceStartEndList)
            {
                if (!db.MikeSourceStartEnds.Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                {
                    mikeSourceStartEndList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MikeSourceStartEnds.RemoveRange(mikeSourceStartEndList);

            if (!TryToSaveRange(mikeSourceStartEndList)) return false;

            return true;
        }
        public bool Update(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Update);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;

            db.MikeSourceStartEnds.Update(mikeSourceStartEnd);

            if (!TryToSave(mikeSourceStartEnd)) return false;

            return true;
        }
        public bool UpdateRange(List<MikeSourceStartEnd> mikeSourceStartEndList)
        {
            foreach (MikeSourceStartEnd mikeSourceStartEnd in mikeSourceStartEndList)
            {
                mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Update);
                if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;
            }
            db.MikeSourceStartEnds.UpdateRange(mikeSourceStartEndList);

            if (!TryToSaveRange(mikeSourceStartEndList)) return false;

            return true;
        }
        public IQueryable<MikeSourceStartEnd> GetRead()
        {
            return db.MikeSourceStartEnds.AsNoTracking();
        }
        public IQueryable<MikeSourceStartEnd> GetEdit()
        {
            return db.MikeSourceStartEnds;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MikeSourceStartEnd mikeSourceStartEnd)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSourceStartEnd.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MikeSourceStartEnd> mikeSourceStartEndList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSourceStartEndList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
