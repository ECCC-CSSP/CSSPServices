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
        public CSSPWebToolsDBContext db { get; set; }
        public DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AddressService(LanguageEnum LanguageRequest, int ContactID, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, ContactID)
        {
            this.DatabaseType = DatabaseType;
            this.db = new CSSPWebToolsDBContext(this.DatabaseType);
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
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressID), new[] { ModelsRes.AddressAddressID });
                }
            }

            //AddressID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (address.AddressTVItemID != null)
            {
                if (address.AddressTVItemID < 1)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressAddressTVItemID, "1"), new[] { ModelsRes.AddressAddressTVItemID });
                }
            }

            if (address.AddressTVItemID != null)
            {
                if (!((from c in db.TVItems where c.TVItemID == address.AddressTVItemID select c).Any()))
                {
                    yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressAddressTVItemID, address.AddressTVItemID.ToString()), new[] { ModelsRes.AddressAddressTVItemID });
                }
            }

            retStr = enums.AddressTypeOK(address.AddressType);
            if (address.AddressType == AddressTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressType), new[] { ModelsRes.AddressAddressType });
            }

            //CountryTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (address.CountryTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressCountryTVItemID, "1"), new[] { ModelsRes.AddressCountryTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == address.CountryTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressCountryTVItemID, address.CountryTVItemID.ToString()), new[] { ModelsRes.AddressCountryTVItemID });
            }

            //ProvinceTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (address.ProvinceTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressProvinceTVItemID, "1"), new[] { ModelsRes.AddressProvinceTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == address.ProvinceTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressProvinceTVItemID, address.ProvinceTVItemID.ToString()), new[] { ModelsRes.AddressProvinceTVItemID });
            }

            //MunicipalityTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (address.MunicipalityTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressMunicipalityTVItemID, "1"), new[] { ModelsRes.AddressMunicipalityTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == address.MunicipalityTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressMunicipalityTVItemID, address.MunicipalityTVItemID.ToString()), new[] { ModelsRes.AddressMunicipalityTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && address.StreetName.Length > 200)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetName, "200"), new[] { ModelsRes.AddressStreetName });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && address.StreetNumber.Length > 50)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetNumber, "50"), new[] { ModelsRes.AddressStreetNumber });
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
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressPostalCode, "6", "11"), new[] { ModelsRes.AddressPostalCode });
            }

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 10 || address.GoogleAddressText.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressGoogleAddressText, "10", "200"), new[] { ModelsRes.AddressGoogleAddressText });
            }

            if (address.LastUpdateDate_UTC == null)
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressLastUpdateDate_UTC), new[] { ModelsRes.AddressLastUpdateDate_UTC });
            }

            if (address.LastUpdateDate_UTC.Year < 1980)
            {
                yield return new ValidationResult(string.Format(ServicesRes._YearShouldBeBiggerThan_, ModelsRes.AddressLastUpdateDate_UTC, "1980"), new[] { ModelsRes.AddressLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (Int32) is required but no testing needed as it is automatically set to 0 or 0.0f or 0.0D

            if (address.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressLastUpdateContactTVItemID, "1"), new[] { ModelsRes.AddressLastUpdateContactTVItemID });
            }

            if (!((from c in db.TVItems where c.TVItemID == address.LastUpdateContactTVItemID select c).Any()))
            {
                yield return new ValidationResult(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressLastUpdateContactTVItemID, address.LastUpdateContactTVItemID.ToString()), new[] { ModelsRes.AddressLastUpdateContactTVItemID });
            }

            retStr = "";
            if (retStr != "")
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
        public CSSPWebToolsDBContext GetDBContext()
        {
            return db;
        }
        public DatabaseTypeEnum GetDatabaseType()
        {
            return DatabaseType;
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
