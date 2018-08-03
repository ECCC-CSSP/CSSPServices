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
    ///     <para>bonjour Address</para>
    /// </summary>
    public partial class AddressService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AddressService(Query query, CSSPWebToolsDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Address address = validationContext.ObjectInstance as Address;
            address.HasErrors = false;

            if (actionDBType == ActionDBTypeEnum.Update || actionDBType == ActionDBTypeEnum.Delete)
            {
                if (address.AddressID == 0)
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AddressAddressID"), new[] { "AddressID" });
                }

                if (!GetRead().Where(c => c.AddressID == address.AddressID).Any())
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Address", "AddressAddressID", address.AddressID.ToString()), new[] { "AddressID" });
                }
            }

            TVItem TVItemAddressTVItemID = (from c in db.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();

            if (TVItemAddressTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressAddressTVItemID", address.AddressTVItemID.ToString()), new[] { "AddressTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Address,
                };
                if (!AllowableTVTypes.Contains(TVItemAddressTVItemID.TVType))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AddressAddressTVItemID", "Address"), new[] { "AddressTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AddressTypeEnum), (int?)address.AddressType);
            if (address.AddressType == null || !string.IsNullOrWhiteSpace(retStr))
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AddressAddressType"), new[] { "AddressType" });
            }

            TVItem TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();

            if (TVItemCountryTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressCountryTVItemID", address.CountryTVItemID.ToString()), new[] { "CountryTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Country,
                };
                if (!AllowableTVTypes.Contains(TVItemCountryTVItemID.TVType))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AddressCountryTVItemID", "Country"), new[] { "CountryTVItemID" });
                }
            }

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressProvinceTVItemID", address.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Province,
                };
                if (!AllowableTVTypes.Contains(TVItemProvinceTVItemID.TVType))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AddressProvinceTVItemID", "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressMunicipalityTVItemID", address.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Municipality,
                };
                if (!AllowableTVTypes.Contains(TVItemMunicipalityTVItemID.TVType))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AddressMunicipalityTVItemID", "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && address.StreetName.Length > 200)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "AddressStreetName", "200"), new[] { "StreetName" });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && address.StreetNumber.Length > 50)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, "AddressStreetNumber", "50"), new[] { "StreetNumber" });
            }

            if (address.StreetType != null)
            {
                retStr = enums.EnumTypeOK(typeof(StreetTypeEnum), (int?)address.StreetType);
                if (address.StreetType == null || !string.IsNullOrWhiteSpace(retStr))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AddressStreetType"), new[] { "StreetType" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode) && (address.PostalCode.Length < 6 || address.PostalCode.Length > 11))
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "AddressPostalCode", "6", "11"), new[] { "PostalCode" });
            }

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 10 || address.GoogleAddressText.Length > 200))
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "AddressGoogleAddressText", "10", "200"), new[] { "GoogleAddressText" });
            }

            if (address.LastUpdateDate_UTC.Year == 1)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, "AddressLastUpdateDate_UTC"), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (address.LastUpdateDate_UTC.Year < 1980)
                {
                address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AddressLastUpdateDate_UTC", "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressLastUpdateContactTVItemID", address.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                List<TVTypeEnum> AllowableTVTypes = new List<TVTypeEnum>()
                {
                    TVTypeEnum.Contact,
                };
                if (!AllowableTVTypes.Contains(TVItemLastUpdateContactTVItemID.TVType))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, "AddressLastUpdateContactTVItemID", "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                address.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public Generated Get
        public Address GetAddressWithAddressID(int AddressID)
        {
            return (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                    where c.AddressID == AddressID
                    select c).FirstOrDefault();

        }
        public IQueryable<Address> GetAddressList()
        {
            IQueryable<Address> AddressQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            AddressQuery = EnhanceQueryStatements<Address>(AddressQuery) as IQueryable<Address>;

            return AddressQuery;
        }
        public AddressWeb GetAddressWebWithAddressID(int AddressID)
        {
            return FillAddressWeb().FirstOrDefault();

        }
        public IQueryable<AddressWeb> GetAddressWebList()
        {
            IQueryable<AddressWeb> AddressWebQuery = FillAddressWeb();

            AddressWebQuery = EnhanceQueryStatements<AddressWeb>(AddressWebQuery) as IQueryable<AddressWeb>;

            return AddressWebQuery;
        }
        public AddressReport GetAddressReportWithAddressID(int AddressID)
        {
            return FillAddressReport().FirstOrDefault();

        }
        public IQueryable<AddressReport> GetAddressReportList()
        {
            IQueryable<AddressReport> AddressReportQuery = FillAddressReport();

            AddressReportQuery = EnhanceQueryStatements<AddressReport>(AddressReportQuery) as IQueryable<AddressReport>;

            return AddressReportQuery;
        }
        #endregion Functions public Generated Get

        #region Functions public Generated CRUD
        public bool Add(Address address)
        {
            address.ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Create);
            if (address.ValidationResults.Count() > 0) return false;

            db.Addresses.Add(address);

            if (!TryToSave(address)) return false;

            return true;
        }
        public bool Delete(Address address)
        {
            address.ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Delete);
            if (address.ValidationResults.Count() > 0) return false;

            db.Addresses.Remove(address);

            if (!TryToSave(address)) return false;

            return true;
        }
        public bool Update(Address address)
        {
            address.ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Update);
            if (address.ValidationResults.Count() > 0) return false;

            db.Addresses.Update(address);

            if (!TryToSave(address)) return false;

            return true;
        }
        public IQueryable<Address> GetRead()
        {
            IQueryable<Address> addressQuery = db.Addresses.AsNoTracking();

            return addressQuery;
        }
        public IQueryable<Address> GetEdit()
        {
            IQueryable<Address> addressQuery = db.Addresses;

            return addressQuery;
        }
        #endregion Functions public Generated CRUD

        #region Functions private Generated AddressFillWeb
        private IQueryable<AddressWeb> FillAddressWeb()
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AddressTypeEnumList = enums.GetEnumTextOrderedList(typeof(AddressTypeEnum));
            List<EnumIDAndText> StreetTypeEnumList = enums.GetEnumTextOrderedList(typeof(StreetTypeEnum));

             IQueryable<AddressWeb>  AddressWebQuery = (from c in db.Addresses
                let AddressTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.AddressTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let CountryTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CountryTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let ProvinceTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ProvinceTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let MunicipalityTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                let LastUpdateContactTVItemLanguage = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl).FirstOrDefault()
                    select new AddressWeb
                    {
                        AddressTVItemLanguage = AddressTVItemLanguage,
                        CountryTVItemLanguage = CountryTVItemLanguage,
                        ProvinceTVItemLanguage = ProvinceTVItemLanguage,
                        MunicipalityTVItemLanguage = MunicipalityTVItemLanguage,
                        LastUpdateContactTVItemLanguage = LastUpdateContactTVItemLanguage,
                        AddressTypeText = (from e in AddressTypeEnumList
                                where e.EnumID == (int?)c.AddressType
                                select e.EnumText).FirstOrDefault(),
                        StreetTypeText = (from e in StreetTypeEnumList
                                where e.EnumID == (int?)c.StreetType
                                select e.EnumText).FirstOrDefault(),
                        AddressID = c.AddressID,
                        AddressTVItemID = c.AddressTVItemID,
                        AddressType = c.AddressType,
                        CountryTVItemID = c.CountryTVItemID,
                        ProvinceTVItemID = c.ProvinceTVItemID,
                        MunicipalityTVItemID = c.MunicipalityTVItemID,
                        StreetName = c.StreetName,
                        StreetNumber = c.StreetNumber,
                        StreetType = c.StreetType,
                        PostalCode = c.PostalCode,
                        GoogleAddressText = c.GoogleAddressText,
                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return AddressWebQuery;
        }
        #endregion Functions private Generated AddressFillWeb

        #region Functions private Generated TryToSave
        private bool TryToSave(Address address)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private Generated TryToSave

    }
}