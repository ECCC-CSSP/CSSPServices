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
        #region Functions private Generated FillTel_A
        private IQueryable<Tel_A> FillTel_A()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TelTypeEnumList = enums.GetEnumTextOrderedList(typeof(TelTypeEnum));

             IQueryable<Tel_A> Tel_AQuery = (from c in db.Tels
                let TelTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TelTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new Tel_A
                    {
                        TelTVItemLanguage = TelTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TelTypeText = (from e in TelTypeEnumList
                                where e.EnumID == (int?)c.TelType
                                select e.EnumText).FirstOrDefault(),
                        TelID = c.TelID,
                        TelTVItemID = c.TelTVItemID,
                        TelNumber = c.TelNumber,
                        TelType = c.TelType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return Tel_AQuery;
        }
        #endregion Functions private Generated FillTel_A

    }
}
