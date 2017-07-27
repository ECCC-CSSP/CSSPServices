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
        private MWQMLookupMPNService mwqmLookupMPNService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNTest() : base()
        {
            mwqmLookupMPNService = new MWQMLookupMPNService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(0, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(0, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = GetRandomInt(1, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            return mwqmLookupMPN;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMLookupMPN_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMLookupMPN mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmLookupMPNService.GetRead().Count();

            mwqmLookupMPNService.Add(mwqmLookupMPN);
            if (mwqmLookupMPN.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmLookupMPNService.GetRead().Where(c => c == mwqmLookupMPN).Any());
            mwqmLookupMPNService.Update(mwqmLookupMPN);
            if (mwqmLookupMPN.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmLookupMPNService.GetRead().Count());
            mwqmLookupMPNService.Delete(mwqmLookupMPN);
            if (mwqmLookupMPN.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmLookupMPN.MWQMLookupMPNID   (Int32)
            // -----------------------------------

            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MWQMLookupMPNID = 0;
            mwqmLookupMPNService.Update(mwqmLookupMPN);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMLookupMPNMWQMLookupMPNID), mwqmLookupMPN.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 5)]
            // mwqmLookupMPN.Tubes10   (Int32)
            // -----------------------------------

            // Tubes10 will automatically be initialized at 0 --> not null


            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // Tubes10 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmLookupMPN.Tubes10 = 0;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(0, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmLookupMPN.Tubes10 = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmLookupMPN.Tubes10 = -1;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmLookupMPN.Tubes10 = 5;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(5, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmLookupMPN.Tubes10 = 4;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(4, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes10 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmLookupMPN.Tubes10 = 6;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes10, "0", "5")).Any());
            Assert.AreEqual(6, mwqmLookupMPN.Tubes10);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 5)]
            // mwqmLookupMPN.Tubes1   (Int32)
            // -----------------------------------

            // Tubes1 will automatically be initialized at 0 --> not null


            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // Tubes1 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmLookupMPN.Tubes1 = 0;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(0, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmLookupMPN.Tubes1 = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmLookupMPN.Tubes1 = -1;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmLookupMPN.Tubes1 = 5;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(5, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmLookupMPN.Tubes1 = 4;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(4, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes1 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmLookupMPN.Tubes1 = 6;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes1, "0", "5")).Any());
            Assert.AreEqual(6, mwqmLookupMPN.Tubes1);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 5)]
            // mwqmLookupMPN.Tubes01   (Int32)
            // -----------------------------------

            // Tubes01 will automatically be initialized at 0 --> not null


            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // Tubes01 has Min [0] and Max [5]. At Min should return true and no errors
            mwqmLookupMPN.Tubes01 = 0;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(0, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Min + 1 should return true and no errors
            mwqmLookupMPN.Tubes01 = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Min - 1 should return false with one error
            mwqmLookupMPN.Tubes01 = -1;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5")).Any());
            Assert.AreEqual(-1, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Max should return true and no errors
            mwqmLookupMPN.Tubes01 = 5;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(5, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Max - 1 should return true and no errors
            mwqmLookupMPN.Tubes01 = 4;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(4, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // Tubes01 has Min [0] and Max [5]. At Max + 1 should return false with one error
            mwqmLookupMPN.Tubes01 = 6;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNTubes01, "0", "5")).Any());
            Assert.AreEqual(6, mwqmLookupMPN.Tubes01);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(1, 10000)]
            // mwqmLookupMPN.MPN_100ml   (Int32)
            // -----------------------------------

            // MPN_100ml will automatically be initialized at 0 --> not null


            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // MPN_100ml has Min [1] and Max [10000]. At Min should return true and no errors
            mwqmLookupMPN.MPN_100ml = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [10000]. At Min + 1 should return true and no errors
            mwqmLookupMPN.MPN_100ml = 2;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(2, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [10000]. At Min - 1 should return false with one error
            mwqmLookupMPN.MPN_100ml = 0;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000")).Any());
            Assert.AreEqual(0, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [10000]. At Max should return true and no errors
            mwqmLookupMPN.MPN_100ml = 10000;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(10000, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [10000]. At Max - 1 should return true and no errors
            mwqmLookupMPN.MPN_100ml = 9999;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(9999, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // MPN_100ml has Min [1] and Max [10000]. At Max + 1 should return false with one error
            mwqmLookupMPN.MPN_100ml = 10001;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMLookupMPNMPN_100ml, "1", "10000")).Any());
            Assert.AreEqual(10001, mwqmLookupMPN.MPN_100ml);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmLookupMPN.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // mwqmLookupMPN.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmLookupMPN.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(1, mwqmLookupMPN.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmLookupMPN.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.AreEqual(0, mwqmLookupMPN.ValidationResults.Count());
            Assert.AreEqual(2, mwqmLookupMPN.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmLookupMPNService.Delete(mwqmLookupMPN));
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmLookupMPN.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmLookupMPNService.Add(mwqmLookupMPN));
            Assert.IsTrue(mwqmLookupMPN.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMLookupMPNLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmLookupMPN.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mwqmLookupMPNService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mwqmLookupMPN.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
