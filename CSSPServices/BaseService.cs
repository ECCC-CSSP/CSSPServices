using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class BaseService
    {
        #region Variables public
        public List<LanguageEnum> LanguageListAllowable = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
        //public int TakeMax = 1000000;
        //public string BasePath = @"E:\inetpub\wwwroot\csspwebtools\App_Data\";
        //public double R = 6378137.0;
        //public double d2r = Math.PI / 180;
        //public double r2d = 180 / Math.PI;
        //public Random random = new Random((int)(DateTime.Now.Ticks));
        //public List<TVTypeNamesAndPath> tvTypeNamesAndPathList = new List<TVTypeNamesAndPath>();
        //public List<PolSourceObsInfoChild> polSourceObsInfoChildList = new List<PolSourceObsInfoChild>();
        #endregion Variables public

        #region Properties
        public LanguageEnum LanguageRequest { get; set; }
        public int ContactID { get; set; }
        public bool IsTest { get; set; }
        public bool CanSendEmail { get; set; }
        public string DBName { get; set; }
        public string FromEmail { get; set; }
        #endregion Properties

        #region Constructors
        public BaseService(LanguageEnum LanguageRequest, int ContactID)
        {
            if (!LanguageListAllowable.Contains(LanguageRequest))
            {
                this.LanguageRequest = LanguageEnum.en;
            }
            else
            {
                this.LanguageRequest = LanguageRequest;
            }

            if (LanguageRequest == LanguageEnum.fr)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");
            }
            this.ContactID = ContactID;
            this.CanSendEmail = true;
            this.DBName = "CSSPWebToolsDBTest";
            this.FromEmail = "ec.pccsm-cssp.ec@canada.ca";
            this.IsTest = false;
        }
        #endregion Constructors  
    }
}
