using jjitalaS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jjitalaS5.Repositories
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteConnection _conn;

        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (_conn != null)
                return;
            _conn = new SQLiteConnection(_dbPath);
            _conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if(string.IsNullOrEmpty(name))
                    throw new Exception("Nombre requerido");
                Persona persona = new() { Name = name };
                result = _conn.Insert(persona);
                StatusMessage = string.Format("Dato insertado");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error ", ex.Message);
                throw;
            }
        }

        //SELECT
        public List<Persona> GetAllPersons()
        {
            try
            {
                Init();
                return _conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error ", ex.Message);
                throw;
            }

            return new List<Persona>();
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                int result = _conn.Delete<Persona>(id);
                StatusMessage = result > 0
                    ? "Persona eliminada"
                    : "No se encontró la persona";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al eliminar: {ex.Message}";
                throw;
            }
        }

        //UPDATE
    }
}
