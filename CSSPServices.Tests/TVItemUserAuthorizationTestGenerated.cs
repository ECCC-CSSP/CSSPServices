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
    public partial class TVItemUserAuthorizationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemUserAuthorizationID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            TVItemUserAuthorizationID += 1;

            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "TVItemUserAuthorizationID") tvItemUserAuthorization.TVItemUserAuthorizationID = TVItemUserAuthorizationID;
            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = GetRandomInt(1, 11);
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = GetRandomInt(1, 11);
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = GetRandomInt(1, 11);
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = GetRandomInt(1, 11);
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvItemUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemUserAuthorization_Testing()
        {
            SetupTestHelper(culture);
            TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            TVItemUserAuthorization tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(true, tvItemUserAuthorizationService.GetRead().Where(c => c == tvItemUserAuthorization).Any());
            tvItemUserAuthorization.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Update(tvItemUserAuthorization));
            Assert.AreEqual(1, tvItemUserAuthorizationService.GetRead().Count());
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // ContactTVItemID will automatically be initialized at 0 --> not null

            // TVItemID1 will automatically be initialized at 0 --> not null

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("TVAuth");
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(1, tvItemUserAuthorization.ValidationResults.Count());
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVAuth)).Any());
            Assert.AreEqual(TVAuthEnum.Error, tvItemUserAuthorization.TVAuth);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(1, tvItemUserAuthorization.ValidationResults.Count());
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItemUserAuthorization.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemUserAuthorizationID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [ContactTVItemID] of type [int]
            //-----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // ContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.ContactTVItemID = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.ContactTVItemID = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.ContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // ContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.ContactTVItemID = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.ContactTVItemID);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItemID1] of type [int]
            //-----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID1 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID1 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID1);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID1 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID1 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID1);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID1 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID1 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID1, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID1);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItemID2] of type [int]
            //-----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID2 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID2 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID2);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID2 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID2);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID2 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID2 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID2, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID2);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItemID3] of type [int]
            //-----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID3 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID3 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID3);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID3 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID3 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID3);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID3 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID3 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID3, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID3);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItemID4] of type [int]
            //-----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // TVItemID4 has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.TVItemID4 = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.TVItemID4);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID4 has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.TVItemID4 = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.TVItemID4);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // TVItemID4 has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.TVItemID4 = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationTVItemID4, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.TVItemID4);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

            //-----------------------------------
            // doing property [TVAuth] of type [TVAuthEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(1, tvItemUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemUserAuthorization.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorization.ValidationResults.Count());
            Assert.AreEqual(2, tvItemUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemUserAuthorizationService.Delete(tvItemUserAuthorization));
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemUserAuthorizationService.Add(tvItemUserAuthorization));
            Assert.IsTrue(tvItemUserAuthorization.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemUserAuthorization.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvItemUserAuthorizationService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
