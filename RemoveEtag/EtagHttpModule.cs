using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;

namespace RemoveEtag
{
	public class EtagHttpModule : IHttpModule
	{
		public void Init(HttpApplication context)
		{
			context.EndRequest += new EventHandler(context_EndRequest);
		}

		private void context_EndRequest(object sender, EventArgs e)
		{
			var context = HttpContext.Current;

			if (Path.GetExtension(context.Request.Url.AbsolutePath) != ".manifest")
			{
				context.Response.Headers.Remove("ETag");
				/*
				TimeSpan cacheDuration = TimeSpan.FromSeconds(44000);
				context.Response.Cache.SetCacheability(HttpCacheability.Public);
				context.Response.Cache.SetExpires(DateTime.Now.Add(cacheDuration));
				context.Response.Cache.SetMaxAge(cacheDuration);
				context.Response.Cache.AppendCacheExtension("must-revalidate, proxy-revalidate");
				 */
			}
		}
		public void Dispose() { }
	}
}
