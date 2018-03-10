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
    ///     <para>bonjour UseOfSite</para>
    /// </summary>
    public partial class UseOfSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public UseOfSiteService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            UseOfSite useOfSite = validationContext.ObjectInstance as UseOfSite;
            useOfSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (useOfSite.UseOfSiteID == 0)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.UseOfSiteUseOfSiteID), new[] { "UseOfSiteID" });
                }

                if (!GetRead().Where(c => c.UseOfSiteID == useOfSite.UseOfSiteID).Any())
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.UseOfSite, CSSPModelsRes.UseOfSiteUseOfSiteID, useOfSite.UseOfSiteID.ToString()), new[] { "UseOfSiteID" });
                }
            }

            TVItem TVItemSiteTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.SiteTVItemID select c).FirstOrDefault();

            if (TVItemSiteTVItemID == null)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteSiteTVItemID, (useOfSite.SiteTVItemID == null ? "" : useOfSite.SiteTVItemID.ToString())), new[] { "SiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.ClimateSite,
                    TVTypeEnum.HydrometricSite,
                    TVTypeEnum.TideSite,
                };
                if (!AllowableTVTypes.Contains(TVItemSiteTVItemID.TVType))
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.UseOfSiteSiteTVItemID, "ClimateSite,HydrometricSite,TideSite"), new[] { "SiteTVItemID" });
                }
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteSubsectorTVItemID, (useOfSite.SubsectorTVItemID == null ? "" : useOfSite.SubsectorTVItemID.ToString())), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.UseOfSiteSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(SiteTypeEnum), (int?)useOfSite.SiteType);
            if (useOfSite.SiteType == SiteTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.UseOfSiteSiteType), new[] { "SiteType" });
            }

            if (useOfSite.Ordinal < 0 || useOfSite.Ordinal > 1000)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            if (useOfSite.StartYear < 1980 || useOfSite.StartYear > 2050)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteStartYear, "1980", "2050"), new[] { "StartYear" });
            }

            if (useOfSite.EndYear != null)
            {
                if (useOfSite.EndYear < 1980 || useOfSite.EndYear > 2050)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteEndYear, "1980", "2050"), new[] { "EndYear" });
                }
            }

            if (useOfSite.Weight_perc != null)
            {
                if (useOfSite.Weight_perc < 0 || useOfSite.Weight_perc > 100)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteWeight_perc, "0", "100"), new[] { "Weight_perc" });
                }
            }

            if (useOfSite.Param1 != null)
            {
                if (useOfSite.Param1 < 0 || useOfSite.Param1 > 100)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam1, "0", "100"), new[] { "Param1" });
                }
            }

            if (useOfSite.Param2 != null)
            {
                if (useOfSite.Param2 < 0 || useOfSite.Param2 > 100)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam2, "0", "100"), new[] { "Param2" });
                }
            }

            if (useOfSite.Param3 != null)
            {
                if (useOfSite.Param3 < 0 || useOfSite.Param3 > 100)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam3, "0", "100"), new[] { "Param3" });
                }
            }

            if (useOfSite.Param4 != null)
            {
                if (useOfSite.Param4 < 0 || useOfSite.Param4 > 100)
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteParam4, "0", "100"), new[] { "Param4" });
                }
            }

            if (useOfSite.LastUpdateDate_UTC.Year == 1)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.UseOfSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (useOfSite.LastUpdateDate_UTC.Year < 1980)
                {
                useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.UseOfSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteLastUpdateContactTVItemID, (useOfSite.LastUpdateContactTVItemID == null ? "" : useOfSite.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    useOfSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.UseOfSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public UseOfSite GetUseOfSiteWithUseOfSiteID(int UseOfSiteID, GetParam getParam)
        {
            IQueryable<UseOfSite> useOfSiteQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.UseOfSiteID == UseOfSiteID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return useOfSiteQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillUseOfSiteWeb(useOfSiteQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillUseOfSiteReport(useOfSiteQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<UseOfSite> GetUseOfSiteList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<UseOfSite> useOfSiteQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            useOfSiteQuery  = useOfSiteQuery.OrderByDescending(c => c.UseOfSiteID);
                        }
                        useOfSiteQuery = useOfSiteQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return useOfSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            useOfSiteQuery = FillUseOfSiteWeb(useOfSiteQuery, FilterAndOrderText).OrderByDescending(c => c.UseOfSiteID);
                        }
                        useOfSiteQuery = FillUseOfSiteWeb(useOfSiteQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return useOfSiteQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            useOfSiteQuery = FillUseOfSiteReport(useOfSiteQuery, FilterAndOrderText).OrderByDescending(c => c.UseOfSiteID);
                        }
                        useOfSiteQuery = FillUseOfSiteReport(useOfSiteQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return useOfSiteQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(UseOfSite useOfSite)
        {
            useOfSite.ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Create);
            if (useOfSite.ValidationResults.Count() > 0) return false;

            db.UseOfSites.Add(useOfSite);

            if (!TryToSave(useOfSite)) return false;

            return true;
        }
        public bool Delete(UseOfSite useOfSite)
        {
            useOfSite.ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Delete);
            if (useOfSite.ValidationResults.Count() > 0) return false;

            db.UseOfSites.Remove(useOfSite);

            if (!TryToSave(useOfSite)) return false;

            return true;
        }
        public bool Update(UseOfSite useOfSite)
        {
            useOfSite.ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Update);
            if (useOfSite.ValidationResults.Count() > 0) return false;

            db.UseOfSites.Update(useOfSite);

            if (!TryToSave(useOfSite)) return false;

            return true;
        }
        public IQueryable<UseOfSite> GetRead()
        {
            return db.UseOfSites.AsNoTracking();
        }
        public IQueryable<UseOfSite> GetEdit()
        {
            return db.UseOfSites;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated UseOfSiteFillWeb
        private IQueryable<UseOfSite> FillUseOfSiteWeb(IQueryable<UseOfSite> useOfSiteQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SiteTypeEnumList = enums.GetEnumTextOrderedList(typeof(SiteTypeEnum));

            useOfSiteQuery = (from c in useOfSiteQuery
                let SiteTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let SubsectorTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.SubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new UseOfSite
                    {
                        UseOfSiteID = c.UseOfSiteID,
                        SiteTVItemID = c.SiteTVItemID,
                        SubsectorTVItemID = c.SubsectorTVItemID,
                        SiteType = c.SiteType,
                        Ordinal = c.Ordinal,
                        StartYear = c.StartYear,
                        EndYear = c.EndYear,
                        UseWeight = c.UseWeight,
                        Weight_perc = c.Weight_perc,
                        UseEquation = c.UseEquation,
                        Param1 = c.Param1,
                        Param2 = c.Param2,
                        Param3 = c.Param3,
                        Param4 = c.Param4,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        UseOfSiteWeb = new UseOfSiteWeb
                        {
                            SiteTVText = SiteTVText,
                            SubsectorTVText = SubsectorTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            SiteTypeText = (from e in SiteTypeEnumList
                                where e.EnumID == (int?)c.SiteType
                                select e.EnumText).FirstOrDefault(),
                        },
                        UseOfSiteReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return useOfSiteQuery;
        }
        #endregion Functions private Generated UseOfSiteFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(UseOfSite useOfSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                useOfSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
