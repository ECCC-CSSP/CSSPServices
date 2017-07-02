using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class AddressTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int AddressID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public AddressTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            AddressID += 1;

            Address address = new Address();

            if (OmitPropName != "AddressID") address.AddressID = AddressID;
            if (OmitPropName != "AddressTVItemID") address.AddressTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "AddressType") address.AddressType = (AddressTypeEnum)GetRandomEnumType(typeof(AddressTypeEnum));
            if (OmitPropName != "CountryTVItemID") address.CountryTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "ProvinceTVItemID") address.ProvinceTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "MunicipalityTVItemID") address.MunicipalityTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "StreetName") address.StreetName = GetRandomString("", 6);
            if (OmitPropName != "StreetNumber") address.StreetNumber = GetRandomString("", 6);
            if (OmitPropName != "StreetType") address.StreetType = (StreetTypeEnum)GetRandomEnumType(typeof(StreetTypeEnum));
            if (OmitPropName != "PostalCode") address.PostalCode = GetRandomString("", 11);
            if (OmitPropName != "GoogleAddressText") address.GoogleAddressText = GetRandomString("", 6);
            if (OmitPropName != "LastUpdateDate_UTC") address.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") address.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return address;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Address_Testing()
        {
            SetupTestHelper(culture);
            AddressService addressService = new AddressService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Address address = GetFilledRandomAddress("");
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(true, addressService.GetRead().Where(c => c == address).Any());
            address.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, addressService.Update(address));
            Assert.AreEqual(1, addressService.GetRead().Count());
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // AddressTVItemID will automatically be initialized at 0 --> not null

            address = null;
            address = GetFilledRandomAddress("AddressType");
            Assert.AreEqual(false, addressService.Add(address));
            Assert.AreEqual(1, address.ValidationResults.Count());
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressType)).Any());
            Assert.AreEqual(AddressTypeEnum.Error, address.AddressType);
            Assert.AreEqual(0, addressService.GetRead().Count());

            // CountryTVItemID will automatically be initialized at 0 --> not null

            // ProvinceTVItemID will automatically be initialized at 0 --> not null

            // MunicipalityTVItemID will automatically be initialized at 0 --> not null

            address = null;
            address = GetFilledRandomAddress("LastUpdateDate_UTC");
            Assert.AreEqual(false, addressService.Add(address));
            Assert.AreEqual(1, address.ValidationResults.Count());
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AddressLastUpdateDate_UTC)).Any());
            Assert.IsTrue(address.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, addressService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [AddressID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [AddressTVItemID] of type [int]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // AddressTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            address.AddressTVItemID = 1;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(1, address.AddressTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // AddressTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            address.AddressTVItemID = 2;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(2, address.AddressTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // AddressTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            address.AddressTVItemID = 0;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressAddressTVItemID, "1")).Any());
            Assert.AreEqual(0, address.AddressTVItemID);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [AddressType] of type [AddressTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [CountryTVItemID] of type [int]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // CountryTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            address.CountryTVItemID = 1;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(1, address.CountryTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // CountryTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            address.CountryTVItemID = 2;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(2, address.CountryTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // CountryTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            address.CountryTVItemID = 0;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressCountryTVItemID, "1")).Any());
            Assert.AreEqual(0, address.CountryTVItemID);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [ProvinceTVItemID] of type [int]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            address.ProvinceTVItemID = 1;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(1, address.ProvinceTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            address.ProvinceTVItemID = 2;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(2, address.ProvinceTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // ProvinceTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            address.ProvinceTVItemID = 0;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressProvinceTVItemID, "1")).Any());
            Assert.AreEqual(0, address.ProvinceTVItemID);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [MunicipalityTVItemID] of type [int]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // MunicipalityTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            address.MunicipalityTVItemID = 1;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(1, address.MunicipalityTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // MunicipalityTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            address.MunicipalityTVItemID = 2;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(2, address.MunicipalityTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // MunicipalityTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            address.MunicipalityTVItemID = 0;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressMunicipalityTVItemID, "1")).Any());
            Assert.AreEqual(0, address.MunicipalityTVItemID);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [StreetName] of type [string]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            // StreetName has MinLength [1] and MaxLength [200]. At Min should return true and no errors
            string addressStreetNameMin = GetRandomString("", 1);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetName has MinLength [1] and MaxLength [200]. At Min + 1 should return true and no errors
            addressStreetNameMin = GetRandomString("", 2);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetName has MinLength [1] and MaxLength [200]. At Max should return true and no errors
            addressStreetNameMin = GetRandomString("", 200);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetName has MinLength [1] and MaxLength [200]. At Max - 1 should return true and no errors
            addressStreetNameMin = GetRandomString("", 199);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetName has MinLength [1] and MaxLength [200]. At Max + 1 should return false with one error
            addressStreetNameMin = GetRandomString("", 201);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressStreetName, "1", "200")).Any());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [StreetNumber] of type [string]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            // StreetNumber has MinLength [1] and MaxLength [50]. At Min should return true and no errors
            string addressStreetNumberMin = GetRandomString("", 1);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetNumber has MinLength [1] and MaxLength [50]. At Min + 1 should return true and no errors
            addressStreetNumberMin = GetRandomString("", 2);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetNumber has MinLength [1] and MaxLength [50]. At Max should return true and no errors
            addressStreetNumberMin = GetRandomString("", 50);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetNumber has MinLength [1] and MaxLength [50]. At Max - 1 should return true and no errors
            addressStreetNumberMin = GetRandomString("", 49);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // StreetNumber has MinLength [1] and MaxLength [50]. At Max + 1 should return false with one error
            addressStreetNumberMin = GetRandomString("", 51);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressStreetNumber, "1", "50")).Any());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [StreetType] of type [StreetTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [PostalCode] of type [string]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            // PostalCode has MinLength [6] and MaxLength [11]. At Min should return true and no errors
            string addressPostalCodeMin = GetRandomString("", 6);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Min + 1 should return true and no errors
            addressPostalCodeMin = GetRandomString("", 7);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Min - 1 should return false with one error
            addressPostalCodeMin = GetRandomString("", 5);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressPostalCode, "6", "11")).Any());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(0, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Max should return true and no errors
            addressPostalCodeMin = GetRandomString("", 11);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Max - 1 should return true and no errors
            addressPostalCodeMin = GetRandomString("", 10);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Max + 1 should return false with one error
            addressPostalCodeMin = GetRandomString("", 12);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressPostalCode, "6", "11")).Any());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [GoogleAddressText] of type [string]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            // GoogleAddressText has MinLength [1] and MaxLength [200]. At Min should return true and no errors
            string addressGoogleAddressTextMin = GetRandomString("", 1);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [1] and MaxLength [200]. At Min + 1 should return true and no errors
            addressGoogleAddressTextMin = GetRandomString("", 2);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [1] and MaxLength [200]. At Max should return true and no errors
            addressGoogleAddressTextMin = GetRandomString("", 200);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [1] and MaxLength [200]. At Max - 1 should return true and no errors
            addressGoogleAddressTextMin = GetRandomString("", 199);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [1] and MaxLength [200]. At Max + 1 should return false with one error
            addressGoogleAddressTextMin = GetRandomString("", 201);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressGoogleAddressText, "1", "200")).Any());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(0, addressService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            address.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(1, address.LastUpdateContactTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            address.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(2, address.LastUpdateContactTVItemID);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(0, addressService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            address.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.AddressLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, address.LastUpdateContactTVItemID);
            Assert.AreEqual(0, addressService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
