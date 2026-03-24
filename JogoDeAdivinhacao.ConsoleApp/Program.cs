using System.Security.Cryptography;

/*
    v1
    Iremos fazer um jogo onde o usuario tera chances de aceertar um numero aleatorio pelo sistema

    Imput (entrada de dados)
        O usuario digita um numero inteiro
    Processamento
        O sistema compara o numero digitado com um numero inteiro aleatório
    Output (Saída de dados)
        O sistema informará o usuário se o mesmo acertou ou nao, podendo incluir dicas sobre a proximidade do "chute"
*/

// 2. Nosso jogo deve gerar um número secreto aleatório
Console.WriteLine("-------------------------------------");
Console.WriteLine("Jogo de Adivinhaçao");
Console.WriteLine("-------------------------------------");

Console.WriteLine();
Console.Write("Digite um número: ");
string strnumeroDigitado = Console.ReadLine();

// 1 - 20 (numero minimo, numero maximo {exclusivo})
int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);

Console.WriteLine("O numero aleatório foi: " + numeroAleatorio);

Console.ReadLine();