using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public static class PersonaService
    {
        private static PersonaRepository PersonaRespositorio = new PersonaRepository();
        public static string Guardar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona)==null)
            {
                PersonaRespositorio.Guardar(persona);
                return $"Se registro la persona {persona.Nombre} Satisfactoriamente";
            }
            else
            {
                return $"La persona {persona.Nombre} ya esta registrada";
            }

            
        }

        public static string Eliminar(string identificacion)
        {
            try
            {

                Persona persona = PersonaRespositorio.Buscar(identificacion);

                if (persona != null)
                {
                    PersonaRespositorio.Eliminar(persona);
                    return $"Los datos de {persona.Nombre} han sido Eliminados satisfactoriamente";
                }
                else
                {
                    return $"Lo Sentimos, la identificacion {identificacion} no se encuentran regitrados ";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }


        }

        public static List<Persona> Consultar()
        {
            return PersonaRespositorio.Consultar();
        }

        public static string Modificar(Persona persona)
        {
            if (PersonaRespositorio.Buscar(persona) == null)
            {

                return $"La persona con identificacion no se encuentra registrada";

            }
            else
            {
                PersonaRespositorio.Modificar(persona);
                return $"La persona {persona.Identificacion} fue Modificada";
            }
        }

        public static Persona Buscar(string identificacion)
        {   
            return PersonaRespositorio.Buscar(identificacion);
        }

        public static void Buscar(Persona persona)
        {
            
        }

    }
}
