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
    public partial class TVItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemService tvItemService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemServiceTest() : base()
        {
            //tvItemService = new TVItemService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = 1;
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "TVText") tvItem.TVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") tvItem.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TVTypeText") tvItem.TVTypeText = GetRandomString("", 5);

            return tvItem;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItem_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemService tvItemService = new TVItemService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                TVItem tvItem = GetFilledRandomTVItem("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = tvItemService.GetRead().Count();

                tvItemService.Add(tvItem);
                if (tvItem.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tvItemService.GetRead().Where(c => c == tvItem).Any());
                tvItemService.Update(tvItem);
                if (tvItem.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tvItemService.GetRead().Count());
                tvItemService.Delete(tvItem);
                if (tvItem.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // tvItem.TVItemID   (Int32)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVItemID = 0;
                tvItemService.Update(tvItem);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVItemID), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 100)]
                // tvItem.TVLevel   (Int32)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVLevel = -1;
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemService.GetRead().Count());
                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVLevel = 101;
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemTVLevel, "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(250))]
                // tvItem.TVPath   (String)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("TVPath");
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(1, tvItem.ValidationResults.Count());
                Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVPath)).Any());
                Assert.AreEqual(null, tvItem.TVPath);
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVPath = GetRandomString("", 251);
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemTVPath, "250"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvItem.TVType   (TVTypeEnum)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVType = (TVTypeEnum)1000000;
                tvItemService.Add(tvItem);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemTVType), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItem.ParentID   (Int32)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.ParentID = 0;
                tvItemService.Add(tvItem);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemParentID, tvItem.ParentID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.ParentID = 2;
                tvItemService.Add(tvItem);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemParentID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // tvItem.IsActive   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // tvItem.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // tvItem.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.LastUpdateContactTVItemID = 0;
                tvItemService.Add(tvItem);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLastUpdateContactTVItemID, tvItem.LastUpdateContactTVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.LastUpdateContactTVItemID = 1;
                tvItemService.Add(tvItem);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLastUpdateContactTVItemID, "Contact"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItem.TVText   (String)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemTVText, "200"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItem.LastUpdateContactTVText   (String)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLastUpdateContactTVText, "200"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvItem.TVTypeText   (String)
                // -----------------------------------

                tvItem = null;
                tvItem = GetFilledRandomTVItem("");
                tvItem.TVTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, tvItemService.Add(tvItem));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemTVTypeText, "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tvItem.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVItem_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemService tvItemService = new TVItemService(LanguageRequest, dbTestDB, ContactID);
                TVItem tvItem = (from c in tvItemService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(tvItem);

                TVItem tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                Assert.AreEqual(tvItem.TVItemID, tvItemRet.TVItemID);
                Assert.AreEqual(tvItem.TVLevel, tvItemRet.TVLevel);
                Assert.AreEqual(tvItem.TVPath, tvItemRet.TVPath);
                Assert.AreEqual(tvItem.TVType, tvItemRet.TVType);
                Assert.AreEqual(tvItem.ParentID, tvItemRet.ParentID);
                Assert.AreEqual(tvItem.IsActive, tvItemRet.IsActive);
                Assert.AreEqual(tvItem.LastUpdateDate_UTC, tvItemRet.LastUpdateDate_UTC);
                Assert.AreEqual(tvItem.LastUpdateContactTVItemID, tvItemRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(tvItemRet.TVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemRet.TVText));
                Assert.IsNotNull(tvItemRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemRet.LastUpdateContactTVText));
                Assert.IsNotNull(tvItemRet.TVTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemRet.TVTypeText));
            }
        }
        #endregion Tests Get With Key

    }
}
