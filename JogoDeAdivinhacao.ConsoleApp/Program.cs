using System.Reflection;
using System.Runtime.InteropServices;
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

// 4. nosso jogo deve permitir múltiplas tentativas ao usúario
int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);

bool jogoDeveContinuar = true;

while (jogoDeveContinuar == true) //false
{
    Console.Clear();
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Jogo de Adivinhaçao");
    Console.WriteLine("-------------------------------------");

    Console.WriteLine();
    Console.Write("Digite um número: ");

    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

    if (numeroDigitado == numeroAleatorio)
    {
        Console.WriteLine("Parabéns! Voce acertou! o número era " + numeroAleatorio);
    }

    else if (numeroDigitado > numeroAleatorio)
    {
        Console.WriteLine("O número digitado foi maior que o número secreto!");
    }

    else
    {
        Console.WriteLine("O número digitado foi menor que o número secreto!");
    }

    Console.WriteLine();
    Console.Write("Deseja continuar? (s/N): ");
    string opcaoContinuar = Console.ReadLine().ToUpper();

    if (opcaoContinuar != "S")
    {
        jogoDeveContinuar = false;
    }
}
