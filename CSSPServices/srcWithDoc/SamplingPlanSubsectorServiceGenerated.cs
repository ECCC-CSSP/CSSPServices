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
    ///     <para>bonjour SamplingPlanSubsector</para>
    /// </summary>
    public partial class SamplingPlanSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsector samplingPlanSubsector = validationContext.ObjectInstance as SamplingPlanSubsector;
            samplingPlanSubsector.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlanSubsector.SamplingPlanSubsectorID == 0)
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorSamplingPlanSubsectorID"), new[] { "SamplingPlanSubsectorID" });
                }

                if (!(from c in db.SamplingPlanSubsectors select c).Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorSamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanSubsectorSamplingPlanID", samplingPlanSubsector.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorSubsectorTVItemID", samplingPlanSubsector.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorSubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSubsectorLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanSubsectorLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSubsectorLastUpdateContactTVItemID", samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSubsectorLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SamplingPlanSubsector GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            return (from c in db.SamplingPlanSubsectors
                    where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                    select c).FirstOrDefault();

        }
        public IQueryable<SamplingPlanSubsector> GetSamplingPlanSubsectorList()
        {
            IQueryable<SamplingPlanSubsector> SamplingPlanSubsectorQuery = (from c in db.SamplingPlanSubsectors select c);

            SamplingPlanSubsectorQuery = EnhanceQueryStatements<SamplingPlanSubsector>(SamplingPlanSubsectorQuery) as IQueryable<SamplingPlanSubsector>;

            return SamplingPlanSubsectorQuery;
        }
        public SamplingPlanSubsector_A GetSamplingPlanSubsector_AWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            return FillSamplingPlanSubsector_A().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanSubsector_A> GetSamplingPlanSubsector_AList()
        {
            IQueryable<SamplingPlanSubsector_A> SamplingPlanSubsector_AQuery = FillSamplingPlanSubsector_A();

            SamplingPlanSubsector_AQuery = EnhanceQueryStatements<SamplingPlanSubsector_A>(SamplingPlanSubsector_AQuery) as IQueryable<SamplingPlanSubsector_A>;

            return SamplingPlanSubsector_AQuery;
        }
        public SamplingPlanSubsector_B GetSamplingPlanSubsector_BWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            return FillSamplingPlanSubsector_B().Where(c => c.SamplingPlanSubsectorID == SamplingPlanSubsectorID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanSubsector_B> GetSamplingPlanSubsector_BList()
        {
            IQueryable<SamplingPlanSubsector_B> SamplingPlanSubsector_BQuery = FillSamplingPlanSubsector_B();

            SamplingPlanSubsector_BQuery = EnhanceQueryStatements<SamplingPlanSubsector_B>(SamplingPlanSubsector_BQuery) as IQueryable<SamplingPlanSubsector_B>;

            return SamplingPlanSubsector_BQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Create);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Add(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public bool Delete(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Delete);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Remove(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public bool Update(SamplingPlanSubsector samplingPlanSubsector)
        {
            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Update(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(SamplingPlanSubsector samplingPlanSubsector)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
