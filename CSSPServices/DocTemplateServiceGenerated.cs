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
        public DocTemplateService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateDocTemplateID), new[] { "DocTemplateID" });
                }

                if (!GetRead().Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
                {
                    docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.DocTemplate, CSSPModelsRes.DocTemplateDocTemplateID, docTemplate.DocTemplateID.ToString()), new[] { "DocTemplateID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)docTemplate.Language);
            if (docTemplate.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateLanguage), new[] { "Language" });
            }

            retStr = enums.EnumTypeOK(typeof(TVTypeEnum), (int?)docTemplate.TVType);
            if (docTemplate.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateTVType), new[] { "TVType" });
            }

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.DocTemplateTVFileTVItemID, (docTemplate.TVFileTVItemID == null ? "" : docTemplate.TVFileTVItemID.ToString())), new[] { "TVFileTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.DocTemplateTVFileTVItemID, "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(docTemplate.FileName))
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateFileName), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.FileName) && docTemplate.FileName.Length > 150)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.DocTemplateFileName, "150"), new[] { "FileName" });
            }

            if (docTemplate.LastUpdateDate_UTC.Year == 1)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.DocTemplateLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (docTemplate.LastUpdateDate_UTC.Year < 1980)
                {
                docTemplate.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.DocTemplateLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                docTemplate.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.DocTemplateLastUpdateContactTVItemID, (docTemplate.LastUpdateContactTVItemID == null ? "" : docTemplate.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.DocTemplateLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public DocTemplate GetDocTemplateWithDocTemplateID(int DocTemplateID, GetParam getParam)
        {
            IQueryable<DocTemplate> docTemplateQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.DocTemplateID == DocTemplateID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return docTemplateQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillDocTemplateWeb(docTemplateQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillDocTemplateReport(docTemplateQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<DocTemplate> GetDocTemplateList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<DocTemplate> docTemplateQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            docTemplateQuery  = docTemplateQuery.OrderByDescending(c => c.DocTemplateID);
                        }
                        docTemplateQuery = docTemplateQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return docTemplateQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            docTemplateQuery = FillDocTemplateWeb(docTemplateQuery, FilterAndOrderText).OrderByDescending(c => c.DocTemplateID);
                        }
                        docTemplateQuery = FillDocTemplateWeb(docTemplateQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return docTemplateQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            docTemplateQuery = FillDocTemplateReport(docTemplateQuery, FilterAndOrderText).OrderByDescending(c => c.DocTemplateID);
                        }
                        docTemplateQuery = FillDocTemplateReport(docTemplateQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return docTemplateQuery;
                    }
                default:
                    return null;
            }
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
        public IQueryable<DocTemplate> GetRead()
        {
            return db.DocTemplates.AsNoTracking();
        }
        public IQueryable<DocTemplate> GetEdit()
        {
            return db.DocTemplates;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated DocTemplateFillWeb
        private IQueryable<DocTemplate> FillDocTemplateWeb(IQueryable<DocTemplate> docTemplateQuery, string FilterAndOrderText)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> LanguageEnumList = enums.GetEnumTextOrderedList(typeof(LanguageEnum));
            List<EnumIDAndText> TVTypeEnumList = enums.GetEnumTextOrderedList(typeof(TVTypeEnum));

            docTemplateQuery = (from c in docTemplateQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
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
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            LanguageText = (from e in LanguageEnumList
                                where e.EnumID == (int?)c.Language
                                select e.EnumText).FirstOrDefault(),
                            TVTypeText = (from e in TVTypeEnumList
                                where e.EnumID == (int?)c.TVType
                                select e.EnumText).FirstOrDefault(),
                        },
                        DocTemplateReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return docTemplateQuery;
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
