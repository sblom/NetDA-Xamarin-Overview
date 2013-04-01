using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;

namespace NetDA.Core
{
	public class Monologue
	{
		public delegate void ArticlesLoadedHandler();
		public event ArticlesLoadedHandler ArticlesLoaded;
		public ObservableCollection<Article> Articles {get;set;}

		public Monologue ()
		{
			Articles = new ObservableCollection<Article> ();
		}

		public void Initialize() {
			var wc = new WebClient();
			wc.OpenReadCompleted += HandleOpenReadCompleted;
			wc.OpenReadAsync (new Uri("http://go-mono.com/monologue/index.rss"));
		}

		public void HandleOpenReadCompleted (object sender, OpenReadCompletedEventArgs e)
		{
			string title;
			string link;

			using (var result = e.Result)
			using (var xr = XmlReader.Create(result)) {
				while (xr.Read()) {
					if (xr.IsStartElement ()) {
						if (xr.Name == "item") {
							xr.ReadToDescendant ("title");
							title = xr.ReadString ();
							xr.ReadToNextSibling ("link");
							link = xr.ReadString ();
							Articles.Add (new Article (title, link));
						}
					}
				}
			}
			if (ArticlesLoaded != null) {
				ArticlesLoaded();
			}
		}


	}
}
