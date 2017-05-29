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
        private CSSPWebToolsDBContext db { get; set; }
        private DatabaseTypeEnum DatabaseType { get; set; }
        #endregion Properties

        #region Constructors
        public AddressService(LanguageEnum LanguageRequest, IPrincipal User, DatabaseTypeEnum DatabaseType)
            : base(LanguageRequest, User)
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

            // ----------------------------------------------------
            // Property is required validation
            // ----------------------------------------------------

            if (actionDBType == ActionDBTypeEnum.Update)
            {
                if (address.AddressID == 0)
                {
                    yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressID), new[] { ModelsRes.AddressAddressID });
                }
            }

            //AddressTVItemID (int) is required but no testing needed as it is automatically set to 0

            retStr = enums.AddressTypeOK(address.AddressType);
            if (address.AddressType == AddressTypeEnum.Error || !string.IsNullOrWhiteSpace(retStr))
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressType), new[] { ModelsRes.AddressAddressType });
            }

            //CountryTVItemID (int) is required but no testing needed as it is automatically set to 0

            //ProvinceTVItemID (int) is required but no testing needed as it is automatically set to 0

            //MunicipalityTVItemID (int) is required but no testing needed as it is automatically set to 0

            if (address.LastUpdateDate_UTC == null || address.LastUpdateDate_UTC.Year < 1900 )
            {
                yield return new ValidationResult(string.Format(ServicesRes._IsRequired, ModelsRes.AddressLastUpdateDate_UTC), new[] { ModelsRes.AddressLastUpdateDate_UTC });
            }

            //LastUpdateContactTVItemID (int) is required but no testing needed as it is automatically set to 0

            // ----------------------------------------------------
            // Property other validation
            // ----------------------------------------------------

            if (address.AddressTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressAddressTVItemID, "1"), new[] { ModelsRes.AddressAddressTVItemID });
            }

            if (address.CountryTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressCountryTVItemID, "1"), new[] { ModelsRes.AddressCountryTVItemID });
            }

            if (address.ProvinceTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressProvinceTVItemID, "1"), new[] { ModelsRes.AddressProvinceTVItemID });
            }

            if (address.MunicipalityTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressMunicipalityTVItemID, "1"), new[] { ModelsRes.AddressMunicipalityTVItemID });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetName) && (address.StreetName.Length < 1 || address.StreetName.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressStreetName, "1", "200"), new[] { ModelsRes.AddressStreetName });
            }

            if (!string.IsNullOrWhiteSpace(address.StreetNumber) && (address.StreetNumber.Length < 1 || address.StreetNumber.Length > 50))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressStreetNumber, "1", "50"), new[] { ModelsRes.AddressStreetNumber });
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

            if (!string.IsNullOrWhiteSpace(address.GoogleAddressText) && (address.GoogleAddressText.Length < 1 || address.GoogleAddressText.Length > 200))
            {
                yield return new ValidationResult(string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressGoogleAddressText, "1", "200"), new[] { ModelsRes.AddressGoogleAddressText });
            }

            if (address.LastUpdateContactTVItemID < 1)
            {
                yield return new ValidationResult(string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressLastUpdateContactTVItemID, "1"), new[] { ModelsRes.AddressLastUpdateContactTVItemID });
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
