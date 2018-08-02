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
    public partial class BoxModelLanguageService
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
        private IQueryable<BoxModelLanguage> FillBoxModelLanguageReport(IQueryable<BoxModelLanguage> boxModelLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            boxModelLanguageQuery = (from c in boxModelLanguageQuery
                                     let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                            where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                            && cl.Language == LanguageRequest
                                                                            select cl).FirstOrDefault()
                                     select new BoxModelLanguage
                                     {
                                         BoxModelLanguageID = c.BoxModelLanguageID,
                                         BoxModelID = c.BoxModelID,
                                         Language = c.Language,
                                         ScenarioName = c.ScenarioName,
                                         TranslationStatus = c.TranslationStatus,
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         BoxModelLanguageWeb = new BoxModelLanguageWeb
                                         {
                                             LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                             LanguageText = (from e in LanguageEnumList
                                                             where e.EnumID == (int?)c.Language
                                                             select e.EnumText).FirstOrDefault(),
                                             TranslationStatusText = (from e in TranslationStatusEnumList
                                                                      where e.EnumID == (int?)c.TranslationStatus
                                                                      select e.EnumText).FirstOrDefault(),
                                         },
                                         BoxModelLanguageReport = new BoxModelLanguageReport
                                         {
                                             BoxModelLanguageReportTest = "BoxModelLanguageReportTest",
                                         },
                                         HasErrors = false,
                                         ValidationResults = null,
                                     });

            return boxModelLanguageQuery;
        }
        #endregion Functions private
    }
}
