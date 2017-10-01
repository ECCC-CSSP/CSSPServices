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
        public SpillService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //SpillID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MunicipalityTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

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
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SpillInfrastructureTVItemID, spill.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
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

            //AverageFlow_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SpillAverageFlow_m3_day, "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

                //Error: Type not implemented [SpillWeb] of type [SpillWeb]
                //Error: Type not implemented [SpillReport] of type [SpillReport]
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

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

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

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                spill.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Spill GetSpillWithSpillID(int SpillID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<Spill> spillQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.SpillID == SpillID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return spillQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillSpill(spillQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Spill> GetSpillList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<Spill> spillQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return spillQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillSpill(spillQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
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
            return db.Spills.AsNoTracking();
        }
        public IQueryable<Spill> GetEdit()
        {
            return db.Spills;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<Spill> FillSpill_Show_Copy_To_SpillServiceExtra_As_Fill_Spill(IQueryable<Spill> spillQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
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
                        SpillReport = new SpillReport
                        {
                            SpillReportTest = "SpillReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return spillQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
