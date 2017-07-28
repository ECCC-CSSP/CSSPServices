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
    public partial class TVItemStatTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemStatService tvItemStatService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatTest() : base()
        {
            tvItemStatService = new TVItemStatService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = 2;
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;

            return tvItemStat;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemStat_Testing()
        {

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
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemStat.TVItemID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemID = 0;
            tvItemStatService.Add(tvItemStat);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemStatTVItemID, tvItemStat.TVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

            // TVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemStat.TVType   (TVTypeEnum)
            // -----------------------------------

            // TVType will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [Range(0, 10000000)]
            // tvItemStat.ChildCount   (Int32)
            // -----------------------------------

            // ChildCount will automatically be initialized at 0 --> not null

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            // ChildCount has Min [0] and Max [10000000]. At Min should return true and no errors
            tvItemStat.ChildCount = 0;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(0, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Min + 1 should return true and no errors
            tvItemStat.ChildCount = 1;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(1, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Min - 1 should return false with one error
            tvItemStat.ChildCount = -1;
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemStatChildCount, "0", "10000000")).Any());
            Assert.AreEqual(-1, tvItemStat.ChildCount);
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Max should return true and no errors
            tvItemStat.ChildCount = 10000000;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(10000000, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Max - 1 should return true and no errors
            tvItemStat.ChildCount = 9999999;
            Assert.AreEqual(true, tvItemStatService.Add(tvItemStat));
            Assert.AreEqual(0, tvItemStat.ValidationResults.Count());
            Assert.AreEqual(9999999, tvItemStat.ChildCount);
            Assert.AreEqual(true, tvItemStatService.Delete(tvItemStat));
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());
            // ChildCount has Min [0] and Max [10000000]. At Max + 1 should return false with one error
            tvItemStat.ChildCount = 10000001;
            Assert.AreEqual(false, tvItemStatService.Add(tvItemStat));
            Assert.IsTrue(tvItemStat.ValidationResults.Where(c => c.ErrorMessage == string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TVItemStatChildCount, "0", "10000000")).Any());
            Assert.AreEqual(10000001, tvItemStat.ChildCount);
            Assert.AreEqual(count, tvItemStatService.GetRead().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemStat.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            // LastUpdateDate_UTC will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvItemStat.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateContactTVItemID = 0;
            tvItemStatService.Add(tvItemStat);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemStatLastUpdateContactTVItemID, tvItemStat.LastUpdateContactTVItemID.ToString()), tvItemStat.ValidationResults.FirstOrDefault().ErrorMessage);

            // LastUpdateContactTVItemID will automatically be initialized at 0 --> not null


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemStat.TVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvItemStat.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
