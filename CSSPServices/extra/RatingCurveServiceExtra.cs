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
    public partial class RatingCurveService
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
        private IQueryable<RatingCurve> FillRatingCurveReport(IQueryable<RatingCurve> ratingCurveQuery)
        {
            ratingCurveQuery = (from c in ratingCurveQuery
                                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                               where cl.TVItemID == c.LastUpdateContactTVItemID
                                                               && cl.Language == LanguageRequest
                                                               select cl).FirstOrDefault()
                                select new RatingCurve
                                {
                                    RatingCurveID = c.RatingCurveID,
                                    HydrometricSiteID = c.HydrometricSiteID,
                                    RatingCurveNumber = c.RatingCurveNumber,
                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                    RatingCurveWeb = new RatingCurveWeb
                                    {
                                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                    },
                                    RatingCurveReport = new RatingCurveReport
                                    {
                                        RatingCurveReportTest = "RatingCurveReportTest",
                                    },
                                    HasErrors = false,
                                    ValidationResults = null,
                                });

            return ratingCurveQuery;
        }
        #endregion Functions private
    }
}
