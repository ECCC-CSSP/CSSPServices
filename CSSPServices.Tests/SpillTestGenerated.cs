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
        private SpillService spillService { get; set; }
        #endregion Properties

        #region Constructors
        public SpillTest() : base()
        {
            spillService = new SpillService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private Spill GetFilledRandomSpill(string OmitPropName)
        {
            Spill spill = new Spill();

            if (OmitPropName != "MunicipalityTVItemID") spill.MunicipalityTVItemID = 14;
            if (OmitPropName != "InfrastructureTVItemID") spill.InfrastructureTVItemID = 16;
            if (OmitPropName != "StartDateTime_Local") spill.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") spill.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "AverageFlow_m3_day") spill.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") spill.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spill.LastUpdateContactTVItemID = 2;

            return spill;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void Spill_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            Spill spill = GetFilledRandomSpill("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = spillService.GetRead().Count();

            spillService.Add(spill);
            if (spill.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, spillService.GetRead().Where(c => c == spill).Any());
            spillService.Update(spill);
            if (spill.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, spillService.GetRead().Count());
            spillService.Delete(spill);
            if (spill.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", spill.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, spillService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // spill.SpillID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.SpillID = 0;
            spillService.Update(spill);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.SpillSpillID), spill.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Municipality)]
            // spill.MunicipalityTVItemID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.MunicipalityTVItemID = 0;
            spillService.Add(spill);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillMunicipalityTVItemID, spill.MunicipalityTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

            // MunicipalityTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Infrastructure)]
            // spill.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.InfrastructureTVItemID = 0;
            spillService.Add(spill);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillInfrastructureTVItemID, spill.InfrastructureTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spill.StartDateTime_Local   (DateTime)
            // -----------------------------------

            // StartDateTime_Local will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateTime_Local)]
            // spill.EndDateTime_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 1000000)]
            // spill.AverageFlow_m3_day   (Double)
            // -----------------------------------

            //Error: Type not implemented [AverageFlow_m3_day]

            spill = null;
            spill = GetFilledRandomSpill("");
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min should return true and no errors
            spill.AverageFlow_m3_day = 0.0D;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(0.0D, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(count, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min + 1 should return true and no errors
            spill.AverageFlow_m3_day = 1.0D;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1.0D, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(count, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Min - 1 should return false with one error
            spill.AverageFlow_m3_day = -1.0D;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SpillAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(-1.0D, spill.AverageFlow_m3_day);
            Assert.AreEqual(count, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max should return true and no errors
            spill.AverageFlow_m3_day = 1000000.0D;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(1000000.0D, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(count, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max - 1 should return true and no errors
            spill.AverageFlow_m3_day = 999999.0D;
            Assert.AreEqual(true, spillService.Add(spill));
            Assert.AreEqual(0, spill.ValidationResults.Count());
            Assert.AreEqual(999999.0D, spill.AverageFlow_m3_day);
            Assert.AreEqual(true, spillService.Delete(spill));
            Assert.AreEqual(count, spillService.GetRead().Count());
            // AverageFlow_m3_day has Min [0.0D] and Max [1000000.0D]. At Max + 1 should return false with one error
            spill.AverageFlow_m3_day = 1000001.0D;
            Assert.AreEqual(false, spillService.Add(spill));
            Assert.IsTrue(spill.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.SpillAverageFlow_m3_day, "0", "1000000")).Any());
            Assert.AreEqual(1000001.0D, spill.AverageFlow_m3_day);
            Assert.AreEqual(count, spillService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spill.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // spill.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.LastUpdateContactTVItemID = 0;
            spillService.Add(spill);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.SpillLastUpdateContactTVItemID, spill.LastUpdateContactTVItemID.ToString()), spill.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // spill.SpillLanguages   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // spill.InfrastructureTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // spill.MunicipalityTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // spill.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
