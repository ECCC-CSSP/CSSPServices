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
    public partial class ContactShortcutService
    {
        #region Functions private Generated FillContactShortcutExtraA
        /// <summary>
        /// Fills items [ContactShortcutExtraA](CSSPModels.ContactShortcutExtraA.html) from CSSPDB
        /// </summary>
        /// <returns>IQueryable of ContactShortcutExtraA</returns>
        private IQueryable<ContactShortcutExtraA> FillContactShortcutExtraA()
        {
             IQueryable<ContactShortcutExtraA> ContactShortcutExtraAQuery = (from c in db.ContactShortcuts
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new ContactShortcutExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        ContactShortcutID = c.ContactShortcutID,
                        ContactID = c.ContactID,
                        ShortCutText = c.ShortCutText,
                        ShortCutAddress = c.ShortCutAddress,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ContactShortcutExtraAQuery;
        }
        #endregion Functions private Generated FillContactShortcutExtraA

    }
}
