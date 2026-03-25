using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls; //Esto permite usar la clase textBox

namespace PokedexWeb
{
    //Le agrego static para no tener que instanciar la clase cada vez que quiera usarla
    public static class Validacion
    {
        //Método que recibe un control genérico y devuelve true si tiene texto
        public static bool ValidaTextoVacio (object control)

        {
            //Verifico si el control es un textbox
            //El truco: "texto" al final castea automáticamente el control a esa variable si la condición se cumple
            if (control is TextBox texto)
            {
                //Si está nulo o vacío, la vallidación falla (devuelve false)
                if(string.IsNullOrEmpty(texto.Text))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false; //Si mandan un control que NO es txtbox, por defecto falla.


        }
        
    }
}