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
        #endregion Properties

        #region Constructors
        public TideDataValueService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TideDataValue tideDataValue = validationContext.ObjectInstance as TideDataValue;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tideDataValue.TideDataValueID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataValueID), new[] { "TideDataValueID" });
                }
            }

            //TideDataValueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TideSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideDataValue.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideDataValueTideSiteTVItemID, tideDataValue.TideSiteTVItemID.ToString()), new[] { "TideSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideDataValueTideSiteTVItemID, "TideSite"), new[] { "TideSiteTVItemID" });
                }
            }

            if (tideDataValue.DateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueDateTime_Local), new[] { "DateTime_Local" });
            }
            else
            {
                if (tideDataValue.DateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TideDataValueDateTime_Local, "1980"), new[] { "DateTime_Local" });
                }
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.TideDataTypeOK(tideDataValue.TideDataType);
            if (tideDataValue.TideDataType == TideDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataType), new[] { "TideDataType" });
            }

            retStr = enums.StorageDataTypeOK(tideDataValue.StorageDataType);
            if (tideDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueStorageDataType), new[] { "StorageDataType" });
            }

            //Depth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideDataValue.Depth_m < 0 || tideDataValue.Depth_m > 10000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "10000"), new[] { "Depth_m" });
            }

            //UVelocity_m_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideDataValue.UVelocity_m_s < 0 || tideDataValue.UVelocity_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "0", "10"), new[] { "UVelocity_m_s" });
            }

            //VVelocity_m_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideDataValue.VVelocity_m_s < 0 || tideDataValue.VVelocity_m_s > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "0", "10"), new[] { "VVelocity_m_s" });
            }

            if (tideDataValue.TideStart != null)
            {
                retStr = enums.TideTextOK(tideDataValue.TideStart);
                if (tideDataValue.TideStart == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideStart), new[] { "TideStart" });
                }
            }

            if (tideDataValue.TideEnd != null)
            {
                retStr = enums.TideTextOK(tideDataValue.TideEnd);
                if (tideDataValue.TideEnd == TideTextEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideEnd), new[] { "TideEnd" });
                }
            }

            if (tideDataValue.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TideDataValueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideDataValueLastUpdateContactTVItemID, tideDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideDataValueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tideDataValue.TideSiteTVText) && tideDataValue.TideSiteTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideSiteTVText, "200"), new[] { "TideSiteTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tideDataValue.LastUpdateContactTVText) && tideDataValue.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(tideDataValue.TideDataTypeText) && tideDataValue.TideDataTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideDataTypeText, "100"), new[] { "TideDataTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tideDataValue.StorageDataTypeText) && tideDataValue.StorageDataTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueStorageDataTypeText, "100"), new[] { "StorageDataTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(tideDataValue.TideStartText) && tideDataValue.TideStartText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideStartText, "100"), new[] { "TideStartText" });
            }

            if (!string.IsNullOrWhiteSpace(tideDataValue.TideEndText) && tideDataValue.TideEndText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideEndText, "100"), new[] { "TideEndText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TideDataValue GetTideDataValueWithTideDataValueID(int TideDataValueID)
        {
            IQueryable<TideDataValue> tideDataValueQuery = (from c in GetRead()
                                                where c.TideDataValueID == TideDataValueID
                                                select c);

            return FillTideDataValue(tideDataValueQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TideDataValue> FillTideDataValue(IQueryable<TideDataValue> tideDataValueQuery)
        {
            List<TideDataValue> TideDataValueList = (from c in tideDataValueQuery
                                         let TideSiteTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.TideSiteTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new TideDataValue
                                         {
                                             TideDataValueID = c.TideDataValueID,
                                             TideSiteTVItemID = c.TideSiteTVItemID,
                                             DateTime_Local = c.DateTime_Local,
                                             Keep = c.Keep,
                                             TideDataType = c.TideDataType,
                                             StorageDataType = c.StorageDataType,
                                             Depth_m = c.Depth_m,
                                             UVelocity_m_s = c.UVelocity_m_s,
                                             VVelocity_m_s = c.VVelocity_m_s,
                                             TideStart = c.TideStart,
                                             TideEnd = c.TideEnd,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             TideSiteTVText = TideSiteTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (TideDataValue tideDataValue in TideDataValueList)
            {
                tideDataValue.TideDataTypeText = enums.GetEnumText_TideDataTypeEnum(tideDataValue.TideDataType);
                tideDataValue.StorageDataTypeText = enums.GetEnumText_StorageDataTypeEnum(tideDataValue.StorageDataType);
                tideDataValue.TideStartText = enums.GetEnumText_TideTextEnum(tideDataValue.TideStart);
                tideDataValue.TideEndText = enums.GetEnumText_TideTextEnum(tideDataValue.TideEnd);
            }

            return TideDataValueList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
