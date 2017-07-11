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
    public partial class TVItemStatService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            TVItemStat tvItemStat = validationContext.ObjectInstance as TVItemStat;

            //TVItemStatID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemStatID has no Range Attribute

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID has no Range Attribute

                //Error: Type not implemented [TVType] of type [TVTypeEnum]

                //Error: Type not implemented [TVType] of type [TVTypeEnum]
            //ChildCount (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ChildCount has no Range Attribute

            if (tvItemStat.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemStatLastUpdateDate_UTC), new[] { ModelsRes.TVItemStatLastUpdateDate_UTC });
            }

            if (tvItemStat.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemStatLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVItemStatLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemStat.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemStatLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVItemStatLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == tvItemStat.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemStatLastUpdateContactTVItemID, tvItemStat.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVItemStatLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Create);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Add(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        public bool AddRange(List<TVItemStat> tvItemStatList)
        {
            foreach (TVItemStat tvItemStat in tvItemStatList)
            {
                tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Create);
                if (tvItemStat.ValidationResults.Count() > 0) return false;
            }

            db.TVItemStats.AddRange(tvItemStatList);

            if (!TryToSaveRange(tvItemStatList)) return false;

            return true;
        }
        public bool Delete(TVItemStat tvItemStat)
        {
            if (!db.TVItemStats.Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
            {
                tvItemStat.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", tvItemStat.TVItemStatID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItemStats.Remove(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItemStat> tvItemStatList)
        {
            foreach (TVItemStat tvItemStat in tvItemStatList)
            {
                if (!db.TVItemStats.Where(c => c.TVItemStatID == tvItemStat.TVItemStatID).Any())
                {
                    tvItemStatList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemStat", "TVItemStatID", tvItemStat.TVItemStatID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItemStats.RemoveRange(tvItemStatList);

            if (!TryToSaveRange(tvItemStatList)) return false;

            return true;
        }
        public bool Update(TVItemStat tvItemStat)
        {
            tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Update);
            if (tvItemStat.ValidationResults.Count() > 0) return false;

            db.TVItemStats.Update(tvItemStat);

            if (!TryToSave(tvItemStat)) return false;

            return true;
        }
        public bool UpdateRange(List<TVItemStat> tvItemStatList)
        {
            foreach (TVItemStat tvItemStat in tvItemStatList)
            {
                tvItemStat.ValidationResults = Validate(new ValidationContext(tvItemStat), ActionDBTypeEnum.Update);
                if (tvItemStat.ValidationResults.Count() > 0) return false;
            }
            db.TVItemStats.UpdateRange(tvItemStatList);

            if (!TryToSaveRange(tvItemStatList)) return false;

            return true;
        }
        public IQueryable<TVItemStat> GetRead()
        {
            return db.TVItemStats.AsNoTracking();
        }
        public IQueryable<TVItemStat> GetEdit()
        {
            return db.TVItemStats;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVItemStat tvItemStat)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemStat.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVItemStat> tvItemStatList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemStatList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
