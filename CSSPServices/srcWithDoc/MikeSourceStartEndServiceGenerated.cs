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
    ///     <para>bonjour MikeSourceStartEnd</para>
    /// </summary>
    public partial class MikeSourceStartEndService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeSourceStartEnd mikeSourceStartEnd = validationContext.ObjectInstance as MikeSourceStartEnd;
            mikeSourceStartEnd.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mikeSourceStartEnd.MikeSourceStartEndID == 0)
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceStartEndMikeSourceStartEndID"), new[] { "MikeSourceStartEndID" });
                }

                if (!(from c in db.MikeSourceStartEnds select c).Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSourceStartEnd", "MikeSourceStartEndMikeSourceStartEndID", mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { "MikeSourceStartEndID" });
                }
            }

            MikeSource MikeSourceMikeSourceID = (from c in db.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();

            if (MikeSourceMikeSourceID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceStartEndMikeSourceID", mikeSourceStartEnd.MikeSourceID.ToString()), new[] { "MikeSourceID" });
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceStartEndStartDateAndTime_Local"), new[] { "StartDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.StartDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeSourceStartEndStartDateAndTime_Local", "1980"), new[] { "StartDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceStartEndEndDateAndTime_Local"), new[] { "EndDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.EndDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeSourceStartEndEndDateAndTime_Local", "1980"), new[] { "EndDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local > mikeSourceStartEnd.EndDateAndTime_Local)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "MikeSourceStartEndEndDateAndTime_Local", "MikeSourceStartEndStartDateAndTime_Local"), new[] { "MikeSourceStartEndEndDateAndTime_Local" });
            }

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourceFlowStart_m3_day", "0", "1000000"), new[] { "SourceFlowStart_m3_day" });
            }

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourceFlowEnd_m3_day", "0", "1000000"), new[] { "SourceFlowEnd_m3_day" });
            }

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourcePollutionStart_MPN_100ml", "0", "10000000"), new[] { "SourcePollutionStart_MPN_100ml" });
            }

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourcePollutionEnd_MPN_100ml", "0", "10000000"), new[] { "SourcePollutionEnd_MPN_100ml" });
            }

            if (mikeSourceStartEnd.SourceTemperatureStart_C < -10 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourceTemperatureStart_C", "-10", "40"), new[] { "SourceTemperatureStart_C" });
            }

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < -10 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourceTemperatureEnd_C", "-10", "40"), new[] { "SourceTemperatureEnd_C" });
            }

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourceSalinityStart_PSU", "0", "40"), new[] { "SourceSalinityStart_PSU" });
            }

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MikeSourceStartEndSourceSalinityEnd_PSU", "0", "40"), new[] { "SourceSalinityEnd_PSU" });
            }

            if (mikeSourceStartEnd.LastUpdateDate_UTC.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MikeSourceStartEndLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MikeSourceStartEndLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MikeSourceStartEndLastUpdateContactTVItemID", mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MikeSourceStartEndLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeSourceStartEnd GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID)
        {
            return (from c in db.MikeSourceStartEnds
                    where c.MikeSourceStartEndID == MikeSourceStartEndID
                    select c).FirstOrDefault();

        }
        public IQueryable<MikeSourceStartEnd> GetMikeSourceStartEndList()
        {
            IQueryable<MikeSourceStartEnd> MikeSourceStartEndQuery = (from c in db.MikeSourceStartEnds select c);

            MikeSourceStartEndQuery = EnhanceQueryStatements<MikeSourceStartEnd>(MikeSourceStartEndQuery) as IQueryable<MikeSourceStartEnd>;

            return MikeSourceStartEndQuery;
        }
        public MikeSourceStartEndExtraA GetMikeSourceStartEndExtraAWithMikeSourceStartEndID(int MikeSourceStartEndID)
        {
            return FillMikeSourceStartEndExtraA().Where(c => c.MikeSourceStartEndID == MikeSourceStartEndID).FirstOrDefault();

        }
        public IQueryable<MikeSourceStartEndExtraA> GetMikeSourceStartEndExtraAList()
        {
            IQueryable<MikeSourceStartEndExtraA> MikeSourceStartEndExtraAQuery = FillMikeSourceStartEndExtraA();

            MikeSourceStartEndExtraAQuery = EnhanceQueryStatements<MikeSourceStartEndExtraA>(MikeSourceStartEndExtraAQuery) as IQueryable<MikeSourceStartEndExtraA>;

            return MikeSourceStartEndExtraAQuery;
        }
        public MikeSourceStartEndExtraB GetMikeSourceStartEndExtraBWithMikeSourceStartEndID(int MikeSourceStartEndID)
        {
            return FillMikeSourceStartEndExtraB().Where(c => c.MikeSourceStartEndID == MikeSourceStartEndID).FirstOrDefault();

        }
        public IQueryable<MikeSourceStartEndExtraB> GetMikeSourceStartEndExtraBList()
        {
            IQueryable<MikeSourceStartEndExtraB> MikeSourceStartEndExtraBQuery = FillMikeSourceStartEndExtraB();

            MikeSourceStartEndExtraBQuery = EnhanceQueryStatements<MikeSourceStartEndExtraB>(MikeSourceStartEndExtraBQuery) as IQueryable<MikeSourceStartEndExtraB>;

            return MikeSourceStartEndExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Create);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;

            db.MikeSourceStartEnds.Add(mikeSourceStartEnd);

            if (!TryToSave(mikeSourceStartEnd)) return false;

            return true;
        }
        public bool Delete(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Delete);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;

            db.MikeSourceStartEnds.Remove(mikeSourceStartEnd);

            if (!TryToSave(mikeSourceStartEnd)) return false;

            return true;
        }
        public bool Update(MikeSourceStartEnd mikeSourceStartEnd)
        {
            mikeSourceStartEnd.ValidationResults = Validate(new ValidationContext(mikeSourceStartEnd), ActionDBTypeEnum.Update);
            if (mikeSourceStartEnd.ValidationResults.Count() > 0) return false;

            db.MikeSourceStartEnds.Update(mikeSourceStartEnd);

            if (!TryToSave(mikeSourceStartEnd)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(MikeSourceStartEnd mikeSourceStartEnd)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSourceStartEnd.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
