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
    /// <summary>
    ///     <para>bonjour MWQMSiteStartEndDate</para>
    /// </summary>
    public partial class MWQMSiteStartEndDateService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSiteStartEndDate mwqmSiteStartEndDate = validationContext.ObjectInstance as MWQMSiteStartEndDate;
            mwqmSiteStartEndDate.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSiteStartEndDate.MWQMSiteStartEndDateID == 0)
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateMWQMSiteStartEndDateID"), new[] { "MWQMSiteStartEndDateID" });
                }

                if (!(from c in db.MWQMSiteStartEndDates select c).Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).Any())
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSiteStartEndDate", "MWQMSiteStartEndDateMWQMSiteStartEndDateID", mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), new[] { "MWQMSiteStartEndDateID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteStartEndDateMWQMSiteTVItemID", mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteStartEndDateMWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (mwqmSiteStartEndDate.StartDate.Year == 1)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateStartDate"), new[] { "StartDate" });
            }
            else
            {
                if (mwqmSiteStartEndDate.StartDate.Year < 1980)
                {
                mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteStartEndDateStartDate", "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmSiteStartEndDate.EndDate != null && ((DateTime)mwqmSiteStartEndDate.EndDate).Year < 1980)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteStartEndDateEndDate", "1980"), new[] { "MWQMSiteStartEndDateEndDate" });
            }

            if (mwqmSiteStartEndDate.StartDate > mwqmSiteStartEndDate.EndDate)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "MWQMSiteStartEndDateEndDate", "MWQMSiteStartEndDateStartDate"), new[] { "MWQMSiteStartEndDateEndDate" });
            }

            if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteStartEndDateLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteStartEndDateLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteStartEndDateLastUpdateContactTVItemID", mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteStartEndDateLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSiteStartEndDate GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID)
        {
            return (from c in db.MWQMSiteStartEndDates
                    where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSiteStartEndDate> GetMWQMSiteStartEndDateList()
        {
            IQueryable<MWQMSiteStartEndDate> MWQMSiteStartEndDateQuery = (from c in db.MWQMSiteStartEndDates select c);

            MWQMSiteStartEndDateQuery = EnhanceQueryStatements<MWQMSiteStartEndDate>(MWQMSiteStartEndDateQuery) as IQueryable<MWQMSiteStartEndDate>;

            return MWQMSiteStartEndDateQuery;
        }
        public MWQMSiteStartEndDate_A GetMWQMSiteStartEndDate_AWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID)
        {
            return FillMWQMSiteStartEndDate_A().Where(c => c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID).FirstOrDefault();

        }
        public IQueryable<MWQMSiteStartEndDate_A> GetMWQMSiteStartEndDate_AList()
        {
            IQueryable<MWQMSiteStartEndDate_A> MWQMSiteStartEndDate_AQuery = FillMWQMSiteStartEndDate_A();

            MWQMSiteStartEndDate_AQuery = EnhanceQueryStatements<MWQMSiteStartEndDate_A>(MWQMSiteStartEndDate_AQuery) as IQueryable<MWQMSiteStartEndDate_A>;

            return MWQMSiteStartEndDate_AQuery;
        }
        public MWQMSiteStartEndDate_B GetMWQMSiteStartEndDate_BWithMWQMSiteStartEndDateID(int MWQMSiteStartEndDateID)
        {
            return FillMWQMSiteStartEndDate_B().Where(c => c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID).FirstOrDefault();

        }
        public IQueryable<MWQMSiteStartEndDate_B> GetMWQMSiteStartEndDate_BList()
        {
            IQueryable<MWQMSiteStartEndDate_B> MWQMSiteStartEndDate_BQuery = FillMWQMSiteStartEndDate_B();

            MWQMSiteStartEndDate_BQuery = EnhanceQueryStatements<MWQMSiteStartEndDate_B>(MWQMSiteStartEndDate_BQuery) as IQueryable<MWQMSiteStartEndDate_B>;

            return MWQMSiteStartEndDate_BQuery;
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
        public bool Delete(MWQMSiteStartEndDate mwqmSiteStartEndDate)
        {
            mwqmSiteStartEndDate.ValidationResults = Validate(new ValidationContext(mwqmSiteStartEndDate), ActionDBTypeEnum.Delete);
            if (mwqmSiteStartEndDate.ValidationResults.Count() > 0) return false;

            db.MWQMSiteStartEndDates.Remove(mwqmSiteStartEndDate);

            if (!TryToSave(mwqmSiteStartEndDate)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
