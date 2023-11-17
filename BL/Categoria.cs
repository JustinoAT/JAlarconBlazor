using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconBlazorContext context = new DL.JalarconBlazorContext())
                {
                    var categoriasLinq = (from objCategoria in context.Categoria
                                         select new
                                         {
                                             IdCategoria = objCategoria.IdCategoria,
                                             Tipo = objCategoria.Tipo
                                         }).ToList();


                    if (categoriasLinq != null && categoriasLinq.ToList().Count > 0)
                    {

                        foreach (var obj in categoriasLinq)
                        {
                            ML.Categoria categoria = new ML.Categoria();


                            categoria.IdCategoria = obj.IdCategoria;
                            categoria.Tipo = obj.Tipo;
                            list.Add(categoria);

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
    }
}
