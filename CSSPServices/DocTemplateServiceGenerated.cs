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
    public partial class DocTemplateService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public DocTemplateService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            DocTemplate docTemplate = validationContext.ObjectInstance as DocTemplate;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (docTemplate.DocTemplateID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateDocTemplateID), new[] { "DocTemplateID" });
                }
            }

            //DocTemplateID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            retStr = enums.LanguageOK(docTemplate.Language);
            if (docTemplate.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateLanguage), new[] { "Language" });
            }

            retStr = enums.TVTypeOK(docTemplate.TVType);
            if (docTemplate.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateTVType), new[] { "TVType" });
            }

            //TVFileTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTVFileTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).FirstOrDefault();

            if (TVItemTVFileTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateTVFileTVItemID, docTemplate.TVFileTVItemID.ToString()), new[] { "TVFileTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.File,
                };
                if (!AllowableTVTypes.Contains(TVItemTVFileTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.DocTemplateTVFileTVItemID, "File"), new[] { "TVFileTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(docTemplate.FileName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateFileName), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.FileName) && docTemplate.FileName.Length > 150)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateFileName, "150"), new[] { "FileName" });
            }

            if (docTemplate.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (docTemplate.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.DocTemplateLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateLastUpdateContactTVItemID, docTemplate.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.DocTemplateLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.LastUpdateContactTVText) && docTemplate.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.LanguageText) && docTemplate.LanguageText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.TVTypeText) && docTemplate.TVTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateTVTypeText, "100"), new[] { "TVTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public DocTemplate GetDocTemplateWithDocTemplateID(int DocTemplateID)
        {
            IQueryable<DocTemplate> docTemplateQuery = (from c in GetRead()
                                                where c.DocTemplateID == DocTemplateID
                                                select c);

            return FillDocTemplate(docTemplateQuery).FirstOrDefault();
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
        public bool AddRange(List<DocTemplate> docTemplateList)
        {
            foreach (DocTemplate docTemplate in docTemplateList)
            {
                docTemplate.ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Create);
                if (docTemplate.ValidationResults.Count() > 0) return false;
            }

            db.DocTemplates.AddRange(docTemplateList);

            if (!TryToSaveRange(docTemplateList)) return false;

            return true;
        }
        public bool Delete(DocTemplate docTemplate)
        {
            if (!db.DocTemplates.Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
            {
                docTemplate.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", docTemplate.DocTemplateID.ToString())) }.AsEnumerable();
                return false;
            }

            db.DocTemplates.Remove(docTemplate);

            if (!TryToSave(docTemplate)) return false;

            return true;
        }
        public bool DeleteRange(List<DocTemplate> docTemplateList)
        {
            foreach (DocTemplate docTemplate in docTemplateList)
            {
                if (!db.DocTemplates.Where(c => c.DocTemplateID == docTemplate.DocTemplateID).Any())
                {
                    docTemplateList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "DocTemplate", "DocTemplateID", docTemplate.DocTemplateID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.DocTemplates.RemoveRange(docTemplateList);

            if (!TryToSaveRange(docTemplateList)) return false;

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
        public bool UpdateRange(List<DocTemplate> docTemplateList)
        {
            foreach (DocTemplate docTemplate in docTemplateList)
            {
                docTemplate.ValidationResults = Validate(new ValidationContext(docTemplate), ActionDBTypeEnum.Update);
                if (docTemplate.ValidationResults.Count() > 0) return false;
            }
            db.DocTemplates.UpdateRange(docTemplateList);

            if (!TryToSaveRange(docTemplateList)) return false;

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

        #region Functions private Generated Fill Class
        private List<DocTemplate> FillDocTemplate(IQueryable<DocTemplate> docTemplateQuery)
        {
            List<DocTemplate> DocTemplateList = (from c in docTemplateQuery
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
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (DocTemplate docTemplate in DocTemplateList)
            {
                docTemplate.LanguageText = enums.GetEnumText_LanguageEnum(docTemplate.Language);
                docTemplate.TVTypeText = enums.GetEnumText_TVTypeEnum(docTemplate.TVType);
            }

            return DocTemplateList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        private bool TryToSaveRange(List<DocTemplate> docTemplateList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                docTemplateList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
