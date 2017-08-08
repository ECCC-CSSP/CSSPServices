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
    public partial class MWQMSiteStartEndDateService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSiteStartEndDate mwqmSiteStartEndDate = validationContext.ObjectInstance as MWQMSiteStartEndDate;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSiteStartEndDate.MWQMSiteStartEndDateID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID), new[] { "MWQMSiteStartEndDateID" });
                }
            }

            //MWQMSiteStartEndDateID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (mwqmSiteStartEndDate.StartDate.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateStartDate), new[] { "StartDate" });
            }
            else
            {
                if (mwqmSiteStartEndDate.StartDate.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSiteStartEndDateStartDate, "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmSiteStartEndDate.EndDate != null && ((DateTime)mwqmSiteStartEndDate.EndDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSiteStartEndDateEndDate, "1980"), new[] { ModelsRes.MWQMSiteStartEndDateEndDate });
            }

            if (mwqmSiteStartEndDate.StartDate > mwqmSiteStartEndDate.EndDate)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.MWQMSiteStartEndDateEndDate, ModelsRes.MWQMSiteStartEndDateStartDate), new[] { ModelsRes.MWQMSiteStartEndDateEndDate });
            }

            if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDate.MWQMSiteTVText) && mwqmSiteStartEndDate.MWQMSiteTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVText, "200"), new[] { "MWQMSiteTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDate.LastUpdateContactTVText) && mwqmSiteStartEndDate.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSiteStartEndDate GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID)
        {
            IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery = (from c in GetRead()
                                                where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                                                select c);

            return FillMWQMSiteStartEndDate(mwqmSiteStartEndDateQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Create);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0) return false;

            db.MWQMSiteStartEndDates.Add(mwqmSiteStartEndDate);

            if (!TryToSave(mwqmSiteStartEndDate)) return false;

            return true;
        }
        public bool AddRange(List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList)
        {
            foreach (MWQMSiteStartEndDate mwqmSiteStartEndDate in mwqmSiteStartEndDateList)
            {
                mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Create);
                if (mwqmSiteStartEndDate.ValidationResults.Count() > 0) return false;
            }

            db.MWQMSiteStartEndDates.AddRange(mwqmSiteStartEndDateList);

            if (!TryToSaveRange(mwqmSiteStartEndDateList)) return false;

            return true;
        }
        public bool Delete(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            if (!db.MWQMSiteStartEndDates.Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).Any())
            {
                mwqmSiteStartEndDate.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateID", mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSiteStartEndDates.Remove(mwqmSiteStartEndDate);

            if (!TryToSave(mwqmSiteStartEndDate)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList)
        {
            foreach (MWQMSiteStartEndDate mwqmSiteStartEndDate in mwqmSiteStartEndDateList)
            {
                if (!db.MWQMSiteStartEndDates.Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).Any())
                {
                    mwqmSiteStartEndDateList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateID", mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMSiteStartEndDates.RemoveRange(mwqmSiteStartEndDateList);

            if (!TryToSaveRange(mwqmSiteStartEndDateList)) return false;

            return true;
        }
        public bool Update(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Update);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0) return false;

            db.MWQMSiteStartEndDates.Update(mwqmSiteStartEndDate);

            if (!TryToSave(mwqmSiteStartEndDate)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList)
        {
            foreach (MWQMSiteStartEndDate mwqmSiteStartEndDate in mwqmSiteStartEndDateList)
            {
                mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Update);
                if (mwqmSiteStartEndDate.ValidationResults.Count() > 0) return false;
            }
            db.MWQMSiteStartEndDates.UpdateRange(mwqmSiteStartEndDateList);

            if (!TryToSaveRange(mwqmSiteStartEndDateList)) return false;

            return true;
        }
        public IQueryable<MWQMSiteStartEndDate> GetRead()
        {
            return db.MWQMSiteStartEndDates.AsNoTracking();
        }
        public IQueryable<MWQMSiteStartEndDate> GetEdit()
        {
            return db.MWQMSiteStartEndDates;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMSiteStartEndDate> FillMWQMSiteStartEndDate(IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery)
        {
            List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList = (from c in mwqmSiteStartEndDateQuery
                                         let MWQMSiteTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.MWQMSiteTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMSiteStartEndDate
                                         {
                                             MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                                             MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                             StartDate = c.StartDate,
                                             EndDate = c.EndDate,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             MWQMSiteTVText = MWQMSiteTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return MWQMSiteStartEndDateList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSiteStartEndDate.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSiteStartEndDateList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
