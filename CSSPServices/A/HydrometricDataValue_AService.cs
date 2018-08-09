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
        #region Functions private Generated FillHydrometricDataValue_A
        private IQueryable<HydrometricDataValue_A> FillHydrometricDataValue_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

             IQueryable<HydrometricDataValue_A> HydrometricDataValue_AQuery = (from c in db.HydrometricDataValues
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new HydrometricDataValue_A
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        StorageDataTypeText = (from e in StorageDataTypeEnumList
                                where e.EnumID == (int?)c.StorageDataType
                                select e.EnumText).FirstOrDefault(),
                        HydrometricDataValueID = c.HydrometricDataValueID,
                        HydrometricSiteID = c.HydrometricSiteID,
                        DateTime_Local = c.DateTime_Local,
                        Keep = c.Keep,
                        StorageDataType = c.StorageDataType,
                        Flow_m3_s = c.Flow_m3_s,
                        HourlyValues = c.HourlyValues,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return HydrometricDataValue_AQuery;
        }
        #endregion Functions private Generated FillHydrometricDataValue_A

    }
}
