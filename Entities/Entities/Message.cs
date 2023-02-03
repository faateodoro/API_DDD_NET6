using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("TB_MESSAGE")]
    public class Message : Notifies
    {
        [Column("MSG_ID")]
        public int Id { get; set; }

        [Column("MSG_TITLE")]
        public string Title { get; set; }

        [Column("MSG_ACTIVE")]
        public bool Active { get; set; }

        [Column("MSG_CREATED_AT")]
        public DateTime CreatedAt { get; set; }

        [Column("MSG_LAST_UPDATE")]
        public DateTime LastUpdate { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        [Column(Order = 1)]
        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
