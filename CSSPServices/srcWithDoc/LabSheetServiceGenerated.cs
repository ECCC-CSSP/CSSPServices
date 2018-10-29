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
    ///     <para>bonjour LabSheet</para>
    /// </summary>
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
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetLabSheetID"), new[] { "LabSheetID" });
                }

                if (!(from c in db.LabSheets select c).Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheet", "LabSheetLabSheetID", labSheet.LabSheetID.ToString()), new[] { "LabSheetID" });
                }
            }

            if (labSheet.OtherServerLabSheetID < 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "LabSheetOtherServerLabSheetID", "1"), new[] { "OtherServerLabSheetID" });
            }

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "SamplingPlan", "LabSheetSamplingPlanID", labSheet.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            if (string.IsNullOrWhiteSpace(labSheet.SamplingPlanName))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetSamplingPlanName"), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanName) && (labSheet.SamplingPlanName.Length < 1 || labSheet.SamplingPlanName.Length > 250))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetSamplingPlanName", "1", "250"), new[] { "SamplingPlanName" });
            }

            if (labSheet.Year < 1980)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "LabSheetYear", "1980"), new[] { "Year" });
            }

            if (labSheet.Month < 1 || labSheet.Month > 12)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetMonth", "1", "12"), new[] { "Month" });
            }

            if (labSheet.Day < 1 || labSheet.Day > 31)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetDay", "1", "31"), new[] { "Day" });
            }

            if (labSheet.RunNumber < 1 || labSheet.RunNumber > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetRunNumber", "1", "100"), new[] { "RunNumber" });
            }

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetSubsectorTVItemID", labSheet.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetSubsectorTVItemID", "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (labSheet.MWQMRunTVItemID != null)
            {
                TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).FirstOrDefault();

                if (TVItemMWQMRunTVItemID == null)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetMWQMRunTVItemID", (labSheet.MWQMRunTVItemID == null ? "" : labSheet.MWQMRunTVItemID.ToString())), new[] { "MWQMRunTVItemID" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetMWQMRunTVItemID", "MWQMRun"), new[] { "MWQMRunTVItemID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)labSheet.SamplingPlanType);
            if (labSheet.SamplingPlanType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetSamplingPlanType"), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheet.SampleType);
            if (labSheet.SampleType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetSampleType"), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)labSheet.LabSheetType);
            if (labSheet.LabSheetType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetLabSheetType"), new[] { "LabSheetType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetStatusEnum), (int?)labSheet.LabSheetStatus);
            if (labSheet.LabSheetStatus == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetLabSheetStatus"), new[] { "LabSheetStatus" });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileName))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetFileName"), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.FileName) && (labSheet.FileName.Length < 1 || labSheet.FileName.Length > 250))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "LabSheetFileName", "1", "250"), new[] { "FileName" });
            }

            if (labSheet.FileLastModifiedDate_Local.Year == 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetFileLastModifiedDate_Local"), new[] { "FileLastModifiedDate_Local" });
            }
            else
            {
                if (labSheet.FileLastModifiedDate_Local.Year < 1980)
                {
                labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetFileLastModifiedDate_Local", "1980"), new[] { "FileLastModifiedDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileContent))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetFileContent"), new[] { "FileContent" });
            }

            //FileContent has no StringLength Attribute

            if (labSheet.AcceptedOrRejectedByContactTVItemID != null)
            {
                TVItem TVItemAcceptedOrRejectedByContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).FirstOrDefault();

                if (TVItemAcceptedOrRejectedByContactTVItemID == null)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetAcceptedOrRejectedByContactTVItemID", (labSheet.AcceptedOrRejectedByContactTVItemID == null ? "" : labSheet.AcceptedOrRejectedByContactTVItemID.ToString())), new[] { "AcceptedOrRejectedByContactTVItemID" });
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
                        yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetAcceptedOrRejectedByContactTVItemID", "Contact"), new[] { "AcceptedOrRejectedByContactTVItemID" });
                    }
                }
            }

            if (labSheet.AcceptedOrRejectedDateTime != null && ((DateTime)labSheet.AcceptedOrRejectedDateTime).Year < 1980)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetAcceptedOrRejectedDateTime", "1980"), new[] { "LabSheetAcceptedOrRejectedDateTime" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.RejectReason) && labSheet.RejectReason.Length > 250)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetRejectReason", "250"), new[] { "RejectReason" });
            }

            if (labSheet.LastUpdateDate_UTC.Year == 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheet.LastUpdateDate_UTC.Year < 1980)
                {
                labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetLastUpdateContactTVItemID", labSheet.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public LabSheetExtraA GetLabSheetExtraAWithLabSheetID(int LabSheetID)
        {
            return FillLabSheetExtraA().Where(c => c.LabSheetID == LabSheetID).FirstOrDefault();

        }
        public IQueryable<LabSheetExtraA> GetLabSheetExtraAList()
        {
            IQueryable<LabSheetExtraA> LabSheetExtraAQuery = FillLabSheetExtraA();

            LabSheetExtraAQuery = EnhanceQueryStatements<LabSheetExtraA>(LabSheetExtraAQuery) as IQueryable<LabSheetExtraA>;

            return LabSheetExtraAQuery;
        }
        public LabSheetExtraB GetLabSheetExtraBWithLabSheetID(int LabSheetID)
        {
            return FillLabSheetExtraB().Where(c => c.LabSheetID == LabSheetID).FirstOrDefault();

        }
        public IQueryable<LabSheetExtraB> GetLabSheetExtraBList()
        {
            IQueryable<LabSheetExtraB> LabSheetExtraBQuery = FillLabSheetExtraB();

            LabSheetExtraBQuery = EnhanceQueryStatements<LabSheetExtraB>(LabSheetExtraBQuery) as IQueryable<LabSheetExtraB>;

            return LabSheetExtraBQuery;
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
