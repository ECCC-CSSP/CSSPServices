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

            //UseOfSiteID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //UseOfSiteID has no Range Attribute

            //SiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SiteTVItemID has no Range Attribute

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SubsectorTVItemID has no Range Attribute

                //Error: Type not implemented [SiteType] of type [SiteTypeEnum]

                //Error: Type not implemented [SiteType] of type [SiteTypeEnum]
            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Ordinal has no Range Attribute

            //StartYear (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //StartYear has no Range Attribute

                //Error: Type not implemented [EndYear] of type [Nullable`1]

            //EndYear has no Range Attribute

                //Error: Type not implemented [UseWeight] of type [Nullable`1]

                //Error: Type not implemented [Weight_perc] of type [Nullable`1]

            //Weight_perc has no Range Attribute

                //Error: Type not implemented [UseEquation] of type [Nullable`1]

                //Error: Type not implemented [Param1] of type [Nullable`1]

            //Param1 has no Range Attribute

                //Error: Type not implemented [Param2] of type [Nullable`1]

            //Param2 has no Range Attribute

                //Error: Type not implemented [Param3] of type [Nullable`1]

            //Param3 has no Range Attribute

                //Error: Type not implemented [Param4] of type [Nullable`1]

            //Param4 has no Range Attribute

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
