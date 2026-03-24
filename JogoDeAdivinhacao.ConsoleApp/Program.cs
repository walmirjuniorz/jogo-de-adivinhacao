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

        2. Implemente uma funcionalidade de Validação de Números Repetidos

            O jogador deve ser informado caso o número que está tentando adivinhar já tenha sido informado anteriormente na mesma rodada.
        3. Implemente uma funcionalidade de Pontuação, onde:

            O jogador começa com uma pontuação máxima, por exemplo, 1000 pontos.
            A pontuação é calculada com base na proximidade do palpite em relação ao número secreto.

            A cada tentativa errada, o jogador perde pontos de acordo com a distância do número secreto:
                Se a diferença entre o número secreto e o palpite for de 10 ou mais, o jogador perde 100 pontos.
                Se a diferença for entre 5 e 9, o jogador perde 50 pontos.
                Se a diferença for entre 1 e 4, o jogador perde 20 pontos.

        4. nosso jogo deve permitir múltiplas tentativas ao usúario
*/

//array

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

    int pontuacao = 1000;

    int[] numerosDigitados = new int[tentativasMaximas];
    int contadorNumerosDigitados = 0;

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

        //comparar com outros numeros na memória
        bool numeroEstaRepetido = false;
        for (int indiceAtual = 0; indiceAtual < numerosDigitados.Length; indiceAtual++)
        {
            if (numerosDigitados[indiceAtual] == numeroDigitado)
            {
                numeroEstaRepetido = true;
                break;
            }
        }

        if (numeroEstaRepetido == true)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Voce ja digitou este número, tente novamente.");
            Console.WriteLine("-------------------------------------");

            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            tentativaAtual--;
            continue;
        }

        //guardar o número na memória
        if (contadorNumerosDigitados < numerosDigitados.Length)
        {
            numerosDigitados[contadorNumerosDigitados] = numeroDigitado;
            contadorNumerosDigitados++;
        }
        else
        {
            numerosDigitados = new int[tentativasMaximas];
            contadorNumerosDigitados = 0;

            numerosDigitados[contadorNumerosDigitados] = numeroDigitado;
            contadorNumerosDigitados++;
        }

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

        int diferencaNumerica = Math.Abs(numeroAleatorio - numeroDigitado); // 90 - 100 = -10

        if (diferencaNumerica >= 10)
        {
            pontuacao -= 100;
        }
        else if (diferencaNumerica >= 5)
        {
            pontuacao -= 50;
        }
        else
        {
            pontuacao -= 20;
        }

        Console.WriteLine("-------------------------------------");
        Console.WriteLine("sua pontuaçao é: " + pontuacao);
        Console.Write("Digite ENTER para continuar...");
        Console.WriteLine("-------------------------------------");
        Console.ReadLine();
    }

    Console.Write("Deseja continuar? (s/N): ");
    string opcaoContinuar = Console.ReadLine().ToUpper();

    if (opcaoContinuar != "S")
    {
        jogoDeveContinuar = false;
    }
}
