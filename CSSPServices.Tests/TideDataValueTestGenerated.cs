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
            if (OmitPropName != "DateTime_Local") tideDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") tideDataValue.Keep = true;
            if (OmitPropName != "TideDataType") tideDataValue.TideDataType = (TideDataTypeEnum)GetRandomEnumType(typeof(TideDataTypeEnum));
            if (OmitPropName != "StorageDataType") tideDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Depth_m") tideDataValue.Depth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "UVelocity_m_s") tideDataValue.UVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "VVelocity_m_s") tideDataValue.VVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "TideStart") tideDataValue.TideStart = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "TideEnd") tideDataValue.TideEnd = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tideDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tideDataValue.TideDataValueID   (Int32)
            // -----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            tideDataValue.TideDataValueID = 0;
            tideDataValueService.Update(tideDataValue);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataValueID), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.TideSite)]
            // tideDataValue.TideSiteTVItemID   (Int32)
            // -----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            tideDataValue.TideSiteTVItemID = 0;
            tideDataValueService.Add(tideDataValue);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideDataValueTideSiteTVItemID, tideDataValue.TideSiteTVItemID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

            // TideSiteTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tideDataValue.DateTime_Local   (DateTime)
            // -----------------------------------

            // DateTime_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // tideDataValue.Keep   (Boolean)
            // -----------------------------------

            // Keep will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tideDataValue.TideDataType   (TideDataTypeEnum)
            // -----------------------------------

            // TideDataType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tideDataValue.StorageDataType   (StorageDataTypeEnum)
            // -----------------------------------

            // StorageDataType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000)]
            // tideDataValue.Depth_m   (Double)
            // -----------------------------------

            //Error: Type not implemented [Depth_m]

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // Depth_m has Min [0.0D] and Max [10000.0D]. At Min should return true and no errors
            tideDataValue.Depth_m = 0.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [10000.0D]. At Min + 1 should return true and no errors
            tideDataValue.Depth_m = 1.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [10000.0D]. At Min - 1 should return false with one error
            tideDataValue.Depth_m = -1.0D;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "10000")).Any());
            Assert.AreEqual(-1.0D, tideDataValue.Depth_m);
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [10000.0D]. At Max should return true and no errors
            tideDataValue.Depth_m = 10000.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(10000.0D, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [10000.0D]. At Max - 1 should return true and no errors
            tideDataValue.Depth_m = 9999.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(9999.0D, tideDataValue.Depth_m);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // Depth_m has Min [0.0D] and Max [10000.0D]. At Max + 1 should return false with one error
            tideDataValue.Depth_m = 10001.0D;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "10000")).Any());
            Assert.AreEqual(10001.0D, tideDataValue.Depth_m);
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10)]
            // tideDataValue.UVelocity_m_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [UVelocity_m_s]

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // UVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            tideDataValue.UVelocity_m_s = 0.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            tideDataValue.UVelocity_m_s = 1.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            tideDataValue.UVelocity_m_s = -1.0D;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0D, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            tideDataValue.UVelocity_m_s = 10.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(10.0D, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            tideDataValue.UVelocity_m_s = 9.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(9.0D, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // UVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            tideDataValue.UVelocity_m_s = 11.0D;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0D, tideDataValue.UVelocity_m_s);
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10)]
            // tideDataValue.VVelocity_m_s   (Double)
            // -----------------------------------

            //Error: Type not implemented [VVelocity_m_s]

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            // VVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min should return true and no errors
            tideDataValue.VVelocity_m_s = 0.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(0.0D, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min + 1 should return true and no errors
            tideDataValue.VVelocity_m_s = 1.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(1.0D, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [0.0D] and Max [10.0D]. At Min - 1 should return false with one error
            tideDataValue.VVelocity_m_s = -1.0D;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(-1.0D, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max should return true and no errors
            tideDataValue.VVelocity_m_s = 10.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(10.0D, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max - 1 should return true and no errors
            tideDataValue.VVelocity_m_s = 9.0D;
            Assert.AreEqual(true, tideDataValueService.Add(tideDataValue));
            Assert.AreEqual(0, tideDataValue.ValidationResults.Count());
            Assert.AreEqual(9.0D, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(true, tideDataValueService.Delete(tideDataValue));
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());
            // VVelocity_m_s has Min [0.0D] and Max [10.0D]. At Max + 1 should return false with one error
            tideDataValue.VVelocity_m_s = 11.0D;
            Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
            Assert.IsTrue(tideDataValue.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "0", "10")).Any());
            Assert.AreEqual(11.0D, tideDataValue.VVelocity_m_s);
            Assert.AreEqual(count, tideDataValueService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // tideDataValue.TideStart   (TideTextEnum)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // tideDataValue.TideEnd   (TideTextEnum)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tideDataValue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tideDataValue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tideDataValue = null;
            tideDataValue = GetFilledRandomTideDataValue("");
            tideDataValue.LastUpdateContactTVItemID = 0;
            tideDataValueService.Add(tideDataValue);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideDataValueLastUpdateContactTVItemID, tideDataValue.LastUpdateContactTVItemID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tideDataValue.TideSiteTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tideDataValue.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
