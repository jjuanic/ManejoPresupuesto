using Dapper;
using ManejoPresupuestoMVC.Models;
using ManejoPresupuestoMVC.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuestoMVC.Controllers
{
    public class TiposCuentasController : Controller
    {
        private readonly IRepositorioTiposCuenta repositorioTiposCuenta;
        public TiposCuentasController(IRepositorioTiposCuenta repositorioTiposCuentas) 
        {
            this.repositorioTiposCuenta = repositorioTiposCuentas;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoCuenta tipoCuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoCuenta);
            }

            tipoCuenta.UsuarioId = 1;
            await repositorioTiposCuenta.Crear(tipoCuenta);

            return View();
        }
    }
}
