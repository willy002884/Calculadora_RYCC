using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Calculadora_RYCC.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] public double? Numero1 { get; set; }
        [BindProperty] public double? Numero2 { get; set; }

        public string Resultado { get; set; } = "";

        public void OnPost(string operacion)
        {
            // Si presionó "Limpiar", borramos todo
            if (operacion == "limpiar")
            {
                ModelState.Clear();
                Numero1 = null;
                Numero2 = null;
                Resultado = "";
                return;
            }

            // Si falta algún valor
            if (Numero1 == null || Numero2 == null)
            {
                Resultado = "Escribe los dos valores";
                return;
            }

            // Hacemos la operación según el botón
            if (operacion == "suma")
            {
                Resultado = (Numero1 + Numero2).ToString();
            }
            else if (operacion == "resta")
            {
                Resultado = (Numero1 - Numero2).ToString();
            }
            else if (operacion == "multiplicacion")
            {
                Resultado = (Numero1 * Numero2).ToString();
            }
            else if (operacion == "division")
            {
                if (Numero2 == 0)
                {
                    Resultado = "No se puede dividir entre 0";
                }
                else
                {
                    Resultado = (Numero1 / Numero2).ToString();
                }
            }
        }
    }
}