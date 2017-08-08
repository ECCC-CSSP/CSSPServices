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
        #endregion Properties

        #region Constructors
        public HydrometricDataValueService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueHydrometricDataValueID), new[] { "HydrometricDataValueID" });
                }
            }

            //HydrometricDataValueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HydrometricSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.HydrometricSite, ModelsRes.HydrometricDataValueHydrometricSiteID, hydrometricDataValue.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueDateTime_Local), new[] { "DateTime_Local" });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricDataValueDateTime_Local, "1980"), new[] { "DateTime_Local" });
                }
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.StorageDataTypeOK(hydrometricDataValue.StorageDataType);
            if (hydrometricDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueStorageDataType), new[] { "StorageDataType" });
            }

            //Flow_m3_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (hydrometricDataValue.Flow_m3_s < 0 || hydrometricDataValue.Flow_m3_s > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), new[] { "Flow_m3_s" });
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.HydrometricDataValueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.HydrometricDataValueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricDataValue.LastUpdateContactTVText) && hydrometricDataValue.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricDataValueLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricDataValue.StorageDataTypeText) && hydrometricDataValue.StorageDataTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.HydrometricDataValueStorageDataTypeText, "100"), new[] { "StorageDataTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public HydrometricDataValue GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            IQueryable<HydrometricDataValue> hydrometricDataValueQuery = (from c in GetRead()
                                                where c.HydrometricDataValueID == HydrometricDataValueID
                                                select c);

            return FillHydrometricDataValue(hydrometricDataValueQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<HydrometricDataValue> FillHydrometricDataValue(IQueryable<HydrometricDataValue> hydrometricDataValueQuery)
        {
            List<HydrometricDataValue> HydrometricDataValueList = (from c in hydrometricDataValueQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new HydrometricDataValue
                                         {
                                             HydrometricDataValueID = c.HydrometricDataValueID,
                                             HydrometricSiteID = c.HydrometricSiteID,
                                             DateTime_Local = c.DateTime_Local,
                                             Keep = c.Keep,
                                             StorageDataType = c.StorageDataType,
                                             Flow_m3_s = c.Flow_m3_s,
                                             HourlyValues = c.HourlyValues,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (HydrometricDataValue hydrometricDataValue in HydrometricDataValueList)
            {
                hydrometricDataValue.StorageDataTypeText = enums.GetEnumText_StorageDataTypeEnum(hydrometricDataValue.StorageDataType);
            }

            return HydrometricDataValueList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
