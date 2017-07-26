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
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = validationContext.ObjectInstance as SamplingPlanSubsectorSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID), new[] { ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID });
                }
            }

            //SamplingPlanSubsectorSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SamplingPlanSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlanSubsectorSite.SamplingPlanSubsectorID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID });
            }

            if (!((from c in db.SamplingPlanSubsectors where c.SamplingPlanSubsectorID == samplingPlanSubsectorSite.SamplingPlanSubsectorID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlanSubsector, ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID, samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), new[] { ModelsRes.SamplingPlanSubsectorSiteSamplingPlanSubsectorID });
            }

            //MWQMSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlanSubsectorSite.MWQMSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.MWQMSiteTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID, samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), new[] { ModelsRes.SamplingPlanSubsectorSiteMWQMSiteTVItemID });
            }

            //IsDuplicate (bool) is required but no testing needed 

            if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC), new[] { ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC });
            }
            else
            {
                if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC, "1980"), new[] { ModelsRes.SamplingPlanSubsectorSiteLastUpdateDate_UTC });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlanSubsectorSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID, samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.SamplingPlanSubsectorSiteLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
