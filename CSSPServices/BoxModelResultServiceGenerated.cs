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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            BoxModelResult boxModelResult = validationContext.ObjectInstance as BoxModelResult;

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (boxModelResult.BoxModelResultID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultID), new[] { ModelsRes.BoxModelResultBoxModelResultID });
                }
            }

            //BoxModelID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.BoxModelResultTypeOK(boxModelResult.BoxModelResultType);
            if (boxModelResult.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultType), new[] { ModelsRes.BoxModelResultBoxModelResultType });
            }

            //Volume_m3 (float) is required but no testing needed as it is automatically set to 0.0f

            //Surface_m2 (float) is required but no testing needed as it is automatically set to 0.0f

            //Radius_m (float) is required but no testing needed as it is automatically set to 0.0f

            //LeftSideDiameterLineAngle_deg (float) is required but no testing needed as it is automatically set to 0.0f

            //CircleCenterLatitude (float) is required but no testing needed as it is automatically set to 0.0f

            //CircleCenterLongitude (float) is required but no testing needed as it is automatically set to 0.0f

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            //RectLength_m (float) is required but no testing needed as it is automatically set to 0.0f

            //RectWidth_m (float) is required but no testing needed as it is automatically set to 0.0f

            //LeftSideLineAngle_deg (float) is required but no testing needed as it is automatically set to 0.0f

            //LeftSideLineStartLatitude (float) is required but no testing needed as it is automatically set to 0.0f

            //LeftSideLineStartLongitude (float) is required but no testing needed as it is automatically set to 0.0f

            if (boxModelResult.LastUpdateDate_UTC == null || boxModelResult.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultLastUpdateDate_UTC), new[] { ModelsRes.BoxModelResultLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (boxModelResult.BoxModelID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultBoxModelID, "1"), new[] { ModelsRes.BoxModelResultBoxModelID });
            }

            if (boxModelResult.Volume_m3 < 0 || boxModelResult.Volume_m3 > 900000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultVolume_m3, "0", "900000"), new[] { ModelsRes.BoxModelResultVolume_m3 });
            }

            if (boxModelResult.Surface_m2 < 0 || boxModelResult.Surface_m2 > 900000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultSurface_m2, "0", "900000"), new[] { ModelsRes.BoxModelResultSurface_m2 });
            }

            if (boxModelResult.Radius_m < 0 || boxModelResult.Radius_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000"), new[] { ModelsRes.BoxModelResultRadius_m });
            }

            if (boxModelResult.LeftSideDiameterLineAngle_deg < 0 || boxModelResult.LeftSideDiameterLineAngle_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), new[] { ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg });
            }

            if (boxModelResult.CircleCenterLatitude < -90 || boxModelResult.CircleCenterLatitude > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), new[] { ModelsRes.BoxModelResultCircleCenterLatitude });
            }

            if (boxModelResult.CircleCenterLongitude < -180 || boxModelResult.CircleCenterLongitude > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), new[] { ModelsRes.BoxModelResultCircleCenterLongitude });
            }

            if (boxModelResult.RectLength_m < 0 || boxModelResult.RectLength_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000"), new[] { ModelsRes.BoxModelResultRectLength_m });
            }

            if (boxModelResult.RectWidth_m < 0 || boxModelResult.RectWidth_m > 100000)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000"), new[] { ModelsRes.BoxModelResultRectWidth_m });
            }

            if (boxModelResult.LeftSideLineAngle_deg < 0 || boxModelResult.LeftSideLineAngle_deg > 360)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), new[] { ModelsRes.BoxModelResultLeftSideLineAngle_deg });
            }

            if (boxModelResult.LeftSideLineStartLatitude < -90 || boxModelResult.LeftSideLineStartLatitude > 90)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), new[] { ModelsRes.BoxModelResultLeftSideLineStartLatitude });
            }

            if (boxModelResult.LeftSideLineStartLongitude < -180 || boxModelResult.LeftSideLineStartLongitude > 180)
            {
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), new[] { ModelsRes.BoxModelResultLeftSideLineStartLongitude });
            }

            if (boxModelResult.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "1"), new[] { ModelsRes.BoxModelResultLastUpdateContactTVItemID });
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
