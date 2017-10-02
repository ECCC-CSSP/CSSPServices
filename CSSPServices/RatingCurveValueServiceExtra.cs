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
    public partial class RatingCurveValueService
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
        private IQueryable<RatingCurveValue> FillRatingCurveValueReport(IQueryable<RatingCurveValue> ratingCurveValueQuery, string FilterAndOrderText)
        {
            ratingCurveValueQuery = (from c in ratingCurveValueQuery
                                     let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                    where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                    && cl.Language == LanguageRequest
                                                                    select cl.TVText).FirstOrDefault()
                                     select new RatingCurveValue
                                     {
                                         RatingCurveValueID = c.RatingCurveValueID,
                                         RatingCurveID = c.RatingCurveID,
                                         StageValue_m = c.StageValue_m,
                                         DischargeValue_m3_s = c.DischargeValue_m3_s,
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         RatingCurveValueWeb = new RatingCurveValueWeb
                                         {
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                         },
                                         RatingCurveValueReport = new RatingCurveValueReport
                                         {
                                             RatingCurveValueReportTest = "RatingCurveValueReportTest",
                                         },
                                         HasErrors = false,
                                         ValidationResults = null,
                                     });

            return ratingCurveValueQuery;
        }
        #endregion Functions private
    }
}
