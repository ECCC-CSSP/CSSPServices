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
    ///     <para>bonjour MWQMSite</para>
    /// </summary>
    public partial class MWQMSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSiteService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSite mwqmSite = validationContext.ObjectInstance as MWQMSite;
            mwqmSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSite.MWQMSiteID == 0)
                {
                    mwqmSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteID"), new[] { "MWQMSiteID" });
                }

                if (!GetRead().Where(c => c.MWQMSiteID == mwqmSite.MWQMSiteID).Any())
                {
                    mwqmSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSite", "MWQMSiteMWQMSiteID", mwqmSite.MWQMSiteID.ToString()), new[] { "MWQMSiteID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSite.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteMWQMSiteTVItemID", mwqmSite.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    mwqmSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteMWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteNumber))
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteNumber"), new[] { "MWQMSiteNumber" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteNumber) && mwqmSite.MWQMSiteNumber.Length > 8)
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSiteMWQMSiteNumber", "8"), new[] { "MWQMSiteNumber" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteDescription))
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteDescription"), new[] { "MWQMSiteDescription" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSite.MWQMSiteDescription) && mwqmSite.MWQMSiteDescription.Length > 200)
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSiteMWQMSiteDescription", "200"), new[] { "MWQMSiteDescription" });
            }

            retStr = enums.EnumTypeOK(typeof(MWQMSiteLatestClassificationEnum), (int?)mwqmSite.MWQMSiteLatestClassification);
            if (mwqmSite.MWQMSiteLatestClassification == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteMWQMSiteLatestClassification"), new[] { "MWQMSiteLatestClassification" });
            }

            if (mwqmSite.Ordinal < 0 || mwqmSite.Ordinal > 1000)
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMSiteOrdinal", "0", "1000"), new[] { "Ordinal" });
            }

            if (mwqmSite.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSiteLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSite.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSiteLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSiteLastUpdateContactTVItemID", mwqmSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSiteLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSite GetMWQMSiteWithMWQMSiteID(int MWQMSiteID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.MWQMSiteID == MWQMSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSite> GetMWQMSiteList()
        {
            IQueryable<MWQMSite> MWQMSiteQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            MWQMSiteQuery = EnhanceQueryStatements<MWQMSite>(MWQMSiteQuery) as IQueryable<MWQMSite>;

            return MWQMSiteQuery;
        }
        public MWQMSiteWeb GetMWQMSiteWebWithMWQMSiteID(int MWQMSiteID)
        {
            return FillMWQMSiteWeb().FirstOrDefault();

        }
        public IQueryable<MWQMSiteWeb> GetMWQMSiteWebList()
        {
            IQueryable<MWQMSiteWeb> MWQMSiteWebQuery = FillMWQMSiteWeb();

            MWQMSiteWebQuery = EnhanceQueryStatements<MWQMSiteWeb>(MWQMSiteWebQuery) as IQueryable<MWQMSiteWeb>;

            return MWQMSiteWebQuery;
        }
        public MWQMSiteReport GetMWQMSiteReportWithMWQMSiteID(int MWQMSiteID)
        {
            return FillMWQMSiteReport().FirstOrDefault();

        }
        public IQueryable<MWQMSiteReport> GetMWQMSiteReportList()
        {
            IQueryable<MWQMSiteReport> MWQMSiteReportQuery = FillMWQMSiteReport();

            MWQMSiteReportQuery = EnhanceQueryStatements<MWQMSiteReport>(MWQMSiteReportQuery) as IQueryable<MWQMSiteReport>;

            return MWQMSiteReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSite mwqmSite)
        {
            mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Create);
            if (mwqmSite.ValidationResults.Count() > 0) return false;

            db.MWQMSites.Add(mwqmSite);

            if (!TryToSave(mwqmSite)) return false;

            return true;
        }
        public bool Delete(MWQMSite mwqmSite)
        {
            mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Delete);
            if (mwqmSite.ValidationResults.Count() > 0) return false;

            db.MWQMSites.Remove(mwqmSite);

            if (!TryToSave(mwqmSite)) return false;

            return true;
        }
        public bool Update(MWQMSite mwqmSite)
        {
            mwqmSite.ValidationResults = Validate(new ValidationContext(mwqmSite), ActionDBTypeEnum.Update);
            if (mwqmSite.ValidationResults.Count() > 0) return false;

            db.MWQMSites.Update(mwqmSite);

            if (!TryToSave(mwqmSite)) return false;

            return true;
        }
        public IQueryable<MWQMSite> GetRead()
        {
            IQueryable<MWQMSite> mwqmSiteQuery = db.MWQMSites.AsNoTracking();

            return mwqmSiteQuery;
        }
        public IQueryable<MWQMSite> GetEdit()
        {
            IQueryable<MWQMSite> mwqmSiteQuery = db.MWQMSites;

            return mwqmSiteQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSiteFillWeb
        private IQueryable<MWQMSiteWeb> FillMWQMSiteWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> MWQMSiteLatestClassificationEnumList = enums.GetEnumTextOrderedList(typeof(MWQMSiteLatestClassificationEnum));

             IQueryable<MWQMSiteWeb>  MWQMSiteWebQuery = (from c in db.MWQMSites
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSiteWeb
                    {
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMSiteLatestClassificationText = (from e in MWQMSiteLatestClassificationEnumList
                                where e.EnumID == (int?)c.MWQMSiteLatestClassification
                                select e.EnumText).FirstOrDefault(),
                        MWQMSiteID = c.MWQMSiteID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        MWQMSiteNumber = c.MWQMSiteNumber,
                        MWQMSiteDescription = c.MWQMSiteDescription,
                        MWQMSiteLatestClassification = c.MWQMSiteLatestClassification,
                        Ordinal = c.Ordinal,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MWQMSiteWebQuery;
        }
        #endregion Functions private Generated MWQMSiteFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMSite mwqmSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}