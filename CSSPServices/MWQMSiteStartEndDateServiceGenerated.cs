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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            MWQMSiteStartEndDate mwqmSiteStartEndDate = validationContext.ObjectInstance as MWQMSiteStartEndDate;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSiteStartEndDate.MWQMSiteStartEndDateID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID), new[] { ModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID });
                }
            }

            //MWQMSiteTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (mwqmSiteStartEndDate.StartDate == null || mwqmSiteStartEndDate.StartDate.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateStartDate), new[] { ModelsRes.MWQMSiteStartEndDateStartDate });
            }

            if (mwqmSiteStartEndDate.LastUpdateDate_UTC == null || mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC), new[] { ModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (mwqmSiteStartEndDate.MWQMSiteTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "1"), new[] { ModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID });
            }

            if (mwqmSiteStartEndDate.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID });
            }


        }
        #endregion Validation

        #region Functions public
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
        #endregion Functions public

        #region Functions private
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
        #endregion Functions private
    }
}
