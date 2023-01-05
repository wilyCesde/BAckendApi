using System.ComponentModel.DataAnnotations;

namespace BAckendApi.Models
{
    public class TblUsuario
    {
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string Usuario { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Rol { get; set; }
    }
}
