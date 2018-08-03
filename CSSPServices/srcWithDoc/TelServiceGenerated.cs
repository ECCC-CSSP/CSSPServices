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
        public TelService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TelTelID"), new[] { "TelID" });
                }

                if (!GetRead().Where(c => c.TelID == tel.TelID).Any())
                {
                    tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Tel", "TelTelID", tel.TelID.ToString()), new[] { "TelID" });
                }
            }

            TVItem TVItemTelTVItemID = (from c in db.TVItems where c.TVItemID == tel.TelTVItemID select c).FirstOrDefault();

            if (TVItemTelTVItemID == null)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TelTelTVItemID", tel.TelTVItemID.ToString()), new[] { "TelTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TelTelTVItemID", "Tel"), new[] { "TelTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tel.TelNumber))
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TelTelNumber"), new[] { "TelNumber" });
            }

            if (!string.IsNullOrWhiteSpace(tel.TelNumber) && tel.TelNumber.Length > 50)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "TelTelNumber", "50"), new[] { "TelNumber" });
            }

            retStr = enums.EnumTypeOK(typeof(TelTypeEnum), (int?)tel.TelType);
            if (tel.TelType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TelTelType"), new[] { "TelType" });
            }

            if (tel.LastUpdateDate_UTC.Year == 1)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "TelLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tel.LastUpdateDate_UTC.Year < 1980)
                {
                tel.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "TelLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                tel.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "TelLastUpdateContactTVItemID", tel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "TelLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                tel.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Tel GetTelWithTelID(int TelID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.TelID == TelID
                    select c).FirstOrDefault();

        }
        public IQueryable<Tel> GetTelList()
        {
            IQueryable<Tel> TelQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            TelQuery = EnhanceQueryStatements<Tel>(TelQuery) as IQueryable<Tel>;

            return TelQuery;
        }
        public TelWeb GetTelWebWithTelID(int TelID)
        {
            return FillTelWeb().FirstOrDefault();

        }
        public IQueryable<TelWeb> GetTelWebList()
        {
            IQueryable<TelWeb> TelWebQuery = FillTelWeb();

            TelWebQuery = EnhanceQueryStatements<TelWeb>(TelWebQuery) as IQueryable<TelWeb>;

            return TelWebQuery;
        }
        public TelReport GetTelReportWithTelID(int TelID)
        {
            return FillTelReport().FirstOrDefault();

        }
        public IQueryable<TelReport> GetTelReportList()
        {
            IQueryable<TelReport> TelReportQuery = FillTelReport();

            TelReportQuery = EnhanceQueryStatements<TelReport>(TelReportQuery) as IQueryable<TelReport>;

            return TelReportQuery;
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
            IQueryable<Tel> telQuery = db.Tels.AsNoTracking();

            return telQuery;
        }
        public IQueryable<Tel> GetEdit()
        {
            IQueryable<Tel> telQuery = db.Tels;

            return telQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated TelFillWeb
        private IQueryable<TelWeb> FillTelWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> TelTypeEnumList = enums.GetEnumTextOrderedList(typeof(TelTypeEnum));

             IQueryable<TelWeb>  TelWebQuery = (from c in db.Tels
                let TelTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.TelTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new TelWeb
                    {
                        TelTVItemLanguage = TelTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        TelTypeText = (from e in TelTypeEnumList
                                where e.EnumID == (int?)c.TelType
                                select e.EnumText).FirstOrDefault(),
                        TelID = c.TelID,
                        TelTVItemID = c.TelTVItemID,
                        TelNumber = c.TelNumber,
                        TelType = c.TelType,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return TelWebQuery;
        }
        #endregion Functions private Generated TelFillWeb

        #region Functions private Generated TryToSave
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
        #endregion Functions private Generated TryToSave

    }
}
