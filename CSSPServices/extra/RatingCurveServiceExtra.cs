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
    public partial class RatingCurveService
    {
        #region Functions private Generated RatingCurveFillReport
        private IQueryable<RatingCurveReport> FillRatingCurveReport()
        {
             IQueryable<RatingCurveReport>  RatingCurveReportQuery = (from c in db.RatingCurves
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new RatingCurveReport
                    {
                        RatingCurveReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        RatingCurveID = c.RatingCurveID,
                        HydrometricSiteID = c.HydrometricSiteID,
                        RatingCurveNumber = c.RatingCurveNumber,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return RatingCurveReportQuery;
        }
        #endregion Functions private Generated RatingCurveFillReport

    }
}
