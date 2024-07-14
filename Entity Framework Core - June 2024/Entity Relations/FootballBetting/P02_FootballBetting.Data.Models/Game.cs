using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            Bets = new HashSet<Bet>();
            PlayersStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int GameId { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
        [ForeignKey(nameof(HomeTeamId))]
        [Required]
        public virtual Team HomeTeam { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
        [ForeignKey(nameof(AwayTeamId))]
        [Required]
        public virtual Team AwayTeam { get; set; }
        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }
        public DateTime DateTime { get; set; }

        public decimal HomeTeamBetRate { get; set; }

        public decimal AwayTeamBetRate { get; set; }

        public decimal DrawBetRate { get; set; }

        public string Result { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
