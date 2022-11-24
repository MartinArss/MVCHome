using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCHome.Context;
using MVCHome.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MVCHome.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticuloController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N5V89RM; Initial Catalog=ProyectoTest; Integrated Security=True;");

        public async Task<IActionResult> Index()
        {
            return View(await _context.ArticuloDb.ToListAsync());
        }

        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        //var response = await _context.ArticuloDb.ToListAsync();
        //        var response = await connection.QueryAsync<Articulo>("SP_GetDataAriculos", new { }, commandType: CommandType.StoredProcedure);
        //        return View(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new System.Exception("Surgio un error" + ex.Message);
        //    }
        //}

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CrearArticulo(Articulo request)
        //{
        //    if (request != null)
        //    {
        //        Articulo articulo = new Articulo();
        //        articulo.Nombre = request.Nombre;
        //        articulo.Descripcion = request.Descripcion;
        //        articulo.UrlImg = request.UrlImg;

        //        _context.ArticuloDb.Add(articulo);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Crear(Articulo response)
        {
            try
            {
                await connection.QueryAsync<Articulo>("SP_InsertArticulo",
                    new { response.Nombre, response.Descripcion, response.UrlImg }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var articulo = _context.ArticuloDb.Find(id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Articulo response)
        {
            try
            {
                await connection.QueryAsync<Articulo>("SP_EditArticulo",
                    new { response.PkArticulo, response.Nombre, response.Descripcion, response.UrlImg }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error" + ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.ArticuloDb.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(Articulo response)
        {
            try
            {
                await connection.QueryAsync<Articulo>("SP_DeleteArticulo",
                    new { response.PkArticulo }, commandType: CommandType.StoredProcedure);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new System.Exception("Surgio un error" + ex.Message);
            }
        }
    }
}
