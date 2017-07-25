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
    public partial class MWQMSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSite mwqmSite = validationContext.ObjectInstance as MWQMSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSite.MWQMSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteID), new[] { ModelsRes.MWQMSiteMWQMSiteID });
                }
            }

            //MWQMSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSite.MWQMSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteMWQMSiteTVItemID, "1"), new[] { ModelsRes.MWQMSiteMWQMSiteTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmSite.MWQMSiteTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteMWQMSiteTVItemID, mwqmSite.MWQMSiteTVItemID.ToString()), new[] { ModelsRes.MWQMSiteMWQMSiteTVItemID });
            }

            if (string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteNumber), new[] { ModelsRes.MWQMSiteMWQMSiteNumber });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteNumber) && mwqmSite.MWQMSiteNumber.Length > 8)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteMWQMSiteNumber, "8"), new[] { ModelsRes.MWQMSiteMWQMSiteNumber });
            }

            if (string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteDescription))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteDescription), new[] { ModelsRes.MWQMSiteMWQMSiteDescription });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteDescription) && mwqmSite.MWQMSiteDescription.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteMWQMSiteDescription, "200"), new[] { ModelsRes.MWQMSiteMWQMSiteDescription });
            }

            retStr = enums.MWQMSiteLatestClassificationOK(mwqmSite.MWQMSiteLatestClassification);
            if (mwqmSite.MWQMSiteLatestClassification == MWQMSiteLatestClassificationEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteMWQMSiteLatestClassification), new[] { ModelsRes.MWQMSiteMWQMSiteLatestClassification });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSite.Ordinal < 0 || mwqmSite.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSiteOrdinal, "0", "1000"), new[] { ModelsRes.MWQMSiteOrdinal });
            }

            if (mwqmSite.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteLastUpdateDate_UTC), new[] { ModelsRes.MWQMSiteLastUpdateDate_UTC });
            }

            if (mwqmSite.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSiteLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MWQMSiteLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSite.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMSiteLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmSite.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteLastUpdateContactTVItemID, mwqmSite.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MWQMSiteLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MWQMSite mwqmSite)
        {
            mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Create);
            if (mwqmSite.ValidationResults.Count() > 0) return false;

            db.MWQMSites.Add(mwqmSite);

            if (!TryToSave(mwqmSite)) return false;

            return true;
        }
        public bool AddRange(List<MWQMSite> mwqmSiteList)
        {
            foreach (MWQMSite mwqmSite in mwqmSiteList)
            {
                mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Create);
                if (mwqmSite.ValidationResults.Count() > 0) return false;
            }

            db.MWQMSites.AddRange(mwqmSiteList);

            if (!TryToSaveRange(mwqmSiteList)) return false;

            return true;
        }
        public bool Delete(MWQMSite mwqmSite)
        {
            if (!db.MWQMSites.Where(c => c.MWQMSiteID == mwqmSite.MWQMSiteID).Any())
            {
                mwqmSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSite", "MWQMSiteID", mwqmSite.MWQMSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSites.Remove(mwqmSite);

            if (!TryToSave(mwqmSite)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMSite> mwqmSiteList)
        {
            foreach (MWQMSite mwqmSite in mwqmSiteList)
            {
                if (!db.MWQMSites.Where(c => c.MWQMSiteID == mwqmSite.MWQMSiteID).Any())
                {
                    mwqmSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSite", "MWQMSiteID", mwqmSite.MWQMSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMSites.RemoveRange(mwqmSiteList);

            if (!TryToSaveRange(mwqmSiteList)) return false;

            return true;
        }
        public bool Update(MWQMSite mwqmSite)
        {
            mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Update);
            if (mwqmSite.ValidationResults.Count() > 0) return false;

            db.MWQMSites.Update(mwqmSite);

            if (!TryToSave(mwqmSite)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMSite> mwqmSiteList)
        {
            foreach (MWQMSite mwqmSite in mwqmSiteList)
            {
                mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Update);
                if (mwqmSite.ValidationResults.Count() > 0) return false;
            }
            db.MWQMSites.UpdateRange(mwqmSiteList);

            if (!TryToSaveRange(mwqmSiteList)) return false;

            return true;
        }
        public IQueryable<MWQMSite> GetRead()
        {
            return db.MWQMSites.AsNoTracking();
        }
        public IQueryable<MWQMSite> GetEdit()
        {
            return db.MWQMSites;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MWQMSite mwqmSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMSite> mwqmSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
