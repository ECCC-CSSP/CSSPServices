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
    public partial class TideDataValueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TideDataValueService tideDataValueService { get; set; }
        #endregion Properties

        #region Constructors
        public TideDataValueServiceTest() : base()
        {
            //tideDataValueService = new TideDataValueService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TideDataValue GetFilledRandomTideDataValue(string OmitPropName)
        {
            TideDataValue tideDataValue = new TideDataValue();

            if (OmitPropName != "TideSiteTVItemID") tideDataValue.TideSiteTVItemID = 13;
            if (OmitPropName != "DateTime_Local") tideDataValue.DateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "Keep") tideDataValue.Keep = true;
            if (OmitPropName != "TideDataType") tideDataValue.TideDataType = (TideDataTypeEnum)GetRandomEnumType(typeof(TideDataTypeEnum));
            if (OmitPropName != "StorageDataType") tideDataValue.StorageDataType = (StorageDataTypeEnum)GetRandomEnumType(typeof(StorageDataTypeEnum));
            if (OmitPropName != "Depth_m") tideDataValue.Depth_m = GetRandomDouble(0.0D, 10000.0D);
            if (OmitPropName != "UVelocity_m_s") tideDataValue.UVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "VVelocity_m_s") tideDataValue.VVelocity_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "TideStart") tideDataValue.TideStart = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "TideEnd") tideDataValue.TideEnd = (TideTextEnum)GetRandomEnumType(typeof(TideTextEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tideDataValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideDataValue.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "TideSiteTVText") tideDataValue.TideSiteTVText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateContactTVText") tideDataValue.LastUpdateContactTVText = GetRandomString("", 5);
            if (OmitPropName != "TideDataTypeText") tideDataValue.TideDataTypeText = GetRandomString("", 5);
            if (OmitPropName != "StorageDataTypeText") tideDataValue.StorageDataTypeText = GetRandomString("", 5);
            if (OmitPropName != "TideStartText") tideDataValue.TideStartText = GetRandomString("", 5);
            if (OmitPropName != "TideEndText") tideDataValue.TideEndText = GetRandomString("", 5);
            if (OmitPropName != "HasErrors") tideDataValue.HasErrors = true;

            return tideDataValue;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TideDataValue_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideDataValueService tideDataValueService = new TideDataValueService(LanguageRequest, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TideDataValue tideDataValue = GetFilledRandomTideDataValue("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                count = tideDataValueService.GetRead().Count();

                Assert.AreEqual(tideDataValueService.GetRead().Count(), tideDataValueService.GetEdit().Count());

                tideDataValueService.Add(tideDataValue);
                if (tideDataValue.HasErrors)
                {
                    Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(true, tideDataValueService.GetRead().Where(c => c == tideDataValue).Any());
                tideDataValueService.Update(tideDataValue);
                if (tideDataValue.HasErrors)
                {
                    Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count + 1, tideDataValueService.GetRead().Count());
                tideDataValueService.Delete(tideDataValue);
                if (tideDataValue.HasErrors)
                {
                    Assert.AreEqual("", tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                }
                Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------


                    // -----------------------------------
                    // [Key]
                    // Is NOT Nullable
                    // tideDataValue.TideDataValueID   (Int32)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueID = 0;
                    tideDataValueService.Update(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataValueID), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataValueID = 10000000;
                    tideDataValueService.Update(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TideDataValue, ModelsRes.TideDataValueTideDataValueID, tideDataValue.TideDataValueID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
                    // tideDataValue.TideSiteTVItemID   (Int32)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideSiteTVItemID = 0;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideDataValueTideSiteTVItemID, tideDataValue.TideSiteTVItemID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideSiteTVItemID = 1;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideDataValueTideSiteTVItemID, "TideSite"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideDataValue.DateTime_Local   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // tideDataValue.Keep   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tideDataValue.TideDataType   (TideDataTypeEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataType = (TideDataTypeEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideDataType), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tideDataValue.StorageDataType   (StorageDataTypeEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.StorageDataType = (StorageDataTypeEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueStorageDataType), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10000)]
                    // tideDataValue.Depth_m   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [Depth_m]

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.Depth_m = -1.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "10000"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.Depth_m = 10001.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueDepth_m, "0", "10000"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10)]
                    // tideDataValue.UVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [UVelocity_m_s]

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.UVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.UVelocity_m_s = 11.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueUVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [Range(0, 10)]
                    // tideDataValue.VVelocity_m_s   (Double)
                    // -----------------------------------

                    //Error: Type not implemented [VVelocity_m_s]

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.VVelocity_m_s = -1.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());
                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.VVelocity_m_s = 11.0D;
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._ValueShouldBeBetween_And_, ModelsRes.TideDataValueVVelocity_m_s, "0", "10"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // tideDataValue.TideStart   (TideTextEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideStart = (TideTextEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideStart), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPEnumType]
                    // tideDataValue.TideEnd   (TideTextEnum)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideEnd = (TideTextEnum)1000000;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TideDataValueTideEnd), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tideDataValue.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tideDataValue.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateContactTVItemID = 0;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TideDataValueLastUpdateContactTVItemID, tideDataValue.LastUpdateContactTVItemID.ToString()), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateContactTVItemID = 1;
                    tideDataValueService.Add(tideDataValue);
                    Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TideDataValueLastUpdateContactTVItemID, "Contact"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "TideSiteTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // tideDataValue.TideSiteTVText   (String)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideSiteTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideSiteTVText, "200"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [CSSPFill(FillTypeName = "TVItemLanguage", FillPlurial = "s", FillFieldID = "TVItemID", FillEqualField = "LastUpdateContactTVItemID", FillReturnField = "TVText", FillNeedLanguage = "TVText")]
                    // [NotMapped]
                    // [StringLength(200))]
                    // tideDataValue.LastUpdateContactTVText   (String)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.LastUpdateContactTVText = GetRandomString("", 201);
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueLastUpdateContactTVText, "200"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // tideDataValue.TideDataTypeText   (String)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideDataTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideDataTypeText, "100"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // tideDataValue.StorageDataTypeText   (String)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.StorageDataTypeText = GetRandomString("", 101);
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueStorageDataTypeText, "100"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // tideDataValue.TideStartText   (String)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideStartText = GetRandomString("", 101);
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideStartText, "100"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // [StringLength(100))]
                    // tideDataValue.TideEndText   (String)
                    // -----------------------------------

                    tideDataValue = null;
                    tideDataValue = GetFilledRandomTideDataValue("");
                    tideDataValue.TideEndText = GetRandomString("", 101);
                    Assert.AreEqual(false, tideDataValueService.Add(tideDataValue));
                    Assert.AreEqual(string.Format(ServicesRes._MaxLengthIs_, ModelsRes.TideDataValueTideEndText, "100"), tideDataValue.ValidationResults.FirstOrDefault().ErrorMessage);
                    Assert.AreEqual(count, tideDataValueService.GetRead().Count());

                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideDataValue.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tideDataValue.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TideDataValue_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TideDataValueService tideDataValueService = new TideDataValueService(LanguageRequest, dbTestDB, ContactID);
                    TideDataValue tideDataValue = (from c in tideDataValueService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tideDataValue);

                    TideDataValue tideDataValueRet = tideDataValueService.GetTideDataValueWithTideDataValueID(tideDataValue.TideDataValueID);
                    Assert.IsNotNull(tideDataValueRet.TideDataValueID);
                    Assert.IsNotNull(tideDataValueRet.TideSiteTVItemID);
                    Assert.IsNotNull(tideDataValueRet.DateTime_Local);
                    Assert.IsNotNull(tideDataValueRet.Keep);
                    Assert.IsNotNull(tideDataValueRet.TideDataType);
                    Assert.IsNotNull(tideDataValueRet.StorageDataType);
                    Assert.IsNotNull(tideDataValueRet.Depth_m);
                    Assert.IsNotNull(tideDataValueRet.UVelocity_m_s);
                    Assert.IsNotNull(tideDataValueRet.VVelocity_m_s);
                    if (tideDataValueRet.TideStart != null)
                    {
                       Assert.IsNotNull(tideDataValueRet.TideStart);
                    }
                    if (tideDataValueRet.TideEnd != null)
                    {
                       Assert.IsNotNull(tideDataValueRet.TideEnd);
                    }
                    Assert.IsNotNull(tideDataValueRet.LastUpdateDate_UTC);
                    Assert.IsNotNull(tideDataValueRet.LastUpdateContactTVItemID);

                    Assert.IsNotNull(tideDataValueRet.TideSiteTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueRet.TideSiteTVText));
                    Assert.IsNotNull(tideDataValueRet.LastUpdateContactTVText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueRet.LastUpdateContactTVText));
                    Assert.IsNotNull(tideDataValueRet.TideDataTypeText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueRet.TideDataTypeText));
                    Assert.IsNotNull(tideDataValueRet.StorageDataTypeText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueRet.StorageDataTypeText));
                    Assert.IsNotNull(tideDataValueRet.TideStartText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueRet.TideStartText));
                    Assert.IsNotNull(tideDataValueRet.TideEndText);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(tideDataValueRet.TideEndText));
                    Assert.IsNotNull(tideDataValueRet.HasErrors);
                }
            }
        }
        #endregion Tests Get With Key

    }
}
