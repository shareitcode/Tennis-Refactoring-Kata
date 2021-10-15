using System;

namespace Tennis
{
	class TennisGame1 : ITennisGame
	{
		private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;
		private string player1Name;
		private string player2Name;

		public TennisGame1(string player1Name, string player2Name)
		{
			this.player1Name = player1Name;
			this.player2Name = player2Name;
		}

		public void WonPoint(string playerName)
		{
			if (playerName == this.player1Name)
				this.scorePlayer1 += 1;
			else
				this.scorePlayer2 += 1;
		}

		public string GetScore()
		{
			if (this.IsDraw())
			{
				return this.Draw();
			}

			int scoreDelta = Math.Abs(this.scorePlayer1 - this.scorePlayer2);

			if (this.IsAdvantage(scoreDelta))
			{
				return this.Advantage();
			}

			if (this.IsWin(scoreDelta))
			{
				return this.Win();
			}

			return this.IncrementScore();
		}

		private bool IsDraw()
		{
			return this.scorePlayer1 == this.scorePlayer2;
		}

		private string Draw()
		{
			return this.scorePlayer1 switch
			{
				0 => "Love-All",
				1 => "Fifteen-All",
				2 => "Thirty-All",
				_ => "Deuce"
			};
		}

		private bool IsAdvantage(int scoreDelta)
		{
			return (this.scorePlayer1 >= 4 || this.scorePlayer2 >= 4) && scoreDelta is 1 or -1;
		}

		private string Advantage()
		{
			string score;
			if (this.scorePlayer1 > this.scorePlayer2)
			{
				score = "Advantage player1";
			}
			else
			{
				score = "Advantage player2";
			}

			return score;
		}

		private bool IsWin(int scoreDelta)
		{
			return (this.scorePlayer1 >= 4 || this.scorePlayer2 >= 4) && scoreDelta >= 2;
		}

		private string Win()
		{
			string score;
			if (this.scorePlayer1 > this.scorePlayer2)
			{
				score = "Win for player1";
			}
			else
			{
				score = "Win for player2";
			}

			return score;
		}

		private string IncrementScore()
		{
			return $"{this.BuildScore(this.scorePlayer1)}-{this.BuildScore(this.scorePlayer2)}";
		}

		private string BuildScore(int playerScore)
		{
			var score = string.Empty;
			switch (playerScore)
			{
				case 0:
					score += "Love";
					break;
				case 1:
					score += "Fifteen";
					break;
				case 2:
					score += "Thirty";
					break;
				case 3:
					score += "Forty";
					break;
			}
			return score;
		}
	}
}