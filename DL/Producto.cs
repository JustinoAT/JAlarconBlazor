using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL;

public partial class Producto
{
    [Required]
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal Precio { get; set; }

    public int? Categoria { get; set; }
    public virtual Categorium? CategoriaNavigation { get; set; }
}
