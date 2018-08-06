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
    ///     <para>bonjour BoxModelResult</para>
    /// </summary>
    public partial class BoxModelResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public BoxModelResultService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultBoxModelResultID"), new[] { "BoxModelResultID" });
                }

                if (!(from c in db.BoxModelResults select c).Where(c => c.BoxModelResultID == boxModelResult.BoxModelResultID).Any())
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModelResult", "BoxModelResultBoxModelResultID", boxModelResult.BoxModelResultID.ToString()), new[] { "BoxModelResultID" });
                }
            }

            BoxModel BoxModelBoxModelID = (from c in db.BoxModels where c.BoxModelID == boxModelResult.BoxModelID select c).FirstOrDefault();

            if (BoxModelBoxModelID == null)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "BoxModel", "BoxModelResultBoxModelID", boxModelResult.BoxModelID.ToString()), new[] { "BoxModelID" });
            }

            retStr = enums.EnumTypeOK(typeof(BoxModelResultTypeEnum), (int?)boxModelResult.BoxModelResultType);
            if (boxModelResult.BoxModelResultType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultBoxModelResultType"), new[] { "BoxModelResultType" });
            }

            if (boxModelResult.Volume_m3 < 0)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "BoxModelResultVolume_m3", "0"), new[] { "Volume_m3" });
            }

            if (boxModelResult.Surface_m2 < 0)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MinValueIs_, "BoxModelResultSurface_m2", "0"), new[] { "Surface_m2" });
            }

            if (boxModelResult.Radius_m < 0 || boxModelResult.Radius_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRadius_m", "0", "100000"), new[] { "Radius_m" });
            }

            if (boxModelResult.LeftSideDiameterLineAngle_deg != null)
            {
                if (boxModelResult.LeftSideDiameterLineAngle_deg < 0 || boxModelResult.LeftSideDiameterLineAngle_deg > 360)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideDiameterLineAngle_deg", "0", "360"), new[] { "LeftSideDiameterLineAngle_deg" });
                }
            }

            if (boxModelResult.CircleCenterLatitude != null)
            {
                if (boxModelResult.CircleCenterLatitude < -90 || boxModelResult.CircleCenterLatitude > 90)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultCircleCenterLatitude", "-90", "90"), new[] { "CircleCenterLatitude" });
                }
            }

            if (boxModelResult.CircleCenterLongitude != null)
            {
                if (boxModelResult.CircleCenterLongitude < -180 || boxModelResult.CircleCenterLongitude > 180)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultCircleCenterLongitude", "-180", "180"), new[] { "CircleCenterLongitude" });
                }
            }

            if (boxModelResult.RectLength_m < 0 || boxModelResult.RectLength_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRectLength_m", "0", "100000"), new[] { "RectLength_m" });
            }

            if (boxModelResult.RectWidth_m < 0 || boxModelResult.RectWidth_m > 100000)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultRectWidth_m", "0", "100000"), new[] { "RectWidth_m" });
            }

            if (boxModelResult.LeftSideLineAngle_deg != null)
            {
                if (boxModelResult.LeftSideLineAngle_deg < 0 || boxModelResult.LeftSideLineAngle_deg > 360)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineAngle_deg", "0", "360"), new[] { "LeftSideLineAngle_deg" });
                }
            }

            if (boxModelResult.LeftSideLineStartLatitude != null)
            {
                if (boxModelResult.LeftSideLineStartLatitude < -90 || boxModelResult.LeftSideLineStartLatitude > 90)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineStartLatitude", "-90", "90"), new[] { "LeftSideLineStartLatitude" });
                }
            }

            if (boxModelResult.LeftSideLineStartLongitude != null)
            {
                if (boxModelResult.LeftSideLineStartLongitude < -180 || boxModelResult.LeftSideLineStartLongitude > 180)
                {
                    boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "BoxModelResultLeftSideLineStartLongitude", "-180", "180"), new[] { "LeftSideLineStartLongitude" });
                }
            }

            if (boxModelResult.LastUpdateDate_UTC.Year == 1)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "BoxModelResultLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (boxModelResult.LastUpdateDate_UTC.Year < 1980)
                {
                boxModelResult.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "BoxModelResultLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == boxModelResult.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                boxModelResult.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "BoxModelResultLastUpdateContactTVItemID", boxModelResult.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "BoxModelResultLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

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
            return (from c in db.BoxModelResults
                    where c.BoxModelResultID == BoxModelResultID
                    select c).FirstOrDefault();

        }
        public IQueryable<BoxModelResult> GetBoxModelResultList()
        {
            IQueryable<BoxModelResult> BoxModelResultQuery = (from c in db.BoxModelResults select c);

            BoxModelResultQuery = EnhanceQueryStatements<BoxModelResult>(BoxModelResultQuery) as IQueryable<BoxModelResult>;

            return BoxModelResultQuery;
        }
        public BoxModelResultWeb GetBoxModelResultWebWithBoxModelResultID(int BoxModelResultID)
        {
            return FillBoxModelResultWeb().Where(c => c.BoxModelResultID == BoxModelResultID).FirstOrDefault();

        }
        public IQueryable<BoxModelResultWeb> GetBoxModelResultWebList()
        {
            IQueryable<BoxModelResultWeb> BoxModelResultWebQuery = FillBoxModelResultWeb();

            BoxModelResultWebQuery = EnhanceQueryStatements<BoxModelResultWeb>(BoxModelResultWebQuery) as IQueryable<BoxModelResultWeb>;

            return BoxModelResultWebQuery;
        }
        public BoxModelResultReport GetBoxModelResultReportWithBoxModelResultID(int BoxModelResultID)
        {
            return FillBoxModelResultReport().Where(c => c.BoxModelResultID == BoxModelResultID).FirstOrDefault();

        }
        public IQueryable<BoxModelResultReport> GetBoxModelResultReportList()
        {
            IQueryable<BoxModelResultReport> BoxModelResultReportQuery = FillBoxModelResultReport();

            BoxModelResultReportQuery = EnhanceQueryStatements<BoxModelResultReport>(BoxModelResultReportQuery) as IQueryable<BoxModelResultReport>;

            return BoxModelResultReportQuery;
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
        #endregion Functions public Generated CRUD

        #region Functions private Generated BoxModelResultFillWeb
        private IQueryable<BoxModelResultWeb> FillBoxModelResultWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> BoxModelResultTypeEnumList = enums.GetEnumTextOrderedList(typeof(BoxModelResultTypeEnum));

             IQueryable<BoxModelResultWeb> BoxModelResultWebQuery = (from c in db.BoxModelResults
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new BoxModelResultWeb
                    {
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        BoxModelResultTypeText = (from e in BoxModelResultTypeEnumList
                                where e.EnumID == (int?)c.BoxModelResultType
                                select e.EnumText).FirstOrDefault(),
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
                        HasErrors = false,
                        ValidationResults = null,
                    }).AsNoTracking();

            return BoxModelResultWebQuery;
        }
        #endregion Functions private Generated BoxModelResultFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
