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
    ///     <para>bonjour MWQMSample</para>
    /// </summary>
    public partial class MWQMSampleService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSample mwqmSample = validationContext.ObjectInstance as MWQMSample;
            mwqmSample.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSample.MWQMSampleID == 0)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleMWQMSampleID), new[] { "MWQMSampleID" });
                }

                if (!GetRead().Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).Any())
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSample, CSSPModelsRes.MWQMSampleMWQMSampleID, mwqmSample.MWQMSampleID.ToString()), new[] { "MWQMSampleID" });
                }
            }

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleMWQMSiteTVItemID, mwqmSample.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMSite,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSiteTVItemID.TVType))
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.MWQMRunTVItemID select c).FirstOrDefault();

            if (TVItemMWQMRunTVItemID == null)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleMWQMRunTVItemID, mwqmSample.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MWQMRun,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMRunTVItemID.TVType))
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleMWQMRunTVItemID, "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            if (mwqmSample.SampleDateTime_Local.Year == 1)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleSampleDateTime_Local), new[] { "SampleDateTime_Local" });
            }
            else
            {
                if (mwqmSample.SampleDateTime_Local.Year < 1980)
                {
                mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSampleSampleDateTime_Local, "1980"), new[] { "SampleDateTime_Local" });
                }
            }

            if (mwqmSample.Depth_m != null)
            {
                if (mwqmSample.Depth_m < 0 || mwqmSample.Depth_m > 1000)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleDepth_m, "0", "1000"), new[] { "Depth_m" });
                }
            }

            if (mwqmSample.FecCol_MPN_100ml < 0 || mwqmSample.FecCol_MPN_100ml > 10000000)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000"), new[] { "FecCol_MPN_100ml" });
            }

            if (mwqmSample.Salinity_PPT != null)
            {
                if (mwqmSample.Salinity_PPT < 0 || mwqmSample.Salinity_PPT > 40)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleSalinity_PPT, "0", "40"), new[] { "Salinity_PPT" });
                }
            }

            if (mwqmSample.WaterTemp_C != null)
            {
                if (mwqmSample.WaterTemp_C < -10 || mwqmSample.WaterTemp_C > 40)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleWaterTemp_C, "-10", "40"), new[] { "WaterTemp_C" });
                }
            }

            if (mwqmSample.PH != null)
            {
                if (mwqmSample.PH < 0 || mwqmSample.PH > 14)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSamplePH, "0", "14"), new[] { "PH" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText))
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleSampleTypesText), new[] { "SampleTypesText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText) && mwqmSample.SampleTypesText.Length > 50)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSampleSampleTypesText, "50"), new[] { "SampleTypesText" });
            }

            if (mwqmSample.SampleType_old != null)
            {
                retStr = enums.EnumTypeOK(typeof(SampleTypeEnum), (int?)mwqmSample.SampleType_old);
                if (mwqmSample.SampleType_old == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleSampleType_old), new[] { "SampleType_old" });
                }
            }

            if (mwqmSample.Tube_10 != null)
            {
                if (mwqmSample.Tube_10 < 0 || mwqmSample.Tube_10 > 5)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_10, "0", "5"), new[] { "Tube_10" });
                }
            }

            if (mwqmSample.Tube_1_0 != null)
            {
                if (mwqmSample.Tube_1_0 < 0 || mwqmSample.Tube_1_0 > 5)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_1_0, "0", "5"), new[] { "Tube_1_0" });
                }
            }

            if (mwqmSample.Tube_0_1 != null)
            {
                if (mwqmSample.Tube_0_1 < 0 || mwqmSample.Tube_0_1 > 5)
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMSampleTube_0_1, "0", "5"), new[] { "Tube_0_1" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.ProcessedBy) && mwqmSample.ProcessedBy.Length > 10)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSampleProcessedBy, "10"), new[] { "ProcessedBy" });
            }

            if (mwqmSample.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSampleLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSample.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSampleLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSampleLastUpdateContactTVItemID, mwqmSample.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSample.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSampleLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSample.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSample GetMWQMSampleWithMWQMSampleID(int MWQMSampleID)
        {
            IQueryable<MWQMSample> mwqmSampleQuery = (from c in (GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMSampleID == MWQMSampleID
                                                select c);

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmSampleQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMWQMSampleWeb(mwqmSampleQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMSampleReport(mwqmSampleQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMSample> GetMWQMSampleList()
        {
            IQueryable<MWQMSample> mwqmSampleQuery = GetParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (GetParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        mwqmSampleQuery = EnhanceQueryStatements<MWQMSample>(mwqmSampleQuery) as IQueryable<MWQMSample>;

                        return mwqmSampleQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        mwqmSampleQuery = FillMWQMSampleWeb(mwqmSampleQuery);

                        mwqmSampleQuery = EnhanceQueryStatements<MWQMSample>(mwqmSampleQuery) as IQueryable<MWQMSample>;

                        return mwqmSampleQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        mwqmSampleQuery = FillMWQMSampleReport(mwqmSampleQuery);

                        mwqmSampleQuery = EnhanceQueryStatements<MWQMSample>(mwqmSampleQuery) as IQueryable<MWQMSample>;

                        return mwqmSampleQuery;
                    }
                default:
                    {
                        mwqmSampleQuery = mwqmSampleQuery.Where(c => c.MWQMSampleID == 0);

                        return mwqmSampleQuery;
                    }
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMSample mwqmSample)
        {
            mwqmSample.ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Create);
            if (mwqmSample.ValidationResults.Count() > 0) return false;

            db.MWQMSamples.Add(mwqmSample);

            if (!TryToSave(mwqmSample)) return false;

            return true;
        }
        public bool Delete(MWQMSample mwqmSample)
        {
            mwqmSample.ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Delete);
            if (mwqmSample.ValidationResults.Count() > 0) return false;

            db.MWQMSamples.Remove(mwqmSample);

            if (!TryToSave(mwqmSample)) return false;

            return true;
        }
        public bool Update(MWQMSample mwqmSample)
        {
            mwqmSample.ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Update);
            if (mwqmSample.ValidationResults.Count() > 0) return false;

            db.MWQMSamples.Update(mwqmSample);

            if (!TryToSave(mwqmSample)) return false;

            return true;
        }
        public IQueryable<MWQMSample> GetRead()
        {
            IQueryable<MWQMSample> mwqmSampleQuery = db.MWQMSamples.AsNoTracking();

            return mwqmSampleQuery;
        }
        public IQueryable<MWQMSample> GetEdit()
        {
            IQueryable<MWQMSample> mwqmSampleQuery = db.MWQMSamples;

            return mwqmSampleQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSampleFillWeb
        private IQueryable<MWQMSample> FillMWQMSampleWeb(IQueryable<MWQMSample> mwqmSampleQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> SampleTypeEnumList = enums.GetEnumTextOrderedList(typeof(SampleTypeEnum));

            mwqmSampleQuery = (from c in mwqmSampleQuery
                let MWQMSiteTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMSiteTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MWQMRunTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MWQMRunTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MWQMSample
                    {
                        MWQMSampleID = c.MWQMSampleID,
                        MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                        MWQMRunTVItemID = c.MWQMRunTVItemID,
                        SampleDateTime_Local = c.SampleDateTime_Local,
                        Depth_m = c.Depth_m,
                        FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                        Salinity_PPT = c.Salinity_PPT,
                        WaterTemp_C = c.WaterTemp_C,
                        PH = c.PH,
                        SampleTypesText = c.SampleTypesText,
                        SampleType_old = c.SampleType_old,
                        Tube_10 = c.Tube_10,
                        Tube_1_0 = c.Tube_1_0,
                        Tube_0_1 = c.Tube_0_1,
                        ProcessedBy = c.ProcessedBy,
                        UseForOpenData = c.UseForOpenData,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        MWQMSampleWeb = new MWQMSampleWeb
                        {
                            MWQMSiteTVText = MWQMSiteTVText,
                            MWQMRunTVText = MWQMRunTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            SampleType_oldText = (from e in SampleTypeEnumList
                                where e.EnumID == (int?)c.SampleType_old
                                select e.EnumText).FirstOrDefault(),
                        },
                        MWQMSampleReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmSampleQuery;
        }
        #endregion Functions private Generated MWQMSampleFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMSample mwqmSample)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSample.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
