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
        public MWQMLookupMPNService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
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

            //MWQMLookupMPNID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //Tubes10 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes10 < 0 || mwqmLookupMPN.Tubes10 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes10, "0", "5"), new[] { "Tubes10" });
            }

            //Tubes1 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes1 < 0 || mwqmLookupMPN.Tubes1 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes1, "0", "5"), new[] { "Tubes1" });
            }

            //Tubes01 (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.Tubes01 < 0 || mwqmLookupMPN.Tubes01 > 5)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNTubes01, "0", "5"), new[] { "Tubes01" });
            }

            //MPN_100ml (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (mwqmLookupMPN.MPN_100ml < 1 || mwqmLookupMPN.MPN_100ml > 10000)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000"), new[] { "MPN_100ml" });
            }

                //Error: Type not implemented [MWQMLookupMPNWeb] of type [MWQMLookupMPNWeb]
                //Error: Type not implemented [MWQMLookupMPNReport] of type [MWQMLookupMPNReport]
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

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == mwqmLookupMPN.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, mwqmLookupMPN.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                mwqmLookupMPN.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public MWQMLookupMPN GetMWQMLookupMPNWithMWQMLookupMPNID(int MWQMLookupMPNID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.MWQMLookupMPNID == MWQMLookupMPNID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmLookupMPNQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMLookupMPN(mwqmLookupMPNQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<MWQMLookupMPN> GetMWQMLookupMPNList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return mwqmLookupMPNQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillMWQMLookupMPN(mwqmLookupMPNQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
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
            return db.MWQMLookupMPNs.AsNoTracking();
        }
        public IQueryable<MWQMLookupMPN> GetEdit()
        {
            return db.MWQMLookupMPNs;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<MWQMLookupMPN> FillMWQMLookupMPN_Show_Copy_To_MWQMLookupMPNServiceExtra_As_Fill_MWQMLookupMPN(IQueryable<MWQMLookupMPN> mwqmLookupMPNQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
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
                        MWQMLookupMPNReport = new MWQMLookupMPNReport
                        {
                            MWQMLookupMPNReportTest = "MWQMLookupMPNReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return mwqmLookupMPNQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
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
        #endregion Functions private Generated

    }
}
