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
    ///     <para>bonjour TideLocation</para>
    /// </summary>
    public partial class TideLocationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideLocationService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TideLocation tideLocation = validationContext.ObjectInstance as TideLocation;
            tideLocation.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tideLocation.TideLocationID == 0)
                {
                    tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationTideLocationID), new[] { "TideLocationID" });
                }

                if (!GetRead().Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                {
                    tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideLocation, CSSPModelsRes.TideLocationTideLocationID, tideLocation.TideLocationID.ToString()), new[] { "TideLocationID" });
                }
            }

            //TideLocationID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Zone (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideLocation.Zone < 0 || tideLocation.Zone > 10000)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationZone, "0", "10000"), new[] { "Zone" });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Name))
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Name) && tideLocation.Name.Length > 100)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideLocationName, "100"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Prov))
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationProv), new[] { "Prov" });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Prov) && tideLocation.Prov.Length > 100)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TideLocationProv, "100"), new[] { "Prov" });
            }

            //sid (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideLocation.sid < 0 || tideLocation.sid > 100000)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationsid, "0", "100000"), new[] { "sid" });
            }

            //Lat (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideLocation.Lat < -90 || tideLocation.Lat > 90)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLat, "-90", "90"), new[] { "Lat" });
            }

            //Lng (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideLocation.Lng < -180 || tideLocation.Lng > 180)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLng, "-180", "180"), new[] { "Lng" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public TideLocation GetTideLocationWithTideLocationID(int TideLocationID)
        {
            IQueryable<TideLocation> tideLocationQuery = (from c in GetRead()
                                                where c.TideLocationID == TideLocationID
                                                select c);

            return FillTideLocation(tideLocationQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(TideLocation tideLocation)
        {
            tideLocation.ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Create);
            if (tideLocation.ValidationResults.Count() > 0) return false;

            db.TideLocations.Add(tideLocation);

            if (!TryToSave(tideLocation)) return false;

            return true;
        }
        public bool Delete(TideLocation tideLocation)
        {
            tideLocation.ValidationResults = Validate(new ValidationContext(tideLocation), ActionDBTypeEnum.Delete);
            if (tideLocation.ValidationResults.Count() > 0) return false;

            db.TideLocations.Remove(tideLocation);

            if (!TryToSave(tideLocation)) return false;

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
        public IQueryable<TideLocation> GetRead()
        {
            return db.TideLocations.AsNoTracking();
        }
        public IQueryable<TideLocation> GetEdit()
        {
            return db.TideLocations;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<TideLocation> FillTideLocation(IQueryable<TideLocation> tideLocationQuery)
        {
            List<TideLocation> TideLocationList = (from c in tideLocationQuery
                                         select new TideLocation
                                         {
                                             TideLocationID = c.TideLocationID,
                                             Zone = c.Zone,
                                             Name = c.Name,
                                             Prov = c.Prov,
                                             sid = c.sid,
                                             Lat = c.Lat,
                                             Lng = c.Lng,
                                             ValidationResults = null,
                                         }).ToList();

            return TideLocationList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
