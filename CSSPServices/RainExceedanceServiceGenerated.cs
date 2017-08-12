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
    public partial class RainExceedanceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            RainExceedance rainExceedance = validationContext.ObjectInstance as RainExceedance;
            rainExceedance.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (rainExceedance.RainExceedanceID == 0)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceRainExceedanceID), new[] { "RainExceedanceID" });
                }

                if (!GetRead().Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.RainExceedance, ModelsRes.RainExceedanceRainExceedanceID, rainExceedance.RainExceedanceID.ToString()), new[] { "RainExceedanceID" });
                }
            }

            //RainExceedanceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //YearRound (bool) is required but no testing needed 

            if (rainExceedance.StartDate_Local != null && ((DateTime)rainExceedance.StartDate_Local).Year < 1980)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RainExceedanceStartDate_Local, "1980"), new[] { ModelsRes.RainExceedanceStartDate_Local });
            }

            if (rainExceedance.EndDate_Local != null && ((DateTime)rainExceedance.EndDate_Local).Year < 1980)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RainExceedanceEndDate_Local, "1980"), new[] { ModelsRes.RainExceedanceEndDate_Local });
            }

            if (rainExceedance.StartDate_Local > rainExceedance.EndDate_Local)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.RainExceedanceEndDate_Local, ModelsRes.RainExceedanceStartDate_Local), new[] { ModelsRes.RainExceedanceEndDate_Local });
            }

            if (rainExceedance.RainMaximum_mm != null)
            {
                if (rainExceedance.RainMaximum_mm < 0 || rainExceedance.RainMaximum_mm > 300)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), new[] { "RainMaximum_mm" });
                }
            }

            if (rainExceedance.RainExtreme_mm != null)
            {
                if (rainExceedance.RainExtreme_mm < 0 || rainExceedance.RainExtreme_mm > 300)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), new[] { "RainExtreme_mm" });
                }
            }

            //DaysPriorToStart (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (rainExceedance.DaysPriorToStart < 0 || rainExceedance.DaysPriorToStart > 30)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), new[] { "DaysPriorToStart" });
            }

            //RepeatEveryYear (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceProvinceTVItemIDs), new[] { "ProvinceTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs) && rainExceedance.ProvinceTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceProvinceTVItemIDs, "250"), new[] { "ProvinceTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceSubsectorTVItemIDs), new[] { "SubsectorTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs) && rainExceedance.SubsectorTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceSubsectorTVItemIDs, "250"), new[] { "SubsectorTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceClimateSiteTVItemIDs), new[] { "ClimateSiteTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs) && rainExceedance.ClimateSiteTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceClimateSiteTVItemIDs, "250"), new[] { "ClimateSiteTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceEmailDistributionListIDs), new[] { "EmailDistributionListIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs) && rainExceedance.EmailDistributionListIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceEmailDistributionListIDs, "250"), new[] { "EmailDistributionListIDs" });
            }

            if (rainExceedance.LastUpdateDate_UTC.Year == 1)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.RainExceedanceLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (rainExceedance.LastUpdateDate_UTC.Year < 1980)
                {
                rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.RainExceedanceLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.RainExceedanceLastUpdateContactTVItemID, rainExceedance.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.RainExceedanceLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.LastUpdateContactTVText) && rainExceedance.LastUpdateContactTVText.Length > 200)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.RainExceedanceLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public RainExceedance GetRainExceedanceWithRainExceedanceID(int RainExceedanceID)
        {
            IQueryable<RainExceedance> rainExceedanceQuery = (from c in GetRead()
                                                where c.RainExceedanceID == RainExceedanceID
                                                select c);

            return FillRainExceedance(rainExceedanceQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(RainExceedance rainExceedance)
        {
            rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Create);
            if (rainExceedance.ValidationResults.Count() > 0) return false;

            db.RainExceedances.Add(rainExceedance);

            if (!TryToSave(rainExceedance)) return false;

            return true;
        }
        public bool Delete(RainExceedance rainExceedance)
        {
            rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Delete);
            if (rainExceedance.ValidationResults.Count() > 0) return false;

            db.RainExceedances.Remove(rainExceedance);

            if (!TryToSave(rainExceedance)) return false;

            return true;
        }
        public bool Update(RainExceedance rainExceedance)
        {
            rainExceedance.ValidationResults = Validate(new ValidationContext(rainExceedance), ActionDBTypeEnum.Update);
            if (rainExceedance.ValidationResults.Count() > 0) return false;

            db.RainExceedances.Update(rainExceedance);

            if (!TryToSave(rainExceedance)) return false;

            return true;
        }
        public IQueryable<RainExceedance> GetRead()
        {
            return db.RainExceedances.AsNoTracking();
        }
        public IQueryable<RainExceedance> GetEdit()
        {
            return db.RainExceedances;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<RainExceedance> FillRainExceedance(IQueryable<RainExceedance> rainExceedanceQuery)
        {
            List<RainExceedance> RainExceedanceList = (from c in rainExceedanceQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new RainExceedance
                                         {
                                             RainExceedanceID = c.RainExceedanceID,
                                             YearRound = c.YearRound,
                                             StartDate_Local = c.StartDate_Local,
                                             EndDate_Local = c.EndDate_Local,
                                             RainMaximum_mm = c.RainMaximum_mm,
                                             RainExtreme_mm = c.RainExtreme_mm,
                                             DaysPriorToStart = c.DaysPriorToStart,
                                             RepeatEveryYear = c.RepeatEveryYear,
                                             ProvinceTVItemIDs = c.ProvinceTVItemIDs,
                                             SubsectorTVItemIDs = c.SubsectorTVItemIDs,
                                             ClimateSiteTVItemIDs = c.ClimateSiteTVItemIDs,
                                             EmailDistributionListIDs = c.EmailDistributionListIDs,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return RainExceedanceList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(RainExceedance rainExceedance)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                rainExceedance.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
