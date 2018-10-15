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
    ///     <para>bonjour SamplingPlan</para>
    /// </summary>
    public partial class SamplingPlanService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public SamplingPlanService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            SamplingPlan samplingPlan = validationContext.ObjectInstance as SamplingPlan;
            samplingPlan.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (samplingPlan.SamplingPlanID == 0)
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSamplingPlanID"), new[] { "SamplingPlanID" });
                }

                if (!(from c in db.SamplingPlans select c).Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanSamplingPlanID", samplingPlan.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
                }
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSamplingPlanName"), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName) && samplingPlan.SamplingPlanName.Length > 200)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanSamplingPlanName", "200"), new[] { "SamplingPlanName" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ForGroupName))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanForGroupName"), new[] { "ForGroupName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ForGroupName) && samplingPlan.ForGroupName.Length > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanForGroupName", "100"), new[] { "ForGroupName" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)samplingPlan.SampleType);
            if (samplingPlan.SampleType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSampleType"), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)samplingPlan.SamplingPlanType);
            if (samplingPlan.SamplingPlanType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSamplingPlanType"), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)samplingPlan.LabSheetType);
            if (samplingPlan.LabSheetType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanLabSheetType"), new[] { "LabSheetType" });
            }

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanProvinceTVItemID", samplingPlan.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanProvinceTVItemID", "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            TVItem TVItemCreatorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.CreatorTVItemID select c).FirstOrDefault();

            if (TVItemCreatorTVItemID == null)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanCreatorTVItemID", samplingPlan.CreatorTVItemID.ToString()), new[] { "CreatorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemCreatorTVItemID.TVType))
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanCreatorTVItemID", "Contact"), new[] { "CreatorTVItemID" });
                }
            }

            if (samplingPlan.Year < 2000 || samplingPlan.Year > 2050)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanYear", "2000", "2050"), new[] { "Year" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.AccessCode))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanAccessCode"), new[] { "AccessCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.AccessCode) && samplingPlan.AccessCode.Length > 15)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanAccessCode", "15"), new[] { "AccessCode" });
            }

            if (samplingPlan.DailyDuplicatePrecisionCriteria < 0 || samplingPlan.DailyDuplicatePrecisionCriteria > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanDailyDuplicatePrecisionCriteria", "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            if (samplingPlan.IntertechDuplicatePrecisionCriteria < 0 || samplingPlan.IntertechDuplicatePrecisionCriteria > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "SamplingPlanIntertechDuplicatePrecisionCriteria", "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanApprovalCode"), new[] { "ApprovalCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode) && samplingPlan.ApprovalCode.Length > 15)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanApprovalCode", "15"), new[] { "ApprovalCode" });
            }

            if (samplingPlan.SamplingPlanFileTVItemID != null)
            {
                TVItem TVItemSamplingPlanFileTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.SamplingPlanFileTVItemID select c).FirstOrDefault();

                if (TVItemSamplingPlanFileTVItemID == null)
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanSamplingPlanFileTVItemID", (samplingPlan.SamplingPlanFileTVItemID == null ? "" : samplingPlan.SamplingPlanFileTVItemID.ToString())), new[] { "SamplingPlanFileTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSamplingPlanFileTVItemID.TVType))
                    {
                        samplingPlan.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanSamplingPlanFileTVItemID", "File"), new[] { "SamplingPlanFileTVItemID" });
                    }
                }
            }

            if (samplingPlan.AnalyzeMethodDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(AnalyzeMethodEnum), (int?)samplingPlan.AnalyzeMethodDefault);
                if (samplingPlan.AnalyzeMethodDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanAnalyzeMethodDefault"), new[] { "AnalyzeMethodDefault" });
                }
            }

            if (samplingPlan.SampleMatrixDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleMatrixEnum), (int?)samplingPlan.SampleMatrixDefault);
                if (samplingPlan.SampleMatrixDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanSampleMatrixDefault"), new[] { "SampleMatrixDefault" });
                }
            }

            if (samplingPlan.LaboratoryDefault != null)
            {
                retStr = enums.EnumTypeOK(typeof(LaboratoryEnum), (int?)samplingPlan.LaboratoryDefault);
                if (samplingPlan.LaboratoryDefault == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanLaboratoryDefault"), new[] { "LaboratoryDefault" });
                }
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.BackupDirectory))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanBackupDirectory"), new[] { "BackupDirectory" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.BackupDirectory) && samplingPlan.BackupDirectory.Length > 250)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "SamplingPlanBackupDirectory", "250"), new[] { "BackupDirectory" });
            }

            if (samplingPlan.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlan.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "SamplingPlanLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SamplingPlanLastUpdateContactTVItemID", samplingPlan.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SamplingPlanLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public SamplingPlan GetSamplingPlanWithSamplingPlanID(int SamplingPlanID)
        {
            return (from c in db.SamplingPlans
                    where c.SamplingPlanID == SamplingPlanID
                    select c).FirstOrDefault();

        }
        public IQueryable<SamplingPlan> GetSamplingPlanList()
        {
            IQueryable<SamplingPlan> SamplingPlanQuery = (from c in db.SamplingPlans select c);

            SamplingPlanQuery = EnhanceQueryStatements<SamplingPlan>(SamplingPlanQuery) as IQueryable<SamplingPlan>;

            return SamplingPlanQuery;
        }
        public SamplingPlanExtraA GetSamplingPlanExtraAWithSamplingPlanID(int SamplingPlanID)
        {
            return FillSamplingPlanExtraA().Where(c => c.SamplingPlanID == SamplingPlanID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanExtraA> GetSamplingPlanExtraAList()
        {
            IQueryable<SamplingPlanExtraA> SamplingPlanExtraAQuery = FillSamplingPlanExtraA();

            SamplingPlanExtraAQuery = EnhanceQueryStatements<SamplingPlanExtraA>(SamplingPlanExtraAQuery) as IQueryable<SamplingPlanExtraA>;

            return SamplingPlanExtraAQuery;
        }
        public SamplingPlanExtraB GetSamplingPlanExtraBWithSamplingPlanID(int SamplingPlanID)
        {
            return FillSamplingPlanExtraB().Where(c => c.SamplingPlanID == SamplingPlanID).FirstOrDefault();

        }
        public IQueryable<SamplingPlanExtraB> GetSamplingPlanExtraBList()
        {
            IQueryable<SamplingPlanExtraB> SamplingPlanExtraBQuery = FillSamplingPlanExtraB();

            SamplingPlanExtraBQuery = EnhanceQueryStatements<SamplingPlanExtraB>(SamplingPlanExtraBQuery) as IQueryable<SamplingPlanExtraB>;

            return SamplingPlanExtraBQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(SamplingPlan samplingPlan)
        {
            samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Create);
            if (samplingPlan.ValidationResults.Count() > 0) return false;

            db.SamplingPlans.Add(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        public bool Delete(SamplingPlan samplingPlan)
        {
            samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Delete);
            if (samplingPlan.ValidationResults.Count() > 0) return false;

            db.SamplingPlans.Remove(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        public bool Update(SamplingPlan samplingPlan)
        {
            samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Update);
            if (samplingPlan.ValidationResults.Count() > 0) return false;

            db.SamplingPlans.Update(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
        private bool TryToSave(SamplingPlan samplingPlan)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlan.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
