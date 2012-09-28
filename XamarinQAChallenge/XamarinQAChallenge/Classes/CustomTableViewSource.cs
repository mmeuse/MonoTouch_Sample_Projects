using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace XamarinQAChallenge
{
	//========================================================================
	/// <summary>
	/// Combined DataSource and Delegate for our UITableView with custom cells
	/// </summary>
	public class CustomTableViewSource : UITableViewSource
	{
		//---- declare vars
		protected List<BasicTableViewItemGroup> _tableItems;
		protected string _customCellIdentifier = "MyCustomTableCellView";
		protected Dictionary<int, CustomCell> _cellControllers = 
			new Dictionary<int, CustomCell>();
		
		public CustomTableViewSource (List<BasicTableViewItemGroup> items)
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
		/// Called by the TableView to retreive the height of the row for the particular section and row
		/// </summary>
		public override float GetHeightForRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			return 130f;
		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular section and row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			//---- declare vars
			UITableViewCell cell = tableView.DequeueReusableCell (this._customCellIdentifier);
			CustomCell customCellController = null;
			
			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				customCellController = new CustomCell ();
				// retreive the cell from our custom cell controller
				cell = customCellController.Cell;
				// give the cell a unique ID, so we can match it up to the controller
				cell.Tag = Environment.TickCount;
				// store our controller with the unique ID we gave our cell
				this._cellControllers.Add (cell.Tag, customCellController);
			}
			else
			{
				// retreive our controller via it's unique ID
				customCellController = this._cellControllers[cell.Tag];
			}
			
			//---- create a shortcut to our item
			BasicTableViewItem item = this._tableItems[indexPath.Section].Items[indexPath.Row];
			
			//---- set our cell properties
			customCellController._CriticScore = item.Movie.CriticScore;
			customCellController._Title = item.Movie.Title;
			customCellController._Indicator = item.Movie.FanIndicator;
			customCellController._Mpaa = item.Movie.MPAA;
			customCellController._RunTime = item.Movie.RunTime;
			customCellController._Actors = item.Movie.AbridgedActors;

			if(!string.IsNullOrEmpty(item.Movie.ThumbNail))
			{
				MonoTouch.Foundation.NSUrl nsUrl = new MonoTouch.Foundation.NSUrl(item.Movie.ThumbNail);
                MonoTouch.Foundation.NSData data = MonoTouch.Foundation.NSData.FromUrl(nsUrl);
                var myImage = new UIImage(data); 

				customCellController._Thumbnail.Image = myImage;
			}

			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{  
			BasicTableViewItem item = this._tableItems[indexPath.Section].Items[indexPath.Row];
			Movie movie = item.Movie;
    	
			//Launch the Individual Movie Screen with the selected movie
			IndividualMovieView movieScreen = new IndividualMovieView(movie);
			AppDelegate.rootNavigationController.PushViewController(movieScreen,true);

			tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight
		}
	}
}