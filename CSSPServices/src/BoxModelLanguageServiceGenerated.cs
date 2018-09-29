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
    ///     <para>bonjour BoxModelLanguage</para>
    /// </summary>
    public partial class BoxModelLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageBoxModelLanguageID"), new[] { "BoxModelLanguageID" });
                }

                if (!(from c in db.BoxModelLanguages select c).Where(c => c.BoxModelLanguageID == boxModelLanguage.BoxModelLanguageID).Any())
                {
                    boxModelLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModelLanguage", "BoxModelLanguageBoxModelLanguageID", boxModelLanguage.BoxModelLanguageID.ToString()), new[] { "BoxModelLanguageID" });
                }
            }

            BoxModel BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelLanguage.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelLanguageBoxModelID", boxModelLanguage.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)boxModelLanguage.Language);
            if (boxModelLanguage.Language == null || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageLanguage"), new[] { "Language" });
            }

            if (string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName))
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageScenarioName"), new[] { "ScenarioName" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelLanguage.ScenarioName) && boxModelLanguage.ScenarioName.Length > 250)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "BoxModelLanguageScenarioName", "250"), new[] { "ScenarioName" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)boxModelLanguage.TranslationStatus);
            if (boxModelLanguage.TranslationStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageTranslationStatus"), new[] { "TranslationStatus" });
            }

            if (boxModelLanguage.LastUpdateDate_UTC.Year == 1)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelLanguageLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                boxModelLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "BoxModelLanguageLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModelLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelLanguageLastUpdateContactTVItemID", boxModelLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelLanguageLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.BoxModelLanguages
                    where c.BoxModelLanguageID == BoxModelLanguageID
                    select c).FirstOrDefault();

        }
        public IQueryable<BoxModelLanguage> GetBoxModelLanguageList()
        {
            IQueryable<BoxModelLanguage> BoxModelLanguageQuery = (from c in db.BoxModelLanguages select c);

            BoxModelLanguageQuery = EnhanceQueryStatements<BoxModelLanguage>(BoxModelLanguageQuery) as IQueryable<BoxModelLanguage>;

            return BoxModelLanguageQuery;
        }
        public BoxModelLanguage_A GetBoxModelLanguage_AWithBoxModelLanguageID(int BoxModelLanguageID)
        {
            return FillBoxModelLanguage_A().Where(c => c.BoxModelLanguageID == BoxModelLanguageID).FirstOrDefault();

        }
        public IQueryable<BoxModelLanguage_A> GetBoxModelLanguage_AList()
        {
            IQueryable<BoxModelLanguage_A> BoxModelLanguage_AQuery = FillBoxModelLanguage_A();

            BoxModelLanguage_AQuery = EnhanceQueryStatements<BoxModelLanguage_A>(BoxModelLanguage_AQuery) as IQueryable<BoxModelLanguage_A>;

            return BoxModelLanguage_AQuery;
        }
        public BoxModelLanguage_B GetBoxModelLanguage_BWithBoxModelLanguageID(int BoxModelLanguageID)
        {
            return FillBoxModelLanguage_B().Where(c => c.BoxModelLanguageID == BoxModelLanguageID).FirstOrDefault();

        }
        public IQueryable<BoxModelLanguage_B> GetBoxModelLanguage_BList()
        {
            IQueryable<BoxModelLanguage_B> BoxModelLanguage_BQuery = FillBoxModelLanguage_B();

            BoxModelLanguage_BQuery = EnhanceQueryStatements<BoxModelLanguage_B>(BoxModelLanguage_BQuery) as IQueryable<BoxModelLanguage_B>;

            return BoxModelLanguage_BQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
