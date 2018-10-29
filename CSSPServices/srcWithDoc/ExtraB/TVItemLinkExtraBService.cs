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
    public partial class TVItemLinkService
    {
        #region Functions private Generated FillTVItemLinkExtraB
        private IQueryable<TVItemLinkExtraB> FillTVItemLinkExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<TVItemLinkExtraB> TVItemLinkExtraBQuery = (from c in db.TVItemLinks
                let TVItemLinkReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let FromText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.FromTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ToText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ToTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let FromTVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.FromTVType
                    select e.EnumText).FirstOrDefault()
                let ToTVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.ToTVType
                    select e.EnumText).FirstOrDefault()
                    select new TVItemLinkExtraB
                    {
                        TVItemLinkReportTest = TVItemLinkReportTest,
                        FromText = FromText,
                        ToText = ToText,
                        LastUpdateContactText = LastUpdateContactText,
                        FromTVTypeText = FromTVTypeText,
                        ToTVTypeText = ToTVTypeText,
                        TVItemLinkID = c.TVItemLinkID,
                        FromTVItemID = c.FromTVItemID,
                        ToTVItemID = c.ToTVItemID,
                        FromTVType = c.FromTVType,
                        ToTVType = c.ToTVType,
                        StartDateTime_Local = c.StartDateTime_Local,
                        EndDateTime_Local = c.EndDateTime_Local,
                        Ordinal = c.Ordinal,
                        TVLevel = c.TVLevel,
                        TVPath = c.TVPath,
                        ParentTVItemLinkID = c.ParentTVItemLinkID,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVItemLinkExtraBQuery;
        }
        #endregion Functions private Generated FillTVItemLinkExtraB

    }
}
