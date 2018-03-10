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
    ///     <para>bonjour MWQMSubsector</para>
    /// </summary>
    public partial class MWQMSubsectorService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMSubsectorService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMSubsector mwqmSubsector = validationContext.ObjectInstance as MWQMSubsector;
            mwqmSubsector.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmSubsector.MWQMSubsectorID == 0)
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorMWQMSubsectorID), new[] { "MWQMSubsectorID" });
                }

                if (!GetRead().Where(c => c.MWQMSubsectorID == mwqmSubsector.MWQMSubsectorID).Any())
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMSubsector, CSSPModelsRes.MWQMSubsectorMWQMSubsectorID, mwqmSubsector.MWQMSubsectorID.ToString()), new[] { "MWQMSubsectorID" });
                }
            }

            TVItem TVItemMWQMSubsectorTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.MWQMSubsectorTVItemID select c).FirstOrDefault();

            if (TVItemMWQMSubsectorTVItemID == null)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, (mwqmSubsector.MWQMSubsectorTVItemID == null ? "" : mwqmSubsector.MWQMSubsectorTVItemID.ToString())), new[] { "MWQMSubsectorTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Subsector,
                };
                if (!AllowableTVTypes.Contains(TVItemMWQMSubsectorTVItemID.TVType))
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "Subsector"), new[] { "MWQMSubsectorTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey))
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorSubsectorHistoricKey), new[] { "SubsectorHistoricKey" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.SubsectorHistoricKey) && mwqmSubsector.SubsectorHistoricKey.Length > 20)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorSubsectorHistoricKey, "20"), new[] { "SubsectorHistoricKey" });
            }

            if (!string.IsNullOrWhiteSpace(mwqmSubsector.TideLocationSIDText) && mwqmSubsector.TideLocationSIDText.Length > 20)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.MWQMSubsectorTideLocationSIDText, "20"), new[] { "TideLocationSIDText" });
            }

            if (mwqmSubsector.LastUpdateDate_UTC.Year == 1)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMSubsectorLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmSubsector.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMSubsectorLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmSubsector.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMSubsectorLastUpdateContactTVItemID, (mwqmSubsector.LastUpdateContactTVItemID == null ? "" : mwqmSubsector.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmSubsector.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmSubsector.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMSubsector GetMWQMSubsectorWithMWQMSubsectorID(int MWQMSubsectorID, GetParam getParam)
        {
            IQueryable<MWQMSubsector> mwqmSubsectorQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMSubsectorID == MWQMSubsectorID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmSubsectorQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMWQMSubsectorWeb(mwqmSubsectorQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMSubsectorReport(mwqmSubsectorQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMSubsector> GetMWQMSubsectorList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<MWQMSubsector> mwqmSubsectorQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmSubsectorQuery  = mwqmSubsectorQuery.OrderByDescending(c => c.MWQMSubsectorID);
                        }
                        mwqmSubsectorQuery = mwqmSubsectorQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmSubsectorQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmSubsectorQuery = FillMWQMSubsectorWeb(mwqmSubsectorQuery, FilterAndOrderText).OrderByDescending(c => c.MWQMSubsectorID);
                        }
                        mwqmSubsectorQuery = FillMWQMSubsectorWeb(mwqmSubsectorQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmSubsectorQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmSubsectorQuery = FillMWQMSubsectorReport(mwqmSubsectorQuery, FilterAndOrderText).OrderByDescending(c => c.MWQMSubsectorID);
                        }
                        mwqmSubsectorQuery = FillMWQMSubsectorReport(mwqmSubsectorQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmSubsectorQuery;
                    }
                default:
                    return null;
            }
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
        public bool Delete(MWQMSubsector mwqmSubsector)
        {
            mwqmSubsector.ValidationResults = Validate(new ValidationContext(mwqmSubsector), ActionDBTypeEnum.Delete);
            if (mwqmSubsector.ValidationResults.Count() > 0) return false;

            db.MWQMSubsectors.Remove(mwqmSubsector);

            if (!TryToSave(mwqmSubsector)) return false;

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
        public IQueryable<MWQMSubsector> GetRead()
        {
            return db.MWQMSubsectors.AsNoTracking();
        }
        public IQueryable<MWQMSubsector> GetEdit()
        {
            return db.MWQMSubsectors;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMSubsectorFillWeb
        private IQueryable<MWQMSubsector> FillMWQMSubsectorWeb(IQueryable<MWQMSubsector> mwqmSubsectorQuery, string FilterAndOrderText)
        {
            mwqmSubsectorQuery = (from c in mwqmSubsectorQuery
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
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        MWQMSubsectorWeb = new MWQMSubsectorWeb
                        {
                            SubsectorTVText = SubsectorTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        MWQMSubsectorReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmSubsectorQuery;
        }
        #endregion Functions private Generated MWQMSubsectorFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
