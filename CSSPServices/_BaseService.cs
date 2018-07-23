using CSSPEnums;
using CSSPModels;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
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
        public string BasePath = @"E:\inetpub\wwwroot\csspwebtools\App_Data\";
        public double R = 6378137.0;
        public double d2r = Math.PI / 180;
        public double r2d = 180 / Math.PI;
        //public Random random = new Random((int)(DateTime.Now.Ticks));
        //public List<TVTypeNamesAndPath> tvTypeNamesAndPathList = new List<TVTypeNamesAndPath>();
        //public List<PolSourceObsInfoChild> polSourceObsInfoChildList = new List<PolSourceObsInfoChild>();
        #endregion Variables public

        #region Properties
        public CSSPWebToolsDBContext db { get; set; }
        public bool CanSendEmail { get; set; }
        public int ContactID { get; set; }
        public string FromEmail { get; set; }
        public LanguageEnum LanguageRequest { get; set; }
        public GetParam GetParam { get; set; }
        #endregion Properties

        #region Constructors
        public BaseService(GetParam getParam, CSSPWebToolsDBContext db, int ContactID)
        {
            if (!LanguageListAllowable.Contains(getParam.Language))
            {
                this.LanguageRequest = LanguageEnum.en;
            }
            else
            {
                this.LanguageRequest = getParam.Language;
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
            this.db = db;
            CanSendEmail = true;
            FromEmail = "ec.pccsm-cssp.ec@canada.ca";
            GetParam = getParam;
        }
        #endregion Constructors  

        #region Functions public
        public Object EnhanceQueryStatements<T>(Object obj)
        {
            IQueryable<T> query = (IQueryable<T>)obj;

            // Example of GetParam.Where == "TVItemID,EQ,5|TVItemID,EQ,7"
            // This would be 2 where statement
            List<string> WhereList = GetParam.Where.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string where in WhereList)
            {
                // Example of where == "TVItemID,EQ,5"
                List<string> ValList = where.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                if (ValList.Count == 3)
                {
                    switch (ValList[1].ToLower())
                    {
                        case "eq":
                            {
                                query = query.Where(c => EF.Property<string>(c, ValList[0]) == ValList[2]);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            List<string> OrderByNamesList = GetParam.OrderByNames.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            if (OrderByNamesList.Count > 0)
            {
                foreach (string OrderByName in OrderByNamesList)
                {
                    query = query.OrderBy(c => EF.Property<string>(c, OrderByName));
                }
            }
            else
            {
                string TypeName = typeof(T).Name + "ID";

                query = OrderExpression.OrderByProp<T>(query, TypeName);
            }

            if (GetParam.Skip > 0)
            {
                query = query.Skip(GetParam.Skip);
            }

            query = query.Take(GetParam.Take);

            return query;
        }

        #endregion Functions public
    }
}
