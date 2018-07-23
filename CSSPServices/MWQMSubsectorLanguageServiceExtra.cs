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
    public partial class MWQMSubsectorLanguageService
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
        private IQueryable<MWQMSubsectorLanguage> FillMWQMSubsectorLanguageReport(IQueryable<MWQMSubsectorLanguage> mwqmSubsectorLanguageQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TranslationStatusEnumList = enums.GetEnumTextOrderedList(typeof(TranslationStatusEnum));

            mwqmSubsectorLanguageQuery = (from c in mwqmSubsectorLanguageQuery
                                          let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                                         where cl.TVItemID == c.LastUpdateContactTVItemID
                                                                         && cl.Language == LanguageRequest
                                                                         select cl.TVText).FirstOrDefault()
                                          select new MWQMSubsectorLanguage
                                          {
                                              MWQMSubsectorLanguageID = c.MWQMSubsectorLanguageID,
                                              MWQMSubsectorID = c.MWQMSubsectorID,
                                              Language = c.Language,
                                              SubsectorDesc = c.SubsectorDesc,
                                              TranslationStatusSubsectorDesc = c.TranslationStatusSubsectorDesc,
                                              LogBook = c.LogBook,
                                              TranslationStatusLogBook = c.TranslationStatusLogBook,
                                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                              MWQMSubsectorLanguageWeb = new MWQMSubsectorLanguageWeb
                                              {
                                                  LastUpdateContactTVText = LastUpdateContactTVText,
                                                  LanguageText = (from e in LanguageEnumList
                                                                  where e.EnumID == (int?)c.Language
                                                                  select e.EnumText).FirstOrDefault(),
                                                  TranslationStatusSubsectorDescText = (from e in TranslationStatusEnumList
                                                                                        where e.EnumID == (int?)c.TranslationStatusSubsectorDesc
                                                                                        select e.EnumText).FirstOrDefault(),
                                                  TranslationStatusLogBookText = (from e in TranslationStatusEnumList
                                                                                  where e.EnumID == (int?)c.TranslationStatusLogBook
                                                                                  select e.EnumText).FirstOrDefault(),
                                              },
                                              MWQMSubsectorLanguageReport = new MWQMSubsectorLanguageReport
                                              {
                                                  MWQMSubsectorLanguageReportTest = "MWQMSubsectorLanguageReportTest",
                                              },
                                              HasErrors = false,
                                              ValidationResults = null,
                                          });

            return mwqmSubsectorLanguageQuery;
        }
        #endregion Functions private
    }
}
