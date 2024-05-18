using System;

public class Aluno
{

    private static int alunosTotal;
	public int ID { get; set; }
	public string Nome { get; set; }
	public string Cpf { get; set; }
	public int Idade { get; set; }

	public Aluno(string nome, string cpf, int idade) {
		this.ID = alunosTotal;
		this.Nome = nome;
		this.Cpf = cpf;
		this.Idade = idade;
		alunosTotal++;
	} 
}


	

