using System.Text.Json;

namespace Joao_Ramos_DR2_TP2
{
    static class Repos
    {
        public static List<Produto> Load(string path)
        {
            try
            {
                string text = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<Produto>>(text);
            }
            catch(FileNotFoundException) {
                var stream = File.Create(path);
                string text = File.ReadAllText($"{stream.Name}");
                return JsonSerializer.Deserialize<List<Produto>>(text);
            }
            catch (JsonException) {
                File.WriteAllText(path, "[]");
                return new List<Produto>();
            }
        }

        public static async void Save(List<Produto> produtoList, string path)
        {
            string text = JsonSerializer.Serialize(produtoList);
            File.WriteAllText(path, text);
        }


    }
}
