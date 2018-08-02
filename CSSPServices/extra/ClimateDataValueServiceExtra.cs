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
    public partial class ClimateDataValueService
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
        private IQueryable<ClimateDataValue> FillClimateDataValueReport(IQueryable<ClimateDataValue> climateDataValueQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

            climateDataValueQuery = (from c in climateDataValueQuery
                                     let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                    where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                    && cl.Language == LanguageRequest
                                                                    select cl).FirstOrDefault()
                                     select new ClimateDataValue
                                     {
                                         ClimateDataValueID = c.ClimateDataValueID,
                                         ClimateSiteID = c.ClimateSiteID,
                                         DateTime_Local = c.DateTime_Local,
                                         Keep = c.Keep,
                                         StorageDataType = c.StorageDataType,
                                         Snow_cm = c.Snow_cm,
                                         Rainfall_mm = c.Rainfall_mm,
                                         RainfallEntered_mm = c.RainfallEntered_mm,
                                         TotalPrecip_mm_cm = c.TotalPrecip_mm_cm,
                                         MaxTemp_C = c.MaxTemp_C,
                                         MinTemp_C = c.MinTemp_C,
                                         HeatDegDays_C = c.HeatDegDays_C,
                                         CoolDegDays_C = c.CoolDegDays_C,
                                         SnowOnGround_cm = c.SnowOnGround_cm,
                                         DirMaxGust_0North = c.DirMaxGust_0North,
                                         SpdMaxGust_kmh = c.SpdMaxGust_kmh,
                                         HourlyValues = c.HourlyValues,
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         ClimateDataValueWeb = new ClimateDataValueWeb
                                         {
                                             LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                             StorageDataTypeEnumText = (from e in StorageDataTypeEnumList
                                                                        where e.EnumID == (int?)c.StorageDataType
                                                                        select e.EnumText).FirstOrDefault(),
                                         },
                                         ClimateDataValueReport = new ClimateDataValueReport
                                         {
                                             ClimateDataValueReportTest = "ClimateDataValueReportTest",
                                         },
                                         HasErrors = false,
                                         ValidationResults = null,
                                     });

            return climateDataValueQuery;
        }
        #endregion Functions private
    }
}
