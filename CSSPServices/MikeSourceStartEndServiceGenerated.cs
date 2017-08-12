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
    public partial class MikeSourceStartEndService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndMikeSourceStartEndID), new[] { "MikeSourceStartEndID" });
                }

                if (!GetRead().Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MikeSourceStartEnd, ModelsRes.MikeSourceStartEndMikeSourceStartEndID, mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { "MikeSourceStartEndID" });
                }
            }

            //MikeSourceStartEndID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeSourceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MikeSource MikeSourceMikeSourceID = (from c in db.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();

            if (MikeSourceMikeSourceID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MikeSource, ModelsRes.MikeSourceStartEndMikeSourceID, mikeSourceStartEnd.MikeSourceID.ToString()), new[] { "MikeSourceID" });
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndStartDateAndTime_Local), new[] { "StartDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.StartDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeSourceStartEndStartDateAndTime_Local, "1980"), new[] { "StartDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndEndDateAndTime_Local), new[] { "EndDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.EndDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeSourceStartEndEndDateAndTime_Local, "1980"), new[] { "EndDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local > mikeSourceStartEnd.EndDateAndTime_Local)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.MikeSourceStartEndEndDateAndTime_Local, ModelsRes.MikeSourceStartEndStartDateAndTime_Local), new[] { ModelsRes.MikeSourceStartEndEndDateAndTime_Local });
            }

            //SourceFlowStart_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), new[] { "SourceFlowStart_m3_day" });
            }

            //SourceFlowEnd_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), new[] { "SourceFlowEnd_m3_day" });
            }

            //SourcePollutionStart_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000"), new[] { "SourcePollutionStart_MPN_100ml" });
            }

            //SourcePollutionEnd_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000"), new[] { "SourcePollutionEnd_MPN_100ml" });
            }

            //SourceTemperatureStart_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceTemperatureStart_C < -10 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40"), new[] { "SourceTemperatureStart_C" });
            }

            //SourceTemperatureEnd_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < -10 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40"), new[] { "SourceTemperatureEnd_C" });
            }

            //SourceSalinityStart_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), new[] { "SourceSalinityStart_PSU" });
            }

            //SourceSalinityEnd_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), new[] { "SourceSalinityEnd_PSU" });
            }

            if (mikeSourceStartEnd.LastUpdateDate_UTC.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceStartEndLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeSourceStartEndLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mikeSourceStartEnd.LastUpdateContactTVText) && mikeSourceStartEnd.LastUpdateContactTVText.Length > 200)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceStartEndLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
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
            IQueryable<MikeSourceStartEnd> mikeSourceStartEndQuery = (from c in GetRead()
                                                where c.MikeSourceStartEndID == MikeSourceStartEndID
                                                select c);

            return FillMikeSourceStartEnd(mikeSourceStartEndQuery).FirstOrDefault();
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
        public IQueryable<MikeSourceStartEnd> GetRead()
        {
            return db.MikeSourceStartEnds.AsNoTracking();
        }
        public IQueryable<MikeSourceStartEnd> GetEdit()
        {
            return db.MikeSourceStartEnds;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MikeSourceStartEnd> FillMikeSourceStartEnd(IQueryable<MikeSourceStartEnd> mikeSourceStartEndQuery)
        {
            List<MikeSourceStartEnd> MikeSourceStartEndList = (from c in mikeSourceStartEndQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MikeSourceStartEnd
                                         {
                                             MikeSourceStartEndID = c.MikeSourceStartEndID,
                                             MikeSourceID = c.MikeSourceID,
                                             StartDateAndTime_Local = c.StartDateAndTime_Local,
                                             EndDateAndTime_Local = c.EndDateAndTime_Local,
                                             SourceFlowStart_m3_day = c.SourceFlowStart_m3_day,
                                             SourceFlowEnd_m3_day = c.SourceFlowEnd_m3_day,
                                             SourcePollutionStart_MPN_100ml = c.SourcePollutionStart_MPN_100ml,
                                             SourcePollutionEnd_MPN_100ml = c.SourcePollutionEnd_MPN_100ml,
                                             SourceTemperatureStart_C = c.SourceTemperatureStart_C,
                                             SourceTemperatureEnd_C = c.SourceTemperatureEnd_C,
                                             SourceSalinityStart_PSU = c.SourceSalinityStart_PSU,
                                             SourceSalinityEnd_PSU = c.SourceSalinityEnd_PSU,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return MikeSourceStartEndList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
