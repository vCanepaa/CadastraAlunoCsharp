using CadastraAlunos.Exceptions;
using System;
using MongoDB.Driver;
using MongoDB.Bson;
using CadastraAlunos.DataBase;
using System.Runtime.CompilerServices;

public class AlunoController
{
	private DBConnection con;
	

    private IMongoCollection<Aluno> alunos;
	public AlunoController()
	{
			con = new DBConnection();
			alunos = con.Db.GetCollection<Aluno>("Alunos");
    }
	public void CadastrarAluno()
	{
		
        Console.WriteLine("Digite o nome do aluno: ");
		string nome = Console.ReadLine();
        Console.WriteLine("Digite o cpf do aluno: ");
		string cpf = Console.ReadLine();
        Console.WriteLine("Digite a idade do aluno: ");
		int idade = int.Parse(Console.ReadLine());
		
		Aluno al = new Aluno{
			Nome = $"{nome}",
			Cpf = $"{cpf}",
			Idade = idade
		};	
			alunos.InsertOne(al);
			
    }
	public void PrintAlunos()
	{
		List<Aluno> lista = alunos.Aggregate().ToList();
		foreach(Aluno al in lista)
		{
            Console.WriteLine("ID: "+ al.ID+ " Aluno: "+al.Nome+ " CPF: "+ al.Cpf+ " Idade "+ al.Idade);
        }
	}
    private FilterDefinition<Aluno> filtroCpf(string cpf)
    {
        FilterDefinition<Aluno> filtro = Builders<Aluno>.Filter.Eq("cpf", $"{cpf}");
		
		return filtro;
    
	}

    public Aluno findById(string id)
    {
        FilterDefinition<Aluno> filtro = Builders<Aluno>.Filter.Eq("_id", $"{id}");
		Aluno al = alunos.Find(filtro).FirstOrDefault();
		return al;
    }

    public void AlterarAluno()
	{

		Console.WriteLine("Digite o cpf do aluno a ser alterado:");
		string cpf = Console.ReadLine();
		FilterDefinition<Aluno> filtro = filtroCpf(cpf);
        Aluno al = alunos.Find(filtro).FirstOrDefault();

        Console.WriteLine("Digite o novo nome do aluno: ");
        al.Nome = Console.ReadLine();
        Console.WriteLine("Digite o novo cpf do aluno: ");
        al.Cpf = Console.ReadLine();
        Console.WriteLine("Digite a nova idade do aluno: ");
        al.Idade = Int32.Parse(Console.ReadLine());

		UpdateDefinition<Aluno> update = Builders<Aluno>.Update.Set("nome", $"{al.Nome}")
			.Set("cpf",$"{al.Cpf}")
			.Set("idade", al.Idade);

			alunos.UpdateOne(filtro, update);
	}
	public void DeletarAluno()
	{
		Console.WriteLine("Digite o cpf do aluno a ser deletado:");
		string cpf = Console.ReadLine();
		FilterDefinition<Aluno> filtro = filtroCpf(cpf);

		alunos.DeleteOne(filtro);
		
    }
}
