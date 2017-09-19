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
        public SamplingPlanService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSamplingPlanID), new[] { "SamplingPlanID" });
                }

                if (!GetRead().Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.SamplingPlan, CSSPModelsRes.SamplingPlanSamplingPlanID, samplingPlan.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
                }
            }

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSamplingPlanName), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName) && samplingPlan.SamplingPlanName.Length > 200)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanSamplingPlanName, "200"), new[] { "SamplingPlanName" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ForGroupName))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanForGroupName), new[] { "ForGroupName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ForGroupName) && samplingPlan.ForGroupName.Length > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanForGroupName, "100"), new[] { "ForGroupName" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)samplingPlan.SampleType);
            if (samplingPlan.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSampleType), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)samplingPlan.SamplingPlanType);
            if (samplingPlan.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanSamplingPlanType), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)samplingPlan.LabSheetType);
            if (samplingPlan.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanLabSheetType), new[] { "LabSheetType" });
            }

            //ProvinceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanProvinceTVItemID, samplingPlan.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanProvinceTVItemID, "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            //CreatorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemCreatorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.CreatorTVItemID select c).FirstOrDefault();

            if (TVItemCreatorTVItemID == null)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanCreatorTVItemID, samplingPlan.CreatorTVItemID.ToString()), new[] { "CreatorTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanCreatorTVItemID, "Contact"), new[] { "CreatorTVItemID" });
                }
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.Year < 2000 || samplingPlan.Year > 2050)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanYear, "2000", "2050"), new[] { "Year" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.AccessCode))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanAccessCode), new[] { "AccessCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.AccessCode) && samplingPlan.AccessCode.Length > 15)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanAccessCode, "15"), new[] { "AccessCode" });
            }

            //DailyDuplicatePrecisionCriteria (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.DailyDuplicatePrecisionCriteria < 0 || samplingPlan.DailyDuplicatePrecisionCriteria > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            //IntertechDuplicatePrecisionCriteria (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.IntertechDuplicatePrecisionCriteria < 0 || samplingPlan.IntertechDuplicatePrecisionCriteria > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode))
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanApprovalCode), new[] { "ApprovalCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode) && samplingPlan.ApprovalCode.Length > 15)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanApprovalCode, "15"), new[] { "ApprovalCode" });
            }

            if (samplingPlan.SamplingPlanFileTVItemID != null)
            {
                TVItem TVItemSamplingPlanFileTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.SamplingPlanFileTVItemID select c).FirstOrDefault();

                if (TVItemSamplingPlanFileTVItemID == null)
                {
                    samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanSamplingPlanFileTVItemID, samplingPlan.SamplingPlanFileTVItemID.ToString()), new[] { "SamplingPlanFileTVItemID" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanSamplingPlanFileTVItemID, "File"), new[] { "SamplingPlanFileTVItemID" });
                    }
                }
            }

            if (samplingPlan.LastUpdateDate_UTC.Year == 1)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.SamplingPlanLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlan.LastUpdateDate_UTC.Year < 1980)
                {
                samplingPlan.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.SamplingPlanLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.SamplingPlanLastUpdateContactTVItemID, samplingPlan.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.SamplingPlanLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ProvinceTVText) && samplingPlan.ProvinceTVText.Length > 200)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanProvinceTVText, "200"), new[] { "ProvinceTVText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.CreatorTVText) && samplingPlan.CreatorTVText.Length > 200)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanCreatorTVText, "200"), new[] { "CreatorTVText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanFileTVText) && samplingPlan.SamplingPlanFileTVText.Length > 200)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanSamplingPlanFileTVText, "200"), new[] { "SamplingPlanFileTVText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.LastUpdateContactTVText) && samplingPlan.LastUpdateContactTVText.Length > 200)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SampleTypeText) && samplingPlan.SampleTypeText.Length > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanSampleTypeText, "100"), new[] { "SampleTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanTypeText) && samplingPlan.SamplingPlanTypeText.Length > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanSamplingPlanTypeText, "100"), new[] { "SamplingPlanTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.LabSheetTypeText) && samplingPlan.LabSheetTypeText.Length > 100)
            {
                samplingPlan.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.SamplingPlanLabSheetTypeText, "100"), new[] { "LabSheetTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

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
            IQueryable<SamplingPlan> samplingPlanQuery = (from c in GetRead()
                                                where c.SamplingPlanID == SamplingPlanID
                                                select c);

            return FillSamplingPlan(samplingPlanQuery).FirstOrDefault();
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
        public IQueryable<SamplingPlan> GetRead()
        {
            return db.SamplingPlans.AsNoTracking();
        }
        public IQueryable<SamplingPlan> GetEdit()
        {
            return db.SamplingPlans;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<SamplingPlan> FillSamplingPlan(IQueryable<SamplingPlan> samplingPlanQuery)
        {
            List<SamplingPlan> SamplingPlanList = (from c in samplingPlanQuery
                                         let ProvinceTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.ProvinceTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let CreatorTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.CreatorTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let SamplingPlanFileTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.SamplingPlanFileTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new SamplingPlan
                                         {
                                             SamplingPlanID = c.SamplingPlanID,
                                             SamplingPlanName = c.SamplingPlanName,
                                             ForGroupName = c.ForGroupName,
                                             SampleType = c.SampleType,
                                             SamplingPlanType = c.SamplingPlanType,
                                             LabSheetType = c.LabSheetType,
                                             ProvinceTVItemID = c.ProvinceTVItemID,
                                             CreatorTVItemID = c.CreatorTVItemID,
                                             Year = c.Year,
                                             AccessCode = c.AccessCode,
                                             DailyDuplicatePrecisionCriteria = c.DailyDuplicatePrecisionCriteria,
                                             IntertechDuplicatePrecisionCriteria = c.IntertechDuplicatePrecisionCriteria,
                                             IncludeLaboratoryQAQC = c.IncludeLaboratoryQAQC,
                                             ApprovalCode = c.ApprovalCode,
                                             SamplingPlanFileTVItemID = c.SamplingPlanFileTVItemID,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ProvinceTVText = ProvinceTVText,
                                             CreatorTVText = CreatorTVText,
                                             SamplingPlanFileTVText = SamplingPlanFileTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (SamplingPlan samplingPlan in SamplingPlanList)
            {
                samplingPlan.SampleTypeText = enums.GetResValueForTypeAndID(typeof(SampleTypeEnum), (int?)samplingPlan.SampleType);
                samplingPlan.SamplingPlanTypeText = enums.GetResValueForTypeAndID(typeof(SamplingPlanTypeEnum), (int?)samplingPlan.SamplingPlanType);
                samplingPlan.LabSheetTypeText = enums.GetResValueForTypeAndID(typeof(LabSheetTypeEnum), (int?)samplingPlan.LabSheetType);
            }

            return SamplingPlanList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
