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
            labSheet.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheet.LabSheetID == 0)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetID), new[] { "LabSheetID" });
                }

                if (!GetRead().Where(c => c.LabSheetID == labSheet.LabSheetID).Any())
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheet, ModelsRes.LabSheetLabSheetID, labSheet.LabSheetID.ToString()), new[] { "LabSheetID" });
                }
            }

            //LabSheetID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //OtherServerLabSheetID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.OtherServerLabSheetID < 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetOtherServerLabSheetID, "1"), new[] { "OtherServerLabSheetID" });
            }

            //SamplingPlanID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            SamplingPlan SamplingPlanSamplingPlanID = (from c in db.SamplingPlans where c.SamplingPlanID == labSheet.SamplingPlanID select c).FirstOrDefault();

            if (SamplingPlanSamplingPlanID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.SamplingPlan, ModelsRes.LabSheetSamplingPlanID, labSheet.SamplingPlanID.ToString()), new[] { "SamplingPlanID" });
            }

            if (string.IsNullOrWhiteSpace(labSheet.SamplingPlanName))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanName), new[] { "SamplingPlanName" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanName) && (labSheet.SamplingPlanName.Length < 1 || labSheet.SamplingPlanName.Length > 250))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetSamplingPlanName, "1", "250"), new[] { "SamplingPlanName" });
            }

            //Year (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.Year < 1980)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.LabSheetYear, "1980"), new[] { "Year" });
            }

            //Month (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.Month < 1 || labSheet.Month > 12)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetMonth, "1", "12"), new[] { "Month" });
            }

            //Day (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.Day < 1 || labSheet.Day > 31)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetDay, "1", "31"), new[] { "Day" });
            }

            //RunNumber (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheet.RunNumber < 1 || labSheet.RunNumber > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetRunNumber, "1", "100"), new[] { "RunNumber" });
            }

            //SubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.SubsectorTVItemID select c).FirstOrDefault();

            if (TVItemSubsectorTVItemID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetSubsectorTVItemID, labSheet.SubsectorTVItemID.ToString()), new[] { "SubsectorTVItemID" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetSubsectorTVItemID, "Subsector"), new[] { "SubsectorTVItemID" });
                }
            }

            if (labSheet.MWQMRunTVItemID != null)
            {
                TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.MWQMRunTVItemID select c).FirstOrDefault();

                if (TVItemMWQMRunTVItemID == null)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetMWQMRunTVItemID, labSheet.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
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
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetMWQMRunTVItemID, "MWQMRun"), new[] { "MWQMRunTVItemID" });
                    }
                }
            }

            retStr = enums.EnumTypeOK(typeof(SamplingPlanTypeEnum), (int?)labSheet.SamplingPlanType);
            if (labSheet.SamplingPlanType == SamplingPlanTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSamplingPlanType), new[] { "SamplingPlanType" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheet.SampleType);
            if (labSheet.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetSampleType), new[] { "SampleType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetTypeEnum), (int?)labSheet.LabSheetType);
            if (labSheet.LabSheetType == LabSheetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetType), new[] { "LabSheetType" });
            }

            retStr = enums.EnumTypeOK(typeof(LabSheetStatusEnum), (int?)labSheet.LabSheetStatus);
            if (labSheet.LabSheetStatus == LabSheetStatusEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLabSheetStatus), new[] { "LabSheetStatus" });
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileName))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileName), new[] { "FileName" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.FileName) && (labSheet.FileName.Length < 1 || labSheet.FileName.Length > 250))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.LabSheetFileName, "1", "250"), new[] { "FileName" });
            }

            if (labSheet.FileLastModifiedDate_Local.Year == 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileLastModifiedDate_Local), new[] { "FileLastModifiedDate_Local" });
            }
            else
            {
                if (labSheet.FileLastModifiedDate_Local.Year < 1980)
                {
                labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetFileLastModifiedDate_Local, "1980"), new[] { "FileLastModifiedDate_Local" });
                }
            }

            if (string.IsNullOrWhiteSpace(labSheet.FileContent))
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetFileContent), new[] { "FileContent" });
            }

            //FileContent has no StringLength Attribute

            if (labSheet.AcceptedOrRejectedByContactTVItemID != null)
            {
                TVItem TVItemAcceptedOrRejectedByContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.AcceptedOrRejectedByContactTVItemID select c).FirstOrDefault();

                if (TVItemAcceptedOrRejectedByContactTVItemID == null)
                {
                    labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, labSheet.AcceptedOrRejectedByContactTVItemID.ToString()), new[] { "AcceptedOrRejectedByContactTVItemID" });
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
                        yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVItemID, "Contact"), new[] { "AcceptedOrRejectedByContactTVItemID" });
                    }
                }
            }

            if (labSheet.AcceptedOrRejectedDateTime != null && ((DateTime)labSheet.AcceptedOrRejectedDateTime).Year < 1980)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetAcceptedOrRejectedDateTime, "1980"), new[] { ModelsRes.LabSheetAcceptedOrRejectedDateTime });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.RejectReason) && labSheet.RejectReason.Length > 250)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetRejectReason, "250"), new[] { "RejectReason" });
            }

            if (labSheet.LastUpdateDate_UTC.Year == 1)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheet.LastUpdateDate_UTC.Year < 1980)
                {
                labSheet.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheet.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetLastUpdateContactTVItemID, labSheet.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SubsectorTVText) && labSheet.SubsectorTVText.Length > 200)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetSubsectorTVText, "200"), new[] { "SubsectorTVText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.MWQMRunTVText) && labSheet.MWQMRunTVText.Length > 200)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetMWQMRunTVText, "200"), new[] { "MWQMRunTVText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.AcceptedOrRejectedByContactTVText) && labSheet.AcceptedOrRejectedByContactTVText.Length > 200)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetAcceptedOrRejectedByContactTVText, "200"), new[] { "AcceptedOrRejectedByContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.LastUpdateContactTVText) && labSheet.LastUpdateContactTVText.Length > 200)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SamplingPlanTypeText) && labSheet.SamplingPlanTypeText.Length > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetSamplingPlanTypeText, "100"), new[] { "SamplingPlanTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.SampleTypeText) && labSheet.SampleTypeText.Length > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetSampleTypeText, "100"), new[] { "SampleTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.LabSheetTypeText) && labSheet.LabSheetTypeText.Length > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetLabSheetTypeText, "100"), new[] { "LabSheetTypeText" });
            }

            if (!string.IsNullOrWhiteSpace(labSheet.LabSheetStatusText) && labSheet.LabSheetStatusText.Length > 100)
            {
                labSheet.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetLabSheetStatusText, "100"), new[] { "LabSheetStatusText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
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
            IQueryable<LabSheet> labSheetQuery = (from c in GetRead()
                                                where c.LabSheetID == LabSheetID
                                                select c);

            return FillLabSheet(labSheetQuery).FirstOrDefault();
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
        public IQueryable<LabSheet> GetRead()
        {
            return db.LabSheets.AsNoTracking();
        }
        public IQueryable<LabSheet> GetEdit()
        {
            return db.LabSheets;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<LabSheet> FillLabSheet(IQueryable<LabSheet> labSheetQuery)
        {
            List<LabSheet> LabSheetList = (from c in labSheetQuery
                                         let SubsectorTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.SubsectorTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let MWQMRunTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.MWQMRunTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let AcceptedOrRejectedByContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.AcceptedOrRejectedByContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new LabSheet
                                         {
                                             LabSheetID = c.LabSheetID,
                                             OtherServerLabSheetID = c.OtherServerLabSheetID,
                                             SamplingPlanID = c.SamplingPlanID,
                                             SamplingPlanName = c.SamplingPlanName,
                                             Year = c.Year,
                                             Month = c.Month,
                                             Day = c.Day,
                                             RunNumber = c.RunNumber,
                                             SubsectorTVItemID = c.SubsectorTVItemID,
                                             MWQMRunTVItemID = c.MWQMRunTVItemID,
                                             SamplingPlanType = c.SamplingPlanType,
                                             SampleType = c.SampleType,
                                             LabSheetType = c.LabSheetType,
                                             LabSheetStatus = c.LabSheetStatus,
                                             FileName = c.FileName,
                                             FileLastModifiedDate_Local = c.FileLastModifiedDate_Local,
                                             FileContent = c.FileContent,
                                             AcceptedOrRejectedByContactTVItemID = c.AcceptedOrRejectedByContactTVItemID,
                                             AcceptedOrRejectedDateTime = c.AcceptedOrRejectedDateTime,
                                             RejectReason = c.RejectReason,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             SubsectorTVText = SubsectorTVText,
                                             MWQMRunTVText = MWQMRunTVText,
                                             AcceptedOrRejectedByContactTVText = AcceptedOrRejectedByContactTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (LabSheet labSheet in LabSheetList)
            {
                labSheet.SamplingPlanTypeText = enums.GetResValueForTypeAndID(typeof(SamplingPlanTypeEnum), (int?)labSheet.SamplingPlanType);
                labSheet.SampleTypeText = enums.GetResValueForTypeAndID(typeof(SampleTypeEnum), (int?)labSheet.SampleType);
                labSheet.LabSheetTypeText = enums.GetResValueForTypeAndID(typeof(LabSheetTypeEnum), (int?)labSheet.LabSheetType);
                labSheet.LabSheetStatusText = enums.GetResValueForTypeAndID(typeof(LabSheetStatusEnum), (int?)labSheet.LabSheetStatus);
            }

            return LabSheetList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
