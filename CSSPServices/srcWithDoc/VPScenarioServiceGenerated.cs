/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [VPScenarioController](CSSPWebAPI.Controllers.VPScenarioController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.VPScenario](CSSPModels.VPScenario.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [ScenarioStatusEnum](CSSPEnums.ScenarioStatusEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class VPScenarioService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB VPScenarios table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public VPScenarioService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all VPScenarioService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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

                if (!(from c in db.VPScenarios select c).Where(c => c.VPScenarioID == vpScenario.VPScenarioID).Any())
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
            if (!string.IsNullOrWhiteSpace(retStr))
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

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                vpScenario.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the VPScenario model with the VPScenarioID identifier
        /// </summary>
        /// <param name="VPScenarioID">Is the identifier of [VPScenarios](CSSPModels.VPScenario.html) table of CSSPDB</param>
        /// <returns>[VPScenario](CSSPModels.VPScenario.html) object connected to the CSSPDB</returns>
        public VPScenario GetVPScenarioWithVPScenarioID(int VPScenarioID)
        {
            return (from c in db.VPScenarios
                    where c.VPScenarioID == VPScenarioID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [VPScenario](CSSPModels.VPScenario.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [VPScenario](CSSPModels.VPScenario.html)</returns>
        public IQueryable<VPScenario> GetVPScenarioList()
        {
            IQueryable<VPScenario> VPScenarioQuery = (from c in db.VPScenarios select c);

            VPScenarioQuery = EnhanceQueryStatements<VPScenario>(VPScenarioQuery) as IQueryable<VPScenario>;

            return VPScenarioQuery;
        }
        /// <summary>
        /// Gets the VPScenarioExtraA model with the VPScenarioID identifier
        /// </summary>
        /// <param name="VPScenarioID">Is the identifier of [VPScenarios](CSSPModels.VPScenario.html) table of CSSPDB</param>
        /// <returns>[VPScenarioExtraA](CSSPModels.VPScenarioExtraA.html) object connected to the CSSPDB</returns>
        public VPScenarioExtraA GetVPScenarioExtraAWithVPScenarioID(int VPScenarioID)
        {
            return FillVPScenarioExtraA().Where(c => c.VPScenarioID == VPScenarioID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [VPScenarioExtraA](CSSPModels.VPScenarioExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [VPScenarioExtraA](CSSPModels.VPScenarioExtraA.html)</returns>
        public IQueryable<VPScenarioExtraA> GetVPScenarioExtraAList()
        {
            IQueryable<VPScenarioExtraA> VPScenarioExtraAQuery = FillVPScenarioExtraA();

            VPScenarioExtraAQuery = EnhanceQueryStatements<VPScenarioExtraA>(VPScenarioExtraAQuery) as IQueryable<VPScenarioExtraA>;

            return VPScenarioExtraAQuery;
        }
        /// <summary>
        /// Gets the VPScenarioExtraB model with the VPScenarioID identifier
        /// </summary>
        /// <param name="VPScenarioID">Is the identifier of [VPScenarios](CSSPModels.VPScenario.html) table of CSSPDB</param>
        /// <returns>[VPScenarioExtraB](CSSPModels.VPScenarioExtraB.html) object connected to the CSSPDB</returns>
        public VPScenarioExtraB GetVPScenarioExtraBWithVPScenarioID(int VPScenarioID)
        {
            return FillVPScenarioExtraB().Where(c => c.VPScenarioID == VPScenarioID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [VPScenarioExtraB](CSSPModels.VPScenarioExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [VPScenarioExtraB](CSSPModels.VPScenarioExtraB.html)</returns>
        public IQueryable<VPScenarioExtraB> GetVPScenarioExtraBList()
        {
            IQueryable<VPScenarioExtraB> VPScenarioExtraBQuery = FillVPScenarioExtraB();

            VPScenarioExtraBQuery = EnhanceQueryStatements<VPScenarioExtraB>(VPScenarioExtraBQuery) as IQueryable<VPScenarioExtraB>;

            return VPScenarioExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [VPScenario](CSSPModels.VPScenario.html) item in CSSPDB
        /// </summary>
        /// <param name="vpScenario">Is the VPScenario item the client want to add to CSSPDB</param>
        /// <returns>true if VPScenario item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Create);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Add(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [VPScenario](CSSPModels.VPScenario.html) item in CSSPDB
        /// </summary>
        /// <param name="vpScenario">Is the VPScenario item the client want to add to CSSPDB. What's important here is the VPScenarioID</param>
        /// <returns>true if VPScenario item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Delete);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Remove(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [VPScenario](CSSPModels.VPScenario.html) item in CSSPDB
        /// </summary>
        /// <param name="vpScenario">Is the VPScenario item the client want to add to CSSPDB. What's important here is the VPScenarioID</param>
        /// <returns>true if VPScenario item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(VPScenario vpScenario)
        {
            vpScenario.ValidationResults = Validate(new ValidationContext(vpScenario), ActionDBTypeEnum.Update);
            if (vpScenario.ValidationResults.Count() > 0) return false;

            db.VPScenarios.Update(vpScenario);

            if (!TryToSave(vpScenario)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [VPScenario](CSSPModels.VPScenario.html) item
        /// </summary>
        /// <param name="vpScenario">Is the VPScenario item the client want to add to CSSPDB. What's important here is the VPScenarioID</param>
        /// <returns>true if VPScenario item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
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
