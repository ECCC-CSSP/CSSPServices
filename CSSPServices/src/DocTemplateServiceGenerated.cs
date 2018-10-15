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
        public DocTemplateService(Query query, CSSPDBContext db, int ContactID)
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
        public DocTemplateExtraA GetDocTemplateExtraAWithDocTemplateID(int DocTemplateID)
        {
            return FillDocTemplateExtraA().Where(c => c.DocTemplateID == DocTemplateID).FirstOrDefault();

        }
        public IQueryable<DocTemplateExtraA> GetDocTemplateExtraAList()
        {
            IQueryable<DocTemplateExtraA> DocTemplateExtraAQuery = FillDocTemplateExtraA();

            DocTemplateExtraAQuery = EnhanceQueryStatements<DocTemplateExtraA>(DocTemplateExtraAQuery) as IQueryable<DocTemplateExtraA>;

            return DocTemplateExtraAQuery;
        }
        public DocTemplateExtraB GetDocTemplateExtraBWithDocTemplateID(int DocTemplateID)
        {
            return FillDocTemplateExtraB().Where(c => c.DocTemplateID == DocTemplateID).FirstOrDefault();

        }
        public IQueryable<DocTemplateExtraB> GetDocTemplateExtraBList()
        {
            IQueryable<DocTemplateExtraB> DocTemplateExtraBQuery = FillDocTemplateExtraB();

            DocTemplateExtraBQuery = EnhanceQueryStatements<DocTemplateExtraB>(DocTemplateExtraBQuery) as IQueryable<DocTemplateExtraB>;

            return DocTemplateExtraBQuery;
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
