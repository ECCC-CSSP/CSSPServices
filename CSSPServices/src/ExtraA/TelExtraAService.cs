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
    public partial class TelService
    {
        #region Functions private Generated FillTelExtraA
        private IQueryable<TelExtraA> FillTelExtraA()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TelTypeEnumList = enums.GetEnumTextOrderedList(typeof(TelTypeEnum));

             IQueryable<TelExtraA> TelExtraAQuery = (from c in db.Tels
                let TelNumberText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TelTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let TelTypeText = (from e in TelTypeEnumList
                    where e.EnumID == (int?)c.TelType
                    select e.EnumText).FirstOrDefault()
                    select new TelExtraA
                    {
                        TelNumberText = TelNumberText,
                        LastUpdateContactText = LastUpdateContactText,
                        TelTypeText = TelTypeText,
                        TelID = c.TelID,
                        TelTVItemID = c.TelTVItemID,
                        TelNumber = c.TelNumber,
                        TelType = c.TelType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return TelExtraAQuery;
        }
        #endregion Functions private Generated FillTelExtraA

    }
}