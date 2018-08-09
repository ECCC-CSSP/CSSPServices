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
        #region Functions private Generated FillTVItemLink_B
        private IQueryable<TVItemLink_B> FillTVItemLink_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<TVItemLink_B> TVItemLink_BQuery = (from c in db.TVItemLinks
                let TVItemLinkReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let FromTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.FromTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ToTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ToTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVItemLink_B
                    {
                        TVItemLinkReportTest = TVItemLinkReportTest,
                        FromTVItemLanguage = FromTVItemLanguage,
                        ToTVItemLanguage = ToTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        FromTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.FromTVType
                                select e.EnumText).FirstOrDefault(),
                        ToTVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.ToTVType
                                select e.EnumText).FirstOrDefault(),
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

            return TVItemLink_BQuery;
        }
        #endregion Functions private Generated FillTVItemLink_B

    }
}
