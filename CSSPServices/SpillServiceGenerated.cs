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
    ///     <para>bonjour Spill</para>
    /// </summary>
    public partial class SpillService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Spill spill = validationContext.ObjectInstance as Spill;
            spill.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (spill.SpillID == 0)
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillSpillID), new[] { "SpillID" });
                }

                if (!GetRead().Where(c => c.SpillID == spill.SpillID).Any())
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Spill, CSSPModelsRes.SpillSpillID, spill.SpillID.ToString()), new[] { "SpillID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillMunicipalityTVItemID, spill.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillMunicipalityTVItemID, "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();

                if (TVItemInfrastructureTVItemID == null)
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillInfrastructureTVItemID, (spill.InfrastructureTVItemID == null ? "" : spill.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                    {
                        spill.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                    }
                }
            }

            if (spill.StartDateTime_Local.Year == 1)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillStartDateTime_Local), new[] { "StartDateTime_Local" });
            }
            else
            {
                if (spill.StartDateTime_Local.Year < 1980)
                {
                spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillStartDateTime_Local, "1980"), new[] { "StartDateTime_Local" });
                }
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillEndDateTime_Local, "1980"), new[] { CSSPModelsRes.SpillEndDateTime_Local });
            }

            if (spill.StartDateTime_Local > spill.EndDateTime_Local)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.SpillEndDateTime_Local, CSSPModelsRes.SpillStartDateTime_Local), new[] { CSSPModelsRes.SpillEndDateTime_Local });
            }

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SpillAverageFlow_m3_day, "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

            if (spill.LastUpdateDate_UTC.Year == 1)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SpillLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spill.LastUpdateDate_UTC.Year < 1980)
                {
                spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SpillLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillLastUpdateContactTVItemID, spill.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SpillLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                spill.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Spill GetSpillWithSpillID(int SpillID)
        {
            IQueryable<Spill> spillQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.SpillID == SpillID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return spillQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillSpillWeb(spillQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillSpillReport(spillQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Spill> GetSpillList()
        {
            IQueryable<Spill> spillQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        spillQuery = EnhanceQueryStatements<Spill>(spillQuery) as IQueryable<Spill>;

                        return spillQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        spillQuery = FillSpillWeb(spillQuery);

                        spillQuery = EnhanceQueryStatements<Spill>(spillQuery) as IQueryable<Spill>;

                        return spillQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        spillQuery = FillSpillReport(spillQuery);

                        spillQuery = EnhanceQueryStatements<Spill>(spillQuery) as IQueryable<Spill>;

                        return spillQuery;
                    }
                default:
                    {
                        spillQuery = spillQuery.Where(c => c.SpillID == 0);

                        return spillQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Add(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public bool Delete(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Delete);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Remove(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public bool Update(Spill spill)
        {
            spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
            if (spill.ValidationResults.Count() > 0) return false;

            db.Spills.Update(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public IQueryable<Spill> GetRead()
        {
            IQueryable<Spill> spillQuery = db.Spills.AsNoTracking();

            return spillQuery;
        }
        public IQueryable<Spill> GetEdit()
        {
            IQueryable<Spill> spillQuery = db.Spills;

            return spillQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated SpillFillWeb
        private IQueryable<Spill> FillSpillWeb(IQueryable<Spill> spillQuery)
        {
            spillQuery = (from c in spillQuery
                let MunicipalityTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let InfrastructureTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.InfrastructureTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Spill
                    {
                        SpillID = c.SpillID,
                        MunicipalityTVItemID = c.MunicipalityTVItemID,
                        InfrastructureTVItemID = c.InfrastructureTVItemID,
                        StartDateTime_Local = c.StartDateTime_Local,
                        EndDateTime_Local = c.EndDateTime_Local,
                        AverageFlow_m3_day = c.AverageFlow_m3_day,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        SpillWeb = new SpillWeb
                        {
                            MunicipalityTVText = MunicipalityTVText,
                            InfrastructureTVText = InfrastructureTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        SpillReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return spillQuery;
        }
        #endregion Functions private Generated SpillFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(Spill spill)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spill.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
