using Dapper;
using ManejoPresupuestoMVC.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuestoMVC.Servicios
{
    public interface IRepositorioTiposCuenta
    {
        Task Crear(TipoCuenta tipoCuenta);
    }
    public class RepositorioTiposCuenta : IRepositorioTiposCuenta
    {
        private readonly string connectionString;
        public RepositorioTiposCuenta(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            // Query que estoy seguro que me va a traer un solo resultado
            // Después de insertar el objeto, vamos a querer devolver el id
            var id =await connection.QuerySingleAsync<int>
                ($@"INSERT INTO TiposCuenta (Nombre,UsuarioId,Orden)
                 values (@nombre, @usuarioId,0);
                 SELECT SCOPE_IDENTITY();", tipoCuenta); //Trae el Id recién creado 
            tipoCuenta.Id = id;
        }
    }
}
