using System;
using System.Collections.Generic;

namespace XamarinQAChallenge
{
	//========================================================================
	/// <summary>
	/// A group that contains table items
	/// </summary>
	public class BasicTableViewItemGroup
	{
		public string Name { get; set; }

		public string Footer { get; set; }
		
		public List<BasicTableViewItem> Items
		{
			get { return this._items; }
			set { this._items = value; }
		}
		protected List<BasicTableViewItem> _items = new List<BasicTableViewItem>();
		
		public BasicTableViewItemGroup ()
		{
		}
	}
	//========================================================================
}
