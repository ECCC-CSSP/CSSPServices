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
        public BoxModelResultService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (boxModelResult.BoxModelResultID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultID), new[] { ModelsRes.BoxModelResultBoxModelResultID });
                }
            }

            //BoxModelResultID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //BoxModelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.BoxModelID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultBoxModelID, "1"), new[] { ModelsRes.BoxModelResultBoxModelID });
            }

            if (!((from c in db.BoxModels where c.BoxModelID == boxModelResult.BoxModelID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.BoxModel, ModelsRes.BoxModelResultBoxModelID, boxModelResult.BoxModelID.ToString()), new[] { ModelsRes.BoxModelResultBoxModelID });
            }

            retStr = enums.BoxModelResultTypeOK(boxModelResult.BoxModelResultType);
            if (boxModelResult.BoxModelResultType == BoxModelResultTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultBoxModelResultType), new[] { ModelsRes.BoxModelResultBoxModelResultType });
            }

            //Volume_m3 (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Volume_m3 has no Range Attribute

            //Surface_m2 (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Surface_m2 has no Range Attribute

            //Radius_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Radius_m has no Range Attribute

            //LeftSideDiameterLineAngle_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //LeftSideDiameterLineAngle_deg has no Range Attribute

            //CircleCenterLatitude (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //CircleCenterLatitude has no Range Attribute

            //CircleCenterLongitude (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //CircleCenterLongitude has no Range Attribute

            //FixLength (bool) is required but no testing needed 

            //FixWidth (bool) is required but no testing needed 

            //RectLength_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //RectLength_m has no Range Attribute

            //RectWidth_m (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //RectWidth_m has no Range Attribute

            //LeftSideLineAngle_deg (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //LeftSideLineAngle_deg has no Range Attribute

            //LeftSideLineStartLatitude (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //LeftSideLineStartLatitude has no Range Attribute

            //LeftSideLineStartLongitude (Single) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //LeftSideLineStartLongitude has no Range Attribute

            if (boxModelResult.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.BoxModelResultLastUpdateDate_UTC), new[] { ModelsRes.BoxModelResultLastUpdateDate_UTC });
            }

            if (boxModelResult.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.BoxModelResultLastUpdateDate_UTC, "1980"), new[] { ModelsRes.BoxModelResultLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (boxModelResult.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.BoxModelResultLastUpdateContactTVItemID, "1"), new[] { ModelsRes.BoxModelResultLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == boxModelResult.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.BoxModelResultLastUpdateContactTVItemID, boxModelResult.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.BoxModelResultLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
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
