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
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
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
            TVItemLink tvItemLink = GetFilledRandomTVItemLink("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

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

            //Error: Type not implemented [FromTVType]

            //Error: Type not implemented [ToTVType]

            // Ordinal will automatically be initialized at 0 --> not null

            // TVLevel will automatically be initialized at 0 --> not null

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("TVPath");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVPath)).Any());
            Assert.AreEqual(null, tvItemLink.TVPath);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("LastUpdateDate_UTC");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkLastUpdateDate_UTC)).Any());
            Assert.IsTrue(tvItemLink.LastUpdateDate_UTC.Year < 1900);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null

            //Error: Type not implemented [FromTVItem]

            //Error: Type not implemented [ParentTVItemLink]

            //Error: Type not implemented [InverseParentTVItemLink]

            //Error: Type not implemented [ToTVItem]

            //Error: Type not implemented [ValidationResults]


            // -------------------------------
            // -------------------------------
            // Min and Max properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            // doing property [TVItemLinkID] of type [Int32]
            //-----------------------------------

            //-----------------------------------
            // doing property [FromTVItemID] of type [Int32]
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
            // doing property [ToTVItemID] of type [Int32]
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
            // doing property [Ordinal] of type [Int32]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // Ordinal has Min [0] and Max [100]. At Min should return true and no errors
            tvItemLink.Ordinal = 0;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(0, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Min + 1 should return true and no errors
            tvItemLink.Ordinal = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Min - 1 should return false with one error
            tvItemLink.Ordinal = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100")).Any());
            Assert.AreEqual(-1, tvItemLink.Ordinal);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max should return true and no errors
            tvItemLink.Ordinal = 100;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(100, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max - 1 should return true and no errors
            tvItemLink.Ordinal = 99;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(99, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max + 1 should return false with one error
            tvItemLink.Ordinal = 101;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100")).Any());
            Assert.AreEqual(101, tvItemLink.Ordinal);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [TVLevel] of type [Int32]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // TVLevel has Min [0] and Max [100]. At Min should return true and no errors
            tvItemLink.TVLevel = 0;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(0, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min + 1 should return true and no errors
            tvItemLink.TVLevel = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min - 1 should return false with one error
            tvItemLink.TVLevel = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100")).Any());
            Assert.AreEqual(-1, tvItemLink.TVLevel);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max should return true and no errors
            tvItemLink.TVLevel = 100;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(100, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max - 1 should return true and no errors
            tvItemLink.TVLevel = 99;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(99, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max + 1 should return false with one error
            tvItemLink.TVLevel = 101;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100")).Any());
            Assert.AreEqual(101, tvItemLink.TVLevel);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            // doing property [TVPath] of type [String]
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");

            //-----------------------------------
            // doing property [ParentTVItemLinkID] of type [Int32]
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
            // doing property [LastUpdateContactTVItemID] of type [Int32]
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

            //-----------------------------------
            // doing property [FromTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ParentTVItemLink] of type [TVItemLink]
            //-----------------------------------

            //-----------------------------------
            // doing property [InverseParentTVItemLink] of type [ICollection`1]
            //-----------------------------------

            //-----------------------------------
            // doing property [ToTVItem] of type [TVItem]
            //-----------------------------------

            //-----------------------------------
            // doing property [ValidationResults] of type [IEnumerable`1]
            //-----------------------------------

        }
        #endregion Tests Generated
    }
}
