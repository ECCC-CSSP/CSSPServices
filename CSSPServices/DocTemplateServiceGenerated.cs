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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateDocTemplateID), new[] { ModelsRes.DocTemplateDocTemplateID });
                }
            }

            //DocTemplateID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            retStr = enums.LanguageOK(docTemplate.Language);
            if (docTemplate.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateLanguage), new[] { ModelsRes.DocTemplateLanguage });
            }

            retStr = enums.TVTypeOK(docTemplate.TVType);
            if (docTemplate.TVType == TVTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateTVType), new[] { ModelsRes.DocTemplateTVType });
            }

            //TVFileTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (docTemplate.TVFileTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.DocTemplateTVFileTVItemID, "1"), new[] { ModelsRes.DocTemplateTVFileTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == docTemplate.TVFileTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateTVFileTVItemID, docTemplate.TVFileTVItemID.ToString()), new[] { ModelsRes.DocTemplateTVFileTVItemID });
            }

            if (string.IsNullOrWhiteSpace(docTemplate.FileName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateFileName), new[] { ModelsRes.DocTemplateFileName });
            }

            if (!string.IsNullOrWhiteSpace(docTemplate.FileName) && docTemplate.FileName.Length > 150)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.DocTemplateFileName, "150"), new[] { ModelsRes.DocTemplateFileName });
            }

            if (docTemplate.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.DocTemplateLastUpdateDate_UTC), new[] { ModelsRes.DocTemplateLastUpdateDate_UTC });
            }

            if (docTemplate.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.DocTemplateLastUpdateDate_UTC, "1980"), new[] { ModelsRes.DocTemplateLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (docTemplate.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.DocTemplateLastUpdateContactTVItemID, "1"), new[] { ModelsRes.DocTemplateLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == docTemplate.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.DocTemplateLastUpdateContactTVItemID, docTemplate.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.DocTemplateLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
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
        #endregion Functions public

        #region Functions private
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
        #endregion Functions private
    }
}
