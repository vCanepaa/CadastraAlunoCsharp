using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Aluno
{
	[BsonId]
	[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
	public string ID { get; set; }
	[BsonElement("nome")]
	public string Nome { get; set; }
	[BsonElement("cpf")]
	public string Cpf { get; set; }
	[BsonElement("idade")]
	[BsonRepresentation(BsonType.Int32)]
	public int Idade { get; set; }

	public Aluno()
	{

	}
}


	

