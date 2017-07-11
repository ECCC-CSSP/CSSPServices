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
        public HydrometricDataValueService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            HydrometricDataValue hydrometricDataValue = validationContext.ObjectInstance as HydrometricDataValue;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (hydrometricDataValue.HydrometricDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHydrometricDataValueID), new[] { ModelsRes.HydrometricDataValueHydrometricDataValueID });
                }
            }

            //HydrometricDataValueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HydrometricSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (hydrometricDataValue.HydrometricSiteID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueHydrometricSiteID, "1"), new[] { ModelsRes.HydrometricDataValueHydrometricSiteID });
            }

            if (!((from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.HydrometricDataValueHydrometricSiteID, hydrometricDataValue.HydrometricSiteID.ToString()), new[] { ModelsRes.HydrometricDataValueHydrometricSiteID });
            }

            if (hydrometricDataValue.DateTime_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueDateTime_Local), new[] { ModelsRes.HydrometricDataValueDateTime_Local });
            }

            if (hydrometricDataValue.DateTime_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricDataValueDateTime_Local, "1980"), new[] { ModelsRes.HydrometricDataValueDateTime_Local });
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.StorageDataTypeOK(hydrometricDataValue.StorageDataType);
            if (hydrometricDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueStorageDataType), new[] { ModelsRes.HydrometricDataValueStorageDataType });
            }

            //Flow_m3_s (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (hydrometricDataValue.Flow_m3_s < 0 || hydrometricDataValue.Flow_m3_s > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), new[] { ModelsRes.HydrometricDataValueFlow_m3_s });
            }

            if (string.IsNullOrWhiteSpace(hydrometricDataValue.HourlyValues))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHourlyValues), new[] { ModelsRes.HydrometricDataValueHourlyValues });
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueLastUpdateDate_UTC), new[] { ModelsRes.HydrometricDataValueLastUpdateDate_UTC });
            }

            if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricDataValueLastUpdateDate_UTC, "1980"), new[] { ModelsRes.HydrometricDataValueLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (hydrometricDataValue.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "1"), new[] { ModelsRes.HydrometricDataValueLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.HydrometricDataValueLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
