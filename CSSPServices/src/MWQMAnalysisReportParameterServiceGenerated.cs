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
    ///     <para>bonjour MWQMAnalysisReportParameter</para>
    /// </summary>
    public partial class MWQMAnalysisReportParameterService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterMWQMAnalysisReportParameterID"), new[] { "MWQMAnalysisReportParameterID" });
                }

                if (!(from c in db.MWQMAnalysisReportParameters select c).Where(c => c.MWQMAnalysisReportParameterID == mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID).Any())
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "MWQMAnalysisReportParameter", "MWQMAnalysisReportParameterMWQMAnalysisReportParameterID", mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID.ToString()), new[] { "MWQMAnalysisReportParameterID" });
                }
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMAnalysisReportParameterSubsectorTVItemID", mwqmAnalysisReportParameter.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMAnalysisReportParameterSubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.AnalysisName))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterAnalysisName"), new[] { "AnalysisName" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.AnalysisName) && (mwqmAnalysisReportParameter.AnalysisName.Length < 5 || mwqmAnalysisReportParameter.AnalysisName.Length > 250))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "MWQMAnalysisReportParameterAnalysisName", "5", "250"), new[] { "AnalysisName" });
            }

            if (mwqmAnalysisReportParameter.AnalysisReportYear != null)
            {
                if (mwqmAnalysisReportParameter.AnalysisReportYear < 1980 || mwqmAnalysisReportParameter.AnalysisReportYear > 2050)
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterAnalysisReportYear", "1980", "2050"), new[] { "AnalysisReportYear" });
                }
            }

            if (mwqmAnalysisReportParameter.StartDate.Year == 1)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterStartDate"), new[] { "StartDate" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.StartDate.Year < 1980)
                {
                mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMAnalysisReportParameterStartDate", "1980"), new[] { "StartDate" });
                }
            }

            if (mwqmAnalysisReportParameter.EndDate.Year == 1)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterEndDate"), new[] { "EndDate" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.EndDate.Year < 1980)
                {
                mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMAnalysisReportParameterEndDate", "1980"), new[] { "EndDate" });
                }
            }

            if (mwqmAnalysisReportParameter.StartDate > mwqmAnalysisReportParameter.EndDate)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._DateIsBiggerThan_, "MWQMAnalysisReportParameterEndDate", "MWQMAnalysisReportParameterStartDate"), new[] { "MWQMAnalysisReportParameterEndDate" });
            }

            retStr = enums.EnumTypeOK(typeof(AnalysisCalculationTypeEnum), (int?)mwqmAnalysisReportParameter.AnalysisCalculationType);
            if (mwqmAnalysisReportParameter.AnalysisCalculationType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterAnalysisCalculationType"), new[] { "AnalysisCalculationType" });
            }

            if (mwqmAnalysisReportParameter.NumberOfRuns < 1 || mwqmAnalysisReportParameter.NumberOfRuns > 1000)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterNumberOfRuns", "1", "1000"), new[] { "NumberOfRuns" });
            }

            if (mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage < 1 || mwqmAnalysisReportParameter.SalinityHighlightDeviationFromAverage > 20)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterSalinityHighlightDeviationFromAverage", "1", "20"), new[] { "SalinityHighlightDeviationFromAverage" });
            }

            if (mwqmAnalysisReportParameter.ShortRangeNumberOfDays < 0 || mwqmAnalysisReportParameter.ShortRangeNumberOfDays > 5)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterShortRangeNumberOfDays", "0", "5"), new[] { "ShortRangeNumberOfDays" });
            }

            if (mwqmAnalysisReportParameter.MidRangeNumberOfDays < 2 || mwqmAnalysisReportParameter.MidRangeNumberOfDays > 7)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterMidRangeNumberOfDays", "2", "7"), new[] { "MidRangeNumberOfDays" });
            }

            if (mwqmAnalysisReportParameter.DryLimit24h < 1 || mwqmAnalysisReportParameter.DryLimit24h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterDryLimit24h", "1", "100"), new[] { "DryLimit24h" });
            }

            if (mwqmAnalysisReportParameter.DryLimit48h < 1 || mwqmAnalysisReportParameter.DryLimit48h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterDryLimit48h", "1", "100"), new[] { "DryLimit48h" });
            }

            if (mwqmAnalysisReportParameter.DryLimit72h < 1 || mwqmAnalysisReportParameter.DryLimit72h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterDryLimit72h", "1", "100"), new[] { "DryLimit72h" });
            }

            if (mwqmAnalysisReportParameter.DryLimit96h < 1 || mwqmAnalysisReportParameter.DryLimit96h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterDryLimit96h", "1", "100"), new[] { "DryLimit96h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit24h < 1 || mwqmAnalysisReportParameter.WetLimit24h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterWetLimit24h", "1", "100"), new[] { "WetLimit24h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit48h < 1 || mwqmAnalysisReportParameter.WetLimit48h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterWetLimit48h", "1", "100"), new[] { "WetLimit48h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit72h < 1 || mwqmAnalysisReportParameter.WetLimit72h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterWetLimit72h", "1", "100"), new[] { "WetLimit72h" });
            }

            if (mwqmAnalysisReportParameter.WetLimit96h < 1 || mwqmAnalysisReportParameter.WetLimit96h > 100)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "MWQMAnalysisReportParameterWetLimit96h", "1", "100"), new[] { "WetLimit96h" });
            }

            if (string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.RunsToOmit))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterRunsToOmit"), new[] { "RunsToOmit" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.RunsToOmit) && mwqmAnalysisReportParameter.RunsToOmit.Length > 250)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMAnalysisReportParameterRunsToOmit", "250"), new[] { "RunsToOmit" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmAnalysisReportParameter.ShowDataTypes) && mwqmAnalysisReportParameter.ShowDataTypes.Length > 20)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "MWQMAnalysisReportParameterShowDataTypes", "20"), new[] { "ShowDataTypes" });
            }

            if (mwqmAnalysisReportParameter.ExcelTVFileTVItemID != null)
            {
                TVItem TVItemExcelTVFileTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.ExcelTVFileTVItemID select c).FirstOrDefault();

                if (TVItemExcelTVFileTVItemID == null)
                {
                    mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMAnalysisReportParameterExcelTVFileTVItemID", (mwqmAnalysisReportParameter.ExcelTVFileTVItemID == null ? "" : mwqmAnalysisReportParameter.ExcelTVFileTVItemID.ToString())), new[] { "ExcelTVFileTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemExcelTVFileTVItemID.TVType))
                    {
                        mwqmAnalysisReportParameter.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMAnalysisReportParameterExcelTVFileTVItemID", "File"), new[] { "ExcelTVFileTVItemID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(AnalysisReportExportCommandEnum), (int?)mwqmAnalysisReportParameter.Command);
            if (mwqmAnalysisReportParameter.Command == null || !string.IsNullOrWhiteSpace(retStr))
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterCommand"), new[] { "Command" });
            }

            if (mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year == 1)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "MWQMAnalysisReportParameterLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmAnalysisReportParameter.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmAnalysisReportParameter.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "MWQMAnalysisReportParameterLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmAnalysisReportParameter.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmAnalysisReportParameter.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMAnalysisReportParameterLastUpdateContactTVItemID", mwqmAnalysisReportParameter.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMAnalysisReportParameterLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.MWQMAnalysisReportParameters
                    where c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID
                    select c).FirstOrDefault();

        }
        public IQueryable<MWQMAnalysisReportParameter> GetMWQMAnalysisReportParameterList()
        {
            IQueryable<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterQuery = (from c in db.MWQMAnalysisReportParameters select c);

            MWQMAnalysisReportParameterQuery = EnhanceQueryStatements<MWQMAnalysisReportParameter>(MWQMAnalysisReportParameterQuery) as IQueryable<MWQMAnalysisReportParameter>;

            return MWQMAnalysisReportParameterQuery;
        }
        public MWQMAnalysisReportParameter_A GetMWQMAnalysisReportParameter_AWithMWQMAnalysisReportParameterID(int MWQMAnalysisReportParameterID)
        {
            return FillMWQMAnalysisReportParameter_A().Where(c => c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID).FirstOrDefault();

        }
        public IQueryable<MWQMAnalysisReportParameter_A> GetMWQMAnalysisReportParameter_AList()
        {
            IQueryable<MWQMAnalysisReportParameter_A> MWQMAnalysisReportParameter_AQuery = FillMWQMAnalysisReportParameter_A();

            MWQMAnalysisReportParameter_AQuery = EnhanceQueryStatements<MWQMAnalysisReportParameter_A>(MWQMAnalysisReportParameter_AQuery) as IQueryable<MWQMAnalysisReportParameter_A>;

            return MWQMAnalysisReportParameter_AQuery;
        }
        public MWQMAnalysisReportParameter_B GetMWQMAnalysisReportParameter_BWithMWQMAnalysisReportParameterID(int MWQMAnalysisReportParameterID)
        {
            return FillMWQMAnalysisReportParameter_B().Where(c => c.MWQMAnalysisReportParameterID == MWQMAnalysisReportParameterID).FirstOrDefault();

        }
        public IQueryable<MWQMAnalysisReportParameter_B> GetMWQMAnalysisReportParameter_BList()
        {
            IQueryable<MWQMAnalysisReportParameter_B> MWQMAnalysisReportParameter_BQuery = FillMWQMAnalysisReportParameter_B();

            MWQMAnalysisReportParameter_BQuery = EnhanceQueryStatements<MWQMAnalysisReportParameter_B>(MWQMAnalysisReportParameter_BQuery) as IQueryable<MWQMAnalysisReportParameter_B>;

            return MWQMAnalysisReportParameter_BQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
