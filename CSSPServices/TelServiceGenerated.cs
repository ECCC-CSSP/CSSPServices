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

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (tel.TelID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelID), new[] { "TelID" });
                }
            }

            //TelID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //TelTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemTelTVItemID = (from c in db.TVItems where c.TVItemID == tel.TelTVItemID select c).FirstOrDefault();

            if (TVItemTelTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TelTelTVItemID, tel.TelTVItemID.ToString()), new[] { "TelTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Tel,
                };
                if (!AllowableTVTypes.Contains(TVItemTelTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TelTelTVItemID, "Tel"), new[] { "TelTVItemID" });
                }
            }

            if (string.IsNullOrWhiteSpace(tel.TelNumber))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelNumber), new[] { "TelNumber" });
            }

            if (!string.IsNullOrWhiteSpace(tel.TelNumber) && tel.TelNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TelTelNumber, "50"), new[] { "TelNumber" });
            }

            retStr = enums.TelTypeOK(tel.TelType);
            if (tel.TelType == TelTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelTelType), new[] { "TelType" });
            }

            if (tel.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.TelLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (tel.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.TelLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == tel.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TelLastUpdateContactTVItemID, tel.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TelLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(tel.TelTypeText) && tel.TelTypeText.Length > 100)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TelTelTypeText, "100"), new[] { "TelTypeText" });
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Tel GetTelWithTelID(int TelID)
        {
            IQueryable<Tel> telQuery = (from c in GetRead()
                                                where c.TelID == TelID
                                                select c);

            return FillTel(telQuery).FirstOrDefault();
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
        public bool AddRange(List<Tel> telList)
        {
            foreach (Tel tel in telList)
            {
                tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Create);
                if (tel.ValidationResults.Count() > 0) return false;
            }

            db.Tels.AddRange(telList);

            if (!TryToSaveRange(telList)) return false;

            return true;
        }
        public bool Delete(Tel tel)
        {
            if (!db.Tels.Where(c => c.TelID == tel.TelID).Any())
            {
                tel.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", tel.TelID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Tels.Remove(tel);

            if (!TryToSave(tel)) return false;

            return true;
        }
        public bool DeleteRange(List<Tel> telList)
        {
            foreach (Tel tel in telList)
            {
                if (!db.Tels.Where(c => c.TelID == tel.TelID).Any())
                {
                    telList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Tel", "TelID", tel.TelID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Tels.RemoveRange(telList);

            if (!TryToSaveRange(telList)) return false;

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
        public bool UpdateRange(List<Tel> telList)
        {
            foreach (Tel tel in telList)
            {
                tel.ValidationResults = Validate(new ValidationContext(tel), ActionDBTypeEnum.Update);
                if (tel.ValidationResults.Count() > 0) return false;
            }
            db.Tels.UpdateRange(telList);

            if (!TryToSaveRange(telList)) return false;

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
        private List<Tel> FillTel(IQueryable<Tel> telQuery)
        {
            List<Tel> TelList = (from c in telQuery
                                         select new Tel
                                         {
                                             TelID = c.TelID,
                                             TelTVItemID = c.TelTVItemID,
                                             TelNumber = c.TelNumber,
                                             TelType = c.TelType,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             ValidationResults = null,
                                         }).ToList();

            Enums enums = new Enums(LanguageRequest);

            foreach (Tel tel in TelList)
            {
                tel.TelTypeText = enums.GetEnumText_TelTypeEnum(tel.TelType);
            }

            return TelList;
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
        private bool TryToSaveRange(List<Tel> telList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                telList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated

    }
}
