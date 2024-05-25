
using CadastraAlunos.DataBase;
using CadastraAlunos.Exceptions;
using System.Runtime.CompilerServices;

AlunoController ac = new AlunoController();
int cont = 0;


do
{
    if (cont >= 2)
    {
        Console.Clear();
        cont = 0;
    }
    else
    {
        cont++;
    }

    Console.WriteLine("----CADASTRO DE ALUNOS-----");
    Console.WriteLine("1-CADASTRAR");
    Console.WriteLine("2-ALTERAR");
    Console.WriteLine("3-LISTAR");
    Console.WriteLine("4-DELETAR");
    Console.WriteLine("5-FINALIZAR");
    try
    {
        int op = int.Parse(Console.ReadLine());

        if (op > 5 || op < 1)
        {
            throw new IOException("Opção invalida");
        }else if (op == 5)
        {
            break;
        }
        else
        {
            switch (op)
            {

                case 1:
                    ac.CadastrarAluno();
                    break;
                case 2:
                    ac.AlterarAluno();
                    break;
                case 3:
                    ac.PrintAlunos();
                    break;
                case 4:
                    ac.DeletarAluno();
                    break;
            }
        }
       
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine("Tipo de entrada invalido!");
    }catch(IOException e)
    {
        Console.WriteLine(e.Message);
    }catch(AlunoNotFoundException e)
    {
        Console.WriteLine(e.Message);
    }catch(DataBaseException e)
    {
        Console.WriteLine(e.Message);
    }

} while (true);

