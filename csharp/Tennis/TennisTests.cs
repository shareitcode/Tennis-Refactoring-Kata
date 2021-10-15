using System;
using Xunit;

namespace Tennis
{
	public class TennisTests
	{
		[Theory]
		[ClassData(typeof(TestDataGenerator))]
		public void Tennis1Test(int p1, int p2, string expected)
		{
			var game = new TennisGame1("player1", "player2");
			CheckAllScores(game, p1, p2, expected);
		}

		[Theory]
		[ClassData(typeof(TestDataGenerator))]
		public void Tennis2Test(int p1, int p2, string expected)
		{
			var game = new TennisGame2("player1", "player2");
			CheckAllScores(game, p1, p2, expected);
		}

		[Theory]
		[ClassData(typeof(TestDataGenerator))]
		public void Tennis3Test(int p1, int p2, string expected)
		{
			var game = new TennisGame3("player1", "player2");
			CheckAllScores(game, p1, p2, expected);
		}

		private void CheckAllScores(ITennisGame game, int player1Score, int player2Score, string expectedScore)
		{
			var highestScore = Math.Max(player1Score, player2Score);
			for (var i = 0; i < highestScore; i++)
			{
				if (i < player1Score)
					game.WonPoint("player1");
				if (i < player2Score)
					game.WonPoint("player2");
			}

			Assert.Equal(expectedScore, game.GetScore());
		}
	}
}