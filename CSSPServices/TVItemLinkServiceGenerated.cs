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
    public partial class TVItemLinkService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemLinkService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            TVItemLink tvItemLink = validationContext.ObjectInstance as TVItemLink;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tvItemLink.TVItemLinkID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVItemLinkID), new[] { "TVItemLinkID" });
                }
            }

            //TVItemLinkID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //FromTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemFromTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.FromTVItemID select c).FirstOrDefault();

            if (TVItemFromTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), new[] { "FromTVItemID" });
            }

            //ToTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemToTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.ToTVItemID select c).FirstOrDefault();

            if (TVItemToTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), new[] { "ToTVItemID" });
            }

            retStr = enums.TVTypeOK(tvItemLink.FromTVType);
            if (tvItemLink.FromTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkFromTVType), new[] { "FromTVType" });
            }

            retStr = enums.TVTypeOK(tvItemLink.ToTVType);
            if (tvItemLink.ToTVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkToTVType), new[] { "ToTVType" });
            }

            if (tvItemLink.StartDateTime_Local != null && ((DateTime)tvItemLink.StartDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLinkStartDateTime_Local, "1980"), new[] { ModelsRes.TVItemLinkStartDateTime_Local });
            }

            if (tvItemLink.EndDateTime_Local != null && ((DateTime)tvItemLink.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLinkEndDateTime_Local, "1980"), new[] { ModelsRes.TVItemLinkEndDateTime_Local });
            }

            if (tvItemLink.StartDateTime_Local > tvItemLink.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.TVItemLinkEndDateTime_Local, ModelsRes.TVItemLinkStartDateTime_Local), new[] { ModelsRes.TVItemLinkEndDateTime_Local });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemLink.Ordinal < 0 || tvItemLink.Ordinal > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100"), new[] { "Ordinal" });
            }

            //TVLevel (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (tvItemLink.TVLevel < 0 || tvItemLink.TVLevel > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100"), new[] { "TVLevel" });
            }

            if (string.IsNullOrWhiteSpace(tvItemLink.TVPath))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVPath), new[] { "TVPath" });
            }

            if (!string.IsNullOrWhiteSpace(tvItemLink.TVPath) && tvItemLink.TVPath.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkTVPath, "250"), new[] { "TVPath" });
            }

            if (tvItemLink.ParentTVItemLinkID != null)
            {
                TVItem TVItemParentTVItemLinkID = (from c in db.TVItems where c.TVItemID == tvItemLink.ParentTVItemLinkID select c).FirstOrDefault();

                if (TVItemParentTVItemLinkID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkParentTVItemLinkID, tvItemLink.ParentTVItemLinkID.ToString()), new[] { "ParentTVItemLinkID" });
                }
            }

            if (tvItemLink.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tvItemLink.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TVItemLinkLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tvItemLink.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkLastUpdateContactTVItemID, tvItemLink.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public bool Add(TVItemLink tvItemLink)
        {
            tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Create);
            if (tvItemLink.ValidationResults.Count() > 0) return false;

            db.TVItemLinks.Add(tvItemLink);

            if (!TryToSave(tvItemLink)) return false;

            return true;
        }
        public bool AddRange(List<TVItemLink> tvItemLinkList)
        {
            foreach (TVItemLink tvItemLink in tvItemLinkList)
            {
                tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Create);
                if (tvItemLink.ValidationResults.Count() > 0) return false;
            }

            db.TVItemLinks.AddRange(tvItemLinkList);

            if (!TryToSaveRange(tvItemLinkList)) return false;

            return true;
        }
        public bool Delete(TVItemLink tvItemLink)
        {
            if (!db.TVItemLinks.Where(c => c.TVItemLinkID == tvItemLink.TVItemLinkID).Any())
            {
                tvItemLink.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkID", tvItemLink.TVItemLinkID.ToString())) }.AsEnumerable();
                return false;
            }

            db.TVItemLinks.Remove(tvItemLink);

            if (!TryToSave(tvItemLink)) return false;

            return true;
        }
        public bool DeleteRange(List<TVItemLink> tvItemLinkList)
        {
            foreach (TVItemLink tvItemLink in tvItemLinkList)
            {
                if (!db.TVItemLinks.Where(c => c.TVItemLinkID == tvItemLink.TVItemLinkID).Any())
                {
                    tvItemLinkList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "TVItemLink", "TVItemLinkID", tvItemLink.TVItemLinkID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.TVItemLinks.RemoveRange(tvItemLinkList);

            if (!TryToSaveRange(tvItemLinkList)) return false;

            return true;
        }
        public bool Update(TVItemLink tvItemLink)
        {
            tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Update);
            if (tvItemLink.ValidationResults.Count() > 0) return false;

            db.TVItemLinks.Update(tvItemLink);

            if (!TryToSave(tvItemLink)) return false;

            return true;
        }
        public bool UpdateRange(List<TVItemLink> tvItemLinkList)
        {
            foreach (TVItemLink tvItemLink in tvItemLinkList)
            {
                tvItemLink.ValidationResults = Validate(new ValidationContext(tvItemLink), ActionDBTypeEnum.Update);
                if (tvItemLink.ValidationResults.Count() > 0) return false;
            }
            db.TVItemLinks.UpdateRange(tvItemLinkList);

            if (!TryToSaveRange(tvItemLinkList)) return false;

            return true;
        }
        public IQueryable<TVItemLink> GetRead()
        {
            return db.TVItemLinks.AsNoTracking();
        }
        public IQueryable<TVItemLink> GetEdit()
        {
            return db.TVItemLinks;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(TVItemLink tvItemLink)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLink.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<TVItemLink> tvItemLinkList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tvItemLinkList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
