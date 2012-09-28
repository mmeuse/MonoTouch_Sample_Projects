// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace XamarinQAChallenge
{
	[Register ("BoxOfficeScreen")]
	partial class BoxOfficeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UITableView BoxOfficeTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BoxOfficeTable != null) {
				BoxOfficeTable.Dispose ();
				BoxOfficeTable = null;
			}
		}
	}
}
