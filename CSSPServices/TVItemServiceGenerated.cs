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
    public partial class TVItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
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
            TVItem tvItem = validationContext.ObjectInstance as TVItem;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItem.TVItemID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVItemID), new[] { ModelsRes.TVItemTVItemID });
                }
            }

            //TVLevel (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath), new[] { ModelsRes.TVItemTVPath });
            }

            retStr = enums.TVTypeOK(tvItem.TVType);
            if (tvItem.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVType), new[] { ModelsRes.TVItemTVType });
            }

            //ParentID (int) is required but no testing needed as it is automatically set to 0

            //IsActive (bool) is required but no testing needed 

            if (tvItem.LastUpdateDate_UTC == null || tvItem.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLastUpdateDate_UTC), new[] { ModelsRes.TVItemLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (tvItem.TVLevel < 0 || tvItem.TVLevel > 12)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "12"), new[] { ModelsRes.TVItemTVLevel });
            }

            if (!string.IsNullOrWhiteSpace(tvItem.TVPath) && (tvItem.TVPath.Length < 2 || tvItem.TVPath.Length > 250))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemTVPath, "2", "250"), new[] { ModelsRes.TVItemTVPath });
            }

            if (tvItem.ParentID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemParentID, "1"), new[] { ModelsRes.TVItemParentID });
            }

            if (tvItem.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLastUpdateContactTVItemID, "1"), new[] { ModelsRes.TVItemLastUpdateContactTVItemID });
            }

            if (DatabaseType > DatabaseTypeEnum.MemoryNoDBShape)
            {
                if (tvItem.TVType == TVTypeEnum.Root)
                {
                    if (GetRead().Count() > 0)
                    {
                        yield return new ValidationResult(ServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ModelsRes.TVItemTVItemID });
                    }
                }
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Create);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Add(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        public bool AddRange(List<TVItem> tvItemList)
        {
            foreach (TVItem tvItem in tvItemList)
            {
                tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Create);
                if (tvItem.ValidationResults.Count() > 0) return false;
            }

            db.TVItems.AddRange(tvItemList);

            if (!TryToSaveRange(tvItemList)) return false;

            return true;
        }
        public bool Delete(TVItem tvItem)
        {
            if (!db.TVItems.Where(c => c.TVItemID == tvItem.TVItemID).Any())
            {
                tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItem.TVItemID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItems.Remove(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItem> tvItemList)
        {
            foreach (TVItem tvItem in tvItemList)
            {
                if (!db.TVItems.Where(c => c.TVItemID == tvItem.TVItemID).Any())
                {
                    tvItemList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItem", "TVItemID", tvItem.TVItemID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItems.RemoveRange(tvItemList);

            if (!TryToSaveRange(tvItemList)) return false;

            return true;
        }
        public bool Update(TVItem tvItem)
        {
            tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Update);
            if (tvItem.ValidationResults.Count() > 0) return false;

            db.TVItems.Update(tvItem);

            if (!TryToSave(tvItem)) return false;

            return true;
        }
        public bool UpdateRange(List<TVItem> tvItemList)
        {
            foreach (TVItem tvItem in tvItemList)
            {
                tvItem.ValidationResults = Validate(new ValidationContext(tvItem), ActionDBTypeEnum.Update);
                if (tvItem.ValidationResults.Count() > 0) return false;
            }
            db.TVItems.UpdateRange(tvItemList);

            if (!TryToSaveRange(tvItemList)) return false;

            return true;
        }
        public IQueryable<TVItem> GetRead()
        {
            return db.TVItems.AsNoTracking();
        }
        public IQueryable<TVItem> GetEdit()
        {
            return db.TVItems;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVItem tvItem)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItem.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVItem> tvItemList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
