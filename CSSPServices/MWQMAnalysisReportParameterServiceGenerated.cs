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
    public partial class MWQMAnalysisReportParameterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMAnalysisReportParameter mwqmAnalysisReportParameter = validationContext.ObjectInstance as MWQMAnalysisReportParameter;
            mwqmAnalysisReportParameter.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID == 0)
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMAnalysisReportParameterMWQMAnalysisReportParameterID), new[] { "MWQMAnalysisReportParameterID" });
                }

                if (!GetRead().Where(c => c.MWQMAnalysisReportParameterID == mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID).Any())
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.MWQMAnalysisReportParameter, ModelsRes.MWQMAnalysisReportParameterMWQMAnalysisReportParameterID, mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID.ToString()), new[] { "MWQMAnalysisReportParameterID" });
                }
            }

            //MWQMAnalysisReportParameterID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.MWQMSubsectorTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSubsectorTVItemID == null)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMAnalysisReportParameterMWQMSubsectorTVItemID, mwqmAnalysisReportParameter.MWQMSubsectorTVItemID.ToString()), new[] { "MWQMSubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Error,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSubsectorTVItemID.TVType))
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMAnalysisReportParameterMWQMSubsectorTVItemID, "Error"), new[] { "MWQMSubsectorTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.Name))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMAnalysisReportParameterName), new[] { "Name" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.Name) && (mwqmAnalysisReportParameter.Name.Length < 5 || mwqmAnalysisReportParameter.Name.Length > 250))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterName, "5", "250"), new[] { "Name" });
            }

            //AnalysisReportYear (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.AnalysisReportYear < 1980 || mwqmAnalysisReportParameter.AnalysisReportYear > 2050)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterAnalysisReportYear, "1980", "2050"), new[] { "AnalysisReportYear" });
            }

            if (mwqmAnalysisReportParameter.StartDate.Year == 1)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMAnalysisReportParameterStartDate), new[] { "StartDate" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.StartDate.Year < 1980)
                {
                mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMAnalysisReportParameterStartDate, "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmAnalysisReportParameter.EndDate.Year == 1)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMAnalysisReportParameterEndDate), new[] { "EndDate" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.EndDate.Year < 1980)
                {
                mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMAnalysisReportParameterEndDate, "1980"), new[] { "EndDate" });
                }
            }

            if (mwqmAnalysisReportParameter.StartDate > mwqmAnalysisReportParameter.EndDate)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._DateIsBiggerThan_, ModelsRes.MWQMAnalysisReportParameterEndDate, ModelsRes.MWQMAnalysisReportParameterStartDate), new[] { ModelsRes.MWQMAnalysisReportParameterEndDate });
            }

            retStr = enums.EnumTypeOK(typeof(AnalysisCalculationTypeEnum), (int?)mwqmAnalysisReportParameter.AnalysisCalculationType);
            if (mwqmAnalysisReportParameter.AnalysisCalculationType == AnalysisCalculationTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMAnalysisReportParameterAnalysisCalculationType), new[] { "AnalysisCalculationType" });
            }

            //NumberOfRuns (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.NumberOfRuns < 1 || mwqmAnalysisReportParameter.NumberOfRuns > 1000)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterNumberOfRuns, "1", "1000"), new[] { "NumberOfRuns" });
            }

            //FullYear (bool) is required but no testing needed 

            //SalinityHighlightDeviationFromAverage (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage < 1 || mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage > 20)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage, "1", "20"), new[] { "SalinityHighlightDeviationFromAverage" });
            }

            //ShortRangeNumberOfDays (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.ShortRangeNumberOfDays < 0 || mwqmAnalysisReportParameter.ShortRangeNumberOfDays > 5)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterShortRangeNumberOfDays, "0", "5"), new[] { "ShortRangeNumberOfDays" });
            }

            //MidRangeNumberOfDays (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.MidRangeNumberOfDays < 2 || mwqmAnalysisReportParameter.MidRangeNumberOfDays > 7)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterMidRangeNumberOfDays, "2", "7"), new[] { "MidRangeNumberOfDays" });
            }

            //DryLimit24h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.DryLimit24h < 1 || mwqmAnalysisReportParameter.DryLimit24h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterDryLimit24h, "1", "100"), new[] { "DryLimit24h" });
            }

            //DryLimit48h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.DryLimit48h < 1 || mwqmAnalysisReportParameter.DryLimit48h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterDryLimit48h, "1", "100"), new[] { "DryLimit48h" });
            }

            //DryLimit72h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.DryLimit72h < 1 || mwqmAnalysisReportParameter.DryLimit72h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterDryLimit72h, "1", "100"), new[] { "DryLimit72h" });
            }

            //DryLimit96h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.DryLimit96h < 1 || mwqmAnalysisReportParameter.DryLimit96h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterDryLimit96h, "1", "100"), new[] { "DryLimit96h" });
            }

            //WetLimit24h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.WetLimit24h < 1 || mwqmAnalysisReportParameter.WetLimit24h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterWetLimit24h, "1", "100"), new[] { "WetLimit24h" });
            }

            //WetLimit48h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.WetLimit48h < 1 || mwqmAnalysisReportParameter.WetLimit48h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterWetLimit48h, "1", "100"), new[] { "WetLimit48h" });
            }

            //WetLimit72h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.WetLimit72h < 1 || mwqmAnalysisReportParameter.WetLimit72h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterWetLimit72h, "1", "100"), new[] { "WetLimit72h" });
            }

            //WetLimit96h (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmAnalysisReportParameter.WetLimit96h < 1 || mwqmAnalysisReportParameter.WetLimit96h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMAnalysisReportParameterWetLimit96h, "1", "100"), new[] { "WetLimit96h" });
            }

            if (mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year == 1)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMAnalysisReportParameterLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMAnalysisReportParameterLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVItemID, mwqmAnalysisReportParameter.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.LastUpdateContactTVText) && mwqmAnalysisReportParameter.LastUpdateContactTVText.Length > 200)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMAnalysisReportParameterLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMAnalysisReportParameter GetMWQMAnalysisReportParameterWithMWQMAnalysisReportParameterID(int MWQMAnalysisReportParameterID)
        {
            IQueryable<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterQuery = (from c in GetRead()
                                                where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                                                select c);

            return FillMWQMAnalysisReportParameter(mwqmAnalysisReportParameterQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            mwqmAnalysisReportParameter.ValidationResults = Validate(new ValidationContext(mwqmAnalysisReportParameter), ActionDBTypeEnum.Create);
            if (mwqmAnalysisReportParameter.ValidationResults.Count() > 0) return false;

            db.MWQMAnalysisReportParameters.Add(mwqmAnalysisReportParameter);

            if (!TryToSave(mwqmAnalysisReportParameter)) return false;

            return true;
        }
        public bool Delete(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            mwqmAnalysisReportParameter.ValidationResults = Validate(new ValidationContext(mwqmAnalysisReportParameter), ActionDBTypeEnum.Delete);
            if (mwqmAnalysisReportParameter.ValidationResults.Count() > 0) return false;

            db.MWQMAnalysisReportParameters.Remove(mwqmAnalysisReportParameter);

            if (!TryToSave(mwqmAnalysisReportParameter)) return false;

            return true;
        }
        public bool Update(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            mwqmAnalysisReportParameter.ValidationResults = Validate(new ValidationContext(mwqmAnalysisReportParameter), ActionDBTypeEnum.Update);
            if (mwqmAnalysisReportParameter.ValidationResults.Count() > 0) return false;

            db.MWQMAnalysisReportParameters.Update(mwqmAnalysisReportParameter);

            if (!TryToSave(mwqmAnalysisReportParameter)) return false;

            return true;
        }
        public IQueryable<MWQMAnalysisReportParameter> GetRead()
        {
            return db.MWQMAnalysisReportParameters.AsNoTracking();
        }
        public IQueryable<MWQMAnalysisReportParameter> GetEdit()
        {
            return db.MWQMAnalysisReportParameters;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMAnalysisReportParameter> FillMWQMAnalysisReportParameter(IQueryable<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterQuery)
        {
            List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList = (from c in mwqmAnalysisReportParameterQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMAnalysisReportParameter
                                         {
                                             MWQMAnalysisReportParameterID = c.MWQMAnalysisReportParameterID,
                                             MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                             Name = c.Name,
                                             AnalysisReportYear = c.AnalysisReportYear,
                                             StartDate = c.StartDate,
                                             EndDate = c.EndDate,
                                             AnalysisCalculationType = c.AnalysisCalculationType,
                                             NumberOfRuns = c.NumberOfRuns,
                                             FullYear = c.FullYear,
                                             SalinityHighlightDeviationFromAverage = c.SalinityHighlightDeviationFromAverage,
                                             ShortRangeNumberOfDays = c.ShortRangeNumberOfDays,
                                             MidRangeNumberOfDays = c.MidRangeNumberOfDays,
                                             DryLimit24h = c.DryLimit24h,
                                             DryLimit48h = c.DryLimit48h,
                                             DryLimit72h = c.DryLimit72h,
                                             DryLimit96h = c.DryLimit96h,
                                             WetLimit24h = c.WetLimit24h,
                                             WetLimit48h = c.WetLimit48h,
                                             WetLimit72h = c.WetLimit72h,
                                             WetLimit96h = c.WetLimit96h,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (MWQMAnalysisReportParameter mwqmAnalysisReportParameter in MWQMAnalysisReportParameterList)
            {
            }

            return MWQMAnalysisReportParameterList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmAnalysisReportParameter.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
