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
            if (OmitPropName != "LastUpdateDate_UTC") address.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // address.AddressID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressID = 0;
            addressService.Update(address);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.AddressAddressID), address.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Address)]
            // address.AddressTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressTVItemID = 0;
            addressService.Add(address);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressAddressTVItemID, address.AddressTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

            // AddressTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // address.AddressType   (AddressTypeEnum)
            // -----------------------------------

            // AddressType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Country)]
            // address.CountryTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.CountryTVItemID = 0;
            addressService.Add(address);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressCountryTVItemID, address.CountryTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

            // CountryTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Province)]
            // address.ProvinceTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.ProvinceTVItemID = 0;
            addressService.Add(address);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressProvinceTVItemID, address.ProvinceTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

            // ProvinceTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Municipality)]
            // address.MunicipalityTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.MunicipalityTVItemID = 0;
            addressService.Add(address);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressMunicipalityTVItemID, address.MunicipalityTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

            // MunicipalityTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [StringLength(200))]
            // address.StreetName   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // StreetName has MinLength [empty] and MaxLength [200]. At Max should return true and no errors
            string addressStreetNameMin = GetRandomString("", 200);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // StreetName has MinLength [empty] and MaxLength [200]. At Max - 1 should return true and no errors
            addressStreetNameMin = GetRandomString("", 199);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // StreetName has MinLength [empty] and MaxLength [200]. At Max + 1 should return false with one error
            addressStreetNameMin = GetRandomString("", 201);
            address.StreetName = addressStreetNameMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetName, "200")).Any());
            Assert.AreEqual(addressStreetNameMin, address.StreetName);
            Assert.AreEqual(count, addressService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(50))]
            // address.StreetNumber   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            // StreetNumber has MinLength [empty] and MaxLength [50]. At Max should return true and no errors
            string addressStreetNumberMin = GetRandomString("", 50);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // StreetNumber has MinLength [empty] and MaxLength [50]. At Max - 1 should return true and no errors
            addressStreetNumberMin = GetRandomString("", 49);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // StreetNumber has MinLength [empty] and MaxLength [50]. At Max + 1 should return false with one error
            addressStreetNumberMin = GetRandomString("", 51);
            address.StreetNumber = addressStreetNumberMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.AddressStreetNumber, "50")).Any());
            Assert.AreEqual(addressStreetNumberMin, address.StreetNumber);
            Assert.AreEqual(count, addressService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // address.StreetType   (StreetTypeEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [StringLength(11, MinimumLength = 6)]
            // address.PostalCode   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            // PostalCode has MinLength [6] and MaxLength [11]. At Min should return true and no errors
            string addressPostalCodeMin = GetRandomString("", 6);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Min + 1 should return true and no errors
            addressPostalCodeMin = GetRandomString("", 7);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Min - 1 should return false with one error
            addressPostalCodeMin = GetRandomString("", 5);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressPostalCode, "6", "11")).Any());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(count, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Max should return true and no errors
            addressPostalCodeMin = GetRandomString("", 11);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Max - 1 should return true and no errors
            addressPostalCodeMin = GetRandomString("", 10);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // PostalCode has MinLength [6] and MaxLength [11]. At Max + 1 should return false with one error
            addressPostalCodeMin = GetRandomString("", 12);
            address.PostalCode = addressPostalCodeMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressPostalCode, "6", "11")).Any());
            Assert.AreEqual(addressPostalCodeMin, address.PostalCode);
            Assert.AreEqual(count, addressService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(200, MinimumLength = 10)]
            // address.GoogleAddressText   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");

            // GoogleAddressText has MinLength [10] and MaxLength [200]. At Min should return true and no errors
            string addressGoogleAddressTextMin = GetRandomString("", 10);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [10] and MaxLength [200]. At Min + 1 should return true and no errors
            addressGoogleAddressTextMin = GetRandomString("", 11);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [10] and MaxLength [200]. At Min - 1 should return false with one error
            addressGoogleAddressTextMin = GetRandomString("", 9);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressGoogleAddressText, "10", "200")).Any());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(count, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [10] and MaxLength [200]. At Max should return true and no errors
            addressGoogleAddressTextMin = GetRandomString("", 200);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [10] and MaxLength [200]. At Max - 1 should return true and no errors
            addressGoogleAddressTextMin = GetRandomString("", 199);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(true, addressService.Add(address));
            Assert.AreEqual(0, address.ValidationResults.Count());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(true, addressService.Delete(address));
            Assert.AreEqual(count, addressService.GetRead().Count());

            // GoogleAddressText has MinLength [10] and MaxLength [200]. At Max + 1 should return false with one error
            addressGoogleAddressTextMin = GetRandomString("", 201);
            address.GoogleAddressText = addressGoogleAddressTextMin;
            Assert.AreEqual(false, addressService.Add(address));
            Assert.IsTrue(address.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.AddressGoogleAddressText, "10", "200")).Any());
            Assert.AreEqual(addressGoogleAddressTextMin, address.GoogleAddressText);
            Assert.AreEqual(count, addressService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // address.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // address.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateContactTVItemID = 0;
            addressService.Add(address);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.AddressLastUpdateContactTVItemID, address.LastUpdateContactTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // address.AddressTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // address.CountryTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // address.MunicipalityTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // address.ProvinceTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // address.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
