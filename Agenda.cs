using System.Collections.Generic;
using System.IO;

namespace Aula31Whatsapp
{
    public class Agenda : IAgenda{

        List<Contato> contatos = new List<Contato> ();
        private const string PATH = "Database/contato.csv";

        //Criando pasta e arquivo
        public Agenda () {

            string DataBase = PATH.Split ('/') [0];
            if (!Directory.Exists (DataBase)) {
                Directory.CreateDirectory (DataBase);
            }
            if (!File.Exists (PATH)) {
                //Close
                File.Create (PATH).Close ();
            }
        }

        /// <summary>
        /// Cadastra o contato e prepara a linha
        /// </summary>
        /// <param name="Cadastrar e Preparar"></param>

        public void Cadastrar (Contato _contato) {
            var linha = new string[] { PrepararLinha (_contato) };
            File.AppendAllLines (PATH, linha);
        }

        /// <summary>
        /// Lê o contato
        /// </summary>

        public void Listar () {

            string[] linhas = File.ReadAllLines (PATH);

            foreach (var linha in linhas) {

                string[] dado = linha.Split (";");

                Contato ctt = new Contato ();
                contatos.Add (ctt);
            }
        }

        /// <summary>
        /// Remove um contato
        /// </summary>
        /// <param name="Remover"></param>
        
        public void Excluir (string _contato) {

            List<string> linhas = new List<string> ();

            using (StreamReader arquivo = new StreamReader (PATH)) {

                string linha;
                while ((linha = arquivo.ReadLine ()) != null) {

                    linhas.Add (linha);
                }
            }

            linhas.RemoveAll (l => l.Contains (_contato));

            using (StreamWriter output = new StreamWriter (PATH)) {

                foreach (string ln in linhas) {
                    output.Write (ln + "\n");
                }
            }
        }

        public string PrepararLinha (Contato ctt) {
            return $"Nome = {ctt.Nome}; Telefone = {ctt.Telefone}";
        }
    }
}