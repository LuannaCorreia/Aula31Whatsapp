using System;

namespace Aula31Whatsapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Contato _contato = new Contato ();
            Agenda agd = new Agenda ();
            _contato.Nome = "Luanna Correia";
            _contato.Telefone = "(11)2568-2159";
            agd.Cadastrar (_contato);
            agd.Listar ();
        }
    }
}