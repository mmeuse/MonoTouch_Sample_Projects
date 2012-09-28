using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace XamarinQAChallenge
{
	//View Controller for the main application screen that displays a grouped listing of movies retrieved using the rottenTomatoes API
	public partial class BoxOfficeScreen : UIViewController
	{
		public 	ArrayList TopBoxOfficeMovies = new ArrayList();
		public ArrayList OpeningThisWeekMovies = new ArrayList();
		public ArrayList AlsoInTheatersMovies = new ArrayList();
		public CustomTableViewSource tableViewSource;

		//Default Constructor
		public BoxOfficeScreen () : base ("BoxOfficeScreen", null)
		{
			this.Title = "Box Office - Rotten Tomatoes";
			this.BoxOfficeTable = new UITableView();

			//Add the TableView to the Page
			Add (BoxOfficeTable);

			//Populate the Table View
			PopulateTableView();
		}

		private void PopulateTableView ()
		{
			//Get a collection of the different Movie Groups
			TopBoxOfficeMovies = GetMoviesByURL(@"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey=z3ypr66hg9c46kwrbxk3uwmr");
			OpeningThisWeekMovies  = GetMoviesByURL(@"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/opening.json?apikey=z3ypr66hg9c46kwrbxk3uwmr");
			AlsoInTheatersMovies = GetMoviesByURL(@"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?apikey=z3ypr66hg9c46kwrbxk3uwmr");

			//Instantiate the UITableViewSource with the different collections of movie groups, and set the Source property on the table.
			CreateTableItems();
            BoxOfficeTable.Source = tableViewSource;
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Add a Refresh button to the UINavigation element
			NavigationItem.RightBarButtonItem = new UIBarButtonItem("Refresh",UIBarButtonItemStyle.Plain,OnRefresh);
		}

		//Repopulate the TableView when Refresh is clicked
		public void OnRefresh (Object o, EventArgs args)
		{
			InvokeOnMainThread(delegate{	
				this.BoxOfficeTable = new UITableView();
				PopulateTableView();
			});
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		/// <summary>
		/// Retrieve all Movies from RottenTomatoes API
		/// </summary>
		/// <returns>
		/// The movies by URL
		/// </returns>
		/// <param name='URL'>
		/// Input REST URL for a given category
		/// </param>
		public ArrayList GetMoviesByURL (string URL)
		{
			string allMoviesUrl = URL;
			ArrayList movieCollection = new ArrayList();
			var client = new RestClient ();
			var request = new RestRequest (allMoviesUrl);
			request.RequestFormat = DataFormat.Json;

			var response = client.Execute (request);
			var content = response.Content; // raw content as string

			//Request a Json Object for the given URL
			JObject o = JObject.Parse(content);

			//Use Linq to deserialize the Json and to populate a list of movies
			var movies =
 			from p in o["movies"].Children()
 			select new 
			{ 
				Title = p["title"],
				ThumbNail = p["posters"]["thumbnail"],
				FanIndicator = p["ratings"]["audience_rating"],
				CriticScore = p["ratings"]["critics_score"],
				CompleteCast = p["abridged_cast"],
				MPAA = p["mpaa_rating"],
				RunTime = p["runtime"],
				ReleaseDate = p["release_dates"]["theater"],
				Synopsis = p["synopsis"],
				CriticReview = p["critics_consensus"],
				CriticIndicator = p["ratings"]["critics_rating"]
			};

			foreach (var m in movies) 
			{	
				ArrayList actorList = new ArrayList();

				var actors =
 				from p in m.CompleteCast.Children ()
				select new { Name = p["name"]};

				foreach(var actor in actors)
				{
					string actorName = actor.Name.ToString();

					//Add an Actor to a collection of actors for the current movie
					if(actorName != null && actorName != String.Empty)
						actorList.Add(actorName);
				}

				//Check to see if values are null and set them accordingly
				string title = m.Title != null ? m.Title.ToString() : String.Empty;
				string thumbNail = m.ThumbNail != null ? m.ThumbNail.ToString() : String.Empty;
				string fanIndicator = m.FanIndicator != null ? m.FanIndicator.ToString() : String.Empty;
				string criticScore = m.CriticScore != null ? m.CriticScore.ToString() : String.Empty;
				string mpaa = m.MPAA != null ? m.MPAA.ToString() : String.Empty;
				string runTime = m.RunTime != null ? m .RunTime.ToString() : String.Empty;
				string releaseDate = m.ReleaseDate != null ? m.ReleaseDate.ToString() : String.Empty;
				string synopsis = m.Synopsis != null ? m.Synopsis.ToString() : String.Empty;
				string criticRevew = m.CriticReview != null ? m.CriticReview.ToString() : String.Empty;
				string criticIndicator = m.CriticIndicator != null ? m.CriticIndicator.ToString() : String.Empty;

				//With the movie values parsed from the Json response, instantiate a new movie object and add it to a collection
				movieCollection.Add(new Movie(title,thumbNail,fanIndicator,criticScore,actorList,mpaa,runTime,releaseDate,synopsis,criticRevew,criticIndicator));
			}

			return movieCollection;
		}

		/// <summary>
		/// Creates a TableViewSource containing the three collections listed in the specification
		/// </summary>
		public void CreateTableItems ()
		{
			List<BasicTableViewItemGroup> tableItems = new List<BasicTableViewItemGroup> ();
			BasicTableViewItemGroup tGroup;

			//Create Group
			tGroup = new BasicTableViewItemGroup() { Name = "Top Box Office"};

			foreach (Movie m in this.TopBoxOfficeMovies) 
			{
				//Add movies to Group
				tGroup.Items.Add (new BasicTableViewItem() { Movie = m});
			}

			//Add the Group to the TableView
			tableItems.Add (tGroup);
			tGroup = new BasicTableViewItemGroup() { Name = "Opening This Week"};
	

			foreach (Movie m in this.OpeningThisWeekMovies) 
			{
				tGroup.Items.Add (new BasicTableViewItem() { Movie = m});
			}

			tableItems.Add (tGroup);
			tGroup = new BasicTableViewItemGroup() { Name = "Also In Theaters"};

			foreach (Movie m in this.AlsoInTheatersMovies) 
			{
				tGroup.Items.Add (new BasicTableViewItem() { Movie = m});
			}

			tableItems.Add (tGroup);
			this.tableViewSource = new CustomTableViewSource(tableItems);
		}
	}
}

