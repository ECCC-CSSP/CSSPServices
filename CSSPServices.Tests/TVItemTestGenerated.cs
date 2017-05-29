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
    public partial class TVItemTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItemID += 1;

            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVItemID") tvItem.TVItemID = TVItemID;
            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 12);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 7);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = GetRandomInt(1, 11);
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvItem;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItem_Testing()
        {
            SetupTestHelper(LoginEmail, culture);
            TVItemService tvItemService = new TVItemService(LanguageRequest, User, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            TVItem tvItem = GetFilledRandomTVItem("");
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(true, tvItemService.GetRead().Where(c => c == tvItem).Any());
            tvItem.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvItemService.Update(tvItem));
            Assert.AreEqual(1, tvItemService.GetRead().Count());
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // TVLevel will automatically be initialized at 0 --> not null

            tvItem = null;
            tvItem = GetFilledRandomTVItem("TVPath");
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.AreEqual(1, tvItem.ValidationResults.Count());
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath)).Any());
            Assert.AreEqual(null, tvItem.TVPath);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            tvItem = null;
            tvItem = GetFilledRandomTVItem("TVType");
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.AreEqual(1, tvItem.ValidationResults.Count());
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVType)).Any());
            Assert.AreEqual(TVTypeEnum.Error, tvItem.TVType);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // ParentID will automatically be initialized at 0 --> not null

            // IsActive will automatically be initialized at false --> not null

            tvItem = null;
            tvItem = GetFilledRandomTVItem("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.AreEqual(1, tvItem.ValidationResults.Count());
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItem.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [TVLevel] of type [int]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // TVLevel has Min [0] and Max [12]. At Min should return true and no errors
            tvItem.TVLevel = 0;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(0, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Min + 1 should return true and no errors
            tvItem.TVLevel = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Min - 1 should return false with one error
            tvItem.TVLevel = -1;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "12")).Any());
            Assert.AreEqual(-1, tvItem.TVLevel);
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Max should return true and no errors
            tvItem.TVLevel = 12;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(12, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Max - 1 should return true and no errors
            tvItem.TVLevel = 11;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(11, tvItem.TVLevel);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Max + 1 should return false with one error
            tvItem.TVLevel = 13;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "12")).Any());
            Assert.AreEqual(13, tvItem.TVLevel);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //-----------------------------------
            // doing property [TVPath] of type [string]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");

            // TVPath has MinLength [2] and MaxLength [250]. At Min should return true and no errors
            string tvItemTVPathMin = GetRandomString("", 2);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Min + 1 should return true and no errors
            tvItemTVPathMin = GetRandomString("", 3);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Min - 1 should return false with one error
            tvItemTVPathMin = GetRandomString("", 1);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemTVPath, "2", "250")).Any());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Max should return true and no errors
            tvItemTVPathMin = GetRandomString("", 250);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Max - 1 should return true and no errors
            tvItemTVPathMin = GetRandomString("", 249);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Max + 1 should return false with one error
            tvItemTVPathMin = GetRandomString("", 251);
            tvItem.TVPath = tvItemTVPathMin;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemTVPath, "2", "250")).Any());
            Assert.AreEqual(tvItemTVPathMin, tvItem.TVPath);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //-----------------------------------
            // doing property [TVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ParentID] of type [int]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // ParentID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItem.ParentID = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.ParentID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // ParentID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItem.ParentID = 2;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(2, tvItem.ParentID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // ParentID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItem.ParentID = 0;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemParentID, "1")).Any());
            Assert.AreEqual(0, tvItem.ParentID);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

            //-----------------------------------
            // doing property [IsActive] of type [bool]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItem.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(1, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItem.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemService.Add(tvItem));
            Assert.AreEqual(0, tvItem.ValidationResults.Count());
            Assert.AreEqual(2, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemService.Delete(tvItem));
            Assert.AreEqual(0, tvItemService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItem.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemService.Add(tvItem));
            Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItem.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvItemService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
