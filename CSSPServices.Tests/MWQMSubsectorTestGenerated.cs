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
    public partial class MWQMSubsectorTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MWQMSubsectorService mwqmSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorTest() : base()
        {
            mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "RainDay0Limit") mwqmSubsector.RainDay0Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay1Limit") mwqmSubsector.RainDay1Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay2Limit") mwqmSubsector.RainDay2Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay3Limit") mwqmSubsector.RainDay3Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay4Limit") mwqmSubsector.RainDay4Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay5Limit") mwqmSubsector.RainDay5Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay6Limit") mwqmSubsector.RainDay6Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay7Limit") mwqmSubsector.RainDay7Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay8Limit") mwqmSubsector.RainDay8Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay9Limit") mwqmSubsector.RainDay9Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay10Limit") mwqmSubsector.RainDay10Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "IncludeRainStartDate") mwqmSubsector.IncludeRainStartDate = GetRandomDateTime();
            if (OmitPropName != "IncludeRainEndDate") mwqmSubsector.IncludeRainEndDate = GetRandomDateTime();
            if (OmitPropName != "IncludeRainRunCount") mwqmSubsector.IncludeRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "IncludeRainSelectFullYear") mwqmSubsector.IncludeRainSelectFullYear = true;
            if (OmitPropName != "NoRainStartDate") mwqmSubsector.NoRainStartDate = GetRandomDateTime();
            if (OmitPropName != "NoRainEndDate") mwqmSubsector.NoRainEndDate = GetRandomDateTime();
            if (OmitPropName != "NoRainRunCount") mwqmSubsector.NoRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "NoRainSelectFullYear") mwqmSubsector.NoRainSelectFullYear = true;
            if (OmitPropName != "OnlyRainStartDate") mwqmSubsector.OnlyRainStartDate = GetRandomDateTime();
            if (OmitPropName != "OnlyRainEndDate") mwqmSubsector.OnlyRainEndDate = GetRandomDateTime();
            if (OmitPropName != "OnlyRainRunCount") mwqmSubsector.OnlyRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "OnlyRainSelectFullYear") mwqmSubsector.OnlyRainSelectFullYear = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;

            return mwqmSubsector;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MWQMSubsector_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mwqmSubsectorService.GetRead().Count();

            mwqmSubsectorService.Add(mwqmSubsector);
            if (mwqmSubsector.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mwqmSubsectorService.GetRead().Where(c => c == mwqmSubsector).Any());
            mwqmSubsectorService.Update(mwqmSubsector);
            if (mwqmSubsector.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mwqmSubsectorService.GetRead().Count());
            mwqmSubsectorService.Delete(mwqmSubsector);
            if (mwqmSubsector.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSubsector.MWQMSubsectorID   (Int32)
            // -----------------------------------

            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorID = 0;
            mwqmSubsectorService.Update(mwqmSubsector);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorMWQMSubsectorID), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Subsector)]
            // [Range(1, -1)]
            // mwqmSubsector.MWQMSubsectorTVItemID   (Int32)
            // -----------------------------------

            // MWQMSubsectorTVItemID will automatically be initialized at 0 --> not null


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // MWQMSubsectorTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.MWQMSubsectorTVItemID = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.MWQMSubsectorTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // MWQMSubsectorTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.MWQMSubsectorTVItemID = 2;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSubsector.MWQMSubsectorTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // MWQMSubsectorTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.MWQMSubsectorTVItemID = 0;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSubsector.MWQMSubsectorTVItemID);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(20))]
            // mwqmSubsector.SubsectorHistoricKey   (String)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorSubsectorHistoricKey)).Any());
            Assert.AreEqual(null, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(0, mwqmSubsectorService.GetRead().Count());


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            // SubsectorHistoricKey has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string mwqmSubsectorSubsectorHistoricKeyMin = GetRandomString("", 20);
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorSubsectorHistoricKeyMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorSubsectorHistoricKeyMin, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // SubsectorHistoricKey has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            mwqmSubsectorSubsectorHistoricKeyMin = GetRandomString("", 19);
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorSubsectorHistoricKeyMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorSubsectorHistoricKeyMin, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // SubsectorHistoricKey has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            mwqmSubsectorSubsectorHistoricKeyMin = GetRandomString("", 21);
            mwqmSubsector.SubsectorHistoricKey = mwqmSubsectorSubsectorHistoricKeyMin;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorHistoricKey, "20")).Any());
            Assert.AreEqual(mwqmSubsectorSubsectorHistoricKeyMin, mwqmSubsector.SubsectorHistoricKey);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [StringLength(20))]
            // mwqmSubsector.TideLocationSIDText   (String)
            // -----------------------------------


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            // TideLocationSIDText has MinLength [empty] and MaxLength [20]. At Max should return true and no errors
            string mwqmSubsectorTideLocationSIDTextMin = GetRandomString("", 20);
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorTideLocationSIDTextMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorTideLocationSIDTextMin, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // TideLocationSIDText has MinLength [empty] and MaxLength [20]. At Max - 1 should return true and no errors
            mwqmSubsectorTideLocationSIDTextMin = GetRandomString("", 19);
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorTideLocationSIDTextMin;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(mwqmSubsectorTideLocationSIDTextMin, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // TideLocationSIDText has MinLength [empty] and MaxLength [20]. At Max + 1 should return false with one error
            mwqmSubsectorTideLocationSIDTextMin = GetRandomString("", 21);
            mwqmSubsector.TideLocationSIDText = mwqmSubsectorTideLocationSIDTextMin;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorTideLocationSIDText, "20")).Any());
            Assert.AreEqual(mwqmSubsectorTideLocationSIDTextMin, mwqmSubsector.TideLocationSIDText);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay0Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay0Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay0Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay0Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay0Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay0Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay0Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay0Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay0Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay0Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay0Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay1Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay1Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay1Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay1Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay1Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay1Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay1Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay1Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay1Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay1Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay1Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay2Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay2Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay2Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay2Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay2Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay2Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay2Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay2Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay2Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay2Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay2Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay3Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay3Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay3Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay3Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay3Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay3Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay3Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay3Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay3Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay3Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay3Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay4Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay4Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay4Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay4Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay4Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay4Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay4Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay4Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay4Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay4Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay4Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay5Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay5Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay5Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay5Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay5Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay5Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay5Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay5Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay5Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay5Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay5Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay6Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay6Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay6Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay6Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay6Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay6Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay6Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay6Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay6Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay6Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay6Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay7Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay7Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay7Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay7Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay7Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay7Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay7Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay7Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay7Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay7Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay7Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay8Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay8Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay8Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay8Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay8Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay8Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay8Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay8Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay8Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay8Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay8Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay9Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay9Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay9Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay9Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay9Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay9Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay9Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay9Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay9Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay9Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay9Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [Range(0, 300)]
            // mwqmSubsector.RainDay10Limit   (Double)
            // -----------------------------------

            //Error: Type not implemented [RainDay10Limit]


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // RainDay10Limit has Min [0.0D] and Max [300.0D]. At Min should return true and no errors
            mwqmSubsector.RainDay10Limit = 0.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0.0D, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0.0D] and Max [300.0D]. At Min + 1 should return true and no errors
            mwqmSubsector.RainDay10Limit = 1.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1.0D, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0.0D] and Max [300.0D]. At Min - 1 should return false with one error
            mwqmSubsector.RainDay10Limit = -1.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "300")).Any());
            Assert.AreEqual(-1.0D, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0.0D] and Max [300.0D]. At Max should return true and no errors
            mwqmSubsector.RainDay10Limit = 300.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(300.0D, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0.0D] and Max [300.0D]. At Max - 1 should return true and no errors
            mwqmSubsector.RainDay10Limit = 299.0D;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(299.0D, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // RainDay10Limit has Min [0.0D] and Max [300.0D]. At Max + 1 should return false with one error
            mwqmSubsector.RainDay10Limit = 301.0D;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "300")).Any());
            Assert.AreEqual(301.0D, mwqmSubsector.RainDay10Limit);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.IncludeRainStartDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.IncludeRainEndDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // mwqmSubsector.IncludeRainRunCount   (Int32)
            // -----------------------------------


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // IncludeRainRunCount has Min [0] and Max [10]. At Min should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Min + 1 should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Min - 1 should return false with one error
            mwqmSubsector.IncludeRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10")).Any());
            Assert.AreEqual(-1, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Max should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 10;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(10, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Max - 1 should return true and no errors
            mwqmSubsector.IncludeRainRunCount = 9;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(9, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // IncludeRainRunCount has Min [0] and Max [10]. At Max + 1 should return false with one error
            mwqmSubsector.IncludeRainRunCount = 11;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10")).Any());
            Assert.AreEqual(11, mwqmSubsector.IncludeRainRunCount);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // mwqmSubsector.IncludeRainSelectFullYear   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.NoRainStartDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.NoRainEndDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // mwqmSubsector.NoRainRunCount   (Int32)
            // -----------------------------------


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // NoRainRunCount has Min [0] and Max [10]. At Min should return true and no errors
            mwqmSubsector.NoRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Min + 1 should return true and no errors
            mwqmSubsector.NoRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Min - 1 should return false with one error
            mwqmSubsector.NoRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10")).Any());
            Assert.AreEqual(-1, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Max should return true and no errors
            mwqmSubsector.NoRainRunCount = 10;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(10, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Max - 1 should return true and no errors
            mwqmSubsector.NoRainRunCount = 9;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(9, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // NoRainRunCount has Min [0] and Max [10]. At Max + 1 should return false with one error
            mwqmSubsector.NoRainRunCount = 11;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10")).Any());
            Assert.AreEqual(11, mwqmSubsector.NoRainRunCount);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // mwqmSubsector.NoRainSelectFullYear   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.OnlyRainStartDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.OnlyRainEndDate   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [Range(0, 10)]
            // mwqmSubsector.OnlyRainRunCount   (Int32)
            // -----------------------------------


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // OnlyRainRunCount has Min [0] and Max [10]. At Min should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 0;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(0, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Min + 1 should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Min - 1 should return false with one error
            mwqmSubsector.OnlyRainRunCount = -1;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10")).Any());
            Assert.AreEqual(-1, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Max should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 10;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(10, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Max - 1 should return true and no errors
            mwqmSubsector.OnlyRainRunCount = 9;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(9, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // OnlyRainRunCount has Min [0] and Max [10]. At Max + 1 should return false with one error
            mwqmSubsector.OnlyRainRunCount = 11;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10")).Any());
            Assert.AreEqual(11, mwqmSubsector.OnlyRainRunCount);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // mwqmSubsector.OnlyRainSelectFullYear   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // [Range(1, -1)]
            // mwqmSubsector.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mwqmSubsector.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(1, mwqmSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mwqmSubsector.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.AreEqual(0, mwqmSubsector.ValidationResults.Count());
            Assert.AreEqual(2, mwqmSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mwqmSubsectorService.Delete(mwqmSubsector));
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mwqmSubsector.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
            Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mwqmSubsector.LastUpdateContactTVItemID);
            Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mwqmSubsector.MWQMSubsectorLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // mwqmSubsector.MWQMSubsectorTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // mwqmSubsector.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
