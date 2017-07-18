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
    public partial class SpillTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int SpillID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public SpillTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Spill GetFilledRandomSpill(string OmitPropName)
        {
            SpillID += 1;

            Spill spill = new Spill();

            if (OmitPropName != "SpillID") spill.SpillID = SpillID;
            if (OmitPropName != "MunicipalityTVItemID") spill.MunicipalityTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "InfrastructureTVItemID") spill.InfrastructureTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "StartDateTime_Local") spill.StartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_Local") spill.EndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "AverageFlow_m3_day") spill.AverageFlow_m3_day = GetRandomFloat(0.0f, 1000000.0f);
            if (OmitPropName != "LastUpdateDate_UTC") spill.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") spill.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return spill;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Spill_Testing()
        {
            SetupTestHelper(culture);
            SpillService spillService = new SpillService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);
            Spill spill = GetFilledRandomSpill("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(true, spillService.GetRead().Where(c => c == spill).Any());
            spill.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, spillService.Update(spill));
            Assert.AreEqual(1, spillService.GetRead().Count());
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MunicipalityTVItemID will automatically be initialized at 0 --> not null

            spill = null;
            spill = GetFilledRandomSpill("StartDateTime_Local");
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.AreEqual(1, spill.ValidationResults.Count());
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillStartDateTime_Local)).Any());
            Assert.IsTrue(spill.StartDateTime_Local.Year < 1900);
            Assert.AreEqual(0, spillService.GetRead().Count());

            // AverageFlow_m3_day will automatically be initialized at 0 --> not null

            spill = null;
            spill = GetFilledRandomSpill("LastUpdateDate_UTC");
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.AreEqual(1, spill.ValidationResults.Count());
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.SpillLastUpdateDate_UTC)).Any());
            Assert.IsTrue(spill.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, spillService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [SpillLanguages]

            //Error: Type not implemented [InfrastructureTVItem]

            //Error: Type not implemented [MunicipalityTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [SpillID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MunicipalityTVItemID] of type [Int32]
            //-----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            // MunicipalityTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            spill.MunicipalityTVItemID = 1;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1, spill.MunicipalityTVItemID);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // MunicipalityTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            spill.MunicipalityTVItemID = 2;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(2, spill.MunicipalityTVItemID);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // MunicipalityTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            spill.MunicipalityTVItemID = 0;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillMunicipalityTVItemID, "1")).Any());
            Assert.AreEqual(0, spill.MunicipalityTVItemID);
            Assert.AreEqual(0, spillService.GetRead().Count());

            //-----------------------------------
            // doing property [InfrastructureTVItemID] of type [Int32]
            //-----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            spill.InfrastructureTVItemID = 1;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1, spill.InfrastructureTVItemID);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            spill.InfrastructureTVItemID = 2;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(2, spill.InfrastructureTVItemID);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // InfrastructureTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            spill.InfrastructureTVItemID = 0;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillInfrastructureTVItemID, "1")).Any());
            Assert.AreEqual(0, spill.InfrastructureTVItemID);
            Assert.AreEqual(0, spillService.GetRead().Count());

            //-----------------------------------
            // doing property [StartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [AverageFlow_m3_day] of type [Single]
            //-----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Min should return true and no errors
            spill.AverageFlow_m3_day = 0.0f;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(0.0f, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Min + 1 should return true and no errors
            spill.AverageFlow_m3_day = 1.0f;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1.0f, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Min - 1 should return false with one error
            spill.AverageFlow_m3_day = -1.0f;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SpillAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0f, spill.AverageFlow_m3_day);
            Assert.AreEqual(0, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Max should return true and no errors
            spill.AverageFlow_m3_day = 1000000.0f;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1000000.0f, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Max - 1 should return true and no errors
            spill.AverageFlow_m3_day = 999999.0f;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(999999.0f, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0] and Max [1000000]. At Max + 1 should return false with one error
            spill.AverageFlow_m3_day = 1000001.0f;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SpillAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0f, spill.AverageFlow_m3_day);
            Assert.AreEqual(0, spillService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            spill.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1, spill.LastUpdateContactTVItemID);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            spill.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(2, spill.LastUpdateContactTVItemID);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(0, spillService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            spill.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.SpillLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, spill.LastUpdateContactTVItemID);
            Assert.AreEqual(0, spillService.GetRead().Count());

            //-----------------------------------
            // doing property [SpillLanguages] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [InfrastructureTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [MunicipalityTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
