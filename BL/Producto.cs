using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static bool Add(ML.Producto producto)
        {
            bool result = new bool();
            try
            {
                using (DL.JalarconBlazorContext context = new DL.JalarconBlazorContext())
                {

                    DL.Producto producto1 = new DL.Producto();

                    producto1.Nombre = producto.Nombre;
                    producto1.Precio = producto.Precio;
                    producto1.Categoria = producto.Categoria.IdCategoria;


                    context.Productos.Add(producto1);

                    context.SaveChanges();
                    result = true;
                }
            }

            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
        public static bool Update(ML.Producto producto)
        {
            bool result = new bool();

            try
            {
                using (DL.JalarconBlazorContext context = new DL.JalarconBlazorContext())
                {
                    var query = (from a in context.Productos
                                 where a.IdProducto == producto.IdProducto
                                 select a).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.Precio = producto.Precio;
                        query.Categoria = producto.Categoria.IdCategoria;


                        context.SaveChanges();

                        result = true;
                    }

                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.ToString());

            }
            return result;

        }
        public static bool Delete(int IdProducto)
        {
            bool result = new bool();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconBlazorContext context = new DL.JalarconBlazorContext())
                {
                    var query = (from a in context.Productos
                                 where a.IdProducto == IdProducto
                                 select a).First();

                    context.Productos.Remove(query);
                    context.SaveChanges();
                }
                result = true;


            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.ToString());

            }
            return result;

        }

        public static List<object> GetAll(string? Nombre)
        {
            List<object> list = new List<object>();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconBlazorContext context = new DL.JalarconBlazorContext())
                {
                    var productosLINQ = (from objProducto in context.Productos
                                         join Categoria in context.Categoria on objProducto.Categoria equals Categoria.IdCategoria
                                         where objProducto.Nombre.Contains(Nombre)
                            select new
                            {
                                IdProducto = objProducto.IdProducto,
                                Nombre = objProducto.Nombre,
                                Precio = objProducto.Precio,
                                Categoria = objProducto.Categoria
                            }).ToList();


                    if (productosLINQ != null && productosLINQ.ToList().Count > 0)
                    {

                        foreach (var obj in productosLINQ)
                        {
                            ML.Producto producto = new ML.Producto();


                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Precio = obj.Precio;
                            producto.Categoria = new ML.Categoria();
                            producto.Categoria.IdCategoria = obj.Categoria.Value;

                            list.Add(producto);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return list;

        }
        public static object GetById(int IdProducto)
        {
            object list = new object();
            try
            {
                using (DL.JalarconBlazorContext context = new DL.JalarconBlazorContext())
                {
                    var productoLINQ = (from objProducto in context.Productos
                                        where objProducto.IdProducto == IdProducto
                                        select new
                                        {
                                            IdProducto = objProducto.IdProducto,
                                            Nombre = objProducto.Nombre,
                                            Precio = objProducto.Precio,
                                            Categoria = objProducto.Categoria
                                        }).Single();

                    if (productoLINQ != null)
                    {
                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = productoLINQ.IdProducto;
                        producto.Nombre = productoLINQ.Nombre;
                        producto.Precio = productoLINQ.Precio;
                        producto.Categoria = new ML.Categoria();
                        producto.Categoria.IdCategoria = productoLINQ.Categoria.Value;
                        list = producto;

                    }
                    else
                    {

                        Console.WriteLine("A ocurrido un error");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return list;

        }
    }

}
