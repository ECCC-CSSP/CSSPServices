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
    /// <summary>
    ///     <para>bonjour DocTemplate</para>
    /// </summary>
    public partial class DocTemplateService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DocTemplateService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DocTemplate docTemplate = validationContext.ObjectInstance as DocTemplate;
            docTemplate.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (docTemplate.DocTemplateID == 0)
                {
                    docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocTemplateDocTemplateID"), new[] { "DocTemplateID" });
                }

                if (!(from c in db.DocTemplates select c).Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
                {
                    docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateDocTemplateID", docTemplate.DocTemplateID.ToString()), new[] { "DocTemplateID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)docTemplate.Language);
            if (docTemplate.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocTemplateLanguage"), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)docTemplate.TVType);
            if (docTemplate.TVType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocTemplateTVType"), new[] { "TVType" });
            }

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "DocTemplateTVFileTVItemID", docTemplate.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "DocTemplateTVFileTVItemID", "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(docTemplate.FileName))
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocTemplateFileName"), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.FileName) && docTemplate.FileName.Length > 150)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "DocTemplateFileName", "150"), new[] { "FileName" });
            }

            if (docTemplate.LastUpdateDate_UTC.Year == 1)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "DocTemplateLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (docTemplate.LastUpdateDate_UTC.Year < 1980)
                {
                docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "DocTemplateLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "DocTemplateLastUpdateContactTVItemID", docTemplate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "DocTemplateLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public DocTemplate GetDocTemplateWithDocTemplateID(int DocTemplateID)
        {
            return (from c in db.DocTemplates
                    where c.DocTemplateID == DocTemplateID
                    select c).FirstOrDefault();

        }
        public IQueryable<DocTemplate> GetDocTemplateList()
        {
            IQueryable<DocTemplate> DocTemplateQuery = (from c in db.DocTemplates select c);

            DocTemplateQuery = EnhanceQueryStatements<DocTemplate>(DocTemplateQuery) as IQueryable<DocTemplate>;

            return DocTemplateQuery;
        }
        public DocTemplateWeb GetDocTemplateWebWithDocTemplateID(int DocTemplateID)
        {
            return FillDocTemplateWeb().Where(c => c.DocTemplateID == DocTemplateID).FirstOrDefault();

        }
        public IQueryable<DocTemplateWeb> GetDocTemplateWebList()
        {
            IQueryable<DocTemplateWeb> DocTemplateWebQuery = FillDocTemplateWeb();

            DocTemplateWebQuery = EnhanceQueryStatements<DocTemplateWeb>(DocTemplateWebQuery) as IQueryable<DocTemplateWeb>;

            return DocTemplateWebQuery;
        }
        public DocTemplateReport GetDocTemplateReportWithDocTemplateID(int DocTemplateID)
        {
            return FillDocTemplateReport().Where(c => c.DocTemplateID == DocTemplateID).FirstOrDefault();

        }
        public IQueryable<DocTemplateReport> GetDocTemplateReportList()
        {
            IQueryable<DocTemplateReport> DocTemplateReportQuery = FillDocTemplateReport();

            DocTemplateReportQuery = EnhanceQueryStatements<DocTemplateReport>(DocTemplateReportQuery) as IQueryable<DocTemplateReport>;

            return DocTemplateReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(DocTemplate docTemplate)
        {
            docTemplate.ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Create);
            if (docTemplate.ValidationResults.Count() > 0) return false;

            db.DocTemplates.Add(docTemplate);

            if (!TryToSave(docTemplate)) return false;

            return true;
        }
        public bool Delete(DocTemplate docTemplate)
        {
            docTemplate.ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Delete);
            if (docTemplate.ValidationResults.Count() > 0) return false;

            db.DocTemplates.Remove(docTemplate);

            if (!TryToSave(docTemplate)) return false;

            return true;
        }
        public bool Update(DocTemplate docTemplate)
        {
            docTemplate.ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Update);
            if (docTemplate.ValidationResults.Count() > 0) return false;

            db.DocTemplates.Update(docTemplate);

            if (!TryToSave(docTemplate)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated DocTemplateFillWeb
        private IQueryable<DocTemplateWeb> FillDocTemplateWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

             IQueryable<DocTemplateWeb>  DocTemplateWebQuery = (from c in db.DocTemplates
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new DocTemplateWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                        TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        DocTemplateID = c.DocTemplateID,
                        Language = c.Language,
                        TVType = c.TVType,
                        TVFileTVItemID = c.TVFileTVItemID,
                        FileName = c.FileName,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return DocTemplateWebQuery;
        }
        #endregion Functions private Generated DocTemplateFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(DocTemplate docTemplate)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                docTemplate.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
