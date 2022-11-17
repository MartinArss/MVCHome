using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCHome.Context;
using MVCHome.Models;
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

        public async Task<IActionResult> Index()
        {
            var response = await _context.ArticuloDb.ToListAsync();
            return View(response);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearArticulo(Articulo request)
        {
            if (request != null)
            {
                Articulo articulo = new Articulo();
                articulo.Nombre = request.Nombre;
                articulo.Descripcion = request.Descripcion;
                articulo.UrlImg = request.UrlImg;

                _context.ArticuloDb.Add(articulo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
