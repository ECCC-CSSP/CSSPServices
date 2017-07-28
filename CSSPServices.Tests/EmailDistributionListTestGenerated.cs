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
        private EmailDistributionListService emailDistributionListService { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListTest() : base()
        {
            emailDistributionListService = new EmailDistributionListService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private EmailDistributionList GetFilledRandomEmailDistributionList(string OmitPropName)
        {
            EmailDistributionList emailDistributionList = new EmailDistributionList();

            if (OmitPropName != "CountryTVItemID") emailDistributionList.CountryTVItemID = 5;
            if (OmitPropName != "RegionName") emailDistributionList.RegionName = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") emailDistributionList.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") emailDistributionList.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") emailDistributionList.LastUpdateContactTVItemID = 2;

            return emailDistributionList;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void EmailDistributionList_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            EmailDistributionList emailDistributionList = GetFilledRandomEmailDistributionList("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = emailDistributionListService.GetRead().Count();

            emailDistributionListService.Add(emailDistributionList);
            if (emailDistributionList.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, emailDistributionListService.GetRead().Where(c => c == emailDistributionList).Any());
            emailDistributionListService.Update(emailDistributionList);
            if (emailDistributionList.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, emailDistributionListService.GetRead().Count());
            emailDistributionListService.Delete(emailDistributionList);
            if (emailDistributionList.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // emailDistributionList.EmailDistributionListID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.EmailDistributionListID = 0;
            emailDistributionListService.Update(emailDistributionList);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListEmailDistributionListID), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Country)]
            // emailDistributionList.CountryTVItemID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.CountryTVItemID = 0;
            emailDistributionListService.Add(emailDistributionList);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListCountryTVItemID, emailDistributionList.CountryTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

            // CountryTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(100))]
            // emailDistributionList.RegionName   (String)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("RegionName");
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(1, emailDistributionList.ValidationResults.Count());
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.EmailDistributionListRegionName)).Any());
            Assert.AreEqual(null, emailDistributionList.RegionName);
            Assert.AreEqual(0, emailDistributionListService.GetRead().Count());

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            // RegionName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string emailDistributionListRegionNameMin = GetRandomString("", 100);
            emailDistributionList.RegionName = emailDistributionListRegionNameMin;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListRegionNameMin, emailDistributionList.RegionName);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

            // RegionName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            emailDistributionListRegionNameMin = GetRandomString("", 99);
            emailDistributionList.RegionName = emailDistributionListRegionNameMin;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(emailDistributionListRegionNameMin, emailDistributionList.RegionName);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

            // RegionName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            emailDistributionListRegionNameMin = GetRandomString("", 101);
            emailDistributionList.RegionName = emailDistributionListRegionNameMin;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.EmailDistributionListRegionName, "100")).Any());
            Assert.AreEqual(emailDistributionListRegionNameMin, emailDistributionList.RegionName);
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000)]
            // emailDistributionList.Ordinal   (Int32)
            // -----------------------------------

            // Ordinal will automatically be initialized at 0 --> not null

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            emailDistributionList.Ordinal = 0;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(0, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            emailDistributionList.Ordinal = 1;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(1, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            emailDistributionList.Ordinal = -1;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, emailDistributionList.Ordinal);
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            emailDistributionList.Ordinal = 1000;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(1000, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            emailDistributionList.Ordinal = 999;
            Assert.AreEqual(true, emailDistributionListService.Add(emailDistributionList));
            Assert.AreEqual(0, emailDistributionList.ValidationResults.Count());
            Assert.AreEqual(999, emailDistributionList.Ordinal);
            Assert.AreEqual(true, emailDistributionListService.Delete(emailDistributionList));
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            emailDistributionList.Ordinal = 1001;
            Assert.AreEqual(false, emailDistributionListService.Add(emailDistributionList));
            Assert.IsTrue(emailDistributionList.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.EmailDistributionListOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, emailDistributionList.Ordinal);
            Assert.AreEqual(count, emailDistributionListService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // emailDistributionList.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // emailDistributionList.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            emailDistributionList = null;
            emailDistributionList = GetFilledRandomEmailDistributionList("");
            emailDistributionList.LastUpdateContactTVItemID = 0;
            emailDistributionListService.Add(emailDistributionList);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.EmailDistributionListLastUpdateContactTVItemID, emailDistributionList.LastUpdateContactTVItemID.ToString()), emailDistributionList.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // emailDistributionList.CountryTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // emailDistributionList.EmailDistributionListContacts   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // emailDistributionList.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
