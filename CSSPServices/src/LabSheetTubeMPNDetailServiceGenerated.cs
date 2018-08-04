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
    ///     <para>bonjour LabSheetTubeMPNDetail</para>
    /// </summary>
    public partial class LabSheetTubeMPNDetailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = validationContext.ObjectInstance as LabSheetTubeMPNDetail;
            labSheetTubeMPNDetail.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (labSheetTubeMPNDetail.LabSheetTubeMPNDetailID == 0)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailLabSheetTubeMPNDetailID"), new[] { "LabSheetTubeMPNDetailID" });
                }

                if (!(from c in db.LabSheetTubeMPNDetails select c).Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetTubeMPNDetail", "LabSheetTubeMPNDetailLabSheetTubeMPNDetailID", labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), new[] { "LabSheetTubeMPNDetailID" });
                }
            }

            LabSheetDetail LabSheetDetailLabSheetDetailID = (from c in db.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();

            if (LabSheetDetailLabSheetDetailID == null)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "LabSheetDetail", "LabSheetTubeMPNDetailLabSheetDetailID", labSheetTubeMPNDetail.LabSheetDetailID.ToString()), new[] { "LabSheetDetailID" });
            }

            if (labSheetTubeMPNDetail.Ordinal < 0 || labSheetTubeMPNDetail.Ordinal > 1000)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailOrdinal", "0", "1000"), new[] { "Ordinal" });
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetTubeMPNDetailMWQMSiteTVItemID", labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetTubeMPNDetailMWQMSiteTVItemID", "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (labSheetTubeMPNDetail.SampleDateTime != null && ((DateTime)labSheetTubeMPNDetail.SampleDateTime).Year < 1980)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetTubeMPNDetailSampleDateTime", "1980"), new[] { "LabSheetTubeMPNDetailSampleDateTime" });
            }

            if (labSheetTubeMPNDetail.MPN != null)
            {
                if (labSheetTubeMPNDetail.MPN < 1 || labSheetTubeMPNDetail.MPN > 10000000)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailMPN", "1", "10000000"), new[] { "MPN" });
                }
            }

            if (labSheetTubeMPNDetail.Tube10 != null)
            {
                if (labSheetTubeMPNDetail.Tube10 < 0 || labSheetTubeMPNDetail.Tube10 > 5)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube10", "0", "5"), new[] { "Tube10" });
                }
            }

            if (labSheetTubeMPNDetail.Tube1_0 != null)
            {
                if (labSheetTubeMPNDetail.Tube1_0 < 0 || labSheetTubeMPNDetail.Tube1_0 > 5)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube1_0", "0", "5"), new[] { "Tube1_0" });
                }
            }

            if (labSheetTubeMPNDetail.Tube0_1 != null)
            {
                if (labSheetTubeMPNDetail.Tube0_1 < 0 || labSheetTubeMPNDetail.Tube0_1 > 5)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTube0_1", "0", "5"), new[] { "Tube0_1" });
                }
            }

            if (labSheetTubeMPNDetail.Salinity != null)
            {
                if (labSheetTubeMPNDetail.Salinity < 0 || labSheetTubeMPNDetail.Salinity > 40)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailSalinity", "0", "40"), new[] { "Salinity" });
                }
            }

            if (labSheetTubeMPNDetail.Temperature != null)
            {
                if (labSheetTubeMPNDetail.Temperature < -10 || labSheetTubeMPNDetail.Temperature > 40)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "LabSheetTubeMPNDetailTemperature", "-10", "40"), new[] { "Temperature" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.ProcessedBy) && labSheetTubeMPNDetail.ProcessedBy.Length > 10)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetTubeMPNDetailProcessedBy", "10"), new[] { "ProcessedBy" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetTubeMPNDetail.SampleType);
            if (labSheetTubeMPNDetail.SampleType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailSampleType"), new[] { "SampleType" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.SiteComment) && labSheetTubeMPNDetail.SiteComment.Length > 250)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "LabSheetTubeMPNDetailSiteComment", "250"), new[] { "SiteComment" });
            }

            if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year == 1)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "LabSheetTubeMPNDetailLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year < 1980)
                {
                labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "LabSheetTubeMPNDetailLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "LabSheetTubeMPNDetailLastUpdateContactTVItemID", labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "LabSheetTubeMPNDetailLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public LabSheetTubeMPNDetail GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID)
        {
            return (from c in db.LabSheetTubeMPNDetails
                    where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                    select c).FirstOrDefault();

        }
        public IQueryable<LabSheetTubeMPNDetail> GetLabSheetTubeMPNDetailList()
        {
            IQueryable<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailQuery = (from c in db.LabSheetTubeMPNDetails select c);

            LabSheetTubeMPNDetailQuery = EnhanceQueryStatements<LabSheetTubeMPNDetail>(LabSheetTubeMPNDetailQuery) as IQueryable<LabSheetTubeMPNDetail>;

            return LabSheetTubeMPNDetailQuery;
        }
        public LabSheetTubeMPNDetailWeb GetLabSheetTubeMPNDetailWebWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID)
        {
            return FillLabSheetTubeMPNDetailWeb().Where(c => c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID).FirstOrDefault();

        }
        public IQueryable<LabSheetTubeMPNDetailWeb> GetLabSheetTubeMPNDetailWebList()
        {
            IQueryable<LabSheetTubeMPNDetailWeb> LabSheetTubeMPNDetailWebQuery = FillLabSheetTubeMPNDetailWeb();

            LabSheetTubeMPNDetailWebQuery = EnhanceQueryStatements<LabSheetTubeMPNDetailWeb>(LabSheetTubeMPNDetailWebQuery) as IQueryable<LabSheetTubeMPNDetailWeb>;

            return LabSheetTubeMPNDetailWebQuery;
        }
        public LabSheetTubeMPNDetailReport GetLabSheetTubeMPNDetailReportWithLabSheetTubeMPNDetailID(int LabSheetTubeMPNDetailID)
        {
            return FillLabSheetTubeMPNDetailReport().Where(c => c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID).FirstOrDefault();

        }
        public IQueryable<LabSheetTubeMPNDetailReport> GetLabSheetTubeMPNDetailReportList()
        {
            IQueryable<LabSheetTubeMPNDetailReport> LabSheetTubeMPNDetailReportQuery = FillLabSheetTubeMPNDetailReport();

            LabSheetTubeMPNDetailReportQuery = EnhanceQueryStatements<LabSheetTubeMPNDetailReport>(LabSheetTubeMPNDetailReportQuery) as IQueryable<LabSheetTubeMPNDetailReport>;

            return LabSheetTubeMPNDetailReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            labSheetTubeMPNDetail.ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Create);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetail);

            if (!TryToSave(labSheetTubeMPNDetail)) return false;

            return true;
        }
        public bool Delete(LabSheetTubeMPNDetail labSheetTubeMPNDetail)
        {
            labSheetTubeMPNDetail.ValidationResults = Validate(new ValidationContext(labSheetTubeMPNDetail), ActionDBTypeEnum.Delete);
            if (labSheetTubeMPNDetail.ValidationResults.Count() > 0) return false;

            db.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetail);

            if (!TryToSave(labSheetTubeMPNDetail)) return false;

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
        #endregion Functions public Generated CRUD

        #region Functions private Generated LabSheetTubeMPNDetailFillWeb
        private IQueryable<LabSheetTubeMPNDetailWeb> FillLabSheetTubeMPNDetailWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

             IQueryable<LabSheetTubeMPNDetailWeb>  LabSheetTubeMPNDetailWebQuery = (from c in db.LabSheetTubeMPNDetails
                let MWQMSiteTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new LabSheetTubeMPNDetailWeb
                    {
                        MWQMSiteTVItemLanguage = MWQMSiteTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        SampleTypeText = (from e in SampleTypeEnumList
                                where e.EnumID == (int?)c.SampleType
                                select e.EnumText).FirstOrDefault(),
                        LabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailID,
                        LabSheetDetailID = c.LabSheetDetailID,
                        Ordinal = c.Ordinal,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        SampleDateTime = c.SampleDateTime,
                        MPN = c.MPN,
                        Tube10 = c.Tube10,
                        Tube1_0 = c.Tube1_0,
                        Tube0_1 = c.Tube0_1,
                        Salinity = c.Salinity,
                        Temperature = c.Temperature,
                        ProcessedBy = c.ProcessedBy,
                        SampleType = c.SampleType,
                        SiteComment = c.SiteComment,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return LabSheetTubeMPNDetailWebQuery;
        }
        #endregion Functions private Generated LabSheetTubeMPNDetailFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
