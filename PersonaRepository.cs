using gguachaminS5_2.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gguachaminS5_2
{
    public class PersonaRepository
    {
        string _dbPath; //Ruta
        private SQLiteConnection conn;
        //Mensaje a mostrar
        public string StatusMessage { get; set; }

        //TODO: Add variable for the SQLite connection

        private void Init()
        {
            if (conn is not null)
            {
                return;
            }
            conn = new(_dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonaRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPersona(string nombre)
        {
            int result;
            try
            {
                Init();

                //Validar que se ingrese el nombre
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");

                Persona persona = new() { Name = nombre };
                result = conn.Insert(persona);

                StatusMessage = string.Format("{0} record(s) added (Nombre: {1})", result, nombre);
            } catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nombre, ex.Message);
            }
        }
        public List<Persona> GetAllPeople() 
        {
            List<Persona> personasDB;
            try
            {
                Init();
                personasDB = conn.Table<Persona>().ToList();
                return personasDB;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data {0}.", ex.Message);
            }
            return new List<Persona>();
        }
        public void UpdatePersona(int id, string nombre)
        {
            int result;
            try
            {
                Init();

                //Validar que se ingrese el nombre
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");

                Persona persona = new() { Name = nombre , Id = id};
                result = conn.Update(persona);

                StatusMessage = string.Format("{0} record(s) updated (Nombre: {1})", result, nombre);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update {0}. Error: {1}", nombre, ex.Message);
            }
        }
        public void DeletePersona(int id)
        {
            int result;
            try
            {
                Init();

                //Validar que se ingrese el nombre
                if (id <= 0)
                    throw new Exception("Id requerido");

                Persona persona = new() { Id = id };
                result = conn.Delete(persona);

                StatusMessage = string.Format("{0} record(s) deleted (Nombre: {1})", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }
    }
}
