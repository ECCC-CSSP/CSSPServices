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
    public partial class MWQMSampleService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSampleService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSample mwqmSample = validationContext.ObjectInstance as MWQMSample;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSample.MWQMSampleID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleMWQMSampleID), new[] { "MWQMSampleID" });
                }
            }

            //MWQMSampleID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSiteTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMSiteTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.MWQMSiteTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSiteTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleMWQMSiteTVItemID, mwqmSample.MWQMSiteTVItemID.ToString()), new[] { "MWQMSiteTVItemID" });
            }
            else
            {
                if (TVItemMWQMSiteTVItemID.TVType != TVTypeEnum.MWQMSite)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleMWQMSiteTVItemID, "MWQMSite"), new[] { "MWQMSiteTVItemID" });
                }
            }

            //MWQMRunTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMRunTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.MWQMRunTVItemID select c).FirstOrDefault();

            if (TVItemMWQMRunTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleMWQMRunTVItemID, mwqmSample.MWQMRunTVItemID.ToString()), new[] { "MWQMRunTVItemID" });
            }
            else
            {
                if (TVItemMWQMRunTVItemID.TVType != TVTypeEnum.MWQMRun)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleMWQMRunTVItemID, "MWQMRun"), new[] { "MWQMRunTVItemID" });
                }
            }

            if (mwqmSample.SampleDateTime_Local.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleDateTime_Local), new[] { "SampleDateTime_Local" });
            }
            else
            {
                if (mwqmSample.SampleDateTime_Local.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSampleSampleDateTime_Local, "1980"), new[] { "SampleDateTime_Local" });
                }
            }

            if (mwqmSample.Depth_m != null)
            {
                if (mwqmSample.Depth_m < 0 || mwqmSample.Depth_m > 1000)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleDepth_m, "0", "1000"), new[] { "Depth_m" });
                }
            }

            //FecCol_MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSample.FecCol_MPN_100ml < 0 || mwqmSample.FecCol_MPN_100ml > 10000000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleFecCol_MPN_100ml, "0", "10000000"), new[] { "FecCol_MPN_100ml" });
            }

            if (mwqmSample.Salinity_PPT != null)
            {
                if (mwqmSample.Salinity_PPT < 0 || mwqmSample.Salinity_PPT > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleSalinity_PPT, "0", "40"), new[] { "Salinity_PPT" });
                }
            }

            if (mwqmSample.WaterTemp_C != null)
            {
                if (mwqmSample.WaterTemp_C < -10 || mwqmSample.WaterTemp_C > 40)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleWaterTemp_C, "-10", "40"), new[] { "WaterTemp_C" });
                }
            }

            if (mwqmSample.PH != null)
            {
                if (mwqmSample.PH < 0 || mwqmSample.PH > 14)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSamplePH, "0", "14"), new[] { "PH" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleTypesText), new[] { "SampleTypesText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.SampleTypesText) && mwqmSample.SampleTypesText.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleSampleTypesText, "50"), new[] { "SampleTypesText" });
            }

            retStr = enums.SampleTypeOK(mwqmSample.SampleType_old);
            if (mwqmSample.SampleType_old == SampleTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleSampleType_old), new[] { "SampleType_old" });
            }

            if (mwqmSample.Tube_10 != null)
            {
                if (mwqmSample.Tube_10 < 0 || mwqmSample.Tube_10 > 5)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_10, "0", "5"), new[] { "Tube_10" });
                }
            }

            if (mwqmSample.Tube_1_0 != null)
            {
                if (mwqmSample.Tube_1_0 < 0 || mwqmSample.Tube_1_0 > 5)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_1_0, "0", "5"), new[] { "Tube_1_0" });
                }
            }

            if (mwqmSample.Tube_0_1 != null)
            {
                if (mwqmSample.Tube_0_1 < 0 || mwqmSample.Tube_0_1 > 5)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSampleTube_0_1, "0", "5"), new[] { "Tube_0_1" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSample.ProcessedBy) && mwqmSample.ProcessedBy.Length > 10)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSampleProcessedBy, "10"), new[] { "ProcessedBy" });
            }

            if (mwqmSample.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSampleLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSample.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSampleLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSample.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSampleLastUpdateContactTVItemID, mwqmSample.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSampleLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public bool Add(MWQMSample mwqmSample)
        {
            mwqmSample.ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Create);
            if (mwqmSample.ValidationResults.Count() > 0) return false;

            db.MWQMSamples.Add(mwqmSample);

            if (!TryToSave(mwqmSample)) return false;

            return true;
        }
        public bool AddRange(List<MWQMSample> mwqmSampleList)
        {
            foreach (MWQMSample mwqmSample in mwqmSampleList)
            {
                mwqmSample.ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Create);
                if (mwqmSample.ValidationResults.Count() > 0) return false;
            }

            db.MWQMSamples.AddRange(mwqmSampleList);

            if (!TryToSaveRange(mwqmSampleList)) return false;

            return true;
        }
        public bool Delete(MWQMSample mwqmSample)
        {
            if (!db.MWQMSamples.Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).Any())
            {
                mwqmSample.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", mwqmSample.MWQMSampleID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSamples.Remove(mwqmSample);

            if (!TryToSave(mwqmSample)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMSample> mwqmSampleList)
        {
            foreach (MWQMSample mwqmSample in mwqmSampleList)
            {
                if (!db.MWQMSamples.Where(c => c.MWQMSampleID == mwqmSample.MWQMSampleID).Any())
                {
                    mwqmSampleList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSample", "MWQMSampleID", mwqmSample.MWQMSampleID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMSamples.RemoveRange(mwqmSampleList);

            if (!TryToSaveRange(mwqmSampleList)) return false;

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
        public bool UpdateRange(List<MWQMSample> mwqmSampleList)
        {
            foreach (MWQMSample mwqmSample in mwqmSampleList)
            {
                mwqmSample.ValidationResults = Validate(new ValidationContext(mwqmSample), ActionDBTypeEnum.Update);
                if (mwqmSample.ValidationResults.Count() > 0) return false;
            }
            db.MWQMSamples.UpdateRange(mwqmSampleList);

            if (!TryToSaveRange(mwqmSampleList)) return false;

            return true;
        }
        public IQueryable<MWQMSample> GetRead()
        {
            return db.MWQMSamples.AsNoTracking();
        }
        public IQueryable<MWQMSample> GetEdit()
        {
            return db.MWQMSamples;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<MWQMSample> mwqmSampleList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSampleList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
