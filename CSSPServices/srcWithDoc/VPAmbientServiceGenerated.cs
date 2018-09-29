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
        public VPAmbientService(Query query, CSSPDBContext db, int ContactID)
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

                if (!(from c in db.VPAmbients select c).Where(c => c.VPAmbientID == vpAmbient.VPAmbientID).Any())
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
            return (from c in db.VPAmbients
                    where c.VPAmbientID == VPAmbientID
                    select c).FirstOrDefault();

        }
        public IQueryable<VPAmbient> GetVPAmbientList()
        {
            IQueryable<VPAmbient> VPAmbientQuery = (from c in db.VPAmbients select c);

            VPAmbientQuery = EnhanceQueryStatements<VPAmbient>(VPAmbientQuery) as IQueryable<VPAmbient>;

            return VPAmbientQuery;
        }
        public VPAmbient_A GetVPAmbient_AWithVPAmbientID(int VPAmbientID)
        {
            return FillVPAmbient_A().Where(c => c.VPAmbientID == VPAmbientID).FirstOrDefault();

        }
        public IQueryable<VPAmbient_A> GetVPAmbient_AList()
        {
            IQueryable<VPAmbient_A> VPAmbient_AQuery = FillVPAmbient_A();

            VPAmbient_AQuery = EnhanceQueryStatements<VPAmbient_A>(VPAmbient_AQuery) as IQueryable<VPAmbient_A>;

            return VPAmbient_AQuery;
        }
        public VPAmbient_B GetVPAmbient_BWithVPAmbientID(int VPAmbientID)
        {
            return FillVPAmbient_B().Where(c => c.VPAmbientID == VPAmbientID).FirstOrDefault();

        }
        public IQueryable<VPAmbient_B> GetVPAmbient_BList()
        {
            IQueryable<VPAmbient_B> VPAmbient_BQuery = FillVPAmbient_B();

            VPAmbient_BQuery = EnhanceQueryStatements<VPAmbient_B>(VPAmbient_BQuery) as IQueryable<VPAmbient_B>;

            return VPAmbient_BQuery;
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
        #endregion Functions public Generated CRUD

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
