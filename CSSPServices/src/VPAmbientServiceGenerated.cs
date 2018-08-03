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
    ///     <para>bonjour VPAmbient</para>
    /// </summary>
    public partial class VPAmbientService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPAmbientService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPAmbient vpAmbient = validationContext.ObjectInstance as VPAmbient;
            vpAmbient.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpAmbient.VPAmbientID == 0)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPAmbientVPAmbientID"), new[] { "VPAmbientID" });
                }

                if (!GetRead().Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPAmbient", "VPAmbientVPAmbientID", vpAmbient.VPAmbientID.ToString()), new[] { "VPAmbientID" });
                }
            }

            VPScenario VPScenarioVPScenarioID = (from c in db.VPScenarios where c.VPScenarioID == vpAmbient.VPScenarioID select c).FirstOrDefault();

            if (VPScenarioVPScenarioID == null)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPAmbientVPScenarioID", vpAmbient.VPScenarioID.ToString()), new[] { "VPScenarioID" });
            }

            if (vpAmbient.Row < 0 || vpAmbient.Row > 10)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientRow", "0", "10"), new[] { "Row" });
            }

            if (vpAmbient.MeasurementDepth_m != null)
            {
                if (vpAmbient.MeasurementDepth_m < 0 || vpAmbient.MeasurementDepth_m > 1000)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientMeasurementDepth_m", "0", "1000"), new[] { "MeasurementDepth_m" });
                }
            }

            if (vpAmbient.CurrentSpeed_m_s != null)
            {
                if (vpAmbient.CurrentSpeed_m_s < 0 || vpAmbient.CurrentSpeed_m_s > 10)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientCurrentSpeed_m_s", "0", "10"), new[] { "CurrentSpeed_m_s" });
                }
            }

            if (vpAmbient.CurrentDirection_deg != null)
            {
                if (vpAmbient.CurrentDirection_deg < -180 || vpAmbient.CurrentDirection_deg > 180)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientCurrentDirection_deg", "-180", "180"), new[] { "CurrentDirection_deg" });
                }
            }

            if (vpAmbient.AmbientSalinity_PSU != null)
            {
                if (vpAmbient.AmbientSalinity_PSU < 0 || vpAmbient.AmbientSalinity_PSU > 40)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientAmbientSalinity_PSU", "0", "40"), new[] { "AmbientSalinity_PSU" });
                }
            }

            if (vpAmbient.AmbientTemperature_C != null)
            {
                if (vpAmbient.AmbientTemperature_C < -10 || vpAmbient.AmbientTemperature_C > 40)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientAmbientTemperature_C", "-10", "40"), new[] { "AmbientTemperature_C" });
                }
            }

            if (vpAmbient.BackgroundConcentration_MPN_100ml != null)
            {
                if (vpAmbient.BackgroundConcentration_MPN_100ml < 0 || vpAmbient.BackgroundConcentration_MPN_100ml > 10000000)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientBackgroundConcentration_MPN_100ml", "0", "10000000"), new[] { "BackgroundConcentration_MPN_100ml" });
                }
            }

            if (vpAmbient.PollutantDecayRate_per_day != null)
            {
                if (vpAmbient.PollutantDecayRate_per_day < 0 || vpAmbient.PollutantDecayRate_per_day > 100)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientPollutantDecayRate_per_day", "0", "100"), new[] { "PollutantDecayRate_per_day" });
                }
            }

            if (vpAmbient.FarFieldCurrentSpeed_m_s != null)
            {
                if (vpAmbient.FarFieldCurrentSpeed_m_s < 0 || vpAmbient.FarFieldCurrentSpeed_m_s > 10)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldCurrentSpeed_m_s", "0", "10"), new[] { "FarFieldCurrentSpeed_m_s" });
                }
            }

            if (vpAmbient.FarFieldCurrentDirection_deg != null)
            {
                if (vpAmbient.FarFieldCurrentDirection_deg < -180 || vpAmbient.FarFieldCurrentDirection_deg > 180)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldCurrentDirection_deg", "-180", "180"), new[] { "FarFieldCurrentDirection_deg" });
                }
            }

            if (vpAmbient.FarFieldDiffusionCoefficient != null)
            {
                if (vpAmbient.FarFieldDiffusionCoefficient < 0 || vpAmbient.FarFieldDiffusionCoefficient > 1)
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPAmbientFarFieldDiffusionCoefficient", "0", "1"), new[] { "FarFieldDiffusionCoefficient" });
                }
            }

            if (vpAmbient.LastUpdateDate_UTC.Year == 1)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPAmbientLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpAmbient.LastUpdateDate_UTC.Year < 1980)
                {
                vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPAmbientLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpAmbient.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPAmbientLastUpdateContactTVItemID", vpAmbient.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpAmbient.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "VPAmbientLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpAmbient.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPAmbient GetVPAmbientWithVPAmbientID(int VPAmbientID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.VPAmbientID == VPAmbientID
                    select c).FirstOrDefault();

        }
        public IQueryable<VPAmbient> GetVPAmbientList()
        {
            IQueryable<VPAmbient> VPAmbientQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            VPAmbientQuery = EnhanceQueryStatements<VPAmbient>(VPAmbientQuery) as IQueryable<VPAmbient>;

            return VPAmbientQuery;
        }
        public VPAmbientWeb GetVPAmbientWebWithVPAmbientID(int VPAmbientID)
        {
            return FillVPAmbientWeb().FirstOrDefault();

        }
        public IQueryable<VPAmbientWeb> GetVPAmbientWebList()
        {
            IQueryable<VPAmbientWeb> VPAmbientWebQuery = FillVPAmbientWeb();

            VPAmbientWebQuery = EnhanceQueryStatements<VPAmbientWeb>(VPAmbientWebQuery) as IQueryable<VPAmbientWeb>;

            return VPAmbientWebQuery;
        }
        public VPAmbientReport GetVPAmbientReportWithVPAmbientID(int VPAmbientID)
        {
            return FillVPAmbientReport().FirstOrDefault();

        }
        public IQueryable<VPAmbientReport> GetVPAmbientReportList()
        {
            IQueryable<VPAmbientReport> VPAmbientReportQuery = FillVPAmbientReport();

            VPAmbientReportQuery = EnhanceQueryStatements<VPAmbientReport>(VPAmbientReportQuery) as IQueryable<VPAmbientReport>;

            return VPAmbientReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Create);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Add(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool Delete(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Delete);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Remove(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public bool Update(VPAmbient vpAmbient)
        {
            vpAmbient.ValidationResults = Validate(new ValidationContext(vpAmbient), ActionDBTypeEnum.Update);
            if (vpAmbient.ValidationResults.Count() > 0) return false;

            db.VPAmbients.Update(vpAmbient);

            if (!TryToSave(vpAmbient)) return false;

            return true;
        }
        public IQueryable<VPAmbient> GetRead()
        {
            IQueryable<VPAmbient> vpAmbientQuery = db.VPAmbients.AsNoTracking();

            return vpAmbientQuery;
        }
        public IQueryable<VPAmbient> GetEdit()
        {
            IQueryable<VPAmbient> vpAmbientQuery = db.VPAmbients;

            return vpAmbientQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated VPAmbientFillWeb
        private IQueryable<VPAmbientWeb> FillVPAmbientWeb()
        {
             IQueryable<VPAmbientWeb>  VPAmbientWebQuery = (from c in db.VPAmbients
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new VPAmbientWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        VPAmbientID = c.VPAmbientID,
                        VPScenarioID = c.VPScenarioID,
                        Row = c.Row,
                        MeasurementDepth_m = c.MeasurementDepth_m,
                        CurrentSpeed_m_s = c.CurrentSpeed_m_s,
                        CurrentDirection_deg = c.CurrentDirection_deg,
                        AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                        AmbientTemperature_C = c.AmbientTemperature_C,
                        BackgroundConcentration_MPN_100ml = c.BackgroundConcentration_MPN_100ml,
                        PollutantDecayRate_per_day = c.PollutantDecayRate_per_day,
                        FarFieldCurrentSpeed_m_s = c.FarFieldCurrentSpeed_m_s,
                        FarFieldCurrentDirection_deg = c.FarFieldCurrentDirection_deg,
                        FarFieldDiffusionCoefficient = c.FarFieldDiffusionCoefficient,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return VPAmbientWebQuery;
        }
        #endregion Functions private Generated VPAmbientFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(VPAmbient vpAmbient)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpAmbient.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}