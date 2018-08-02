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
    ///     <para>bonjour SamplingPlanSubsectorSite</para>
    /// </summary>
    public partial class SamplingPlanSubsectorSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = validationContext.ObjectInstance as SamplingPlanSubsectorSite;
            samplingPlanSubsectorSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID == 0)
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), new[] { "SamplingPlanSubsectorSiteID" });
                }

                if (!GetRead().Where(c => c.SamplingPlanSubsectorSiteID == samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID).Any())
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsectorSite, CSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID, samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), new[] { "SamplingPlanSubsectorSiteID" });
                }
            }

            SamplingPlanSubsector SamplingPlanSubsectorSamplingPlanSubsectorID = (from c in db.SamplingPlanSubsectors where c.SamplingPlanSubsectorID == samplingPlanSubsectorSite.SamplingPlanSubsectorID select c).FirstOrDefault();

            if (SamplingPlanSubsectorSamplingPlanSubsectorID == null)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsector, CSSPModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SamplingPlanSubsectorSite GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(int SamplingPlanSubsectorSiteID)
        {
            IQueryable<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return samplingPlanSubsectorSiteQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillSamplingPlanSubsectorSiteWeb(samplingPlanSubsectorSiteQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillSamplingPlanSubsectorSiteReport(samplingPlanSubsectorSiteQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<SamplingPlanSubsectorSite> GetSamplingPlanSubsectorSiteList()
        {
            IQueryable<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        samplingPlanSubsectorSiteQuery = EnhanceQueryStatements<SamplingPlanSubsectorSite>(samplingPlanSubsectorSiteQuery) as IQueryable<SamplingPlanSubsectorSite>;

                        return samplingPlanSubsectorSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        samplingPlanSubsectorSiteQuery = FillSamplingPlanSubsectorSiteWeb(samplingPlanSubsectorSiteQuery);

                        samplingPlanSubsectorSiteQuery = EnhanceQueryStatements<SamplingPlanSubsectorSite>(samplingPlanSubsectorSiteQuery) as IQueryable<SamplingPlanSubsectorSite>;

                        return samplingPlanSubsectorSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        samplingPlanSubsectorSiteQuery = FillSamplingPlanSubsectorSiteReport(samplingPlanSubsectorSiteQuery);

                        samplingPlanSubsectorSiteQuery = EnhanceQueryStatements<SamplingPlanSubsectorSite>(samplingPlanSubsectorSiteQuery) as IQueryable<SamplingPlanSubsectorSite>;

                        return samplingPlanSubsectorSiteQuery;
                    }
                default:
                    {
                        samplingPlanSubsectorSiteQuery = samplingPlanSubsectorSiteQuery.Where(c => c.SamplingPlanSubsectorSiteID == 0);

                        return samplingPlanSubsectorSiteQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Create);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Add(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public bool Delete(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Delete);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Remove(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public bool Update(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Update);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Update(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public IQueryable<SamplingPlanSubsectorSite> GetRead()
        {
            IQueryable<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteQuery = db.SamplingPlanSubsectorSites.AsNoTracking();

            return samplingPlanSubsectorSiteQuery;
        }
        public IQueryable<SamplingPlanSubsectorSite> GetEdit()
        {
            IQueryable<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteQuery = db.SamplingPlanSubsectorSites;

            return samplingPlanSubsectorSiteQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated SamplingPlanSubsectorSiteFillWeb
        private IQueryable<SamplingPlanSubsectorSite> FillSamplingPlanSubsectorSiteWeb(IQueryable<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteQuery)
        {
            samplingPlanSubsectorSiteQuery = (from c in samplingPlanSubsectorSiteQuery
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new SamplingPlanSubsectorSite
                    {
                        SamplingPlanSubsectorSiteID = c.SamplingPlanSubsectorSiteID,
                        SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        IsDuplicate = c.IsDuplicate,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        SamplingPlanSubsectorSiteWeb = new SamplingPlanSubsectorSiteWeb
                        {
                            MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                            LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        },
                        SamplingPlanSubsectorSiteReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return samplingPlanSubsectorSiteQuery;
        }
        #endregion Functions private Generated SamplingPlanSubsectorSiteFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsectorSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
