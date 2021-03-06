/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        public HydrometricDataValueService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "HydrometricDataValueID"), new[] { "HydrometricDataValueID" });
                }

                if (!(from c in db.HydrometricDataValues select c).Where(c => c.HydrometricDataValueID == hydrometricDataValue.HydrometricDataValueID).Any())
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricDataValue", "HydrometricDataValueID", hydrometricDataValue.HydrometricDataValueID.ToString()), new[] { "HydrometricDataValueID" });
                }
            }

            HydrometricSite HydrometricSiteHydrometricSiteID = (from c in db.HydrometricSites where c.HydrometricSiteID == hydrometricDataValue.HydrometricSiteID select c).FirstOrDefault();

            if (HydrometricSiteHydrometricSiteID == null)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "HydrometricSite", "HydrometricSiteID", hydrometricDataValue.HydrometricSiteID.ToString()), new[] { "HydrometricSiteID" });
            }

            if (hydrometricDataValue.DateTime_Local.Year == 1)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DateTime_Local"), new[] { "DateTime_Local" });
            }
            else
            {
                if (hydrometricDataValue.DateTime_Local.Year < 1980)
                {
                hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "DateTime_Local", "1980"), new[] { "DateTime_Local" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(StorageDataTypeEnum), (int?)hydrometricDataValue.StorageDataType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StorageDataType"), new[] { "StorageDataType" });
            }

            if (hydrometricDataValue.Discharge_m3_s != null)
            {
                if (hydrometricDataValue.Discharge_m3_s < 0 || hydrometricDataValue.Discharge_m3_s > 100000)
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Discharge_m3_s", "0", "100000"), new[] { "Discharge_m3_s" });
                }
            }

            if (hydrometricDataValue.DischargeEntered_m3_s != null)
            {
                if (hydrometricDataValue.DischargeEntered_m3_s < 0 || hydrometricDataValue.DischargeEntered_m3_s > 100000)
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DischargeEntered_m3_s", "0", "100000"), new[] { "DischargeEntered_m3_s" });
                }
            }

            if (hydrometricDataValue.Level_m != null)
            {
                if (hydrometricDataValue.Level_m < 0 || hydrometricDataValue.Level_m > 10000)
                {
                    hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Level_m", "0", "10000"), new[] { "Level_m" });
                }
            }

            //HourlyValues has no StringLength Attribute

            if (hydrometricDataValue.LastUpdateDate_UTC.Year == 1)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (hydrometricDataValue.LastUpdateDate_UTC.Year < 1980)
                {
                hydrometricDataValue.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == hydrometricDataValue.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                hydrometricDataValue.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", hydrometricDataValue.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
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
