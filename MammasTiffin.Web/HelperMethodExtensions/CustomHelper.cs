using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MammasTiffin.Web.CustomHelpers
{
    public static class CustomHelper
    {
        public static MvcHtmlString CusButton(this HtmlHelper helper, string btnName, string btnText, bool isSubmit, object htmlAttributes = null)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var btntype = isSubmit ? "submit" : "button";
            var builder = new TagBuilder("input");
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(attributes);
            }
            builder.Attributes.Add("type", btntype);
            builder.Attributes.Add("value", btnText);
            builder.Attributes.Add("name", btnName);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString CusFileUploadFor<inpT, outT>(this HtmlHelper<inpT> helper, Expression<Func<inpT, outT>> exp,object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(exp);
            ModelMetadata modelMetadata = ModelMetadata.FromLambdaExpression<inpT, outT>(exp, helper.ViewData);
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            var builder = new TagBuilder("input");
            if (htmlAttributes != null)
            {
                builder.MergeAttributes(attributes);
            }
            builder.MergeAttributes<string, object>(helper.GetUnobtrusiveValidationAttributes(name, modelMetadata));
            builder.Attributes.Add("type", "file");
            builder.Attributes.Add("name", name);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }

    }
}