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
    public partial class MikeSourceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private MikeSourceService mikeSourceService { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceTest() : base()
        {
            mikeSourceService = new MikeSourceService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MikeSource GetFilledRandomMikeSource(string OmitPropName)
        {
            MikeSource mikeSource = new MikeSource();

            if (OmitPropName != "MikeSourceTVItemID") mikeSource.MikeSourceTVItemID = 27;
            if (OmitPropName != "IsContinuous") mikeSource.IsContinuous = true;
            if (OmitPropName != "Include") mikeSource.Include = true;
            if (OmitPropName != "IsRiver") mikeSource.IsRiver = true;
            if (OmitPropName != "SourceNumberString") mikeSource.SourceNumberString = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;

            return mikeSource;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void MikeSource_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            MikeSource mikeSource = GetFilledRandomMikeSource("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = mikeSourceService.GetRead().Count();

            mikeSourceService.Add(mikeSource);
            if (mikeSource.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, mikeSourceService.GetRead().Where(c => c == mikeSource).Any());
            mikeSourceService.Update(mikeSource);
            if (mikeSource.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, mikeSourceService.GetRead().Count());
            mikeSourceService.Delete(mikeSource);
            if (mikeSource.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", mikeSource.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, mikeSourceService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // MikeSourceTVItemID will automatically be initialized at 0 --> not null

            // IsContinuous will automatically be initialized at 0 --> not null

            // Include will automatically be initialized at 0 --> not null

            // IsRiver will automatically be initialized at 0 --> not null

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("SourceNumberString");
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(1, mikeSource.ValidationResults.Count());
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceSourceNumberString)).Any());
            Assert.AreEqual(null, mikeSource.SourceNumberString);
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("LastUpdateDate_UTC");
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(1, mikeSource.ValidationResults.Count());
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MikeSourceLastUpdateDate_UTC)).Any());
            Assert.IsTrue(mikeSource.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [MikeSourceStartEnds]

            //Error: Type not implemented [MikeSourceTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [MikeSourceID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeSourceTVItemID] of type [Int32]
            //-----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            // MikeSourceTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeSource.MikeSourceTVItemID = 1;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(1, mikeSource.MikeSourceTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());
            // MikeSourceTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeSource.MikeSourceTVItemID = 2;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(2, mikeSource.MikeSourceTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());
            // MikeSourceTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeSource.MikeSourceTVItemID = 0;
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceMikeSourceTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeSource.MikeSourceTVItemID);
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());

            //-----------------------------------
            // doing property [IsContinuous] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [Include] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [IsRiver] of type [Boolean]
            //-----------------------------------

            //-----------------------------------
            // doing property [SourceNumberString] of type [String]
            //-----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            mikeSource = null;
            mikeSource = GetFilledRandomMikeSource("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            mikeSource.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(1, mikeSource.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            mikeSource.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, mikeSourceService.Add(mikeSource));
            Assert.AreEqual(0, mikeSource.ValidationResults.Count());
            Assert.AreEqual(2, mikeSource.LastUpdateContactTVItemID);
            Assert.AreEqual(true, mikeSourceService.Delete(mikeSource));
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            mikeSource.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, mikeSourceService.Add(mikeSource));
            Assert.IsTrue(mikeSource.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.MikeSourceLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, mikeSource.LastUpdateContactTVItemID);
            Assert.AreEqual(0, mikeSourceService.GetRead().Count());

            //-----------------------------------
            // doing property [MikeSourceStartEnds] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [MikeSourceTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
