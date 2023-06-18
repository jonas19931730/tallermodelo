using System;
using System.Collections.Generic;

namespace TallerModeloBasadoDb.Db.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<VentaCabecera> VentaCabeceras { get; set; } = new List<VentaCabecera>();
}
