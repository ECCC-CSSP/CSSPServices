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
    ///     <para>bonjour Tel</para>
    /// </summary>
    public partial class TelService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TelService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Tel tel = validationContext.ObjectInstance as Tel;
            tel.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (tel.TelID == 0)
                {
                    tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelTelID), new[] { "TelID" });
                }

                if (!GetRead().Where(c => c.TelID == tel.TelID).Any())
                {
                    tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Tel, CSSPModelsRes.TelTelID, tel.TelID.ToString()), new[] { "TelID" });
                }
            }

            //TelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TelTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTelTVItemID = (from c in db.TVItems where c.TVItemID == tel.TelTVItemID select c).FirstOrDefault();

            if (TVItemTelTVItemID == null)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TelTelTVItemID, tel.TelTVItemID.ToString()), new[] { "TelTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Tel,
                };
                if (!AllowableTVTypes.Contains(TVItemTelTVItemID.TVType))
                {
                    tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TelTelTVItemID, "Tel"), new[] { "TelTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tel.TelNumber))
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelTelNumber), new[] { "TelNumber" });
            }

            if (!string.IsNullOrWhiteSpace(tel.TelNumber) && tel.TelNumber.Length > 50)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TelTelNumber, "50"), new[] { "TelNumber" });
            }

            retStr = enums.EnumTypeOK(typeof(TelTypeEnum), (int?)tel.TelType);
            if (tel.TelType == TelTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelTelType), new[] { "TelType" });
            }

                //Error: Type not implemented [TelWeb] of type [TelWeb]
                //Error: Type not implemented [TelReport] of type [TelReport]
            if (tel.LastUpdateDate_UTC.Year == 1)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TelLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tel.LastUpdateDate_UTC.Year < 1980)
                {
                tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.TelLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TelLastUpdateContactTVItemID, tel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TelLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            //HasErrors (bool) is required but no testing needed 

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tel.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Tel GetTelWithTelID(int TelID,
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<Tel> telQuery = (from c in (EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.TelID == TelID
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return telQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTel(telQuery, "", EntityQueryDetailType).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Tel> GetTelList(string FilterAndOrderText = "",
            EntityQueryDetailTypeEnum EntityQueryDetailType = EntityQueryDetailTypeEnum.EntityOnly,
            EntityQueryTypeEnum EntityQueryType = EntityQueryTypeEnum.AsNoTracking)
        {
            IQueryable<Tel> telQuery = (from c in GetRead()
                                                select c);

            switch (EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return telQuery;
                case EntityQueryDetailTypeEnum.EntityWeb:
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillTel(telQuery, FilterAndOrderText, EntityQueryDetailType).Take(MaxGetCount);
                default:
                    return null;
            }
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Tel tel)
        {
            tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Create);
            if (tel.ValidationResults.Count() > 0) return false;

            db.Tels.Add(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public bool Delete(Tel tel)
        {
            tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Delete);
            if (tel.ValidationResults.Count() > 0) return false;

            db.Tels.Remove(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public bool Update(Tel tel)
        {
            tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Update);
            if (tel.ValidationResults.Count() > 0) return false;

            db.Tels.Update(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public IQueryable<Tel> GetRead()
        {
            return db.Tels.AsNoTracking();
        }
        public IQueryable<Tel> GetEdit()
        {
            return db.Tels;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated Fill Class
        // --------------------------------------------------------------------------------
        // You should copy to AddressServiceExtra or sync with it then remove this function
        // --------------------------------------------------------------------------------
        private IQueryable<Tel> FillTel_Show_Copy_To_TelServiceExtra_As_Fill_Tel(IQueryable<Tel> telQuery, string FilterAndOrderText, EntityQueryDetailTypeEnum EntityQueryDetailType)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TelTypeEnumList = enums.GetEnumTextOrderedList(typeof(TelTypeEnum));

            telQuery = (from c in telQuery
                let TelTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TelTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Tel
                    {
                        TelID = c.TelID,
                        TelTVItemID = c.TelTVItemID,
                        TelNumber = c.TelNumber,
                        TelType = c.TelType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        TelWeb = new TelWeb
                        {
                            TelTVText = TelTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            TelTypeText = (from e in TelTypeEnumList
                                where e.EnumID == (int?)c.TelType
                                select e.EnumText).FirstOrDefault(),
                        },
                        TelReport = new TelReport
                        {
                            TelReportTest = "TelReportTest",
                        },
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return telQuery;
        }
        #endregion Functions private Generated Fill Class

        #region Functions private Generated
        private bool TryToSave(Tel tel)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                tel.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
