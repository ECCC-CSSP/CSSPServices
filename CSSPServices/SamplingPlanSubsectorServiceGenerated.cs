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
        public SamplingPlanSubsectorService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID), new[] { "SamplingPlanSubsectorID" });
                }

                if (!GetRead().Where(c => c.SamplingPlanSubsectorID == samplingPlanSubsector.SamplingPlanSubsectorID).Any())
                {
                    samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlanSubsector, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanSubsectorID, samplingPlanSubsector.SamplingPlanSubsectorID.ToString()), new[] { "SamplingPlanSubsectorID" });
                }
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == samplingPlanSubsector.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.SamplingPlanSubsectorSamplingPlanID, (samplingPlanSubsector.SamplingPlanID == null ? "" : samplingPlanSubsector.SamplingPlanID.ToString())), new[] { "SamplingPlanID" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID, (samplingPlanSubsector.SubsectorTVItemID == null ? "" : samplingPlanSubsector.SubsectorTVItemID.ToString())), new[] { "SubsectorTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (samplingPlanSubsector.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlanSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlanSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SamplingPlanSubsectorLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlanSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlanSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, (samplingPlanSubsector.LastUpdateContactTVItemID == null ? "" : samplingPlanSubsector.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSubsectorLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public SamplingPlanSubsector GetSamplingPlanSubsectorWithSamplingPlanSubsectorID(int SamplingPlanSubsectorID, GetParam getParam)
        {
            IQueryable<SamplingPlanSubsector> samplingPlanSubsectorQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.SamplingPlanSubsectorID == SamplingPlanSubsectorID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return samplingPlanSubsectorQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillSamplingPlanSubsectorWeb(samplingPlanSubsectorQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillSamplingPlanSubsectorReport(samplingPlanSubsectorQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<SamplingPlanSubsector> GetSamplingPlanSubsectorList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<SamplingPlanSubsector> samplingPlanSubsectorQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            samplingPlanSubsectorQuery  = samplingPlanSubsectorQuery.OrderByDescending(c => c.SamplingPlanSubsectorID);
                        }
                        samplingPlanSubsectorQuery = samplingPlanSubsectorQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return samplingPlanSubsectorQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            samplingPlanSubsectorQuery = FillSamplingPlanSubsectorWeb(samplingPlanSubsectorQuery, FilterAndOrderText).OrderByDescending(c => c.SamplingPlanSubsectorID);
                        }
                        samplingPlanSubsectorQuery = FillSamplingPlanSubsectorWeb(samplingPlanSubsectorQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return samplingPlanSubsectorQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            samplingPlanSubsectorQuery = FillSamplingPlanSubsectorReport(samplingPlanSubsectorQuery, FilterAndOrderText).OrderByDescending(c => c.SamplingPlanSubsectorID);
                        }
                        samplingPlanSubsectorQuery = FillSamplingPlanSubsectorReport(samplingPlanSubsectorQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return samplingPlanSubsectorQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<SamplingPlanSubsector> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.SamplingPlanSubsectors.AsNoTracking();
            }
            else
            {
                return db.SamplingPlanSubsectors.AsNoTracking().OrderByDescending(c => c.SamplingPlanSubsectorID);
            }
        }
        public IQueryable<SamplingPlanSubsector> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.SamplingPlanSubsectors;
            }
            else
            {
                return db.SamplingPlanSubsectors.OrderByDescending(c => c.SamplingPlanSubsectorID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated SamplingPlanSubsectorFillWeb
        private IQueryable<SamplingPlanSubsector> FillSamplingPlanSubsectorWeb(IQueryable<SamplingPlanSubsector> samplingPlanSubsectorQuery, string FilterAndOrderText)
        {
            samplingPlanSubsectorQuery = (from c in samplingPlanSubsectorQuery
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
                        SamplingPlanSubsectorWeb = new SamplingPlanSubsectorWeb
                        {
                            SubsectorTVText = SubsectorTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        SamplingPlanSubsectorReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return samplingPlanSubsectorQuery;
        }
        #endregion Functions private Generated SamplingPlanSubsectorFillWeb

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
