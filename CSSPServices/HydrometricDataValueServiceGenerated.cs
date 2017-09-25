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
    /// <summary>
    ///     <para>bonjour HydrometricDataValue</para>
    /// </summary>
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
            hydrometricDataValue.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (hydrometricDataValue.HydrometricDataValueID == 0)
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueHydrometricDataValueID), new[] { "HydrometricDataValueID" });
                }

                if (!GetRead().Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricDataValue, CSSPModelsRes.HydrometricDataValueHydrometricDataValueID, hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { "HydrometricDataValueID" });
                }
            }

            //HydrometricDataValueID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //HydrometricSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.HydrometricSite, CSSPModelsRes.HydrometricDataValueHydrometricSiteID, hydrometricDataValue.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueDateTime_Local), new[] { "DateTime_Local" });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricDataValueDateTime_Local, "1980"), new[] { "DateTime_Local" });
                }
            }

            //Keep (bool) is required but no testing needed 

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (hydrometricDataValue.StorageDataType == StorageDataTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueStorageDataType), new[] { "StorageDataType" });
            }

            //Flow_m3_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (hydrometricDataValue.Flow_m3_s < 0 || hydrometricDataValue.Flow_m3_s > 10000)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.HydrometricDataValueFlow_m3_s, "0", "10000"), new[] { "Flow_m3_s" });
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.HydrometricDataValueLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.HydrometricDataValueLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.HydrometricDataValueLastUpdateContactTVItemID, hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.HydrometricDataValueLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(hydrometricDataValue.LastUpdateContactTVText) && hydrometricDataValue.LastUpdateContactTVText.Length > 200)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricDataValueLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(hydrometricDataValue.StorageDataTypeText) && hydrometricDataValue.StorageDataTypeText.Length > 100)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.HydrometricDataValueStorageDataTypeText, "100"), new[] { "StorageDataTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public HydrometricDataValue GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<HydrometricDataValue> hydrometricDataValueQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.HydrometricDataValueID == HydrometricDataValueID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return hydrometricDataValueQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityIncludingNotMapped:
                case EntityQueryDetailTypeEnum.EntityForReport:
                    return FillHydrometricDataValue(hydrometricDataValueQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<HydrometricDataValue> GetHydrometricDataValueList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<HydrometricDataValue> hydrometricDataValueQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return hydrometricDataValueQuery;
                case EntityQueryDetailTypeEnum.EntityIncludingNotMapped:
                case EntityQueryDetailTypeEnum.EntityForReport:
                    return FillHydrometricDataValue(hydrometricDataValueQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
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
        public bool Delete(HydrometricDataValue hydrometricDataValue)
        {
            hydrometricDataValue.ValidationResults = Validate(new ValidationContext(hydrometricDataValue), ActionDBTypeEnum.Delete);
            if (hydrometricDataValue.ValidationResults.Count() > 0) return false;

            db.HydrometricDataValues.Remove(hydrometricDataValue);

            if (!TryToSave(hydrometricDataValue)) return false;

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
        private IQueryable<HydrometricDataValue> FillHydrometricDataValue(IQueryable<HydrometricDataValue> hydrometricDataValueQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

            hydrometricDataValueQuery = (from c in hydrometricDataValueQuery
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
                        StorageDataTypeText = (from e in StorageDataTypeEnumList
                                where e.EnumID == (int?)c.StorageDataType
                                select e.EnumText).FirstOrDefault(),
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return hydrometricDataValueQuery;
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
        #endregion Functions private Generated

    }
}
