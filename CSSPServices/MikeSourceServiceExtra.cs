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
    public partial class MikeSourceService
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
        private IQueryable<MikeSource> FillMikeSourceReport(IQueryable<MikeSource> mikeSourceQuery, string FilterAndOrderText)
        {
            mikeSourceQuery = (from c in mikeSourceQuery
                               let MikeSourceTVText = (from cl in db.TVItemLanguages
                                                       where cl.TVItemID == c.MikeSourceTVItemID
                                                       && cl.Language == LanguageRequest
                                                       select cl.TVText).FirstOrDefault()
                               let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                               select new MikeSource
                               {
                                   MikeSourceID = c.MikeSourceID,
                                   MikeSourceTVItemID = c.MikeSourceTVItemID,
                                   IsContinuous = c.IsContinuous,
                                   Include = c.Include,
                                   IsRiver = c.IsRiver,
                                   SourceNumberString = c.SourceNumberString,
                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                   MikeSourceWeb = new MikeSourceWeb
                                   {
                                       MikeSourceTVText = MikeSourceTVText,
                                       LastUpdateContactTVText = LastUpdateContactTVText,
                                   },
                                   MikeSourceReport = new MikeSourceReport
                                   {
                                       MikeSourceReportTest = "MikeSourceReportTest",
                                   },
                                   HasErrors = false,
                                   ValidationResults = null,
                               });

            return mikeSourceQuery;
        }
        #endregion Functions private
    }
}
