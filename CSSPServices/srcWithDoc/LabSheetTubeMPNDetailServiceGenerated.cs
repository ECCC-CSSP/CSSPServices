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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID), new[] { "LabSheetTubeMPNDetailID" });
                }

                if (!GetRead().Where(c => c.LabSheetTubeMPNDetailID == labSheetTubeMPNDetail.LabSheetTubeMPNDetailID).Any())
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheetTubeMPNDetail, CSSPModelsRes.LabSheetTubeMPNDetailLabSheetTubeMPNDetailID, labSheetTubeMPNDetail.LabSheetTubeMPNDetailID.ToString()), new[] { "LabSheetTubeMPNDetailID" });
                }
            }

            LabSheetDetail LabSheetDetailLabSheetDetailID = (from c in db.LabSheetDetails where c.LabSheetDetailID == labSheetTubeMPNDetail.LabSheetDetailID select c).FirstOrDefault();

            if (LabSheetDetailLabSheetDetailID == null)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.LabSheetDetail, CSSPModelsRes.LabSheetTubeMPNDetailLabSheetDetailID, labSheetTubeMPNDetail.LabSheetDetailID.ToString()), new[] { "LabSheetDetailID" });
            }

            if (labSheetTubeMPNDetail.Ordinal < 0 || labSheetTubeMPNDetail.Ordinal > 1000)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailOrdinal, "0", "1000"), new[] { "Ordinal" });
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, labSheetTubeMPNDetail.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetTubeMPNDetailMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            if (labSheetTubeMPNDetail.SampleDateTime != null && ((DateTime)labSheetTubeMPNDetail.SampleDateTime).Year < 1980)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetTubeMPNDetailSampleDateTime, "1980"), new[] { CSSPModelsRes.LabSheetTubeMPNDetailSampleDateTime });
            }

            if (labSheetTubeMPNDetail.MPN != null)
            {
                if (labSheetTubeMPNDetail.MPN < 1 || labSheetTubeMPNDetail.MPN > 10000000)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailMPN, "1", "10000000"), new[] { "MPN" });
                }
            }

            if (labSheetTubeMPNDetail.Tube10 != null)
            {
                if (labSheetTubeMPNDetail.Tube10 < 0 || labSheetTubeMPNDetail.Tube10 > 5)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube10, "0", "5"), new[] { "Tube10" });
                }
            }

            if (labSheetTubeMPNDetail.Tube1_0 != null)
            {
                if (labSheetTubeMPNDetail.Tube1_0 < 0 || labSheetTubeMPNDetail.Tube1_0 > 5)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube1_0, "0", "5"), new[] { "Tube1_0" });
                }
            }

            if (labSheetTubeMPNDetail.Tube0_1 != null)
            {
                if (labSheetTubeMPNDetail.Tube0_1 < 0 || labSheetTubeMPNDetail.Tube0_1 > 5)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTube0_1, "0", "5"), new[] { "Tube0_1" });
                }
            }

            if (labSheetTubeMPNDetail.Salinity != null)
            {
                if (labSheetTubeMPNDetail.Salinity < 0 || labSheetTubeMPNDetail.Salinity > 40)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailSalinity, "0", "40"), new[] { "Salinity" });
                }
            }

            if (labSheetTubeMPNDetail.Temperature != null)
            {
                if (labSheetTubeMPNDetail.Temperature < -10 || labSheetTubeMPNDetail.Temperature > 40)
                {
                    labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.LabSheetTubeMPNDetailTemperature, "-10", "40"), new[] { "Temperature" });
                }
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.ProcessedBy) && labSheetTubeMPNDetail.ProcessedBy.Length > 10)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetTubeMPNDetailProcessedBy, "10"), new[] { "ProcessedBy" });
            }

            retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)labSheetTubeMPNDetail.SampleType);
            if (labSheetTubeMPNDetail.SampleType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetTubeMPNDetailSampleType), new[] { "SampleType" });
            }

            if (!string.IsNullOrWhiteSpace(labSheetTubeMPNDetail.SiteComment) && labSheetTubeMPNDetail.SiteComment.Length > 250)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.LabSheetTubeMPNDetailSiteComment, "250"), new[] { "SiteComment" });
            }

            if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year == 1)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (labSheetTubeMPNDetail.LastUpdateDate_UTC.Year < 1980)
                {
                labSheetTubeMPNDetail.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == labSheetTubeMPNDetail.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                labSheetTubeMPNDetail.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, labSheetTubeMPNDetail.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.LabSheetTubeMPNDetailLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<LabSheetTubeMPNDetail> labSheetTubeMPNDetailQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return labSheetTubeMPNDetailQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillLabSheetTubeMPNDetailWeb(labSheetTubeMPNDetailQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillLabSheetTubeMPNDetailReport(labSheetTubeMPNDetailQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<LabSheetTubeMPNDetail> GetLabSheetTubeMPNDetailList()
        {
            IQueryable<LabSheetTubeMPNDetail> labSheetTubeMPNDetailQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        labSheetTubeMPNDetailQuery = EnhanceQueryStatements<LabSheetTubeMPNDetail>(labSheetTubeMPNDetailQuery) as IQueryable<LabSheetTubeMPNDetail>;

                        return labSheetTubeMPNDetailQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        labSheetTubeMPNDetailQuery = FillLabSheetTubeMPNDetailWeb(labSheetTubeMPNDetailQuery);

                        labSheetTubeMPNDetailQuery = EnhanceQueryStatements<LabSheetTubeMPNDetail>(labSheetTubeMPNDetailQuery) as IQueryable<LabSheetTubeMPNDetail>;

                        return labSheetTubeMPNDetailQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        labSheetTubeMPNDetailQuery = FillLabSheetTubeMPNDetailReport(labSheetTubeMPNDetailQuery);

                        labSheetTubeMPNDetailQuery = EnhanceQueryStatements<LabSheetTubeMPNDetail>(labSheetTubeMPNDetailQuery) as IQueryable<LabSheetTubeMPNDetail>;

                        return labSheetTubeMPNDetailQuery;
                    }
                default:
                    {
                        labSheetTubeMPNDetailQuery = labSheetTubeMPNDetailQuery.Where(c => c.LabSheetTubeMPNDetailID == 0);

                        return labSheetTubeMPNDetailQuery;
                    }
            }
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
        public IQueryable<LabSheetTubeMPNDetail> GetRead()
        {
            IQueryable<LabSheetTubeMPNDetail> labSheetTubeMPNDetailQuery = db.LabSheetTubeMPNDetails.AsNoTracking();

            return labSheetTubeMPNDetailQuery;
        }
        public IQueryable<LabSheetTubeMPNDetail> GetEdit()
        {
            IQueryable<LabSheetTubeMPNDetail> labSheetTubeMPNDetailQuery = db.LabSheetTubeMPNDetails;

            return labSheetTubeMPNDetailQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated LabSheetTubeMPNDetailFillWeb
        private IQueryable<LabSheetTubeMPNDetail> FillLabSheetTubeMPNDetailWeb(IQueryable<LabSheetTubeMPNDetail> labSheetTubeMPNDetailQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

            labSheetTubeMPNDetailQuery = (from c in labSheetTubeMPNDetailQuery
                let MWQMSiteTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new LabSheetTubeMPNDetail
                    {
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
                        LabSheetTubeMPNDetailWeb = new LabSheetTubeMPNDetailWeb
                        {
                            MWQMSiteTVText = MWQMSiteTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            SampleTypeText = (from e in SampleTypeEnumList
                                where e.EnumID == (int?)c.SampleType
                                select e.EnumText).FirstOrDefault(),
                        },
                        LabSheetTubeMPNDetailReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return labSheetTubeMPNDetailQuery;
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
