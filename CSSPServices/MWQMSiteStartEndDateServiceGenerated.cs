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
        public MWQMSiteStartEndDateService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID), new[] { "MWQMSiteStartEndDateID" });
                }

                if (!GetRead().Where(c => c.MWQMSiteStartEndDateID == mwqmSiteStartEndDate.MWQMSiteStartEndDateID).Any())
                {
                    mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSiteStartEndDate, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteStartEndDateID, mwqmSiteStartEndDate.MWQMSiteStartEndDateID.ToString()), new[] { "MWQMSiteStartEndDateID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, mwqmSiteStartEndDate.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteStartEndDateMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (mwqmSiteStartEndDate.StartDate.Year == 1)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateStartDate), new[] { "StartDate" });
            }
            else
            {
                if (mwqmSiteStartEndDate.StartDate.Year < 1980)
                {
                mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateStartDate, "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmSiteStartEndDate.EndDate != null && ((DateTime)mwqmSiteStartEndDate.EndDate).Year < 1980)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateEndDate, "1980"), new[] { CSSPModelsRes.MWQMSiteStartEndDateEndDate });
            }

            if (mwqmSiteStartEndDate.StartDate > mwqmSiteStartEndDate.EndDate)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateEndDate, CSSPModelsRes.MWQMSiteStartEndDateStartDate), new[] { CSSPModelsRes.MWQMSiteStartEndDateEndDate });
            }

            if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSiteStartEndDate.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSiteStartEndDate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSiteStartEndDate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSiteStartEndDate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, mwqmSiteStartEndDate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSiteStartEndDateLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmSiteStartEndDateQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMWQMSiteStartEndDateWeb(mwqmSiteStartEndDateQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMSiteStartEndDateReport(mwqmSiteStartEndDateQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMSiteStartEndDate> GetMWQMSiteStartEndDateList()
        {
            IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        mwqmSiteStartEndDateQuery = EnhanceQueryStatements<MWQMSiteStartEndDate>(mwqmSiteStartEndDateQuery) as IQueryable<MWQMSiteStartEndDate>;

                        return mwqmSiteStartEndDateQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        mwqmSiteStartEndDateQuery = FillMWQMSiteStartEndDateWeb(mwqmSiteStartEndDateQuery);

                        mwqmSiteStartEndDateQuery = EnhanceQueryStatements<MWQMSiteStartEndDate>(mwqmSiteStartEndDateQuery) as IQueryable<MWQMSiteStartEndDate>;

                        return mwqmSiteStartEndDateQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        mwqmSiteStartEndDateQuery = FillMWQMSiteStartEndDateReport(mwqmSiteStartEndDateQuery);

                        mwqmSiteStartEndDateQuery = EnhanceQueryStatements<MWQMSiteStartEndDate>(mwqmSiteStartEndDateQuery) as IQueryable<MWQMSiteStartEndDate>;

                        return mwqmSiteStartEndDateQuery;
                    }
                default:
                    {
                        mwqmSiteStartEndDateQuery = mwqmSiteStartEndDateQuery.Where(c => c.MWQMSiteStartEndDateID == 0);

                        return mwqmSiteStartEndDateQuery;
                    }
            }
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
        public IQueryable<MWQMSiteStartEndDate> GetRead()
        {
            IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery = db.MWQMSiteStartEndDates.AsNoTracking();

            return mwqmSiteStartEndDateQuery;
        }
        public IQueryable<MWQMSiteStartEndDate> GetEdit()
        {
            IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery = db.MWQMSiteStartEndDates;

            return mwqmSiteStartEndDateQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSiteStartEndDateFillWeb
        private IQueryable<MWQMSiteStartEndDate> FillMWQMSiteStartEndDateWeb(IQueryable<MWQMSiteStartEndDate> mwqmSiteStartEndDateQuery)
        {
            mwqmSiteStartEndDateQuery = (from c in mwqmSiteStartEndDateQuery
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
                        MWQMSiteStartEndDateWeb = new MWQMSiteStartEndDateWeb
                        {
                            MWQMSiteTVText = MWQMSiteTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        MWQMSiteStartEndDateReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmSiteStartEndDateQuery;
        }
        #endregion Functions private Generated MWQMSiteStartEndDateFillWeb

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
