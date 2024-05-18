using CadastraAlunos.Exceptions;
using System;

public class AlunoController
{
	public List<Aluno> lista;
	public AlunoController()
	{
		lista = new List<Aluno>();
	}
	public void CadastrarAluno()
	{
        Console.WriteLine("Digite o nome do aluno: ");
		string nome = Console.ReadLine();
        Console.WriteLine("Digite o cpf do aluno: ");
		string cpf = Console.ReadLine();
        Console.WriteLine("Digite a idade do aluno: ");
		int idade = int.Parse(Console.ReadLine());

		Aluno al = new Aluno(nome, cpf, idade);
		lista.Add(al);
    }
	public void PrintAlunos()
	{
		foreach(Aluno al in lista)
		{
            Console.WriteLine("ID: "+ al.ID+ " Aluno: "+al.Nome+ " CPF: "+ al.Cpf+ " Idade "+ al.Idade);
        }
	}
	public Aluno findById(int id)
	{
		foreach(Aluno al in lista) { 
			if(id == al.ID)
			{
				return al;
			}
		}
		throw new AlunoNotFoundException("Aluno não encontrado!");
    }

	public void AlterarAluno()
	{

		Console.WriteLine("Digite o id do aluno a ser alterado:");
		int id = Int32.Parse(Console.ReadLine());

		foreach(Aluno al in lista)
		{
			if(al.ID == id)
			{
				lista.Remove(al);
                Console.WriteLine("Digite o novo nome do aluno: ");
                al.Nome = Console.ReadLine();
                Console.WriteLine("Digite o novo cpf do aluno: ");
                al.Cpf = Console.ReadLine();
                Console.WriteLine("Digite a nova idade do aluno: ");
                al.Idade = Int32.Parse(Console.ReadLine());
				lista.Insert(id, al);
				break;
            }
		}
        throw new AlunoNotFoundException("Aluno não encontrado!");
    }
	public void DeletarAluno()
	{
		Console.WriteLine("Digite o id do aluno a ser deletado:");
		int id = Int32.Parse(Console.ReadLine());
		Aluno al = findById(id);
		if (al != null)
		{
			lista.Remove(al);
		}
	}
}
