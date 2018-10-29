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
    public partial class RatingCurveValueService
    {
        #region Functions private Generated FillRatingCurveValueExtraB
        private IQueryable<RatingCurveValueExtraB> FillRatingCurveValueExtraB()
        {
             IQueryable<RatingCurveValueExtraB> RatingCurveValueExtraBQuery = (from c in db.RatingCurveValues
                let RatingCurveValueReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new RatingCurveValueExtraB
                    {
                        RatingCurveValueReportTest = RatingCurveValueReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        RatingCurveValueID = c.RatingCurveValueID,
                        RatingCurveID = c.RatingCurveID,
                        StageValue_m = c.StageValue_m,
                        DischargeValue_m3_s = c.DischargeValue_m3_s,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return RatingCurveValueExtraBQuery;
        }
        #endregion Functions private Generated FillRatingCurveValueExtraB

    }
}
