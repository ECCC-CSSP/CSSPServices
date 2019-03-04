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
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [InfrastructureController](CSSPWebAPI.Controllers.InfrastructureController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.Infrastructure](CSSPModels.Infrastructure.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [InfrastructureTypeEnum](CSSPEnums.InfrastructureTypeEnum.html), [FacilityTypeEnum](CSSPEnums.FacilityTypeEnum.html), [AerationTypeEnum](CSSPEnums.AerationTypeEnum.html), [PreliminaryTreatmentTypeEnum](CSSPEnums.PreliminaryTreatmentTypeEnum.html), [PrimaryTreatmentTypeEnum](CSSPEnums.PrimaryTreatmentTypeEnum.html), [SecondaryTreatmentTypeEnum](CSSPEnums.SecondaryTreatmentTypeEnum.html), [TertiaryTreatmentTypeEnum](CSSPEnums.TertiaryTreatmentTypeEnum.html), [TreatmentTypeEnum](CSSPEnums.TreatmentTypeEnum.html), [DisinfectionTypeEnum](CSSPEnums.DisinfectionTypeEnum.html), [CollectionSystemTypeEnum](CSSPEnums.CollectionSystemTypeEnum.html), [AlarmSystemTypeEnum](CSSPEnums.AlarmSystemTypeEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class InfrastructureService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB Infrastructures table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public InfrastructureService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all InfrastructureService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Infrastructure infrastructure = validationContext.ObjectInstance as Infrastructure;
            infrastructure.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (infrastructure.InfrastructureID == 0)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureID"), new[] { "InfrastructureID" });
                }

                if (!(from c in db.Infrastructures select c).Where(c => c.InfrastructureID == infrastructure.InfrastructureID).Any())
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Infrastructure", "InfrastructureID", infrastructure.InfrastructureID.ToString()), new[] { "InfrastructureID" });
                }
            }

            TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.InfrastructureTVItemID select c).FirstOrDefault();

            if (TVItemInfrastructureTVItemID == null)
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", infrastructure.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Infrastructure,
                };
                if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                }
            }

            if (infrastructure.PrismID != null)
            {
                if (infrastructure.PrismID < 0 || infrastructure.PrismID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PrismID", "0", "100000"), new[] { "PrismID" });
                }
            }

            if (infrastructure.TPID != null)
            {
                if (infrastructure.TPID < 0 || infrastructure.TPID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TPID", "0", "100000"), new[] { "TPID" });
                }
            }

            if (infrastructure.LSID != null)
            {
                if (infrastructure.LSID < 0 || infrastructure.LSID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LSID", "0", "100000"), new[] { "LSID" });
                }
            }

            if (infrastructure.SiteID != null)
            {
                if (infrastructure.SiteID < 0 || infrastructure.SiteID > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SiteID", "0", "100000"), new[] { "SiteID" });
                }
            }

            if (infrastructure.Site != null)
            {
                if (infrastructure.Site < 0 || infrastructure.Site > 100000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Site", "0", "100000"), new[] { "Site" });
                }
            }

            if (!string.IsNullOrWhiteSpace(infrastructure.InfrastructureCategory) && (infrastructure.InfrastructureCategory.Length < 1 || infrastructure.InfrastructureCategory.Length > 1))
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "InfrastructureCategory", "1", "1"), new[] { "InfrastructureCategory" });
            }

            if (infrastructure.InfrastructureType != null)
            {
                retStr = enums.EnumTypeOK(typeof(InfrastructureTypeEnum), (int?)infrastructure.InfrastructureType);
                if (infrastructure.InfrastructureType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "InfrastructureType"), new[] { "InfrastructureType" });
                }
            }

            if (infrastructure.FacilityType != null)
            {
                retStr = enums.EnumTypeOK(typeof(FacilityTypeEnum), (int?)infrastructure.FacilityType);
                if (infrastructure.FacilityType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FacilityType"), new[] { "FacilityType" });
                }
            }

            if (infrastructure.NumberOfCells != null)
            {
                if (infrastructure.NumberOfCells < 0 || infrastructure.NumberOfCells > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfCells", "0", "10"), new[] { "NumberOfCells" });
                }
            }

            if (infrastructure.NumberOfAeratedCells != null)
            {
                if (infrastructure.NumberOfAeratedCells < 0 || infrastructure.NumberOfAeratedCells > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfAeratedCells", "0", "10"), new[] { "NumberOfAeratedCells" });
                }
            }

            if (infrastructure.AerationType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AerationTypeEnum), (int?)infrastructure.AerationType);
                if (infrastructure.AerationType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AerationType"), new[] { "AerationType" });
                }
            }

            if (infrastructure.PreliminaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PreliminaryTreatmentTypeEnum), (int?)infrastructure.PreliminaryTreatmentType);
                if (infrastructure.PreliminaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PreliminaryTreatmentType"), new[] { "PreliminaryTreatmentType" });
                }
            }

            if (infrastructure.PrimaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(PrimaryTreatmentTypeEnum), (int?)infrastructure.PrimaryTreatmentType);
                if (infrastructure.PrimaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PrimaryTreatmentType"), new[] { "PrimaryTreatmentType" });
                }
            }

            if (infrastructure.SecondaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(SecondaryTreatmentTypeEnum), (int?)infrastructure.SecondaryTreatmentType);
                if (infrastructure.SecondaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SecondaryTreatmentType"), new[] { "SecondaryTreatmentType" });
                }
            }

            if (infrastructure.TertiaryTreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TertiaryTreatmentTypeEnum), (int?)infrastructure.TertiaryTreatmentType);
                if (infrastructure.TertiaryTreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TertiaryTreatmentType"), new[] { "TertiaryTreatmentType" });
                }
            }

            if (infrastructure.TreatmentType != null)
            {
                retStr = enums.EnumTypeOK(typeof(TreatmentTypeEnum), (int?)infrastructure.TreatmentType);
                if (infrastructure.TreatmentType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TreatmentType"), new[] { "TreatmentType" });
                }
            }

            if (infrastructure.DisinfectionType != null)
            {
                retStr = enums.EnumTypeOK(typeof(DisinfectionTypeEnum), (int?)infrastructure.DisinfectionType);
                if (infrastructure.DisinfectionType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DisinfectionType"), new[] { "DisinfectionType" });
                }
            }

            if (infrastructure.CollectionSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(CollectionSystemTypeEnum), (int?)infrastructure.CollectionSystemType);
                if (infrastructure.CollectionSystemType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "CollectionSystemType"), new[] { "CollectionSystemType" });
                }
            }

            if (infrastructure.AlarmSystemType != null)
            {
                retStr = enums.EnumTypeOK(typeof(AlarmSystemTypeEnum), (int?)infrastructure.AlarmSystemType);
                if (infrastructure.AlarmSystemType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AlarmSystemType"), new[] { "AlarmSystemType" });
                }
            }

            if (infrastructure.DesignFlow_m3_day != null)
            {
                if (infrastructure.DesignFlow_m3_day < 0 || infrastructure.DesignFlow_m3_day > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DesignFlow_m3_day", "0", "1000000"), new[] { "DesignFlow_m3_day" });
                }
            }

            if (infrastructure.AverageFlow_m3_day != null)
            {
                if (infrastructure.AverageFlow_m3_day < 0 || infrastructure.AverageFlow_m3_day > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AverageFlow_m3_day", "0", "1000000"), new[] { "AverageFlow_m3_day" });
                }
            }

            if (infrastructure.PeakFlow_m3_day != null)
            {
                if (infrastructure.PeakFlow_m3_day < 0 || infrastructure.PeakFlow_m3_day > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PeakFlow_m3_day", "0", "1000000"), new[] { "PeakFlow_m3_day" });
                }
            }

            if (infrastructure.PopServed != null)
            {
                if (infrastructure.PopServed < 0 || infrastructure.PopServed > 1000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PopServed", "0", "1000000"), new[] { "PopServed" });
                }
            }

            if (infrastructure.PercFlowOfTotal != null)
            {
                if (infrastructure.PercFlowOfTotal < 0 || infrastructure.PercFlowOfTotal > 100)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PercFlowOfTotal", "0", "100"), new[] { "PercFlowOfTotal" });
                }
            }

            if (infrastructure.TimeOffset_hour != null)
            {
                if (infrastructure.TimeOffset_hour < -10 || infrastructure.TimeOffset_hour > 0)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "TimeOffset_hour", "-10", "0"), new[] { "TimeOffset_hour" });
                }
            }

            //TempCatchAllRemoveLater has no StringLength Attribute

            if (infrastructure.AverageDepth_m != null)
            {
                if (infrastructure.AverageDepth_m < 0 || infrastructure.AverageDepth_m > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AverageDepth_m", "0", "1000"), new[] { "AverageDepth_m" });
                }
            }

            if (infrastructure.NumberOfPorts != null)
            {
                if (infrastructure.NumberOfPorts < 1 || infrastructure.NumberOfPorts > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NumberOfPorts", "1", "1000"), new[] { "NumberOfPorts" });
                }
            }

            if (infrastructure.PortDiameter_m != null)
            {
                if (infrastructure.PortDiameter_m < 0 || infrastructure.PortDiameter_m > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PortDiameter_m", "0", "10"), new[] { "PortDiameter_m" });
                }
            }

            if (infrastructure.PortSpacing_m != null)
            {
                if (infrastructure.PortSpacing_m < 0 || infrastructure.PortSpacing_m > 10000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PortSpacing_m", "0", "10000"), new[] { "PortSpacing_m" });
                }
            }

            if (infrastructure.PortElevation_m != null)
            {
                if (infrastructure.PortElevation_m < 0 || infrastructure.PortElevation_m > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "PortElevation_m", "0", "1000"), new[] { "PortElevation_m" });
                }
            }

            if (infrastructure.VerticalAngle_deg != null)
            {
                if (infrastructure.VerticalAngle_deg < -90 || infrastructure.VerticalAngle_deg > 90)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "VerticalAngle_deg", "-90", "90"), new[] { "VerticalAngle_deg" });
                }
            }

            if (infrastructure.HorizontalAngle_deg != null)
            {
                if (infrastructure.HorizontalAngle_deg < -180 || infrastructure.HorizontalAngle_deg > 180)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "HorizontalAngle_deg", "-180", "180"), new[] { "HorizontalAngle_deg" });
                }
            }

            if (infrastructure.DecayRate_per_day != null)
            {
                if (infrastructure.DecayRate_per_day < 0 || infrastructure.DecayRate_per_day > 100)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DecayRate_per_day", "0", "100"), new[] { "DecayRate_per_day" });
                }
            }

            if (infrastructure.NearFieldVelocity_m_s != null)
            {
                if (infrastructure.NearFieldVelocity_m_s < 0 || infrastructure.NearFieldVelocity_m_s > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "NearFieldVelocity_m_s", "0", "10"), new[] { "NearFieldVelocity_m_s" });
                }
            }

            if (infrastructure.FarFieldVelocity_m_s != null)
            {
                if (infrastructure.FarFieldVelocity_m_s < 0 || infrastructure.FarFieldVelocity_m_s > 10)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "FarFieldVelocity_m_s", "0", "10"), new[] { "FarFieldVelocity_m_s" });
                }
            }

            if (infrastructure.ReceivingWaterSalinity_PSU != null)
            {
                if (infrastructure.ReceivingWaterSalinity_PSU < 0 || infrastructure.ReceivingWaterSalinity_PSU > 40)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReceivingWaterSalinity_PSU", "0", "40"), new[] { "ReceivingWaterSalinity_PSU" });
                }
            }

            if (infrastructure.ReceivingWaterTemperature_C != null)
            {
                if (infrastructure.ReceivingWaterTemperature_C < -10 || infrastructure.ReceivingWaterTemperature_C > 40)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReceivingWaterTemperature_C", "-10", "40"), new[] { "ReceivingWaterTemperature_C" });
                }
            }

            if (infrastructure.ReceivingWater_MPN_per_100ml != null)
            {
                if (infrastructure.ReceivingWater_MPN_per_100ml < 0 || infrastructure.ReceivingWater_MPN_per_100ml > 10000000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ReceivingWater_MPN_per_100ml", "0", "10000000"), new[] { "ReceivingWater_MPN_per_100ml" });
                }
            }

            if (infrastructure.DistanceFromShore_m != null)
            {
                if (infrastructure.DistanceFromShore_m < 0 || infrastructure.DistanceFromShore_m > 1000)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "DistanceFromShore_m", "0", "1000"), new[] { "DistanceFromShore_m" });
                }
            }

            if (infrastructure.SeeOtherMunicipalityTVItemID != null)
            {
                TVItem TVItemSeeOtherMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.SeeOtherMunicipalityTVItemID select c).FirstOrDefault();

                if (TVItemSeeOtherMunicipalityTVItemID == null)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SeeOtherMunicipalityTVItemID", (infrastructure.SeeOtherMunicipalityTVItemID == null ? "" : infrastructure.SeeOtherMunicipalityTVItemID.ToString())), new[] { "SeeOtherMunicipalityTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSeeOtherMunicipalityTVItemID.TVType))
                    {
                        infrastructure.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SeeOtherMunicipalityTVItemID", "Infrastructure"), new[] { "SeeOtherMunicipalityTVItemID" });
                    }
                }
            }

            if (infrastructure.CivicAddressTVItemID != null)
            {
                TVItem TVItemCivicAddressTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.CivicAddressTVItemID select c).FirstOrDefault();

                if (TVItemCivicAddressTVItemID == null)
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "CivicAddressTVItemID", (infrastructure.CivicAddressTVItemID == null ? "" : infrastructure.CivicAddressTVItemID.ToString())), new[] { "CivicAddressTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Address,
                    };
                    if (!AllowableTVTypes.Contains(TVItemCivicAddressTVItemID.TVType))
                    {
                        infrastructure.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "CivicAddressTVItemID", "Address"), new[] { "CivicAddressTVItemID" });
                    }
                }
            }

            if (infrastructure.LastUpdateDate_UTC.Year == 1)
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (infrastructure.LastUpdateDate_UTC.Year < 1980)
                {
                infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == infrastructure.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", infrastructure.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    infrastructure.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                infrastructure.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the Infrastructure model with the InfrastructureID identifier
        /// </summary>
        /// <param name="InfrastructureID">Is the identifier of [Infrastructures](CSSPModels.Infrastructure.html) table of CSSPDB</param>
        /// <returns>[Infrastructure](CSSPModels.Infrastructure.html) object connected to the CSSPDB</returns>
        public Infrastructure GetInfrastructureWithInfrastructureID(int InfrastructureID)
        {
            return (from c in db.Infrastructures
                    where c.InfrastructureID == InfrastructureID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [Infrastructure](CSSPModels.Infrastructure.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [Infrastructure](CSSPModels.Infrastructure.html)</returns>
        public IQueryable<Infrastructure> GetInfrastructureList()
        {
            IQueryable<Infrastructure> InfrastructureQuery = (from c in db.Infrastructures select c);

            InfrastructureQuery = EnhanceQueryStatements<Infrastructure>(InfrastructureQuery) as IQueryable<Infrastructure>;

            return InfrastructureQuery;
        }
        /// <summary>
        /// Gets the InfrastructureExtraA model with the InfrastructureID identifier
        /// </summary>
        /// <param name="InfrastructureID">Is the identifier of [Infrastructures](CSSPModels.Infrastructure.html) table of CSSPDB</param>
        /// <returns>[InfrastructureExtraA](CSSPModels.InfrastructureExtraA.html) object connected to the CSSPDB</returns>
        public InfrastructureExtraA GetInfrastructureExtraAWithInfrastructureID(int InfrastructureID)
        {
            return FillInfrastructureExtraA().Where(c => c.InfrastructureID == InfrastructureID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [InfrastructureExtraA](CSSPModels.InfrastructureExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [InfrastructureExtraA](CSSPModels.InfrastructureExtraA.html)</returns>
        public IQueryable<InfrastructureExtraA> GetInfrastructureExtraAList()
        {
            IQueryable<InfrastructureExtraA> InfrastructureExtraAQuery = FillInfrastructureExtraA();

            InfrastructureExtraAQuery = EnhanceQueryStatements<InfrastructureExtraA>(InfrastructureExtraAQuery) as IQueryable<InfrastructureExtraA>;

            return InfrastructureExtraAQuery;
        }
        /// <summary>
        /// Gets the InfrastructureExtraB model with the InfrastructureID identifier
        /// </summary>
        /// <param name="InfrastructureID">Is the identifier of [Infrastructures](CSSPModels.Infrastructure.html) table of CSSPDB</param>
        /// <returns>[InfrastructureExtraB](CSSPModels.InfrastructureExtraB.html) object connected to the CSSPDB</returns>
        public InfrastructureExtraB GetInfrastructureExtraBWithInfrastructureID(int InfrastructureID)
        {
            return FillInfrastructureExtraB().Where(c => c.InfrastructureID == InfrastructureID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [InfrastructureExtraB](CSSPModels.InfrastructureExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [InfrastructureExtraB](CSSPModels.InfrastructureExtraB.html)</returns>
        public IQueryable<InfrastructureExtraB> GetInfrastructureExtraBList()
        {
            IQueryable<InfrastructureExtraB> InfrastructureExtraBQuery = FillInfrastructureExtraB();

            InfrastructureExtraBQuery = EnhanceQueryStatements<InfrastructureExtraB>(InfrastructureExtraBQuery) as IQueryable<InfrastructureExtraB>;

            return InfrastructureExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [Infrastructure](CSSPModels.Infrastructure.html) item in CSSPDB
        /// </summary>
        /// <param name="infrastructure">Is the Infrastructure item the client want to add to CSSPDB</param>
        /// <returns>true if Infrastructure item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Create);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Add(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [Infrastructure](CSSPModels.Infrastructure.html) item in CSSPDB
        /// </summary>
        /// <param name="infrastructure">Is the Infrastructure item the client want to add to CSSPDB. What's important here is the InfrastructureID</param>
        /// <returns>true if Infrastructure item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Delete);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Remove(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [Infrastructure](CSSPModels.Infrastructure.html) item in CSSPDB
        /// </summary>
        /// <param name="infrastructure">Is the Infrastructure item the client want to add to CSSPDB. What's important here is the InfrastructureID</param>
        /// <returns>true if Infrastructure item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(Infrastructure infrastructure)
        {
            infrastructure.ValidationResults = Validate(new ValidationContext(infrastructure), ActionDBTypeEnum.Update);
            if (infrastructure.ValidationResults.Count() > 0) return false;

            db.Infrastructures.Update(infrastructure);

            if (!TryToSave(infrastructure)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [Infrastructure](CSSPModels.Infrastructure.html) item
        /// </summary>
        /// <param name="infrastructure">Is the Infrastructure item the client want to add to CSSPDB. What's important here is the InfrastructureID</param>
        /// <returns>true if Infrastructure item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(Infrastructure infrastructure)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                infrastructure.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
