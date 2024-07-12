namespace Comex.Funcionalidades
{
    internal class Sair : Funcionalidade
    {
        public Sair(string titulo) : base(titulo)
        {
        }

        public override void Executar()
        {
            Console.WriteLine("COMEX FINALIZADO");
        }
    }
}
