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
    ///     <para>bonjour MWQMSubsector</para>
    /// </summary>
    public partial class MWQMSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSubsector mwqmSubsector = validationContext.ObjectInstance as MWQMSubsector;
            mwqmSubsector.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSubsector.MWQMSubsectorID == 0)
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorMWQMSubsectorID"), new[] { "MWQMSubsectorID" });
                }

                if (!GetRead().Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorMWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString()), new[] { "MWQMSubsectorID" });
                }
            }

            TVItem TVItemMWQMSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSubsectorTVItemID == null)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorMWQMSubsectorTVItemID", mwqmSubsector.MWQMSubsectorTVItemID.ToString()), new[] { "MWQMSubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSubsectorTVItemID.TVType))
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSubsectorMWQMSubsectorTVItemID", "Subsector"), new[] { "MWQMSubsectorTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey))
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorSubsectorHistoricKey"), new[] { "SubsectorHistoricKey" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey) && mwqmSubsector.SubsectorHistoricKey.Length > 20)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSubsectorSubsectorHistoricKey", "20"), new[] { "SubsectorHistoricKey" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText) && mwqmSubsector.TideLocationSIDText.Length > 20)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMSubsectorTideLocationSIDText", "20"), new[] { "TideLocationSIDText" });
            }

            if (mwqmSubsector.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMSubsectorLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMSubsectorLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMSubsectorLastUpdateContactTVItemID", mwqmSubsector.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMSubsectorLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSubsector GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.MWQMSubsectorID == MWQMSubsectorID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMSubsector> GetMWQMSubsectorList()
        {
            IQueryable<MWQMSubsector> MWQMSubsectorQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            MWQMSubsectorQuery = EnhanceQueryStatements<MWQMSubsector>(MWQMSubsectorQuery) as IQueryable<MWQMSubsector>;

            return MWQMSubsectorQuery;
        }
        public MWQMSubsectorWeb GetMWQMSubsectorWebWithMWQMSubsectorID(int MWQMSubsectorID)
        {
            return FillMWQMSubsectorWeb().FirstOrDefault();

        }
        public IQueryable<MWQMSubsectorWeb> GetMWQMSubsectorWebList()
        {
            IQueryable<MWQMSubsectorWeb> MWQMSubsectorWebQuery = FillMWQMSubsectorWeb();

            MWQMSubsectorWebQuery = EnhanceQueryStatements<MWQMSubsectorWeb>(MWQMSubsectorWebQuery) as IQueryable<MWQMSubsectorWeb>;

            return MWQMSubsectorWebQuery;
        }
        public MWQMSubsectorReport GetMWQMSubsectorReportWithMWQMSubsectorID(int MWQMSubsectorID)
        {
            return FillMWQMSubsectorReport().FirstOrDefault();

        }
        public IQueryable<MWQMSubsectorReport> GetMWQMSubsectorReportList()
        {
            IQueryable<MWQMSubsectorReport> MWQMSubsectorReportQuery = FillMWQMSubsectorReport();

            MWQMSubsectorReportQuery = EnhanceQueryStatements<MWQMSubsectorReport>(MWQMSubsectorReportQuery) as IQueryable<MWQMSubsectorReport>;

            return MWQMSubsectorReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSubsector mwqmSubsector)
        {
            mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Create);
            if (mwqmSubsector.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectors.Add(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

            return true;
        }
        public bool Delete(MWQMSubsector mwqmSubsector)
        {
            mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Delete);
            if (mwqmSubsector.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectors.Remove(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

            return true;
        }
        public bool Update(MWQMSubsector mwqmSubsector)
        {
            mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Update);
            if (mwqmSubsector.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectors.Update(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

            return true;
        }
        public IQueryable<MWQMSubsector> GetRead()
        {
            IQueryable<MWQMSubsector> mwqmSubsectorQuery = db.MWQMSubsectors.AsNoTracking();

            return mwqmSubsectorQuery;
        }
        public IQueryable<MWQMSubsector> GetEdit()
        {
            IQueryable<MWQMSubsector> mwqmSubsectorQuery = db.MWQMSubsectors;

            return mwqmSubsectorQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSubsectorFillWeb
        private IQueryable<MWQMSubsectorWeb> FillMWQMSubsectorWeb()
        {
             IQueryable<MWQMSubsectorWeb>  MWQMSubsectorWebQuery = (from c in db.MWQMSubsectors
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSubsectorTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MWQMSubsectorWeb
                    {
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MWQMSubsectorID = c.MWQMSubsectorID,
                        MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                        SubsectorHistoricKey = c.SubsectorHistoricKey,
                        TideLocationSIDText = c.TideLocationSIDText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return MWQMSubsectorWebQuery;
        }
        #endregion Functions private Generated MWQMSubsectorFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMSubsector mwqmSubsector)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}