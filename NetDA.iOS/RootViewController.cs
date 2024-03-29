using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using NetDA.Core;

namespace NetDA.iOS
{
	public partial class RootViewController : UITableViewController
	{
		DataSource<Article> dataSource;
		Monologue Monologue_;

		public RootViewController () : base ("RootViewController", null)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Master", "Master");
			ContentSizeForViewInPopover = new SizeF (320f, 600f);
			ClearsSelectionOnViewWillAppear = false;
			
			// Custom initialization
		}

		public DetailViewController DetailViewController {
			get;
			set;
		}

//		void AddNewItem (object sender, EventArgs args)
//		{
//			dataSource.Objects.Insert (0, DateTime.Now);
//
//			using (var indexPath = NSIndexPath.FromRowSection (0, 0))
//				TableView.InsertRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
//		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

//			// Perform any additional setup after loading the view, typically from a nib.
//			NavigationItem.LeftBarButtonItem = EditButtonItem;

//			var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add, AddNewItem);
//			NavigationItem.RightBarButtonItem = addButton;

			Monologue_ = new Monologue ();

			Monologue_.ArticlesLoaded += () => InvokeOnMainThread(() => TableView.ReloadData());
			TableView.Source = dataSource = new DataSource<Article> (this, Monologue_.Articles, (a) => a.Title, (a) => a.Url);

			Monologue_.Initialize ();
		}

		[Obsolete ("Deprecated in iOS6. Replace it with both GetSupportedInterfaceOrientations and PreferredInterfaceOrientationForPresentation")]
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			return true;
		}

//		class DataSource : UITableViewSource
//		{
//			static readonly NSString CellIdentifier = new NSString ("DataSourceCell");
//			List<object> objects = new List<object> ();
//			RootViewController controller;
//
//			public DataSource (RootViewController controller)
//			{
//				this.controller = controller;
//			}
//
//			public IList<object> Objects {
//				get { return objects; }
//			}
//
//			// Customize the number of sections in the table view.
//			public override int NumberOfSections (UITableView tableView)
//			{
//				return 1;
//			}
//
//			public override int RowsInSection (UITableView tableview, int section)
//			{
//				return objects.Count;
//			}
//
//			// Customize the appearance of table view cells.
//			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
//			{
//				var cell = tableView.DequeueReusableCell (CellIdentifier);
//				if (cell == null)
//					cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
//
//				cell.TextLabel.Text = objects [indexPath.Row].ToString ();
//
//				return cell;
//			}
//
//			public override bool CanEditRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
//			{
//				// Return false if you do not want the specified item to be editable.
//				return true;
//			}
//
//			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
//			{
//				if (editingStyle == UITableViewCellEditingStyle.Delete) {
//					// Delete the row from the data source.
//					objects.RemoveAt (indexPath.Row);
//					controller.TableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
//				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
//					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
//				}
//			}
//
//			/*
//			// Override to support rearranging the table view.
//			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
//			{
//			}
//			*/
//
//			/*
//			// Override to support conditional rearranging of the table view.
//			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
//			{
//				// Return false if you do not want the item to be re-orderable.
//				return true;
//			}
//			*/
//
//			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
//			{
//				controller.DetailViewController.SetDetailItem (objects [indexPath.Row]);
//			}
//		}
	}
}

