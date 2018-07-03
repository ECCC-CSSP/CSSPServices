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

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            Address address = new Address();

            if (OmitPropName != "AddressTVItemID") address.AddressTVItemID = 42;
            if (OmitPropName != "AddressType") address.AddressType = (AddressTypeEnum)GetRandomEnumType(typeof(AddressTypeEnum));
            if (OmitPropName != "CountryTVItemID") address.CountryTVItemID = 5;
            if (OmitPropName != "ProvinceTVItemID") address.ProvinceTVItemID = 6;
            if (OmitPropName != "MunicipalityTVItemID") address.MunicipalityTVItemID = 35;
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

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Address_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    AddressService addressService = new AddressService(new GetParam(), dbTestDB, ContactID);

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

                    Assert.AreEqual(addressService.GetRead().Count(), addressService.GetEdit().Count());

                    addressService.Add(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, addressService.GetRead().Where(c => c == address).Any());
                    addressService.Update(address);
                    if (address.HasErrors)
                    {
                        Assert.AreEqual("", address.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, addressService.GetRead().Count());
                    addressService.Delete(address);
                    if (address.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressAddressID), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressID = 10000000;
                    addressService.Update(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.Address, CSSPModelsRes.AddressAddressID, address.AddressID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
                    // address.AddressTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressAddressTVItemID, address.AddressTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressAddressTVItemID, "Address"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // address.AddressType   (AddressTypeEnum)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressType = (AddressTypeEnum)1000000;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressAddressType), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
                    // address.CountryTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.CountryTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressCountryTVItemID, address.CountryTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.CountryTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressCountryTVItemID, "Country"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
                    // address.ProvinceTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.ProvinceTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressProvinceTVItemID, address.ProvinceTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.ProvinceTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressProvinceTVItemID, "Province"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
                    // address.MunicipalityTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.MunicipalityTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressMunicipalityTVItemID, address.MunicipalityTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.MunicipalityTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressMunicipalityTVItemID, "Municipality"), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200))]
                    // address.StreetName   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetName = GetRandomString("", 201);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AddressStreetName, "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(50))]
                    // address.StreetNumber   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetNumber = GetRandomString("", 51);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.AddressStreetNumber, "50"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // address.StreetType   (StreetTypeEnum)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.StreetType = (StreetTypeEnum)1000000;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressStreetType), address.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(11, MinimumLength = 6)]
                    // address.PostalCode   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.PostalCode = GetRandomString("", 5);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.AddressPostalCode, "6", "11"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetRead().Count());
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.PostalCode = GetRandomString("", 12);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.AddressPostalCode, "6", "11"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [StringLength(200, MinimumLength = 10)]
                    // address.GoogleAddressText   (String)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.GoogleAddressText = GetRandomString("", 9);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.AddressGoogleAddressText, "10", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetRead().Count());
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.GoogleAddressText = GetRandomString("", 201);
                    Assert.AreEqual(false, addressService.Add(address));
                    Assert.AreEqual(string.Format(CSSPServicesRes._LengthShouldBeBetween_And_, CSSPModelsRes.AddressGoogleAddressText, "10", "200"), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, addressService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // address.AddressWeb   (AddressWeb)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressWeb = null;
                    Assert.IsNull(address.AddressWeb);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressWeb = new AddressWeb();
                    Assert.IsNotNull(address.AddressWeb);

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // address.AddressReport   (AddressReport)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressReport = null;
                    Assert.IsNull(address.AddressReport);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.AddressReport = new AddressReport();
                    Assert.IsNotNull(address.AddressReport);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // address.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateDate_UTC = new DateTime();
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.AddressLastUpdateDate_UTC), address.ValidationResults.FirstOrDefault().ErrorMessage);
                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._YearShouldBeBiggerThan_, CSSPModelsRes.AddressLastUpdateDate_UTC, "1980"), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // address.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateContactTVItemID = 0;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.AddressLastUpdateContactTVItemID, address.LastUpdateContactTVItemID.ToString()), address.ValidationResults.FirstOrDefault().ErrorMessage);

                    address = null;
                    address = GetFilledRandomAddress("");
                    address.LastUpdateContactTVItemID = 1;
                    addressService.Add(address);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.AddressLastUpdateContactTVItemID, "Contact"), address.ValidationResults.FirstOrDefault().ErrorMessage);


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

        #region Tests Generated Get With Key
        [TestMethod]
        public void Address_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    GetParam getParam = new GetParam();
                    AddressService addressService = new AddressService(new GetParam(), dbTestDB, ContactID);
                    Address address = (from c in addressService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(address);

                    Address addressRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb, EntityQueryDetailTypeEnum.EntityReport })
                    {
                        getParam.EntityQueryDetailType = entityQueryDetailTypeEnum;

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            addressRet = addressService.GetAddressWithAddressID(address.AddressID, getParam);
                            Assert.IsNull(addressRet);
                            continue;
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            addressRet = addressService.GetAddressWithAddressID(address.AddressID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            addressRet = addressService.GetAddressWithAddressID(address.AddressID, getParam);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            addressRet = addressService.GetAddressWithAddressID(address.AddressID, getParam);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Address fields
                        Assert.IsNotNull(addressRet.AddressID);
                        Assert.IsNotNull(addressRet.AddressTVItemID);
                        Assert.IsNotNull(addressRet.AddressType);
                        Assert.IsNotNull(addressRet.CountryTVItemID);
                        Assert.IsNotNull(addressRet.ProvinceTVItemID);
                        Assert.IsNotNull(addressRet.MunicipalityTVItemID);
                        if (addressRet.StreetName != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.StreetName));
                        }
                        if (addressRet.StreetNumber != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.StreetNumber));
                        }
                        if (addressRet.StreetType != null)
                        {
                            Assert.IsNotNull(addressRet.StreetType);
                        }
                        if (addressRet.PostalCode != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.PostalCode));
                        }
                        if (addressRet.GoogleAddressText != null)
                        {
                            Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.GoogleAddressText));
                        }
                        Assert.IsNotNull(addressRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(addressRet.LastUpdateContactTVItemID);

                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            // AddressWeb and AddressReport fields should be null here
                            Assert.IsNull(addressRet.AddressWeb);
                            Assert.IsNull(addressRet.AddressReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            // AddressWeb fields should not be null and AddressReport fields should be null here
                            Assert.IsTrue(addressRet.AddressWeb.ParentTVItemID > 0);
                            if (addressRet.AddressWeb.AddressTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.AddressTVText));
                            }
                            if (addressRet.AddressWeb.CountryTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.CountryTVText));
                            }
                            if (addressRet.AddressWeb.ProvinceTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.ProvinceTVText));
                            }
                            if (addressRet.AddressWeb.MunicipalityTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.MunicipalityTVText));
                            }
                            if (addressRet.AddressWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.LastUpdateContactTVText));
                            }
                            if (addressRet.AddressWeb.AddressTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.AddressTypeText));
                            }
                            if (addressRet.AddressWeb.StreetTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.StreetTypeText));
                            }
                            Assert.IsNull(addressRet.AddressReport);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityReport)
                        {
                            // AddressWeb and AddressReport fields should NOT be null here
                            Assert.IsTrue(addressRet.AddressWeb.ParentTVItemID > 0);
                            if (addressRet.AddressWeb.AddressTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.AddressTVText));
                            }
                            if (addressRet.AddressWeb.CountryTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.CountryTVText));
                            }
                            if (addressRet.AddressWeb.ProvinceTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.ProvinceTVText));
                            }
                            if (addressRet.AddressWeb.MunicipalityTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.MunicipalityTVText));
                            }
                            if (addressRet.AddressWeb.LastUpdateContactTVText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.LastUpdateContactTVText));
                            }
                            if (addressRet.AddressWeb.AddressTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.AddressTypeText));
                            }
                            if (addressRet.AddressWeb.StreetTypeText != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressWeb.StreetTypeText));
                            }
                            if (addressRet.AddressReport.AddressReportTest != null)
                            {
                                Assert.IsFalse(string.IsNullOrWhiteSpace(addressRet.AddressReport.AddressReportTest));
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of Address
        #endregion Tests Get List of Address

    }
}
