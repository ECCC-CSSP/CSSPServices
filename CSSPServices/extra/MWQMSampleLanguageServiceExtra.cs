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
    public partial class MWQMSampleLanguageService
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
        private IQueryable<MWQMSampleLanguage> FillMWQMSampleLanguageReport(IQueryable<MWQMSampleLanguage> mwqmSampleLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            mwqmSampleLanguageQuery = (from c in mwqmSampleLanguageQuery
                                       let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                                      where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                      && cl.Language == LanguageRequest
                                                                      select cl).FirstOrDefault()
                                       select new MWQMSampleLanguage
                                       {
                                           MWQMSampleLanguageID = c.MWQMSampleLanguageID,
                                           MWQMSampleID = c.MWQMSampleID,
                                           Language = c.Language,
                                           MWQMSampleNote = c.MWQMSampleNote,
                                           TranslationStatus = c.TranslationStatus,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           MWQMSampleLanguageWeb = new MWQMSampleLanguageWeb
                                           {
                                               LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                               LanguageText = (from e in LanguageEnumList
                                                               where e.EnumID == (int?)c.Language
                                                               select e.EnumText).FirstOrDefault(),
                                               TranslationStatusText = (from e in TranslationStatusEnumList
                                                                        where e.EnumID == (int?)c.TranslationStatus
                                                                        select e.EnumText).FirstOrDefault(),
                                           },
                                           MWQMSampleLanguageReport = new MWQMSampleLanguageReport
                                           {
                                               MWQMSampleLanguageReportTest = "MWQMSampleLanguageReportTest",
                                           },
                                           HasErrors = false,
                                           ValidationResults = null,
                                       });

            return mwqmSampleLanguageQuery;
        }
        #endregion Functions private
    }
}
