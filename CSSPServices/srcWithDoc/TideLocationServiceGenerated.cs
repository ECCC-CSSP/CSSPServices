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
        public TideLocationService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideLocationTideLocationID"), new[] { "TideLocationID" });
                }

                if (!(from c in db.TideLocations select c).Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                {
                    tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TideLocation", "TideLocationTideLocationID", tideLocation.TideLocationID.ToString()), new[] { "TideLocationID" });
                }
            }

            if (tideLocation.Zone < 0 || tideLocation.Zone > 10000)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationZone", "0", "10000"), new[] { "Zone" });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Name))
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideLocationName"), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Name) && tideLocation.Name.Length > 100)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TideLocationName", "100"), new[] { "Name" });
            }

            if (string.IsNullOrWhiteSpace(tideLocation.Prov))
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideLocationProv"), new[] { "Prov" });
            }

            if (!string.IsNullOrWhiteSpace(tideLocation.Prov) && tideLocation.Prov.Length > 100)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TideLocationProv", "100"), new[] { "Prov" });
            }

            if (tideLocation.sid < 0 || tideLocation.sid > 100000)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationsid", "0", "100000"), new[] { "sid" });
            }

            if (tideLocation.Lat < -90 || tideLocation.Lat > 90)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationLat", "-90", "90"), new[] { "Lat" });
            }

            if (tideLocation.Lng < -180 || tideLocation.Lng > 180)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TideLocationLng", "-180", "180"), new[] { "Lng" });
            }

            if (tideLocation.LastUpdateDate_UTC.Year == 1)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TideLocationLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideLocation.LastUpdateDate_UTC.Year < 1980)
                {
                tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TideLocationLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TideLocationLastUpdateContactTVItemID", tideLocation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TideLocationLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.TideLocations
                    where c.TideLocationID == TideLocationID
                    select c).FirstOrDefault();

        }
        public IQueryable<TideLocation> GetTideLocationList()
        {
            IQueryable<TideLocation> TideLocationQuery = (from c in db.TideLocations select c);

            TideLocationQuery = EnhanceQueryStatements<TideLocation>(TideLocationQuery) as IQueryable<TideLocation>;

            return TideLocationQuery;
        }
        public TideLocation_A GetTideLocation_AWithTideLocationID(int TideLocationID)
        {
            return FillTideLocation_A().Where(c => c.TideLocationID == TideLocationID).FirstOrDefault();

        }
        public IQueryable<TideLocation_A> GetTideLocation_AList()
        {
            IQueryable<TideLocation_A> TideLocation_AQuery = FillTideLocation_A();

            TideLocation_AQuery = EnhanceQueryStatements<TideLocation_A>(TideLocation_AQuery) as IQueryable<TideLocation_A>;

            return TideLocation_AQuery;
        }
        public TideLocation_B GetTideLocation_BWithTideLocationID(int TideLocationID)
        {
            return FillTideLocation_B().Where(c => c.TideLocationID == TideLocationID).FirstOrDefault();

        }
        public IQueryable<TideLocation_B> GetTideLocation_BList()
        {
            IQueryable<TideLocation_B> TideLocation_BQuery = FillTideLocation_B();

            TideLocation_BQuery = EnhanceQueryStatements<TideLocation_B>(TideLocation_BQuery) as IQueryable<TideLocation_B>;

            return TideLocation_BQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
