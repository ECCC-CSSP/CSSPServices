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
    public partial class TVItemUserAuthorizationService
    {
        #region Functions private Generated FillTVItemUserAuthorizationExtraA
        private IQueryable<TVItemUserAuthorizationExtraA> FillTVItemUserAuthorizationExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

             IQueryable<TVItemUserAuthorizationExtraA> TVItemUserAuthorizationExtraAQuery = (from c in db.TVItemUserAuthorizations
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let TVItemLanguage1 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID1
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let TVItemLanguage2 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID2
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let TVItemLanguage3 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID3
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let TVItemLanguage4 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID4
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVItemUserAuthorizationExtraA
                    {
                        ContactTVItemLanguage = ContactTVItemLanguage,
                        TVItemLanguage1 = TVItemLanguage1,
                        TVItemLanguage2 = TVItemLanguage2,
                        TVItemLanguage3 = TVItemLanguage3,
                        TVItemLanguage4 = TVItemLanguage4,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TVAuthText = (from e in TVAuthEnumList
                                where e.EnumID == (int?)c.TVAuth
                                select e.EnumText).FirstOrDefault(),
                        TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                        ContactTVItemID = c.ContactTVItemID,
                        TVItemID1 = c.TVItemID1,
                        TVItemID2 = c.TVItemID2,
                        TVItemID3 = c.TVItemID3,
                        TVItemID4 = c.TVItemID4,
                        TVAuth = c.TVAuth,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVItemUserAuthorizationExtraAQuery;
        }
        #endregion Functions private Generated FillTVItemUserAuthorizationExtraA

    }
}
