using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using CSSPModelsGenerateCodeHelper;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesGenerateCodeHelper : GenerateCodeBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        protected CSSPWebToolsDBContext dbCSSPWebToolsDB { get; set; }
        protected CSSPWebToolsDBContext dbCSSPWebToolsDBRead { get; set; }
        protected CSSPWebToolsDBContext dbTestDB { get; set; }
        protected CSSPWebToolsDBContext dbTestDBWrite { get; set; }
        private ModelsGenerateCodeHelper modelsGenerateCodeHelper { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesGenerateCodeHelper()
        {
            dbCSSPWebToolsDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryCSSPWebToolsDB);
            dbCSSPWebToolsDBRead = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerCSSPWebToolsDB);
            dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB);
            dbTestDBWrite = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB);

            modelsGenerateCodeHelper = new ModelsGenerateCodeHelper();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
