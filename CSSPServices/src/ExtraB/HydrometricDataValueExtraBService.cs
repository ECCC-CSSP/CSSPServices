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
    public partial class HydrometricDataValueService
    {
        #region Functions private Generated FillHydrometricDataValueExtraB
        private IQueryable<HydrometricDataValueExtraB> FillHydrometricDataValueExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

             IQueryable<HydrometricDataValueExtraB> HydrometricDataValueExtraBQuery = (from c in db.HydrometricDataValues
                let HydrometricDataValueReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let StorageDataTypeText = (from e in StorageDataTypeEnumList
                    where e.EnumID == (int?)c.StorageDataType
                    select e.EnumText).FirstOrDefault()
                    select new HydrometricDataValueExtraB
                    {
                        HydrometricDataValueReportTest = HydrometricDataValueReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        StorageDataTypeText = StorageDataTypeText,
                        HydrometricDataValueID = c.HydrometricDataValueID,
                        HydrometricSiteID = c.HydrometricSiteID,
                        DateTime_Local = c.DateTime_Local,
                        Keep = c.Keep,
                        StorageDataType = c.StorageDataType,
                        HasBeenRead = c.HasBeenRead,
                        Discharge_m3_s = c.Discharge_m3_s,
                        DischargeEntered_m3_s = c.DischargeEntered_m3_s,
                        Level_m = c.Level_m,
                        HourlyValues = c.HourlyValues,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return HydrometricDataValueExtraBQuery;
        }
        #endregion Functions private Generated FillHydrometricDataValueExtraB

    }
}
