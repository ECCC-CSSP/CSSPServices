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
    public partial class ClimateDataValueService
    {
        #region Functions private Generated FillClimateDataValue_B
        private IQueryable<ClimateDataValue_B> FillClimateDataValue_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

             IQueryable<ClimateDataValue_B> ClimateDataValue_BQuery = (from c in db.ClimateDataValues
                let ClimateDataValueReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ClimateDataValue_B
                    {
                        ClimateDataValueReportTest = ClimateDataValueReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        StorageDataTypeEnumText = (from e in StorageDataTypeEnumList
                                where e.EnumID == (int?)c.StorageDataType
                                select e.EnumText).FirstOrDefault(),
                        ClimateDataValueID = c.ClimateDataValueID,
                        ClimateSiteID = c.ClimateSiteID,
                        DateTime_Local = c.DateTime_Local,
                        Keep = c.Keep,
                        StorageDataType = c.StorageDataType,
                        HasBeenRead = c.HasBeenRead,
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ClimateDataValue_BQuery;
        }
        #endregion Functions private Generated FillClimateDataValue_B

    }
}
