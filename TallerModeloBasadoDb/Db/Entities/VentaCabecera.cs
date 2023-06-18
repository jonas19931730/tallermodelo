using System;
using System.Collections.Generic;

namespace TallerModeloBasadoDb.Db.Entities;

public partial class VentaCabecera
{
    public int Id { get; set; }

    public int? IdCliente { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public double? Subtotal { get; set; }

    public double? Iva { get; set; }

    public double? Total { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
