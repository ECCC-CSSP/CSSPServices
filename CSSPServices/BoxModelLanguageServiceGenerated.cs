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
    public partial class BoxModelLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelLanguage boxModelLanguage = validationContext.ObjectInstance as BoxModelLanguage;
            boxModelLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModelLanguage.BoxModelLanguageID == 0)
                {
                    boxModelLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageBoxModelLanguageID), new[] { "BoxModelLanguageID" });
                }

                if (!GetRead().Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
                {
                    boxModelLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModelLanguage, ModelsRes.BoxModelLanguageBoxModelLanguageID, boxModelLanguage.BoxModelLanguageID.ToString()), new[] { "BoxModelLanguageID" });
                }
            }

            //BoxModelLanguageID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            BoxModel BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelLanguage.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelLanguageBoxModelID, boxModelLanguage.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)boxModelLanguage.Language);
            if (boxModelLanguage.Language == LanguageEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLanguage), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName))
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageScenarioName), new[] { "ScenarioName" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName) && boxModelLanguage.ScenarioName.Length > 250)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageScenarioName, "250"), new[] { "ScenarioName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)boxModelLanguage.TranslationStatus);
            if (boxModelLanguage.TranslationStatus == TranslationStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageTranslationStatus), new[] { "TranslationStatus" });
            }

            if (boxModelLanguage.LastUpdateDate_UTC.Year == 1)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelLanguageLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                boxModelLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelLanguageLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, boxModelLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    boxModelLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelLanguageLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.LastUpdateContactTVText) && boxModelLanguage.LastUpdateContactTVText.Length > 200)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.LanguageText) && boxModelLanguage.LanguageText.Length > 100)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageLanguageText, "100"), new[] { "LanguageText" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.TranslationStatusText) && boxModelLanguage.TranslationStatusText.Length > 100)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelLanguageTranslationStatusText, "100"), new[] { "TranslationStatusText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public BoxModelLanguage GetBoxModelLanguageWithBoxModelLanguageID(int BoxModelLanguageID)
        {
            IQueryable<BoxModelLanguage> boxModelLanguageQuery = (from c in GetRead()
                                                where c.BoxModelLanguageID == BoxModelLanguageID
                                                select c);

            return FillBoxModelLanguage(boxModelLanguageQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(BoxModelLanguage boxModelLanguage)
        {
            boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Create);
            if (boxModelLanguage.ValidationResults.Count() > 0) return false;

            db.BoxModelLanguages.Add(boxModelLanguage);

            if (!TryToSave(boxModelLanguage)) return false;

            return true;
        }
        public bool Delete(BoxModelLanguage boxModelLanguage)
        {
            boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Delete);
            if (boxModelLanguage.ValidationResults.Count() > 0) return false;

            db.BoxModelLanguages.Remove(boxModelLanguage);

            if (!TryToSave(boxModelLanguage)) return false;

            return true;
        }
        public bool Update(BoxModelLanguage boxModelLanguage)
        {
            boxModelLanguage.ValidationResults = Validate(new ValidationContext(boxModelLanguage), ActionDBTypeEnum.Update);
            if (boxModelLanguage.ValidationResults.Count() > 0) return false;

            db.BoxModelLanguages.Update(boxModelLanguage);

            if (!TryToSave(boxModelLanguage)) return false;

            return true;
        }
        public IQueryable<BoxModelLanguage> GetRead()
        {
            return db.BoxModelLanguages.AsNoTracking();
        }
        public IQueryable<BoxModelLanguage> GetEdit()
        {
            return db.BoxModelLanguages;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<BoxModelLanguage> FillBoxModelLanguage(IQueryable<BoxModelLanguage> boxModelLanguageQuery)
        {
            List<BoxModelLanguage> BoxModelLanguageList = (from c in boxModelLanguageQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new BoxModelLanguage
                                         {
                                             BoxModelLanguageID = c.BoxModelLanguageID,
                                             BoxModelID = c.BoxModelID,
                                             Language = c.Language,
                                             ScenarioName = c.ScenarioName,
                                             TranslationStatus = c.TranslationStatus,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (BoxModelLanguage boxModelLanguage in BoxModelLanguageList)
            {
                boxModelLanguage.LanguageText = enums.GetResValueForTypeAndID(typeof(LanguageEnum), (int?)boxModelLanguage.Language);
                boxModelLanguage.TranslationStatusText = enums.GetResValueForTypeAndID(typeof(TranslationStatusEnum), (int?)boxModelLanguage.TranslationStatus);
            }

            return BoxModelLanguageList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(BoxModelLanguage boxModelLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
