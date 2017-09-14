using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Routing;
using ftd.data;
using ftd.query.model;
using ftd.service;
using ftd.web;

namespace System.Web.Mvc.Html
{
    public static class FwbHtmlHelperExtensions
    {
        private const string DROPDOWNLIST_EMPTY_LABEL = "請選擇";

        //public static MvcForm beginFileForm(this HtmlHelper helper, string actionName = null, object httpAttributes = null)
        //{
        //    var newHttpAttributes = new RouteValueDictionary(httpAttributes);
        //    if (!newHttpAttributes.ContainsKey("enctype"))
        //    {
        //        newHttpAttributes.Add("enctype", "multipart/form-data");
        //    }
        //    var form = helper.BeginForm(actionName, null, FormMethod.Post, newHttpAttributes);
        //    return form;
        //}

        //public static MvcHtmlString editorValidationFor<TModel, TValue>(
        //    this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        //{
        //    var str = html.EditorFor(expression).ToString() +
        //        html.ValidationMessageFor(expression).ToString();

        //    var result = MvcHtmlString.Create(str);
        //    return result;
        //}

        public static MvcHtmlString dropDownList(this HtmlHelper helper, string name, string codeTypeName, bool addEmpty = false, object htmlAttributes = null, string defaultValue = "")
        {
            TagBuilder spanBuilder = new TagBuilder("span");

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            spanBuilder.MergeAttributes(attributes, true);
            spanBuilder.MergeAttribute("id", "sp_" + name, true);
            spanBuilder.MergeAttribute("name", "sp_" + name, true);

            TagBuilder selectBuiler = new TagBuilder("select");
            selectBuiler.MergeAttributes(attributes, true);
            selectBuiler.MergeAttribute("id", name, true);
            selectBuiler.MergeAttribute("name", name, true);

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;
            var codeTypes = FtdCodeNameService.Instance.getCodeNames(codeTypeName, "");
            if (codeTypes == null | codeTypes.Count == 0)
            {
                spanBuilder.InnerHtml += selectBuiler.ToString();
                result = MvcHtmlString.Create(spanBuilder.ToString());
                return result;
            }

            Dictionary<string, string> codeTypes2 = new Dictionary<string, string>();

            foreach (var key in codeTypes.Keys)
            {
                codeTypes2.Add(key.ToString(), codeTypes[key].ToString());
            }

            //額外增加之選項，例：""-請選擇
            if (addEmpty)
            {
                sb.AppendFormat("<option value=\"\">{0}</option>", DROPDOWNLIST_EMPTY_LABEL);
            }

            foreach (var key in codeTypes2.Keys)
            {
                if (defaultValue.equalIgnoreCase(key))
                {
                    sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", key, codeTypes2[key]);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\">{1}</option>", key, codeTypes2[key]);
                }
            }

            selectBuiler.InnerHtml += sb.ToString();
            spanBuilder.InnerHtml += selectBuiler.ToString();
            result = MvcHtmlString.Create(spanBuilder.ToString());
            return result;
        }

        public static MvcHtmlString dropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string codeTypeName, bool addEmpty = false, object htmlAttributes = null)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);

            // Derive property name for element name
            string propertyName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);

            // Get currently select values from the ViewData model
            TProperty val = default(TProperty); 
            string selectedValue = "";
            if (helper.ViewData.Model != null)
            {
                val = expression.Compile().Invoke(helper.ViewData.Model);
                if (val != null)
                {
                    selectedValue = val.ToString();
                }
            }

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.MergeAttributes(attributes, true);
            spanBuilder.MergeAttribute("id", "sp_" + propertyName, true);
            spanBuilder.MergeAttribute("name", "sp_" + propertyName, true);

            TagBuilder selectBuiler = new TagBuilder("select");
            selectBuiler.MergeAttributes(attributes, true);
            selectBuiler.MergeAttribute("id", propertyName, true);
            selectBuiler.MergeAttribute("name", propertyName, true);

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;
            var codeTypes = FtdCodeNameService.Instance.getCodeNames(codeTypeName, "");
            if (codeTypes == null | codeTypes.Count == 0)
            {
                spanBuilder.InnerHtml += selectBuiler.ToString();
                result = MvcHtmlString.Create(spanBuilder.ToString());
                return result;
            }

            Dictionary<string, string> codeTypes2 = new Dictionary<string, string>();

            foreach (var key in codeTypes.Keys)
            {
                codeTypes2.Add(key.ToString(), codeTypes[key].ToString());
            }

            //額外增加之選項，例：""-請選擇
            if (addEmpty)
            {
                if (selectedValue.Length > 0)
                {
                    sb.AppendFormat("<option value=\"\">{0}</option>", DROPDOWNLIST_EMPTY_LABEL);
                }
                else
                {
                    sb.AppendFormat("<option value=\"\" selected=\"selected\">{0}</option>", DROPDOWNLIST_EMPTY_LABEL);
                }
            }

            foreach (var key in codeTypes2.Keys)
            {
                if (selectedValue.equalIgnoreCase(key))
                {
                    sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", key, codeTypes2[key]);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\">{1}</option>", key, codeTypes2[key]);
                }
            }

            selectBuiler.InnerHtml += sb.ToString();
            spanBuilder.InnerHtml += selectBuiler.ToString();
            result = MvcHtmlString.Create(spanBuilder.ToString());
            return result;
        }

        public static MvcHtmlString functionName(this HtmlHelper helper, string funCode, bool textOnly = false)
        {
            var userFuns = AppUserSession.User.UserFunctions;
            if (userFuns == null)
                return MvcHtmlString.Create("");

            var fun = userFuns.Find(x => x.Attributes["itemNo"] == funCode);
            if (fun == null)
                return MvcHtmlString.Create("");

            if (textOnly)
                return MvcHtmlString.Create(fun.Attributes["title"]);

            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"function-title\">");
            sb.AppendFormat("<h2>{0}-{1}</h2>", funCode, fun.Attributes["title"]);
            sb.Append("</div>");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString toolBar(this HtmlHelper helper, string funCode)
        {
            //使用者程式功能權限
            var userId = AppUserSession.User.UserId;
            var qm = new EoMenuFunQryModel();
            qm.Q_ItemNo = funCode;
            qm.Q_ToolbarLevel = "F";
            var dtMenuFun = EoDataService.Instance.EoMenuFun_getList(qm).OrderBy(t => t.EOMF_SeqNo);
            var funPermSet = EoDataService.Instance.queryUserFunPermSet(userId, "EOM_MAINMENU");
            var userPermission = FtdPermissionService.Instance.getActorPermission(userId);
            var isAdmin = userPermission.containPermisson(AppPermissionName.APN_APP_SystemAdmin);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div id=\"toolbar\" class=\"toolbar\">");
            if (isAdmin)
            {
                //具有系統管理權限
                foreach (var cmd in dtMenuFun)
                {
                    sb.AppendFormat("<input type=\"button\" id=\"cmd{0}\" class=\"ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover\" value=\"{1}\" onclick=\"doAction('{2}');\" />", cmd.EOMF_FunctionCode, cmd.EOMF_FunctionName, cmd.EOMF_FunctionCode.ToLower());
                }
            }
            else
            {
                if (funPermSet.Keys.Contains(funCode))
                {
                    var codes = funPermSet[funCode].Select(x => x.Key).ToArray();
                    var funs = dtMenuFun.Where(t => t.EOMF_FunctionCode.inAny(codes));
                    foreach (var cmd in funs)
                    {
                        sb.AppendFormat("<input type=\"button\" id=\"cmd{0}\" class=\"ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover\" value=\"{1}\" onclick=\"doAction('{2}');\" />", cmd.EOMF_FunctionCode, cmd.EOMF_FunctionName, cmd.EOMF_FunctionCode.ToLower());
                    }
                }
            }
            sb.AppendFormat("</div>");
            //sb.AppendFormat("<div id=\"toolbar\" class=\"toolbar\">");
            //sb.AppendFormat("<input type=\"button\" id=\"cmdQuery\" class=\"ui-button ui-widget ui-state-default ui-corner-all ui-button-text-only ui-state-hover\" value=\"查詢\" onclick=\"doAction('query');\" />");
            //sb.AppendFormat("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString codeQuery(this HtmlHelper helper, string groupName, string action, string controller, bool checkPermission)
        {
            return codeQuery(helper, groupName, action, controller, 800, 600, null, true, null, checkPermission);
        }

        public static MvcHtmlString codeQuery(this HtmlHelper helper, string groupName, string action, string controller, int width = 800, int height = 600, object htmlAttributes = null, bool showClearButton = true, object routeValues = null, bool checkPermission = false, string displayText = "")
        {
            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            spanBuilder.MergeAttribute("id", groupName, true);
            spanBuilder.MergeAttribute("class", "code-query-widget", true);

            bool allowChange = true;
            //是否檢查權限
            if (checkPermission && !AppUserSession.User.IsSysAdmin)
                allowChange = false;

            string title = "查詢";
            if (spanBuilder.Attributes.Keys.Contains("title"))
                title = spanBuilder.Attributes["title"] + "查詢";

            string extRequest = "";
            string area = "";
            if (routeValues != null)
            {
                RouteValueDictionary tmpRouteValues = new RouteValueDictionary(routeValues);
                foreach (var item in tmpRouteValues)
                {
                    if (item.Key.equalIgnoreCase("area"))
                    {
                        area = item.Value.ToString();
                        continue;
                    }
                    extRequest += string.Format("&{0}={1}", item.Key, item.Value);
                }
            }
            //string url = string.Format("../{0}/{1}?RequestKey={2}{3}", controller, action, groupName, extRequest);
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            string url = string.Format("{0}?RequestKey={1}{2}", urlHelper.Action(action, controller, routeValues), groupName, extRequest);
            string cqFunction = string.Format("CodeQuery({0}, {1}, true, '{2}', '{3}');", height, width, url, title);

            if (displayText.isNullOrEmpty())
                displayText = "...";

            StringBuilder sb = new StringBuilder();
            if (showClearButton)
            {
                sb.AppendFormat("<input type='button' value='{2}' onclick=\"{0}\"{1} />", cqFunction, (allowChange ? "" : " disabled=\"disabled\""), displayText);
                sb.AppendFormat("<input type='button' value='X' onclick=\"clearGroupFileds('{0}');\"{1} />", groupName, (allowChange ? "" : " disabled=\"disabled\""));
            }
            else
            {
                sb.AppendFormat("<input type='button' value='{2}' onclick=\"{0}\"{1} />", cqFunction, (allowChange ? "" : " disabled=\"disabled\""), displayText);
            }
            spanBuilder.InnerHtml += sb.ToString();
            return MvcHtmlString.Create(spanBuilder.ToString());
        }

        public static MvcHtmlString codeQueryUserDefine(this HtmlHelper helper, string groupName, string clickFunction, string clearFunction, bool checkPermission)
        {
            return codeQueryUserDefine(helper, groupName, clickFunction, clearFunction, 800, 600, null, true, checkPermission);
        }

        public static MvcHtmlString codeQueryUserDefine(this HtmlHelper helper, string groupName, string clickFunction, string clearFunction = "", int width = 800, int height = 600, object htmlAttributes = null, bool showClearButton = true, bool checkPermission = false, string displayText = "")
        {
            TagBuilder spanBuilder = new TagBuilder("span");
            spanBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            spanBuilder.MergeAttribute("id", groupName, true);
            spanBuilder.MergeAttribute("class", "code-query-widget", true);

            bool allowChange = true;
            //是否檢查權限
            if (checkPermission && !AppUserSession.User.IsSysAdmin)
                allowChange = false;

            string title = "查詢";
            if (spanBuilder.Attributes.Keys.Contains("title"))
                title = spanBuilder.Attributes["title"] + "查詢";

            if (clearFunction.isNullOrEmpty())
                clearFunction = string.Format("clearGroupFileds('{0}');", groupName);

            if (displayText.isNullOrEmpty())
                displayText = "...";

            StringBuilder sb = new StringBuilder();
            if (showClearButton)
            {
                sb.AppendFormat("<input type='button' value='{2}' onclick=\"{0}\"{1} />", clickFunction, (allowChange ? "" : " disabled=\"disabled\""), displayText);
                sb.AppendFormat("<input type='button' value='X' onclick=\"{0}\"{1} />", clearFunction, (allowChange ? "" : " disabled=\"disabled\""));
            }
            else
            {
                sb.AppendFormat("<input type='button' value='{2}' onclick=\"{0}\"{1} />", clickFunction, (allowChange ? "" : " disabled=\"disabled\""), displayText);
            }
            spanBuilder.InnerHtml += sb.ToString();
            return MvcHtmlString.Create(spanBuilder.ToString());
        }

        public static MvcHtmlString radioButtons(this HtmlHelper helper, string name, string codeTypeName, string defaultValue = "", bool addAll = false, object htmlAttributes = null)
        {
            TagBuilder divBuilder = new TagBuilder("div");

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            divBuilder.MergeAttributes(attributes, true);
            divBuilder.MergeAttribute("id", "rbn_" + name, true);
            divBuilder.MergeAttribute("name", "rbn_" + name, true);
            divBuilder.AddCssClass("inline-block");

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;

            var codeTypes = FtdCodeNameService.Instance.getCodeNames(codeTypeName, "");
            if (codeTypes == null | codeTypes.Count == 0)
            {
                result = MvcHtmlString.Create(divBuilder.ToString());
                return result;
            }

            Dictionary<string, string> codeTypes2 = new Dictionary<string, string>();

            foreach (var key in codeTypes.Keys)
            {
                codeTypes2.Add(key.ToString(), codeTypes[key].ToString());
            }

            //額外增加"全選"
            if (addAll)
            {
                if (defaultValue == "")
                {
                    sb.AppendFormat("<input type=\"radio\" name=\"{0}\" id=\"{0}_All\" value=\"\" checked=\"checked\" /><label for=\"{0}_All\">全部</label>", name);
                }
                else
                {
                    sb.AppendFormat("<input type=\"radio\" name=\"{0}\" id=\"{0}_All\" value=\"\" /><label for=\"{0}_All\">全部</label>", name);
                }
            }

            foreach (var key in codeTypes2.Keys)
            {
                if (!defaultValue.isNullOrEmpty() && defaultValue.equalIgnoreCase(key))
                {
                    sb.AppendFormat("<input type=\"radio\" name=\"{0}\" id=\"{0}_{1}\" value=\"{1}\" checked=\"checked\" /><label for=\"{0}_{1}\">{2}</label>", name, key, codeTypes2[key]);
                }
                else
                {
                    sb.AppendFormat("<input type=\"radio\" name=\"{0}\" id=\"{0}_{1}\" value=\"{1}\" /><label for=\"{0}_{1}\">{2}</label>", name, key, codeTypes2[key]);
                }
            }

            divBuilder.InnerHtml += sb.ToString();
            result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }

        public static MvcHtmlString radioButtonsFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string codeTypeName, object htmlAttributes = null)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);

            // Derive property name for element name
            string propertyName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);

            // Get currently select values from the ViewData model
            TProperty val = expression.Compile().Invoke(helper.ViewData.Model);
            string selectedValue = "";
            if (val != null)
            {
                selectedValue = val.ToString();
            }

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(attributes, true);
            divBuilder.MergeAttribute("id", "rbn_" + propertyName, true);
            divBuilder.MergeAttribute("name", "rbn_" + propertyName, true);
            divBuilder.AddCssClass("inline-block");

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;

            var codeTypes = FtdCodeNameService.Instance.getCodeNames(codeTypeName, "");
            if (codeTypes == null | codeTypes.Count == 0)
            {
                result = MvcHtmlString.Create(divBuilder.ToString());
                return result;
            }

            Dictionary<string, string> codeTypes2 = new Dictionary<string, string>();

            foreach (var key in codeTypes.Keys)
            {
                codeTypes2.Add(key.ToString(), codeTypes[key].ToString());
            }

            foreach (var key in codeTypes2.Keys)
            {
                if (selectedValue.equalIgnoreCase(key))
                {
                    sb.AppendFormat("<input type=\"radio\" name=\"{0}\" id=\"{0}_{1}\" value=\"{1}\" checked=\"checked\" /><label for=\"{0}_{1}\">{2}</label>", propertyName, key, codeTypes2[key]);
                }
                else
                {
                    sb.AppendFormat("<input type=\"radio\" name=\"{0}\" id=\"{0}_{1}\" value=\"{1}\" /><label for=\"{0}_{1}\">{2}</label>", propertyName, key, codeTypes2[key]);
                }
            }

            divBuilder.InnerHtml += sb.ToString();
            result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }

        public static MvcHtmlString checkBox(this HtmlHelper helper, string name, string desc, object htmlAttributes = null, string checkedValue = "Y", string uncheckedValue = "N", bool isChecked = false)
        {
            TagBuilder divBuilder = new TagBuilder("div");

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            divBuilder.MergeAttributes(attributes, true);
            divBuilder.MergeAttribute("id", "chk_" + name, true);
            divBuilder.MergeAttribute("name", "chk_" + name, true);
            divBuilder.AddCssClass("inline-block");

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;

            if (isChecked)
            {
                sb.AppendFormat("<input type=\"checkbox\" id=\"{0}\" name=\"{0}\" data-checked=\"{1}\" data-unchecked=\"{2}\" checked=\"checked\" /><label for=\"{0}\">{3}</label>", name, checkedValue, uncheckedValue, desc);
            }
            else
            {
                sb.AppendFormat("<input type=\"checkbox\" id=\"{0}\" name=\"{0}\" data-checked=\"{1}\" data-unchecked=\"{2}\" /><label for=\"{0}\">{3}</label>", name, checkedValue, uncheckedValue, desc);
            }
            divBuilder.InnerHtml += sb.ToString();
            result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }

        public static MvcHtmlString checkBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string desc, object htmlAttributes = null, string checkedValue = "Y", string uncheckedValue = "N")
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);

            // Derive property name for element name
            string propertyName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);

            // Get currently select values from the ViewData model
            TProperty val = expression.Compile().Invoke(helper.ViewData.Model);
            string selectedValue = "";
            if (val != null)
            {
                selectedValue = val.ToString();
            }

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(attributes, true);
            divBuilder.MergeAttribute("id", "chk_" + propertyName, true);
            divBuilder.MergeAttribute("name", "chk_" + propertyName, true);
            divBuilder.AddCssClass("inline-block");

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;

            if (selectedValue.equalIgnoreCase(checkedValue))
            {
                sb.AppendFormat("<input type=\"checkbox\" id=\"{0}\" name=\"{0}\" data-checked=\"{1}\" data-unchecked=\"{2}\" checked=\"checked\" /><label for=\"{0}\">{3}</label>", propertyName, checkedValue, uncheckedValue, desc);
            }
            else
            {
                sb.AppendFormat("<input type=\"checkbox\" id=\"{0}\" name=\"{0}\" data-checked=\"{1}\" data-unchecked=\"{2}\" /><label for=\"{0}\">{3}</label>", propertyName, checkedValue, uncheckedValue, desc);
            }

            divBuilder.InnerHtml += sb.ToString();
            result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }

        // 查詢使用者權限用
        public static MvcHtmlString treeViewUserMenu(this HtmlHelper helper, string name, string userId, object htmlAttributes = null)
        {
            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(attributes, true);
            divBuilder.MergeAttribute("id", name, true);
            divBuilder.MergeAttribute("name", name, true);

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;

            //使用者功能表權限
            FtdXmlMenu xmlmenu = EoDataService.Instance.getUserMenus(userId);
            //使用者程式功能權限
            var qm = new EoMenuFunQryModel();
            var dtMenuFun = EoDataService.Instance.EoMenuFun_getList(qm);
            var funPermSet = EoDataService.Instance.queryUserFunPermSet(userId, "EOM_MAINMENU");
            var userPermission = FtdPermissionService.Instance.getActorPermission(userId);
            var isAdmin = userPermission.containPermisson(AppPermissionName.APN_APP_SystemAdmin);

            Action<IEnumerable<FtdXmlMenuNode>, string, string> GenerateTree = null;
            GenerateTree = (nodes, parentID, treeNodeId) =>
                {
                    if (nodes.Any(x => x.Parent.ID == parentID))
                    {
                        int j = -1;
                        sb.AppendFormat("<ul>");
                        foreach (var node in nodes)
                        {
                            j++;
                            var treeId2 = treeNodeId + "-" + j;
                            sb.AppendFormat("<li id=\"{0}\" data-itemno=\"{0}\">", node["itemNo"]);
                            //if (node.ChildNodes.Count > 0)
                            var childCount = node.ChildNodes.Where(x => x["viewable"] == "Y").Count();
                            if (childCount > 0)
                            {
                                //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_{0}\" name=\"chk_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                                sb.AppendFormat("<label for=\"chk_{0}\">{1}</label>", node["itemNo"], node["title"]);
                            }
                            else
                            {
                                //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_menu_{0}\" name=\"chk_menu_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                                sb.AppendFormat("<label for=\"chk_menu_{0}\">{0}-{1}</label>", node["itemNo"], node["title"]);
                                sb.AppendFormat("<span>-----</span>");

                                if (isAdmin) //具有系統管理權限
                                {
                                    var cmds = dtMenuFun.Where(t => t.EOMF_ItemNo == node["itemNo"].ToString()).OrderBy(x => x.EOMF_SeqNo).ToArray();
                                    foreach (var cmd in cmds)
                                    {
                                        sb.AppendFormat("<span>--</span>");
                                        //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_fun_{0}_{1}\" name=\"chk_fun_{0}\" value=\"{1}\" data-itemno=\"{0}\" />", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode);
                                        sb.AppendFormat("<label for=\"chk_fun_{0}_{1}\">{2}</label>", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode, cmd.EOMF_FunctionName);
                                    }
                                }
                                else
                                {
                                    if (funPermSet.Keys.Contains(node["itemNo"]))
                                    {
                                        var cmds = funPermSet[node["itemNo"]];
                                        foreach (var key in cmds.Keys)
                                        {
                                            sb.AppendFormat("<span>--</span>");
                                            //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_fun_{0}_{1}\" name=\"chk_fun_{0}\" value=\"{1}\" data-itemno=\"{0}\" />", node["itemNo"], key);
                                            sb.AppendFormat("<label for=\"chk_fun_{0}_{1}\">{2}</label>", node["itemNo"], key, cmds[key]);
                                        }
                                    }
                                }
                            }
                            GenerateTree(node.ChildNodes, node.ID, treeId2);
                            sb.AppendFormat("</li>");
                        }
                        sb.AppendFormat("</ul>");
                    }
                };

            int i = -1;
            sb.AppendFormat("<ul>");
            foreach (var node in xmlmenu.RootNode.ChildNodes)
            {
                i++;
                var treeId = "item-" + i.ToString();
                sb.AppendFormat("<li id=\"{0}\" data-itemno=\"{0}\">", node["itemNo"]);
                //if (node.ChildNodes.Count > 0)
                var childCount = node.ChildNodes.Where(x => x["viewable"] == "Y").Count();
                if (childCount > 0)
                {
                    //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_{0}\" name=\"chk_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                    sb.AppendFormat("<label for=\"chk_{0}\">{1}</label>", node["itemNo"], node["title"]);
                }
                else
                {
                    //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_menu_{0}\" name=\"chk_menu_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                    sb.AppendFormat("<label for=\"chk_menu_{0}\">{0}-{1}</label>", node["itemNo"], node["title"]);
                    sb.AppendFormat("<span>-----</span>");

                    if (isAdmin) //具有系統管理權限
                    {
                        var cmds = dtMenuFun.Where(t => t.EOMF_ItemNo == node["itemNo"].ToString()).OrderBy(x => x.EOMF_SeqNo).ToArray();
                        foreach (var cmd in cmds)
                        {
                            sb.AppendFormat("<span>--</span>");
                            //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_fun_{0}_{1}\" name=\"chk_fun_{0}\" value=\"{1}\" data-itemno=\"{0}\" />", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode);
                            sb.AppendFormat("<label for=\"chk_fun_{0}_{1}\">{2}</label>", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode, cmd.EOMF_FunctionName);
                        }
                    }
                    else
                    {
                        if (funPermSet.Keys.Contains(node["itemNo"]))
                        {
                            var cmds = funPermSet[node["itemNo"]];
                            foreach (var key in cmds.Keys)
                            {
                                sb.AppendFormat("<span>--</span>");
                                //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_fun_{0}_{1}\" name=\"chk_fun_{0}\" value=\"{1}\" data-itemno=\"{0}\" />", node["itemNo"], key);
                                sb.AppendFormat("<label for=\"chk_fun_{0}_{1}\">{2}</label>", node["itemNo"], key, cmds[key]);
                            }
                        }
                    }
                }

                ////sb.AppendFormat("<input type=\"checkbox\" id=\"chk_{0}\" name=\"chk_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                //sb.AppendFormat("<label for=\"chk_{0}\">{1}</label>", node["itemNo"], node["title"]);
                GenerateTree(node.ChildNodes, node.ID, treeId);
                sb.AppendFormat("</li>");
            }
            sb.AppendFormat("</ul>");

            divBuilder.InnerHtml += sb.ToString();
            result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }

        // 功能表權限設定專用
        public static MvcHtmlString treeViewMenuPermFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string name, object htmlAttributes = null)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, helper.ViewData);

            // Derive property name for element name
            string propertyName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);

            // Get currently select values from the ViewData model
            TProperty val = expression.Compile().Invoke(helper.ViewData.Model);
            string menuPermId = "";
            if (val != null)
            {
                menuPermId = val.ToString();
            }

            RouteValueDictionary tmpAttributes = new RouteValueDictionary(htmlAttributes);
            var dic1 = tmpAttributes.Where(a => !a.Key.StartsWith("data_"))
                .Select(p => new { p.Key, p.Value })
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            RouteValueDictionary attributes = new RouteValueDictionary(dic1);

            var dic2 = tmpAttributes.Where(a => a.Key.StartsWith("data_"));
            foreach (var item in dic2)
            {
                attributes.Add(item.Key.Replace("data_", "data-"), item.Value);
            }

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.MergeAttributes(attributes, true);
            divBuilder.MergeAttribute("id", name, true);
            divBuilder.MergeAttribute("name", name, true);

            StringBuilder sb = new StringBuilder();
            MvcHtmlString result;

            //功能表
            FtdXmlMenu xmlmenu = EoDataService.Instance.getMenu(true);
            //程式功能清單
            var qm = new EoMenuFunQryModel();
            var dtMenuFun = EoDataService.Instance.EoMenuFun_getList(qm);

            //程式授權清單
            var dtMenuPermSet = EoDataService.Instance.EoMenuPermSet_getByMenuPerId(menuPermId);
            var itemNos = dtMenuPermSet.Select(x => x.EOMPS_MenuItemNo).Distinct().ToArray();
            //程式功能授權清單
            var menuPermSetIds = dtMenuPermSet.Select(x => x.EOMPS_MenuPermSetId).ToArray();
            var dtFunPermSet = EoDataService.Instance.EoFunPermSet_getByMenuPermSetIds(menuPermSetIds);
            //var funPermSet = dtFunPermSet.GroupBy(x => x.EOFPS_MenuItemNo_XX, y => new { Code = y.EOFPS_FunctionCode_XX, Name = y.EOFPS_FunctionName_XX })
            //    .ToDictionary(x => x.Key, y => y.ToDictionary(a => a.Code, b => b.Name));

            Dictionary<string, Dictionary<string, string>> funPermSet = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> dicFuns = null;
            var itemNos2 = dtFunPermSet.Select(x => x.EOFPS_MenuItemNo_XX).Distinct().ToArray();
            foreach (var item in itemNos2)
            {
                if (!funPermSet.Keys.Contains(item))
                {
                    funPermSet.Add(item, new Dictionary<string, string>());
                }
                dicFuns = funPermSet[item];

                var funs = dtFunPermSet.Where(x => x.EOFPS_MenuItemNo_XX == item).OrderBy(x => x.EOFPS_FunctionSeqNo_XX).ToArray();
                foreach (var fun in funs)
                {
                    if (dicFuns.Keys.Contains(fun.EOFPS_FunctionCode_XX))
                        dicFuns[fun.EOFPS_FunctionCode_XX] = fun.EOFPS_FunctionName_XX;
                    else
                        dicFuns.Add(fun.EOFPS_FunctionCode_XX, fun.EOFPS_FunctionName_XX);
                }
            }

            Action<IEnumerable<FtdXmlMenuNode>, string, string> GenerateTree = null;
            GenerateTree = (nodes, parentID, treeNodeId) =>
                {
                    if (nodes.Any(x => x.Parent.ID == parentID))
                    {
                        int j = -1;
                        sb.AppendFormat("<ul>");
                        foreach (var node in nodes)
                        {
                            j++;
                            var treeId2 = treeNodeId + "-" + j;
                            sb.AppendFormat("<li id=\"{0}\" data-itemno=\"{0}\">", node["itemNo"]);
                            var childCount = node.ChildNodes.Where(x => x["viewable"] == "Y").Count();
                            if (childCount > 0)
                            {
                                sb.AppendFormat("<input type=\"checkbox\" id=\"chk_{0}\" name=\"chk_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                                sb.AppendFormat("<label for=\"chk_{0}\">{1}</label>", node["itemNo"], node["title"]);
                            }
                            else
                            {
                                var chkMenu = "";
                                if (itemNos.Contains(node["itemNo"]))
                                    chkMenu = " checked=\"checked\"";

                                sb.AppendFormat("<input type=\"checkbox\" id=\"chk_menu_{0}\" name=\"chk_menu_{0}\" value=\"{0}\" data-itemno=\"{0}\"{1} />", node["itemNo"], chkMenu);
                                sb.AppendFormat("<label for=\"chk_menu_{0}\">{0}-{1}</label>", node["itemNo"], node["title"]);
                                sb.AppendFormat("<span>-----</span>");

                                var cmds = dtMenuFun.Where(t => t.EOMF_ItemNo == node["itemNo"].ToString()).OrderBy(x => x.EOMF_SeqNo).ToArray();
                                foreach (var cmd in cmds)
                                {
                                    var chkFun = "";
                                    if (funPermSet.Keys.Contains(node["itemNo"]))
                                    {
                                        if (funPermSet[node["itemNo"]].Keys.Contains(cmd.EOMF_FunctionCode))
                                            chkFun = " checked=\"checked\"";
                                    }
                                    sb.AppendFormat("<input type=\"checkbox\" id=\"chk_fun_{0}_{1}\" name=\"chk_fun_{0}\" value=\"{1}\" data-itemno=\"{0}\"{2} />", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode, chkFun);
                                    sb.AppendFormat("<label for=\"chk_fun_{0}_{1}\">{2}</label>", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode, cmd.EOMF_FunctionName);
                                }
                            }
                            GenerateTree(node.ChildNodes, node.ID, treeId2);
                            sb.AppendFormat("</li>");
                        }
                        sb.AppendFormat("</ul>");
                    }
                };

            int i = -1;
            sb.AppendFormat("<ul>");
            foreach (var node in xmlmenu.RootNode.ChildNodes)
            {
                i++;
                var treeId = "item-" + i.ToString();
                sb.AppendFormat("<li id=\"{0}\" data-itemno=\"{0}\">", node["itemNo"]);
                var childCount = node.ChildNodes.Where(x => x["viewable"] == "Y").Count();
                if (childCount > 0)
                {
                    sb.AppendFormat("<input type=\"checkbox\" id=\"chk_{0}\" name=\"chk_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                    sb.AppendFormat("<label for=\"chk_{0}\">{1}</label>", node["itemNo"], node["title"]);
                }
                else
                {
                    var chkMenu = "";
                    if (itemNos.Contains(node["itemNo"]))
                        chkMenu = " checked=\"checked\"";

                    sb.AppendFormat("<input type=\"checkbox\" id=\"chk_menu_{0}\" name=\"chk_menu_{0}\" value=\"{0}\" data-itemno=\"{0}\"{1} />", node["itemNo"], chkMenu);
                    sb.AppendFormat("<label for=\"chk_menu_{0}\">{0}-{1}</label>", node["itemNo"], node["title"]);
                    sb.AppendFormat("<span>-----</span>");

                    var cmds = dtMenuFun.Where(t => t.EOMF_ItemNo == node["itemNo"].ToString()).OrderBy(x => x.EOMF_SeqNo).ToArray();
                    foreach (var cmd in cmds)
                    {
                        var chkFun = "";
                        if (funPermSet.Keys.Contains(node["itemNo"]))
                        {
                            if (funPermSet[node["itemNo"]].Keys.Contains(cmd.EOMF_FunctionCode))
                                chkFun = " checked=\"checked\"";
                        }
                        sb.AppendFormat("<input type=\"checkbox\" id=\"chk_fun_{0}_{1}\" name=\"chk_fun_{0}\" value=\"{1}\" data-itemno=\"{0}\"{2} />", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode, chkFun);
                        sb.AppendFormat("<label for=\"chk_fun_{0}_{1}\">{2}</label>", cmd.EOMF_ItemNo, cmd.EOMF_FunctionCode, cmd.EOMF_FunctionName);
                    }
                }
                //sb.AppendFormat("<input type=\"checkbox\" id=\"chk_{0}\" name=\"chk_{0}\" value=\"{0}\" data-itemno=\"{0}\" />", node["itemNo"]);
                //sb.AppendFormat("<label for=\"chk_{0}\">{1}</label>", node["itemNo"], node["title"]);
                GenerateTree(node.ChildNodes, node.ID, treeId);
                sb.AppendFormat("</li>");
            }
            sb.AppendFormat("</ul>");

            divBuilder.InnerHtml += sb.ToString();
            result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }

        public static MvcHtmlString jTableToolbar(this HtmlHelper helper, string funCode)
        {
            //必需指定程式代號
            if (funCode.isNullOrEmpty())
                return MvcHtmlString.Create("");

            //找出資料表層級的功能鍵
            var qm = new EoMenuFunQryModel();
            qm.Q_ItemNo = funCode;
            qm.Q_ToolbarLevel = "T";
            var dtFun = EoDataService.Instance.EoMenuFun_getList(qm);
            dtFun.OrderBy(x => x.EOMF_SeqNo);
            //是否為系統管理員
            var isAdmin = AppUserSession.User.containsPermission(AppPermissionName.APN_APP_SystemAdmin);
            //使用者功能權限
            var userFunPermSet = AppUserSession.User.UserFunPermSet;
            Dictionary<string, string> funPermSet = null;
            if (userFunPermSet.Keys.Contains(funCode))
                funPermSet = userFunPermSet[funCode];
            //無任何權限
            if (!isAdmin && (funPermSet == null || funPermSet.Count == 0))
                return MvcHtmlString.Create("");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("items: [");
            sb.AppendLine();
            foreach (var item in dtFun)
            {
                //功能代號
                var cmd = item.EOMF_FunctionCode;
                var name = item.EOMF_FunctionName;
                var hasPerm = (funPermSet != null && funPermSet.Keys.Contains(cmd));
                if (isAdmin || hasPerm)
                {
                    sb.AppendFormat("{{");
                    sb.AppendLine();

                    if (cmd.equalIgnoreCase("create"))
                        sb.AppendFormat("    icon: '../Scripts/jtable/themes/lightcolor/add.png',");
                    else
                        sb.AppendFormat("    //icon: '../Scripts/jtable/themes/lightcolor/add.png',");

                    sb.AppendLine();
                    sb.AppendFormat("    text: '{0}',", name);
                    sb.AppendLine();
                    sb.AppendFormat("    click: function() {{ doTableAction_{0}('{1}'); }},", funCode, cmd.ToLower());
                    sb.AppendLine();
                    sb.AppendFormat("    cssClass: 'jtable-toolbar-cmd-{0}'", cmd.ToLower());
                    sb.AppendLine();
                    sb.AppendFormat("}},");
                    sb.AppendLine();
                }
            }
            sb.AppendFormat("]");

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString jTableItemActions(this HtmlHelper helper, string funCode)
        {
            //必需指定程式代號
            if (funCode.isNullOrEmpty())
                return MvcHtmlString.Create("");

            //找出資料列層級的功能鍵
            var qm = new EoMenuFunQryModel();
            qm.Q_ItemNo = funCode;
            qm.Q_ToolbarLevel = "R";
            var dtFun = EoDataService.Instance.EoMenuFun_getList(qm);
            dtFun.OrderBy(x => x.EOMF_SeqNo);
            //是否為系統管理員
            var isAdmin = AppUserSession.User.containsPermission(AppPermissionName.APN_APP_SystemAdmin);
            //使用者功能權限
            var userFunPermSet = AppUserSession.User.UserFunPermSet;
            Dictionary<string, string> funPermSet = null;
            if (userFunPermSet.Keys.Contains(funCode))
                funPermSet = userFunPermSet[funCode];

            StringBuilder sb = new StringBuilder();
            foreach (var item in dtFun)
            {
                //功能代號
                var cmd = item.EOMF_FunctionCode;
                //刪除鍵另外處理
                if (cmd.equalIgnoreCase("delete"))
                    continue;

                var hasPerm = (funPermSet != null && funPermSet.Keys.Contains(cmd));
                if (isAdmin || hasPerm)
                {
                    sb.AppendFormat("ActionColumn_{0}: {{", cmd.ToLower());
                    sb.AppendLine();
                    sb.AppendFormat("    title: ' ',");
                    sb.AppendLine();
                    sb.AppendFormat("    width: '0.1%',");
                    sb.AppendLine();
                    sb.AppendFormat("    key: false,");
                    sb.AppendLine();
                    sb.AppendFormat("    list: true,");
                    sb.AppendLine();
                    sb.AppendFormat("    create: false,");
                    sb.AppendLine();
                    sb.AppendFormat("    edit: false,");
                    sb.AppendLine();
                    sb.AppendFormat("    listClass: 'jtable-command-column jtable-command-column-{0}',", cmd.ToLower());
                    sb.AppendLine();
                    sb.AppendFormat("    display: function (item) {{ return getItemAction_{0}('{1}', item); }},", funCode, cmd.ToLower());
                    sb.AppendLine();
                    sb.AppendFormat("    sorting: false");
                    sb.AppendLine();
                    sb.AppendFormat("}},");
                    sb.AppendLine();
                }
            }

            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString jTableDeleteAction(this HtmlHelper helper, string funCode, string action, string controller)
        {
            var userFunPermSet = AppUserSession.User.UserFunPermSet;
            var isAdmin = AppUserSession.User.containsPermission(AppPermissionName.APN_APP_SystemAdmin);

            StringBuilder sb = new StringBuilder();
            if (isAdmin)
            {
                sb.AppendFormat(",deleteAction: '/{0}/{1}'", controller, action);
                return MvcHtmlString.Create(sb.ToString());
            }

            if (userFunPermSet.Keys.Contains(funCode))
            {
                var funPermSet = userFunPermSet[funCode];
                if (funPermSet.Keys.Contains("DELETE"))
                {
                    sb.AppendFormat(",deleteAction: '/{0}/{1}'", controller, action);
                }
            }
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString reportPrintMethod(this HtmlHelper helper, string reportId)
        {
            //取得報表定義，是否允許排程
            //var rptDef = SyDataService.Instance.SyReportDefinition_getByReportId(reportId).FirstRow;
            bool allowSchedule = false;
            //if (rptDef != null)
            //    allowSchedule = rptDef.SYRD_AllowScheduling.equalIgnoreCase("Y");

            TagBuilder divBuilder = new TagBuilder("div");
            divBuilder.AddCssClass("inline-block");

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<input type=\"radio\" name=\"ReportPrintMethod\" id=\"ReportPrintMethod_D\" value=\"D\" checked=\"checked\" /><label for=\"ReportPrintMethod_D\">直接下載</label>");

            if (allowSchedule)
            {
                sb.AppendFormat("<input type=\"radio\" name=\"ReportPrintMethod\" id=\"ReportPrintMethod_S\" value=\"S\" /><label for=\"ReportPrintMethod_S\">排程：</label>");
                sb.AppendFormat("<span>日期</span><input type=\"text\" id=\"ReportScheduleDate\" name=\"ReportScheduleDate\" class=\"date\" style=\"width:100px;\" />");

                //小時
                sb.AppendFormat("<select id=\"ReportScheduleHour\" name=\"ReportScheduleHour\">");
                for (int i = 0; i < 24; i++)
                {
                    if (i == 0)
                    {
                        sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i.ToString("00"));
                    }
                    else
                    {
                        sb.AppendFormat("<option value=\"{0}\">{0}</option>", i.ToString("00"));
                    }
                }
                sb.AppendFormat("</select>");
                sb.AppendFormat("<span>時</span>");

                //分鍾
                sb.AppendFormat("<select id=\"ReportScheduleMin\" name=\"ReportScheduleMin\">");
                for (int i = 0; i < 60; i++)
                {
                    if (i == 0)
                    {
                        sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{0}</option>", i.ToString("00"));
                    }
                    else
                    {
                        sb.AppendFormat("<option value=\"{0}\">{0}</option>", i.ToString("00"));
                    }
                }
                sb.AppendFormat("</select>");
                sb.AppendFormat("<span>分</span>");
                //sb.AppendFormat("<span>(不指定表示立即執行)</span>");
            }

            divBuilder.InnerHtml += sb.ToString();
            var result = MvcHtmlString.Create(divBuilder.ToString());
            return result;
        }
    }
}