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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceRainExceedanceID), new[] { "RainExceedanceID" });
                }

                if (!GetRead().Where(c => c.RainExceedanceID == rainExceedance.RainExceedanceID).Any())
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.RainExceedance, CSSPModelsRes.RainExceedanceRainExceedanceID, rainExceedance.RainExceedanceID.ToString()), new[] { "RainExceedanceID" });
                }
            }

            if (rainExceedance.StartDate_Local != null && ((DateTime)rainExceedance.StartDate_Local).Year < 1980)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RainExceedanceStartDate_Local, "1980"), new[] { CSSPModelsRes.RainExceedanceStartDate_Local });
            }

            if (rainExceedance.EndDate_Local != null && ((DateTime)rainExceedance.EndDate_Local).Year < 1980)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RainExceedanceEndDate_Local, "1980"), new[] { CSSPModelsRes.RainExceedanceEndDate_Local });
            }

            if (rainExceedance.StartDate_Local > rainExceedance.EndDate_Local)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.RainExceedanceEndDate_Local, CSSPModelsRes.RainExceedanceStartDate_Local), new[] { CSSPModelsRes.RainExceedanceEndDate_Local });
            }

            if (rainExceedance.RainMaximum_mm != null)
            {
                if (rainExceedance.RainMaximum_mm < 0 || rainExceedance.RainMaximum_mm > 300)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceRainMaximum_mm, "0", "300"), new[] { "RainMaximum_mm" });
                }
            }

            if (rainExceedance.RainExtreme_mm != null)
            {
                if (rainExceedance.RainExtreme_mm < 0 || rainExceedance.RainExtreme_mm > 300)
                {
                    rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceRainExtreme_mm, "0", "300"), new[] { "RainExtreme_mm" });
                }
            }

            if (rainExceedance.DaysPriorToStart < 0 || rainExceedance.DaysPriorToStart > 30)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.RainExceedanceDaysPriorToStart, "0", "30"), new[] { "DaysPriorToStart" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceProvinceTVItemIDs), new[] { "ProvinceTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ProvinceTVItemIDs) && rainExceedance.ProvinceTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceProvinceTVItemIDs, "250"), new[] { "ProvinceTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceSubsectorTVItemIDs), new[] { "SubsectorTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.SubsectorTVItemIDs) && rainExceedance.SubsectorTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceSubsectorTVItemIDs, "250"), new[] { "SubsectorTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceClimateSiteTVItemIDs), new[] { "ClimateSiteTVItemIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.ClimateSiteTVItemIDs) && rainExceedance.ClimateSiteTVItemIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceClimateSiteTVItemIDs, "250"), new[] { "ClimateSiteTVItemIDs" });
            }

            if (string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs))
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceEmailDistributionListIDs), new[] { "EmailDistributionListIDs" });
            }

            if (!string.IsNullOrWhiteSpace(rainExceedance.EmailDistributionListIDs) && rainExceedance.EmailDistributionListIDs.Length > 250)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.RainExceedanceEmailDistributionListIDs, "250"), new[] { "EmailDistributionListIDs" });
            }

            if (rainExceedance.LastUpdateDate_UTC.Year == 1)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.RainExceedanceLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (rainExceedance.LastUpdateDate_UTC.Year < 1980)
                {
                rainExceedance.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.RainExceedanceLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == rainExceedance.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                rainExceedance.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.RainExceedanceLastUpdateContactTVItemID, rainExceedance.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.RainExceedanceLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<RainExceedance> rainExceedanceQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.RainExceedanceID == RainExceedanceID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return rainExceedanceQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillRainExceedanceWeb(rainExceedanceQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillRainExceedanceReport(rainExceedanceQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<RainExceedance> GetRainExceedanceList()
        {
            IQueryable<RainExceedance> rainExceedanceQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        rainExceedanceQuery = EnhanceQueryStatements<RainExceedance>(rainExceedanceQuery) as IQueryable<RainExceedance>;

                        return rainExceedanceQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        rainExceedanceQuery = FillRainExceedanceWeb(rainExceedanceQuery);

                        rainExceedanceQuery = EnhanceQueryStatements<RainExceedance>(rainExceedanceQuery) as IQueryable<RainExceedance>;

                        return rainExceedanceQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        rainExceedanceQuery = FillRainExceedanceReport(rainExceedanceQuery);

                        rainExceedanceQuery = EnhanceQueryStatements<RainExceedance>(rainExceedanceQuery) as IQueryable<RainExceedance>;

                        return rainExceedanceQuery;
                    }
                default:
                    {
                        rainExceedanceQuery = rainExceedanceQuery.Where(c => c.RainExceedanceID == 0);

                        return rainExceedanceQuery;
                    }
            }
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
            IQueryable<RainExceedance> rainExceedanceQuery = db.RainExceedances.AsNoTracking();

            return rainExceedanceQuery;
        }
        public IQueryable<RainExceedance> GetEdit()
        {
            IQueryable<RainExceedance> rainExceedanceQuery = db.RainExceedances;

            return rainExceedanceQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated RainExceedanceFillWeb
        private IQueryable<RainExceedance> FillRainExceedanceWeb(IQueryable<RainExceedance> rainExceedanceQuery)
        {
            rainExceedanceQuery = (from c in rainExceedanceQuery
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
                        RainExceedanceWeb = new RainExceedanceWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        RainExceedanceReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return rainExceedanceQuery;
        }
        #endregion Functions private Generated RainExceedanceFillWeb

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
