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
        public HydrometricDataValueService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueHydrometricDataValueID"), new[] { "HydrometricDataValueID" });
                }

                if (!(from c in db.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueHydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { "HydrometricDataValueID" });
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricDataValueHydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueDateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricDataValueDateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (hydrometricDataValue.StorageDataType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueStorageDataType"), new[] { "StorageDataType" });
            }

            if (hydrometricDataValue.Flow_m3_s < 0 || hydrometricDataValue.Flow_m3_s > 10000)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HydrometricDataValueFlow_m3_s", "0", "10000"), new[] { "Flow_m3_s" });
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "HydrometricDataValueLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "HydrometricDataValueLastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "HydrometricDataValueLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public HydrometricDataValue GetHydrometricDataValueWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            return (from c in db.HydrometricDataValues
                    where c.HydrometricDataValueID == HydrometricDataValueID
                    select c).FirstOrDefault();

        }
        public IQueryable<HydrometricDataValue> GetHydrometricDataValueList()
        {
            IQueryable<HydrometricDataValue> HydrometricDataValueQuery = (from c in db.HydrometricDataValues select c);

            HydrometricDataValueQuery = EnhanceQueryStatements<HydrometricDataValue>(HydrometricDataValueQuery) as IQueryable<HydrometricDataValue>;

            return HydrometricDataValueQuery;
        }
        public HydrometricDataValueWeb GetHydrometricDataValueWebWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            return FillHydrometricDataValueWeb().Where(c => c.HydrometricDataValueID == HydrometricDataValueID).FirstOrDefault();

        }
        public IQueryable<HydrometricDataValueWeb> GetHydrometricDataValueWebList()
        {
            IQueryable<HydrometricDataValueWeb> HydrometricDataValueWebQuery = FillHydrometricDataValueWeb();

            HydrometricDataValueWebQuery = EnhanceQueryStatements<HydrometricDataValueWeb>(HydrometricDataValueWebQuery) as IQueryable<HydrometricDataValueWeb>;

            return HydrometricDataValueWebQuery;
        }
        public HydrometricDataValueReport GetHydrometricDataValueReportWithHydrometricDataValueID(int HydrometricDataValueID)
        {
            return FillHydrometricDataValueReport().Where(c => c.HydrometricDataValueID == HydrometricDataValueID).FirstOrDefault();

        }
        public IQueryable<HydrometricDataValueReport> GetHydrometricDataValueReportList()
        {
            IQueryable<HydrometricDataValueReport> HydrometricDataValueReportQuery = FillHydrometricDataValueReport();

            HydrometricDataValueReportQuery = EnhanceQueryStatements<HydrometricDataValueReport>(HydrometricDataValueReportQuery) as IQueryable<HydrometricDataValueReport>;

            return HydrometricDataValueReportQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated HydrometricDataValueFillWeb
        private IQueryable<HydrometricDataValueWeb> FillHydrometricDataValueWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

             IQueryable<HydrometricDataValueWeb> HydrometricDataValueWebQuery = (from c in db.HydrometricDataValues
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new HydrometricDataValueWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        StorageDataTypeText = (from e in StorageDataTypeEnumList
                                where e.EnumID == (int?)c.StorageDataType
                                select e.EnumText).FirstOrDefault(),
                        HydrometricDataValueID = c.HydrometricDataValueID,
                        HydrometricSiteID = c.HydrometricSiteID,
                        DateTime_Local = c.DateTime_Local,
                        Keep = c.Keep,
                        StorageDataType = c.StorageDataType,
                        Flow_m3_s = c.Flow_m3_s,
                        HourlyValues = c.HourlyValues,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return HydrometricDataValueWebQuery;
        }
        #endregion Functions private Generated HydrometricDataValueFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
