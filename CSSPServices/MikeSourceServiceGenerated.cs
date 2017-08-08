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
    public partial class MikeSourceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MikeSourceService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MikeSource mikeSource = validationContext.ObjectInstance as MikeSource;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (mikeSource.MikeSourceID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceMikeSourceID), new[] { "MikeSourceID" });
                }
            }

            //MikeSourceID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //MikeSourceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMikeSourceTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.MikeSourceTVItemID select c).FirstOrDefault();

            if (TVItemMikeSourceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceMikeSourceTVItemID, mikeSource.MikeSourceTVItemID.ToString()), new[] { "MikeSourceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.MikeSource,
                };
                if (!AllowableTVTypes.Contains(TVItemMikeSourceTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeSourceMikeSourceTVItemID, "MikeSource"), new[] { "MikeSourceTVItemID" });
                }
            }

            //IsContinuous (bool) is required but no testing needed 

            //Include (bool) is required but no testing needed 

            //IsRiver (bool) is required but no testing needed 

            if (string.IsNullOrWhiteSpace(mikeSource.SourceNumberString))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceSourceNumberString), new[] { "SourceNumberString" });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.SourceNumberString) && mikeSource.SourceNumberString.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceSourceNumberString, "50"), new[] { "SourceNumberString" });
            }

            if (mikeSource.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mikeSource.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.MikeSourceLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mikeSource.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MikeSourceLastUpdateContactTVItemID, mikeSource.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MikeSourceLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.MikeSourceTVText) && mikeSource.MikeSourceTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceMikeSourceTVText, "200"), new[] { "MikeSourceTVText" });
            }

            if (!string.IsNullOrWhiteSpace(mikeSource.LastUpdateContactTVText) && mikeSource.LastUpdateContactTVText.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeSourceLastUpdateContactTVText, "200"), new[] { "LastUpdateContactTVText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MikeSource GetMikeSourceWithMikeSourceID(int MikeSourceID)
        {
            IQueryable<MikeSource> mikeSourceQuery = (from c in GetRead()
                                                where c.MikeSourceID == MikeSourceID
                                                select c);

            return FillMikeSource(mikeSourceQuery).FirstOrDefault();
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Add(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool AddRange(List<MikeSource> mikeSourceList)
        {
            foreach (MikeSource mikeSource in mikeSourceList)
            {
                mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Create);
                if (mikeSource.ValidationResults.Count() > 0) return false;
            }

            db.MikeSources.AddRange(mikeSourceList);

            if (!TryToSaveRange(mikeSourceList)) return false;

            return true;
        }
        public bool Delete(MikeSource mikeSource)
        {
            if (!db.MikeSources.Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
            {
                mikeSource.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString())) }.AsEnumerable();
                return false;
            }

            db.MikeSources.Remove(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool DeleteRange(List<MikeSource> mikeSourceList)
        {
            foreach (MikeSource mikeSource in mikeSourceList)
            {
                if (!db.MikeSources.Where(c => c.MikeSourceID == mikeSource.MikeSourceID).Any())
                {
                    mikeSourceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "MikeSource", "MikeSourceID", mikeSource.MikeSourceID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.MikeSources.RemoveRange(mikeSourceList);

            if (!TryToSaveRange(mikeSourceList)) return false;

            return true;
        }
        public bool Update(MikeSource mikeSource)
        {
            mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
            if (mikeSource.ValidationResults.Count() > 0) return false;

            db.MikeSources.Update(mikeSource);

            if (!TryToSave(mikeSource)) return false;

            return true;
        }
        public bool UpdateRange(List<MikeSource> mikeSourceList)
        {
            foreach (MikeSource mikeSource in mikeSourceList)
            {
                mikeSource.ValidationResults = Validate(new ValidationContext(mikeSource), ActionDBTypeEnum.Update);
                if (mikeSource.ValidationResults.Count() > 0) return false;
            }
            db.MikeSources.UpdateRange(mikeSourceList);

            if (!TryToSaveRange(mikeSourceList)) return false;

            return true;
        }
        public IQueryable<MikeSource> GetRead()
        {
            return db.MikeSources.AsNoTracking();
        }
        public IQueryable<MikeSource> GetEdit()
        {
            return db.MikeSources;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        private List<MikeSource> FillMikeSource(IQueryable<MikeSource> mikeSourceQuery)
        {
            List<MikeSource> MikeSourceList = (from c in mikeSourceQuery
                                         let MikeSourceTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.MikeSourceTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                                                              where cl.TVItemID == c.LastUpdateContactTVItemID
                                                              && cl.Language == LanguageRequest
                                                              select cl.TVText).FirstOrDefault()
                                         select new MikeSource
                                         {
                                             MikeSourceID = c.MikeSourceID,
                                             MikeSourceTVItemID = c.MikeSourceTVItemID,
                                             IsContinuous = c.IsContinuous,
                                             Include = c.Include,
                                             IsRiver = c.IsRiver,
                                             SourceNumberString = c.SourceNumberString,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             MikeSourceTVText = MikeSourceTVText,
                                             LastUpdateContactTVText = LastUpdateContactTVText,
                                             ValidationResults = null,
                                         }).ToList();

            return MikeSourceList;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(MikeSource mikeSource)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSource.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        private bool TryToSaveRange(List<MikeSource> mikeSourceList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mikeSourceList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
