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
    public partial class SamplingPlanSubsectorSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = validationContext.ObjectInstance as SamplingPlanSubsectorSite;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), new[] { ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID });
                }
            }

            //SamplingPlanSubsectorID (int) is required but no testing needed as it is automatically set to 0

            //MWQMSiteTVItemID (int) is required but no testing needed as it is automatically set to 0

            //IsDuplicate (bool) is required but no testing needed 

            if (samplingPlanSubsectorSite.LastUpdateDate_UTC == null || samplingPlanSubsectorSite.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC), new[] { ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (samplingPlanSubsectorSite.SamplingPlanSubsectorID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID });
            }

            if (samplingPlanSubsectorSite.MWQMSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID });
            }

            if (samplingPlanSubsectorSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
        public bool Add(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Create);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Add(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public bool AddRange(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
            foreach (SamplingPlanSubsectorSite samplingPlanSubsectorSite in samplingPlanSubsectorSiteList)
            {
                samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Create);
                if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;
            }

            db.SamplingPlanSubsectorSites.AddRange(samplingPlanSubsectorSiteList);

            if (!TryToSaveRange(samplingPlanSubsectorSiteList)) return false;

            return true;
        }
        public bool Delete(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            if (!db.SamplingPlanSubsectorSites.Where(c => c.SamplingPlanSubsectorSiteID == samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID).Any())
            {
                samplingPlanSubsectorSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteID", samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.SamplingPlanSubsectorSites.Remove(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public bool DeleteRange(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
            foreach (SamplingPlanSubsectorSite samplingPlanSubsectorSite in samplingPlanSubsectorSiteList)
            {
                if (!db.SamplingPlanSubsectorSites.Where(c => c.SamplingPlanSubsectorSiteID == samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID).Any())
                {
                    samplingPlanSubsectorSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteID", samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.SamplingPlanSubsectorSites.RemoveRange(samplingPlanSubsectorSiteList);

            if (!TryToSaveRange(samplingPlanSubsectorSiteList)) return false;

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
        public bool UpdateRange(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
            foreach (SamplingPlanSubsectorSite samplingPlanSubsectorSite in samplingPlanSubsectorSiteList)
            {
                samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Update);
                if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;
            }
            db.SamplingPlanSubsectorSites.UpdateRange(samplingPlanSubsectorSiteList);

            if (!TryToSaveRange(samplingPlanSubsectorSiteList)) return false;

            return true;
        }
        public IQueryable<SamplingPlanSubsectorSite> GetRead()
        {
            return db.SamplingPlanSubsectorSites.AsNoTracking();
        }
        public IQueryable<SamplingPlanSubsectorSite> GetEdit()
        {
            return db.SamplingPlanSubsectorSites;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsectorSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
