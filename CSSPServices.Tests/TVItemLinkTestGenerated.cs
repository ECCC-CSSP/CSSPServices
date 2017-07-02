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
    public partial class TVItemLinkTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private int TVItemLinkID { get; set; }
        private LanguageEnum language { get; set; }
        private CultureInfo culture { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkTest() : base()
        {
            language = LanguageEnum.en;
            culture = new CultureInfo(language.ToString() + "-CA");
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemLink GetFilledRandomTVItemLink(string OmitPropName)
        {
            TVItemLinkID += 1;

            TVItemLink tvItemLink = new TVItemLink();

            if (OmitPropName != "TVItemLinkID") tvItemLink.TVItemLinkID = TVItemLinkID;
            if (OmitPropName != "FromTVItemID") tvItemLink.FromTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "ToTVItemID") tvItemLink.ToTVItemID = GetRandomInt(1, 11);
            if (OmitPropName != "FromTVType") tvItemLink.FromTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ToTVType") tvItemLink.ToTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 12);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 7);
            if (OmitPropName != "ParentTVItemLinkID") tvItemLink.ParentTVItemLinkID = GetRandomInt(1, 11);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLink.LastUpdateContactTVItemID = GetRandomInt(1, 11);

            return tvItemLink;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemLink_Testing()
        {
            SetupTestHelper(culture);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, ID, DatabaseTypeEnum.MemoryNoDBShape);

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            TVItemLink tvItemLink = GetFilledRandomTVItemLink("");
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(true, tvItemLinkService.GetRead().Where(c => c == tvItemLink).Any());
            tvItemLink.LastUpdateContactTVItemID = GetRandomInt(1, 11);
            Assert.AreEqual(true, tvItemLinkService.Update(tvItemLink));
            Assert.AreEqual(1, tvItemLinkService.GetRead().Count());
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Required properties testing
            // -------------------------------
            // -------------------------------

            // FromTVItemID will automatically be initialized at 0 --> not null

            // ToTVItemID will automatically be initialized at 0 --> not null

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("FromTVType");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkFromTVType)).Any());
            Assert.AreEqual(TVTypeEnum.Error, tvItemLink.FromTVType);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("ToTVType");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkToTVType)).Any());
            Assert.AreEqual(TVTypeEnum.Error, tvItemLink.ToTVType);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // Ordinal will automatically be initialized at 0 --> not null

            // TVLevel will automatically be initialized at 0 --> not null

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItemLink.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemLinkID] of type [int]
            //-----------------------------------

            //-----------------------------------
            // doing property [FromTVItemID] of type [int]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // FromTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.FromTVItemID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.FromTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // FromTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.FromTVItemID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.FromTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // FromTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.FromTVItemID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkFromTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.FromTVItemID);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [ToTVItemID] of type [int]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // ToTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.ToTVItemID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.ToTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // ToTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.ToTVItemID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.ToTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // ToTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.ToTVItemID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkToTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.ToTVItemID);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [FromTVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [ToTVType] of type [TVTypeEnum]
            //-----------------------------------

            //-----------------------------------
            // doing property [StartDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [EndDateTime_Local] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [Ordinal] of type [int]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // Ordinal has Min [0] and Max [1000]. At Min should return true and no errors
            tvItemLink.Ordinal = 0;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(0, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min + 1 should return true and no errors
            tvItemLink.Ordinal = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Min - 1 should return false with one error
            tvItemLink.Ordinal = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "1000")).Any());
            Assert.AreEqual(-1, tvItemLink.Ordinal);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max should return true and no errors
            tvItemLink.Ordinal = 1000;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1000, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max - 1 should return true and no errors
            tvItemLink.Ordinal = 999;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(999, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [1000]. At Max + 1 should return false with one error
            tvItemLink.Ordinal = 1001;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "1000")).Any());
            Assert.AreEqual(1001, tvItemLink.Ordinal);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [TVLevel] of type [int]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // TVLevel has Min [0] and Max [12]. At Min should return true and no errors
            tvItemLink.TVLevel = 0;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(0, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Min + 1 should return true and no errors
            tvItemLink.TVLevel = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Min - 1 should return false with one error
            tvItemLink.TVLevel = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "12")).Any());
            Assert.AreEqual(-1, tvItemLink.TVLevel);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Max should return true and no errors
            tvItemLink.TVLevel = 12;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(12, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Max - 1 should return true and no errors
            tvItemLink.TVLevel = 11;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(11, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [12]. At Max + 1 should return false with one error
            tvItemLink.TVLevel = 13;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "12")).Any());
            Assert.AreEqual(13, tvItemLink.TVLevel);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [TVPath] of type [string]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");

            // TVPath has MinLength [2] and MaxLength [250]. At Min should return true and no errors
            string tvItemLinkTVPathMin = GetRandomString("", 2);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Min + 1 should return true and no errors
            tvItemLinkTVPathMin = GetRandomString("", 3);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Min - 1 should return false with one error
            tvItemLinkTVPathMin = GetRandomString("", 1);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemLinkTVPath, "2", "250")).Any());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Max should return true and no errors
            tvItemLinkTVPathMin = GetRandomString("", 250);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Max - 1 should return true and no errors
            tvItemLinkTVPathMin = GetRandomString("", 249);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [2] and MaxLength [250]. At Max + 1 should return false with one error
            tvItemLinkTVPathMin = GetRandomString("", 251);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._LengthShouldBeBetween_And_, ModelsRes.TVItemLinkTVPath, "2", "250")).Any());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [ParentTVItemLinkID] of type [int]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // ParentTVItemLinkID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.ParentTVItemLinkID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.ParentTVItemLinkID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // ParentTVItemLinkID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.ParentTVItemLinkID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.ParentTVItemLinkID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // ParentTVItemLinkID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.ParentTVItemLinkID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkParentTVItemLinkID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.ParentTVItemLinkID);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [LastUpdateDate_UTC] of type [DateTime]
            //-----------------------------------

            //-----------------------------------
            // doing property [LastUpdateContactTVItemID] of type [int]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.LastUpdateContactTVItemID);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

        }
        #endregion Tests Generated
    }
}
