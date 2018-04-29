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
    ///     <para>bonjour MWQMLookupMPN</para>
    /// </summary>
    public partial class MWQMLookupMPNService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
            : base(getParam, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            MWQMLookupMPN mwqmLookupMPN = validationContext.ObjectInstance as MWQMLookupMPN;
            mwqmLookupMPN.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (mwqmLookupMPN.MWQMLookupMPNID == 0)
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMLookupMPNMWQMLookupMPNID), new[] { "MWQMLookupMPNID" });
                }

                if (!GetRead().Where(c => c.MWQMLookupMPNID == mwqmLookupMPN.MWQMLookupMPNID).Any())
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.MWQMLookupMPN, CSSPModelsRes.MWQMLookupMPNMWQMLookupMPNID, mwqmLookupMPN.MWQMLookupMPNID.ToString()), new[] { "MWQMLookupMPNID" });
                }
            }

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes10, "0", "5"), new[] { "Tubes10" });
            }

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes1, "0", "5"), new[] { "Tubes1" });
            }

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes01, "0", "5"), new[] { "Tubes01" });
            }

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 10000)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000"), new[] { "MPN_100ml" });
            }

            if (mwqmLookupMPN.LastUpdateDate_UTC.Year == 1)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.MWQMLookupMPNLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (mwqmLookupMPN.LastUpdateDate_UTC.Year < 1980)
                {
                mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.MWQMLookupMPNLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmLookupMPN.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, (mwqmLookupMPN.LastUpdateContactTVItemID == null ? "" : mwqmLookupMPN.LastUpdateContactTVItemID.ToString())), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    mwqmLookupMPN.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMLookupMPN GetMWQMLookupMPNWithMWQMLookupMPNID(int MWQMLookupMPNID, GetParam getParam)
        {
            IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMLookupMPNID == MWQMLookupMPNID
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmLookupMPNQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillMWQMLookupMPNWeb(mwqmLookupMPNQuery, "").FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMLookupMPNReport(mwqmLookupMPNQuery, "").FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMLookupMPN> GetMWQMLookupMPNList(GetParam getParam, string FilterAndOrderText = "")
        {
            IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery = (from c in (getParam.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                select c);

            switch (getParam.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmLookupMPNQuery  = mwqmLookupMPNQuery.OrderByDescending(c => c.MWQMLookupMPNID);
                        }
                        mwqmLookupMPNQuery = mwqmLookupMPNQuery.Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmLookupMPNQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmLookupMPNQuery = FillMWQMLookupMPNWeb(mwqmLookupMPNQuery, FilterAndOrderText).OrderByDescending(c => c.MWQMLookupMPNID);
                        }
                        mwqmLookupMPNQuery = FillMWQMLookupMPNWeb(mwqmLookupMPNQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmLookupMPNQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        if (!getParam.OrderAscending)
                        {
                            mwqmLookupMPNQuery = FillMWQMLookupMPNReport(mwqmLookupMPNQuery, FilterAndOrderText).OrderByDescending(c => c.MWQMLookupMPNID);
                        }
                        mwqmLookupMPNQuery = FillMWQMLookupMPNReport(mwqmLookupMPNQuery, FilterAndOrderText).Skip(getParam.Skip).Take(getParam.Take);
                        return mwqmLookupMPNQuery;
                    }
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Create);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Add(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool Delete(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Delete);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Remove(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public bool Update(MWQMLookupMPN mwqmLookupMPN)
        {
            mwqmLookupMPN.ValidationResults = Validate(new ValidationContext(mwqmLookupMPN), ActionDBTypeEnum.Update);
            if (mwqmLookupMPN.ValidationResults.Count() > 0) return false;

            db.MWQMLookupMPNs.Update(mwqmLookupMPN);

            if (!TryToSave(mwqmLookupMPN)) return false;

            return true;
        }
        public IQueryable<MWQMLookupMPN> GetRead()
        {
            if (GetParam.OrderAscending)
            {
                return db.MWQMLookupMPNs.AsNoTracking();
            }
            else
            {
                return db.MWQMLookupMPNs.AsNoTracking().OrderByDescending(c => c.MWQMLookupMPNID);
            }
        }
        public IQueryable<MWQMLookupMPN> GetEdit()
        {
            if (GetParam.OrderAscending)
            {
                return db.MWQMLookupMPNs;
            }
            else
            {
                return db.MWQMLookupMPNs.OrderByDescending(c => c.MWQMLookupMPNID);
            }
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated MWQMLookupMPNFillWeb
        private IQueryable<MWQMLookupMPN> FillMWQMLookupMPNWeb(IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery, string FilterAndOrderText)
        {
            mwqmLookupMPNQuery = (from c in mwqmLookupMPNQuery
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new MWQMLookupMPN
                    {
                        MWQMLookupMPNID = c.MWQMLookupMPNID,
                        Tubes10 = c.Tubes10,
                        Tubes1 = c.Tubes1,
                        Tubes01 = c.Tubes01,
                        MPN_100ml = c.MPN_100ml,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        MWQMLookupMPNWeb = new MWQMLookupMPNWeb
                        {
                            LastUpdateContactTVText = LastUpdateContactTVText,
                        },
                        MWQMLookupMPNReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmLookupMPNQuery;
        }
        #endregion Functions private Generated MWQMLookupMPNFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(MWQMLookupMPN mwqmLookupMPN)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                mwqmLookupMPN.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}
