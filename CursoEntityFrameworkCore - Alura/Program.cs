using Microsoft.EntityFrameworkCore;

namespace CursoEntityFrameworkCore___Alura;
class Program
{
    static void Main(string[] args)
    {
        //GravarUsandoEntity();
        // DeletarUsandoEntity();
        AtualizarUsandoEntity();
    }

    private static void GravarUsandoEntity()
    {
        Produto p = new Produto();
        p.Nome = "Harry Potter e a Ordem da Fênix";
        p.Categoria = "Livros";
        p.Preco = 19.89;

        Produto p1 = new Produto();
        p1.Nome = "testeteste";
        p1.Categoria = "Livros";
        p1.Preco = 25.90;

        Produto p2 = new Produto();
        p2.Nome = "Como fazer amigos";
        p2.Categoria = "Filme";
        p2.Preco = 102.90;

        using (var contexto = new LojaContext())
        {
            contexto.Produtos.AddRange(p,p1,p2);
            contexto.SaveChanges();
        }
    }

    private static void BuscarUsandoEntity()
    {

        using (var contexto = new LojaContext())
        {
            List<Produto> produtos = contexto.Produtos.ToList();

            foreach (var produto in produtos)
            {
                Console.WriteLine("Nome: " + produto.Nome);
                Console.WriteLine("Preço: "+ produto.Preco);
            }
        }
    }

    private static void DeletarUsandoEntity()
    {
        using (var contexto = new LojaContext())
        {
            List<Produto> produtos = contexto.Produtos.ToList();

            foreach(var produto in produtos)
            {
                Console.WriteLine($"removendo: {produto.Nome}");
                contexto.Produtos.Remove(produto);
                contexto.SaveChanges();
            }
        }
    }

    private static void AtualizarUsandoEntity()
    {
        using (var contexto = new LojaContext())
        {
            List<Produto> produtos = contexto.Produtos.ToList();

            foreach(var produto in produtos)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Id: {produto.Id}");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Preço: {produto.Preco}");
                Console.WriteLine($"Categoria: {produto.Categoria}");
                Console.WriteLine("----------------------");
            }

            Console.Write("\n\nDigite o id do Produto que deseja alterar: ");
            string opcao = Console.ReadLine()!;
            int opcaoNumero = int.Parse(opcao);

            foreach (var produto in produtos)
            {
                if(produto.Id == opcaoNumero)
                {
                    Console.Write("Digite o novo Nome: ");
                    string nome = Console.ReadLine()!;
                    Console.Write("Digite o novo Preço: ");
                    string preco = Console.ReadLine()!;
                    double precoConvertido = double.Parse(preco);
                    Console.Write("Digite a nova Categoria: ");
                    string categoria = Console.ReadLine()!;

                    produto.Categoria = categoria;
                    produto.Preco = precoConvertido;
                    produto.Nome = nome;

                    contexto.Update(produto);
                    contexto.SaveChanges();

                    return;
                }
            }
            Console.WriteLine("Id não encontrado!");
        }
    }
}
