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
    public partial class UseOfSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            UseOfSite useOfSite = validationContext.ObjectInstance as UseOfSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (useOfSite.UseOfSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteUseOfSiteID), new[] { ModelsRes.UseOfSiteUseOfSiteID });
                }
            }

            //UseOfSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (useOfSite.SiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.UseOfSiteSiteTVItemID, "1"), new[] { ModelsRes.UseOfSiteSiteTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == useOfSite.SiteTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteSiteTVItemID, useOfSite.SiteTVItemID.ToString()), new[] { ModelsRes.UseOfSiteSiteTVItemID });
            }

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (useOfSite.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.UseOfSiteSubsectorTVItemID, "1"), new[] { ModelsRes.UseOfSiteSubsectorTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == useOfSite.SubsectorTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteSubsectorTVItemID, useOfSite.SubsectorTVItemID.ToString()), new[] { ModelsRes.UseOfSiteSubsectorTVItemID });
            }

            retStr = enums.SiteTypeOK(useOfSite.SiteType);
            if (useOfSite.SiteType == SiteTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteSiteType), new[] { ModelsRes.UseOfSiteSiteType });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (useOfSite.Ordinal < 0 || useOfSite.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteOrdinal, "0", "1000"), new[] { ModelsRes.UseOfSiteOrdinal });
            }

            //StartYear (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (useOfSite.StartYear < 1980 || useOfSite.StartYear > 2050)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteStartYear, "1980", "2050"), new[] { ModelsRes.UseOfSiteStartYear });
            }

            if (useOfSite.EndYear != null)
            {
                if (useOfSite.EndYear < 1980 || useOfSite.EndYear > 2050)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteEndYear, "1980", "2050"), new[] { ModelsRes.UseOfSiteEndYear });
                }
            }

            if (useOfSite.Weight_perc != null)
            {
                if (useOfSite.Weight_perc < 0 || useOfSite.Weight_perc > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteWeight_perc, "0", "100"), new[] { ModelsRes.UseOfSiteWeight_perc });
                }
            }

            if (useOfSite.Param1 != null)
            {
                if (useOfSite.Param1 < 0 || useOfSite.Param1 > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam1, "0", "100"), new[] { ModelsRes.UseOfSiteParam1 });
                }
            }

            if (useOfSite.Param2 != null)
            {
                if (useOfSite.Param2 < 0 || useOfSite.Param2 > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam2, "0", "100"), new[] { ModelsRes.UseOfSiteParam2 });
                }
            }

            if (useOfSite.Param3 != null)
            {
                if (useOfSite.Param3 < 0 || useOfSite.Param3 > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam3, "0", "100"), new[] { ModelsRes.UseOfSiteParam3 });
                }
            }

            if (useOfSite.Param4 != null)
            {
                if (useOfSite.Param4 < 0 || useOfSite.Param4 > 100)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.UseOfSiteParam4, "0", "100"), new[] { ModelsRes.UseOfSiteParam4 });
                }
            }

            if (useOfSite.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.UseOfSiteLastUpdateDate_UTC), new[] { ModelsRes.UseOfSiteLastUpdateDate_UTC });
            }

            if (useOfSite.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.UseOfSiteLastUpdateDate_UTC, "1980"), new[] { ModelsRes.UseOfSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (useOfSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.UseOfSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.UseOfSiteLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == useOfSite.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.UseOfSiteLastUpdateContactTVItemID, useOfSite.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.UseOfSiteLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(UseOfSite useOfSite)
        {
            useOfSite.ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Create);
            if (useOfSite.ValidationResults.Count() > 0) return false;

            db.UseOfSites.Add(useOfSite);

            if (!TryToSave(useOfSite)) return false;

            return true;
        }
        public bool AddRange(List<UseOfSite> useOfSiteList)
        {
            foreach (UseOfSite useOfSite in useOfSiteList)
            {
                useOfSite.ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Create);
                if (useOfSite.ValidationResults.Count() > 0) return false;
            }

            db.UseOfSites.AddRange(useOfSiteList);

            if (!TryToSaveRange(useOfSiteList)) return false;

            return true;
        }
        public bool Delete(UseOfSite useOfSite)
        {
            if (!db.UseOfSites.Where(c => c.UseOfSiteID == useOfSite.UseOfSiteID).Any())
            {
                useOfSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "UseOfSite", "UseOfSiteID", useOfSite.UseOfSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.UseOfSites.Remove(useOfSite);

            if (!TryToSave(useOfSite)) return false;

            return true;
        }
        public bool DeleteRange(List<UseOfSite> useOfSiteList)
        {
            foreach (UseOfSite useOfSite in useOfSiteList)
            {
                if (!db.UseOfSites.Where(c => c.UseOfSiteID == useOfSite.UseOfSiteID).Any())
                {
                    useOfSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "UseOfSite", "UseOfSiteID", useOfSite.UseOfSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.UseOfSites.RemoveRange(useOfSiteList);

            if (!TryToSaveRange(useOfSiteList)) return false;

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
        public bool UpdateRange(List<UseOfSite> useOfSiteList)
        {
            foreach (UseOfSite useOfSite in useOfSiteList)
            {
                useOfSite.ValidationResults = Validate(new ValidationContext(useOfSite), ActionDBTypeEnum.Update);
                if (useOfSite.ValidationResults.Count() > 0) return false;
            }
            db.UseOfSites.UpdateRange(useOfSiteList);

            if (!TryToSaveRange(useOfSiteList)) return false;

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
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<UseOfSite> useOfSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                useOfSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
