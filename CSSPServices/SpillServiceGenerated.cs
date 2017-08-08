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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (spill.SpillID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillSpillID), new[] { "SpillID" });
                }
            }

            //SpillID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MunicipalityTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == spill.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillMunicipalityTVItemID, spill.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SpillMunicipalityTVItemID, "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (spill.InfrastructureTVItemID != null)
            {
                TVItem TVItemInfrastructureTVItemID = (from c in db.TVItems where c.TVItemID == spill.InfrastructureTVItemID select c).FirstOrDefault();

                if (TVItemInfrastructureTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillInfrastructureTVItemID, spill.InfrastructureTVItemID.ToString()), new[] { "InfrastructureTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Infrastructure,
                    };
                    if (!AllowableTVTypes.Contains(TVItemInfrastructureTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SpillInfrastructureTVItemID, "Infrastructure"), new[] { "InfrastructureTVItemID" });
                    }
                }
            }

            if (spill.StartDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillStartDateTime_Local), new[] { "StartDateTime_Local" });
            }
            else
            {
                if (spill.StartDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillStartDateTime_Local, "1980"), new[] { "StartDateTime_Local" });
                }
            }

            if (spill.EndDateTime_Local != null && ((DateTime)spill.EndDateTime_Local).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillEndDateTime_Local, "1980"), new[] { ModelsRes.SpillEndDateTime_Local });
            }

            if (spill.StartDateTime_Local > spill.EndDateTime_Local)
            {
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.SpillEndDateTime_Local, ModelsRes.SpillStartDateTime_Local), new[] { ModelsRes.SpillEndDateTime_Local });
            }

            //AverageFlow_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (spill.AverageFlow_m3_day < 0 || spill.AverageFlow_m3_day > 1000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SpillAverageFlow_m3_day, "0", "1000000"), new[] { "AverageFlow_m3_day" });
            }

            if (spill.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SpillLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (spill.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SpillLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == spill.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLastUpdateContactTVItemID, spill.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SpillLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(spill.MunicipalityTVText) && spill.MunicipalityTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillMunicipalityTVText, "200"), new[] { "MunicipalityTVText" });
            }

            if (!string.IsNullOrWhiteSpace(spill.InfrastructureTVText) && spill.InfrastructureTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillInfrastructureTVText, "200"), new[] { "InfrastructureTVText" });
            }

            if (!string.IsNullOrWhiteSpace(spill.LastUpdateContactTVText) && spill.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SpillLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Spill GetSpillWithSpillID(int SpillID)
        {
            IQueryable<Spill> spillQuery = (from c in GetRead()
                                                where c.SpillID == SpillID
                                                select c);

            return FillSpill(spillQuery).FirstOrDefault();
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
        public bool AddRange(List<Spill> spillList)
        {
            foreach (Spill spill in spillList)
            {
                spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Create);
                if (spill.ValidationResults.Count() > 0) return false;
            }

            db.Spills.AddRange(spillList);

            if (!TryToSaveRange(spillList)) return false;

            return true;
        }
        public bool Delete(Spill spill)
        {
            if (!db.Spills.Where(c => c.SpillID == spill.SpillID).Any())
            {
                spill.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Spills.Remove(spill);

            if (!TryToSave(spill)) return false;

            return true;
        }
        public bool DeleteRange(List<Spill> spillList)
        {
            foreach (Spill spill in spillList)
            {
                if (!db.Spills.Where(c => c.SpillID == spill.SpillID).Any())
                {
                    spillList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Spill", "SpillID", spill.SpillID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Spills.RemoveRange(spillList);

            if (!TryToSaveRange(spillList)) return false;

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
        public bool UpdateRange(List<Spill> spillList)
        {
            foreach (Spill spill in spillList)
            {
                spill.ValidationResults = Validate(new ValidationContext(spill), ActionDBTypeEnum.Update);
                if (spill.ValidationResults.Count() > 0) return false;
            }
            db.Spills.UpdateRange(spillList);

            if (!TryToSaveRange(spillList)) return false;

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
        private List<Spill> FillSpill(IQueryable<Spill> spillQuery)
        {
            List<Spill> SpillList = (from c in spillQuery
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
                                             MunicipalityTVText = MunicipalityTVText,
                                             InfrastructureTVText = InfrastructureTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return SpillList;
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
        private bool TryToSaveRange(List<Spill> spillList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                spillList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
