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
    ///     <para>bonjour MWQMLookupMPN</para>
    /// </summary>
    public partial class MWQMLookupMPNService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMLookupMPN mwqmLookupMPN = validationContext.ObjectInstance as MWQMLookupMPN;
            mwqmLookupMPN.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmLookupMPN.MWQMLookupMPNID == 0)
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMLookupMPNMWQMLookupMPNID"), new[] { "MWQMLookupMPNID" });
                }

                if (!(from c in db.MWQMLookupMPNs select c).Where(c => c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID).Any())
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMLookupMPN", "MWQMLookupMPNMWQMLookupMPNID", mwqmLookupMPN.MWQMLookupMPNID.ToString()), new[] { "MWQMLookupMPNID" });
                }
            }

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes10", "0", "5"), new[] { "Tubes10" });
            }

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes1", "0", "5"), new[] { "Tubes1" });
            }

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNTubes01", "0", "5"), new[] { "Tubes01" });
            }

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 10000)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMLookupMPNMPN_100ml", "1", "10000"), new[] { "MPN_100ml" });
            }

            if (mwqmLookupMPN.LastUpdateDate_UTC.Year == 1)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMLookupMPNLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmLookupMPN.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMLookupMPNLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmLookupMPN.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMLookupMPNLastUpdateContactTVItemID", mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMLookupMPNLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMLookupMPN GetMWQMLookupMPNWithMWQMLookupMPNID(int MWQMLookupMPNID)
        {
            return (from c in db.MWQMLookupMPNs
                    where c.MWQMLookupMPNID == MWQMLookupMPNID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMLookupMPN> GetMWQMLookupMPNList()
        {
            IQueryable<MWQMLookupMPN> MWQMLookupMPNQuery = (from c in db.MWQMLookupMPNs select c);

            MWQMLookupMPNQuery = EnhanceQueryStatements<MWQMLookupMPN>(MWQMLookupMPNQuery) as IQueryable<MWQMLookupMPN>;

            return MWQMLookupMPNQuery;
        }
        public MWQMLookupMPNWeb GetMWQMLookupMPNWebWithMWQMLookupMPNID(int MWQMLookupMPNID)
        {
            return FillMWQMLookupMPNWeb().Where(c => c.MWQMLookupMPNID == MWQMLookupMPNID).FirstOrDefault();

        }
        public IQueryable<MWQMLookupMPNWeb> GetMWQMLookupMPNWebList()
        {
            IQueryable<MWQMLookupMPNWeb> MWQMLookupMPNWebQuery = FillMWQMLookupMPNWeb();

            MWQMLookupMPNWebQuery = EnhanceQueryStatements<MWQMLookupMPNWeb>(MWQMLookupMPNWebQuery) as IQueryable<MWQMLookupMPNWeb>;

            return MWQMLookupMPNWebQuery;
        }
        public MWQMLookupMPNReport GetMWQMLookupMPNReportWithMWQMLookupMPNID(int MWQMLookupMPNID)
        {
            return FillMWQMLookupMPNReport().Where(c => c.MWQMLookupMPNID == MWQMLookupMPNID).FirstOrDefault();

        }
        public IQueryable<MWQMLookupMPNReport> GetMWQMLookupMPNReportList()
        {
            IQueryable<MWQMLookupMPNReport> MWQMLookupMPNReportQuery = FillMWQMLookupMPNReport();

            MWQMLookupMPNReportQuery = EnhanceQueryStatements<MWQMLookupMPNReport>(MWQMLookupMPNReportQuery) as IQueryable<MWQMLookupMPNReport>;

            return MWQMLookupMPNReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Create);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Add(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool Delete(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Delete);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Remove(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool Update(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Update);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Update(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMLookupMPNFillWeb
        private IQueryable<MWQMLookupMPNWeb> FillMWQMLookupMPNWeb()
        {
             IQueryable<MWQMLookupMPNWeb>  MWQMLookupMPNWebQuery = (from c in db.MWQMLookupMPNs
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMLookupMPNWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMLookupMPNID = c.MWQMLookupMPNID,
                        Tubes10 = c.Tubes10,
                        Tubes1 = c.Tubes1,
                        Tubes01 = c.Tubes01,
                        MPN_100ml = c.MPN_100ml,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMLookupMPNWebQuery;
        }
        #endregion Functions private Generated MWQMLookupMPNFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMLookupMPN mwqmLookupMPN)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmLookupMPN.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
