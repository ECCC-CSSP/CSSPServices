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
    ///     <para>bonjour TideDataValue</para>
    /// </summary>
    public partial class TideDataValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideDataValueService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TideDataValue tideDataValue = validationContext.ObjectInstance as TideDataValue;
            tideDataValue.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideDataValue.TideDataValueID == 0)
                {
                    tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueTideDataValueID"), new[] { "TideDataValueID" });
                }

                if (!(from c in db.TideDataValues select c).Where(c => c.TideDataValueID == tideDataValue.TideDataValueID).Any())
                {
                    tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideDataValue", "TideDataValueTideDataValueID", tideDataValue.TideDataValueID.ToString()), new[] { "TideDataValueID" });
                }
            }

            TVItem TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideDataValue.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideDataValueTideSiteTVItemID", tideDataValue.TideSiteTVItemID.ToString()), new[] { "TideSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemTideSiteTVItemID.TVType))
                {
                    tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TideDataValueTideSiteTVItemID", "TideSite"), new[] { "TideSiteTVItemID" });
                }
            }

            if (tideDataValue.DateTime_Local.Year == 1)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueDateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (tideDataValue.DateTime_Local.Year < 1980)
                {
                tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TideDataValueDateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TideDataTypeEnum), (int?)tideDataValue.TideDataType);
            if (tideDataValue.TideDataType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueTideDataType"), new[] { "TideDataType" });
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)tideDataValue.StorageDataType);
            if (tideDataValue.StorageDataType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueStorageDataType"), new[] { "StorageDataType" });
            }

            if (tideDataValue.Depth_m < 0 || tideDataValue.Depth_m > 10000)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideDataValueDepth_m", "0", "10000"), new[] { "Depth_m" });
            }

            if (tideDataValue.UVelocity_m_s < 0 || tideDataValue.UVelocity_m_s > 10)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideDataValueUVelocity_m_s", "0", "10"), new[] { "UVelocity_m_s" });
            }

            if (tideDataValue.VVelocity_m_s < 0 || tideDataValue.VVelocity_m_s > 10)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideDataValueVVelocity_m_s", "0", "10"), new[] { "VVelocity_m_s" });
            }

            if (tideDataValue.TideStart != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)tideDataValue.TideStart);
                if (tideDataValue.TideStart == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueTideStart"), new[] { "TideStart" });
                }
            }

            if (tideDataValue.TideEnd != null)
            {
                retStr = enums.EnumTypeOK(typeof(TideTextEnum), (int?)tideDataValue.TideEnd);
                if (tideDataValue.TideEnd == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueTideEnd"), new[] { "TideEnd" });
                }
            }

            if (tideDataValue.LastUpdateDate_UTC.Year == 1)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideDataValueLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TideDataValueLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideDataValueLastUpdateContactTVItemID", tideDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tideDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TideDataValueLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tideDataValue.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TideDataValue GetTideDataValueWithTideDataValueID(int TideDataValueID)
        {
            return (from c in db.TideDataValues
                    where c.TideDataValueID == TideDataValueID
                    select c).FirstOrDefault();

        }
        public IQueryable<TideDataValue> GetTideDataValueList()
        {
            IQueryable<TideDataValue> TideDataValueQuery = (from c in db.TideDataValues select c);

            TideDataValueQuery = EnhanceQueryStatements<TideDataValue>(TideDataValueQuery) as IQueryable<TideDataValue>;

            return TideDataValueQuery;
        }
        public TideDataValue_A GetTideDataValue_AWithTideDataValueID(int TideDataValueID)
        {
            return FillTideDataValue_A().Where(c => c.TideDataValueID == TideDataValueID).FirstOrDefault();

        }
        public IQueryable<TideDataValue_A> GetTideDataValue_AList()
        {
            IQueryable<TideDataValue_A> TideDataValue_AQuery = FillTideDataValue_A();

            TideDataValue_AQuery = EnhanceQueryStatements<TideDataValue_A>(TideDataValue_AQuery) as IQueryable<TideDataValue_A>;

            return TideDataValue_AQuery;
        }
        public TideDataValue_B GetTideDataValue_BWithTideDataValueID(int TideDataValueID)
        {
            return FillTideDataValue_B().Where(c => c.TideDataValueID == TideDataValueID).FirstOrDefault();

        }
        public IQueryable<TideDataValue_B> GetTideDataValue_BList()
        {
            IQueryable<TideDataValue_B> TideDataValue_BQuery = FillTideDataValue_B();

            TideDataValue_BQuery = EnhanceQueryStatements<TideDataValue_B>(TideDataValue_BQuery) as IQueryable<TideDataValue_B>;

            return TideDataValue_BQuery;
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
        public bool Delete(TideDataValue tideDataValue)
        {
            tideDataValue.ValidationResults = Validate(new ValidationContext(tideDataValue), ActionDBTypeEnum.Delete);
            if (tideDataValue.ValidationResults.Count() > 0) return false;

            db.TideDataValues.Remove(tideDataValue);

            if (!TryToSave(tideDataValue)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
