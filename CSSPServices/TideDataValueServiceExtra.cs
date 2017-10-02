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
    public partial class TideDataValueService
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
        private IQueryable<TideDataValue> FillTideDataValueReport(IQueryable<TideDataValue> tideDataValueQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TideDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(TideDataTypeEnum));
            List<EnumIDAndText> StorageDataTypeEnumList = enums.GetEnumTextOrderedList(typeof(StorageDataTypeEnum));
            List<EnumIDAndText> TideTextEnumList = enums.GetEnumTextOrderedList(typeof(TideTextEnum));

            tideDataValueQuery = (from c in tideDataValueQuery
                                  let TideSiteTVText = (from cl in db.TVItemLanguages
                                                        where cl.TVItemID == c.TideSiteTVItemID
                                                        && cl.Language == LanguageRequest
                                                        select cl.TVText).FirstOrDefault()
                                  let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                 where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                 && cl.Language == LanguageRequest
                                                                 select cl.TVText).FirstOrDefault()
                                  select new TideDataValue
                                  {
                                      TideDataValueID = c.TideDataValueID,
                                      TideSiteTVItemID = c.TideSiteTVItemID,
                                      DateTime_Local = c.DateTime_Local,
                                      Keep = c.Keep,
                                      TideDataType = c.TideDataType,
                                      StorageDataType = c.StorageDataType,
                                      Depth_m = c.Depth_m,
                                      UVelocity_m_s = c.UVelocity_m_s,
                                      VVelocity_m_s = c.VVelocity_m_s,
                                      TideStart = c.TideStart,
                                      TideEnd = c.TideEnd,
                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                      TideDataValueWeb = new TideDataValueWeb
                                      {
                                          TideSiteTVText = TideSiteTVText,
                                          LastUpdateContactTVText = LastUpdateContactTVText,
                                          TideDataTypeText = (from e in TideDataTypeEnumList
                                                              where e.EnumID == (int?)c.TideDataType
                                                              select e.EnumText).FirstOrDefault(),
                                          StorageDataTypeText = (from e in StorageDataTypeEnumList
                                                                 where e.EnumID == (int?)c.StorageDataType
                                                                 select e.EnumText).FirstOrDefault(),
                                          TideStartText = (from e in TideTextEnumList
                                                           where e.EnumID == (int?)c.TideStart
                                                           select e.EnumText).FirstOrDefault(),
                                          TideEndText = (from e in TideTextEnumList
                                                         where e.EnumID == (int?)c.TideEnd
                                                         select e.EnumText).FirstOrDefault(),
                                      },
                                      TideDataValueReport = new TideDataValueReport
                                      {
                                          TideDataValueReportTest = "TideDataValueReportTest",
                                      },
                                      HasErrors = false,
                                      ValidationResults = null,
                                  });

            return tideDataValueQuery;
        }
        #endregion Functions private
    }
}
