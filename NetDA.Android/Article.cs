using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace NetDA.Android
{
  [Activity(Label = "My Activity")]
  public class Article : Activity
  {
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);
      SetContentView(Android.Resource.Layout.Article);
      WebView web = (WebView)FindViewById(Android.Resource.Id.webView);
      web.Settings.JavaScriptEnabled = true;
      web.LoadUrl(this.Intent.GetStringExtra("link"));

      // Create your application here
    }
  }
}