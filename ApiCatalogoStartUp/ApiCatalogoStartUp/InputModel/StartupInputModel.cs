using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoStartUp.InputModel
{
    public class StartupInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del Startup debe contener entre 3 y 100 caracteres")]
        public string nombre { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre del Producto debe contener entre 1 y 100 caracteres")]
        public string producto { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "El precio debe ser de minimo 1 y 1000")]
        public double precio { get; set; }

    }
}
