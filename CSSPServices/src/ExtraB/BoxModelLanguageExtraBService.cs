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
    public partial class BoxModelLanguageService
    {
        #region Functions private Generated FillBoxModelLanguageExtraB
        private IQueryable<BoxModelLanguageExtraB> FillBoxModelLanguageExtraB()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

             IQueryable<BoxModelLanguageExtraB> BoxModelLanguageExtraBQuery = (from c in db.BoxModelLanguages
                let BoxModelLanguageReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LanguageText = (from e in LanguageEnumList
                    where e.EnumID == (int?)c.Language
                    select e.EnumText).FirstOrDefault()
                let TranslationStatusText = (from e in TranslationStatusEnumList
                    where e.EnumID == (int?)c.TranslationStatus
                    select e.EnumText).FirstOrDefault()
                    select new BoxModelLanguageExtraB
                    {
                        BoxModelLanguageReportTest = BoxModelLanguageReportTest,
                        LastUpdateContactText = LastUpdateContactText,
                        LanguageText = LanguageText,
                        TranslationStatusText = TranslationStatusText,
                        BoxModelLanguageID = c.BoxModelLanguageID,
                        BoxModelID = c.BoxModelID,
                        Language = c.Language,
                        ScenarioName = c.ScenarioName,
                        TranslationStatus = c.TranslationStatus,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return BoxModelLanguageExtraBQuery;
        }
        #endregion Functions private Generated FillBoxModelLanguageExtraB

    }
}
