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
    public partial class HydrometricDataValueService
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
        private IQueryable<HydrometricDataValue> FillHydrometricDataValueReport(IQueryable<HydrometricDataValue> hydrometricDataValueQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));

            hydrometricDataValueQuery = (from c in hydrometricDataValueQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                        where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                        && cl.Language == LanguageRequest
                                                                        select cl.TVText).FirstOrDefault()
                                         select new HydrometricDataValue
                                         {
                                             HydrometricDataValueID = c.HydrometricDataValueID,
                                             HydrometricSiteID = c.HydrometricSiteID,
                                             DateTime_Local = c.DateTime_Local,
                                             Keep = c.Keep,
                                             StorageDataType = c.StorageDataType,
                                             Flow_m3_s = c.Flow_m3_s,
                                             HourlyValues = c.HourlyValues,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             HydrometricDataValueWeb = new HydrometricDataValueWeb
                                             {
                                                 LastUpdateContactTVText = LastUpdateContactTVText,
                                                 StorageDataTypeText = (from e in StorageDataTypeEnumList
                                                                        where e.EnumID == (int?)c.StorageDataType
                                                                        select e.EnumText).FirstOrDefault(),
                                             },
                                             HydrometricDataValueReport = new HydrometricDataValueReport
                                             {
                                                 HydrometricDataValueReportTest = "HydrometricDataValueReportTest",
                                             },
                                             HasErrors = false,
                                             ValidationResults = null,
                                         });

            return hydrometricDataValueQuery;
        }
        #endregion Functions private
    }
}
