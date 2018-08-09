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
    ///     <para>bonjour RainExceedance</para>
    /// </summary>
    public partial class RainExceedanceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public RainExceedanceService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceRainExceedanceID"), new[] { "RainExceedanceID" });
                }

                if (!(from c in db.RainExceedances select c).Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "RainExceedance", "RainExceedanceRainExceedanceID", rainExceedance.RainExceedanceID.ToString()), new[] { "RainExceedanceID" });
                }
            }

            if (rainExceedance.StartDate_Local != null && ((DateTime)rainExceedance.StartDate_Local).Year < 1980)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RainExceedanceStartDate_Local", "1980"), new[] { "RainExceedanceStartDate_Local" });
            }

            if (rainExceedance.EndDate_Local != null && ((DateTime)rainExceedance.EndDate_Local).Year < 1980)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RainExceedanceEndDate_Local", "1980"), new[] { "RainExceedanceEndDate_Local" });
            }

            if (rainExceedance.StartDate_Local > rainExceedance.EndDate_Local)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "RainExceedanceEndDate_Local", "RainExceedanceStartDate_Local"), new[] { "RainExceedanceEndDate_Local" });
            }

            if (rainExceedance.RainMaximum_mm != null)
            {
                if (rainExceedance.RainMaximum_mm < 0 || rainExceedance.RainMaximum_mm > 300)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceRainMaximum_mm", "0", "300"), new[] { "RainMaximum_mm" });
                }
            }

            if (rainExceedance.RainExtreme_mm != null)
            {
                if (rainExceedance.RainExtreme_mm < 0 || rainExceedance.RainExtreme_mm > 300)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceRainExtreme_mm", "0", "300"), new[] { "RainExtreme_mm" });
                }
            }

            if (rainExceedance.DaysPriorToStart < 0 || rainExceedance.DaysPriorToStart > 30)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RainExceedanceDaysPriorToStart", "0", "30"), new[] { "DaysPriorToStart" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceProvinceTVItemIDs"), new[] { "ProvinceTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs) && rainExceedance.ProvinceTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceProvinceTVItemIDs", "250"), new[] { "ProvinceTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceSubsectorTVItemIDs"), new[] { "SubsectorTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs) && rainExceedance.SubsectorTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceSubsectorTVItemIDs", "250"), new[] { "SubsectorTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceClimateSiteTVItemIDs"), new[] { "ClimateSiteTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs) && rainExceedance.ClimateSiteTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceClimateSiteTVItemIDs", "250"), new[] { "ClimateSiteTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceEmailDistributionListIDs"), new[] { "EmailDistributionListIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs) && rainExceedance.EmailDistributionListIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RainExceedanceEmailDistributionListIDs", "250"), new[] { "EmailDistributionListIDs" });
            }

            if (rainExceedance.LastUpdateDate_UTC.Year == 1)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "RainExceedanceLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (rainExceedance.LastUpdateDate_UTC.Year < 1980)
                {
                rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "RainExceedanceLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "RainExceedanceLastUpdateContactTVItemID", rainExceedance.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "RainExceedanceLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.RainExceedances
                    where c.RainExceedanceID == RainExceedanceID
                    select c).FirstOrDefault();

        }
        public IQueryable<RainExceedance> GetRainExceedanceList()
        {
            IQueryable<RainExceedance> RainExceedanceQuery = (from c in db.RainExceedances select c);

            RainExceedanceQuery = EnhanceQueryStatements<RainExceedance>(RainExceedanceQuery) as IQueryable<RainExceedance>;

            return RainExceedanceQuery;
        }
        public RainExceedance_A GetRainExceedance_AWithRainExceedanceID(int RainExceedanceID)
        {
            return FillRainExceedance_A().Where(c => c.RainExceedanceID == RainExceedanceID).FirstOrDefault();

        }
        public IQueryable<RainExceedance_A> GetRainExceedance_AList()
        {
            IQueryable<RainExceedance_A> RainExceedance_AQuery = FillRainExceedance_A();

            RainExceedance_AQuery = EnhanceQueryStatements<RainExceedance_A>(RainExceedance_AQuery) as IQueryable<RainExceedance_A>;

            return RainExceedance_AQuery;
        }
        public RainExceedance_B GetRainExceedance_BWithRainExceedanceID(int RainExceedanceID)
        {
            return FillRainExceedance_B().Where(c => c.RainExceedanceID == RainExceedanceID).FirstOrDefault();

        }
        public IQueryable<RainExceedance_B> GetRainExceedance_BList()
        {
            IQueryable<RainExceedance_B> RainExceedance_BQuery = FillRainExceedance_B();

            RainExceedance_BQuery = EnhanceQueryStatements<RainExceedance_B>(RainExceedance_BQuery) as IQueryable<RainExceedance_B>;

            return RainExceedance_BQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
