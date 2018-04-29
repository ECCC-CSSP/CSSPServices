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
    ///     <para>bonjour PolSourceObservation</para>
    /// </summary>
    public partial class PolSourceObservationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceObservationService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceObservation polSourceObservation = validationContext.ObjectInstance as PolSourceObservation;
            polSourceObservation.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceObservation.PolSourceObservationID == 0)
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationPolSourceObservationID), new[] { "PolSourceObservationID" });
                }

                if (!GetRead().Where(c => c.PolSourceObservationID == polSourceObservation.PolSourceObservationID).Any())
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceObservation, CSSPModelsRes.PolSourceObservationPolSourceObservationID, polSourceObservation.PolSourceObservationID.ToString()), new[] { "PolSourceObservationID" });
                }
            }

            PolSourceSite PolSourceSitePolSourceSiteID = (from c in db.PolSourceSites where c.PolSourceSiteID == polSourceObservation.PolSourceSiteID select c).FirstOrDefault();

            if (PolSourceSitePolSourceSiteID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.PolSourceSite, CSSPModelsRes.PolSourceObservationPolSourceSiteID, (polSourceObservation.PolSourceSiteID == null ? "" : polSourceObservation.PolSourceSiteID.ToString())), new[] { "PolSourceSiteID" });
            }

            if (polSourceObservation.ObservationDate_Local.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationObservationDate_Local), new[] { "ObservationDate_Local" });
            }
            else
            {
                if (polSourceObservation.ObservationDate_Local.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceObservationObservationDate_Local, "1980"), new[] { "ObservationDate_Local" });
                }
            }

            TVItem TVItemContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.ContactTVItemID select c).FirstOrDefault();

            if (TVItemContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationContactTVItemID, (polSourceObservation.ContactTVItemID == null ? "" : polSourceObservation.ContactTVItemID.ToString())), new[] { "ContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationContactTVItemID, "Contact"), new[] { "ContactTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted))
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationObservation_ToBeDeleted), new[] { "Observation_ToBeDeleted" });
            }

            //Observation_ToBeDeleted has no StringLength Attribute

            if (polSourceObservation.LastUpdateDate_UTC.Year == 1)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.PolSourceObservationLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceObservation.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.PolSourceObservationLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceObservation.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID, (polSourceObservation.LastUpdateContactTVItemID == null ? "" : polSourceObservation.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceObservation.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.PolSourceObservationLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                polSourceObservation.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceObservation GetPolSourceObservationWithPolSourceObservationID(int PolSourceObservationID, GetParam getParam)
        {
            IQueryable<PolSourceObservation> polSourceObservationQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.PolSourceObservationID == PolSourceObservationID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return polSourceObservationQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillPolSourceObservationWeb(polSourceObservationQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillPolSourceObservationReport(polSourceObservationQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<PolSourceObservation> GetPolSourceObservationList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<PolSourceObservation> polSourceObservationQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            polSourceObservationQuery  = polSourceObservationQuery.OrderByDescending(c => c.PolSourceObservationID);
                        }
                        polSourceObservationQuery = polSourceObservationQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return polSourceObservationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            polSourceObservationQuery = FillPolSourceObservationWeb(polSourceObservationQuery, FilterAndOrderText).OrderByDescending(c => c.PolSourceObservationID);
                        }
                        polSourceObservationQuery = FillPolSourceObservationWeb(polSourceObservationQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return polSourceObservationQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            polSourceObservationQuery = FillPolSourceObservationReport(polSourceObservationQuery, FilterAndOrderText).OrderByDescending(c => c.PolSourceObservationID);
                        }
                        polSourceObservationQuery = FillPolSourceObservationReport(polSourceObservationQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return polSourceObservationQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Create);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Add(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public bool Delete(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Delete);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Remove(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public bool Update(PolSourceObservation polSourceObservation)
        {
            polSourceObservation.ValidationResults = Validate(new ValidationContext(polSourceObservation), ActionDBTypeEnum.Update);
            if (polSourceObservation.ValidationResults.Count() > 0) return false;

            db.PolSourceObservations.Update(polSourceObservation);

            if (!TryToSave(polSourceObservation)) return false;

            return true;
        }
        public IQueryable<PolSourceObservation> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.PolSourceObservations.AsNoTracking();
            }
            else
            {
                return db.PolSourceObservations.AsNoTracking().OrderByDescending(c => c.PolSourceObservationID);
            }
        }
        public IQueryable<PolSourceObservation> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.PolSourceObservations;
            }
            else
            {
                return db.PolSourceObservations.OrderByDescending(c => c.PolSourceObservationID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated PolSourceObservationFillWeb
        private IQueryable<PolSourceObservation> FillPolSourceObservationWeb(IQueryable<PolSourceObservation> polSourceObservationQuery, string FilterAndOrderText)
        {
            polSourceObservationQuery = (from c in polSourceObservationQuery
                let PolSourceSiteTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.PolSourceSiteID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new PolSourceObservation
                    {
                        PolSourceObservationID = c.PolSourceObservationID,
                        PolSourceSiteID = c.PolSourceSiteID,
                        ObservationDate_Local = c.ObservationDate_Local,
                        ContactTVItemID = c.ContactTVItemID,
                        Observation_ToBeDeleted = c.Observation_ToBeDeleted,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        PolSourceObservationWeb = new PolSourceObservationWeb
                        {
                            PolSourceSiteTVText = PolSourceSiteTVText,
                            ContactTVText = ContactTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        PolSourceObservationReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return polSourceObservationQuery;
        }
        #endregion Functions private Generated PolSourceObservationFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceObservation polSourceObservation)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceObservation.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
