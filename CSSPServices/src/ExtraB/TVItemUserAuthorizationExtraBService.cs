/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
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
    public partial class TVItemUserAuthorizationService
    {
        #region Functions private Generated FillTVItemUserAuthorizationExtraB
        private IQueryable<TVItemUserAuthorizationExtraB> FillTVItemUserAuthorizationExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVAuthEnumList = enums.GetEnumTextOrderedList(typeof(TVAuthEnum));

             IQueryable<TVItemUserAuthorizationExtraB> TVItemUserAuthorizationExtraBQuery = (from c in db.TVItemUserAuthorizations
                let TVItemUserAuthorizationReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ContactName = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText1 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID1
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText2 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID2
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText3 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID3
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVItemText4 = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TVItemID4
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVAuthText = (from e in TVAuthEnumList
                    where e.EnumID == (int?)c.TVAuth
                    select e.EnumText).FirstOrDefault()
                    select new TVItemUserAuthorizationExtraB
                    {
                        TVItemUserAuthorizationReportTest = TVItemUserAuthorizationReportTest,
                        ContactName = ContactName,
                        TVItemText1 = TVItemText1,
                        TVItemText2 = TVItemText2,
                        TVItemText3 = TVItemText3,
                        TVItemText4 = TVItemText4,
                        LastUpdateContactText = LastUpdateContactText,
                        TVAuthText = TVAuthText,
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

            return TVItemUserAuthorizationExtraBQuery;
        }
        #endregion Functions private Generated FillTVItemUserAuthorizationExtraB

    }
}
