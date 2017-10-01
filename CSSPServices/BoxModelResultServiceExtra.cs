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
    public partial class BoxModelResultService
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
        private IQueryable<BoxModelResult> FillBoxModelResult(IQueryable<BoxModelResult> boxModelResultQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> BoxModelResultTypeEnumList = enums.GetEnumTextOrderedList(typeof(BoxModelResultTypeEnum));

            boxModelResultQuery = (from c in boxModelResultQuery
                                   let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                  where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                  && cl.Language == LanguageRequest
                                                                  select cl.TVText).FirstOrDefault()
                                   select new BoxModelResult
                                   {
                                       BoxModelResultID = c.BoxModelResultID,
                                       BoxModelID = c.BoxModelID,
                                       BoxModelResultType = c.BoxModelResultType,
                                       Volume_m3 = c.Volume_m3,
                                       Surface_m2 = c.Surface_m2,
                                       Radius_m = c.Radius_m,
                                       LeftSideDiameterLineAngle_deg = c.LeftSideDiameterLineAngle_deg,
                                       CircleCenterLatitude = c.CircleCenterLatitude,
                                       CircleCenterLongitude = c.CircleCenterLongitude,
                                       FixLength = c.FixLength,
                                       FixWidth = c.FixWidth,
                                       RectLength_m = c.RectLength_m,
                                       RectWidth_m = c.RectWidth_m,
                                       LeftSideLineAngle_deg = c.LeftSideLineAngle_deg,
                                       LeftSideLineStartLatitude = c.LeftSideLineStartLatitude,
                                       LeftSideLineStartLongitude = c.LeftSideLineStartLongitude,
                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       BoxModelResultWeb = new BoxModelResultWeb
                                       {
                                           LastUpdateContactTVText = LastUpdateContactTVText,
                                           BoxModelResultTypeText = (from e in BoxModelResultTypeEnumList
                                                                     where e.EnumID == (int?)c.BoxModelResultType
                                                                     select e.EnumText).FirstOrDefault(),
                                       },
                                       BoxModelResultReport = new BoxModelResultReport
                                       {
                                           BoxModelResultReportTest = "BoxModelResultReportTest",
                                       },
                                       HasErrors = false,
                                       ValidationResults = null,
                                   });

            return boxModelResultQuery;
        }
        #endregion Functions private
    }
}
