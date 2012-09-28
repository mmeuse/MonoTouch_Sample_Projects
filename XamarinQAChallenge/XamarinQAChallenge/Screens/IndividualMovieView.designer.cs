// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace XamarinQAChallenge
{
	[Register ("IndividualMovieView")]
	partial class IndividualMovieView
	{
		[Outlet]
		MonoTouch.UIKit.UITextView Cast { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel Mpaa { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel RunningTime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ReleaseDate { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView Synopsis { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel RottenIndicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView CriticReview { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel Director { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Cast != null) {
				Cast.Dispose ();
				Cast = null;
			}

			if (Mpaa != null) {
				Mpaa.Dispose ();
				Mpaa = null;
			}

			if (RunningTime != null) {
				RunningTime.Dispose ();
				RunningTime = null;
			}

			if (ReleaseDate != null) {
				ReleaseDate.Dispose ();
				ReleaseDate = null;
			}

			if (Synopsis != null) {
				Synopsis.Dispose ();
				Synopsis = null;
			}

			if (RottenIndicator != null) {
				RottenIndicator.Dispose ();
				RottenIndicator = null;
			}

			if (CriticReview != null) {
				CriticReview.Dispose ();
				CriticReview = null;
			}

			if (Director != null) {
				Director.Dispose ();
				Director = null;
			}
		}
	}
}
