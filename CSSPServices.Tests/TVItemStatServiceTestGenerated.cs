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
    public partial class TVItemStatServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemStatService tvItemStatService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatServiceTest() : base()
        {
            //tvItemStatService = new TVItemStatService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = 1;
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "TVText") tvItemStat.TVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") tvItemStat.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TVTypeText") tvItemStat.TVTypeText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") tvItemStat.HasErrors = true;

            return tvItemStat;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemStat_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemStatService tvItemStatService = new TVItemStatService(LanguageRequest, dbTestDB, ContactID);

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

                Assert.AreEqual(tvItemStatService.GetRead().Count(), tvItemStatService.GetEdit().Count());

                tvItemStatService.Add(tvItemStat);
                if (tvItemStat.HasErrors)
                {
                    Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tvItemStatService.GetRead().Where(c => c == tvItemStat).Any());
                tvItemStatService.Update(tvItemStat);
                if (tvItemStat.HasErrors)
                {
                    Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tvItemStatService.GetRead().Count());
                tvItemStatService.Delete(tvItemStat);
                if (tvItemStat.HasErrors)
                {
                    Assert.AreEqual("", tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, tvItemStatService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tvItemStat.TVItemStatID   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemStatID = 0;
                    tvItemStatService.Update(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemStatTVItemStatID), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemStatID = 10000000;
                    tvItemStatService.Update(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItemStat, CSSPModelsRes.TVItemStatTVItemStatID, tvItemStat.TVItemStatID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                    // tvItemStat.TVItemID   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemID = 0;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemStatTVItemID, tvItemStat.TVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVItemID = 2;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemStatTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvItemStat.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVType = (TVTypeEnum)1000000;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVItemStatTVType), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000000)]
                    // tvItemStat.ChildCount   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.ChildCount = -1;
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemStatChildCount, "0", "10000000"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetRead().Count());
                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.ChildCount = 10000001;
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, CSSPModelsRes.TVItemStatChildCount, "0", "10000000"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvItemStat.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvItemStat.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateContactTVItemID = 0;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVItemStatLastUpdateContactTVItemID, tvItemStat.LastUpdateContactTVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateContactTVItemID = 1;
                    tvItemStatService.Add(tvItemStat);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVItemStatLastUpdateContactTVItemID, "Contact"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // tvItemStat.TVText   (String)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVText = GetRandomString("", 201);
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemStatTVText, "200"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // tvItemStat.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemStatLastUpdateContactTVText, "200"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // tvItemStat.TVTypeText   (String)
                    // -----------------------------------

                    tvItemStat = null;
                    tvItemStat = GetFilledRandomTVItemStat("");
                    tvItemStat.TVTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                    Assert.AreEqual(string.Format(CSSPServicesRes._MaxLengthIs_, CSSPModelsRes.TVItemStatTVTypeText, "100"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tvItemStatService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemStat.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvItemStat.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVItemStat_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVItemStatService tvItemStatService = new TVItemStatService(LanguageRequest, dbTestDB, ContactID);
                    TVItemStat tvItemStat = (from c in tvItemStatService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvItemStat);

                    TVItemStat tvItemStatRet = tvItemStatService.GetTVItemStatWithTVItemStatID(tvItemStat.TVItemStatID);
                    Assert.IsNotNull(tvItemStatRet.TVItemStatID);
                    Assert.IsNotNull(tvItemStatRet.TVItemID);
                    Assert.IsNotNull(tvItemStatRet.TVType);
                    Assert.IsNotNull(tvItemStatRet.ChildCount);
                    Assert.IsNotNull(tvItemStatRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(tvItemStatRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(tvItemStatRet.TVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemStatRet.TVText));
                    Assert.IsNotNull(tvItemStatRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemStatRet.LastUpdateContactTVText));
                    Assert.IsNotNull(tvItemStatRet.TVTypeText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemStatRet.TVTypeText));
                    Assert.IsNotNull(tvItemStatRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
