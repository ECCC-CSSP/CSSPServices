/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\srcWithDoc\[ClassName]ServiceGenerated.cs] button
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
    /// <summary>
    /// > [!NOTE]
    /// > 
    /// > <para>**Used by [CSSPWebAPI.Controllers](CSSPWebAPI.Controllers.html)** : [AppTaskLanguageController](CSSPWebAPI.Controllers.AppTaskLanguageController.html)</para>
    /// > <para>**Requires [CSSPModels](CSSPModels.html)** : [CSSPModels.AppTaskLanguage](CSSPModels.AppTaskLanguage.html)</para>
    /// > <para>**Requires [CSSPEnums](CSSPEnums.html)** : [LanguageEnum](CSSPEnums.LanguageEnum.html), [TranslationStatusEnum](CSSPEnums.TranslationStatusEnum.html)</para>
    /// > <para>**Return to [CSSPServices](CSSPServices.html)**</para>
    /// </summary>
    public partial class AppTaskLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        /// <summary>
        /// CSSPDB AppTaskLanguages table service constructor
        /// </summary>
        /// <param name="query">[Query](CSSPModels.Query.html) object for filtering of service functions</param>
        /// <param name="db">[CSSPDBContext](CSSPModels.CSSPDBContext.html) referencing the CSSP database context</param>
        /// <param name="ContactID">Representing the contact identifier of the person connecting to the service</param>
        public AppTaskLanguageService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        /// <summary>
        /// Validate function for all AppTaskLanguageService commands
        /// </summary>
        /// <param name="validationContext">System.ComponentModel.DataAnnotations.ValidationContext (Describes the context in which a validation check is performed.)</param>
        /// <param name="actionDBType">[ActionDBTypeEnum] (CSSPEnums.ActionDBTypeEnum.html) action type to validate</param>
        /// <returns>IEnumerable of ValidationResult (Where ValidationResult is a container for the results of a validation request.)</returns>
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            AppTaskLanguage appTaskLanguage = validationContext.ObjectInstance as AppTaskLanguage;
            appTaskLanguage.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (appTaskLanguage.AppTaskLanguageID == 0)
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AppTaskLanguageID"), new[] { "AppTaskLanguageID" });
                }

                if (!(from c in db.AppTaskLanguages select c).Where(c => c.AppTaskLanguageID == appTaskLanguage.AppTaskLanguageID).Any())
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTaskLanguage", "AppTaskLanguageID", appTaskLanguage.AppTaskLanguageID.ToString()), new[] { "AppTaskLanguageID" });
                }
            }

            AppTask AppTaskAppTaskID = (from c in db.AppTasks where c.AppTaskID == appTaskLanguage.AppTaskID select c).FirstOrDefault();

            if (AppTaskAppTaskID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "AppTask", "AppTaskID", appTaskLanguage.AppTaskID.ToString()), new[] { "AppTaskID" });
            }

            retStr = enums.EnumTypeOK(typeof(LanguageEnum), (int?)appTaskLanguage.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "Language"), new[] { "Language" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.StatusText) && appTaskLanguage.StatusText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "StatusText", "250"), new[] { "StatusText" });
            }

            if (!string.IsNullOrWhiteSpace(appTaskLanguage.ErrorText) && appTaskLanguage.ErrorText.Length > 250)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "ErrorText", "250"), new[] { "ErrorText" });
            }

            retStr = enums.EnumTypeOK(typeof(TranslationStatusEnum), (int?)appTaskLanguage.TranslationStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TranslationStatus"), new[] { "TranslationStatus" });
            }

            if (appTaskLanguage.LastUpdateDate_UTC.Year == 1)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (appTaskLanguage.LastUpdateDate_UTC.Year < 1980)
                {
                appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == appTaskLanguage.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", appTaskLanguage.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    appTaskLanguage.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                appTaskLanguage.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        /// <summary>
        /// Gets the AppTaskLanguage model with the AppTaskLanguageID identifier
        /// </summary>
        /// <param name="AppTaskLanguageID">Is the identifier of [AppTaskLanguages](CSSPModels.AppTaskLanguage.html) table of CSSPDB</param>
        /// <returns>[AppTaskLanguage](CSSPModels.AppTaskLanguage.html) object connected to the CSSPDB</returns>
        public AppTaskLanguage GetAppTaskLanguageWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return (from c in db.AppTaskLanguages
                    where c.AppTaskLanguageID == AppTaskLanguageID
                    select c).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [AppTaskLanguage](CSSPModels.AppTaskLanguage.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [AppTaskLanguage](CSSPModels.AppTaskLanguage.html)</returns>
        public IQueryable<AppTaskLanguage> GetAppTaskLanguageList()
        {
            IQueryable<AppTaskLanguage> AppTaskLanguageQuery = (from c in db.AppTaskLanguages select c);

            AppTaskLanguageQuery = EnhanceQueryStatements<AppTaskLanguage>(AppTaskLanguageQuery) as IQueryable<AppTaskLanguage>;

            return AppTaskLanguageQuery;
        }
        /// <summary>
        /// Gets the AppTaskLanguageExtraA model with the AppTaskLanguageID identifier
        /// </summary>
        /// <param name="AppTaskLanguageID">Is the identifier of [AppTaskLanguages](CSSPModels.AppTaskLanguage.html) table of CSSPDB</param>
        /// <returns>[AppTaskLanguageExtraA](CSSPModels.AppTaskLanguageExtraA.html) object connected to the CSSPDB</returns>
        public AppTaskLanguageExtraA GetAppTaskLanguageExtraAWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return FillAppTaskLanguageExtraA().Where(c => c.AppTaskLanguageID == AppTaskLanguageID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [AppTaskLanguageExtraA](CSSPModels.AppTaskLanguageExtraA.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [AppTaskLanguageExtraA](CSSPModels.AppTaskLanguageExtraA.html)</returns>
        public IQueryable<AppTaskLanguageExtraA> GetAppTaskLanguageExtraAList()
        {
            IQueryable<AppTaskLanguageExtraA> AppTaskLanguageExtraAQuery = FillAppTaskLanguageExtraA();

            AppTaskLanguageExtraAQuery = EnhanceQueryStatements<AppTaskLanguageExtraA>(AppTaskLanguageExtraAQuery) as IQueryable<AppTaskLanguageExtraA>;

            return AppTaskLanguageExtraAQuery;
        }
        /// <summary>
        /// Gets the AppTaskLanguageExtraB model with the AppTaskLanguageID identifier
        /// </summary>
        /// <param name="AppTaskLanguageID">Is the identifier of [AppTaskLanguages](CSSPModels.AppTaskLanguage.html) table of CSSPDB</param>
        /// <returns>[AppTaskLanguageExtraB](CSSPModels.AppTaskLanguageExtraB.html) object connected to the CSSPDB</returns>
        public AppTaskLanguageExtraB GetAppTaskLanguageExtraBWithAppTaskLanguageID(int AppTaskLanguageID)
        {
            return FillAppTaskLanguageExtraB().Where(c => c.AppTaskLanguageID == AppTaskLanguageID).FirstOrDefault();

        }
        /// <summary>
        /// Gets a list of [AppTaskLanguageExtraB](CSSPModels.AppTaskLanguageExtraB.html) satisfying the filters in [Query](CSSPModels.Query.html)
        /// </summary>
        /// <returns>IQueryable of [AppTaskLanguageExtraB](CSSPModels.AppTaskLanguageExtraB.html)</returns>
        public IQueryable<AppTaskLanguageExtraB> GetAppTaskLanguageExtraBList()
        {
            IQueryable<AppTaskLanguageExtraB> AppTaskLanguageExtraBQuery = FillAppTaskLanguageExtraB();

            AppTaskLanguageExtraBQuery = EnhanceQueryStatements<AppTaskLanguageExtraB>(AppTaskLanguageExtraBQuery) as IQueryable<AppTaskLanguageExtraB>;

            return AppTaskLanguageExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        /// <summary>
        /// Adds an [AppTaskLanguage](CSSPModels.AppTaskLanguage.html) item in CSSPDB
        /// </summary>
        /// <param name="appTaskLanguage">Is the AppTaskLanguage item the client want to add to CSSPDB</param>
        /// <returns>true if AppTaskLanguage item was added to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Add(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Create);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Add(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        /// <summary>
        /// Deletes an [AppTaskLanguage](CSSPModels.AppTaskLanguage.html) item in CSSPDB
        /// </summary>
        /// <param name="appTaskLanguage">Is the AppTaskLanguage item the client want to add to CSSPDB. What's important here is the AppTaskLanguageID</param>
        /// <returns>true if AppTaskLanguage item was deleted to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Delete(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Delete);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Remove(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        /// <summary>
        /// Updates an [AppTaskLanguage](CSSPModels.AppTaskLanguage.html) item in CSSPDB
        /// </summary>
        /// <param name="appTaskLanguage">Is the AppTaskLanguage item the client want to add to CSSPDB. What's important here is the AppTaskLanguageID</param>
        /// <returns>true if AppTaskLanguage item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        public bool Update(AppTaskLanguage appTaskLanguage)
        {
            appTaskLanguage.ValidationResults = Validate(new ValidationContext(appTaskLanguage), ActionDBTypeEnum.Update);
            if (appTaskLanguage.ValidationResults.Count() > 0) return false;

            db.AppTaskLanguages.Update(appTaskLanguage);

            if (!TryToSave(appTaskLanguage)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        /// <summary>
        /// Tries to execute the CSSPDB transaction (add/delete/update) on an [AppTaskLanguage](CSSPModels.AppTaskLanguage.html) item
        /// </summary>
        /// <param name="appTaskLanguage">Is the AppTaskLanguage item the client want to add to CSSPDB. What's important here is the AppTaskLanguageID</param>
        /// <returns>true if AppTaskLanguage item was updated to CSSPDB, false if an error happened during the DB requested transtaction</returns>
        private bool TryToSave(AppTaskLanguage appTaskLanguage)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                appTaskLanguage.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
