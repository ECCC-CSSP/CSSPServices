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
    public partial class TVItemStatService
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
        private IQueryable<TVItemStat> FillTVItemStatReport(IQueryable<TVItemStat> tvItemStatQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            tvItemStatQuery = (from c in tvItemStatQuery
                               let TVText = (from cl in db.TVItemLanguages
                                             where cl.TVItemID == c.TVItemID
                                             && cl.Language == LanguageRequest
                                             select cl.TVText).FirstOrDefault()
                               let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                               select new TVItemStat
                               {
                                   TVItemStatID = c.TVItemStatID,
                                   TVItemID = c.TVItemID,
                                   TVType = c.TVType,
                                   ChildCount = c.ChildCount,
                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                   TVItemStatWeb = new TVItemStatWeb
                                   {
                                       TVText = TVText,
                                       LastUpdateContactTVText = LastUpdateContactTVText,
                                       TVTypeText = (from e in TVTypeEnumList
                                                     where e.EnumID == (int?)c.TVType
                                                     select e.EnumText).FirstOrDefault(),
                                   },
                                   TVItemStatReport = new TVItemStatReport
                                   {
                                       TVItemStatReportTest = "TVItemStatReportTest",
                                   },
                                   HasErrors = false,
                                   ValidationResults = null,
                               });

            return tvItemStatQuery;
        }
        #endregion Functions private
    }
}
