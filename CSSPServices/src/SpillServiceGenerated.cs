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
    public partial class SpillService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SpillService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SpillID"), new[] { "SpillID" });
                }

                if (!(from c in db.Spills select c).Where(c => c.SpillID == spill.SpillID).Any())
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString()), new[] { "SpillID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MunicipalityTVItemID", spill.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MunicipalityTVItemID", "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();

                if (TVItemInfrastructureTVItemID == null)
                {
                    spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "InfrastructureTVItemID", (spill.InfrastructureTVItemID == null ? "" : spill.InfrastructureTVItemID.ToString())), new[] { "InfrastructureTVItemID" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "InfrastructureTVItemID", "Infrastructure"), new[] { "InfrastructureTVItemID" });
                    }
                }
            }

            if (spill.StartDateTime_Local.Year == 1)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "StartDateTime_Local"), new[] { "StartDateTime_Local" });
            }
            else
            {
                if (spill.StartDateTime_Local.Year < 1980)
                {
                spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "StartDateTime_Local", "1980"), new[] { "StartDateTime_Local" });
                }
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "EndDateTime_Local", "1980"), new[] { "EndDateTime_Local" });
            }

            if (spill.StartDateTime_Local > spill.EndDateTime_Local)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "EndDateTime_Local", "SpillStartDateTime_Local"), new[] { "EndDateTime_Local" });
            }

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "AverageFlow_m3_day", "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

            if (spill.LastUpdateDate_UTC.Year == 1)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spill.LastUpdateDate_UTC.Year < 1980)
                {
                spill.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                spill.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", spill.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
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
            return (from c in db.Spills
                    where c.SpillID == SpillID
                    select c).FirstOrDefault();

        }
        public IQueryable<Spill> GetSpillList()
        {
            IQueryable<Spill> SpillQuery = (from c in db.Spills select c);

            SpillQuery = EnhanceQueryStatements<Spill>(SpillQuery) as IQueryable<Spill>;

            return SpillQuery;
        }
        public SpillExtraA GetSpillExtraAWithSpillID(int SpillID)
        {
            return FillSpillExtraA().Where(c => c.SpillID == SpillID).FirstOrDefault();

        }
        public IQueryable<SpillExtraA> GetSpillExtraAList()
        {
            IQueryable<SpillExtraA> SpillExtraAQuery = FillSpillExtraA();

            SpillExtraAQuery = EnhanceQueryStatements<SpillExtraA>(SpillExtraAQuery) as IQueryable<SpillExtraA>;

            return SpillExtraAQuery;
        }
        public SpillExtraB GetSpillExtraBWithSpillID(int SpillID)
        {
            return FillSpillExtraB().Where(c => c.SpillID == SpillID).FirstOrDefault();

        }
        public IQueryable<SpillExtraB> GetSpillExtraBList()
        {
            IQueryable<SpillExtraB> SpillExtraBQuery = FillSpillExtraB();

            SpillExtraBQuery = EnhanceQueryStatements<SpillExtraB>(SpillExtraBQuery) as IQueryable<SpillExtraB>;

            return SpillExtraBQuery;
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
        #endregion Functions public Generated CRUD

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
