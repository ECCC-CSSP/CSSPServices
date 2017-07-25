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
    public partial class PolSourceSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceSite polSourceSite = validationContext.ObjectInstance as PolSourceSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (polSourceSite.PolSourceSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceSitePolSourceSiteID), new[] { ModelsRes.PolSourceSitePolSourceSiteID });
                }
            }

            //PolSourceSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //PolSourceSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceSite.PolSourceSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSitePolSourceSiteTVItemID, "1"), new[] { ModelsRes.PolSourceSitePolSourceSiteTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == polSourceSite.PolSourceSiteTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSitePolSourceSiteTVItemID, polSourceSite.PolSourceSiteTVItemID.ToString()), new[] { ModelsRes.PolSourceSitePolSourceSiteTVItemID });
            }

            if (string.IsNullOrWhiteSpace(polSourceSite.Temp_Locator_CanDelete))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceSiteTemp_Locator_CanDelete), new[] { ModelsRes.PolSourceSiteTemp_Locator_CanDelete });
            }

            if (!string.IsNullOrWhiteSpace(polSourceSite.Temp_Locator_CanDelete) && polSourceSite.Temp_Locator_CanDelete.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.PolSourceSiteTemp_Locator_CanDelete, "50"), new[] { ModelsRes.PolSourceSiteTemp_Locator_CanDelete });
            }

            if (polSourceSite.Oldsiteid != null)
            {
                if (polSourceSite.Oldsiteid < 0 || polSourceSite.Oldsiteid > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteOldsiteid, "0", "1000"), new[] { ModelsRes.PolSourceSiteOldsiteid });
                }
            }

            if (polSourceSite.Site != null)
            {
                if (polSourceSite.Site < 0 || polSourceSite.Site > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSite, "0", "1000"), new[] { ModelsRes.PolSourceSiteSite });
                }
            }

            if (polSourceSite.SiteID != null)
            {
                if (polSourceSite.SiteID < 0 || polSourceSite.SiteID > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.PolSourceSiteSiteID, "0", "1000"), new[] { ModelsRes.PolSourceSiteSiteID });
                }
            }

            //IsPointSource (bool) is required but no testing needed 

            if (polSourceSite.InactiveReason != null)
            {
                retStr = enums.PolSourceInactiveReasonOK(polSourceSite.InactiveReason);
                if (polSourceSite.InactiveReason == PolSourceInactiveReasonEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.PolSourceSiteInactiveReason });
                }
            }

            if (polSourceSite.CivicAddressTVItemID != null)
            {
                if (polSourceSite.CivicAddressTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteCivicAddressTVItemID, "1"), new[] { ModelsRes.PolSourceSiteCivicAddressTVItemID });
                }
            }

            if (polSourceSite.CivicAddressTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == polSourceSite.CivicAddressTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSiteCivicAddressTVItemID, polSourceSite.CivicAddressTVItemID.ToString()), new[] { ModelsRes.PolSourceSiteCivicAddressTVItemID });
                }
            }

            if (polSourceSite.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.PolSourceSiteLastUpdateDate_UTC), new[] { ModelsRes.PolSourceSiteLastUpdateDate_UTC });
            }

            if (polSourceSite.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.PolSourceSiteLastUpdateDate_UTC, "1980"), new[] { ModelsRes.PolSourceSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (polSourceSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.PolSourceSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.PolSourceSiteLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == polSourceSite.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.PolSourceSiteLastUpdateContactTVItemID, polSourceSite.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.PolSourceSiteLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(PolSourceSite polSourceSite)
        {
            polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Create);
            if (polSourceSite.ValidationResults.Count() > 0) return false;

            db.PolSourceSites.Add(polSourceSite);

            if (!TryToSave(polSourceSite)) return false;

            return true;
        }
        public bool AddRange(List<PolSourceSite> polSourceSiteList)
        {
            foreach (PolSourceSite polSourceSite in polSourceSiteList)
            {
                polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Create);
                if (polSourceSite.ValidationResults.Count() > 0) return false;
            }

            db.PolSourceSites.AddRange(polSourceSiteList);

            if (!TryToSaveRange(polSourceSiteList)) return false;

            return true;
        }
        public bool Delete(PolSourceSite polSourceSite)
        {
            if (!db.PolSourceSites.Where(c => c.PolSourceSiteID == polSourceSite.PolSourceSiteID).Any())
            {
                polSourceSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceSite.PolSourceSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.PolSourceSites.Remove(polSourceSite);

            if (!TryToSave(polSourceSite)) return false;

            return true;
        }
        public bool DeleteRange(List<PolSourceSite> polSourceSiteList)
        {
            foreach (PolSourceSite polSourceSite in polSourceSiteList)
            {
                if (!db.PolSourceSites.Where(c => c.PolSourceSiteID == polSourceSite.PolSourceSiteID).Any())
                {
                    polSourceSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "PolSourceSite", "PolSourceSiteID", polSourceSite.PolSourceSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.PolSourceSites.RemoveRange(polSourceSiteList);

            if (!TryToSaveRange(polSourceSiteList)) return false;

            return true;
        }
        public bool Update(PolSourceSite polSourceSite)
        {
            polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Update);
            if (polSourceSite.ValidationResults.Count() > 0) return false;

            db.PolSourceSites.Update(polSourceSite);

            if (!TryToSave(polSourceSite)) return false;

            return true;
        }
        public bool UpdateRange(List<PolSourceSite> polSourceSiteList)
        {
            foreach (PolSourceSite polSourceSite in polSourceSiteList)
            {
                polSourceSite.ValidationResults = Validate(new ValidationContext(polSourceSite), ActionDBTypeEnum.Update);
                if (polSourceSite.ValidationResults.Count() > 0) return false;
            }
            db.PolSourceSites.UpdateRange(polSourceSiteList);

            if (!TryToSaveRange(polSourceSiteList)) return false;

            return true;
        }
        public IQueryable<PolSourceSite> GetRead()
        {
            return db.PolSourceSites.AsNoTracking();
        }
        public IQueryable<PolSourceSite> GetEdit()
        {
            return db.PolSourceSites;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(PolSourceSite polSourceSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<PolSourceSite> polSourceSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
