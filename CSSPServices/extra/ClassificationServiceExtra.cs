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
    public partial class ClassificationService
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
        private IQueryable<Classification> FillClassificationReport(IQueryable<Classification> ClassificationQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> ClassificationEnumList = enums.GetEnumTextOrderedList(typeof(ClassificationTypeEnum));

            ClassificationQuery = (from c in ClassificationQuery
                                     let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                    where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                    && cl.Language == LanguageRequest
                                                                    select cl).FirstOrDefault()
                                     select new Classification
                                     {
                                         ClassificationID = c.ClassificationID,
                                         ClassificationTVItemID = c.ClassificationTVItemID,
                                         ClassificationType = c.ClassificationType,
                                         Ordinal = c.Ordinal,
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         ClassificationWeb = new ClassificationWeb
                                         {
                                             LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                             ClassificationTVText = (from e in ClassificationEnumList
                                                                     where e.EnumID == (int?)c.ClassificationType
                                                                     select e.EnumText).FirstOrDefault(),
                                         },
                                         ClassificationReport = new ClassificationReport
                                         {
                                             ClassificationReportTest = "ClassificationReportTest",
                                         },
                                         HasErrors = false,
                                         ValidationResults = null,
                                     });

            return ClassificationQuery;
        }
        #endregion Functions private
    }
}
