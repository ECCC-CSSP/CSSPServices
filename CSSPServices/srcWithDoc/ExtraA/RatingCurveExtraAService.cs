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
        #region Functions private Generated FillRatingCurveExtraA
        private IQueryable<RatingCurveExtraA> FillRatingCurveExtraA()
        {
             IQueryable<RatingCurveExtraA> RatingCurveExtraAQuery = (from c in db.RatingCurves
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new RatingCurveExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        RatingCurveID = c.RatingCurveID,
                        HydrometricSiteID = c.HydrometricSiteID,
                        RatingCurveNumber = c.RatingCurveNumber,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return RatingCurveExtraAQuery;
        }
        #endregion Functions private Generated FillRatingCurveExtraA

    }
}
