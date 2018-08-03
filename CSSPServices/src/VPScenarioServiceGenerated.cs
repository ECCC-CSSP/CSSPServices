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
    ///     <para>bonjour VPScenario</para>
    /// </summary>
    public partial class VPScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public VPScenarioService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            VPScenario vpScenario = validationContext.ObjectInstance as VPScenario;
            vpScenario.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (vpScenario.VPScenarioID == 0)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioVPScenarioID"), new[] { "VPScenarioID" });
                }

                if (!GetRead().Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "VPScenario", "VPScenarioVPScenarioID", vpScenario.VPScenarioID.ToString()), new[] { "VPScenarioID" });
                }
            }

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == vpScenario.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPScenarioInfrastructureTVItemID", vpScenario.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "VPScenarioInfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)vpScenario.VPScenarioStatus);
            if (vpScenario.VPScenarioStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioVPScenarioStatus"), new[] { "VPScenarioStatus" });
            }

            if (vpScenario.EffluentFlow_m3_s != null)
            {
                if (vpScenario.EffluentFlow_m3_s < 0 || vpScenario.EffluentFlow_m3_s > 1000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentFlow_m3_s", "0", "1000"), new[] { "EffluentFlow_m3_s" });
                }
            }

            if (vpScenario.EffluentConcentration_MPN_100ml != null)
            {
                if (vpScenario.EffluentConcentration_MPN_100ml < 0 || vpScenario.EffluentConcentration_MPN_100ml > 10000000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentConcentration_MPN_100ml", "0", "10000000"), new[] { "EffluentConcentration_MPN_100ml" });
                }
            }

            if (vpScenario.FroudeNumber != null)
            {
                if (vpScenario.FroudeNumber < 0 || vpScenario.FroudeNumber > 10000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioFroudeNumber", "0", "10000"), new[] { "FroudeNumber" });
                }
            }

            if (vpScenario.PortDiameter_m != null)
            {
                if (vpScenario.PortDiameter_m < 0 || vpScenario.PortDiameter_m > 10)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortDiameter_m", "0", "10"), new[] { "PortDiameter_m" });
                }
            }

            if (vpScenario.PortDepth_m != null)
            {
                if (vpScenario.PortDepth_m < 0 || vpScenario.PortDepth_m > 1000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortDepth_m", "0", "1000"), new[] { "PortDepth_m" });
                }
            }

            if (vpScenario.PortElevation_m != null)
            {
                if (vpScenario.PortElevation_m < 0 || vpScenario.PortElevation_m > 1000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortElevation_m", "0", "1000"), new[] { "PortElevation_m" });
                }
            }

            if (vpScenario.VerticalAngle_deg != null)
            {
                if (vpScenario.VerticalAngle_deg < -90 || vpScenario.VerticalAngle_deg > 90)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioVerticalAngle_deg", "-90", "90"), new[] { "VerticalAngle_deg" });
                }
            }

            if (vpScenario.HorizontalAngle_deg != null)
            {
                if (vpScenario.HorizontalAngle_deg < -180 || vpScenario.HorizontalAngle_deg > 180)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioHorizontalAngle_deg", "-180", "180"), new[] { "HorizontalAngle_deg" });
                }
            }

            if (vpScenario.NumberOfPorts != null)
            {
                if (vpScenario.NumberOfPorts < 1 || vpScenario.NumberOfPorts > 100)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioNumberOfPorts", "1", "100"), new[] { "NumberOfPorts" });
                }
            }

            if (vpScenario.PortSpacing_m != null)
            {
                if (vpScenario.PortSpacing_m < 0 || vpScenario.PortSpacing_m > 1000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioPortSpacing_m", "0", "1000"), new[] { "PortSpacing_m" });
                }
            }

            if (vpScenario.AcuteMixZone_m != null)
            {
                if (vpScenario.AcuteMixZone_m < 0 || vpScenario.AcuteMixZone_m > 100)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioAcuteMixZone_m", "0", "100"), new[] { "AcuteMixZone_m" });
                }
            }

            if (vpScenario.ChronicMixZone_m != null)
            {
                if (vpScenario.ChronicMixZone_m < 0 || vpScenario.ChronicMixZone_m > 40000)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioChronicMixZone_m", "0", "40000"), new[] { "ChronicMixZone_m" });
                }
            }

            if (vpScenario.EffluentSalinity_PSU != null)
            {
                if (vpScenario.EffluentSalinity_PSU < 0 || vpScenario.EffluentSalinity_PSU > 40)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentSalinity_PSU", "0", "40"), new[] { "EffluentSalinity_PSU" });
                }
            }

            if (vpScenario.EffluentTemperature_C != null)
            {
                if (vpScenario.EffluentTemperature_C < -10 || vpScenario.EffluentTemperature_C > 40)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentTemperature_C", "-10", "40"), new[] { "EffluentTemperature_C" });
                }
            }

            if (vpScenario.EffluentVelocity_m_s != null)
            {
                if (vpScenario.EffluentVelocity_m_s < 0 || vpScenario.EffluentVelocity_m_s > 100)
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VPScenarioEffluentVelocity_m_s", "0", "100"), new[] { "EffluentVelocity_m_s" });
                }
            }

            //RawResults has no StringLength Attribute

            if (vpScenario.LastUpdateDate_UTC.Year == 1)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "VPScenarioLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpScenario.LastUpdateDate_UTC.Year < 1980)
                {
                vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "VPScenarioLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpScenario.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "VPScenarioLastUpdateContactTVItemID", vpScenario.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "VPScenarioLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPScenario GetVPScenarioWithVPScenarioID(int VPScenarioID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.VPScenarioID == VPScenarioID
                    select c).FirstOrDefault();

        }
        public IQueryable<VPScenario> GetVPScenarioList()
        {
            IQueryable<VPScenario> VPScenarioQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            VPScenarioQuery = EnhanceQueryStatements<VPScenario>(VPScenarioQuery) as IQueryable<VPScenario>;

            return VPScenarioQuery;
        }
        public VPScenarioWeb GetVPScenarioWebWithVPScenarioID(int VPScenarioID)
        {
            return FillVPScenarioWeb().FirstOrDefault();

        }
        public IQueryable<VPScenarioWeb> GetVPScenarioWebList()
        {
            IQueryable<VPScenarioWeb> VPScenarioWebQuery = FillVPScenarioWeb();

            VPScenarioWebQuery = EnhanceQueryStatements<VPScenarioWeb>(VPScenarioWebQuery) as IQueryable<VPScenarioWeb>;

            return VPScenarioWebQuery;
        }
        public VPScenarioReport GetVPScenarioReportWithVPScenarioID(int VPScenarioID)
        {
            return FillVPScenarioReport().FirstOrDefault();

        }
        public IQueryable<VPScenarioReport> GetVPScenarioReportList()
        {
            IQueryable<VPScenarioReport> VPScenarioReportQuery = FillVPScenarioReport();

            VPScenarioReportQuery = EnhanceQueryStatements<VPScenarioReport>(VPScenarioReportQuery) as IQueryable<VPScenarioReport>;

            return VPScenarioReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Create);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Add(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        public bool Delete(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Delete);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Remove(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        public bool Update(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Update);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Update(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        public IQueryable<VPScenario> GetRead()
        {
            IQueryable<VPScenario> vpScenarioQuery = db.VPScenarios.AsNoTracking();

            return vpScenarioQuery;
        }
        public IQueryable<VPScenario> GetEdit()
        {
            IQueryable<VPScenario> vpScenarioQuery = db.VPScenarios;

            return vpScenarioQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated VPScenarioFillWeb
        private IQueryable<VPScenarioWeb> FillVPScenarioWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ScenarioStatusEnumList = enums.GetEnumTextOrderedList(typeof(ScenarioStatusEnum));

             IQueryable<VPScenarioWeb>  VPScenarioWebQuery = (from c in db.VPScenarios
                let SubsectorTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new VPScenarioWeb
                    {
                        SubsectorTVItemLanguage = SubsectorTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        VPScenarioStatusText = (from e in ScenarioStatusEnumList
                                where e.EnumID == (int?)c.VPScenarioStatus
                                select e.EnumText).FirstOrDefault(),
                        VPScenarioID = c.VPScenarioID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        VPScenarioStatus = c.VPScenarioStatus,
                        UseAsBestEstimate = c.UseAsBestEstimate,
                        EffluentFlow_m3_s = c.EffluentFlow_m3_s,
                        EffluentConcentration_MPN_100ml = c.EffluentConcentration_MPN_100ml,
                        FroudeNumber = c.FroudeNumber,
                        PortDiameter_m = c.PortDiameter_m,
                        PortDepth_m = c.PortDepth_m,
                        PortElevation_m = c.PortElevation_m,
                        VerticalAngle_deg = c.VerticalAngle_deg,
                        HorizontalAngle_deg = c.HorizontalAngle_deg,
                        NumberOfPorts = c.NumberOfPorts,
                        PortSpacing_m = c.PortSpacing_m,
                        AcuteMixZone_m = c.AcuteMixZone_m,
                        ChronicMixZone_m = c.ChronicMixZone_m,
                        EffluentSalinity_PSU = c.EffluentSalinity_PSU,
                        EffluentTemperature_C = c.EffluentTemperature_C,
                        EffluentVelocity_m_s = c.EffluentVelocity_m_s,
                        RawResults = c.RawResults,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return VPScenarioWebQuery;
        }
        #endregion Functions private Generated VPScenarioFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(VPScenario vpScenario)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                vpScenario.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}