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
    public partial class MikeSourceService
    {
        #region Functions private Generated FillMikeSourceExtraB
        private IQueryable<MikeSourceExtraB> FillMikeSourceExtraB()
        {
             IQueryable<MikeSourceExtraB> MikeSourceExtraBQuery = (from c in db.MikeSources
                let MikeSourceReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MikeSourceTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MikeSourceTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new MikeSourceExtraB
                    {
                        MikeSourceReportTest = MikeSourceReportTest,
                        MikeSourceTVItemLanguage = MikeSourceTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        MikeSourceID = c.MikeSourceID,
                        MikeSourceTVItemID = c.MikeSourceTVItemID,
                        IsContinuous = c.IsContinuous,
                        Include = c.Include,
                        IsRiver = c.IsRiver,
                        UseHydrometric = c.UseHydrometric,
                        HydrometricTVItemID = c.HydrometricTVItemID,
                        DrainageArea_km2 = c.DrainageArea_km2,
                        Factor = c.Factor,
                        SourceNumberString = c.SourceNumberString,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return MikeSourceExtraBQuery;
        }
        #endregion Functions private Generated FillMikeSourceExtraB

    }
}
