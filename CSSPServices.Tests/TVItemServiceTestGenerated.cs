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
            //Error: property [TVItemWeb] and type [TVItem] is  not implemented
            //Error: property [TVItemReport] and type [TVItem] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") tvItem.HasErrors = true;

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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
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

                    Assert.AreEqual(tvItemService.GetRead().Count(), tvItemService.GetEdit().Count());

                    tvItemService.Add(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvItemService.GetRead().Where(c => c == tvItem).Any());
                    tvItemService.Update(tvItem);
                    if (tvItem.HasErrors)
                    {
                        Assert.AreEqual("", tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvItemService.GetRead().Count());
                    tvItemService.Delete(tvItem);
                    if (tvItem.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemTVItemID), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVItemID = 10000000;
                    tvItemService.Update(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemTVItemID, tvItem.TVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 100)]
                    // tvItem.TVLevel   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVLevel = -1;
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemTVLevel, "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemService.GetRead().Count());
                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVLevel = 101;
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemTVLevel, "0", "100"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.IsTrue(tvItem.ValidationResults.Where(c => c.ErrorMessage == string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemTVPath)).Any());
                    Assert.AreEqual(null, tvItem.TVPath);
                    Assert.AreEqual(count, tvItemService.GetRead().Count());

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.TVPath = GetRandomString("", 251);
                    Assert.AreEqual(false, tvItemService.Add(tvItem));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemTVPath, "250"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemTVType), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                    // tvItem.ParentID   (Int32)
                    // -----------------------------------

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.ParentID = 0;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemParentID, tvItem.ParentID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.ParentID = 2;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemParentID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // tvItem.IsActive   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItem.TVItemWeb   (TVItemWeb)
                    // -----------------------------------

                    //Error: Type not implemented [TVItemWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvItem.TVItemReport   (TVItemReport)
                    // -----------------------------------

                    //Error: Type not implemented [TVItemReport]


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
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemLastUpdateContactTVItemID, tvItem.LastUpdateContactTVItemID.ToString()), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItem = null;
                    tvItem = GetFilledRandomTVItem("");
                    tvItem.LastUpdateContactTVItemID = 1;
                    tvItemService.Add(tvItem);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemLastUpdateContactTVItemID, "Contact"), tvItem.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItem.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItem.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
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

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemService tvItemService = new TVItemService(LanguageRequest, dbTestDB, ContactID);
                    TVItem tvItem = (from c in tvItemService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItem);

                    TVItem tvItemRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvItemRet = tvItemService.GetTVItemWithTVItemID(tvItem.TVItemID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(tvItemRet.TVItemID);
                        Assert.IsNotNull(tvItemRet.TVLevel);
                        Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemRet.TVPath));
                        Assert.IsNotNull(tvItemRet.TVType);
                        Assert.IsNotNull(tvItemRet.ParentID);
                        Assert.IsNotNull(tvItemRet.IsActive);
                        Assert.IsNotNull(tvItemRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tvItemRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (tvItemRet.TVItemWeb != null)
                            {
                                Assert.IsNull(tvItemRet.TVItemWeb);
                            }
                            if (tvItemRet.TVItemReport != null)
                            {
                                Assert.IsNull(tvItemRet.TVItemReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (tvItemRet.TVItemWeb != null)
                            {
                                Assert.IsNotNull(tvItemRet.TVItemWeb);
                            }
                            if (tvItemRet.TVItemReport != null)
                            {
                                Assert.IsNotNull(tvItemRet.TVItemReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of TVItem
        #endregion Tests Get List of TVItem

    }
}
