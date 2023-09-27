using AlunosLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DAL
{
    public static class FileHelper
    {
        public delegate string Serializer(ICollection<Aluno> list);
        public delegate ICollection<Aluno> Deserializer(string text);

        public static string CSVSerialize(ICollection<Aluno> list)
        {
            string s = "";
            foreach (Aluno item in list)
            {
                s += $"{item.GUID},{item.Nome},{item.Turma.ToString()},{item.Periodo},{item.Aprovado}\n";
            }
            return s;
        }

        public static ICollection<Aluno> CSVDeserialize(string text)
        {
            List<Aluno> list = new List<Aluno>();
            string[] lines = text.Split('\n');
            foreach (string line in lines) {
                string[] props = line.Split(',');
                if(props.Length != 5) continue;


                string guid = props[0];
                string nome = props[1];
                Turmas turma = Turmas.ERRO; 
                Enum.TryParse(props[2], out turma);
                int periodo = int.Parse(props[3]);
                bool aprovado = bool.Parse(props[4]);

                list.Add(new Aluno(nome, periodo, turma, aprovado, guid ));
            }
            return list;
        }


        #region JSON_SERIALIZER
        /*
        public static string JSONSerialize(ICollection<Aluno> list) {
            return JsonSerializer.Serialize(list);
        }

        public static ICollection<Aluno> JSONDeserialize(string text){
            return JsonSerializer.Deserialize<List<Aluno>>(text);
        }


        public static string JSONSerialize(ICollection<Aluno> list) {
            return JsonConvert.SerializeObject(list);
        }

        public static ICollection<Aluno> JSONDeserialize(string text){
            var list = JsonConvert.DeserializeObject<List<Aluno>>(text);
            if(list==null) return new List<Aluno>();
            return list;
        }
        */
        #endregion



    }
}
