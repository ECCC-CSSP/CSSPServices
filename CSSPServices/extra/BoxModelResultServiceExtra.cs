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
    public partial class BoxModelResultService
    {
        #region Functions private Generated BoxModelResultFillReport
        private IQueryable<BoxModelResultReport> FillBoxModelResultReport()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> BoxModelResultTypeEnumList = enums.GetEnumTextOrderedList(typeof(BoxModelResultTypeEnum));

             IQueryable<BoxModelResultReport>  BoxModelResultReportQuery = (from c in db.BoxModelResults
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new BoxModelResultReport
                    {
                        BoxModelResultReportTest = "Testing Report",
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        BoxModelResultTypeText = (from e in BoxModelResultTypeEnumList
                                where e.EnumID == (int?)c.BoxModelResultType
                                select e.EnumText).FirstOrDefault(),
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return BoxModelResultReportQuery;
        }
        #endregion Functions private Generated BoxModelResultFillReport

    }
}
