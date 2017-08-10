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
    public partial class SamplingPlanSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlanSubsector samplingPlanSubsector = validationContext.ObjectInstance as SamplingPlanSubsector;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (samplingPlanSubsector.SamplingPlanSubsectorID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), new[] { "SamplingPlanSubsectorID" });
                }
            }

            //SamplingPlanSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.SamplingPlanSubsectorSamplingPlanID, samplingPlanSubsector.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, samplingPlanSubsector.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, samplingPlanSubsector.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanSubsector.SubsectorTVText) && samplingPlanSubsector.SubsectorTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSubsectorSubsectorTVText, "200"), new[] { "SubsectorTVText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlanSubsector.LastUpdateContactTVText) && samplingPlanSubsector.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSubsectorLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SamplingPlanSubsector GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID)
        {
            IQueryable<SamplingPlanSubsector> samplingPlanSubsectorQuery = (from c in GetRead()
                                                where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                                select c);

            return FillSamplingPlanSubsector(samplingPlanSubsectorQuery).FirstOrDefault();
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
            if (!db.SamplingPlanSubsectors.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
            {
                samplingPlanSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString())) }.AsEnumerable();
                return false;
            }

            db.SamplingPlanSubsectors.Remove(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public bool Update(SamplingPlanSubsector samplingPlanSubsector)
        {
            if (!db.SamplingPlanSubsectors.Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
            {
                samplingPlanSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlanSubsector", "SamplingPlanSubsectorID", samplingPlanSubsector.SamplingPlanSubsectorID.ToString())) }.AsEnumerable();
                return false;
            }

            samplingPlanSubsector.ValidationResults = Validate(new ValidationContext(samplingPlanSubsector), ActionDBTypeEnum.Update);
            if (samplingPlanSubsector.ValidationResults.Count() > 0) return false;

            db.SamplingPlanSubsectors.Update(samplingPlanSubsector);

            if (!TryToSave(samplingPlanSubsector)) return false;

            return true;
        }
        public IQueryable<SamplingPlanSubsector> GetRead()
        {
            return db.SamplingPlanSubsectors.AsNoTracking();
        }
        public IQueryable<SamplingPlanSubsector> GetEdit()
        {
            return db.SamplingPlanSubsectors;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<SamplingPlanSubsector> FillSamplingPlanSubsector(IQueryable<SamplingPlanSubsector> samplingPlanSubsectorQuery)
        {
            List<SamplingPlanSubsector> SamplingPlanSubsectorList = (from c in samplingPlanSubsectorQuery
                                         let SubsectorTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.SubsectorTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new SamplingPlanSubsector
                                         {
                                             SamplingPlanSubsectorID = c.SamplingPlanSubsectorID,
                                             SamplingPlanID = c.SamplingPlanID,
                                             SubsectorTVItemID = c.SubsectorTVItemID,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             SubsectorTVText = SubsectorTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return SamplingPlanSubsectorList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
