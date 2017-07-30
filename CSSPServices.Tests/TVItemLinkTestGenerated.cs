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
using CSSPEnums.Resources;

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
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
            if (OmitPropName != "ParentTVItemLinkID") tvItemLink.ParentTVItemLinkID = 2;
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
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


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemLink.TVItemLinkID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVItemLinkID = 0;
            tvItemLinkService.Update(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVItemLinkID), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemLink.FromTVItemID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.FromTVItemID = 0;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemLink.ToTVItemID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ToTVItemID = 0;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLink.FromTVType   (TVTypeEnum)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.FromTVType = (TVTypeEnum)1000000;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkFromTVType), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemLink.ToTVType   (TVTypeEnum)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ToTVType = (TVTypeEnum)1000000;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkToTVType), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemLink.StartDateTime_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateTime_Local)]
            // tvItemLink.EndDateTime_Local   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // tvItemLink.Ordinal   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.Ordinal = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.Ordinal = 101;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkOrdinal, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 100)]
            // tvItemLink.TVLevel   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVLevel = -1;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());
            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVLevel = 101;
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemLinkTVLevel, "0", "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [StringLength(250))]
            // tvItemLink.TVPath   (String)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("TVPath");
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(1, tvItemLink.ValidationResults.Count());
            Assert.IsTrue(tvItemLink.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemLinkTVPath)).Any());
            Assert.AreEqual(null, tvItemLink.TVPath);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.TVPath = GetRandomString("", 251);
            Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
            Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkTVPath, "250"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
            Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemLink.ParentTVItemLinkID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.ParentTVItemLinkID = 0;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkParentTVItemLinkID, tvItemLink.ParentTVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemLink.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvItemLink.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.LastUpdateContactTVItemID = 0;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkLastUpdateContactTVItemID, tvItemLink.LastUpdateContactTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

            tvItemLink = null;
            tvItemLink = GetFilledRandomTVItemLink("");
            tvItemLink.LastUpdateContactTVItemID = 1;
            tvItemLinkService.Add(tvItemLink);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkLastUpdateContactTVItemID, "Contact"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemLink.FromTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemLink.ParentTVItemLink   (TVItemLink)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemLink.InverseParentTVItemLink   (ICollection`1)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemLink.ToTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvItemLink.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
