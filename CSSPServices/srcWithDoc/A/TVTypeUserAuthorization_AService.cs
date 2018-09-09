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
        #region Functions private Generated FillTVTypeUserAuthorization_A
        private IQueryable<TVTypeUserAuthorization_A> FillTVTypeUserAuthorization_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

             IQueryable<TVTypeUserAuthorization_A> TVTypeUserAuthorization_AQuery = (from c in db.TVTypeUserAuthorizations
                let ContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TVTypeUserAuthorization_A
                    {
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

            return TVTypeUserAuthorization_AQuery;
        }
        #endregion Functions private Generated FillTVTypeUserAuthorization_A

    }
}
