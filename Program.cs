using System;

class JogoDaVelha
{
    static char[,] tabuleiro = {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'}
    };

    static char jogadorAtual = 'X'; // jogador 1 = 'X', jogador 2 = 'O'

    public static void Main(string[] args)
    {
        int movimentos = 0;
        bool jogoEncerrado = false;

        while (!jogoEncerrado)
        {
            Console.Clear();
            ExibirTabuleiro(); 
            Console.WriteLine($"Vez do jogador {jogadorAtual}. Escolha uma posição disponível:");

            string entrada = Console.ReadLine();
            if (FazerJogada(entrada))
            {
                movimentos++; // incrementa a quantidade de movimentos para posteriormente facilitar a verificação do empate
                if (VerificarVitoria())
                {
                    Console.Clear();
                    ExibirTabuleiro();
                    Console.WriteLine($"Jogador {jogadorAtual} venceu!");
                    jogoEncerrado = true;
                }
                else if (movimentos == 9) // verifica se empatou
                {
                    Console.Clear();
                    ExibirTabuleiro();
                    Console.WriteLine("Empate!");
                    jogoEncerrado = true;
                }
                else
                {
                    // alterna entre os jogadores 'X' e 'O'
                    jogadorAtual = (jogadorAtual == 'X') ? 'O' : 'X'; 
                }
            }
            else
            {
                Console.WriteLine("Jogada inválida! Tente novamente.");
                Console.ReadKey();
            }
        }
    }

    static void ExibirTabuleiro()
    {
        Console.WriteLine("-------------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(tabuleiro[i, j] + " | ");
            }
            Console.WriteLine("\n-------------");
        }
    }

    static bool FazerJogada(string entrada)
    {
        // percorre a matriz para encontrar a posição escolhida pelo jogador
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tabuleiro[i, j].ToString() == entrada)
                {
                    tabuleiro[i, j] = jogadorAtual;
                    return true;
                }
            }
        }
        return false;
    }

    static bool VerificarVitoria()
    {
        for (int i = 0; i < 3; i++)
        {
            // verifica linhas e colunas
            if ((tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2]) || 
                (tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i]))
            {
                return true;
            }
        }
        // verifica diagonais
        if ((tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2]) || 
            (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0]))
        {
            return true;
        }
        return false;
    }
}
