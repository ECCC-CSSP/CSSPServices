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
    public partial class MWQMSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSubsector mwqmSubsector = validationContext.ObjectInstance as MWQMSubsector;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mwqmSubsector.MWQMSubsectorID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorMWQMSubsectorID), new[] { ModelsRes.MWQMSubsectorMWQMSubsectorID });
                }
            }

            //MWQMSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSubsector.MWQMSubsectorTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "1"), new[] { ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, mwqmSubsector.MWQMSubsectorTVItemID.ToString()), new[] { ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorSubsectorHistoricKey), new[] { ModelsRes.MWQMSubsectorSubsectorHistoricKey });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey) && mwqmSubsector.SubsectorHistoricKey.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorHistoricKey, "20"), new[] { ModelsRes.MWQMSubsectorSubsectorHistoricKey });
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorTideLocationSIDText), new[] { ModelsRes.MWQMSubsectorTideLocationSIDText });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText) && mwqmSubsector.TideLocationSIDText.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorTideLocationSIDText, "20"), new[] { ModelsRes.MWQMSubsectorTideLocationSIDText });
            }

            if (mwqmSubsector.RainDay0Limit != null)
            {
                if (mwqmSubsector.RainDay0Limit < 0 || mwqmSubsector.RainDay0Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay0Limit });
                }
            }

            if (mwqmSubsector.RainDay1Limit != null)
            {
                if (mwqmSubsector.RainDay1Limit < 0 || mwqmSubsector.RainDay1Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay1Limit });
                }
            }

            if (mwqmSubsector.RainDay2Limit != null)
            {
                if (mwqmSubsector.RainDay2Limit < 0 || mwqmSubsector.RainDay2Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay2Limit });
                }
            }

            if (mwqmSubsector.RainDay3Limit != null)
            {
                if (mwqmSubsector.RainDay3Limit < 0 || mwqmSubsector.RainDay3Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay3Limit });
                }
            }

            if (mwqmSubsector.RainDay4Limit != null)
            {
                if (mwqmSubsector.RainDay4Limit < 0 || mwqmSubsector.RainDay4Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay4Limit });
                }
            }

            if (mwqmSubsector.RainDay5Limit != null)
            {
                if (mwqmSubsector.RainDay5Limit < 0 || mwqmSubsector.RainDay5Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay5Limit });
                }
            }

            if (mwqmSubsector.RainDay6Limit != null)
            {
                if (mwqmSubsector.RainDay6Limit < 0 || mwqmSubsector.RainDay6Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay6Limit });
                }
            }

            if (mwqmSubsector.RainDay7Limit != null)
            {
                if (mwqmSubsector.RainDay7Limit < 0 || mwqmSubsector.RainDay7Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay7Limit });
                }
            }

            if (mwqmSubsector.RainDay8Limit != null)
            {
                if (mwqmSubsector.RainDay8Limit < 0 || mwqmSubsector.RainDay8Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay8Limit });
                }
            }

            if (mwqmSubsector.RainDay9Limit != null)
            {
                if (mwqmSubsector.RainDay9Limit < 0 || mwqmSubsector.RainDay9Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay9Limit });
                }
            }

            if (mwqmSubsector.RainDay10Limit != null)
            {
                if (mwqmSubsector.RainDay10Limit < 0 || mwqmSubsector.RainDay10Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "300"), new[] { ModelsRes.MWQMSubsectorRainDay10Limit });
                }
            }

            if (mwqmSubsector.IncludeRainStartDate != null && ((DateTime)mwqmSubsector.IncludeRainStartDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorIncludeRainStartDate, "1980"), new[] { ModelsRes.MWQMSubsectorIncludeRainStartDate });
            }

            if (mwqmSubsector.IncludeRainEndDate != null && ((DateTime)mwqmSubsector.IncludeRainEndDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorIncludeRainEndDate, "1980"), new[] { ModelsRes.MWQMSubsectorIncludeRainEndDate });
            }

            if (mwqmSubsector.IncludeRainRunCount != null)
            {
                if (mwqmSubsector.IncludeRainRunCount < 0 || mwqmSubsector.IncludeRainRunCount > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10"), new[] { ModelsRes.MWQMSubsectorIncludeRainRunCount });
                }
            }

            if (mwqmSubsector.NoRainStartDate != null && ((DateTime)mwqmSubsector.NoRainStartDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorNoRainStartDate, "1980"), new[] { ModelsRes.MWQMSubsectorNoRainStartDate });
            }

            if (mwqmSubsector.NoRainEndDate != null && ((DateTime)mwqmSubsector.NoRainEndDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorNoRainEndDate, "1980"), new[] { ModelsRes.MWQMSubsectorNoRainEndDate });
            }

            if (mwqmSubsector.NoRainRunCount != null)
            {
                if (mwqmSubsector.NoRainRunCount < 0 || mwqmSubsector.NoRainRunCount > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10"), new[] { ModelsRes.MWQMSubsectorNoRainRunCount });
                }
            }

            if (mwqmSubsector.OnlyRainStartDate != null && ((DateTime)mwqmSubsector.OnlyRainStartDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorOnlyRainStartDate, "1980"), new[] { ModelsRes.MWQMSubsectorOnlyRainStartDate });
            }

            if (mwqmSubsector.OnlyRainEndDate != null && ((DateTime)mwqmSubsector.OnlyRainEndDate).Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorOnlyRainEndDate, "1980"), new[] { ModelsRes.MWQMSubsectorOnlyRainEndDate });
            }

            if (mwqmSubsector.OnlyRainRunCount != null)
            {
                if (mwqmSubsector.OnlyRainRunCount < 0 || mwqmSubsector.OnlyRainRunCount > 10)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10"), new[] { ModelsRes.MWQMSubsectorOnlyRainRunCount });
                }
            }

            if (mwqmSubsector.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLastUpdateDate_UTC), new[] { ModelsRes.MWQMSubsectorLastUpdateDate_UTC });
            }

            if (mwqmSubsector.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorLastUpdateDate_UTC, "1980"), new[] { ModelsRes.MWQMSubsectorLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmSubsector.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "1"), new[] { ModelsRes.MWQMSubsectorLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, mwqmSubsector.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.MWQMSubsectorLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(MWQMSubsector mwqmSubsector)
        {
            mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Create);
            if (mwqmSubsector.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectors.Add(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

            return true;
        }
        public bool AddRange(List<MWQMSubsector> mwqmSubsectorList)
        {
            foreach (MWQMSubsector mwqmSubsector in mwqmSubsectorList)
            {
                mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Create);
                if (mwqmSubsector.ValidationResults.Count() > 0) return false;
            }

            db.MWQMSubsectors.AddRange(mwqmSubsectorList);

            if (!TryToSaveRange(mwqmSubsectorList)) return false;

            return true;
        }
        public bool Delete(MWQMSubsector mwqmSubsector)
        {
            if (!db.MWQMSubsectors.Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
            {
                mwqmSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MWQMSubsectors.Remove(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

            return true;
        }
        public bool DeleteRange(List<MWQMSubsector> mwqmSubsectorList)
        {
            foreach (MWQMSubsector mwqmSubsector in mwqmSubsectorList)
            {
                if (!db.MWQMSubsectors.Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
                {
                    mwqmSubsectorList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MWQMSubsector", "MWQMSubsectorID", mwqmSubsector.MWQMSubsectorID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MWQMSubsectors.RemoveRange(mwqmSubsectorList);

            if (!TryToSaveRange(mwqmSubsectorList)) return false;

            return true;
        }
        public bool Update(MWQMSubsector mwqmSubsector)
        {
            mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Update);
            if (mwqmSubsector.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectors.Update(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

            return true;
        }
        public bool UpdateRange(List<MWQMSubsector> mwqmSubsectorList)
        {
            foreach (MWQMSubsector mwqmSubsector in mwqmSubsectorList)
            {
                mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Update);
                if (mwqmSubsector.ValidationResults.Count() > 0) return false;
            }
            db.MWQMSubsectors.UpdateRange(mwqmSubsectorList);

            if (!TryToSaveRange(mwqmSubsectorList)) return false;

            return true;
        }
        public IQueryable<MWQMSubsector> GetRead()
        {
            return db.MWQMSubsectors.AsNoTracking();
        }
        public IQueryable<MWQMSubsector> GetEdit()
        {
            return db.MWQMSubsectors;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(MWQMSubsector mwqmSubsector)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSubsector.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MWQMSubsector> mwqmSubsectorList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmSubsectorList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
