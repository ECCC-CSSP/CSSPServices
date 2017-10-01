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
        public UseOfSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //UseOfSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemSiteTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.SiteTVItemID select c).FirstOrDefault();

            if (TVItemSiteTVItemID == null)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteSiteTVItemID, useOfSite.SiteTVItemID.ToString()), new[] { "SiteTVItemID" });
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

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteSubsectorTVItemID, useOfSite.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
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

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (useOfSite.Ordinal < 0 || useOfSite.Ordinal > 1000)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.UseOfSiteOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            //StartYear (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

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

                //Error: Type not implemented [UseOfSiteWeb] of type [UseOfSiteWeb]
                //Error: Type not implemented [UseOfSiteReport] of type [UseOfSiteReport]
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

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == useOfSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.UseOfSiteLastUpdateContactTVItemID, useOfSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                useOfSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public UseOfSite GetUseOfSiteWithUseOfSiteID(int UseOfSiteID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<UseOfSite> useOfSiteQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.UseOfSiteID == UseOfSiteID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return useOfSiteQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillUseOfSite(useOfSiteQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<UseOfSite> GetUseOfSiteList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<UseOfSite> useOfSiteQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return useOfSiteQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillUseOfSite(useOfSiteQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
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

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<UseOfSite> FillUseOfSite_Show_Copy_To_UseOfSiteServiceExtra_As_Fill_UseOfSite(IQueryable<UseOfSite> useOfSiteQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
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
                        UseOfSiteReport = new UseOfSiteReport
                        {
                            UseOfSiteReportTest = "UseOfSiteReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return useOfSiteQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
