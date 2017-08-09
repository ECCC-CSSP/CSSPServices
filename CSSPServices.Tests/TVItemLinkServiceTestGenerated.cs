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
    public partial class TVItemLinkServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVItemLinkService tvItemLinkService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkServiceTest() : base()
        {
            //tvItemLinkService = new TVItemLinkService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemLink GetFilledRandomTVItemLink(string OmitPropName)
        {
            TVItemLink tvItemLink = new TVItemLink();

            if (OmitPropName != "FromTVItemID") tvItemLink.FromTVItemID = 1;
            if (OmitPropName != "ToTVItemID") tvItemLink.ToTVItemID = 1;
            if (OmitPropName != "FromTVType") tvItemLink.FromTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ToTVType") tvItemLink.ToTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "StartDateTime_Local") tvItemLink.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") tvItemLink.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "Ordinal") tvItemLink.Ordinal = GetRandomInt(0, 100);
            if (OmitPropName != "TVLevel") tvItemLink.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItemLink.TVPath = GetRandomString("", 5);
            // Need to implement [TVItemLink ParentTVItemLinkID TVItemLink TVItemLinkID]
            if (OmitPropName != "LastUpdateDate_UTC") tvItemLink.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemLink.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "FromTVText") tvItemLink.FromTVText = GetRandomString("", 5);
            if (OmitPropName != "ToTVText") tvItemLink.ToTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") tvItemLink.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "FromTVTypeText") tvItemLink.FromTVTypeText = GetRandomString("", 5);
            if (OmitPropName != "ToTVTypeText") tvItemLink.ToTVTypeText = GetRandomString("", 5);

            return tvItemLink;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVItemLink_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, dbTestDB, ContactID);

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
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemLink.FromTVItemID   (Int32)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.FromTVItemID = 0;
                tvItemLinkService.Add(tvItemLink);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkFromTVItemID, tvItemLink.FromTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.FromTVItemID = 2;
                tvItemLinkService.Add(tvItemLink);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkFromTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite)]
                // tvItemLink.ToTVItemID   (Int32)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.ToTVItemID = 0;
                tvItemLinkService.Add(tvItemLink);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemLinkToTVItemID, tvItemLink.ToTVItemID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.ToTVItemID = 2;
                tvItemLinkService.Add(tvItemLink);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemLinkToTVItemID, "Root,Country,Province,Area,Sector,Subsector,ClimateSite,File,HydrometricSite,Infrastructure,MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide,MikeScenario,MikeSource,Municipality,MWQMRun,MWQMSite,MWQMSiteSample,PolSourceSite,SamplingPlan,Spill,TideSite"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


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
                // [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID", AllowableTVtypeList = Error)]
                // tvItemLink.ParentTVItemLinkID   (Int32)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.ParentTVItemLinkID = 0;
                tvItemLinkService.Add(tvItemLink);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItemLink, ModelsRes.TVItemLinkParentTVItemLinkID, tvItemLink.ParentTVItemLinkID.ToString()), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // tvItemLink.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
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
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "FromTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemLink.FromTVText   (String)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.FromTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkFromTVText, "200"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "ToTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemLink.ToTVText   (String)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.ToTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkToTVText, "200"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                // [NotMapped]
                // [StringLength(200))]
                // tvItemLink.LastUpdateContactTVText   (String)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkLastUpdateContactTVText, "200"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvItemLink.FromTVTypeText   (String)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.FromTVTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkFromTVTypeText, "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(100))]
                // tvItemLink.ToTVTypeText   (String)
                // -----------------------------------

                tvItemLink = null;
                tvItemLink = GetFilledRandomTVItemLink("");
                tvItemLink.ToTVTypeText = GetRandomString("", 101);
                Assert.AreEqual(false, tvItemLinkService.Add(tvItemLink));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TVItemLinkToTVTypeText, "100"), tvItemLink.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, tvItemLinkService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // tvItemLink.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVItemLink_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, dbTestDB, ContactID);
                TVItemLink tvItemLink = (from c in tvItemLinkService.GetRead() select c).FirstOrDefault();
                Assert.IsNotNull(tvItemLink);

                TVItemLink tvItemLinkRet = tvItemLinkService.GetTVItemLinkWithTVItemLinkID(tvItemLink.TVItemLinkID);
                Assert.IsNotNull(tvItemLinkRet.TVItemLinkID);
                Assert.IsNotNull(tvItemLinkRet.FromTVItemID);
                Assert.IsNotNull(tvItemLinkRet.ToTVItemID);
                Assert.IsNotNull(tvItemLinkRet.FromTVType);
                Assert.IsNotNull(tvItemLinkRet.ToTVType);
                if (tvItemLinkRet.StartDateTime_Local != null)
                {
                   Assert.IsNotNull(tvItemLinkRet.StartDateTime_Local);
                }
                if (tvItemLinkRet.EndDateTime_Local != null)
                {
                   Assert.IsNotNull(tvItemLinkRet.EndDateTime_Local);
                }
                Assert.IsNotNull(tvItemLinkRet.Ordinal);
                Assert.IsNotNull(tvItemLinkRet.TVLevel);
                Assert.IsNotNull(tvItemLinkRet.TVPath);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.TVPath));
                if (tvItemLinkRet.ParentTVItemLinkID != null)
                {
                   Assert.IsNotNull(tvItemLinkRet.ParentTVItemLinkID);
                }
                Assert.IsNotNull(tvItemLinkRet.LastUpdateDate_UTC);
                Assert.IsNotNull(tvItemLinkRet.LastUpdateContactTVItemID);

                Assert.IsNotNull(tvItemLinkRet.FromTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.FromTVText));
                Assert.IsNotNull(tvItemLinkRet.ToTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.ToTVText));
                Assert.IsNotNull(tvItemLinkRet.LastUpdateContactTVText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.LastUpdateContactTVText));
                Assert.IsNotNull(tvItemLinkRet.FromTVTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.FromTVTypeText));
                Assert.IsNotNull(tvItemLinkRet.ToTVTypeText);
                Assert.IsFalse(string.IsNullOrWhiteSpace(tvItemLinkRet.ToTVTypeText));
            }
        }
        #endregion Tests Get With Key

    }
}
