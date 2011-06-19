using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

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
			context.Response.Headers.Remove("ETag");
		}
		public void Dispose() { }
	}
}
