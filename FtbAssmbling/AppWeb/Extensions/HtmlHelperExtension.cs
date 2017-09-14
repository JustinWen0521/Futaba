using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static partial class htmlHelper
    {
        //Extension
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression, MultiSelectList allOptions, object htmlAttributes = null)
        {
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, IEnumerable<TProperty>>(expression, htmlHelper.ViewData);

            // Derive property name for checkbox name
            string propertyName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);

            // Get currently select values from the ViewData model
            IEnumerable<TProperty> list = expression.Compile().Invoke(htmlHelper.ViewData.Model);

            // Convert selected value list to a List<string> for easy manipulation
            IList<string> selectedValues = new List<string>();

            if (list != null)
            {
                selectedValues = new List<TProperty>(list).ConvertAll<string>(delegate(TProperty i) { return i.ToString(); });
            }

            // Create div
            TagBuilder divTag = new TagBuilder("div");
            divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            // Add checkboxes
            foreach (SelectListItem item in allOptions)
            {
                divTag.InnerHtml += string.Format(
                                                  "<div><input type=\"checkbox\" onclick=\"OnCheck('{0}_{2}','{0}');\" name=\"{0}_{2}\" id=\"{1}_{2}\" " +
                                                  "value=\"{2}\" {3} /><label for=\"{1}_{2}\">{4}</label></div>"
                                                  + "<input type='hidden' name='{0}' id='{0}' value='{5}' />" //August
                                                  ,
                                                  propertyName,
                                                  TagBuilder.CreateSanitizedId(propertyName),
                                                  item.Value,
                                                  selectedValues.Contains(item.Value) ? "checked=\"checked\"" : string.Empty,
                                                  item.Text,
                                                  selectedValues.FirstOrDefault().nullAs("N")
                                                  );
            }

            return MvcHtmlString.Create(divTag.ToString());
        }

        public static MvcHtmlString CheckboxListFor2<TModel, TProperty>(
                    this HtmlHelper<TModel> htmlHelper,
                    Expression<Func<TModel, TProperty>> expression,
                    MultiSelectList listOfValues)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var sb = new StringBuilder();

            if (listOfValues != null)
            {
                for (int i = 0; i < listOfValues.Count(); i++)//foreach (var item in listOfValues)
                {
                    var item = listOfValues.ElementAt(i);
                    var id = string.Format("{0}_{1}", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression)), item.Value);
                    var name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));
                    var label = htmlHelper.Label(id, HttpUtility.HtmlEncode(item.Text));

                    var cb = new TagBuilder("input");
                    cb.MergeAttribute("type", "checkbox");
                    cb.MergeAttribute("name", name);
                    cb.MergeAttribute("value", @item.Value);
                    cb.MergeAttribute("id", id);
                    if (item.Selected)
                    {
                        cb.MergeAttribute("checked", "checked");
                    }
                    sb.AppendFormat("{0}{1}</br>", cb, label);
                }
            }
            return MvcHtmlString.Create(sb.ToString());
        }


        public static MvcHtmlString CheckBoxListMenu(ftd.data.FtdXmlMenuNode menu, object htmlAttributes = null)
        {
            // Create div
            TagBuilder divTag = new TagBuilder("div");
            divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

            // Add checkboxes
            foreach (var dr in menu.ChildNodes)
            {
                divTag.InnerHtml += string.Format(
                                  "<div><input type=\"checkbox\"  name=\"{0}_{2}\" id=\"{1}_{2}\" " +
                                  "value=\"{6}\" {3} /><label for=\"{1}_{2}\">{4}</label></div>",
                                  "itemNo",
                                  TagBuilder.CreateSanitizedId("itemNo"),
                                  dr.Attributes["itemNo"].Replace(".", ""),
                                  dr.Attributes["Checked"] == "true" ? "checked=\"checked\"" : string.Empty,
                                  dr.Attributes["title"],
                                  dr.Attributes["Checked"] == "true" ? "Y" : "N",
                                  dr.Attributes["itemNo"]
                                  );
            }
            return MvcHtmlString.Create(divTag.ToString());
        }

        public static MvcHtmlString CodeQuery(string ValueField, string NameField, string FunctionName, int width = 800, int height = 600, object htmlAttributes = null, bool clear = true, string butname = "...")
        {
            // Create div
            TagBuilder divTag = new TagBuilder("span");
            divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            if (clear)
            {
                divTag.InnerHtml += string.Format(

                                                  "<input type='button' value='" + butname + "'  onclick=\"" + FunctionName + "('" + ValueField + "', '" + NameField + "', " + width + ", " + height + ");\" />" +
                                                  "<input type='button' value='清除' onclick=\"ClearField('" + ValueField + "','" + NameField + "');\" />"
                                                  );
            }
            else
                divTag.InnerHtml += string.Format(
                                  "<input type='button' value='" + butname + "'  onclick=\"" + FunctionName + "('" + ValueField + "', '" + NameField + "', " + width + ", " + height + ");\" />");

            return MvcHtmlString.Create(divTag.ToString());
        }

        //public static MvcHtmlString CodeQuery2(string ValueField, string NameField, string FunctionName, string Kind, int width = 800, int height = 600, object htmlAttributes = null)
        //{
        //    // Create div
        //    TagBuilder divTag = new TagBuilder("span");
        //    divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

        //    divTag.InnerHtml += string.Format(
        //                                      "<input type='button' value='...'  onclick=\"" + FunctionName + "('" + ValueField + "', '" + NameField + "', " + width + ", " + height + ", '" + Kind + "');\" />" +
        //                                      "<input type='button' value='清除' onclick=\"ClearField('" + ValueField + "','" + NameField + "');\" />"
        //                                      );
        //    return MvcHtmlString.Create(divTag.ToString());
        //}

        //public static MvcHtmlString CodeQuery<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TProperty>>> expression,string ValueField, string FunctionName, int width = 800, int height = 600, object htmlAttributes = null)
        //{
        //    ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<TModel, IEnumerable<TProperty>>(expression, htmlHelper.ViewData);

        //    // Derive property name for checkbox name
        //    string propertyName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(modelMetadata.PropertyName);

        //    // Get currently select values from the ViewData model
        //    IEnumerable<TProperty> list = expression.Compile().Invoke(htmlHelper.ViewData.Model);

        //    // Convert selected value list to a List<string> for easy manipulation
        //    IList<string> selectedValues = new List<string>();

        //    if (list != null)
        //    {
        //        selectedValues = new List<TProperty>(list).ConvertAll<string>(delegate(TProperty i) { return i.ToString(); });
        //    }
        //    // Create div
        //    TagBuilder divTag = new TagBuilder("span");
        //    divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);

        //    divTag.InnerHtml += string.Format(
        //                                      "<input type='text' id='"+propertyName+"' name='"+propertyName+"'>"+
        //                                      "<input type='button' value='...'  onclick=\"" + FunctionName + "('" + ValueField + "', '" + propertyName + "', " + width + ", " + height + ");\" />" +
        //                                      "<input type='button' value='清除' onclick=\"ClearField('" + ValueField + "','" + propertyName + "');\" />"
        //                                      );
        //    return MvcHtmlString.Create(divTag.ToString());
        //}

        //public static MvcHtmlString DropDownListForQ(string Name, IEnumerable<SelectListItem> list, object htmlAttributes = null)
        //{
        //    // Create div
        //    TagBuilder divTag = new TagBuilder("span");
        //    divTag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
        //    var required = false;
        //    var title="";
        //    var attr = new RouteValueDictionary(htmlAttributes);
        //    var req = attr.Where(t => t.Key.ToLower() == "required").FirstOrDefault();
        //    if (!req.Key.isNull())
        //    {
        //        required = true;
        //        var titl = attr.Where(t => t.Key.ToLower() == "title").FirstOrDefault();
        //        if (!titl.Key.isNull())
        //            title = titl.Value.ToString();
        //    }
        //    divTag.InnerHtml += "<select type=\"select\" " + (required == true ? "required='required' title='" + title +"'": "") + " name=\"" + Name + "\">";
        //    foreach (var dr in list)
        //    {
        //        divTag.InnerHtml += string.Format("<option value='{0}'>{1}</option>", dr.Value, dr.Text);
        //    }
        //    divTag.InnerHtml += "</select>";
        //    return MvcHtmlString.Create(divTag.ToString());
        //}
    }
}