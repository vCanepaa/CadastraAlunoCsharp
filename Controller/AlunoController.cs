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
			if(!verificaDados(nome,cpf,idade))
			{
				throw new IOException("Dados invalidos");
			}
			Aluno al = new Aluno
			{
				Nome = $"{nome}",
				Cpf = $"{cpf}",
				Idade = idade
			};
			if (this.alunoExiste(al))
			{ 
                throw new DataBaseException("CPF Já existe na Base de Dados!");
			}
			else
			{
				alunos.InsertOne(al);
				Console.WriteLine("Aluno Cadastrado com Sucesso!");
			}
		
    }
	public void PrintAlunos()
	{
		List<Aluno> lista = this.findAll();
		if (lista.Count() == 0)
		{
			Console.WriteLine("Nenhum aluno cadastrado!");
		}
		else
		{
			foreach (Aluno al in lista)
			{
				Console.WriteLine("ID: " + al.ID + " Aluno: " + al.Nome + " CPF: " + al.Cpf + " Idade " + al.Idade);
			}
		}
	}
	
	public void AlterarAluno()
	{
			Console.WriteLine("Digite o cpf do aluno a ser alterado:");
			string cpf = Console.ReadLine();
			FilterDefinition<Aluno> filtro = filtroCpf(cpf);
			Aluno al = alunos.Find(filtro).FirstOrDefault();
			if(al == null)
			{
                throw new AlunoNotFoundException($"Aluno com cpf: {cpf} não existe na Base de dados!");
            }

			Console.WriteLine("Digite o novo nome do aluno: ");
			al.Nome = Console.ReadLine();
			Console.WriteLine("Digite o novo cpf do aluno: ");
			al.Cpf = Console.ReadLine();
			Console.WriteLine("Digite a nova idade do aluno: ");
			al.Idade = Int32.Parse(Console.ReadLine());
			if (al.Nome == null || cpf == al.Cpf || al.Idade <= 0)
			{
				throw new IOException("Dados invalidos");
			}

			UpdateDefinition<Aluno> update = Builders<Aluno>.Update.Set("nome", $"{al.Nome}")
			.Set("cpf", $"{al.Cpf}")
			.Set("idade", al.Idade);

			alunos.UpdateOne(filtro, update);
            Console.WriteLine("Dados de Aluno alterados com Sucesso!");
        
	}
	public void DeletarAluno()
	{
			Console.WriteLine("Digite o cpf do aluno a ser deletado:");
			string cpf = Console.ReadLine();
			if(this.findByCpf(cpf) == null)
			{
				throw new AlunoNotFoundException($"Aluno com cpf: {cpf} não existe na Base de dados!");
			}
			FilterDefinition<Aluno> filtro = filtroCpf(cpf);

			alunos.DeleteOne(filtro);
            Console.WriteLine("Aluno deletado com Sucesso");
       
    }


	//METODOS PRIVADOS
    private List<Aluno> findAll()
    {
        List<Aluno> lista = alunos.Aggregate().ToList();
        return lista;
    }


    private FilterDefinition<Aluno> filtroCpf(string cpf)
    {
        FilterDefinition<Aluno> filtro = Builders<Aluno>.Filter.Eq("cpf", $"{cpf}");

        return filtro;
    }

    private bool alunoExiste(Aluno al)
    {
        List<Aluno> lista = this.findAll();
        foreach (Aluno a in lista)
        {
            if (a.Equals(al))
            {
                return true;
            }
        }
        return false;
    }

    private Aluno findByCpf(string cpf)
    {
        FilterDefinition<Aluno> filtro = Builders<Aluno>.Filter.Eq("cpf", $"{cpf}");
        Aluno al = alunos.Find(filtro).FirstOrDefault();
        return al;
    }

	private bool verificaDados(string n, string c, int i)
	{
		if(i<= 0 || n == null || c == null)
		{
			return false;
		}else if(n.All(char.IsDigit) || !c.All(char.IsDigit))
		{
			return false;
		}


		return true;
	}

}
