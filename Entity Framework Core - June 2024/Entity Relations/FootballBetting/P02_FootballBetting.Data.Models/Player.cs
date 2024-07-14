using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            PlayersStatistics = new HashSet<PlayerStatistic>();
        }
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string Name { get; set; }

        public int SquadNumber { get; set; }
        public int TownId { get; set; }
        [ForeignKey(nameof(TownId))]
        public virtual Town Town { get; set; }
        public int PositionId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual Position Position { get; set; }
        [Required]
        public bool IsInjured { get; set;}
        public int TeamId { get; set; }
        
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }

        public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
    }
}
