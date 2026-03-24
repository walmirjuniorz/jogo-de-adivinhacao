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

    v2
        1. Implemente a funcionalidade de Dificuldade e Tentativas limitadas

        O jogador tem um número limitado de tentativas para adivinhar o número.
            Fácil (intervalo 1 a 20): ≈ 10 tentativas.
            Médio (intervalo 1 a 50): ≈ 5 tentativas.
         Difícil (intervalo 1 a 100): ≈ 3 tentativas.
*/

// 4. nosso jogo deve permitir múltiplas tentativas ao usúario


bool jogoDeveContinuar = true;

while (jogoDeveContinuar == true) //false
{
    Console.Clear();
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Jogo de Adivinhaçao");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Escolha um nível de dificuldade: ");
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - Médio (5 tentativas)");
    Console.WriteLine("3 - Difícil (3 tentativas)");

    Console.WriteLine("Digite sua escolha: ");
    string dificuldadeEscolhida = Console.ReadLine();

    int numeroAleatorio;
    int tentativasMaximas;

    switch (dificuldadeEscolhida) // operador do switch
    {
        case "1":
            numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);
            tentativasMaximas = 10;
            break;

        case "2":
            numeroAleatorio = RandomNumberGenerator.GetInt32(1, 51);
            tentativasMaximas = 5;
            break;

        case "3":
            numeroAleatorio = RandomNumberGenerator.GetInt32(1, 101);
            tentativasMaximas = 3;
            break;

        default:
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Por favor, selecione uma dificuldade válida");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            continue;
    }

    // enquanto a tentativa atual for menor que a qtd de tentativas maximas
    for (int tentativaAtual = 1; tentativaAtual <= tentativasMaximas; tentativaAtual++)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Jogo de Adivinhaçao");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Tentativa {tentativaAtual} de {tentativasMaximas}");
        Console.WriteLine("-------------------------------------");
        Console.Write("Digite um número: ");
        int numeroDigitado = Convert.ToInt32(Console.ReadLine());

        if (numeroDigitado == numeroAleatorio)
        {
            Console.WriteLine("Parabéns! Voce acertou! o número era " + numeroAleatorio);
            break;
        }

        else if (numeroDigitado > numeroAleatorio)
        {
            Console.WriteLine("O número digitado foi maior que o número secreto!");
        }

        else
        {
            Console.WriteLine("O número digitado foi menor que o número secreto!");
        }

        Console.WriteLine("-------------------------------------");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();

    }

    Console.Write("Deseja continuar? (s/N): ");
    string opcaoContinuar = Console.ReadLine().ToUpper();

    if (opcaoContinuar != "S")
    {
        jogoDeveContinuar = false;
    }
}
