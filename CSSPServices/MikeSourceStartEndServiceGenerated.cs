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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID), new[] { "MikeSourceStartEndID" });
                }

                if (!GetRead().Where(c => c.MikeSourceStartEndID == mikeSourceStartEnd.MikeSourceStartEndID).Any())
                {
                    mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSourceStartEnd, CSSPModelsRes.MikeSourceStartEndMikeSourceStartEndID, mikeSourceStartEnd.MikeSourceStartEndID.ToString()), new[] { "MikeSourceStartEndID" });
                }
            }

            //MikeSourceStartEndID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeSourceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            MikeSource MikeSourceMikeSourceID = (from c in db.MikeSources where c.MikeSourceID == mikeSourceStartEnd.MikeSourceID select c).FirstOrDefault();

            if (MikeSourceMikeSourceID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MikeSource, CSSPModelsRes.MikeSourceStartEndMikeSourceID, mikeSourceStartEnd.MikeSourceID.ToString()), new[] { "MikeSourceID" });
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndStartDateAndTime_Local), new[] { "StartDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.StartDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceStartEndStartDateAndTime_Local, "1980"), new[] { "StartDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.EndDateAndTime_Local.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local), new[] { "EndDateAndTime_Local" });
            }
            else
            {
                if (mikeSourceStartEnd.EndDateAndTime_Local.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local, "1980"), new[] { "EndDateAndTime_Local" });
                }
            }

            if (mikeSourceStartEnd.StartDateAndTime_Local > mikeSourceStartEnd.EndDateAndTime_Local)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, CSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local, CSSPModelsRes.MikeSourceStartEndStartDateAndTime_Local), new[] { CSSPModelsRes.MikeSourceStartEndEndDateAndTime_Local });
            }

            //SourceFlowStart_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceFlowStart_m3_day < 0 || mikeSourceStartEnd.SourceFlowStart_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowStart_m3_day, "0", "1000000"), new[] { "SourceFlowStart_m3_day" });
            }

            //SourceFlowEnd_m3_day (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceFlowEnd_m3_day < 0 || mikeSourceStartEnd.SourceFlowEnd_m3_day > 1000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceFlowEnd_m3_day, "0", "1000000"), new[] { "SourceFlowEnd_m3_day" });
            }

            //SourcePollutionStart_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourcePollutionStart_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionStart_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionStart_MPN_100ml, "0", "10000000"), new[] { "SourcePollutionStart_MPN_100ml" });
            }

            //SourcePollutionEnd_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml < 0 || mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml > 10000000)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourcePollutionEnd_MPN_100ml, "0", "10000000"), new[] { "SourcePollutionEnd_MPN_100ml" });
            }

            //SourceTemperatureStart_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceTemperatureStart_C < -10 || mikeSourceStartEnd.SourceTemperatureStart_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureStart_C, "-10", "40"), new[] { "SourceTemperatureStart_C" });
            }

            //SourceTemperatureEnd_C (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceTemperatureEnd_C < -10 || mikeSourceStartEnd.SourceTemperatureEnd_C > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceTemperatureEnd_C, "-10", "40"), new[] { "SourceTemperatureEnd_C" });
            }

            //SourceSalinityStart_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceSalinityStart_PSU < 0 || mikeSourceStartEnd.SourceSalinityStart_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityStart_PSU, "0", "40"), new[] { "SourceSalinityStart_PSU" });
            }

            //SourceSalinityEnd_PSU (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mikeSourceStartEnd.SourceSalinityEnd_PSU < 0 || mikeSourceStartEnd.SourceSalinityEnd_PSU > 40)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MikeSourceStartEndSourceSalinityEnd_PSU, "0", "40"), new[] { "SourceSalinityEnd_PSU" });
            }

                //Error: Type not implemented [MikeSourceStartEndWeb] of type [MikeSourceStartEndWeb]
                //Error: Type not implemented [MikeSourceStartEndReport] of type [MikeSourceStartEndReport]
            if (mikeSourceStartEnd.LastUpdateDate_UTC.Year == 1)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MikeSourceStartEndLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSourceStartEnd.LastUpdateDate_UTC.Year < 1980)
                {
                mikeSourceStartEnd.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MikeSourceStartEndLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSourceStartEnd.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mikeSourceStartEnd.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, mikeSourceStartEnd.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MikeSourceStartEndLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
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
        public MikeSourceStartEnd GetMikeSourceStartEndWithMikeSourceStartEndID(int MikeSourceStartEndID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MikeSourceStartEnd> mikeSourceStartEndQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MikeSourceStartEndID == MikeSourceStartEndID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mikeSourceStartEndQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMikeSourceStartEnd(mikeSourceStartEndQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MikeSourceStartEnd> GetMikeSourceStartEndList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MikeSourceStartEnd> mikeSourceStartEndQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mikeSourceStartEndQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMikeSourceStartEnd(mikeSourceStartEndQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
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
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<MikeSourceStartEnd> FillMikeSourceStartEnd_Show_Copy_To_MikeSourceStartEndServiceExtra_As_Fill_MikeSourceStartEnd(IQueryable<MikeSourceStartEnd> mikeSourceStartEndQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            mikeSourceStartEndQuery = (from c in mikeSourceStartEndQuery
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
                        MikeSourceStartEndWeb = new MikeSourceStartEndWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        MikeSourceStartEndReport = new MikeSourceStartEndReport
                        {
                            MikeSourceStartEndReportTest = "MikeSourceStartEndReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mikeSourceStartEndQuery;
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
