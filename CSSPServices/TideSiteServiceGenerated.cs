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
    public partial class TideSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TideSiteService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TideSite tideSite = validationContext.ObjectInstance as TideSite;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tideSite.TideSiteID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteTideSiteID), new[] { "TideSiteID" });
                }
            }

            //TideSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TideSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTideSiteTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.TideSiteTVItemID select c).FirstOrDefault();

            if (TVItemTideSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideSiteTideSiteTVItemID, tideSite.TideSiteTVItemID.ToString()), new[] { "TideSiteTVItemID" });
            }
            else
            {
                if (TVItemTideSiteTVItemID.TVType != TVTypeEnum.TideSite)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideSiteTideSiteTVItemID, "TideSite"), new[] { "TideSiteTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tideSite.WebTideModel))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteWebTideModel), new[] { "WebTideModel" });
            }

            if (!string.IsNullOrWhiteSpace(tideSite.WebTideModel) && tideSite.WebTideModel.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideSiteWebTideModel, "100"), new[] { "WebTideModel" });
            }

            //WebTideDatum_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tideSite.WebTideDatum_m < -100 || tideSite.WebTideDatum_m > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideSiteWebTideDatum_m, "-100", "100"), new[] { "WebTideDatum_m" });
            }

            if (tideSite.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TideSiteLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tideSite.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TideSiteLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tideSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideSiteLastUpdateContactTVItemID, tideSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideSiteLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Add(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool AddRange(List<TideSite> tideSiteList)
        {
            foreach (TideSite tideSite in tideSiteList)
            {
                tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Create);
                if (tideSite.ValidationResults.Count() > 0) return false;
            }

            db.TideSites.AddRange(tideSiteList);

            if (!TryToSaveRange(tideSiteList)) return false;

            return true;
        }
        public bool Delete(TideSite tideSite)
        {
            if (!db.TideSites.Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
            {
                tideSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TideSites.Remove(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool DeleteRange(List<TideSite> tideSiteList)
        {
            foreach (TideSite tideSite in tideSiteList)
            {
                if (!db.TideSites.Where(c => c.TideSiteID == tideSite.TideSiteID).Any())
                {
                    tideSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TideSite", "TideSiteID", tideSite.TideSiteID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TideSites.RemoveRange(tideSiteList);

            if (!TryToSaveRange(tideSiteList)) return false;

            return true;
        }
        public bool Update(TideSite tideSite)
        {
            tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
            if (tideSite.ValidationResults.Count() > 0) return false;

            db.TideSites.Update(tideSite);

            if (!TryToSave(tideSite)) return false;

            return true;
        }
        public bool UpdateRange(List<TideSite> tideSiteList)
        {
            foreach (TideSite tideSite in tideSiteList)
            {
                tideSite.ValidationResults = Validate(new ValidationContext(tideSite), ActionDBTypeEnum.Update);
                if (tideSite.ValidationResults.Count() > 0) return false;
            }
            db.TideSites.UpdateRange(tideSiteList);

            if (!TryToSaveRange(tideSiteList)) return false;

            return true;
        }
        public IQueryable<TideSite> GetRead()
        {
            return db.TideSites.AsNoTracking();
        }
        public IQueryable<TideSite> GetEdit()
        {
            return db.TideSites;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TideSite tideSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TideSite> tideSiteList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tideSiteList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
