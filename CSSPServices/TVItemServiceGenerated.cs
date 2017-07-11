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
        public TVItemService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
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
            TVItem tvItem = validationContext.ObjectInstance as TVItem;

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVItemID has no Range Attribute

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
            //TVLevel (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVLevel has no Range Attribute

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
            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath), new[] { ModelsRes.TVItemTVPath });
            }

            //TVPath has no StringLength Attribute

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
                //Error: Type not implemented [TVType] of type [TVTypeEnum]

                //Error: Type not implemented [TVType] of type [TVTypeEnum]
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
            //ParentID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //ParentID has no Range Attribute

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
            //IsActive (bool) is required but no testing needed 

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
            if (tvItem.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLastUpdateDate_UTC), new[] { ModelsRes.TVItemLastUpdateDate_UTC });
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
            if (tvItem.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLastUpdateDate_UTC, "1980"), new[] { ModelsRes.TVItemLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

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
            if (!((from c in db.TVItems where c.TVItemID == tvItem.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLastUpdateContactTVItemID, tvItem.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.TVItemLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
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
