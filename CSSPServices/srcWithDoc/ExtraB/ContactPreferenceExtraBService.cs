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
    public partial class ContactPreferenceService
    {
        #region Functions private Generated FillContactPreferenceExtraB
        /// <summary>
        /// Fills items [ContactPreferenceExtraB](CSSPModels.ContactPreferenceExtraB.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of ContactPreferenceExtraB</returns>
        private IQueryable<ContactPreferenceExtraB> FillContactPreferenceExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<ContactPreferenceExtraB> ContactPreferenceExtraBQuery = (from c in db.ContactPreferences
                let ContactPreferenceReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TVTypeText = (from e in TVTypeEnumList
                    where e.EnumID == (int?)c.TVType
                    select e.EnumText).FirstOrDefault()
                    select new ContactPreferenceExtraB
                    {
                        ContactPreferenceReportTest = ContactPreferenceReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        TVTypeText = TVTypeText,
                        ContactPreferenceID = c.ContactPreferenceID,
                        ContactID = c.ContactID,
                        TVType = c.TVType,
                        MarkerSize = c.MarkerSize,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ContactPreferenceExtraBQuery;
        }
        #endregion Functions private Generated FillContactPreferenceExtraB

    }
}
