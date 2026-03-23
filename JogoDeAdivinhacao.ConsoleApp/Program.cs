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

// 1. Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
Console.WriteLine("-------------------------------------");
Console.WriteLine("Jogo de Adivinhacao");
Console.WriteLine("-------------------------------------");

Console.WriteLine();
Console.Write("Digite um número: ");
string strnumeroDigitado = Console.ReadLine();

Console.WriteLine("O numero digitado foi: " + strnumeroDigitado);

Console.ReadLine();