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
    public partial class ClassificationService
    {
        #region Functions private Generated FillClassification_B
        private IQueryable<Classification_B> FillClassification_B()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ClassificationTypeEnumList = enums.GetEnumTextOrderedList(typeof(ClassificationTypeEnum));

             IQueryable<Classification_B> Classification_BQuery = (from c in db.Classifications
                let ClassificationReportTest = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new Classification_B
                    {
                        ClassificationReportTest = ClassificationReportTest,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        ClassificationTVText = (from e in ClassificationTypeEnumList
                                where e.EnumID == (int?)c.ClassificationType
                                select e.EnumText).FirstOrDefault(),
                        ClassificationID = c.ClassificationID,
                        ClassificationTVItemID = c.ClassificationTVItemID,
                        ClassificationType = c.ClassificationType,
                        Ordinal = c.Ordinal,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return Classification_BQuery;
        }
        #endregion Functions private Generated FillClassification_B

    }
}
