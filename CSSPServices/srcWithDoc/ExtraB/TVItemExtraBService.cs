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
    public partial class TVItemService
    {
        #region Functions private Generated FillTVItemExtraB
        private IQueryable<TVItemExtraB> FillTVItemExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<TVItemExtraB> TVItemExtraBQuery = (from c in db.TVItems
                let TVItemReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVItemExtraB
                    {
                        TVItemReportTest = TVItemReportTest,
                        TVItemLanguage = TVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        TVItemID = c.TVItemID,
                        TVLevel = c.TVLevel,
                        TVPath = c.TVPath,
                        TVType = c.TVType,
                        ParentID = c.ParentID,
                        IsActive = c.IsActive,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVItemExtraBQuery;
        }
        #endregion Functions private Generated FillTVItemExtraB

    }
}
