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
    public partial class TideDataValueTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TideDataValueService tideDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueTest() : base()
        {
            tideDataValueService = new TideDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideDataValue GetFilledRandomTideDataValue(string OmitPropName)
        {
            TideDataValue tideDataValue = new TideDataValue();

            if (OmitPropName != "TideSiteTVItemID") tideDataValue.TideSiteTVItemID = 13;
            if (OmitPropName != "DateTime_Local") tideDataValue.DateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Keep") tideDataValue.Keep = true;
            if (OmitPropName != "TideDataType") tideDataValue.TideDataType = (TideDataTypeEnum)GetRandomEnumType(typeof(TideDataTypeEnum));
            if (OmitPropName != "StorageDataType") tideDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Depth_m") tideDataValue.Depth_m = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "UVelocity_m_s") tideDataValue.UVelocity_m_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "VVelocity_m_s") tideDataValue.VVelocity_m_s = GetRandomDouble(1.0D, 1000.0D);
            if (OmitPropName != "TideStart") tideDataValue.TideStart = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "TideEnd") tideDataValue.TideEnd = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tideDataValue.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tideDataValue.LastUpdateContactTVItemID = 2;

            return tideDataValue;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TideDataValue_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TideDataValue tideDataValue = GetFilledRandomTideDataValue("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tideDataValueService.GetRead().Count();

            tideDataValueService.Add(tideDataValue);
            if (tideDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tideDataValueService.GetRead().Where(c => c == tideDataValue).Any());
            tideDataValueService.Update(tideDataValue);
            if (tideDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tideDataValueService.GetRead().Count());
            tideDataValueService.Delete(tideDataValue);
            if (tideDataValue.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TideSiteTVItemID will automatically be initialized at 0 --> not null

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("DateTime_Local");
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(1, tideDataValue.ValidationResults.Count());
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueDateTime_Local)).Any());
            Assert.IsTrue(tideDataValue.DateTime_Local.Year < 1900);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            // Keep will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TideDataType]

            //Error: Type not implemented [StorageDataType]

            //Error: Type not implemented [Depth_m]

            //Error: Type not implemented [UVelocity_m_s]

            //Error: Type not implemented [VVelocity_m_s]

            //Error: Type not implemented [TideStart]

            //Error: Type not implemented [TideEnd]

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("LastUpdateDate_UTC");
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(1, tideDataValue.ValidationResults.Count());
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tideDataValue.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TideSiteTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TideDataValueID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideSiteTVItemID] of type [Int32]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideDataValue.TideSiteTVItemID = 1;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1, tideDataValue.TideSiteTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideDataValue.TideSiteTVItemID = 2;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(2, tideDataValue.TideSiteTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // TideSiteTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideDataValue.TideSiteTVItemID = 0;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideDataValueTideSiteTVItemID, "1")).Any());
            Assert.AreEqual(0, tideDataValue.TideSiteTVItemID);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [DateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Keep] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideDataType] of type [TideDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [StorageDataType] of type [StorageDataTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [Depth_m] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [UVelocity_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [VVelocity_m_s] of type [Double]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideStart] of type [TideTextEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [TideEnd] of type [TideTextEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tideDataValue.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1, tideDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tideDataValue.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(2, tideDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tideDataValue.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TideDataValueLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tideDataValue.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tideDataValueService.GetRead().Count());

            //-----------------------------------
            // doing property [TideSiteTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
