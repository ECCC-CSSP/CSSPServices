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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationTideLocationID), new[] { "TideLocationID" });
                }

                if (!GetRead().Where(c => c.TideLocationID == tideLocation.TideLocationID).Any())
                {
                    tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TideLocation, CSSPModelsRes.TideLocationTideLocationID, tideLocation.TideLocationID.ToString()), new[] { "TideLocationID" });
                }
            }

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

            if (tideLocation.sid < 0 || tideLocation.sid > 100000)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationsid, "0", "100000"), new[] { "sid" });
            }

            if (tideLocation.Lat < -90 || tideLocation.Lat > 90)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLat, "-90", "90"), new[] { "Lat" });
            }

            if (tideLocation.Lng < -180 || tideLocation.Lng > 180)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TideLocationLng, "-180", "180"), new[] { "Lng" });
            }

            if (tideLocation.LastUpdateDate_UTC.Year == 1)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TideLocationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideLocation.LastUpdateDate_UTC.Year < 1980)
                {
                tideLocation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TideLocationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideLocation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tideLocation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TideLocationLastUpdateContactTVItemID, tideLocation.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TideLocationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<TideLocation> tideLocationQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TideLocationID == TideLocationID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return tideLocationQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillTideLocationWeb(tideLocationQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTideLocationReport(tideLocationQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<TideLocation> GetTideLocationList()
        {
            IQueryable<TideLocation> tideLocationQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        tideLocationQuery = EnhanceQueryStatements<TideLocation>(tideLocationQuery) as IQueryable<TideLocation>;

                        return tideLocationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        tideLocationQuery = FillTideLocationWeb(tideLocationQuery);

                        tideLocationQuery = EnhanceQueryStatements<TideLocation>(tideLocationQuery) as IQueryable<TideLocation>;

                        return tideLocationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        tideLocationQuery = FillTideLocationReport(tideLocationQuery);

                        tideLocationQuery = EnhanceQueryStatements<TideLocation>(tideLocationQuery) as IQueryable<TideLocation>;

                        return tideLocationQuery;
                    }
                default:
                    {
                        tideLocationQuery = tideLocationQuery.Where(c => c.TideLocationID == 0);

                        return tideLocationQuery;
                    }
            }
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
            IQueryable<TideLocation> tideLocationQuery = db.TideLocations.AsNoTracking();

            return tideLocationQuery;
        }
        public IQueryable<TideLocation> GetEdit()
        {
            IQueryable<TideLocation> tideLocationQuery = db.TideLocations;

            return tideLocationQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TideLocationFillWeb
        private IQueryable<TideLocation> FillTideLocationWeb(IQueryable<TideLocation> tideLocationQuery)
        {
            tideLocationQuery = (from c in tideLocationQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new TideLocation
                    {
                        TideLocationID = c.TideLocationID,
                        Zone = c.Zone,
                        Name = c.Name,
                        Prov = c.Prov,
                        sid = c.sid,
                        Lat = c.Lat,
                        Lng = c.Lng,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        TideLocationWeb = new TideLocationWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        TideLocationReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return tideLocationQuery;
        }
        #endregion Functions private Generated TideLocationFillWeb

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
