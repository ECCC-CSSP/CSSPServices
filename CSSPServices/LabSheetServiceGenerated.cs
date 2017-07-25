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
    public partial class LabSheetService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheet labSheet = validationContext.ObjectInstance as LabSheet;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (labSheet.LabSheetID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetID), new[] { ModelsRes.LabSheetLabSheetID });
                }
            }

            //LabSheetID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //OtherServerLabSheetID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.OtherServerLabSheetID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetOtherServerLabSheetID, "1"), new[] { ModelsRes.LabSheetOtherServerLabSheetID });
            }

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.SamplingPlanID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSamplingPlanID, "1"), new[] { ModelsRes.LabSheetSamplingPlanID });
            }

            if (!((from c in db.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.LabSheetSamplingPlanID, labSheet.SamplingPlanID.ToString()), new[] { ModelsRes.LabSheetSamplingPlanID });
            }

            if (string.IsNullOrWhiteSpace(labSheet.SamplingPlanName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanName), new[] { ModelsRes.LabSheetSamplingPlanName });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanName) && (labSheet.SamplingPlanName.Length < 1 || labSheet.SamplingPlanName.Length > 250))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetSamplingPlanName, "1", "250"), new[] { ModelsRes.LabSheetSamplingPlanName });
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetYear, "1980"), new[] { ModelsRes.LabSheetYear });
            }

            //Month (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.Month < 1 || labSheet.Month > 12)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12"), new[] { ModelsRes.LabSheetMonth });
            }

            //Day (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.Day < 1 || labSheet.Day > 31)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31"), new[] { ModelsRes.LabSheetDay });
            }

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.RunNumber < 1 || labSheet.RunNumber > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100"), new[] { ModelsRes.LabSheetRunNumber });
            }

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSubsectorTVItemID, "1"), new[] { ModelsRes.LabSheetSubsectorTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetSubsectorTVItemID, labSheet.SubsectorTVItemID.ToString()), new[] { ModelsRes.LabSheetSubsectorTVItemID });
            }

            if (labSheet.MWQMRunTVItemID != null)
            {
                if (labSheet.MWQMRunTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetMWQMRunTVItemID, "1"), new[] { ModelsRes.LabSheetMWQMRunTVItemID });
                }
            }

            if (labSheet.MWQMRunTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetMWQMRunTVItemID, labSheet.MWQMRunTVItemID.ToString()), new[] { ModelsRes.LabSheetMWQMRunTVItemID });
                }
            }

            retStr = enums.SamplingPlanTypeOK(labSheet.SamplingPlanType);
            if (labSheet.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanType), new[] { ModelsRes.LabSheetSamplingPlanType });
            }

            retStr = enums.SampleTypeOK(labSheet.SampleType);
            if (labSheet.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSampleType), new[] { ModelsRes.LabSheetSampleType });
            }

            retStr = enums.LabSheetTypeOK(labSheet.LabSheetType);
            if (labSheet.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetType), new[] { ModelsRes.LabSheetLabSheetType });
            }

            retStr = enums.LabSheetStatusOK(labSheet.LabSheetStatus);
            if (labSheet.LabSheetStatus == LabSheetStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetStatus), new[] { ModelsRes.LabSheetLabSheetStatus });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileName), new[] { ModelsRes.LabSheetFileName });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.FileName) && (labSheet.FileName.Length < 1 || labSheet.FileName.Length > 250))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetFileName, "1", "250"), new[] { ModelsRes.LabSheetFileName });
            }

            if (labSheet.FileLastModifiedDate_Local == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileLastModifiedDate_Local), new[] { ModelsRes.LabSheetFileLastModifiedDate_Local });
            }

            if (labSheet.FileLastModifiedDate_Local.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetFileLastModifiedDate_Local, "1980"), new[] { ModelsRes.LabSheetFileLastModifiedDate_Local });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileContent))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileContent), new[] { ModelsRes.LabSheetFileContent });
            }

            //FileContent has no StringLength Attribute

            if (labSheet.AcceptedOrRejectedByContactTVItemID != null)
            {
                if (labSheet.AcceptedOrRejectedByContactTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "1"), new[] { ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID });
                }
            }

            if (labSheet.AcceptedOrRejectedByContactTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, labSheet.AcceptedOrRejectedByContactTVItemID.ToString()), new[] { ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID });
                }
            }

            if (labSheet.AcceptedOrRejectedDateTime != null && ((DateTime)labSheet.AcceptedOrRejectedDateTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetAcceptedOrRejectedDateTime, "1980"), new[] { ModelsRes.LabSheetAcceptedOrRejectedDateTime });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.RejectReason) && labSheet.RejectReason.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetRejectReason, "250"), new[] { ModelsRes.LabSheetRejectReason });
            }

            if (labSheet.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLastUpdateDate_UTC), new[] { ModelsRes.LabSheetLastUpdateDate_UTC });
            }

            if (labSheet.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetLastUpdateDate_UTC, "1980"), new[] { ModelsRes.LabSheetLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetLastUpdateContactTVItemID, "1"), new[] { ModelsRes.LabSheetLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetLastUpdateContactTVItemID, labSheet.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.LabSheetLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(LabSheet labSheet)
        {
            labSheet.ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Create);
            if (labSheet.ValidationResults.Count() > 0) return false;

            db.LabSheets.Add(labSheet);

            if (!TryToSave(labSheet)) return false;

            return true;
        }
        public bool AddRange(List<LabSheet> labSheetList)
        {
            foreach (LabSheet labSheet in labSheetList)
            {
                labSheet.ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Create);
                if (labSheet.ValidationResults.Count() > 0) return false;
            }

            db.LabSheets.AddRange(labSheetList);

            if (!TryToSaveRange(labSheetList)) return false;

            return true;
        }
        public bool Delete(LabSheet labSheet)
        {
            if (!db.LabSheets.Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
            {
                labSheet.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", labSheet.LabSheetID.ToString())) }.AsEnumerable();
                return false;
            }

            db.LabSheets.Remove(labSheet);

            if (!TryToSave(labSheet)) return false;

            return true;
        }
        public bool DeleteRange(List<LabSheet> labSheetList)
        {
            foreach (LabSheet labSheet in labSheetList)
            {
                if (!db.LabSheets.Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
                {
                    labSheetList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", labSheet.LabSheetID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.LabSheets.RemoveRange(labSheetList);

            if (!TryToSaveRange(labSheetList)) return false;

            return true;
        }
        public bool Update(LabSheet labSheet)
        {
            labSheet.ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Update);
            if (labSheet.ValidationResults.Count() > 0) return false;

            db.LabSheets.Update(labSheet);

            if (!TryToSave(labSheet)) return false;

            return true;
        }
        public bool UpdateRange(List<LabSheet> labSheetList)
        {
            foreach (LabSheet labSheet in labSheetList)
            {
                labSheet.ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Update);
                if (labSheet.ValidationResults.Count() > 0) return false;
            }
            db.LabSheets.UpdateRange(labSheetList);

            if (!TryToSaveRange(labSheetList)) return false;

            return true;
        }
        public IQueryable<LabSheet> GetRead()
        {
            return db.LabSheets.AsNoTracking();
        }
        public IQueryable<LabSheet> GetEdit()
        {
            return db.LabSheets;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(LabSheet labSheet)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                labSheet.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<LabSheet> labSheetList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                labSheetList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
