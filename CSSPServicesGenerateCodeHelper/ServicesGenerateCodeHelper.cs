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
        private ServicesFiles servicesFiles { get; set; }
        protected CSSPWebToolsDBContext dbCSSPWebToolsDB { get; set; }
        protected CSSPWebToolsDBContext dbCSSPWebToolsDBRead { get; set; }
        protected CSSPWebToolsDBContext dbTestDB { get; set; }
        protected CSSPWebToolsDBContext dbTestDBWrite { get; set; }
        private ModelsGenerateCodeHelper modelsGenerateCodeHelper { get; set; }
        #endregion Properties

        #region Constructors
        public ServicesGenerateCodeHelper(ServicesFiles servicesFiles)
        {
            this.servicesFiles = servicesFiles;
            dbCSSPWebToolsDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryCSSPWebToolsDB);
            dbCSSPWebToolsDBRead = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerCSSPWebToolsDB);
            dbTestDB = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryTestDB);
            dbTestDBWrite = new CSSPWebToolsDBContext(DatabaseTypeEnum.SqlServerTestDB);

            ModelsFiles modelsFiles = new ModelsFiles();
            modelsFiles.CSSPModelsDLL = this.servicesFiles.CSSPModelsDLL;
            // the other file name are not required

            modelsGenerateCodeHelper = new ModelsGenerateCodeHelper(modelsFiles);
        }
        #endregion Constructors

        #region Events
        //public virtual void ErrorEvent(ErrorEventArgs e)
        //{
        //    ErrorHandler?.Invoke(this, e);
        //}
        //public event EventHandler<ErrorEventArgs> ErrorHandler;
        //public virtual void StatusTempEvent(StatusEventArgs e)
        //{
        //    StatusTempHandler?.Invoke(this, e);
        //}
        //public event EventHandler<StatusEventArgs> StatusTempHandler;
        //public virtual void StatusPermanentEvent(StatusEventArgs e)
        //{
        //    StatusPermanentHandler?.Invoke(this, e);
        //}
        //public event EventHandler<StatusEventArgs> StatusPermanentHandler;
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }

    #region Other Classes
    public class ServicesFiles
    {
        public ServicesFiles()
        {
            CSSPServicesDLL = "";
            CSSPModelsDLL = "";
            BaseDir = "";
            BaseDirServices = "";
            BaseDirTest = "";
            BaseDirFillDBTest = "";
            CSSPWebToolsDBConnectionString = "";
            TestDBConnectionString = "";
        }
        public string CSSPServicesDLL { get; set; }
        public string CSSPModelsDLL { get; set; }
        public string BaseDir { get; set; }
        public string BaseDirServices { get; set; }
        public string BaseDirTest { get; set; }
        public string BaseDirFillDBTest { get; set; }
        public string CSSPWebToolsDBConnectionString { get; set; }
        public string TestDBConnectionString { get; set; }
    }
    #endregion Other Classes
}
