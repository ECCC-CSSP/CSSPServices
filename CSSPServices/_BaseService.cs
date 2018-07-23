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

            foreach (WhereInfo whereInfo in GetParam.WhereInfoList)
            {
                switch (whereInfo.WhereOperator)
                {
                    case WhereOperatorEnum.Contains:
                        {
                            query = EF_Where_Expression.WhereContains(query, whereInfo.PropertyName, whereInfo.Value);
                        }
                        break;
                    case WhereOperatorEnum.EndsWith:
                        {
                            query = EF_Where_Expression.WhereEndsWith(query, whereInfo.PropertyName, whereInfo.Value);
                        }
                        break;
                    case WhereOperatorEnum.Equal:
                        {
                            switch (whereInfo.PropertyType)
                            {
                                case PropertyTypeEnum.Int:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                case PropertyTypeEnum.Double:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueDouble);
                                    break;
                                case PropertyTypeEnum.String:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                                case PropertyTypeEnum.Boolean:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueBool);
                                    break;
                                case PropertyTypeEnum.DateTime:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueDateTime);
                                    break;
                                case PropertyTypeEnum.Enum:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                default:
                                    query = EF_Where_Expression.WhereEqual(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                            }
                        }
                        break;
                    case WhereOperatorEnum.GreaterThan:
                        {
                            switch (whereInfo.PropertyType)
                            {
                                case PropertyTypeEnum.Int:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                case PropertyTypeEnum.Double:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueDouble);
                                    break;
                                case PropertyTypeEnum.String:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                                case PropertyTypeEnum.Boolean:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueBool);
                                    break;
                                case PropertyTypeEnum.DateTime:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueDateTime);
                                    break;
                                case PropertyTypeEnum.Enum:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                default:
                                    query = EF_Where_Expression.WhereGreaterThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                            }
                        }
                        break;
                    case WhereOperatorEnum.LessThan:
                        {
                            switch (whereInfo.PropertyType)
                            {
                                case PropertyTypeEnum.Int:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                case PropertyTypeEnum.Double:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueDouble);
                                    break;
                                case PropertyTypeEnum.String:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                                case PropertyTypeEnum.Boolean:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueBool);
                                    break;
                                case PropertyTypeEnum.DateTime:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueDateTime);
                                    break;
                                case PropertyTypeEnum.Enum:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.ValueInt);
                                    break;
                                default:
                                    query = EF_Where_Expression.WhereLessThan(query, whereInfo.PropertyName, whereInfo.Value);
                                    break;
                            }
                        }
                        break;
                    case WhereOperatorEnum.StartsWith:
                        {
                            query = EF_Where_Expression.WhereStartsWith(query, whereInfo.PropertyName, whereInfo.Value);
                        }
                        break;
                    default:
                        break;
                }
            }

            if (GetParam.OrderList.Count > 0)
            {
                foreach (string PropertyName in GetParam.OrderList)
                {
                    query = OrderExpression.OrderByProp(query, PropertyName);
                }
            }
            else
            {
                string PropertyName = typeof(T).Name + "ID";

                query = OrderExpression.OrderByProp(query, PropertyName);
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
