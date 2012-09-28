// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace XamarinQAChallenge
{
	[Register ("CustomCell")]
	partial class CustomCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel title { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView Image { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel actors { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CriticScore { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel Indicator { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel mpaa { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel runtime { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableViewCell MyCustomTableCellView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (title != null) {
				title.Dispose ();
				title = null;
			}

			if (Image != null) {
				Image.Dispose ();
				Image = null;
			}

			if (actors != null) {
				actors.Dispose ();
				actors = null;
			}

			if (CriticScore != null) {
				CriticScore.Dispose ();
				CriticScore = null;
			}

			if (Indicator != null) {
				Indicator.Dispose ();
				Indicator = null;
			}

			if (mpaa != null) {
				mpaa.Dispose ();
				mpaa = null;
			}

			if (runtime != null) {
				runtime.Dispose ();
				runtime = null;
			}

			if (MyCustomTableCellView != null) {
				MyCustomTableCellView.Dispose ();
				MyCustomTableCellView = null;
			}
		}
	}
}
