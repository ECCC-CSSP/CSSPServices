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

namespace CSSPServicesGenerateCodeHelper
{
    public partial class GenerateCodeHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        protected CSSPWebToolsDBContext db { get; set; }
        protected string DLLFileName { get; set; }
        protected RichTextBox RichTextBoxStatus { get; set; }
        protected Label LabelStatus { get; set; }
        protected string GenerateFilePath { get; set; }
        protected CSSPModelsGenerateCodeHelper.GenerateCodeHelper ModelGenerateCodeHelper { get; set; }
        #endregion Properties

        public GenerateCodeHelper(string DLLFileName, string GenerateFilePath, RichTextBox richTextBoxStatus, Label lblStatus)
        {
            db = new CSSPWebToolsDBContext(DatabaseTypeEnum.MemoryNoDBShape);
            this.DLLFileName = DLLFileName;
            this.RichTextBoxStatus = richTextBoxStatus;
            this.LabelStatus = lblStatus;
            this.GenerateFilePath = GenerateFilePath;

            ModelGenerateCodeHelper = new CSSPModelsGenerateCodeHelper.GenerateCodeHelper(DLLFileName, GenerateFilePath, richTextBoxStatus, lblStatus);
        }

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
