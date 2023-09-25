using AlunosLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL
{
    public class FileRepos : IRepository
    {
        public string path;
        private FileHelper.Deserializer deserializer;
        private FileHelper.Serializer serializer;

        public FileRepos(string path, FileHelper.Serializer ser, FileHelper.Deserializer des )
        {
            serializer = ser;
            deserializer= des;
            this.path = Path.GetFullPath(path);   
        }

        public ICollection<Aluno> Load()
        {
            try
            {
                string text = File.ReadAllText(path);
                return deserializer(text);
            }
            catch(FileNotFoundException) {
                var stream = File.Create(path);
                stream.Close();
                return new List<Aluno>();
            }
        }

        public void Save(ICollection<Aluno> alunoList)
        {
            string text = serializer(alunoList);
            File.WriteAllText(path, text);
        }
    }
}
