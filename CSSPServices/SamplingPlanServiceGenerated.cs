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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (samplingPlan.SamplingPlanID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanID), new[] { "SamplingPlanID" });
                }
            }

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanName), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanName) && samplingPlan.SamplingPlanName.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanName, "200"), new[] { "SamplingPlanName" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.ForGroupName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanForGroupName), new[] { "ForGroupName" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ForGroupName) && samplingPlan.ForGroupName.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanForGroupName, "100"), new[] { "ForGroupName" });
            }

            retStr = enums.SampleTypeOK(samplingPlan.SampleType);
            if (samplingPlan.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSampleType), new[] { "SampleType" });
            }

            retStr = enums.SamplingPlanTypeOK(samplingPlan.SamplingPlanType);
            if (samplingPlan.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanSamplingPlanType), new[] { "SamplingPlanType" });
            }

            retStr = enums.LabSheetTypeOK(samplingPlan.LabSheetType);
            if (samplingPlan.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLabSheetType), new[] { "LabSheetType" });
            }

            //ProvinceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanProvinceTVItemID, samplingPlan.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanProvinceTVItemID, "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            //CreatorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemCreatorTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.CreatorTVItemID select c).FirstOrDefault();

            if (TVItemCreatorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanCreatorTVItemID, samplingPlan.CreatorTVItemID.ToString()), new[] { "CreatorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemCreatorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanCreatorTVItemID, "Contact"), new[] { "CreatorTVItemID" });
                }
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.Year < 2000 || samplingPlan.Year > 2050)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanYear, "2000", "2050"), new[] { "Year" });
            }

            if (string.IsNullOrWhiteSpace(samplingPlan.AccessCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanAccessCode), new[] { "AccessCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.AccessCode) && samplingPlan.AccessCode.Length > 15)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanAccessCode, "15"), new[] { "AccessCode" });
            }

            //DailyDuplicatePrecisionCriteria (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.DailyDuplicatePrecisionCriteria < 0 || samplingPlan.DailyDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanDailyDuplicatePrecisionCriteria, "0", "100"), new[] { "DailyDuplicatePrecisionCriteria" });
            }

            //IntertechDuplicatePrecisionCriteria (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (samplingPlan.IntertechDuplicatePrecisionCriteria < 0 || samplingPlan.IntertechDuplicatePrecisionCriteria > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SamplingPlanIntertechDuplicatePrecisionCriteria, "0", "100"), new[] { "IntertechDuplicatePrecisionCriteria" });
            }

            //IncludeLaboratoryQAQC (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanApprovalCode), new[] { "ApprovalCode" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.ApprovalCode) && samplingPlan.ApprovalCode.Length > 15)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanApprovalCode, "15"), new[] { "ApprovalCode" });
            }

            if (samplingPlan.SamplingPlanFileTVItemID != null)
            {
                TVItem TVItemSamplingPlanFileTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.SamplingPlanFileTVItemID select c).FirstOrDefault();

                if (TVItemSamplingPlanFileTVItemID == null)
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, samplingPlan.SamplingPlanFileTVItemID.ToString()), new[] { "SamplingPlanFileTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.File,
                    };
                    if (!AllowableTVTypes.Contains(TVItemSamplingPlanFileTVItemID.TVType))
                    {
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanSamplingPlanFileTVItemID, "File"), new[] { "SamplingPlanFileTVItemID" });
                    }
                }
            }

            if (samplingPlan.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.SamplingPlanLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (samplingPlan.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.SamplingPlanLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == samplingPlan.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SamplingPlanLastUpdateContactTVItemID, samplingPlan.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.SamplingPlanLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SampleTypeText) && samplingPlan.SampleTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSampleTypeText, "100"), new[] { "SampleTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.SamplingPlanTypeText) && samplingPlan.SamplingPlanTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanSamplingPlanTypeText, "100"), new[] { "SamplingPlanTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(samplingPlan.LabSheetTypeText) && samplingPlan.LabSheetTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.SamplingPlanLabSheetTypeText, "100"), new[] { "LabSheetTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
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
        public bool AddRange(List<SamplingPlan> samplingPlanList)
        {
            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Create);
                if (samplingPlan.ValidationResults.Count() > 0) return false;
            }

            db.SamplingPlans.AddRange(samplingPlanList);

            if (!TryToSaveRange(samplingPlanList)) return false;

            return true;
        }
        public bool Delete(SamplingPlan samplingPlan)
        {
            if (!db.SamplingPlans.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
            {
                samplingPlan.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlan.SamplingPlanID.ToString())) }.AsEnumerable();
                return false;
            }

            db.SamplingPlans.Remove(samplingPlan);

            if (!TryToSave(samplingPlan)) return false;

            return true;
        }
        public bool DeleteRange(List<SamplingPlan> samplingPlanList)
        {
            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                if (!db.SamplingPlans.Where(c => c.SamplingPlanID == samplingPlan.SamplingPlanID).Any())
                {
                    samplingPlanList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", samplingPlan.SamplingPlanID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.SamplingPlans.RemoveRange(samplingPlanList);

            if (!TryToSaveRange(samplingPlanList)) return false;

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
        public bool UpdateRange(List<SamplingPlan> samplingPlanList)
        {
            foreach (SamplingPlan samplingPlan in samplingPlanList)
            {
                samplingPlan.ValidationResults = Validate(new ValidationContext(samplingPlan), ActionDBTypeEnum.Update);
                if (samplingPlan.ValidationResults.Count() > 0) return false;
            }
            db.SamplingPlans.UpdateRange(samplingPlanList);

            if (!TryToSaveRange(samplingPlanList)) return false;

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
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (SamplingPlan samplingPlan in SamplingPlanList)
            {
                samplingPlan.SampleTypeText = enums.GetEnumText_SampleTypeEnum(samplingPlan.SampleType);
                samplingPlan.SamplingPlanTypeText = enums.GetEnumText_SamplingPlanTypeEnum(samplingPlan.SamplingPlanType);
                samplingPlan.LabSheetTypeText = enums.GetEnumText_LabSheetTypeEnum(samplingPlan.LabSheetType);
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
        private bool TryToSaveRange(List<SamplingPlan> samplingPlanList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                samplingPlanList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
