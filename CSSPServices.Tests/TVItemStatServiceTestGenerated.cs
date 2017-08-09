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
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemStatTVItemStatID), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemStat.TVItemID   (Int32)
                // -----------------------------------

                tvItemStat = null;
                tvItemStat = GetFilledRandomTVItemStat("");
                tvItemStat.TVItemID = 0;
                tvItemStatService.Add(tvItemStat);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemStatTVItemID, tvItemStat.TVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemStat = null;
                tvItemStat = GetFilledRandomTVItemStat("");
                tvItemStat.TVItemID = 2;
                tvItemStatService.Add(tvItemStat);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemStatTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPEnumType]
                // tvItemStat.TVType   (TVTypeEnum)
                // -----------------------------------

                tvItemStat = null;
                tvItemStat = GetFilledRandomTVItemStat("");
                tvItemStat.TVType = (TVTypeEnum)1000000;
                tvItemStatService.Add(tvItemStat);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemStatTVType), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [Range(0, 10000000)]
                // tvItemStat.ChildCount   (Int32)
                // -----------------------------------

                tvItemStat = null;
                tvItemStat = GetFilledRandomTVItemStat("");
                tvItemStat.ChildCount = -1;
                Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemStatChildCount, "0", "10000000"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemStatService.GetRead().Count());
                tvItemStat = null;
                tvItemStat = GetFilledRandomTVItemStat("");
                tvItemStat.ChildCount = 10000001;
                Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemStatChildCount, "0", "10000000"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemStatLastUpdateContactTVItemID, tvItemStat.LastUpdateContactTVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemStat = null;
                tvItemStat = GetFilledRandomTVItemStat("");
                tvItemStat.LastUpdateContactTVItemID = 1;
                tvItemStatService.Add(tvItemStat);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemStatLastUpdateContactTVItemID, "Contact"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);


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
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemStatTVText, "200"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemStatLastUpdateContactTVText, "200"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
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
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemStatTVTypeText, "100"), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemStatService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tvItemStat.ValidationResults   (IEnumerable`1)
                // -----------------------------------

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
            }
        }
        #endregion Tests Get With Key

    }
}
