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
            boxModelResult.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (boxModelResult.BoxModelResultID == 0)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultID), new[] { "BoxModelResultID" });
                }

                if (!GetRead().Where(c => c.BoxModelResultID == boxModelResult.BoxModelResultID).Any())
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModelResult, ModelsRes.BoxModelResultBoxModelResultID, boxModelResult.BoxModelResultID.ToString()), new[] { "BoxModelResultID" });
                }
            }

            //BoxModelResultID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            BoxModel BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelResult.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelResultBoxModelID, boxModelResult.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.BoxModelResultTypeOK(boxModelResult.BoxModelResultType);
            if (boxModelResult.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultType), new[] { "BoxModelResultType" });
            }

            //Volume_m3 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.Volume_m3 < 0)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultVolume_m3, "0"), new[] { "Volume_m3" });
            }

            //Surface_m2 (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.Surface_m2 < 0)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultSurface_m2, "0"), new[] { "Surface_m2" });
            }

            //Radius_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.Radius_m < 0 || boxModelResult.Radius_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRadius_m, "0", "100000"), new[] { "Radius_m" });
            }

            //LeftSideDiameterLineAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideDiameterLineAngle_deg < 0 || boxModelResult.LeftSideDiameterLineAngle_deg > 360)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideDiameterLineAngle_deg, "0", "360"), new[] { "LeftSideDiameterLineAngle_deg" });
            }

            //CircleCenterLatitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.CircleCenterLatitude < -90 || boxModelResult.CircleCenterLatitude > 90)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLatitude, "-90", "90"), new[] { "CircleCenterLatitude" });
            }

            //CircleCenterLongitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.CircleCenterLongitude < -180 || boxModelResult.CircleCenterLongitude > 180)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultCircleCenterLongitude, "-180", "180"), new[] { "CircleCenterLongitude" });
            }

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            //RectLength_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.RectLength_m < 0 || boxModelResult.RectLength_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectLength_m, "0", "100000"), new[] { "RectLength_m" });
            }

            //RectWidth_m (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.RectWidth_m < 0 || boxModelResult.RectWidth_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultRectWidth_m, "0", "100000"), new[] { "RectWidth_m" });
            }

            //LeftSideLineAngle_deg (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideLineAngle_deg < 0 || boxModelResult.LeftSideLineAngle_deg > 360)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineAngle_deg, "0", "360"), new[] { "LeftSideLineAngle_deg" });
            }

            //LeftSideLineStartLatitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideLineStartLatitude < -90 || boxModelResult.LeftSideLineStartLatitude > 90)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLatitude, "-90", "90"), new[] { "LeftSideLineStartLatitude" });
            }

            //LeftSideLineStartLongitude (Double) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LeftSideLineStartLongitude < -180 || boxModelResult.LeftSideLineStartLongitude > 180)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.BoxModelResultLeftSideLineStartLongitude, "-180", "180"), new[] { "LeftSideLineStartLongitude" });
            }

            if (boxModelResult.LastUpdateDate_UTC.Year == 1)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelResult.LastUpdateDate_UTC.Year < 1980)
                {
                boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelResultLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelResultLastUpdateContactTVItemID, boxModelResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(boxModelResult.LastUpdateContactTVText) && boxModelResult.LastUpdateContactTVText.Length > 200)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelResultLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            if (!string.IsNullOrWhiteSpace(boxModelResult.BoxModelResultTypeText) && boxModelResult.BoxModelResultTypeText.Length > 100)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.BoxModelResultBoxModelResultTypeText, "100"), new[] { "BoxModelResultTypeText" });
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public BoxModelResult GetBoxModelResultWithBoxModelResultID(int BoxModelResultID)
        {
            IQueryable<BoxModelResult> boxModelResultQuery = (from c in GetRead()
                                                where c.BoxModelResultID == BoxModelResultID
                                                select c);

            return FillBoxModelResult(boxModelResultQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Create);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Add(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

            return true;
        }
        public bool Delete(BoxModelResult boxModelResult)
        {
            boxModelResult.ValidationResults = Validate(new ValidationContext(boxModelResult), ActionDBTypeEnum.Delete);
            if (boxModelResult.ValidationResults.Count() > 0) return false;

            db.BoxModelResults.Remove(boxModelResult);

            if (!TryToSave(boxModelResult)) return false;

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
        public IQueryable<BoxModelResult> GetRead()
        {
            return db.BoxModelResults.AsNoTracking();
        }
        public IQueryable<BoxModelResult> GetEdit()
        {
            return db.BoxModelResults;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<BoxModelResult> FillBoxModelResult(IQueryable<BoxModelResult> boxModelResultQuery)
        {
            List<BoxModelResult> BoxModelResultList = (from c in boxModelResultQuery
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new BoxModelResult
                                         {
                                             BoxModelResultID = c.BoxModelResultID,
                                             BoxModelID = c.BoxModelID,
                                             BoxModelResultType = c.BoxModelResultType,
                                             Volume_m3 = c.Volume_m3,
                                             Surface_m2 = c.Surface_m2,
                                             Radius_m = c.Radius_m,
                                             LeftSideDiameterLineAngle_deg = c.LeftSideDiameterLineAngle_deg,
                                             CircleCenterLatitude = c.CircleCenterLatitude,
                                             CircleCenterLongitude = c.CircleCenterLongitude,
                                             FixLength = c.FixLength,
                                             FixWidth = c.FixWidth,
                                             RectLength_m = c.RectLength_m,
                                             RectWidth_m = c.RectWidth_m,
                                             LeftSideLineAngle_deg = c.LeftSideLineAngle_deg,
                                             LeftSideLineStartLatitude = c.LeftSideLineStartLatitude,
                                             LeftSideLineStartLongitude = c.LeftSideLineStartLongitude,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (BoxModelResult boxModelResult in BoxModelResultList)
            {
                boxModelResult.BoxModelResultTypeText = enums.GetEnumText_BoxModelResultTypeEnum(boxModelResult.BoxModelResultType);
            }

            return BoxModelResultList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
