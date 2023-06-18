using System;
using System.Collections.Generic;

namespace TallerModeloBasadoDb.Db.Entities;

public partial class VideoJuego
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Proveedor { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
