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
    public partial class TVItemStatService
    {
        #region Functions private Generated FillTVItemStatExtraB
        private IQueryable<TVItemStatExtraB> FillTVItemStatExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<TVItemStatExtraB> TVItemStatExtraBQuery = (from c in db.TVItemStats
                let TVItemStatReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TVType
                    select e.EnumText).FirstOrDefault()
                    select new TVItemStatExtraB
                    {
                        TVItemStatReportTest = TVItemStatReportTest,
                        TVItemText = TVItemText,
                        LastUpdateContactText = LastUpdateContactText,
                        TVTypeText = TVTypeText,
                        TVItemStatID = c.TVItemStatID,
                        TVItemID = c.TVItemID,
                        TVType = c.TVType,
                        ChildCount = c.ChildCount,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVItemStatExtraBQuery;
        }
        #endregion Functions private Generated FillTVItemStatExtraB

    }
}
