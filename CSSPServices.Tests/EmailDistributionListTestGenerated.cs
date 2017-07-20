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
    public partial class EmailDistributionListTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int EmailDistributionListID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionListID += 1;

            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "EmailDistributionListID") emailDistributionList.EmailDistributionListID = EmailDistributionListID;
            if (OmitPropName != "CountryTVItemID") emailDistributionList.CountryTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "RegionName") emailDistributionList.RegionName = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return emailDistributionList;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void EmailDistributionList_Testing()
        {
            SetupTestHelper(culture);
            EmailDistributionListService emailDistributionListService = new EmailDistributionListService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(true, emailDistributionListService.GetRead().Where(c => c == emailDistributionList).Any());
            emailDistributionList.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, emailDistributionListService.Update(emailDistributionList));
            Assert.AreEqual(1, emailDistributionListService.GetRead().Count());
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // CountryTVItemID will automatically be initialized at 0 --> not null

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("RegionName");
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(1, emailDistributionList.ValidationResults.Count());
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListRegionName)).Any());
            Assert.AreEqual(null, emailDistributionList.RegionName);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            // Ordinal will automatically be initialized at 0 --> not null

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("LastUpdateDate_UTC");
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(1, emailDistributionList.ValidationResults.Count());
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListLastUpdateDate_UTC)).Any());
            Assert.IsTrue(emailDistributionList.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [CountryTVItem]

            //Error: Type not implemented [EmailDistributionListContacts]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [EmailDistributionListID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [CountryTVItemID] of type [Int32]
            //-----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            // CountryTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            emailDistributionList.CountryTVItemID = 1;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(1, emailDistributionList.CountryTVItemID);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // CountryTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            emailDistributionList.CountryTVItemID = 2;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(2, emailDistributionList.CountryTVItemID);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // CountryTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            emailDistributionList.CountryTVItemID = 0;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListCountryTVItemID, "1")).Any());
            Assert.AreEqual(0, emailDistributionList.CountryTVItemID);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            //-----------------------------------
            // doing property [RegionName] of type [String]
            //-----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");

            //-----------------------------------
            // doing property [Ordinal] of type [Int32]
            //-----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            emailDistributionList.Ordinal = 0;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(0, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            emailDistributionList.Ordinal = 1;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(1, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            emailDistributionList.Ordinal = -1;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, emailDistributionList.Ordinal);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            emailDistributionList.Ordinal = 1000;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(1000, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            emailDistributionList.Ordinal = 999;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(999, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            emailDistributionList.Ordinal = 1001;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, emailDistributionList.Ordinal);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            emailDistributionList.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(1, emailDistributionList.LastUpdateContactTVItemID);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            emailDistributionList.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(2, emailDistributionList.LastUpdateContactTVItemID);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            emailDistributionList.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, emailDistributionList.LastUpdateContactTVItemID);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            //-----------------------------------
            // doing property [CountryTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [EmailDistributionListContacts] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
