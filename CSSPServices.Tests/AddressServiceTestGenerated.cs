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
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    [TestClass]
    public partial class AddressServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private AddressService addressService { get; set; }
        #endregion Properties

        #region Constructors
        public AddressServiceTest() : base()
        {
            //addressService = new AddressService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Address_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

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

                    count = addressService.GetAddressList().Count();

                    Assert.AreEqual(addressService.GetAddressList().Count(), (from c in dbTestDB.Addresses select c).Take(200).Count());

                    addressService.Add(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, addressService.GetAddressList().Where(c => c == address).Any());
                    addressService.Update(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, addressService.GetAddressList().Count());
                    addressService.Delete(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AddressAddressID"), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressID = 10000000;
                    addressService.Update(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "Address", "AddressAddressID", address.AddressID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
                    // address.AddressTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressAddressTVItemID", address.AddressTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AddressAddressTVItemID", "Address"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // address.AddressType   (AddressTypeEnum)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressType = (AddressTypeEnum)1000000;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AddressAddressType"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                    // address.CountryTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.CountryTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressCountryTVItemID", address.CountryTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.CountryTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AddressCountryTVItemID", "Country"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
                    // address.ProvinceTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.ProvinceTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressProvinceTVItemID", address.ProvinceTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.ProvinceTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AddressProvinceTVItemID", "Province"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
                    // address.MunicipalityTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.MunicipalityTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressMunicipalityTVItemID", address.MunicipalityTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.MunicipalityTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AddressMunicipalityTVItemID", "Municipality"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200))]
                    // address.StreetName   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetName = GetRandomString("", 201);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "AddressStreetName", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // address.StreetNumber   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, "AddressStreetNumber", "50"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // address.StreetType   (StreetTypeEnum)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetType = (StreetTypeEnum)1000000;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AddressStreetType"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(11, MinimumLength = 6)]
                    // address.PostalCode   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.PostalCode = GetRandomString("", 5);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "AddressPostalCode", "6", "11"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.PostalCode = GetRandomString("", 12);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "AddressPostalCode", "6", "11"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200, MinimumLength = 10)]
                    // address.GoogleAddressText   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.GoogleAddressText = GetRandomString("", 9);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "AddressGoogleAddressText", "10", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.GoogleAddressText = GetRandomString("", 201);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, "AddressGoogleAddressText", "10", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetAddressList().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // address.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateDate_UTC = new DateTime();
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, "AddressLastUpdateDate_UTC"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, "AddressLastUpdateDate_UTC", "1980"), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // address.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateContactTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, "TVItem", "AddressLastUpdateContactTVItemID", address.LastUpdateContactTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateContactTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, "AddressLastUpdateContactTVItemID", "Contact"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // address.HasErrors   (Boolean)
                    // -----------------------------------

                    // No testing requied

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // address.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                    // No testing requied
                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetAddressWithAddressID(address.AddressID)
        [TestMethod]
        public void GetAddressWithAddressID__address_AddressID__Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Address address = (from c in dbTestDB.Addresses select c).FirstOrDefault();
                    Assert.IsNotNull(address);

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        addressService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            Address addressRet = addressService.GetAddressWithAddressID(address.AddressID);
                            CheckAddressFields(new List<Address>() { addressRet });
                            Assert.AreEqual(address.AddressID, addressRet.AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            AddressExtraA addressExtraARet = addressService.GetAddressExtraAWithAddressID(address.AddressID);
                            CheckAddressExtraAFields(new List<AddressExtraA>() { addressExtraARet });
                            Assert.AreEqual(address.AddressID, addressExtraARet.AddressID);
                        }
                        else if (detail == "ExtraB")
                        {
                            AddressExtraB addressExtraBRet = addressService.GetAddressExtraBWithAddressID(address.AddressID);
                            CheckAddressExtraBFields(new List<AddressExtraB>() { addressExtraBRet });
                            Assert.AreEqual(address.AddressID, addressExtraBRet.AddressID);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressWithAddressID(address.AddressID)

        #region Tests Generated for GetAddressList()
        [TestMethod]
        public void GetAddressList_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);
                    Address address = (from c in dbTestDB.Addresses select c).FirstOrDefault();
                    Assert.IsNotNull(address);

                    List<Address> addressDirectQueryList = new List<Address>();
                    addressDirectQueryList = (from c in dbTestDB.Addresses select c).Take(200).ToList();

                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        addressService.Query.Detail = detail;

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList()

        #region Tests Generated for GetAddressList() Skip Take
        [TestMethod]
        public void GetAddressList_Skip_Take_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1, "", "", "");

                        List<Address> addressDirectQueryList = new List<Address>();
                        addressDirectQueryList = (from c in dbTestDB.Addresses select c).Skip(1).Take(1).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraAList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraBList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take

        #region Tests Generated for GetAddressList() Skip Take Order
        [TestMethod]
        public void GetAddressList_Skip_Take_Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1,  "AddressID", "");

                        List<Address> addressDirectQueryList = new List<Address>();
                        addressDirectQueryList = (from c in dbTestDB.Addresses select c).Skip(1).Take(1).OrderBy(c => c.AddressID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraAList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraBList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Order

        #region Tests Generated for GetAddressList() Skip Take 2Order
        [TestMethod]
        public void GetAddressList_Skip_Take_2Order_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 1, 1, "AddressID,AddressTVItemID", "");

                        List<Address> addressDirectQueryList = new List<Address>();
                        addressDirectQueryList = (from c in dbTestDB.Addresses select c).Skip(1).Take(1).OrderBy(c => c.AddressID).ThenBy(c => c.AddressTVItemID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraAList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraBList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take 2Order

        #region Tests Generated for GetAddressList() Skip Take Order Where
        [TestMethod]
        public void GetAddressList_Skip_Take_Order_Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 1, "AddressID", "AddressID,EQ,4", "");

                        List<Address> addressDirectQueryList = new List<Address>();
                        addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID == 4).Skip(0).Take(1).OrderBy(c => c.AddressID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraAList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraBList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Order Where

        #region Tests Generated for GetAddressList() Skip Take Order 2Where
        [TestMethod]
        public void GetAddressList_Skip_Take_Order_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 1, "AddressID", "AddressID,GT,2|AddressID,LT,5", "");

                        List<Address> addressDirectQueryList = new List<Address>();
                        addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID > 2 && c.AddressID < 5).Skip(0).Take(1).OrderBy(c => c.AddressID).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraAList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraBList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList() Skip Take Order 2Where

        #region Tests Generated for GetAddressList() 2Where
        [TestMethod]
        public void GetAddressList_2Where_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    foreach (string detail in new List<string>() { null, "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" })
                    {
                        AddressService addressService = new AddressService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                        addressService.Query = addressService.FillQuery(typeof(Address), culture.TwoLetterISOLanguageName, 0, 10000, "", "AddressID,GT,2|AddressID,LT,5", "");

                        List<Address> addressDirectQueryList = new List<Address>();
                        addressDirectQueryList = (from c in dbTestDB.Addresses select c).Where(c => c.AddressID > 2 && c.AddressID < 5).ToList();

                        if (string.IsNullOrWhiteSpace(detail))
                        {
                            List<Address> addressList = new List<Address>();
                            addressList = addressService.GetAddressList().ToList();
                            CheckAddressFields(addressList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressList[0].AddressID);
                        }
                        else if (detail == "ExtraA")
                        {
                            List<AddressExtraA> addressExtraAList = new List<AddressExtraA>();
                            addressExtraAList = addressService.GetAddressExtraAList().ToList();
                            CheckAddressExtraAFields(addressExtraAList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraAList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraAList.Count);
                        }
                        else if (detail == "ExtraB")
                        {
                            List<AddressExtraB> addressExtraBList = new List<AddressExtraB>();
                            addressExtraBList = addressService.GetAddressExtraBList().ToList();
                            CheckAddressExtraBFields(addressExtraBList);
                            Assert.AreEqual(addressDirectQueryList[0].AddressID, addressExtraBList[0].AddressID);
                            Assert.AreEqual(addressDirectQueryList.Count, addressExtraBList.Count);
                        }
                        else
                        {
                            // nothing for now
                        }
                    }
                }
            }
        }
        #endregion Tests Generated for GetAddressList() 2Where

        #region Functions private
        private void CheckAddressFields(List<Address> addressList)
        {
            Assert.IsNotNull(addressList[0].AddressID);
            Assert.IsNotNull(addressList[0].AddressTVItemID);
            Assert.IsNotNull(addressList[0].AddressType);
            Assert.IsNotNull(addressList[0].CountryTVItemID);
            Assert.IsNotNull(addressList[0].ProvinceTVItemID);
            Assert.IsNotNull(addressList[0].MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(addressList[0].StreetName))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].StreetName));
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].StreetNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].StreetNumber));
            }
            if (addressList[0].StreetType != null)
            {
                Assert.IsNotNull(addressList[0].StreetType);
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].PostalCode))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].PostalCode));
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].GoogleAddressText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressList[0].GoogleAddressText));
            }
            Assert.IsNotNull(addressList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(addressList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(addressList[0].HasErrors);
        }
        private void CheckAddressExtraAFields(List<AddressExtraA> addressExtraAList)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].AddressText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].CountryText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].ProvinceText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].MunicipalityText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(addressExtraAList[0].AddressTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].AddressTypeText));
            }
            if (!string.IsNullOrWhiteSpace(addressExtraAList[0].StreetTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].StreetTypeText));
            }
            Assert.IsNotNull(addressExtraAList[0].AddressID);
            Assert.IsNotNull(addressExtraAList[0].AddressTVItemID);
            Assert.IsNotNull(addressExtraAList[0].AddressType);
            Assert.IsNotNull(addressExtraAList[0].CountryTVItemID);
            Assert.IsNotNull(addressExtraAList[0].ProvinceTVItemID);
            Assert.IsNotNull(addressExtraAList[0].MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(addressExtraAList[0].StreetName))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].StreetName));
            }
            if (!string.IsNullOrWhiteSpace(addressExtraAList[0].StreetNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].StreetNumber));
            }
            if (addressExtraAList[0].StreetType != null)
            {
                Assert.IsNotNull(addressExtraAList[0].StreetType);
            }
            if (!string.IsNullOrWhiteSpace(addressExtraAList[0].PostalCode))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].PostalCode));
            }
            if (!string.IsNullOrWhiteSpace(addressExtraAList[0].GoogleAddressText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraAList[0].GoogleAddressText));
            }
            Assert.IsNotNull(addressExtraAList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(addressExtraAList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(addressExtraAList[0].HasErrors);
        }
        private void CheckAddressExtraBFields(List<AddressExtraB> addressExtraBList)
        {
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].AddressReportTest))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].AddressReportTest));
            }
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].AddressText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].CountryText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].ProvinceText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].MunicipalityText));
            Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].LastUpdateContactText));
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].AddressTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].AddressTypeText));
            }
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].StreetTypeText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].StreetTypeText));
            }
            Assert.IsNotNull(addressExtraBList[0].AddressID);
            Assert.IsNotNull(addressExtraBList[0].AddressTVItemID);
            Assert.IsNotNull(addressExtraBList[0].AddressType);
            Assert.IsNotNull(addressExtraBList[0].CountryTVItemID);
            Assert.IsNotNull(addressExtraBList[0].ProvinceTVItemID);
            Assert.IsNotNull(addressExtraBList[0].MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].StreetName))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].StreetName));
            }
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].StreetNumber))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].StreetNumber));
            }
            if (addressExtraBList[0].StreetType != null)
            {
                Assert.IsNotNull(addressExtraBList[0].StreetType);
            }
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].PostalCode))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].PostalCode));
            }
            if (!string.IsNullOrWhiteSpace(addressExtraBList[0].GoogleAddressText))
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(addressExtraBList[0].GoogleAddressText));
            }
            Assert.IsNotNull(addressExtraBList[0].LastUpdateDate_UTC);
            Assert.IsNotNull(addressExtraBList[0].LastUpdateContactTVItemID);
            Assert.IsNotNull(addressExtraBList[0].HasErrors);
        }
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            Address address = new Address();

            if (OmitPropName != "AddressTVItemID") address.AddressTVItemID = 45;
            if (OmitPropName != "AddressType") address.AddressType = (AddressTypeEnum)GetRandomEnumType(typeof(AddressTypeEnum));
            if (OmitPropName != "CountryTVItemID") address.CountryTVItemID = 5;
            if (OmitPropName != "ProvinceTVItemID") address.ProvinceTVItemID = 6;
            if (OmitPropName != "MunicipalityTVItemID") address.MunicipalityTVItemID = 38;
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
    }
}
