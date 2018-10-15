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
        public MWQMSiteService(Query query, CSSPDBContext db, int ContactID)
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

                if (!(from c in db.MWQMSites select c).Where(c => c.MWQMSiteID == mwqmSite.MWQMSiteID).Any())
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
            return (from c in db.MWQMSites
                    where c.MWQMSiteID == MWQMSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSite> GetMWQMSiteList()
        {
            IQueryable<MWQMSite> MWQMSiteQuery = (from c in db.MWQMSites select c);

            MWQMSiteQuery = EnhanceQueryStatements<MWQMSite>(MWQMSiteQuery) as IQueryable<MWQMSite>;

            return MWQMSiteQuery;
        }
        public MWQMSiteExtraA GetMWQMSiteExtraAWithMWQMSiteID(int MWQMSiteID)
        {
            return FillMWQMSiteExtraA().Where(c => c.MWQMSiteID == MWQMSiteID).FirstOrDefault();

        }
        public IQueryable<MWQMSiteExtraA> GetMWQMSiteExtraAList()
        {
            IQueryable<MWQMSiteExtraA> MWQMSiteExtraAQuery = FillMWQMSiteExtraA();

            MWQMSiteExtraAQuery = EnhanceQueryStatements<MWQMSiteExtraA>(MWQMSiteExtraAQuery) as IQueryable<MWQMSiteExtraA>;

            return MWQMSiteExtraAQuery;
        }
        public MWQMSiteExtraB GetMWQMSiteExtraBWithMWQMSiteID(int MWQMSiteID)
        {
            return FillMWQMSiteExtraB().Where(c => c.MWQMSiteID == MWQMSiteID).FirstOrDefault();

        }
        public IQueryable<MWQMSiteExtraB> GetMWQMSiteExtraBList()
        {
            IQueryable<MWQMSiteExtraB> MWQMSiteExtraBQuery = FillMWQMSiteExtraB();

            MWQMSiteExtraBQuery = EnhanceQueryStatements<MWQMSiteExtraB>(MWQMSiteExtraBQuery) as IQueryable<MWQMSiteExtraB>;

            return MWQMSiteExtraBQuery;
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
        #endregion Functions public Generated CRUD

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
