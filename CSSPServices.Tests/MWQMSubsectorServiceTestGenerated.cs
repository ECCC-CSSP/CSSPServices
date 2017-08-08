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
    public partial class MWQMSubsectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private MWQMSubsectorService mwqmSubsectorService { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorServiceTest() : base()
        {
            //mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "RainDay0Limit") mwqmSubsector.RainDay0Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay1Limit") mwqmSubsector.RainDay1Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay2Limit") mwqmSubsector.RainDay2Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay3Limit") mwqmSubsector.RainDay3Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay4Limit") mwqmSubsector.RainDay4Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay5Limit") mwqmSubsector.RainDay5Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay6Limit") mwqmSubsector.RainDay6Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay7Limit") mwqmSubsector.RainDay7Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay8Limit") mwqmSubsector.RainDay8Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay9Limit") mwqmSubsector.RainDay9Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "RainDay10Limit") mwqmSubsector.RainDay10Limit = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "IncludeRainStartDate") mwqmSubsector.IncludeRainStartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "IncludeRainEndDate") mwqmSubsector.IncludeRainEndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "IncludeRainRunCount") mwqmSubsector.IncludeRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "IncludeRainSelectFullYear") mwqmSubsector.IncludeRainSelectFullYear = true;
            if (OmitPropName != "NoRainStartDate") mwqmSubsector.NoRainStartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "NoRainEndDate") mwqmSubsector.NoRainEndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "NoRainRunCount") mwqmSubsector.NoRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "NoRainSelectFullYear") mwqmSubsector.NoRainSelectFullYear = true;
            if (OmitPropName != "OnlyRainStartDate") mwqmSubsector.OnlyRainStartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "OnlyRainEndDate") mwqmSubsector.OnlyRainEndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "OnlyRainRunCount") mwqmSubsector.OnlyRainRunCount = GetRandomInt(0, 10);
            if (OmitPropName != "OnlyRainSelectFullYear") mwqmSubsector.OnlyRainSelectFullYear = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "SubsectorTVText") mwqmSubsector.SubsectorTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") mwqmSubsector.LastUpdateContactTVText = GetRandomString("", 5);

            return mwqmSubsector;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void MWQMSubsector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, dbTestDB, ContactID);

                int count = 0;
                if (count == 1)
                {
                    // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                }

                MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");

                // -------------------------------
                // -------------------------------
                // CRUD testing
                // -------------------------------
                // -------------------------------

                count = mwqmSubsectorService.GetRead().Count();

                mwqmSubsectorService.Add(mwqmSubsector);
                if (mwqmSubsector.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, mwqmSubsectorService.GetRead().Where(c => c == mwqmSubsector).Any());
                mwqmSubsectorService.Update(mwqmSubsector);
                if (mwqmSubsector.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, mwqmSubsectorService.GetRead().Count());
                mwqmSubsectorService.Delete(mwqmSubsector);
                if (mwqmSubsector.ValidationResults.Count() > 0)
                {
                    Assert.AreEqual("", mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -------------------------------
                // -------------------------------
                // Properties testing
                // -------------------------------
                // -------------------------------


                // -----------------------------------
                // [Key]
                // Is NOT Nullable
                // mwqmSubsector.MWQMSubsectorID   (Int32)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.MWQMSubsectorID = 0;
                mwqmSubsectorService.Update(mwqmSubsector);
                Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorMWQMSubsectorID), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Subsector)]
                // mwqmSubsector.MWQMSubsectorTVItemID   (Int32)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.MWQMSubsectorTVItemID = 0;
                mwqmSubsectorService.Add(mwqmSubsector);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, mwqmSubsector.MWQMSubsectorTVItemID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.MWQMSubsectorTVItemID = 1;
                mwqmSubsectorService.Add(mwqmSubsector);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSubsectorMWQMSubsectorTVItemID, "Subsector"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is NOT Nullable
                // [StringLength(20))]
                // mwqmSubsector.SubsectorHistoricKey   (String)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(1, mwqmSubsector.ValidationResults.Count());
                Assert.IsTrue(mwqmSubsector.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._IsRequired, ModelsRes.MWQMSubsectorSubsectorHistoricKey)).Any());
                Assert.AreEqual(null, mwqmSubsector.SubsectorHistoricKey);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 21);
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorHistoricKey, "20"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [StringLength(20))]
                // mwqmSubsector.TideLocationSIDText   (String)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.TideLocationSIDText = GetRandomString("", 21);
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorTideLocationSIDText, "20"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay0Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay0Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay0Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay0Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay0Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay1Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay1Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay1Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay1Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay1Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay2Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay2Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay2Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay2Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay2Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay3Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay3Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay3Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay3Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay3Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay4Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay4Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay4Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay4Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay4Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay5Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay5Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay5Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay5Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay5Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay6Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay6Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay6Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay6Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay6Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay7Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay7Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay7Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay7Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay7Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay8Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay8Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay8Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay8Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay8Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay9Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay9Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay9Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay9Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay9Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [Range(0, 300)]
                // mwqmSubsector.RainDay10Limit   (Double)
                // -----------------------------------

                //Error: Type not implemented [RainDay10Limit]

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay10Limit = -1.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.RainDay10Limit = 301.0D;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorRainDay10Limit, "0", "300"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.IncludeRainStartDate   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.IncludeRainEndDate   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // mwqmSubsector.IncludeRainRunCount   (Int32)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.IncludeRainRunCount = -1;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.IncludeRainRunCount = 11;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorIncludeRainRunCount, "0", "10"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // mwqmSubsector.IncludeRainSelectFullYear   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.NoRainStartDate   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.NoRainEndDate   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // mwqmSubsector.NoRainRunCount   (Int32)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.NoRainRunCount = -1;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.NoRainRunCount = 11;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorNoRainRunCount, "0", "10"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // mwqmSubsector.NoRainSelectFullYear   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.OnlyRainStartDate   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.OnlyRainEndDate   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is Nullable
                // [Range(0, 10)]
                // mwqmSubsector.OnlyRainRunCount   (Int32)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.OnlyRainRunCount = -1;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());
                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.OnlyRainRunCount = 11;
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.MWQMSubsectorOnlyRainRunCount, "0", "10"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // mwqmSubsector.OnlyRainSelectFullYear   (Boolean)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPAfter(Year = 1980)]
                // mwqmSubsector.LastUpdateDate_UTC   (DateTime)
                // -----------------------------------


                // -----------------------------------
                // Is NOT Nullable
                // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", AllowableTVtypeList = Contact)]
                // mwqmSubsector.LastUpdateContactTVItemID   (Int32)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.LastUpdateContactTVItemID = 0;
                mwqmSubsectorService.Add(mwqmSubsector);
                Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, mwqmSubsector.LastUpdateContactTVItemID.ToString()), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.LastUpdateContactTVItemID = 1;
                mwqmSubsectorService.Add(mwqmSubsector);
                Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.MWQMSubsectorLastUpdateContactTVItemID, "Contact"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);


                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSubsector.SubsectorTVText   (String)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.SubsectorTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorSubsectorTVText, "200"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is Nullable
                // [NotMapped]
                // [StringLength(200))]
                // mwqmSubsector.LastUpdateContactTVText   (String)
                // -----------------------------------

                mwqmSubsector = null;
                mwqmSubsector = GetFilledRandomMWQMSubsector("");
                mwqmSubsector.LastUpdateContactTVText = GetRandomString("", 201);
                Assert.AreEqual(false, mwqmSubsectorService.Add(mwqmSubsector));
                Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.MWQMSubsectorLastUpdateContactTVText, "200"), mwqmSubsector.ValidationResults.FirstOrDefault().ErrorMessage);
                Assert.AreEqual(count, mwqmSubsectorService.GetRead().Count());

                // -----------------------------------
                // Is NOT Nullable
                // [NotMapped]
                // mwqmSubsector.ValidationResults   (IEnumerable`1)
                // -----------------------------------

            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void MWQMSubsector_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                MWQMSubsectorService mwqmSubsectorService = new MWQMSubsectorService(LanguageRequest, dbTestDB, ContactID);

                MWQMSubsector mwqmSubsector = (from c in mwqmSubsectorService.GetRead()
                                             select c).FirstOrDefault();
                Assert.IsNotNull(mwqmSubsector);

                MWQMSubsector mwqmSubsectorRet = mwqmSubsectorService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsector.MWQMSubsectorID);
                Assert.AreEqual(mwqmSubsector.MWQMSubsectorID, mwqmSubsectorRet.MWQMSubsectorID);
            }
        }
        #endregion Tests Get With Key

    }
}
