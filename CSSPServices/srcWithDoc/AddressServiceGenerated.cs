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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressAddressID), new[] { "AddressID" });
                }

                if (!GetRead().Where(c => c.AddressID == address.AddressID).Any())
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Address, CSSPModelsRes.AddressAddressID, address.AddressID.ToString()), new[] { "AddressID" });
                }
            }

            TVItem TVItemAddressTVItemID = (from c in db.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();

            if (TVItemAddressTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressAddressTVItemID, address.AddressTVItemID.ToString()), new[] { "AddressTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressAddressTVItemID, "Address"), new[] { "AddressTVItemID" });
                }
            }

            retStr = enums.EnumTypeOK(typeof(AddressTypeEnum), (int?)address.AddressType);
            if (address.AddressType == AddressTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressAddressType), new[] { "AddressType" });
            }

            TVItem TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();

            if (TVItemCountryTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressCountryTVItemID, address.CountryTVItemID.ToString()), new[] { "CountryTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressCountryTVItemID, "Country"), new[] { "CountryTVItemID" });
                }
            }

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressProvinceTVItemID, address.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressProvinceTVItemID, "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressMunicipalityTVItemID, address.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressMunicipalityTVItemID, "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && address.StreetName.Length > 200)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AddressStreetName, "200"), new[] { "StreetName" });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && address.StreetNumber.Length > 50)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AddressStreetNumber, "50"), new[] { "StreetNumber" });
            }

            if (address.StreetType != null)
            {
                retStr = enums.EnumTypeOK(typeof(StreetTypeEnum), (int?)address.StreetType);
                if (address.StreetType == StreetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressStreetType), new[] { "StreetType" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode) && (address.PostalCode.Length < 6 || address.PostalCode.Length > 11))
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.AddressPostalCode, "6", "11"), new[] { "PostalCode" });
            }

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 10 || address.GoogleAddressText.Length > 200))
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.AddressGoogleAddressText, "10", "200"), new[] { "GoogleAddressText" });
            }

            if (address.LastUpdateDate_UTC.Year == 1)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (address.LastUpdateDate_UTC.Year < 1980)
                {
                address.HasErrors = true;
                    yield return new ValidationResult(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AddressLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                address.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressLastUpdateContactTVItemID, address.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
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
                    yield return new ValidationResult(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
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
            IQueryable<Address> addressQuery = (from c in (Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead())
                                                where c.AddressID == AddressID
                                                select c);

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    return addressQuery.FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityWeb:
                    return FillAddressWeb(addressQuery).FirstOrDefault();
                case EntityQueryDetailTypeEnum.EntityReport:
                    return FillAddressReport(addressQuery).FirstOrDefault();
                default:
                    return null;
            }
        }
        public IQueryable<Address> GetAddressList()
        {
            IQueryable<Address> addressQuery = Query.EntityQueryType == EntityQueryTypeEnum.WithTracking ? GetEdit() : GetRead();

            switch (Query.EntityQueryDetailType)
            {
                case EntityQueryDetailTypeEnum.EntityOnly:
                    {
                        addressQuery = EnhanceQueryStatements<Address>(addressQuery) as IQueryable<Address>;

                        return addressQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityWeb:
                    {
                        addressQuery = FillAddressWeb(addressQuery);

                        addressQuery = EnhanceQueryStatements<Address>(addressQuery) as IQueryable<Address>;

                        return addressQuery;
                    }
                case EntityQueryDetailTypeEnum.EntityReport:
                    {
                        addressQuery = FillAddressReport(addressQuery);

                        addressQuery = EnhanceQueryStatements<Address>(addressQuery) as IQueryable<Address>;

                        return addressQuery;
                    }
                default:
                    {
                        addressQuery = addressQuery.Where(c => c.AddressID == 0);

                        return addressQuery;
                    }
            }
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
        private IQueryable<Address> FillAddressWeb(IQueryable<Address> addressQuery)
        {
            Enums enums = new Enums(LanguageRequest);

            List<EnumIDAndText> AddressTypeEnumList = enums.GetEnumTextOrderedList(typeof(AddressTypeEnum));
            List<EnumIDAndText> StreetTypeEnumList = enums.GetEnumTextOrderedList(typeof(StreetTypeEnum));

            addressQuery = (from c in addressQuery
                let ParentTVItemID = (from cl in db.TVItems
                    where cl.TVItemID == c.AddressTVItemID
                    select cl.ParentID).FirstOrDefault()
                let AddressTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.AddressTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let CountryTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.CountryTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let ProvinceTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.ProvinceTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let MunicipalityTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.MunicipalityTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                let LastUpdateContactTVText = (from cl in db.TVItemLanguages
                    where cl.TVItemID == c.LastUpdateContactTVItemID
                    && cl.Language == LanguageRequest
                    select cl.TVText).FirstOrDefault()
                    select new Address
                    {
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
                        AddressWeb = new AddressWeb
                        {
                            ParentTVItemID = ParentTVItemID,
                            AddressTVText = AddressTVText,
                            CountryTVText = CountryTVText,
                            ProvinceTVText = ProvinceTVText,
                            MunicipalityTVText = MunicipalityTVText,
                            LastUpdateContactTVText = LastUpdateContactTVText,
                            AddressTypeText = (from e in AddressTypeEnumList
                                where e.EnumID == (int?)c.AddressType
                                select e.EnumText).FirstOrDefault(),
                            StreetTypeText = (from e in StreetTypeEnumList
                                where e.EnumID == (int?)c.StreetType
                                select e.EnumText).FirstOrDefault(),
                        },
                        AddressReport = null,
                        HasErrors = false,
                        ValidationResults = null,
                    });

            return addressQuery;
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
