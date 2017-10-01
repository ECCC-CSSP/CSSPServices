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
    public partial class TVTypeUserAuthorizationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationServiceTest() : base()
        {
            //tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
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
            //Error: property [TVTypeUserAuthorizationWeb] and type [TVTypeUserAuthorization] is  not implemented
            //Error: property [TVTypeUserAuthorizationReport] and type [TVTypeUserAuthorization] is  not implemented
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;
            if (OmitPropName != "HasErrors") tvTypeUserAuthorization.HasErrors = true;

            return tvTypeUserAuthorization;
        }
        #endregion Functions private

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVTypeUserAuthorization_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);

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

                    Assert.AreEqual(tvTypeUserAuthorizationService.GetRead().Count(), tvTypeUserAuthorizationService.GetEdit().Count());

                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(true, tvTypeUserAuthorizationService.GetRead().Where(c => c == tvTypeUserAuthorization).Any());
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
                    {
                        Assert.AreEqual("", tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);
                    }
                    Assert.AreEqual(count + 1, tvTypeUserAuthorizationService.GetRead().Count());
                    tvTypeUserAuthorizationService.Delete(tvTypeUserAuthorization);
                    if (tvTypeUserAuthorization.HasErrors)
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
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVTypeUserAuthorizationID = 10000000;
                    tvTypeUserAuthorizationService.Update(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVTypeUserAuthorization, CSSPModelsRes.TVTypeUserAuthorizationTVTypeUserAuthorizationID, tvTypeUserAuthorization.TVTypeUserAuthorizationID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvTypeUserAuthorization.ContactTVItemID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.ContactTVItemID = 0;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVTypeUserAuthorizationContactTVItemID, tvTypeUserAuthorization.ContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.ContactTVItemID = 1;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVTypeUserAuthorizationContactTVItemID, "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvTypeUserAuthorization.TVType   (TVTypeEnum)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVType = (TVTypeEnum)1000000;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVType), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPEnumType]
                    // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.TVAuth = (TVAuthEnum)1000000;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsRequired, CSSPModelsRes.TVTypeUserAuthorizationTVAuth), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.TVTypeUserAuthorizationWeb   (TVTypeUserAuthorizationWeb)
                    // -----------------------------------

                    //Error: Type not implemented [TVTypeUserAuthorizationWeb]


                    // -----------------------------------
                    // Is Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.TVTypeUserAuthorizationReport   (TVTypeUserAuthorizationReport)
                    // -----------------------------------

                    //Error: Type not implemented [TVTypeUserAuthorizationReport]


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPAfter(Year = 1980)]
                    // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
                    // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
                    // -----------------------------------

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes.CouldNotFind_With_Equal_, CSSPModelsRes.TVItem, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, tvTypeUserAuthorization.LastUpdateContactTVItemID.ToString()), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);

                    tvTypeUserAuthorization = null;
                    tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
                    tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
                    tvTypeUserAuthorizationService.Add(tvTypeUserAuthorization);
                    Assert.AreEqual(string.Format(CSSPServicesRes._IsNotOfType_, CSSPModelsRes.TVTypeUserAuthorizationLastUpdateContactTVItemID, "Contact"), tvTypeUserAuthorization.ValidationResults.FirstOrDefault().ErrorMessage);


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.HasErrors   (Boolean)
                    // -----------------------------------


                    // -----------------------------------
                    // Is NOT Nullable
                    // [NotMapped]
                    // tvTypeUserAuthorization.ValidationResults   (IEnumerable`1)
                    // -----------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated Get With Key
        [TestMethod]
        public void TVTypeUserAuthorization_Get_With_Key_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, dbTestDB, ContactID);
                    TVTypeUserAuthorization tvTypeUserAuthorization = (from c in tvTypeUserAuthorizationService.GetRead() select c).FirstOrDefault();
                    Assert.IsNotNull(tvTypeUserAuthorization);

                    TVTypeUserAuthorization tvTypeUserAuthorizationRet = null;
                    foreach (EntityQueryDetailTypeEnum entityQueryDetailTypeEnum in new List<EntityQueryDetailTypeEnum>() { EntityQueryDetailTypeEnum.Error, EntityQueryDetailTypeEnum.EntityOnly, EntityQueryDetailTypeEnum.EntityWeb })
                    {
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.Error)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID, EntityQueryDetailTypeEnum.EntityOnly);
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            tvTypeUserAuthorizationRet = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorization.TVTypeUserAuthorizationID, EntityQueryDetailTypeEnum.EntityWeb);
                        }
                        else
                        {
                            // nothing for now
                        }
                        // Entity fields
                        Assert.IsNotNull(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationID);
                        Assert.IsNotNull(tvTypeUserAuthorizationRet.ContactTVItemID);
                        Assert.IsNotNull(tvTypeUserAuthorizationRet.TVType);
                        Assert.IsNotNull(tvTypeUserAuthorizationRet.TVAuth);
                        Assert.IsNotNull(tvTypeUserAuthorizationRet.LastUpdateDate_UTC);
                        Assert.IsNotNull(tvTypeUserAuthorizationRet.LastUpdateContactTVItemID);

                        // Non entity fields
                        if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityOnly)
                        {
                            if (tvTypeUserAuthorizationRet.TVTypeUserAuthorizationWeb != null)
                            {
                                Assert.IsNull(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationWeb);
                            }
                            if (tvTypeUserAuthorizationRet.TVTypeUserAuthorizationReport != null)
                            {
                                Assert.IsNull(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationReport);
                            }
                        }
                        else if (entityQueryDetailTypeEnum == EntityQueryDetailTypeEnum.EntityWeb)
                        {
                            if (tvTypeUserAuthorizationRet.TVTypeUserAuthorizationWeb != null)
                            {
                                Assert.IsNotNull(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationWeb);
                            }
                            if (tvTypeUserAuthorizationRet.TVTypeUserAuthorizationReport != null)
                            {
                                Assert.IsNotNull(tvTypeUserAuthorizationRet.TVTypeUserAuthorizationReport);
                            }
                        }
                    }
                }
            }
        }
        #endregion Tests Get With Key

        #region Tests Generated Get List of TVTypeUserAuthorization
        #endregion Tests Get List of TVTypeUserAuthorization

    }
}
