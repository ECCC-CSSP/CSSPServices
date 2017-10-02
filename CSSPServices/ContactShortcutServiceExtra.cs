using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class ContactShortcutService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Validation
        #endregion Validation

        #region Functions public
        #endregion Functions public

        #region Functions private
        private IQueryable<ContactShortcut> FillContactShortcutReport(IQueryable<ContactShortcut> contactShortcutQuery, string FilterAndOrderText)
        {
            contactShortcutQuery = (from c in contactShortcutQuery
                                    let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                   where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                   && cl.Language == LanguageRequest
                                                                   select cl.TVText).FirstOrDefault()
                                    select new ContactShortcut
                                    {
                                        ContactShortcutID = c.ContactShortcutID,
                                        ContactID = c.ContactID,
                                        ShortCutText = c.ShortCutText,
                                        ShortCutAddress = c.ShortCutAddress,
                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                        ContactShortcutWeb = new ContactShortcutWeb
                                        {
                                            LastUpdateContactTVText = LastUpdateContactTVText,
                                        },
                                        ContactShortcutReport = new ContactShortcutReport
                                        {
                                            ContactShortcutReportTest = "ContactShortcutReportTest",
                                        },
                                        HasErrors = false,
                                        ValidationResults = null,
                                    });

            return contactShortcutQuery;
        }
        #endregion Functions private
    }
}
