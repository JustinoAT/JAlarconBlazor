using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        public object? ProductoObj { get; set; }
        public bool? Correct { get; set; }
        public List<object>? ProductosList { get; set; }
        public ML.Categoria Categoria { get; set; }

    }
}
