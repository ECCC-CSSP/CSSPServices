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
        public VPScenarioService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioVPScenarioID), new[] { "VPScenarioID" });
                }

                if (!GetRead().Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
                {
                    vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.VPScenario, CSSPModelsRes.VPScenarioVPScenarioID, vpScenario.VPScenarioID.ToString()), new[] { "VPScenarioID" });
                }
            }

            //VPScenarioID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //InfrastructureTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == vpScenario.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioInfrastructureTVItemID, vpScenario.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(ScenarioStatusEnum), (int?)vpScenario.VPScenarioStatus);
            if (vpScenario.VPScenarioStatus == ScenarioStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioVPScenarioStatus), new[] { "VPScenarioStatus" });
            }

            //UseAsBestEstimate (bool) is required but no testing needed 

            //EffluentFlow_m3_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentFlow_m3_s < 0 || vpScenario.EffluentFlow_m3_s > 1000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentFlow_m3_s, "0", "1000"), new[] { "EffluentFlow_m3_s" });
            }

            //EffluentConcentration_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentConcentration_MPN_100ml < 0 || vpScenario.EffluentConcentration_MPN_100ml > 10000000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentConcentration_MPN_100ml, "0", "10000000"), new[] { "EffluentConcentration_MPN_100ml" });
            }

            //FroudeNumber (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.FroudeNumber < 0 || vpScenario.FroudeNumber > 10000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioFroudeNumber, "0", "10000"), new[] { "FroudeNumber" });
            }

            //PortDiameter_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortDiameter_m < 0 || vpScenario.PortDiameter_m > 10)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortDiameter_m, "0", "10"), new[] { "PortDiameter_m" });
            }

            //PortDepth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortDepth_m < 0 || vpScenario.PortDepth_m > 1000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortDepth_m, "0", "1000"), new[] { "PortDepth_m" });
            }

            //PortElevation_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortElevation_m < 0 || vpScenario.PortElevation_m > 1000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortElevation_m, "0", "1000"), new[] { "PortElevation_m" });
            }

            //VerticalAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.VerticalAngle_deg < -90 || vpScenario.VerticalAngle_deg > 90)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioVerticalAngle_deg, "-90", "90"), new[] { "VerticalAngle_deg" });
            }

            //HorizontalAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.HorizontalAngle_deg < -180 || vpScenario.HorizontalAngle_deg > 180)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioHorizontalAngle_deg, "-180", "180"), new[] { "HorizontalAngle_deg" });
            }

            //NumberOfPorts (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.NumberOfPorts < 1 || vpScenario.NumberOfPorts > 100)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioNumberOfPorts, "1", "100"), new[] { "NumberOfPorts" });
            }

            //PortSpacing_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.PortSpacing_m < 0 || vpScenario.PortSpacing_m > 1000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioPortSpacing_m, "0", "1000"), new[] { "PortSpacing_m" });
            }

            //AcuteMixZone_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.AcuteMixZone_m < 0 || vpScenario.AcuteMixZone_m > 100)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioAcuteMixZone_m, "0", "100"), new[] { "AcuteMixZone_m" });
            }

            //ChronicMixZone_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.ChronicMixZone_m < 0 || vpScenario.ChronicMixZone_m > 40000)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioChronicMixZone_m, "0", "40000"), new[] { "ChronicMixZone_m" });
            }

            //EffluentSalinity_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentSalinity_PSU < 0 || vpScenario.EffluentSalinity_PSU > 40)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentSalinity_PSU, "0", "40"), new[] { "EffluentSalinity_PSU" });
            }

            //EffluentTemperature_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentTemperature_C < -10 || vpScenario.EffluentTemperature_C > 40)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentTemperature_C, "-10", "40"), new[] { "EffluentTemperature_C" });
            }

            //EffluentVelocity_m_s (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (vpScenario.EffluentVelocity_m_s < 0 || vpScenario.EffluentVelocity_m_s > 100)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.VPScenarioEffluentVelocity_m_s, "0", "100"), new[] { "EffluentVelocity_m_s" });
            }

            //RawResults has no StringLength Attribute

                //Error: Type not implemented [VPScenarioWeb] of type [VPScenarioWeb]
                //Error: Type not implemented [VPScenarioReport] of type [VPScenarioReport]
            if (vpScenario.LastUpdateDate_UTC.Year == 1)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.VPScenarioLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (vpScenario.LastUpdateDate_UTC.Year < 1980)
                {
                vpScenario.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.VPScenarioLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == vpScenario.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.VPScenarioLastUpdateContactTVItemID, vpScenario.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.VPScenarioLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public VPScenario GetVPScenarioWithVPScenarioID(int VPScenarioID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<VPScenario> vpScenarioQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.VPScenarioID == VPScenarioID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return vpScenarioQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillVPScenario(vpScenarioQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<VPScenario> GetVPScenarioList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<VPScenario> vpScenarioQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return vpScenarioQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillVPScenario(vpScenarioQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
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
            return db.VPScenarios.AsNoTracking();
        }
        public IQueryable<VPScenario> GetEdit()
        {
            return db.VPScenarios;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<VPScenario> FillVPScenario_Show_Copy_To_VPScenarioServiceExtra_As_Fill_VPScenario(IQueryable<VPScenario> vpScenarioQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ScenarioStatusEnumList = enums.GetEnumTextOrderedList(typeof(ScenarioStatusEnum));

            vpScenarioQuery = (from c in vpScenarioQuery
                let SubsectorTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new VPScenario
                    {
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
                        VPScenarioWeb = new VPScenarioWeb
                        {
                            SubsectorTVText = SubsectorTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            VPScenarioStatusText = (from e in ScenarioStatusEnumList
                                where e.EnumID == (int?)c.VPScenarioStatus
                                select e.EnumText).FirstOrDefault(),
                        },
                        VPScenarioReport = new VPScenarioReport
                        {
                            VPScenarioReportTest = "VPScenarioReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return vpScenarioQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
