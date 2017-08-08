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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorMWQMSubsectorID), new[] { "MWQMSubsectorID" });
                }
            }

            //MWQMSubsectorID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MWQMSubsectorTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMWQMSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSubsectorTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, mwqmSubsector.MWQMSubsectorTVItemID.ToString()), new[] { "MWQMSubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSubsectorTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "Subsector"), new[] { "MWQMSubsectorTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorSubsectorHistoricKey), new[] { "SubsectorHistoricKey" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey) && mwqmSubsector.SubsectorHistoricKey.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorHistoricKey, "20"), new[] { "SubsectorHistoricKey" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText) && mwqmSubsector.TideLocationSIDText.Length > 20)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorTideLocationSIDText, "20"), new[] { "TideLocationSIDText" });
            }

            if (mwqmSubsector.RainDay0Limit != null)
            {
                if (mwqmSubsector.RainDay0Limit < 0 || mwqmSubsector.RainDay0Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "300"), new[] { "RainDay0Limit" });
                }
            }

            if (mwqmSubsector.RainDay1Limit != null)
            {
                if (mwqmSubsector.RainDay1Limit < 0 || mwqmSubsector.RainDay1Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "300"), new[] { "RainDay1Limit" });
                }
            }

            if (mwqmSubsector.RainDay2Limit != null)
            {
                if (mwqmSubsector.RainDay2Limit < 0 || mwqmSubsector.RainDay2Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "300"), new[] { "RainDay2Limit" });
                }
            }

            if (mwqmSubsector.RainDay3Limit != null)
            {
                if (mwqmSubsector.RainDay3Limit < 0 || mwqmSubsector.RainDay3Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "300"), new[] { "RainDay3Limit" });
                }
            }

            if (mwqmSubsector.RainDay4Limit != null)
            {
                if (mwqmSubsector.RainDay4Limit < 0 || mwqmSubsector.RainDay4Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "300"), new[] { "RainDay4Limit" });
                }
            }

            if (mwqmSubsector.RainDay5Limit != null)
            {
                if (mwqmSubsector.RainDay5Limit < 0 || mwqmSubsector.RainDay5Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "300"), new[] { "RainDay5Limit" });
                }
            }

            if (mwqmSubsector.RainDay6Limit != null)
            {
                if (mwqmSubsector.RainDay6Limit < 0 || mwqmSubsector.RainDay6Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "300"), new[] { "RainDay6Limit" });
                }
            }

            if (mwqmSubsector.RainDay7Limit != null)
            {
                if (mwqmSubsector.RainDay7Limit < 0 || mwqmSubsector.RainDay7Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "300"), new[] { "RainDay7Limit" });
                }
            }

            if (mwqmSubsector.RainDay8Limit != null)
            {
                if (mwqmSubsector.RainDay8Limit < 0 || mwqmSubsector.RainDay8Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "300"), new[] { "RainDay8Limit" });
                }
            }

            if (mwqmSubsector.RainDay9Limit != null)
            {
                if (mwqmSubsector.RainDay9Limit < 0 || mwqmSubsector.RainDay9Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "300"), new[] { "RainDay9Limit" });
                }
            }

            if (mwqmSubsector.RainDay10Limit != null)
            {
                if (mwqmSubsector.RainDay10Limit < 0 || mwqmSubsector.RainDay10Limit > 300)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "300"), new[] { "RainDay10Limit" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10"), new[] { "IncludeRainRunCount" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10"), new[] { "NoRainRunCount" });
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
                    yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10"), new[] { "OnlyRainRunCount" });
                }
            }

            if (mwqmSubsector.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MWQMSubsectorLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, mwqmSubsector.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorTVText) && mwqmSubsector.SubsectorTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorTVText, "200"), new[] { "SubsectorTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.LastUpdateContactTVText) && mwqmSubsector.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSubsector GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID)
        {
            IQueryable<MWQMSubsector> mwqmSubsectorQuery = (from c in GetRead()
                                                where c.MWQMSubsectorID == MWQMSubsectorID
                                                select c);

            return FillMWQMSubsector(mwqmSubsectorQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MWQMSubsector> FillMWQMSubsector(IQueryable<MWQMSubsector> mwqmSubsectorQuery)
        {
            List<MWQMSubsector> MWQMSubsectorList = (from c in mwqmSubsectorQuery
                                         let SubsectorTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.MWQMSubsectorTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MWQMSubsector
                                         {
                                             MWQMSubsectorID = c.MWQMSubsectorID,
                                             MWQMSubsectorTVItemID = c.MWQMSubsectorTVItemID,
                                             SubsectorHistoricKey = c.SubsectorHistoricKey,
                                             TideLocationSIDText = c.TideLocationSIDText,
                                             RainDay0Limit = c.RainDay0Limit,
                                             RainDay1Limit = c.RainDay1Limit,
                                             RainDay2Limit = c.RainDay2Limit,
                                             RainDay3Limit = c.RainDay3Limit,
                                             RainDay4Limit = c.RainDay4Limit,
                                             RainDay5Limit = c.RainDay5Limit,
                                             RainDay6Limit = c.RainDay6Limit,
                                             RainDay7Limit = c.RainDay7Limit,
                                             RainDay8Limit = c.RainDay8Limit,
                                             RainDay9Limit = c.RainDay9Limit,
                                             RainDay10Limit = c.RainDay10Limit,
                                             IncludeRainStartDate = c.IncludeRainStartDate,
                                             IncludeRainEndDate = c.IncludeRainEndDate,
                                             IncludeRainRunCount = c.IncludeRainRunCount,
                                             IncludeRainSelectFullYear = c.IncludeRainSelectFullYear,
                                             NoRainStartDate = c.NoRainStartDate,
                                             NoRainEndDate = c.NoRainEndDate,
                                             NoRainRunCount = c.NoRainRunCount,
                                             NoRainSelectFullYear = c.NoRainSelectFullYear,
                                             OnlyRainStartDate = c.OnlyRainStartDate,
                                             OnlyRainEndDate = c.OnlyRainEndDate,
                                             OnlyRainRunCount = c.OnlyRainRunCount,
                                             OnlyRainSelectFullYear = c.OnlyRainSelectFullYear,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             SubsectorTVText = SubsectorTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return MWQMSubsectorList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
