using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace XamarinQAChallenge
{
	//========================================================================
	/// <summary>
	/// Combined DataSource and Delegate for our UITableView
	/// </summary>
	public class BasicTableViewSource : UITableViewSource
	{
		//---- declare vars
		protected List<BasicTableViewItemGroup> _tableItems;
		protected string _cellIdentifier = "BasicTableViewCell";
		
		public BasicTableViewSource (List<BasicTableViewItemGroup> items)
		{
			this._tableItems = items;
		}

		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override int NumberOfSections (UITableView tableView)
		{
			return this._tableItems.Count;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return this._tableItems[section].Items.Count;
		}

		/// <summary>
		/// Called by the TableView to retrieve the header text for the particular section(group)
		/// </summary>
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return this._tableItems[section].Name;
		}

		/// <summary>
		/// Called by the TableView to retrieve the footer text for the particular section(group)
		/// </summary>
		public override string TitleForFooter (UITableView tableView, int section)
		{
			return this._tableItems[section].Footer;
		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular section and row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			//---- declare vars
			UITableViewCell cell = tableView.DequeueReusableCell (this._cellIdentifier);
			
			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, this._cellIdentifier);
			}
		
			//---- create a shortcut to our item
			BasicTableViewItem item = this._tableItems[indexPath.Section].Items[indexPath.Row];

			cell.TextLabel.Text = item.Movie.title;

			if(!string.IsNullOrEmpty(item.Movie.thumbNail))
			{
				MonoTouch.Foundation.NSUrl nsUrl = new MonoTouch.Foundation.NSUrl(item.Movie.thumbNail);
                MonoTouch.Foundation.NSData data = MonoTouch.Foundation.NSData.FromUrl(nsUrl);
                var myImage = new UIImage(data); 

				cell.ImageView.Image = myImage;
			}

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{  
			BasicTableViewItem item = this._tableItems[indexPath.Section].Items[indexPath.Row];
			Movie movie = item.Movie;

   			 new UIAlertView("Row Selected", movie.title, null, "OK", null).Show();
    		tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		}
	}
	//========================================================================
}
