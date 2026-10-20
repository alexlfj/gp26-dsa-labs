using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA.Lab00
{
    public sealed class PlayerCollection
    {
        private readonly List<Player> _players;

        public PlayerCollection(IEnumerable<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            _players = new List<Player>(players);
        }

        public Player? FindById(int id)
        {
            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public Player? FindHighestScore()
        {

            if (_players.Count != 0)
            {
                Player highestScorePlayer = _players[0];

                for (int i = 1; i < _players.Count; i++)
                {
                    if (_players[i].Score > highestScorePlayer.Score)
                    {
                        highestScorePlayer = _players[i];
                    }
                }

                return highestScorePlayer;
            }

            return null;
        }

        public bool ContainsName(string name)
        {
                return _players.Any(player => player.Name == name);
        }
    }
}
