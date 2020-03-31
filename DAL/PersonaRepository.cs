using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class PersonaRepository
    {
        string FileName = @"Persona.txt";
        public void Guardar(Persona persona)
        {
            FileStream SourcesStream = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(SourcesStream);
            writer.WriteLine(persona.Identificacion + ";" + persona.Nombre + ";" + persona.Edad + ";" + persona.Sexo + ";" + persona.Pulsaciones);
            writer.Close();
            SourcesStream.Close();
        }
        
        
        public List<Persona> Personas = new List<Persona>();

        
        public void Eliminar(Persona persona)
        {
            Personas.Clear();
            Personas = Consultar();

            FileStream Source = new FileStream(FileName, FileMode.Create);
            Source.Close();
            foreach (var item in Personas)
            {
                if (item.Identificacion != persona.Identificacion)
                {
                    Guardar(item);
                }
                
            }
        }

 

        public List<Persona> Consultar()
        {
            Personas.Clear();

            FileStream SourceStream = new FileStream(FileName, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(SourceStream);

            string linea = string.Empty;
            while ((linea = reader.ReadLine())!= null)
            {
                Persona persona = Map(linea);

                Personas.Add(persona);
            }

            linea = reader.ReadLine();
            reader.Close();
            SourceStream.Close();

            return Personas;
        }

        private static Persona Map(string linea)
        {
            char delimiter = ';';
            string[] DatosPersona = linea.Split(delimiter);

            Persona persona = new Persona();
            persona.Identificacion = DatosPersona[0];
            persona.Nombre = DatosPersona[1];
            persona.Edad = Convert.ToInt32(DatosPersona[2]);
            persona.Sexo = DatosPersona[3];
            persona.Pulsaciones = Convert.ToInt32(DatosPersona[4]);
            return persona;
        }

        public void Modificar(Persona persona)
        {
            
           
            FileStream SourceStream = new FileStream(FileName, FileMode.Create);
            SourceStream.Close();
            foreach (var item in Personas)
            {

                if (persona.Identificacion != item.Identificacion)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(item);
                }
            }
            
        }

        public Persona Buscar(Persona persona)
        {
            foreach (var item in Personas)
            {
                if (item.Identificacion.Equals(persona.Identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public Persona Buscar(string identificacion)
        {
            foreach (var item in Personas)
            {
                if (item.Identificacion.Equals(identificacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
