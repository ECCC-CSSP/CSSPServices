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
        private AddressService addressService { get; set; }
        #endregion Properties

        #region Constructors
        public AddressTest() : base()
        {
            addressService = new AddressService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            Address address = new Address();

            if (OmitPropName != "AddressTVItemID") address.AddressTVItemID = 28;
            if (OmitPropName != "AddressType") address.AddressType = (AddressTypeEnum)GetRandomEnumType(typeof(AddressTypeEnum));
            if (OmitPropName != "CountryTVItemID") address.CountryTVItemID = 5;
            if (OmitPropName != "ProvinceTVItemID") address.ProvinceTVItemID = 6;
            if (OmitPropName != "MunicipalityTVItemID") address.MunicipalityTVItemID = 14;
            if (OmitPropName != "StreetName") address.StreetName = GetRandomString("", 5);
            if (OmitPropName != "StreetNumber") address.StreetNumber = GetRandomString("", 5);
            if (OmitPropName != "StreetType") address.StreetType = (StreetTypeEnum)GetRandomEnumType(typeof(StreetTypeEnum));
            if (OmitPropName != "PostalCode") address.PostalCode = GetRandomString("", 11);
            if (OmitPropName != "GoogleAddressText") address.GoogleAddressText = GetRandomString("", 15);
            if (OmitPropName != "LastUpdateDate_UTC") address.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") address.LastUpdateContactTVItemID = 2;

            return address;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Address_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Address address = GetFilledRandomAddress("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = addressService.GetRead().Count();

            addressService.Add(address);
            if (address.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, addressService.GetRead().Where(c => c == address).Any());
            addressService.Update(address);
            if (address.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, addressService.GetRead().Count());
            addressService.Delete(address);
            if (address.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, addressService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            //Error: Type not implemented [AddressType]

            // CountryTVItemID will automatically be initialized at 0 --> not null

            // ProvinceTVItemID will automatically be initialized at 0 --> not null

            // MunicipalityTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [StreetType]

            address = null;
            address = GetFilledRandomAddress("LastUpdateDate_UTC");
            Assert.AreEqual(false, addressService.Add(address));
            Assert.AreEqual(1, address.ValidationResults.Count());
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.AddressLastUpdateDate_UTC)).Any());
            Assert.IsTrue(address.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, addressService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [AddressTVItem]

            //Error: Type not implemented [CountryTVItem]

            //Error: Type not implemented [MunicipalityTVItem]

            //Error: Type not implemented [ProvinceTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [AddressID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [AddressTVItemID] of type [Int32]
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
            // doing property [CountryTVItemID] of type [Int32]
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
            // doing property [ProvinceTVItemID] of type [Int32]
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
            // doing property [MunicipalityTVItemID] of type [Int32]
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
            // doing property [StreetName] of type [String]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            //-----------------------------------
            // doing property [StreetNumber] of type [String]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            //-----------------------------------
            // doing property [StreetType] of type [StreetTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [PostalCode] of type [String]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            //-----------------------------------
            // doing property [GoogleAddressText] of type [String]
            //-----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [AddressTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [CountryTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [MunicipalityTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ProvinceTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
