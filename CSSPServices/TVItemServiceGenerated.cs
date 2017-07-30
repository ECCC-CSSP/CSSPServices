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
        #endregion Properties

        #region Constructors
        public TVItemService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItem tvItem = validationContext.ObjectInstance as TVItem;

            if (db.Database.GetDbConnection().ConnectionString.Contains("TestDB") || db.Database.GetDbConnection().ConnectionString.Contains("TestDB"))
            {
                if (tvItem.TVType == TVTypeEnum.Root)
                {
                    if (GetRead().Count() > 0)
                    {
                        yield return new ValidationResult(ServicesRes.TVItemRootShouldBeTheFirstOneAdded, new[] { ModelsRes.TVItemTVItemID });
                    }
                }
            }

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItem.TVItemID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVItemID), new[] { "TVItemID" });
                }
            }

            //TVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TVLevel (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItem.TVLevel < 0 || tvItem.TVLevel > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItem.TVPath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItem.TVPath) && tvItem.TVPath.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemTVPath, "250"), new[] { "TVPath" });
            }

            retStr = enums.TVTypeOK(tvItem.TVType);
            if (tvItem.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVType), new[] { "TVType" });
            }

            //ParentID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemParentID = (from c in db.TVItems where c.TVItemID == tvItem.ParentID select c).FirstOrDefault();

                if (TVItemParentID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemParentID, tvItem.ParentID.ToString()), new[] { "ParentID" });
                }
            }

            //IsActive (bool) is required but no testing needed 

            if (tvItem.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItem.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItem.TVType != TVTypeEnum.Root)
            {
                TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItem.LastUpdateContactTVItemID select c).FirstOrDefault();

                if (TVItemLastUpdateContactTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLastUpdateContactTVItemID, tvItem.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
                }
                else
                {
                    if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                    }
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
