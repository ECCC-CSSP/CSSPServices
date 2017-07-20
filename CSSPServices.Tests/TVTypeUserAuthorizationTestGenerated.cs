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
    public partial class TVTypeUserAuthorizationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVTypeUserAuthorizationID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVTypeUserAuthorization GetFilledRandomTVTypeUserAuthorization(string OmitPropName)
        {
            TVTypeUserAuthorizationID += 1;

            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();

            if (OmitPropName != "TVTypeUserAuthorizationID") tvTypeUserAuthorization.TVTypeUserAuthorizationID = TVTypeUserAuthorizationID;
            if (OmitPropName != "ContactTVItemID") tvTypeUserAuthorization.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVType") tvTypeUserAuthorization.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVAuth") tvTypeUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvTypeUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVTypeUserAuthorization_Testing()
        {
            SetupTestHelper(culture);
            TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, ID, DatabaseTypeEnum.MemoryTestDB);
            TVTypeUserAuthorization tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(true, tvTypeUserAuthorizationService.GetRead().Where(c => c == tvTypeUserAuthorization).Any());
            tvTypeUserAuthorization.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization));
            Assert.AreEqual(1, tvTypeUserAuthorizationService.GetRead().Count());
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVType]

            //Error: Type not implemented [TVAuth]

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(1, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.IsTrue(tvTypeUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvTypeUserAuthorization.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [ContactTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVTypeUserAuthorizationID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactTVItemID] of type [Int32]
            //-----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvTypeUserAuthorization.ContactTVItemID = 1;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvTypeUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvTypeUserAuthorization.ContactTVItemID = 2;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvTypeUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvTypeUserAuthorization.ContactTVItemID = 0;
            Assert.AreEqual(false, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.IsTrue(tvTypeUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeUserAuthorizationContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvTypeUserAuthorization.ContactTVItemID);
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVAuth] of type [TVAuthEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvTypeUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvTypeUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization));
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization));
            Assert.IsTrue(tvTypeUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvTypeUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvTypeUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [ContactTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
