using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class InfrastructureService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<Infrastructure> FillInfrastructureReport(IQueryable<Infrastructure> infrastructureQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> InfrastructureTypeEnumList = enums.GetEnumTextOrderedList(typeof(InfrastructureTypeEnum));
            List<EnumIDAndText> FacilityTypeEnumList = enums.GetEnumTextOrderedList(typeof(FacilityTypeEnum));
            List<EnumIDAndText> AerationTypeEnumList = enums.GetEnumTextOrderedList(typeof(AerationTypeEnum));
            List<EnumIDAndText> PreliminaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(PreliminaryTreatmentTypeEnum));
            List<EnumIDAndText> PrimaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(PrimaryTreatmentTypeEnum));
            List<EnumIDAndText> SecondaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(SecondaryTreatmentTypeEnum));
            List<EnumIDAndText> TertiaryTreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(TertiaryTreatmentTypeEnum));
            List<EnumIDAndText> TreatmentTypeEnumList = enums.GetEnumTextOrderedList(typeof(TreatmentTypeEnum));
            List<EnumIDAndText> DisinfectionTypeEnumList = enums.GetEnumTextOrderedList(typeof(DisinfectionTypeEnum));
            List<EnumIDAndText> CollectionSystemTypeEnumList = enums.GetEnumTextOrderedList(typeof(CollectionSystemTypeEnum));
            List<EnumIDAndText> AlarmSystemTypeEnumList = enums.GetEnumTextOrderedList(typeof(AlarmSystemTypeEnum));

            infrastructureQuery = (from c in infrastructureQuery
                                   let InfrastructureTVText = (from cl in db.TVItemLanguages
                                                               where cl.TVItemID == c.InfrastructureTVItemID
                                                               && cl.Language == LanguageRequest
                                                               select cl.TVText).FirstOrDefault()
                                   let SeeOtherTVText = (from cl in db.TVItemLanguages
                                                         where cl.TVItemID == c.SeeOtherTVItemID
                                                         && cl.Language == LanguageRequest
                                                         select cl.TVText).FirstOrDefault()
                                   let CivicAddressTVText = (from cl in db.TVItemLanguages
                                                             where cl.TVItemID == c.CivicAddressTVItemID
                                                             && cl.Language == LanguageRequest
                                                             select cl.TVText).FirstOrDefault()
                                   let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                  where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                  && cl.Language == LanguageRequest
                                                                  select cl.TVText).FirstOrDefault()
                                   select new Infrastructure
                                   {
                                       InfrastructureID = c.InfrastructureID,
                                       InfrastructureTVItemID = c.InfrastructureTVItemID,
                                       PrismID = c.PrismID,
                                       TPID = c.TPID,
                                       LSID = c.LSID,
                                       SiteID = c.SiteID,
                                       Site = c.Site,
                                       InfrastructureCategory = c.InfrastructureCategory,
                                       InfrastructureType = c.InfrastructureType,
                                       FacilityType = c.FacilityType,
                                       IsMechanicallyAerated = c.IsMechanicallyAerated,
                                       NumberOfCells = c.NumberOfCells,
                                       NumberOfAeratedCells = c.NumberOfAeratedCells,
                                       AerationType = c.AerationType,
                                       PreliminaryTreatmentType = c.PreliminaryTreatmentType,
                                       PrimaryTreatmentType = c.PrimaryTreatmentType,
                                       SecondaryTreatmentType = c.SecondaryTreatmentType,
                                       TertiaryTreatmentType = c.TertiaryTreatmentType,
                                       TreatmentType = c.TreatmentType,
                                       DisinfectionType = c.DisinfectionType,
                                       CollectionSystemType = c.CollectionSystemType,
                                       AlarmSystemType = c.AlarmSystemType,
                                       DesignFlow_m3_day = c.DesignFlow_m3_day,
                                       AverageFlow_m3_day = c.AverageFlow_m3_day,
                                       PeakFlow_m3_day = c.PeakFlow_m3_day,
                                       PopServed = c.PopServed,
                                       CanOverflow = c.CanOverflow,
                                       PercFlowOfTotal = c.PercFlowOfTotal,
                                       TimeOffset_hour = c.TimeOffset_hour,
                                       TempCatchAllRemoveLater = c.TempCatchAllRemoveLater,
                                       AverageDepth_m = c.AverageDepth_m,
                                       NumberOfPorts = c.NumberOfPorts,
                                       PortDiameter_m = c.PortDiameter_m,
                                       PortSpacing_m = c.PortSpacing_m,
                                       PortElevation_m = c.PortElevation_m,
                                       VerticalAngle_deg = c.VerticalAngle_deg,
                                       HorizontalAngle_deg = c.HorizontalAngle_deg,
                                       DecayRate_per_day = c.DecayRate_per_day,
                                       NearFieldVelocity_m_s = c.NearFieldVelocity_m_s,
                                       FarFieldVelocity_m_s = c.FarFieldVelocity_m_s,
                                       ReceivingWaterSalinity_PSU = c.ReceivingWaterSalinity_PSU,
                                       ReceivingWaterTemperature_C = c.ReceivingWaterTemperature_C,
                                       ReceivingWater_MPN_per_100ml = c.ReceivingWater_MPN_per_100ml,
                                       DistanceFromShore_m = c.DistanceFromShore_m,
                                       SeeOtherTVItemID = c.SeeOtherTVItemID,
                                       CivicAddressTVItemID = c.CivicAddressTVItemID,
                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       InfrastructureWeb = new InfrastructureWeb
                                       {
                                           InfrastructureTVText = InfrastructureTVText,
                                           SeeOtherTVText = SeeOtherTVText,
                                           CivicAddressTVText = CivicAddressTVText,
                                           LastUpdateContactTVText = LastUpdateContactTVText,
                                           InfrastructureTypeText = (from e in InfrastructureTypeEnumList
                                                                     where e.EnumID == (int?)c.InfrastructureType
                                                                     select e.EnumText).FirstOrDefault(),
                                           FacilityTypeText = (from e in FacilityTypeEnumList
                                                               where e.EnumID == (int?)c.FacilityType
                                                               select e.EnumText).FirstOrDefault(),
                                           AerationTypeText = (from e in AerationTypeEnumList
                                                               where e.EnumID == (int?)c.AerationType
                                                               select e.EnumText).FirstOrDefault(),
                                           PreliminaryTreatmentTypeText = (from e in PreliminaryTreatmentTypeEnumList
                                                                           where e.EnumID == (int?)c.PreliminaryTreatmentType
                                                                           select e.EnumText).FirstOrDefault(),
                                           PrimaryTreatmentTypeText = (from e in PrimaryTreatmentTypeEnumList
                                                                       where e.EnumID == (int?)c.PrimaryTreatmentType
                                                                       select e.EnumText).FirstOrDefault(),
                                           SecondaryTreatmentTypeText = (from e in SecondaryTreatmentTypeEnumList
                                                                         where e.EnumID == (int?)c.SecondaryTreatmentType
                                                                         select e.EnumText).FirstOrDefault(),
                                           TertiaryTreatmentTypeText = (from e in TertiaryTreatmentTypeEnumList
                                                                        where e.EnumID == (int?)c.TertiaryTreatmentType
                                                                        select e.EnumText).FirstOrDefault(),
                                           TreatmentTypeText = (from e in TreatmentTypeEnumList
                                                                where e.EnumID == (int?)c.TreatmentType
                                                                select e.EnumText).FirstOrDefault(),
                                           DisinfectionTypeText = (from e in DisinfectionTypeEnumList
                                                                   where e.EnumID == (int?)c.DisinfectionType
                                                                   select e.EnumText).FirstOrDefault(),
                                           CollectionSystemTypeText = (from e in CollectionSystemTypeEnumList
                                                                       where e.EnumID == (int?)c.CollectionSystemType
                                                                       select e.EnumText).FirstOrDefault(),
                                           AlarmSystemTypeText = (from e in AlarmSystemTypeEnumList
                                                                  where e.EnumID == (int?)c.AlarmSystemType
                                                                  select e.EnumText).FirstOrDefault(),
                                       },
                                       InfrastructureReport = new InfrastructureReport
                                       {
                                           InfrastructureReportTest = "InfrastructureReportTest",
                                       },
                                       HasErrors = false,
                                       ValidationResults = null,
                                   });

            return infrastructureQuery;
        }
        #endregion Functions private
    }
}
