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
    public partial class BoxModelResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelResultService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelResult boxModelResult = validationContext.ObjectInstance as BoxModelResult;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (boxModelResult.BoxModelResultID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultID), new[] { "BoxModelResultID" });
                }
            }

            //BoxModelResultID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            BoxModel BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelResult.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelResultBoxModelID, boxModelResult.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.BoxModelResultTypeOK(boxModelResult.BoxModelResultType);
            if (boxModelResult.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultType), new[] { "BoxModelResultType" });
            }

            //Volume_m3 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.Volume_m3 < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultVolume_m3, "0"), new[] { "Volume_m3" });
            }

            //Surface_m2 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.Surface_m2 < 0)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultSurface_m2, "0"), new[] { "Surface_m2" });
            }

            //Radius_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.Radius_m < 0 || boxModelResult.Radius_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000"), new[] { "Radius_m" });
            }

            //LeftSideDiameterLineAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideDiameterLineAngle_deg < 0 || boxModelResult.LeftSideDiameterLineAngle_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), new[] { "LeftSideDiameterLineAngle_deg" });
            }

            //CircleCenterLatitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.CircleCenterLatitude < -90 || boxModelResult.CircleCenterLatitude > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), new[] { "CircleCenterLatitude" });
            }

            //CircleCenterLongitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.CircleCenterLongitude < -180 || boxModelResult.CircleCenterLongitude > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), new[] { "CircleCenterLongitude" });
            }

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            //RectLength_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.RectLength_m < 0 || boxModelResult.RectLength_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000"), new[] { "RectLength_m" });
            }

            //RectWidth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.RectWidth_m < 0 || boxModelResult.RectWidth_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000"), new[] { "RectWidth_m" });
            }

            //LeftSideLineAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideLineAngle_deg < 0 || boxModelResult.LeftSideLineAngle_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), new[] { "LeftSideLineAngle_deg" });
            }

            //LeftSideLineStartLatitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideLineStartLatitude < -90 || boxModelResult.LeftSideLineStartLatitude > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), new[] { "LeftSideLineStartLatitude" });
            }

            //LeftSideLineStartLongitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideLineStartLongitude < -180 || boxModelResult.LeftSideLineStartLongitude > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), new[] { "LeftSideLineStartLongitude" });
            }

            if (boxModelResult.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelResult.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelResultLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelResultLastUpdateContactTVItemID, boxModelResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
        public bool Add(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Create);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Add(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        public bool AddRange(List<BoxModelResult> boxModelResultList)
        {
            foreach (BoxModelResult boxModelResult in boxModelResultList)
            {
                boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Create);
                if (boxModelResult.ValidationResults.Count() > 0) return false;
            }

            db.BoxModelResults.AddRange(boxModelResultList);

            if (!TryToSaveRange(boxModelResultList)) return false;

            return true;
        }
        public bool Delete(BoxModelResult boxModelResult)
        {
            if (!db.BoxModelResults.Where(c => c.BoxModelResultID == boxModelResult.BoxModelResultID).Any())
            {
                boxModelResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "BoxModelResult", "BoxModelResultID", boxModelResult.BoxModelResultID.ToString())) }.AsEnumerable();
                return false;
            }

            db.BoxModelResults.Remove(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        public bool DeleteRange(List<BoxModelResult> boxModelResultList)
        {
            foreach (BoxModelResult boxModelResult in boxModelResultList)
            {
                if (!db.BoxModelResults.Where(c => c.BoxModelResultID == boxModelResult.BoxModelResultID).Any())
                {
                    boxModelResultList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "BoxModelResult", "BoxModelResultID", boxModelResult.BoxModelResultID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.BoxModelResults.RemoveRange(boxModelResultList);

            if (!TryToSaveRange(boxModelResultList)) return false;

            return true;
        }
        public bool Update(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Update);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Update(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        public bool UpdateRange(List<BoxModelResult> boxModelResultList)
        {
            foreach (BoxModelResult boxModelResult in boxModelResultList)
            {
                boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Update);
                if (boxModelResult.ValidationResults.Count() > 0) return false;
            }
            db.BoxModelResults.UpdateRange(boxModelResultList);

            if (!TryToSaveRange(boxModelResultList)) return false;

            return true;
        }
        public IQueryable<BoxModelResult> GetRead()
        {
            return db.BoxModelResults.AsNoTracking();
        }
        public IQueryable<BoxModelResult> GetEdit()
        {
            return db.BoxModelResults;
        }
        #endregion Functions public

        #region Functions private
        private bool TryToSave(BoxModelResult boxModelResult)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelResult.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<BoxModelResult> boxModelResultList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                boxModelResultList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
