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
    public partial class TVTypeUserAuthorizationService
    {
        #region Functions private Generated FillTVTypeUserAuthorization_B
        private IQueryable<TVTypeUserAuthorization_B> FillTVTypeUserAuthorization_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

             IQueryable<TVTypeUserAuthorization_B> TVTypeUserAuthorization_BQuery = (from c in db.TVTypeUserAuthorizations
                let TVTypeUserAuthorizationReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVTypeUserAuthorization_B
                    {
                        TVTypeUserAuthorizationReportTest = TVTypeUserAuthorizationReportTest,
                        ContactTVItemLanguage = ContactTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        TVAuthText = (from e in TVAuthEnumList
                                where e.EnumID == (int?)c.TVAuth
                                select e.EnumText).FirstOrDefault(),
                        TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                        ContactTVItemID = c.ContactTVItemID,
                        TVType = c.TVType,
                        TVAuth = c.TVAuth,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVTypeUserAuthorization_BQuery;
        }
        #endregion Functions private Generated FillTVTypeUserAuthorization_B

    }
}
