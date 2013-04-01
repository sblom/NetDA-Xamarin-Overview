using System;
using System.Collections.ObjectModel;
using MonoTouch.UIKit;

namespace NetDA.iOS
{
	public class DataSource<T>: UITableViewSource
	{
		private ObservableCollection<T> List_;
		private RootViewController Controller_;
		private Func<T, string> TitleSelector_;
		private Func<T, string> LinkSelector_;

		public DataSource(RootViewController controller, ObservableCollection<T> list, Func<T,string> titleSelector, Func<T,string> linkSelector)
		{
			List_ = list;
			Controller_ = controller;
			TitleSelector_ = titleSelector;
			LinkSelector_ = linkSelector;
		}

		#region implemented abstract members of UITableViewSource

		public override int RowsInSection (UITableView tableview, int section)
		{
			return List_.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell ("DataSourceCell") ?? new UITableViewCell();
			cell.TextLabel.Text = TitleSelector_ (List_ [indexPath.Row]);
			return cell;
		}

		#endregion

		public override void RowSelected (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			Controller_.DetailViewController.SetDetailItem (LinkSelector_ (List_[indexPath.Row]));
		}
	}
}

