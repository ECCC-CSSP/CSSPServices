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
    public partial class LabSheetTubeMPNDetailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = validationContext.ObjectInstance as LabSheetTubeMPNDetail;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (labSheetTubeMPNDetail.LabSheetTubeMPNDetailID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID), new[] { "LabSheetTubeMPNDetailID" });
                }
            }

            //LabSheetTubeMPNDetailID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //LabSheetDetailID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            LabSheetDetail LabSheetDetailLabSheetDetailID = (from c in db.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();

            if (LabSheetDetailLabSheetDetailID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.LabSheetDetail, ModelsRes.LabSheetTubeMPNDetailLabSheetDetailID, labSheetTubeMPNDetail.LabSheetDetailID.ToString()), new[] { "LabSheetDetailID" });
            }

            //Ordinal (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (labSheetTubeMPNDetail.Ordinal < 0 || labSheetTubeMPNDetail.Ordinal > 1000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            //MWQMSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                if (TVItemMWQMSiteTVItemID.TVType != TVTypeEnum.MWQMSite)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (labSheetTubeMPNDetail.SampleDateTime != null && ((DateTime)labSheetTubeMPNDetail.SampleDateTime).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetTubeMPNDetailSampleDateTime, "1980"), new[] { ModelsRes.LabSheetTubeMPNDetailSampleDateTime });
            }

            if (labSheetTubeMPNDetail.MPN != null)
            {
                if (labSheetTubeMPNDetail.MPN < 1 || labSheetTubeMPNDetail.MPN > 10000000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000"), new[] { "MPN" });
                }
            }

            if (labSheetTubeMPNDetail.Tube10 != null)
            {
                if (labSheetTubeMPNDetail.Tube10 < 0 || labSheetTubeMPNDetail.Tube10 > 5)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube10, "0", "5"), new[] { "Tube10" });
                }
            }

            if (labSheetTubeMPNDetail.Tube1_0 != null)
            {
                if (labSheetTubeMPNDetail.Tube1_0 < 0 || labSheetTubeMPNDetail.Tube1_0 > 5)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5"), new[] { "Tube1_0" });
                }
            }

            if (labSheetTubeMPNDetail.Tube0_1 != null)
            {
                if (labSheetTubeMPNDetail.Tube0_1 < 0 || labSheetTubeMPNDetail.Tube0_1 > 5)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5"), new[] { "Tube0_1" });
                }
            }

            if (labSheetTubeMPNDetail.Salinity != null)
            {
                if (labSheetTubeMPNDetail.Salinity < 0 || labSheetTubeMPNDetail.Salinity > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40"), new[] { "Salinity" });
                }
            }

            if (labSheetTubeMPNDetail.Temperature != null)
            {
                if (labSheetTubeMPNDetail.Temperature < -10 || labSheetTubeMPNDetail.Temperature > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40"), new[] { "Temperature" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.ProcessedBy) && labSheetTubeMPNDetail.ProcessedBy.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailProcessedBy, "10"), new[] { "ProcessedBy" });
            }

            retStr = enums.SampleTypeOK(labSheetTubeMPNDetail.SampleType);
            if (labSheetTubeMPNDetail.SampleType == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailSampleType), new[] { "SampleType" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.SiteComment) && labSheetTubeMPNDetail.SiteComment.Length > 250)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.LabSheetTubeMPNDetailSiteComment, "250"), new[] { "SiteComment" });
            }

            if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            labSheetTubeMPNDetail.ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Create);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetail);

            if (!TryToSave(labSheetTubeMPNDetail)) return false;

            return true;
        }
        public bool AddRange(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList)
        {
            foreach (LabSheetTubeMPNDetail labSheetTubeMPNDetail in labSheetTubeMPNDetailList)
            {
                labSheetTubeMPNDetail.ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Create);
                if (labSheetTubeMPNDetail.ValidationResults.Count() > 0) return false;
            }

            db.LabSheetTubeMPNDetails.AddRange(labSheetTubeMPNDetailList);

            if (!TryToSaveRange(labSheetTubeMPNDetailList)) return false;

            return true;
        }
        public bool Delete(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            if (!db.LabSheetTubeMPNDetails.Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
            {
                labSheetTubeMPNDetail.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString())) }.AsEnumerable();
                return false;
            }

            db.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetail);

            if (!TryToSave(labSheetTubeMPNDetail)) return false;

            return true;
        }
        public bool DeleteRange(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList)
        {
            foreach (LabSheetTubeMPNDetail labSheetTubeMPNDetail in labSheetTubeMPNDetailList)
            {
                if (!db.LabSheetTubeMPNDetails.Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
                {
                    labSheetTubeMPNDetailList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.LabSheetTubeMPNDetails.RemoveRange(labSheetTubeMPNDetailList);

            if (!TryToSaveRange(labSheetTubeMPNDetailList)) return false;

            return true;
        }
        public bool Update(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            labSheetTubeMPNDetail.ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Update);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetTubeMPNDetails.Update(labSheetTubeMPNDetail);

            if (!TryToSave(labSheetTubeMPNDetail)) return false;

            return true;
        }
        public bool UpdateRange(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList)
        {
            foreach (LabSheetTubeMPNDetail labSheetTubeMPNDetail in labSheetTubeMPNDetailList)
            {
                labSheetTubeMPNDetail.ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Update);
                if (labSheetTubeMPNDetail.ValidationResults.Count() > 0) return false;
            }
            db.LabSheetTubeMPNDetails.UpdateRange(labSheetTubeMPNDetailList);

            if (!TryToSaveRange(labSheetTubeMPNDetailList)) return false;

            return true;
        }
        public IQueryable<LabSheetTubeMPNDetail> GetRead()
        {
            return db.LabSheetTubeMPNDetails.AsNoTracking();
        }
        public IQueryable<LabSheetTubeMPNDetail> GetEdit()
        {
            return db.LabSheetTubeMPNDetails;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                labSheetTubeMPNDetail.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<LabSheetTubeMPNDetail> labSheetTubeMPNDetailList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                labSheetTubeMPNDetailList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
