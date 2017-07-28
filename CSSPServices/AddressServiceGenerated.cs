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
    public partial class AddressService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AddressService(LanguageEnum LanguageRequest, CSSPWebToolsDBContext db, int ContactID)
            : base(LanguageRequest, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Address address = validationContext.ObjectInstance as Address;

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (address.AddressID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressID), new[] { "AddressID" });
                }
            }

            //AddressID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            //AddressTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemAddressTVItemID = (from c in db.TVItems where c.TVItemID == address.AddressTVItemID select c).FirstOrDefault();

            if (TVItemAddressTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressAddressTVItemID, address.AddressTVItemID.ToString()), new[] { "AddressTVItemID" });
            }
            else
            {
                if (TVItemAddressTVItemID.TVType != TVTypeEnum.Address)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AddressAddressTVItemID, "Address"), new[] { "AddressTVItemID" });
                }
            }

            retStr = enums.AddressTypeOK(address.AddressType);
            if (address.AddressType == AddressTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressType), new[] { "AddressType" });
            }

            //CountryTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemCountryTVItemID = (from c in db.TVItems where c.TVItemID == address.CountryTVItemID select c).FirstOrDefault();

            if (TVItemCountryTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressCountryTVItemID, address.CountryTVItemID.ToString()), new[] { "CountryTVItemID" });
            }
            else
            {
                if (TVItemCountryTVItemID.TVType != TVTypeEnum.Country)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AddressCountryTVItemID, "Country"), new[] { "CountryTVItemID" });
                }
            }

            //ProvinceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemProvinceTVItemID = (from c in db.TVItems where c.TVItemID == address.ProvinceTVItemID select c).FirstOrDefault();

            if (TVItemProvinceTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressProvinceTVItemID, address.ProvinceTVItemID.ToString()), new[] { "ProvinceTVItemID" });
            }
            else
            {
                if (TVItemProvinceTVItemID.TVType != TVTypeEnum.Province)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AddressProvinceTVItemID, "Province"), new[] { "ProvinceTVItemID" });
                }
            }

            //MunicipalityTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemMunicipalityTVItemID = (from c in db.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).FirstOrDefault();

            if (TVItemMunicipalityTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressMunicipalityTVItemID, address.MunicipalityTVItemID.ToString()), new[] { "MunicipalityTVItemID" });
            }
            else
            {
                if (TVItemMunicipalityTVItemID.TVType != TVTypeEnum.Municipality)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AddressMunicipalityTVItemID, "Municipality"), new[] { "MunicipalityTVItemID" });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && address.StreetName.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetName, "200"), new[] { "StreetName" });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && address.StreetNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetNumber, "50"), new[] { "StreetNumber" });
            }

            if (address.StreetType != null)
            {
                retStr = enums.StreetTypeOK(address.StreetType);
                if (address.StreetType == StreetTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
                {
                    yield return new ValidationResult(retStr, new[] { ModelsRes.AddressStreetType });
                }
            }

            if (!string.IsNullOrWhiteSpace(address.PostalCode) && (address.PostalCode.Length < 6 || address.PostalCode.Length > 11))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressPostalCode, "6", "11"), new[] { "PostalCode" });
            }

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 10 || address.GoogleAddressText.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressGoogleAddressText, "10", "200"), new[] { "GoogleAddressText" });
            }

            if (address.LastUpdateDate_UTC.Year == 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressLastUpdateDate_UTC), new[] { "LastUpdateDate_UTC" });
            }
            else
            {
                if (address.LastUpdateDate_UTC.Year < 1980)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AddressLastUpdateDate_UTC, "1980"), new[] { "LastUpdateDate_UTC" });
                }
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            TVItem TVItemLastUpdateContactTVItemID = (from c in db.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).FirstOrDefault();

            if (TVItemLastUpdateContactTVItemID == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressLastUpdateContactTVItemID, address.LastUpdateContactTVItemID.ToString()), new[] { "LastUpdateContactTVItemID" });
            }
            else
            {
                if (TVItemLastUpdateContactTVItemID.TVType != TVTypeEnum.Contact)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsNotOfType_, ModelsRes.AddressLastUpdateContactTVItemID, "Contact"), new[] { "LastUpdateContactTVItemID" });
                }
            }

            retStr = ""; // added to stop compiling error
            if (retStr != "") // will never be true
            {
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

        #region Functions public
        public bool Add(Address address)
        {
            address.ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Create);
            if (address.ValidationResults.Count() > 0) return false;

            db.Addresses.Add(address);

            if (!TryToSave(address)) return false;

            return true;
        }
        public bool AddRange(List<Address> addressList)
        {
            foreach (Address address in addressList)
            {
                address.ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Create);
                if (address.ValidationResults.Count() > 0) return false;
            }

            db.Addresses.AddRange(addressList);

            if (!TryToSaveRange(addressList)) return false;

            return true;
        }
        public bool Delete(Address address)
        {
            if (!db.Addresses.Where(c => c.AddressID == address.AddressID).Any())
            {
                address.ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", address.AddressID.ToString())) }.AsEnumerable();
                return false;
            }

            db.Addresses.Remove(address);

            if (!TryToSave(address)) return false;

            return true;
        }
        public bool DeleteRange(List<Address> addressList)
        {
            foreach (Address address in addressList)
            {
                if (!db.Addresses.Where(c => c.AddressID == address.AddressID).Any())
                {
                    addressList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, "Address", "AddressID", address.AddressID.ToString())) }.AsEnumerable();
                    return false;
                }
            }

            db.Addresses.RemoveRange(addressList);

            if (!TryToSaveRange(addressList)) return false;

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
        public bool UpdateRange(List<Address> addressList)
        {
            foreach (Address address in addressList)
            {
                address.ValidationResults = Validate(new ValidationContext(address), ActionDBTypeEnum.Update);
                if (address.ValidationResults.Count() > 0) return false;
            }
            db.Addresses.UpdateRange(addressList);

            if (!TryToSaveRange(addressList)) return false;

            return true;
        }
        public IQueryable<Address> GetRead()
        {
            return db.Addresses.AsNoTracking();
        }
        public IQueryable<Address> GetEdit()
        {
            return db.Addresses;
        }
        #endregion Functions public

        #region Functions private
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
        private bool TryToSaveRange(List<Address> addressList)
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                addressList[0].ValidationResults = new List<ValidationResult>() { new ValidationResult(ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : "")) }.AsEnumerable();
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
