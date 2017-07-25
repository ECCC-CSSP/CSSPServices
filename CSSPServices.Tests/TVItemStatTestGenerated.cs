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
    public partial class TVItemStatTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemStatService tvItemStatService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatTest() : base()
        {
            tvItemStatService = new TVItemStatService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;

            return tvItemStat;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemStat_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVItemStat tvItemStat = GetFilledRandomTVItemStat("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvItemStatService.GetRead().Count();

            tvItemStatService.Add(tvItemStat);
            if (tvItemStat.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvItemStatService.GetRead().Where(c => c == tvItemStat).Any());
            tvItemStatService.Update(tvItemStat);
            if (tvItemStat.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvItemStatService.GetRead().Count());
            tvItemStatService.Delete(tvItemStat);
            if (tvItemStat.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVType]

            // ChildCount will automatically be initialized at 0 --> not null

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(1, tvItemStat.ValidationResults.Count());
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemStatLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItemStat.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [TVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemStatID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVItemID] of type [Int32]
            //-----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            // TVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemStat.TVItemID = 1;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(1, tvItemStat.TVItemID);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemStat.TVItemID = 2;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(2, tvItemStat.TVItemID);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // TVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemStat.TVItemID = 0;
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemStatTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemStat.TVItemID);
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ChildCount] of type [Int32]
            //-----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            // ChildCount has Min [0] and Max [10000000]. At Min should return true and no errors
            tvItemStat.ChildCount = 0;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(0, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            tvItemStat.ChildCount = 1;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(1, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            tvItemStat.ChildCount = -1;
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemStatChildCount, "0", "10000000")).Any());
            Assert.AreEqual(-1, tvItemStat.ChildCount);
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Max should return true and no errors
            tvItemStat.ChildCount = 10000000;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(10000000, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            tvItemStat.ChildCount = 9999999;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(9999999, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            tvItemStat.ChildCount = 10000001;
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemStatChildCount, "0", "10000000")).Any());
            Assert.AreEqual(10000001, tvItemStat.ChildCount);
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [Int32]
            //-----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemStat.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(1, tvItemStat.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemStat.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(2, tvItemStat.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemStat.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemStatLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemStat.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvItemStatService.GetRead().Count());

            //-----------------------------------
            // doing property [TVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
