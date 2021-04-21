/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
    public partial class PolSourceGroupingLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            PolSourceGroupingLanguage polSourceGroupingLanguage = validationContext.ObjectInstance as PolSourceGroupingLanguage;
            polSourceGroupingLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (polSourceGroupingLanguage.PolSourceGroupingLanguageID == 0)
                {
                    polSourceGroupingLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "PolSourceGroupingLanguageID"), new[] { "PolSourceGroupingLanguageID" });
                }

                if (!(from c in db.PolSourceGroupingLanguages select c).Where(c => c.PolSourceGroupingLanguageID == polSourceGroupingLanguage.PolSourceGroupingLanguageID).Any())
                {
                    polSourceGroupingLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceGroupingLanguage", "PolSourceGroupingLanguageID", polSourceGroupingLanguage.PolSourceGroupingLanguageID.ToString()), new[] { "PolSourceGroupingLanguageID" });
                }
            }

            PolSourceGrouping PolSourceGroupingPolSourceGroupingID = (from c in db.PolSourceGroupings where c.PolSourceGroupingID == polSourceGroupingLanguage.PolSourceGroupingID select c).FirstOrDefault();

            if (PolSourceGroupingPolSourceGroupingID == null)
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "PolSourceGrouping", "PolSourceGroupingID", polSourceGroupingLanguage.PolSourceGroupingID.ToString()), new[] { "PolSourceGroupingID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)polSourceGroupingLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.SourceName))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SourceName"), new[] { "SourceName" });
            }

            //SourceName has no StringLength Attribute

            if (polSourceGroupingLanguage.SourceNameOrder < 0 || polSourceGroupingLanguage.SourceNameOrder > 1000)
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SourceNameOrder", "0", "1000"), new[] { "SourceNameOrder" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusSourceName);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusSourceName"), new[] { "TranslationStatusSourceName" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Init))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Init"), new[] { "Init" });
            }

            //Init has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusInit);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusInit"), new[] { "TranslationStatusInit" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Description))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Description"), new[] { "Description" });
            }

            //Description has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusDescription);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusDescription"), new[] { "TranslationStatusDescription" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Report))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Report"), new[] { "Report" });
            }

            //Report has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusReport);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusReport"), new[] { "TranslationStatusReport" });
            }

            if (string.IsNullOrWhiteSpace(polSourceGroupingLanguage.Text))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Text"), new[] { "Text" });
            }

            //Text has no StringLength Attribute

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)polSourceGroupingLanguage.TranslationStatusText);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatusText"), new[] { "TranslationStatusText" });
            }

            if (polSourceGroupingLanguage.LastUpdateDate_UTC.Year == 1)
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (polSourceGroupingLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                polSourceGroupingLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == polSourceGroupingLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", polSourceGroupingLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    polSourceGroupingLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                polSourceGroupingLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public PolSourceGroupingLanguage GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(int PolSourceGroupingLanguageID)
        {
            return (from c in db.PolSourceGroupingLanguages
                    where c.PolSourceGroupingLanguageID == PolSourceGroupingLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<PolSourceGroupingLanguage> GetPolSourceGroupingLanguageList()
        {
            IQueryable<PolSourceGroupingLanguage> PolSourceGroupingLanguageQuery = (from c in db.PolSourceGroupingLanguages select c);

            PolSourceGroupingLanguageQuery = EnhanceQueryStatements<PolSourceGroupingLanguage>(PolSourceGroupingLanguageQuery) as IQueryable<PolSourceGroupingLanguage>;

            return PolSourceGroupingLanguageQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            polSourceGroupingLanguage.ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Create);
            if (polSourceGroupingLanguage.ValidationResults.Count() > 0) return false;

            db.PolSourceGroupingLanguages.Add(polSourceGroupingLanguage);

            if (!TryToSave(polSourceGroupingLanguage)) return false;

            return true;
        }
        public bool Delete(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            polSourceGroupingLanguage.ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Delete);
            if (polSourceGroupingLanguage.ValidationResults.Count() > 0) return false;

            db.PolSourceGroupingLanguages.Remove(polSourceGroupingLanguage);

            if (!TryToSave(polSourceGroupingLanguage)) return false;

            return true;
        }
        public bool Update(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            polSourceGroupingLanguage.ValidationResults = Validate(new ValidationContext(polSourceGroupingLanguage), ActionDBTypeEnum.Update);
            if (polSourceGroupingLanguage.ValidationResults.Count() > 0) return false;

            db.PolSourceGroupingLanguages.Update(polSourceGroupingLanguage);

            if (!TryToSave(polSourceGroupingLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(PolSourceGroupingLanguage polSourceGroupingLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                polSourceGroupingLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}