using Lab15.Models;

using System.Text.Json;

namespace Lab15.Services
{
    public class RegistroAnimalServicescs
    {
        private readonly string _rutaAnimalsRegistro = "registro_animales.json";

        public List<Animal> AnimalsList()
        {
            if (!File.Exists(_rutaAnimalsRegistro))
                return new List<Animal>();

            try
            {
                string jsonData = File.ReadAllText(_rutaAnimalsRegistro);
                return JsonSerializer.Deserialize<List<Animal>>(jsonData) ?? new List<Animal>();
            }
            catch
            {
                return new List<Animal>();
            }
        }

        public void GuardarAnimal(Animal animal)
        {
            var animals = AnimalsList();
            animals.Add(animal);
            try
            {
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                string jsonData = JsonSerializer.Serialize(animals, opciones);
                File.WriteAllText(_rutaAnimalsRegistro, jsonData);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al escribir: {ex.Message}");
            }
        }
    }
}
