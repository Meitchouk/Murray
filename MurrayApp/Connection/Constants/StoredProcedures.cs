namespace Connection.Constants
{
    /// <summary>
    ///     Constantes de los nombres de los procedimientos de almanezado que existen
    /// </summary>
    internal sealed class StoredProcedures
    {
        #region Identity

        public const string UsuarioLogin = "USUARIO_LOGIN";
        public const string UsuarioGet = "USUARIO_GET";
        public const string UsuarioCreate = "USUARIO_CREATE";
        public const string UsuarioUpdate = "USUARIO_UPDATE";
        public const string UsuarioDelete = "USUARIO_DELETE";

        #endregion

        #region Common

        public const string CategoriaGet = "CATEGORIA_GET";
        public const string CategoriaCreate = "CATEGORIA_CREATE";
        public const string CategoriaUpdate = "CATEGORIA_UPDATE";
        public const string CategoriaDelete = "CATEGORIA_DELETE";

        public const string ContactoCreate = "CONTACTO_CREATE";
        public const string ContactoGet = "CONTACTO_GET";
        public const string ContactoUpdate = "CONTACTO_UPDATE";
        public const string ContactoDelete = "CONTACTO_DELETE";

        public const string DepartamentoCreate = "DEPARTAMENTO_CREATE";
        public const string DepartamentoGet = "DEPARTAMENTO_GET";
        public const string DepartamentoUpdate = "DEPARTAMENTO_UPDATE";
        public const string DepartamentoDelete = "DEPARTAMENTO_DELETE";

        public const string EmpleadoCreate = "EMPLEADO_CREATE";
        public const string EmpleadoGet = "EMPLEADO_GET";
        public const string EmpleadoUpdate = "EMPLEADO_UPDATE";
        public const string EmpledaoDelete = "EMPLEADO_DELETE";

        public const string MunicipioGet = "MUNICIPIO_GET";
        public const string MunicipioCreate = "MUNICIPIO_CREATE";
        public const string MunicipioUpdate = "MUNICIPIO_UPDATE";
        public const string MunicipioDelete = "MUNICIPIO_DELETE";

        public const string ProductoGet = "PRODUCTO_GET";
        public const string ProductoCreate = "PRODUCTO_CREATE";
        public const string ProductoUpdate = "PRODUCTO_UPDATE";
        public const string ProductoDelete = "PRODUCTO_DELETE";

        #endregion

        #region Sale

        public const string ClienteGet = "CLIENTE_GET";
        public const string ClienteCreate = "CLIENTE_CREATE";
        public const string ClienteUpdate = "CLIENTE_UPDATE";
        public const string ClienteDelete = "CLIENTE_DELETE";

        public const string VentaGet = "VENTA_GET";
        public const string VentaCreate = "VENTA_CREATE";
        public const string VentaUpdate = "VENTA_UPDATE";
        public const string VentaDelete = "VENTA_DELETE";

        public const string DetalleVentaGet = "DETALLE_VENTA_GET";
        public const string DetalleVentaCreate = "DETALLE_VENTA_CREATE";
        public const string DetalleVentaUpdate = "DETALLE_VENTA_UPDATE";
        public const string DetalleVentaDelete = "DETALLE_VENTA_DELETE";

        #endregion

        #region Shopping

        public const string ProveedorGet = "PROVEEDOR_GET";
        public const string ProveedorCreate = "PROVEEDOR_CREATE";
        public const string ProveedorUpdate = "PROVEEDOR_UPDATE";
        public const string ProveedorDelete = "PROVEEDOR_DELETE";

        public const string CompraGet = "COMPRA_GET";
        public const string CompraCreate = "COMPRA_CREATE";
        public const string CompraUpdate = "COMPRA_UPDATE";
        public const string CompraDelete = "COMPRA_DELETE";

        public const string DetalleCompraGet = "DETALLE_COMPRA_GET";
        public const string DetalleCompraCreate = "DETALLE_COMPRA_CREATE";
        public const string DetalleCompraUpdate = "DETALLE_COMPRA_UPDATE";
        public const string DetalleCompraDelete = "DETALLE_COMPRA_DELETE";

        #endregion
    }
}