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
    public partial class TideDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
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
            TideDataValue tideDataValue = validationContext.ObjectInstance as TideDataValue;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tideDataValue.TideDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataValueID), new[] { ModelsRes.TideDataValueTideDataValueID });
                }
            }

            //TideSiteTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (tideDataValue.DateTime_Local == null || tideDataValue.DateTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueDateTime_Local), new[] { ModelsRes.TideDataValueDateTime_Local });
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.TideDataTypeOK(tideDataValue.TideDataType);
            if (tideDataValue.TideDataType == TideDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataType), new[] { ModelsRes.TideDataValueTideDataType });
            }

            retStr = enums.StorageDataTypeOK(tideDataValue.StorageDataType);
            if (tideDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueStorageDataType), new[] { ModelsRes.TideDataValueStorageDataType });
            }

            //Depth_m (float) is required but no testing needed as it is automatically set to 0.0f

            //UVelocity_m_s (float) is required but no testing needed as it is automatically set to 0.0f

            //VVelocity_m_s (float) is required but no testing needed as it is automatically set to 0.0f

            if (tideDataValue.LastUpdateDate_UTC == null || tideDataValue.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueLastUpdateDate_UTC), new[] { ModelsRes.TideDataValueLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tideDataValue.TideSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TideDataValueTideSiteTVItemID, "1"), new[] { ModelsRes.TideDataValueTideSiteTVItemID });
            }

            if (tideDataValue.Depth_m < 0 || tideDataValue.Depth_m > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "1000"), new[] { ModelsRes.TideDataValueDepth_m });
            }

            if (tideDataValue.UVelocity_m_s < -10 || tideDataValue.UVelocity_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "-10", "10"), new[] { ModelsRes.TideDataValueUVelocity_m_s });
            }

            if (tideDataValue.VVelocity_m_s < -10 || tideDataValue.VVelocity_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "-10", "10"), new[] { ModelsRes.TideDataValueVVelocity_m_s });
            }

            if (tideDataValue.TideStart != null)
            {
                retStr = enums.TideTextOK(tideDataValue.TideStart);
                if (tideDataValue.TideStart == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.TideDataValueTideStart });
                }
            }

            if (tideDataValue.TideEnd != null)
            {
                retStr = enums.TideTextOK(tideDataValue.TideEnd);
                if (tideDataValue.TideEnd == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.TideDataValueTideEnd });
                }
            }

            if (tideDataValue.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TideDataValueLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TideDataValueLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(TideDataValue tideDataValue)
        {
            tideDataValue.ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Create);
            if (tideDataValue.ValidationResults.Count() > 0) return false;

            db.TideDataValues.Add(tideDataValue);

            if (!TryToSave(tideDataValue)) return false;

            return true;
        }
        public bool AddRange(List<TideDataValue> tideDataValueList)
        {
            foreach (TideDataValue tideDataValue in tideDataValueList)
            {
                tideDataValue.ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Create);
                if (tideDataValue.ValidationResults.Count() > 0) return false;
            }

            db.TideDataValues.AddRange(tideDataValueList);

            if (!TryToSaveRange(tideDataValueList)) return false;

            return true;
        }
        public bool Delete(TideDataValue tideDataValue)
        {
            if (!db.TideDataValues.Where(c => c.TideDataValueID == tideDataValue.TideDataValueID).Any())
            {
                tideDataValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", tideDataValue.TideDataValueID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TideDataValues.Remove(tideDataValue);

            if (!TryToSave(tideDataValue)) return false;

            return true;
        }
        public bool DeleteRange(List<TideDataValue> tideDataValueList)
        {
            foreach (TideDataValue tideDataValue in tideDataValueList)
            {
                if (!db.TideDataValues.Where(c => c.TideDataValueID == tideDataValue.TideDataValueID).Any())
                {
                    tideDataValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueID", tideDataValue.TideDataValueID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TideDataValues.RemoveRange(tideDataValueList);

            if (!TryToSaveRange(tideDataValueList)) return false;

            return true;
        }
        public bool Update(TideDataValue tideDataValue)
        {
            tideDataValue.ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Update);
            if (tideDataValue.ValidationResults.Count() > 0) return false;

            db.TideDataValues.Update(tideDataValue);

            if (!TryToSave(tideDataValue)) return false;

            return true;
        }
        public bool UpdateRange(List<TideDataValue> tideDataValueList)
        {
            foreach (TideDataValue tideDataValue in tideDataValueList)
            {
                tideDataValue.ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Update);
                if (tideDataValue.ValidationResults.Count() > 0) return false;
            }
            db.TideDataValues.UpdateRange(tideDataValueList);

            if (!TryToSaveRange(tideDataValueList)) return false;

            return true;
        }
        public IQueryable<TideDataValue> GetRead()
        {
            return db.TideDataValues.AsNoTracking();
        }
        public IQueryable<TideDataValue> GetEdit()
        {
            return db.TideDataValues;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TideDataValue tideDataValue)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideDataValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TideDataValue> tideDataValueList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideDataValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
