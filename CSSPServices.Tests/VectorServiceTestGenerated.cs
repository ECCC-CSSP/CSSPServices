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
    public partial class VectorServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private VectorService vectorService { get; set; }
        #endregion Properties

        #region Constructors
        public VectorServiceTest() : base()
        {
            //vectorService = new VectorService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Tests Generated CRUD and Properties
        [TestMethod]
        public void Vector_CRUD_And_Properties_Test()
        {
            foreach (CultureInfo culture in AllowableCulture)
            {
                ChangeCulture(culture);

                using (CSSPWebToolsDBContext dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB))
                {
                    VectorService vectorService = new VectorService(new Query() { Lang = culture.TwoLetterISOLanguageName }, dbTestDB, ContactID);

                    int count = 0;
                    if (count == 1)
                    {
                        // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
                    }

                    Vector vector = GetFilledRandomVector("");

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

        #region Tests Generated for GetVectorWithVectorID(vector.VectorID)
        #endregion Tests Generated for GetVectorWithVectorID(vector.VectorID)

        #region Tests Generated for GetVectorList()
        #endregion Tests Generated for GetVectorList()

        #region Tests Generated for GetVectorList() Skip Take
        #endregion Tests Generated for GetVectorList() Skip Take

        #region Tests Generated for GetVectorList() Skip Take Order
        #endregion Tests Generated for GetVectorList() Skip Take Order

        #region Tests Generated for GetVectorList() Skip Take 2Order
        #endregion Tests Generated for GetVectorList() Skip Take 2Order

        #region Tests Generated for GetVectorList() Skip Take Order Where
        #endregion Tests Generated for GetVectorList() Skip Take Order Where

        #region Tests Generated for GetVectorList() Skip Take Order 2Where
        #endregion Tests Generated for GetVectorList() Skip Take Order 2Where

        #region Tests Generated for GetVectorList() 2Where
        #endregion Tests Generated for GetVectorList() 2Where

        #region Functions private
        private Vector GetFilledRandomVector(string OmitPropName)
        {
            Vector vector = new Vector();


            return vector;
        }
        #endregion Functions private
    }
}
