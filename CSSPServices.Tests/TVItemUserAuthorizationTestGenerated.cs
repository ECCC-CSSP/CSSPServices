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
    public partial class TVItemUserAuthorizationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationTest() : base()
        {
            tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = 2;
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = 2;
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = 2;
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = 2;
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = 2;

            return tvItemUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVItemUserAuthorization_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVItemUserAuthorization tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvItemUserAuthorizationService.GetRead().Count();

            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvItemUserAuthorizationService.GetRead().Where(c => c == tvItemUserAuthorization).Any());
            tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvItemUserAuthorizationService.GetRead().Count());
            tvItemUserAuthorizationService.Delete(tvItemUserAuthorization);
            if (tvItemUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvItemUserAuthorizationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemUserAuthorization.TVItemUserAuthorizationID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemUserAuthorizationID = 0;
            tvItemUserAuthorizationService.Update(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVItemUserAuthorizationID), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvItemUserAuthorization.ContactTVItemID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.ContactTVItemID = 0;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationContactTVItemID, tvItemUserAuthorization.ContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.ContactTVItemID = 1;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemUserAuthorization.TVItemID1   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID1 = 0;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID1, tvItemUserAuthorization.TVItemID1.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemUserAuthorization.TVItemID2   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID2 = 0;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID2, tvItemUserAuthorization.TVItemID2.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemUserAuthorization.TVItemID3   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID3 = 0;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID3, tvItemUserAuthorization.TVItemID3.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Error)]
            // tvItemUserAuthorization.TVItemID4   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID4 = 0;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationTVItemID4, tvItemUserAuthorization.TVItemID4.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVAuth = (TVAuthEnum)1000000;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVItemUserAuthorizationTVAuth), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, tvItemUserAuthorization.LastUpdateContactTVItemID.ToString()), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
            tvItemUserAuthorizationService.Add(tvItemUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVItemUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvItemUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvItemUserAuthorization.ContactTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvItemUserAuthorization.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
