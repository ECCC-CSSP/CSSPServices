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
    ///     <para>bonjour SamplingPlanSubsectorSite</para>
    /// </summary>
    public partial class SamplingPlanSubsectorSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsectorSite samplingPlanSubsectorSite = validationContext.ObjectInstance as SamplingPlanSubsectorSite;
            samplingPlanSubsectorSite.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID == 0)
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID"), new[] { "SamplingPlanSubsectorSiteID" });
                }

                if (!(from c in db.SamplingPlanSubsectorSites select c).Where(c => c.SamplingPlanSubsectorSiteID == samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID).Any())
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsectorSite", "SamplingPlanSubsectorSiteSamplingPlanSubsectorSiteID", samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID.ToString()), new[] { "SamplingPlanSubsectorSiteID" });
                }
            }

            SamplingPlanSubsector SamplingPlanSubsectorSamplingPlanSubsectorID = (from c in db.SamplingPlanSubsectors where c.SamplingPlanSubsectorID == samplingPlanSubsectorSite.SamplingPlanSubsectorID select c).FirstOrDefault();

            if (SamplingPlanSubsectorSamplingPlanSubsectorID == null)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorSiteSamplingPlanSubsectorID", samplingPlanSubsectorSite.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorSiteMWQMSiteTVItemID", samplingPlanSubsectorSite.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorSiteMWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSiteLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsectorSite.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanSubsectorSiteLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsectorSite.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorSiteLastUpdateContactTVItemID", samplingPlanSubsectorSite.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    samplingPlanSubsectorSite.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorSiteLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                samplingPlanSubsectorSite.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SamplingPlanSubsectorSite GetSamplingPlanSubsectorSiteWithSamplingPlanSubsectorSiteID(int SamplingPlanSubsectorSiteID)
        {
            return (from c in db.SamplingPlanSubsectorSites
                    where c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID
                    select c).FirstOrDefault();

        }
        public IQueryable<SamplingPlanSubsectorSite> GetSamplingPlanSubsectorSiteList()
        {
            IQueryable<SamplingPlanSubsectorSite> SamplingPlanSubsectorSiteQuery = (from c in db.SamplingPlanSubsectorSites select c);

            SamplingPlanSubsectorSiteQuery = EnhanceQueryStatements<SamplingPlanSubsectorSite>(SamplingPlanSubsectorSiteQuery) as IQueryable<SamplingPlanSubsectorSite>;

            return SamplingPlanSubsectorSiteQuery;
        }
        public SamplingPlanSubsectorSite_A GetSamplingPlanSubsectorSite_AWithSamplingPlanSubsectorSiteID(int SamplingPlanSubsectorSiteID)
        {
            return FillSamplingPlanSubsectorSite_A().Where(c => c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanSubsectorSite_A> GetSamplingPlanSubsectorSite_AList()
        {
            IQueryable<SamplingPlanSubsectorSite_A> SamplingPlanSubsectorSite_AQuery = FillSamplingPlanSubsectorSite_A();

            SamplingPlanSubsectorSite_AQuery = EnhanceQueryStatements<SamplingPlanSubsectorSite_A>(SamplingPlanSubsectorSite_AQuery) as IQueryable<SamplingPlanSubsectorSite_A>;

            return SamplingPlanSubsectorSite_AQuery;
        }
        public SamplingPlanSubsectorSite_B GetSamplingPlanSubsectorSite_BWithSamplingPlanSubsectorSiteID(int SamplingPlanSubsectorSiteID)
        {
            return FillSamplingPlanSubsectorSite_B().Where(c => c.SamplingPlanSubsectorSiteID == SamplingPlanSubsectorSiteID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanSubsectorSite_B> GetSamplingPlanSubsectorSite_BList()
        {
            IQueryable<SamplingPlanSubsectorSite_B> SamplingPlanSubsectorSite_BQuery = FillSamplingPlanSubsectorSite_B();

            SamplingPlanSubsectorSite_BQuery = EnhanceQueryStatements<SamplingPlanSubsectorSite_B>(SamplingPlanSubsectorSite_BQuery) as IQueryable<SamplingPlanSubsectorSite_B>;

            return SamplingPlanSubsectorSite_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Create);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Add(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public bool Delete(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Delete);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Remove(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        public bool Update(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            samplingPlanSubsectorSite.ValidationResults = Validate(new ValidationContext(samplingPlanSubsectorSite), ActionDBTypeEnum.Update);
            if (samplingPlanSubsectorSite.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectorSites.Update(samplingPlanSubsectorSite);

            if (!TryToSave(samplingPlanSubsectorSite)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(SamplingPlanSubsectorSite samplingPlanSubsectorSite)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsectorSite.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
