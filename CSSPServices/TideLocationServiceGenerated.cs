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
    public partial class TideLocationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            TideLocation tideLocation = validationContext.ObjectInstance as TideLocation;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (string.IsNullOrWhiteSpace(tideLocation.TideLocationID))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationTideLocationID), new[] { ModelsRes.TideLocationTideLocationID });
                }
            }

            //Zone (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(tideLocation.Name))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationName), new[] { ModelsRes.TideLocationName });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Prov))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideLocationProv), new[] { ModelsRes.TideLocationProv });
            }

            //sid (int) is required but no testing needed as it is automatically set to 0

            //Lat (float) is required but no testing needed as it is automatically set to 0.0f

            //Lng (float) is required but no testing needed as it is automatically set to 0.0f

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tideLocation.Zone < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TideLocationZone, "1"), new[] { ModelsRes.TideLocationZone });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Name) && tideLocation.Name.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationName, "100"), new[] { ModelsRes.TideLocationName });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Prov) && tideLocation.Prov.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideLocationProv, "10"), new[] { ModelsRes.TideLocationProv });
            }

            if (tideLocation.sid < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TideLocationsid, "1"), new[] { ModelsRes.TideLocationsid });
            }

            if (tideLocation.Lat < -90 || tideLocation.Lat > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLat, "-90", "90"), new[] { ModelsRes.TideLocationLat });
            }

            if (tideLocation.Lng < -180 || tideLocation.Lng > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideLocationLng, "-180", "180"), new[] { ModelsRes.TideLocationLng });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(TideLocation tideLocation)
        {
            tideLocation.ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Create);
            if (tideLocation.ValidationResults.Count() > 0) return false;

            db.TideLocations.Add(tideLocation);

            if (!TryToSave(tideLocation)) return false;

            return true;
        }
        public bool AddRange(List<TideLocation> tideLocationList)
        {
            foreach (TideLocation tideLocation in tideLocationList)
            {
                tideLocation.ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Create);
                if (tideLocation.ValidationResults.Count() > 0) return false;
            }

            db.TideLocations.AddRange(tideLocationList);

            if (!TryToSaveRange(tideLocationList)) return false;

            return true;
        }
        public bool Delete(TideLocation tideLocation)
        {
            if (!db.TideLocations.Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
            {
                tideLocation.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", tideLocation.TideLocationID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TideLocations.Remove(tideLocation);

            if (!TryToSave(tideLocation)) return false;

            return true;
        }
        public bool DeleteRange(List<TideLocation> tideLocationList)
        {
            foreach (TideLocation tideLocation in tideLocationList)
            {
                if (!db.TideLocations.Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                {
                    tideLocationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationID", tideLocation.TideLocationID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TideLocations.RemoveRange(tideLocationList);

            if (!TryToSaveRange(tideLocationList)) return false;

            return true;
        }
        public bool Update(TideLocation tideLocation)
        {
            tideLocation.ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Update);
            if (tideLocation.ValidationResults.Count() > 0) return false;

            db.TideLocations.Update(tideLocation);

            if (!TryToSave(tideLocation)) return false;

            return true;
        }
        public bool UpdateRange(List<TideLocation> tideLocationList)
        {
            foreach (TideLocation tideLocation in tideLocationList)
            {
                tideLocation.ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Update);
                if (tideLocation.ValidationResults.Count() > 0) return false;
            }
            db.TideLocations.UpdateRange(tideLocationList);

            if (!TryToSaveRange(tideLocationList)) return false;

            return true;
        }
        public IQueryable<TideLocation> GetRead()
        {
            return db.TideLocations.AsNoTracking();
        }
        public IQueryable<TideLocation> GetEdit()
        {
            return db.TideLocations;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TideLocation tideLocation)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideLocation.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TideLocation> tideLocationList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideLocationList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
