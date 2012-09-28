
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace XamarinQAChallenge
{
	//This View Controller and Corresponding View (nib) display an individual movie selected in the Box Office Screen Table View
	public partial class IndividualMovieView : UIViewController
	{
		public Movie movie;

		//Default Constructor
		public IndividualMovieView ()
		{
			movie = new Movie();
			this.Cast = new UITextView();
			this.Mpaa = new UILabel();
			this.RunningTime = new UILabel();
			this.ReleaseDate = new UILabel();
			this.Synopsis = new UITextView();
			this.RottenIndicator = new UILabel();
			this.CriticReview = new UITextView();
		}

		//Overloaded Constructor that accepts a Movie object as an input parameter
		public IndividualMovieView (Movie mov)
		{
			movie = mov;
			this.Cast = new UITextView();
			this.Mpaa = new UILabel();
			this.RunningTime = new UILabel();
			this.ReleaseDate = new UILabel();
			this.Synopsis = new UITextView();
			this.RottenIndicator = new UILabel();
			this.CriticReview = new UITextView();
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		//When the view is loaded, populate the corresponding UI elements with the Movie object
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			string actors = String.Empty;

			foreach (string actor in movie.CompleteCast) 
			{
				actors += actor + ", ";
			}

			this.Cast.Text = actors.TrimEnd(',');
			this.Mpaa.Text = movie.MPAA;
			this.RunningTime.Text = movie.RunTime;
			this.ReleaseDate.Text = movie.ReleaseDate;
			this.Synopsis.Text = movie.Synopsis;
			this.RottenIndicator.Text = movie.CriticIndicator;
			this.CriticReview.Text = movie.CriticReview;
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

