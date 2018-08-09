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
        #region Functions private Generated FillContactShortcut_A
        private IQueryable<ContactShortcut_A> FillContactShortcut_A()
        {
             IQueryable<ContactShortcut_A> ContactShortcut_AQuery = (from c in db.ContactShortcuts
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new ContactShortcut_A
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ContactShortcutID = c.ContactShortcutID,
                        ContactID = c.ContactID,
                        ShortCutText = c.ShortCutText,
                        ShortCutAddress = c.ShortCutAddress,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return ContactShortcut_AQuery;
        }
        #endregion Functions private Generated FillContactShortcut_A

    }
}