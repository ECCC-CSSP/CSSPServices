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
    public partial class DocTemplateService
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
        private IQueryable<DocTemplate> FillDocTemplateReport(IQueryable<DocTemplate> docTemplateQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            docTemplateQuery = (from c in docTemplateQuery
                                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                                                               where cl.TVItemID == c.LastUpdateContactTVItemID
                                                               && cl.Language == LanguageRequest
                                                               select cl).FirstOrDefault()
                                select new DocTemplate
                                {
                                    DocTemplateID = c.DocTemplateID,
                                    Language = c.Language,
                                    TVType = c.TVType,
                                    TVFileTVItemID = c.TVFileTVItemID,
                                    FileName = c.FileName,
                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                    DocTemplateWeb = new DocTemplateWeb
                                    {
                                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                                        LanguageText = (from e in LanguageEnumList
                                                        where e.EnumID == (int?)c.Language
                                                        select e.EnumText).FirstOrDefault(),
                                        TVTypeText = (from e in TVTypeEnumList
                                                      where e.EnumID == (int?)c.TVType
                                                      select e.EnumText).FirstOrDefault(),
                                    },
                                    DocTemplateReport = new DocTemplateReport
                                    {
                                        DocTemplateReportTest = "DocTemplateReportTest",
                                    },
                                    HasErrors = false,
                                    ValidationResults = null,
                                });

            return docTemplateQuery;
        }
        #endregion Functions private
    }
}
