namespace ProvadorVirtual.Aplicacao.Interfaces.Administracao
{
    public interface IApplicationServiceEmail
    {
        void EnviarEmail(string destinatario, string assunto, string mensagem);
    }
}
