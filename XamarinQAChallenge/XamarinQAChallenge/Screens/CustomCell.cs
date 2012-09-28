using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XamarinQAChallenge
{
	//Controller Class for the Custom Cell View (nib) used to define a movie in the Box Office Screens main table view
	public partial class CustomCell : UIViewController
	{
		public UITableViewCell Cell
		{
			get { return this.MyCustomTableCellView; }
		}

		public string _CriticScore
		{
			get { return this.CriticScore.Text; }
			set { this.CriticScore.Text = value; }
		}

		public string _Title
		{
			get { return this.title.Text; }
			set { this.title.Text = value; }
		}

		public UIImageView _Thumbnail
		{
			get { return this.Image; }
			set { this.Image = value; }
		}

		public string _Indicator
		{
			get { return this.Indicator.Text; }
			set { this.Indicator.Text = value; }
		}

		public string _Actors
		{
			get { return this.actors.Text; }
			set { this.actors.Text = value; }
		}

		public string _Mpaa
		{
			get { return this.mpaa.Text; }
			set { this.mpaa.Text = value; }
		}

		public string _RunTime
		{
			get { return this.runtime.Text; }
			set { this.runtime.Text = value; }
		}

		public CustomCell ()
		{
			MonoTouch.Foundation.NSBundle.MainBundle.LoadNib ("CustomCell", this, null);
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

