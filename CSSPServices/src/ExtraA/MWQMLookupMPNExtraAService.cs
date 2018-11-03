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
    public partial class MWQMLookupMPNService
    {
        #region Functions private Generated FillMWQMLookupMPNExtraA
        private IQueryable<MWQMLookupMPNExtraA> FillMWQMLookupMPNExtraA()
        {
             IQueryable<MWQMLookupMPNExtraA> MWQMLookupMPNExtraAQuery = (from c in db.MWQMLookupMPNs
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MWQMLookupMPNExtraA
                    {
                        LastUpdateContactText = LastUpdateContactText,
                        MWQMLookupMPNID = c.MWQMLookupMPNID,
                        Tubes10 = c.Tubes10,
                        Tubes1 = c.Tubes1,
                        Tubes01 = c.Tubes01,
                        MPN_100ml = c.MPN_100ml,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MWQMLookupMPNExtraAQuery;
        }
        #endregion Functions private Generated FillMWQMLookupMPNExtraA

    }
}