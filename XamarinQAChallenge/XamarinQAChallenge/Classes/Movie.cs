using System;
using System.Collections;

namespace XamarinQAChallenge
{
	/// <summary>
	/// Represents a Movie that is instantiated from a REST response resulting from calling the RottenTomatoesAPI using a given URL
	/// </summary>
	public class Movie
	{
		public string Title{get; set;}
		public string ThumbNail {get; set;}
		public string FanIndicator {get; set;}
		public string CriticScore {get; set;}
		public ArrayList CompleteCast {get; set;}
		public string AbridgedActors {get; set;}
		public string MPAA {get; set;}
		public string RunTime {get; set;}
		public string ReleaseDate {get; set;}
		public string Synopsis {get; set;}
		public string CriticReview {get; set;}
		public string CriticIndicator {get; set;}

		public Movie ()
		{

		}

		public Movie (string titl, string thmb, string fn, string crtscr, ArrayList cmpCst, string mpa, string rntm, string relsdt, string synpsis, string crtrvw, string crtindctr)
		{
			this.Title = titl;
			this.ThumbNail = thmb;
			this.CriticScore = crtscr;
			this.CompleteCast = cmpCst;

			//Create an abridged list of actors for each TableView Item
			switch (cmpCst.Count) 
			{
				case 0:
					this.AbridgedActors = "No Actors Specified";
					break;
				case 1:
					this.AbridgedActors = CompleteCast[0].ToString();
					break;
				default:
					this.AbridgedActors = CompleteCast[0].ToString() + " , " + CompleteCast[1].ToString();
					break;
			}

			this.MPAA = mpa;
			this.FanIndicator = fn;

			//Format the time, which was given in minutes, into hrs. min. format
			if (rntm != String.Empty) 
			{

				TimeSpan t = TimeSpan.FromMinutes (double.Parse (rntm));

				string formattedTime = string.Format ("{0:D2}hr. {1:D2}min.", 
                        t.Hours, 
                        t.Minutes);

				this.RunTime = formattedTime;
			} 
			else 
			{
				this.RunTime = "00hr. 00min.";
			}

			this.ReleaseDate = relsdt;
			this.Synopsis = synpsis;
			this.CriticReview = crtrvw;
			this.CriticIndicator = crtindctr;
		}

		public void Print()
		{
			Console.WriteLine ("Title:" + this.Title + ", Thumbnail:" + this.ThumbNail + ", Fan Indicator:" + this.FanIndicator + 
			                   ", CriticScore:" + this.CriticScore + ", CriticReview:" + this.CriticReview + ", Critic Indicator:" +
			                   this.CriticIndicator + ", MPAA:" + this.MPAA + ", RunTime:" + this.RunTime  + ", ReleaseDate:" + 
			                   this.ReleaseDate + ", Synopsis:" + this.Synopsis);
		}
	}
}

