using System;

namespace NetDA.Core
{
	public class Article
	{
		public string Title { get; private set; }
		public string Url { get; private set; }

		public Article (string title, string url)
		{
			Title = title;
			Url = url;
		}
	}
}

