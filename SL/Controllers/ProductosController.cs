using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        [Route("{nombre?}")]
        [HttpGet]
        public IActionResult GetAll(string? nombre)
        {
         
            if (nombre == null) nombre = "";

            ML.Producto producto = new ML.Producto();
            producto.Nombre = nombre;

            producto.ProductosList = BL.Producto.GetAll(nombre);

            if (producto.ProductosList.Count > 0)
            {
                return StatusCode(200, producto.ProductosList);
            }
            else
            {
                return StatusCode(500, producto.ProductosList);
            }
        }
        [Route("GetById/{IdProducto}")]
        [HttpGet]
        public IActionResult GetById(int IdProducto)
        {

            ML.Producto producto = new ML.Producto();

            producto.ProductoObj = BL.Producto.GetById(IdProducto);

            if (producto.ProductoObj != null)
            {
                return StatusCode(200, producto.ProductoObj);
            }
            else
            {
                return StatusCode(500, producto.ProductoObj);
            }
        }


        [Route("Add")]
        [HttpPost]
        public IActionResult Add(ML.Producto producto)
        {


            producto.Correct = BL.Producto.Add(producto);

            if (producto.Correct == true)
            {
                return StatusCode(200, producto.Correct);
            }
            else
            {
                return StatusCode(500, producto.Correct);
            }
        }

        [Route("Delete/{IdProducto}")]
        [HttpDelete]
        public IActionResult Delete(int IdProducto)
        {
            ML.Producto producto = new ML.Producto();

            producto.Correct = BL.Producto.Delete(IdProducto);

            if (producto.Correct == true)
            {
                return StatusCode(200, producto.Correct);
            }
            else
            {
                return StatusCode(500, producto.Correct);
            }
        }
        [Route("Update")]
        [HttpPut]
        public IActionResult Update(ML.Producto producto)
        {
            

            producto.Correct = BL.Producto.Update(producto);

            if (producto.Correct == true)
            {
                return StatusCode(200, producto.Correct);
            }
            else
            {
                return StatusCode(500, producto.Correct);
            }
        }
    }
}
