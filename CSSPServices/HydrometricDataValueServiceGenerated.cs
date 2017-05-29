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
    public partial class HydrometricDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public HydrometricDataValueService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
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
            HydrometricDataValue hydrometricDataValue = validationContext.ObjectInstance as HydrometricDataValue;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (hydrometricDataValue.HydrometricDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHydrometricDataValueID), new[] { ModelsRes.HydrometricDataValueHydrometricDataValueID });
                }
            }

            //HydrometricSiteID (int) is required but no testing needed as it is automatically set to 0

            if (hydrometricDataValue.DateTime_Local == null || hydrometricDataValue.DateTime_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueDateTime_Local), new[] { ModelsRes.HydrometricDataValueDateTime_Local });
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.StorageDataTypeOK(hydrometricDataValue.StorageDataType);
            if (hydrometricDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueStorageDataType), new[] { ModelsRes.HydrometricDataValueStorageDataType });
            }

            //Flow_m3_s (float) is required but no testing needed as it is automatically set to 0.0f

            if (hydrometricDataValue.LastUpdateDate_UTC == null || hydrometricDataValue.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueLastUpdateDate_UTC), new[] { ModelsRes.HydrometricDataValueLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (hydrometricDataValue.HydrometricSiteID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueHydrometricSiteID, "1"), new[] { ModelsRes.HydrometricDataValueHydrometricSiteID });
            }

            if (hydrometricDataValue.Flow_m3_s < 0 || hydrometricDataValue.Flow_m3_s > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "1000000"), new[] { ModelsRes.HydrometricDataValueFlow_m3_s });
            }

            // HourlyValues has no validation

            if (hydrometricDataValue.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "1"), new[] { ModelsRes.HydrometricDataValueLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(HydrometricDataValue hydrometricDataValue)
        {
            hydrometricDataValue.ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Create);
            if (hydrometricDataValue.ValidationResults.Count() > 0) return false;

            db.HydrometricDataValues.Add(hydrometricDataValue);

            if (!TryToSave(hydrometricDataValue)) return false;

            return true;
        }
        public bool AddRange(List<HydrometricDataValue> hydrometricDataValueList)
        {
            foreach (HydrometricDataValue hydrometricDataValue in hydrometricDataValueList)
            {
                hydrometricDataValue.ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Create);
                if (hydrometricDataValue.ValidationResults.Count() > 0) return false;
            }

            db.HydrometricDataValues.AddRange(hydrometricDataValueList);

            if (!TryToSaveRange(hydrometricDataValueList)) return false;

            return true;
        }
        public bool Delete(HydrometricDataValue hydrometricDataValue)
        {
            if (!db.HydrometricDataValues.Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
            {
                hydrometricDataValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString())) }.AsEnumerable();
                return false;
            }

            db.HydrometricDataValues.Remove(hydrometricDataValue);

            if (!TryToSave(hydrometricDataValue)) return false;

            return true;
        }
        public bool DeleteRange(List<HydrometricDataValue> hydrometricDataValueList)
        {
            foreach (HydrometricDataValue hydrometricDataValue in hydrometricDataValueList)
            {
                if (!db.HydrometricDataValues.Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                {
                    hydrometricDataValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.HydrometricDataValues.RemoveRange(hydrometricDataValueList);

            if (!TryToSaveRange(hydrometricDataValueList)) return false;

            return true;
        }
        public bool Update(HydrometricDataValue hydrometricDataValue)
        {
            hydrometricDataValue.ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Update);
            if (hydrometricDataValue.ValidationResults.Count() > 0) return false;

            db.HydrometricDataValues.Update(hydrometricDataValue);

            if (!TryToSave(hydrometricDataValue)) return false;

            return true;
        }
        public bool UpdateRange(List<HydrometricDataValue> hydrometricDataValueList)
        {
            foreach (HydrometricDataValue hydrometricDataValue in hydrometricDataValueList)
            {
                hydrometricDataValue.ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Update);
                if (hydrometricDataValue.ValidationResults.Count() > 0) return false;
            }
            db.HydrometricDataValues.UpdateRange(hydrometricDataValueList);

            if (!TryToSaveRange(hydrometricDataValueList)) return false;

            return true;
        }
        public IQueryable<HydrometricDataValue> GetRead()
        {
            return db.HydrometricDataValues.AsNoTracking();
        }
        public IQueryable<HydrometricDataValue> GetEdit()
        {
            return db.HydrometricDataValues;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(HydrometricDataValue hydrometricDataValue)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                hydrometricDataValue.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<HydrometricDataValue> hydrometricDataValueList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                hydrometricDataValueList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
