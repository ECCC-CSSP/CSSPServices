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
    public partial class TVTypeUserAuthorizationTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationTest() : base()
        {
            tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private TVTypeUserAuthorization GetFilledRandomTVTypeUserAuthorization(string OmitPropName)
        {
            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvTypeUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVType") tvTypeUserAuthorization.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVAuth") tvTypeUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;

            return tvTypeUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated
        [TestMethod]
        public void TVTypeUserAuthorization_Testing()
        {

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            TVTypeUserAuthorization tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");

            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            count = tvTypeUserAuthorizationService.GetRead().Count();

            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(true, tvTypeUserAuthorizationService.GetRead().Where(c => c == tvTypeUserAuthorization).Any());
            tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count + 1, tvTypeUserAuthorizationService.GetRead().Count());
            tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization);
            if (tvTypeUserAuthorization.ValidationResults.Count() > 0)
            {
                Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
            }
            Assert.AreEqual(count, tvTypeUserAuthorizationService.GetRead().Count());

            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvTypeUserAuthorization.TVTypeUserAuthorizationID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
            tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvTypeUserAuthorization.ContactTVItemID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.ContactTVItemID = 0;
            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVTypeUserAuthorizationContactTVItemID, tvTypeUserAuthorization.ContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.ContactTVItemID = 1;
            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVTypeUserAuthorizationContactTVItemID, "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvTypeUserAuthorization.TVType   (TVTypeEnum)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVType = (TVTypeEnum)1000000;
            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVType), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVAuth = (TVAuthEnum)1000000;
            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsRequired, ModelsRes.TVTypeUserAuthorizationTVAuth), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(TypeName = "TVItem", Plurial = "s", FieldID = "TVItemID", TVType = TVTypeEnum.Contact)]
            // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes.CouldNotFind_With_Equal_, ModelsRes.TVItem, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
            tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
            Assert.AreEqual(string.Format(ServicesRes._IsNotOfType_, ModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


            // -----------------------------------
            // Is NOT Nullable
            // [IsVirtual]
            // tvTypeUserAuthorization.ContactTVItem   (TVItem)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [NotMapped]
            // tvTypeUserAuthorization.ValidationResults   (IEnumerable`1)
            // -----------------------------------

        }
        #endregion Tests Generated
    }
}
