/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        #region Functions private Generated FillTVTypeUserAuthorizationExtraA
        /// <summary>
        /// Fills items [TVTypeUserAuthorizationExtraA](CSSPModels.TVTypeUserAuthorizationExtraA.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of TVTypeUserAuthorizationExtraA</returns>
        private IQueryable<TVTypeUserAuthorizationExtraA> FillTVTypeUserAuthorizationExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));
            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

             IQueryable<TVTypeUserAuthorizationExtraA> TVTypeUserAuthorizationExtraAQuery = (from c in db.TVTypeUserAuthorizations
                let ContactName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TVType
                    select e.EnumText).FirstOrDefault()
                let TVAuthText = (from e in TVAuthEnumList
                    where e.EnumID == (int?)c.TVAuth
                    select e.EnumText).FirstOrDefault()
                    select new TVTypeUserAuthorizationExtraA
                    {
                        ContactName = ContactName,
                        LastUpdateContactText = LastUpdateContactText,
                        TVTypeText = TVTypeText,
                        TVAuthText = TVAuthText,
                        TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                        ContactTVItemID = c.ContactTVItemID,
                        TVType = c.TVType,
                        TVAuth = c.TVAuth,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TVTypeUserAuthorizationExtraAQuery;
        }
        #endregion Functions private Generated FillTVTypeUserAuthorizationExtraA

    }
}
