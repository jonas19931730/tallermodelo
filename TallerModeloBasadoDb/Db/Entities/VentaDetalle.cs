using System;
using System.Collections.Generic;

namespace TallerModeloBasadoDb.Db.Entities;

public partial class VentaDetalle
{
    public int Id { get; set; }

    public int? IdVentaCabecera { get; set; }

    public int? IdVideoJuego { get; set; }

    public int? Cantidad { get; set; }

    public virtual VentaCabecera? IdVentaCabeceraNavigation { get; set; }

    public virtual VideoJuego? IdVideoJuegoNavigation { get; set; }
}
