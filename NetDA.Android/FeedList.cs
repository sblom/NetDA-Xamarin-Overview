using System;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using NetDA.Core;

namespace NetDA.Android
{
  [Activity(Label = "NetDA.Android", MainLauncher = true, Icon = "@drawable/icon")]
  public class FeedList : ListActivity
  {
    private Monologue Monologue_;
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Set our view from the "main" layout resource
      //SetContentView(Resource.Layout.Main);

      Monologue_ = new Monologue();
      Monologue_.ArticlesLoaded += () => RunOnUiThread(MonologueOnArticlesLoaded);
      Monologue_.Initialize();
    }

    private void MonologueOnArticlesLoaded()
    {
      var articles = Monologue_.Articles.Select(a => a.Title).ToArray();
      ListAdapter = new ArrayAdapter(this, global::Android.Resource.Layout.SimpleListItem1, articles);
    }
  }
}

