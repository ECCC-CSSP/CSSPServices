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
    public partial class MWQMLookupMPNTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MWQMLookupMPNID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPNID += 1;

            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "MWQMLookupMPNID") mwqmLookupMPN.MWQMLookupMPNID = MWQMLookupMPNID;
            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(0, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = GetRandomInt(1, 1700);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mwqmLookupMPN;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMLookupMPN_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            MWQMLookupMPNService mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MWQMLookupMPN mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(true, mwqmLookupMPNService.GetRead().Where(c => c == mwqmLookupMPN).Any());
            mwqmLookupMPN.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mwqmLookupMPNService.Update(mwqmLookupMPN));
            Assert.AreEqual(1, mwqmLookupMPNService.GetRead().Count());
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // Tubes10 will automatically be initialized at 0 --> not null

            // Tubes1 will automatically be initialized at 0 --> not null

            // Tubes01 will automatically be initialized at 0 --> not null

            // MPN_100ml will automatically be initialized at 0 --> not null

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("LastUpdateDate_UTC");
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(1, mwqmLookupMPN.ValidationResults.Count());
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mwqmLookupMPN.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MWQMLookupMPNID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [Tubes10] of type [int]
            //-----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // Tubes10 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmLookupMPN.Tubes10 = 0;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(0, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmLookupMPN.Tubes10 = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmLookupMPN.Tubes10 = -1;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmLookupMPN.Tubes10 = 5;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(5, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmLookupMPN.Tubes10 = 4;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(4, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmLookupMPN.Tubes10 = 6;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5")).Any());
            Assert.AreEqual(6, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

            //-----------------------------------
            // doing property [Tubes1] of type [int]
            //-----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // Tubes1 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmLookupMPN.Tubes1 = 0;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(0, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmLookupMPN.Tubes1 = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmLookupMPN.Tubes1 = -1;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmLookupMPN.Tubes1 = 5;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(5, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmLookupMPN.Tubes1 = 4;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(4, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmLookupMPN.Tubes1 = 6;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5")).Any());
            Assert.AreEqual(6, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

            //-----------------------------------
            // doing property [Tubes01] of type [int]
            //-----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // Tubes01 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmLookupMPN.Tubes01 = 0;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(0, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmLookupMPN.Tubes01 = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmLookupMPN.Tubes01 = -1;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmLookupMPN.Tubes01 = 5;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(5, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmLookupMPN.Tubes01 = 4;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(4, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmLookupMPN.Tubes01 = 6;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5")).Any());
            Assert.AreEqual(6, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

            //-----------------------------------
            // doing property [MPN_100ml] of type [int]
            //-----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // MPN_100ml has Min [1] and Max [1700]. At Min should return true and no errors
            mwqmLookupMPN.MPN_100ml = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [1700]. At Min + 1 should return true and no errors
            mwqmLookupMPN.MPN_100ml = 2;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(2, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [1700]. At Min - 1 should return false with one error
            mwqmLookupMPN.MPN_100ml = 0;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "1700")).Any());
            Assert.AreEqual(0, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [1700]. At Max should return true and no errors
            mwqmLookupMPN.MPN_100ml = 1700;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1700, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [1700]. At Max - 1 should return true and no errors
            mwqmLookupMPN.MPN_100ml = 1699;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1699, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [1700]. At Max + 1 should return false with one error
            mwqmLookupMPN.MPN_100ml = 1701;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "1700")).Any());
            Assert.AreEqual(1701, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmLookupMPN.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmLookupMPN.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(2, mwqmLookupMPN.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmLookupMPN.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmLookupMPN.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mwqmLookupMPNService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
