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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public LabSheetService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheet labSheet = validationContext.ObjectInstance as LabSheet;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (labSheet.LabSheetID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetID), new[] { ModelsRes.LabSheetLabSheetID });
                }
            }

            //OtherServerLabSheetID (int) is required but no testing needed as it is automatically set to 0

            //SamplingPlanID (int) is required but no testing needed as it is automatically set to 0

            if (string.IsNullOrWhiteSpace(labSheet.SamplingPlanName))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanName), new[] { ModelsRes.LabSheetSamplingPlanName });
            }

            //Year (int) is required but no testing needed as it is automatically set to 0

            //Month (int) is required but no testing needed as it is automatically set to 0

            //Day (int) is required but no testing needed as it is automatically set to 0

            //RunNumber (int) is required but no testing needed as it is automatically set to 0

            //SubsectorTVItemID (int) is required but no testing needed as it is automatically set to 0

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

            if (labSheet.FileLastModifiedDate_Local == null || labSheet.FileLastModifiedDate_Local.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileLastModifiedDate_Local), new[] { ModelsRes.LabSheetFileLastModifiedDate_Local });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileContent))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileContent), new[] { ModelsRes.LabSheetFileContent });
            }

            if (labSheet.LastUpdateDate_UTC == null || labSheet.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLastUpdateDate_UTC), new[] { ModelsRes.LabSheetLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (labSheet.OtherServerLabSheetID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetOtherServerLabSheetID, "1"), new[] { ModelsRes.LabSheetOtherServerLabSheetID });
            }

            if (labSheet.SamplingPlanID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSamplingPlanID, "1"), new[] { ModelsRes.LabSheetSamplingPlanID });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanName) && labSheet.SamplingPlanName.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetSamplingPlanName, "250"), new[] { ModelsRes.LabSheetSamplingPlanName });
            }

            if (labSheet.Year < 1980 || labSheet.Year > 2050)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetYear, "1980", "2050"), new[] { ModelsRes.LabSheetYear });
            }

            if (labSheet.Month < 1 || labSheet.Month > 12)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12"), new[] { ModelsRes.LabSheetMonth });
            }

            if (labSheet.Day < 1 || labSheet.Day > 31)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31"), new[] { ModelsRes.LabSheetDay });
            }

            if (labSheet.RunNumber < 1 || labSheet.RunNumber > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "1000"), new[] { ModelsRes.LabSheetRunNumber });
            }

            if (labSheet.SubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetSubsectorTVItemID, "1"), new[] { ModelsRes.LabSheetSubsectorTVItemID });
            }

            if (labSheet.MWQMRunTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetMWQMRunTVItemID, "1"), new[] { ModelsRes.LabSheetMWQMRunTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.FileName) && labSheet.FileName.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetFileName, "250"), new[] { ModelsRes.LabSheetFileName });
            }

            // FileContent has no validation

            if (labSheet.AcceptedOrRejectedByContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "1"), new[] { ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID });
            }

            // RejectReason has no validation

            if (labSheet.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetLastUpdateContactTVItemID, "1"), new[] { ModelsRes.LabSheetLastUpdateContactTVItemID });
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
