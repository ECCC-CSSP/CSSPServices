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
        private TVItemLinkService tvItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkTest() : base()
        {
            tvItemLinkService = new TVItemLinkService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemLink GetFilledRandomTVItemLink(string OmitPropName)
        {
            TVItemLink tvItemLink = new TVItemLink();

            if (OmitPropName != "FromTVItemID") tvItemLink.FromTVItemID = 2;
            if (OmitPropName != "ToTVItemID") tvItemLink.ToTVItemID = 2;
            if (OmitPropName != "FromTVType") tvItemLink.FromTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ToTVType") tvItemLink.ToTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = GetRandomDateTime();
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
            if (OmitPropName != "ParentTVItemLinkID") tvItemLink.ParentTVItemLinkID = 2;
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = GetRandomDateTime();
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLink.LastUpdateContactTVItemID = 2;

            return tvItemLink;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemLink_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVItemLink tvItemLink = GetFilledRandomTVItemLink("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvItemLinkService.GetRead().Count();

            tvItemLinkService.Add(tvItemLink);
            if (tvItemLink.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvItemLinkService.GetRead().Where(c => c == tvItemLink).Any());
            tvItemLinkService.Update(tvItemLink);
            if (tvItemLink.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvItemLinkService.GetRead().Count());
            tvItemLinkService.Delete(tvItemLink);
            if (tvItemLink.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            //-----------------------------------
            //[Key]
            //Is NOT Nullable
            // tvItemLink.TVItemLinkID   (Int32)
            //-----------------------------------
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVItemLinkID = 0;
            tvItemLinkService.Update(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVItemLinkID), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // tvItemLink.FromTVItemID   (Int32)
            //-----------------------------------
            // FromTVItemID will automatically be initialized at 0 --> not null


            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // FromTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.FromTVItemID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.FromTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // FromTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.FromTVItemID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.FromTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // FromTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.FromTVItemID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkFromTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.FromTVItemID);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // tvItemLink.ToTVItemID   (Int32)
            //-----------------------------------
            // ToTVItemID will automatically be initialized at 0 --> not null


            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // ToTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.ToTVItemID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.ToTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // ToTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.ToTVItemID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.ToTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // ToTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.ToTVItemID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkToTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.ToTVItemID);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // tvItemLink.FromTVType   (TVTypeEnum)
            //-----------------------------------
            // FromTVType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPEnumType]
            // tvItemLink.ToTVType   (TVTypeEnum)
            //-----------------------------------
            // ToTVType will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            // tvItemLink.StartDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is Nullable
            //[CSSPAfter(Year = 1980)]
            //[CSSPBigger(OtherField = StartDateTime_Local)]
            // tvItemLink.EndDateTime_Local   (DateTime)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // tvItemLink.Ordinal   (Int32)
            //-----------------------------------
            // Ordinal will automatically be initialized at 0 --> not null


            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // Ordinal has Min [0] and Max [100]. At Min should return true and no errors
            tvItemLink.Ordinal = 0;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(0, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Min + 1 should return true and no errors
            tvItemLink.Ordinal = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Min - 1 should return false with one error
            tvItemLink.Ordinal = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100")).Any());
            Assert.AreEqual(-1, tvItemLink.Ordinal);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max should return true and no errors
            tvItemLink.Ordinal = 100;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(100, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max - 1 should return true and no errors
            tvItemLink.Ordinal = 99;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(99, tvItemLink.Ordinal);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // Ordinal has Min [0] and Max [100]. At Max + 1 should return false with one error
            tvItemLink.Ordinal = 101;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100")).Any());
            Assert.AreEqual(101, tvItemLink.Ordinal);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[Range(0, 100)]
            // tvItemLink.TVLevel   (Int32)
            //-----------------------------------
            // TVLevel will automatically be initialized at 0 --> not null


            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // TVLevel has Min [0] and Max [100]. At Min should return true and no errors
            tvItemLink.TVLevel = 0;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(0, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min + 1 should return true and no errors
            tvItemLink.TVLevel = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Min - 1 should return false with one error
            tvItemLink.TVLevel = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100")).Any());
            Assert.AreEqual(-1, tvItemLink.TVLevel);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max should return true and no errors
            tvItemLink.TVLevel = 100;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(100, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max - 1 should return true and no errors
            tvItemLink.TVLevel = 99;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(99, tvItemLink.TVLevel);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // TVLevel has Min [0] and Max [100]. At Max + 1 should return false with one error
            tvItemLink.TVLevel = 101;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100")).Any());
            Assert.AreEqual(101, tvItemLink.TVLevel);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[StringLength(250))]
            // tvItemLink.TVPath   (String)
            //-----------------------------------
            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("TVPath");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVPath)).Any());
            Assert.AreEqual(null, tvItemLink.TVPath);
            Assert.AreEqual(0, tvItemLinkService.GetRead().Count());


            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");

            // TVPath has MinLength [empty] and MaxLength [250]. At Max should return true and no errors
            string tvItemLinkTVPathMin = GetRandomString("", 250);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [empty] and MaxLength [250]. At Max - 1 should return true and no errors
            tvItemLinkTVPathMin = GetRandomString("", 249);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            // TVPath has MinLength [empty] and MaxLength [250]. At Max + 1 should return false with one error
            tvItemLinkTVPathMin = GetRandomString("", 251);
            tvItemLink.TVPath = tvItemLinkTVPathMin;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkTVPath, "250")).Any());
            Assert.AreEqual(tvItemLinkTVPathMin, tvItemLink.TVPath);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            //[Range(1, -1)]
            // tvItemLink.ParentTVItemLinkID   (Int32)
            //-----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // ParentTVItemLinkID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.ParentTVItemLinkID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.ParentTVItemLinkID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // ParentTVItemLinkID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.ParentTVItemLinkID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.ParentTVItemLinkID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // ParentTVItemLinkID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.ParentTVItemLinkID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkParentTVItemLinkID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.ParentTVItemLinkID);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[CSSPAfter(Year = 1980)]
            // tvItemLink.LastUpdateDate_UTC   (DateTime)
            //-----------------------------------
            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            //-----------------------------------
            //Is NOT Nullable
            //[CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            //[Range(1, -1)]
            // tvItemLink.LastUpdateContactTVItemID   (Int32)
            //-----------------------------------
            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min should return true and no errors
            tvItemLink.LastUpdateContactTVItemID = 1;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(1, tvItemLink.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min + 1 should return true and no errors
            tvItemLink.LastUpdateContactTVItemID = 2;
            Assert.AreEqual(true, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(0, tvItemLink.ValidationResults.Count());
            Assert.AreEqual(2, tvItemLink.LastUpdateContactTVItemID);
            Assert.AreEqual(true, tvItemLinkService.Delete(tvItemLink));
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            // LastUpdateContactTVItemID has Min [1] and Max [empty]. At Min - 1 should return false with one error
            tvItemLink.LastUpdateContactTVItemID = 0;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._MinValueIs_, ModelsRes.TVItemLinkLastUpdateContactTVItemID, "1")).Any());
            Assert.AreEqual(0, tvItemLink.LastUpdateContactTVItemID);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // tvItemLink.FromTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // tvItemLink.ParentTVItemLink   (TVItemLink)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // tvItemLink.InverseParentTVItemLink   (ICollection`1)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[IsVirtual]
            // tvItemLink.ToTVItem   (TVItem)
            //-----------------------------------

            //-----------------------------------
            //Is NOT Nullable
            //[NotMapped]
            // tvItemLink.ValidationResults   (IEnumerable`1)
            //-----------------------------------
        }
        #endregion Tests Generated
    }
}
