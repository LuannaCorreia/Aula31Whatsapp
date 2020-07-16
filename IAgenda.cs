namespace Aula31Whatsapp
{
    public interface IAgenda
    {
           void Listar ();

        void Cadastrar (Contato _contato);

        void Excluir (string _contato);
    }
}
