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
    ///     <para>bonjour VPResult</para>
    /// </summary>
    public partial class VPResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPResultService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPResult vpResult = validationContext.ObjectInstance as VPResult;
            vpResult.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpResult.VPResultID == 0)
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPResultVPResultID), new[] { "VPResultID" });
                }

                if (!GetRead().Where(c => c.VPResultID == vpResult.VPResultID).Any())
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPResult, CSSPModelsRes.VPResultVPResultID, vpResult.VPResultID.ToString()), new[] { "VPResultID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpResult.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPResultVPScenarioID, (vpResult.VPScenarioID == null ? "" : vpResult.VPScenarioID.ToString())), new[] { "VPScenarioID" });
            }

            if (vpResult.Ordinal < 0 || vpResult.Ordinal > 1000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            if (vpResult.Concentration_MPN_100ml < 0 || vpResult.Concentration_MPN_100ml > 10000000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultConcentration_MPN_100ml, "0", "10000000"), new[] { "Concentration_MPN_100ml" });
            }

            if (vpResult.Dilution < 0 || vpResult.Dilution > 1000000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultDilution, "0", "1000000"), new[] { "Dilution" });
            }

            if (vpResult.FarFieldWidth_m < 0 || vpResult.FarFieldWidth_m > 10000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultFarFieldWidth_m, "0", "10000"), new[] { "FarFieldWidth_m" });
            }

            if (vpResult.DispersionDistance_m < 0 || vpResult.DispersionDistance_m > 100000)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultDispersionDistance_m, "0", "100000"), new[] { "DispersionDistance_m" });
            }

            if (vpResult.TravelTime_hour < 0 || vpResult.TravelTime_hour > 100)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPResultTravelTime_hour, "0", "100"), new[] { "TravelTime_hour" });
            }

            if (vpResult.LastUpdateDate_UTC.Year == 1)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPResultLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpResult.LastUpdateDate_UTC.Year < 1980)
                {
                vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPResultLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPResultLastUpdateContactTVItemID, (vpResult.LastUpdateContactTVItemID == null ? "" : vpResult.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPResultLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpResult.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPResult GetVPResultWithVPResultID(int VPResultID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<VPResult> vpResultQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.VPResultID == VPResultID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return vpResultQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillVPResultWeb(vpResultQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillVPResultReport(vpResultQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<VPResult> GetVPResultList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<VPResult> vpResultQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return vpResultQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillVPResultWeb(vpResultQuery, FilterAndOrderText).Take(MaxGetCount);
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillVPResultReport(vpResultQuery, FilterAndOrderText).Take(MaxGetCount);
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Create);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Add(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool Delete(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Delete);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Remove(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public bool Update(VPResult vpResult)
        {
            vpResult.ValidationResults = Validate(new ValidationContext(vpResult), ActionDBTypeEnum.Update);
            if (vpResult.ValidationResults.Count() > 0) return false;

            db.VPResults.Update(vpResult);

            if (!TryToSave(vpResult)) return false;

            return true;
        }
        public IQueryable<VPResult> GetRead()
        {
            return db.VPResults.AsNoTracking();
        }
        public IQueryable<VPResult> GetEdit()
        {
            return db.VPResults;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated VPResultFillWeb
        private IQueryable<VPResult> FillVPResultWeb(IQueryable<VPResult> vpResultQuery, string FilterAndOrderText)
        {
            vpResultQuery = (from c in vpResultQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new VPResult
                    {
                        VPResultID = c.VPResultID,
                        VPScenarioID = c.VPScenarioID,
                        Ordinal = c.Ordinal,
                        Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                        Dilution = c.Dilution,
                        FarFieldWidth_m = c.FarFieldWidth_m,
                        DispersionDistance_m = c.DispersionDistance_m,
                        TravelTime_hour = c.TravelTime_hour,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        VPResultWeb = new VPResultWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        VPResultReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return vpResultQuery;
        }
        #endregion Functions private Generated VPResultFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(VPResult vpResult)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
