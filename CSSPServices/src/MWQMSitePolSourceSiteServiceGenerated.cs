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
    ///     <para>bonjour MWQMSitePolSourceSite</para>
    /// </summary>
    public partial class MWQMSitePolSourceSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSitePolSourceSiteService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSitePolSourceSite mwqmSitePolSourceSite = validationContext.ObjectInstance as MWQMSitePolSourceSite;
            mwqmSitePolSourceSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSitePolSourceSite.MWQMSitePolSourceSiteID == 0)
                {
                    mwqmSitePolSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteMWQMSitePolSourceSiteID"), new[] { "MWQMSitePolSourceSiteID" });
                }

                if (!(from c in db.MWQMSitePolSourceSites select c).Where(c => c.MWQMSitePolSourceSiteID == mwqmSitePolSourceSite.MWQMSitePolSourceSiteID).Any())
                {
                    mwqmSitePolSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSitePolSourceSite", "MWQMSitePolSourceSiteMWQMSitePolSourceSiteID", mwqmSitePolSourceSite.MWQMSitePolSourceSiteID.ToString()), new[] { "MWQMSitePolSourceSiteID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSitePolSourceSite.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSitePolSourceSiteMWQMSiteTVItemID", mwqmSitePolSourceSite.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    mwqmSitePolSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSitePolSourceSiteMWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            TVItem TVItemPolSourceSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSitePolSourceSite.PolSourceSiteTVItemID select c).FirstOrDefault();

            if (TVItemPolSourceSiteTVItemID == null)
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSitePolSourceSitePolSourceSiteTVItemID", mwqmSitePolSourceSite.PolSourceSiteTVItemID.ToString()), new[] { "PolSourceSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.PolSourceSite,
                };
                if (!AllowableTVTypes.Contains(TVItemPolSourceSiteTVItemID.TVType))
                {
                    mwqmSitePolSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSitePolSourceSitePolSourceSiteTVItemID", "PolSourceSite"), new[] { "PolSourceSiteTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)mwqmSitePolSourceSite.TVType);
            if (mwqmSitePolSourceSite.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteTVType"), new[] { "TVType" });
            }

            if (string.IsNullOrWhiteSpace(mwqmSitePolSourceSite.LinkReasons))
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteLinkReasons"), new[] { "LinkReasons" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSitePolSourceSite.LinkReasons) && mwqmSitePolSourceSite.LinkReasons.Length > 4000)
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSitePolSourceSiteLinkReasons", "4000"), new[] { "LinkReasons" });
            }

            if (mwqmSitePolSourceSite.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSitePolSourceSiteLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSitePolSourceSite.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSitePolSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSitePolSourceSiteLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSitePolSourceSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSitePolSourceSiteLastUpdateContactTVItemID", mwqmSitePolSourceSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSitePolSourceSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSitePolSourceSiteLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mwqmSitePolSourceSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSitePolSourceSite GetMWQMSitePolSourceSiteWithMWQMSitePolSourceSiteID(int MWQMSitePolSourceSiteID)
        {
            return (from c in db.MWQMSitePolSourceSites
                    where c.MWQMSitePolSourceSiteID == MWQMSitePolSourceSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSitePolSourceSite> GetMWQMSitePolSourceSiteList()
        {
            IQueryable<MWQMSitePolSourceSite> MWQMSitePolSourceSiteQuery = (from c in db.MWQMSitePolSourceSites select c);

            MWQMSitePolSourceSiteQuery = EnhanceQueryStatements<MWQMSitePolSourceSite>(MWQMSitePolSourceSiteQuery) as IQueryable<MWQMSitePolSourceSite>;

            return MWQMSitePolSourceSiteQuery;
        }
        public MWQMSitePolSourceSiteExtraA GetMWQMSitePolSourceSiteExtraAWithMWQMSitePolSourceSiteID(int MWQMSitePolSourceSiteID)
        {
            return FillMWQMSitePolSourceSiteExtraA().Where(c => c.MWQMSitePolSourceSiteID == MWQMSitePolSourceSiteID).FirstOrDefault();

        }
        public IQueryable<MWQMSitePolSourceSiteExtraA> GetMWQMSitePolSourceSiteExtraAList()
        {
            IQueryable<MWQMSitePolSourceSiteExtraA> MWQMSitePolSourceSiteExtraAQuery = FillMWQMSitePolSourceSiteExtraA();

            MWQMSitePolSourceSiteExtraAQuery = EnhanceQueryStatements<MWQMSitePolSourceSiteExtraA>(MWQMSitePolSourceSiteExtraAQuery) as IQueryable<MWQMSitePolSourceSiteExtraA>;

            return MWQMSitePolSourceSiteExtraAQuery;
        }
        public MWQMSitePolSourceSiteExtraB GetMWQMSitePolSourceSiteExtraBWithMWQMSitePolSourceSiteID(int MWQMSitePolSourceSiteID)
        {
            return FillMWQMSitePolSourceSiteExtraB().Where(c => c.MWQMSitePolSourceSiteID == MWQMSitePolSourceSiteID).FirstOrDefault();

        }
        public IQueryable<MWQMSitePolSourceSiteExtraB> GetMWQMSitePolSourceSiteExtraBList()
        {
            IQueryable<MWQMSitePolSourceSiteExtraB> MWQMSitePolSourceSiteExtraBQuery = FillMWQMSitePolSourceSiteExtraB();

            MWQMSitePolSourceSiteExtraBQuery = EnhanceQueryStatements<MWQMSitePolSourceSiteExtraB>(MWQMSitePolSourceSiteExtraBQuery) as IQueryable<MWQMSitePolSourceSiteExtraB>;

            return MWQMSitePolSourceSiteExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSitePolSourceSite mwqmSitePolSourceSite)
        {
            mwqmSitePolSourceSite.ValidationResults = Validate(new ValidationContext(mwqmSitePolSourceSite), ActionDBTypeEnum.Create);
            if (mwqmSitePolSourceSite.ValidationResults.Count() > 0) return false;

            db.MWQMSitePolSourceSites.Add(mwqmSitePolSourceSite);

            if (!TryToSave(mwqmSitePolSourceSite)) return false;

            return true;
        }
        public bool Delete(MWQMSitePolSourceSite mwqmSitePolSourceSite)
        {
            mwqmSitePolSourceSite.ValidationResults = Validate(new ValidationContext(mwqmSitePolSourceSite), ActionDBTypeEnum.Delete);
            if (mwqmSitePolSourceSite.ValidationResults.Count() > 0) return false;

            db.MWQMSitePolSourceSites.Remove(mwqmSitePolSourceSite);

            if (!TryToSave(mwqmSitePolSourceSite)) return false;

            return true;
        }
        public bool Update(MWQMSitePolSourceSite mwqmSitePolSourceSite)
        {
            mwqmSitePolSourceSite.ValidationResults = Validate(new ValidationContext(mwqmSitePolSourceSite), ActionDBTypeEnum.Update);
            if (mwqmSitePolSourceSite.ValidationResults.Count() > 0) return false;

            db.MWQMSitePolSourceSites.Update(mwqmSitePolSourceSite);

            if (!TryToSave(mwqmSitePolSourceSite)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMSitePolSourceSite mwqmSitePolSourceSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSitePolSourceSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
