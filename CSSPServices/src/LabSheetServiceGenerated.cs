/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

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
        public LabSheetService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheet labSheet = validationContext.ObjectInstance as LabSheet;
            labSheet.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheet.LabSheetID == 0)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetID"), new[] { "LabSheetID" });
                }

                if (!(from c in db.LabSheets select c).Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetID", labSheet.LabSheetID.ToString()), new[] { "LabSheetID" });
                }
            }

            if (labSheet.OtherServerLabSheetID < 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "OtherServerLabSheetID", "1"), new[] { "OtherServerLabSheetID" });
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "SamplingPlanID", labSheet.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            if (string.IsNullOrWhiteSpace(labSheet.SamplingPlanName))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanName"), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanName) && (labSheet.SamplingPlanName.Length < 1 || labSheet.SamplingPlanName.Length > 250))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "SamplingPlanName", "1", "250"), new[] { "SamplingPlanName" });
            }

            if (labSheet.Year < 1980)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "Year", "1980"), new[] { "Year" });
            }

            if (labSheet.Month < 1 || labSheet.Month > 12)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Month", "1", "12"), new[] { "Month" });
            }

            if (labSheet.Day < 1 || labSheet.Day > 31)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "Day", "1", "31"), new[] { "Day" });
            }

            if (labSheet.RunNumber < 1 || labSheet.RunNumber > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "RunNumber", "1", "100"), new[] { "RunNumber" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "SubsectorTVItemID", labSheet.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemSubsectorTVItemID.TVType))
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "SubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (labSheet.MWQMRunTVItemID != null)
            {
                TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).FirstOrDefault();

                if (TVItemMWQMRunTVItemID == null)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "MWQMRunTVItemID", (labSheet.MWQMRunTVItemID == null ? "" : labSheet.MWQMRunTVItemID.ToString())), new[] { "MWQMRunTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.MWQMRun,
                    };
                    if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                    {
                        labSheet.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "MWQMRunTVItemID", "MWQMRun"), new[] { "MWQMRunTVItemID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)labSheet.SamplingPlanType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SamplingPlanType"), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheet.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "SampleType"), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)labSheet.LabSheetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetType"), new[] { "LabSheetType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetStatusEnum), (int?)labSheet.LabSheetStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetStatus"), new[] { "LabSheetStatus" });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileName))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileName"), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.FileName) && (labSheet.FileName.Length < 1 || labSheet.FileName.Length > 250))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "FileName", "1", "250"), new[] { "FileName" });
            }

            if (labSheet.FileLastModifiedDate_Local.Year == 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileLastModifiedDate_Local"), new[] { "FileLastModifiedDate_Local" });
            }
            else
            {
                if (labSheet.FileLastModifiedDate_Local.Year < 1980)
                {
                labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "FileLastModifiedDate_Local", "1980"), new[] { "FileLastModifiedDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileContent))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "FileContent"), new[] { "FileContent" });
            }

            //FileContent has no StringLength Attribute

            if (labSheet.AcceptedOrRejectedByContactTVItemID != null)
            {
                TVItem TVItemAcceptedOrRejectedByContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).FirstOrDefault();

                if (TVItemAcceptedOrRejectedByContactTVItemID == null)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AcceptedOrRejectedByContactTVItemID", (labSheet.AcceptedOrRejectedByContactTVItemID == null ? "" : labSheet.AcceptedOrRejectedByContactTVItemID.ToString())), new[] { "AcceptedOrRejectedByContactTVItemID" });
                }
                else
                {
                    List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                    {
                        TVTypeEnum.Contact,
                    };
                    if (!AllowableTVTypes.Contains(TVItemAcceptedOrRejectedByContactTVItemID.TVType))
                    {
                        labSheet.HasErrors = true;
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AcceptedOrRejectedByContactTVItemID", "Contact"), new[] { "AcceptedOrRejectedByContactTVItemID" });
                    }
                }
            }

            if (labSheet.AcceptedOrRejectedDateTime != null && ((DateTime)labSheet.AcceptedOrRejectedDateTime).Year < 1980)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AcceptedOrRejectedDateTime", "1980"), new[] { "AcceptedOrRejectedDateTime" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.RejectReason) && labSheet.RejectReason.Length > 250)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "RejectReason", "250"), new[] { "RejectReason" });
            }

            if (labSheet.LastUpdateDate_UTC.Year == 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheet.LastUpdateDate_UTC.Year < 1980)
                {
                labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LastUpdateContactTVItemID", labSheet.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public LabSheet GetLabSheetWithLabSheetID(int LabSheetID)
        {
            return (from c in db.LabSheets
                    where c.LabSheetID == LabSheetID
                    select c).FirstOrDefault();

        }
        public IQueryable<LabSheet> GetLabSheetList()
        {
            IQueryable<LabSheet> LabSheetQuery = (from c in db.LabSheets select c);

            LabSheetQuery = EnhanceQueryStatements<LabSheet>(LabSheetQuery) as IQueryable<LabSheet>;

            return LabSheetQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(LabSheet labSheet)
        {
            labSheet.ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Create);
            if (labSheet.ValidationResults.Count() > 0) return false;

            db.LabSheets.Add(labSheet);

            if (!TryToSave(labSheet)) return false;

            return true;
        }
        public bool Delete(LabSheet labSheet)
        {
            labSheet.ValidationResults = Validate(new ValidationContext(labSheet), ActionDBTypeEnum.Delete);
            if (labSheet.ValidationResults.Count() > 0) return false;

            db.LabSheets.Remove(labSheet);

            if (!TryToSave(labSheet)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
