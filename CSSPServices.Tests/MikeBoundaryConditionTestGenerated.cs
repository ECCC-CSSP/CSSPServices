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
    public partial class MikeBoundaryConditionTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int MikeBoundaryConditionID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeBoundaryCondition GetFilledRandomMikeBoundaryCondition(string OmitPropName)
        {
            MikeBoundaryConditionID += 1;

            MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();

            if (OmitPropName != "MikeBoundaryConditionID") mikeBoundaryCondition.MikeBoundaryConditionID = MikeBoundaryConditionID;
            if (OmitPropName != "MikeBoundaryConditionTVItemID") mikeBoundaryCondition.MikeBoundaryConditionTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "MikeBoundaryConditionCode") mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionName") mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLength_m") mikeBoundaryCondition.MikeBoundaryConditionLength_m = GetRandomFloat(0, 1000000);
            if (OmitPropName != "MikeBoundaryConditionFormat") mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLevelOrVelocity") mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)GetRandomEnumType(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            if (OmitPropName != "WebTideDataSet") mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "NumberOfWebTideNodes") mikeBoundaryCondition.NumberOfWebTideNodes = GetRandomInt(1, 100);
            if (OmitPropName != "WebTideDataFromStartToEndDate") mikeBoundaryCondition.WebTideDataFromStartToEndDate = GetRandomString("", 20);
            if (OmitPropName != "TVType") mikeBoundaryCondition.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mikeBoundaryCondition.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mikeBoundaryCondition.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return mikeBoundaryCondition;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeBoundaryCondition_Testing()
        {
            SetupTestHelper(culture);
            MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            MikeBoundaryCondition mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(true, mikeBoundaryConditionService.GetRead().Where(c => c == mikeBoundaryCondition).Any());
            mikeBoundaryCondition.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, mikeBoundaryConditionService.Update(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryConditionService.GetRead().Count());
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MikeBoundaryConditionTVItemID will automatically be initialized at 0 --> not null

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionCode");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionName");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionLength_m will automatically be initialized at 0.0f --> not null

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionFormat");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat)).Any());
            Assert.AreEqual(null, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionLevelOrVelocity");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLevelOrVelocity)).Any());
            Assert.AreEqual(MikeBoundaryConditionLevelOrVelocityEnum.Error, mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("WebTideDataSet");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionWebTideDataSet)).Any());
            Assert.AreEqual(WebTideDataSetEnum.Error, mikeBoundaryCondition.WebTideDataSet);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // NumberOfWebTideNodes will automatically be initialized at 0 --> not null

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("TVType");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionTVType)).Any());
            Assert.AreEqual(TVTypeEnum.Error, mikeBoundaryCondition.TVType);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("LastUpdateDate_UTC");
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(1, mikeBoundaryCondition.ValidationResults.Count());
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeBoundaryConditionLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mikeBoundaryCondition.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MikeBoundaryConditionID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeBoundaryConditionTVItemID] of type [int]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // MikeBoundaryConditionTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 1;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1, mikeBoundaryCondition.MikeBoundaryConditionTVItemID);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 2;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(2, mikeBoundaryCondition.MikeBoundaryConditionTVItemID);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 0;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeBoundaryCondition.MikeBoundaryConditionTVItemID);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeBoundaryConditionCode] of type [string]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

            // MikeBoundaryConditionCode has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string mikeBoundaryConditionMikeBoundaryConditionCodeMin = GetRandomString("", 100);
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionMikeBoundaryConditionCodeMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionCodeMin, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionCode has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            mikeBoundaryConditionMikeBoundaryConditionCodeMin = GetRandomString("", 99);
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionMikeBoundaryConditionCodeMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionCodeMin, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionCode has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            mikeBoundaryConditionMikeBoundaryConditionCodeMin = GetRandomString("", 101);
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionMikeBoundaryConditionCodeMin;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionCode, "100")).Any());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionCodeMin, mikeBoundaryCondition.MikeBoundaryConditionCode);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeBoundaryConditionName] of type [string]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

            // MikeBoundaryConditionName has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string mikeBoundaryConditionMikeBoundaryConditionNameMin = GetRandomString("", 100);
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionMikeBoundaryConditionNameMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionNameMin, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionName has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            mikeBoundaryConditionMikeBoundaryConditionNameMin = GetRandomString("", 99);
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionMikeBoundaryConditionNameMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionNameMin, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionName has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            mikeBoundaryConditionMikeBoundaryConditionNameMin = GetRandomString("", 101);
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionMikeBoundaryConditionNameMin;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionName, "100")).Any());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionNameMin, mikeBoundaryCondition.MikeBoundaryConditionName);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeBoundaryConditionLength_m] of type [float]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // MikeBoundaryConditionLength_m has Min [0] and Max [1000000]. At Min should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 0.0f;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(0.0f, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 1.0f;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1.0f, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = -1.0f;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [0] and Max [1000000]. At Max should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 1000000.0f;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 999999.0f;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(999999.0f, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // MikeBoundaryConditionLength_m has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 1000001.0f;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionLength_m, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, mikeBoundaryCondition.MikeBoundaryConditionLength_m);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeBoundaryConditionFormat] of type [string]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

            // MikeBoundaryConditionFormat has MinLength [empty] and MaxLength [100]. At Max should return true and no errors
            string mikeBoundaryConditionMikeBoundaryConditionFormatMin = GetRandomString("", 100);
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionMikeBoundaryConditionFormatMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionFormatMin, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionFormat has MinLength [empty] and MaxLength [100]. At Max - 1 should return true and no errors
            mikeBoundaryConditionMikeBoundaryConditionFormatMin = GetRandomString("", 99);
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionMikeBoundaryConditionFormatMin;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionFormatMin, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            // MikeBoundaryConditionFormat has MinLength [empty] and MaxLength [100]. At Max + 1 should return false with one error
            mikeBoundaryConditionMikeBoundaryConditionFormatMin = GetRandomString("", 101);
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionMikeBoundaryConditionFormatMin;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MikeBoundaryConditionMikeBoundaryConditionFormat, "100")).Any());
            Assert.AreEqual(mikeBoundaryConditionMikeBoundaryConditionFormatMin, mikeBoundaryCondition.MikeBoundaryConditionFormat);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeBoundaryConditionLevelOrVelocity] of type [MikeBoundaryConditionLevelOrVelocityEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [WebTideDataSet] of type [WebTideDataSetEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [NumberOfWebTideNodes] of type [int]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // NumberOfWebTideNodes has Min [1] and Max [100]. At Min should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 1;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [1] and Max [100]. At Min + 1 should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 2;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(2, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [1] and Max [100]. At Min - 1 should return false with one error
            mikeBoundaryCondition.NumberOfWebTideNodes = 0;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "1", "100")).Any());
            Assert.AreEqual(0, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [1] and Max [100]. At Max should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 100;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(100, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [1] and Max [100]. At Max - 1 should return true and no errors
            mikeBoundaryCondition.NumberOfWebTideNodes = 99;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(99, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // NumberOfWebTideNodes has Min [1] and Max [100]. At Max + 1 should return false with one error
            mikeBoundaryCondition.NumberOfWebTideNodes = 101;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MikeBoundaryConditionNumberOfWebTideNodes, "1", "100")).Any());
            Assert.AreEqual(101, mikeBoundaryCondition.NumberOfWebTideNodes);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

            //-----------------------------------
            // doing property [WebTideDataFromStartToEndDate] of type [string]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeBoundaryCondition.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(1, mikeBoundaryCondition.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeBoundaryCondition.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryCondition.ValidationResults.Count());
            Assert.AreEqual(2, mikeBoundaryCondition.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeBoundaryConditionService.Delete(mikeBoundaryCondition));
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeBoundaryCondition.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mikeBoundaryConditionService.Add(mikeBoundaryCondition));
            Assert.IsTrue(mikeBoundaryCondition.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeBoundaryConditionLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeBoundaryCondition.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mikeBoundaryConditionService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
