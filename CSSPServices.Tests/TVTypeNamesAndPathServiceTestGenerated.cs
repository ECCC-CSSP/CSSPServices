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
    public partial class TVTypeNamesAndPathServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private TVTypeNamesAndPathService tvTypeNamesAndPathService { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeNamesAndPathServiceTest() : base()
        {
            //tvTypeNamesAndPathService = new TVTypeNamesAndPathService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void TVTypeNamesAndPath_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    TVTypeNamesAndPathService tvTypeNamesAndPathService = new TVTypeNamesAndPathService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    TVTypeNamesAndPath tvTypeNamesAndPath = GetFilledRandomTVTypeNamesAndPath("");

                    // -------------------------------
                    // -------------------------------
                    // CRUD testing
                    // -------------------------------
                    // -------------------------------

                    // -------------------------------
                    // -------------------------------
                    // Properties testing
                    // -------------------------------
                    // -------------------------------

                }
            }
        }
        #endregion Tests Generated CRUD and Properties

        #region Tests Generated for GetTVTypeNamesAndPathWithTVTypeNamesAndPathID(tvTypeNamesAndPath.TVTypeNamesAndPathID)
        #endregion Tests Generated for GetTVTypeNamesAndPathWithTVTypeNamesAndPathID(tvTypeNamesAndPath.TVTypeNamesAndPathID)

        #region Tests Generated for GetTVTypeNamesAndPathList()
        #endregion Tests Generated for GetTVTypeNamesAndPathList()

        #region Tests Generated for GetTVTypeNamesAndPathList() Skip Take
        #endregion Tests Generated for GetTVTypeNamesAndPathList() Skip Take

        #region Tests Generated for GetTVTypeNamesAndPathList() Skip Take Order
        #endregion Tests Generated for GetTVTypeNamesAndPathList() Skip Take Order

        #region Tests Generated for GetTVTypeNamesAndPathList() Skip Take 2Order
        #endregion Tests Generated for GetTVTypeNamesAndPathList() Skip Take 2Order

        #region Tests Generated for GetTVTypeNamesAndPathList() Skip Take Order Where
        #endregion Tests Generated for GetTVTypeNamesAndPathList() Skip Take Order Where

        #region Tests Generated for GetTVTypeNamesAndPathList() Skip Take Order 2Where
        #endregion Tests Generated for GetTVTypeNamesAndPathList() Skip Take Order 2Where

        #region Tests Generated for GetTVTypeNamesAndPathList() 2Where
        #endregion Tests Generated for GetTVTypeNamesAndPathList() 2Where

        #region Functions private
        private TVTypeNamesAndPath GetFilledRandomTVTypeNamesAndPath(string OmitPropName)
        {
            TVTypeNamesAndPath tvTypeNamesAndPath = new TVTypeNamesAndPath();

            if (OmitPropName != "TVTypeName") tvTypeNamesAndPath.TVTypeName = GetRandomString("", 6);
            if (OmitPropName != "Index") tvTypeNamesAndPath.Index = GetRandomInt(1, 11);
            if (OmitPropName != "TVPath") tvTypeNamesAndPath.TVPath = GetRandomString("", 6);

            return tvTypeNamesAndPath;
        }
        #endregion Functions private
    }
}
