using System;
using System.Linq; // Biblioteca para usar funções como Average()
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
class Program
{
    static void Main()
    {
        // Parte 1: Cálculo da soma do primeiro código
        CalcularSoma();

        // Parte 2: Verificação de Fibonacci
        VerificarFibonacci();

        //Parte 3: Vetor
        VetorFaturamento();

        //Parte 4: Faturamento por Estado
        FaturamentoUF();

        //Parte 5: Inverter String
        StringInvertida();
    }

    // Questão 1

    static void CalcularSoma()
    {

        Console.WriteLine($"");
        Console.WriteLine($"------/------");
        Console.WriteLine($"DESAFIO 1:");

        int INDICE = 13, SOMA = 0, K = 0;

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine("O valor da variável SOMA é: " + SOMA);
    }

    static void VerificarFibonacci()
    {

        Console.WriteLine($"");
        Console.WriteLine($"------/------");
        Console.WriteLine($"DESAFIO 2:");

        Console.Write("\nDigite um número para verificar se pertence à sequência de Fibonacci: ");

        int numero = int.Parse(Console.ReadLine());

        if (IsFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci.");
        }
    }


    // Questão 2

    static bool IsFibonacci(int num)
    {
        int a = 0, b = 1, soma = 0;

        while (soma < num)
        {
            soma = a + b;
            a = b;
            b = soma;
        }

        return soma == num || num == 0;
    }



    // Questão 3
    static void VetorFaturamento()
    {

        Console.WriteLine($"");
        Console.WriteLine($"------/------");
        Console.WriteLine($"DESAFIO 3:");
        // Lendo o JSON
        string json = File.ReadAllText("faturamento.json");

        // Desserializando os dados do JSON
        var dados = JsonConvert.DeserializeObject<FaturamentoMensal>(json);
        double[] faturamentoDiario = dados.Faturamento;

        // Filtrando dias com faturamento > 0 (ignorando feriados e finais de semana)
        var faturamentoValido = faturamentoDiario.Where(x => x > 0).ToArray();

        // Calculando valores
        double menorFaturamento = faturamentoValido.Min();
        double maiorFaturamento = faturamentoValido.Max();
        double mediaMensal = faturamentoValido.Average();

        // Contando dias com faturamento acima da média
        int diasAcimaDaMedia = faturamentoValido.Count(x => x > mediaMensal);

        // Exibindo os resultados
        Console.WriteLine("\n--- Análise do Faturamento Diário ---");
        Console.WriteLine($"Menor faturamento: R$ {menorFaturamento}");
        Console.WriteLine($"Maior faturamento: R$ {maiorFaturamento}");
        Console.WriteLine($"Dias com faturamento acima da média mensal: {diasAcimaDaMedia}");
    }

    // Classe para desserializar JSON
    class FaturamentoMensal
    {
        public double[] Faturamento { get; set; }
    }

    // Questão 4

    static void FaturamentoUF()
    {
        Console.WriteLine($"");
        Console.WriteLine($"------/------");
        Console.WriteLine($"DESAFIO 4:");

        // Faturamento por estado
        double sp = 67836.43;
        double rj = 36678.66;
        double mg = 29229.88;
        double es = 27165.48;
        double outros = 19849.53;

        // Cálculo do faturamento total
        double faturamentoTotal = sp + rj + mg + es + outros;

        // Exibindo percentuais
        Console.WriteLine("\n--- Percentual de Representação por Estado ---");
        Console.WriteLine($"SP: {CalcularPercentual(sp, faturamentoTotal):F2}%");
        Console.WriteLine($"RJ: {CalcularPercentual(rj, faturamentoTotal):F2}%");
        Console.WriteLine($"MG: {CalcularPercentual(mg, faturamentoTotal):F2}%");
        Console.WriteLine($"ES: {CalcularPercentual(es, faturamentoTotal):F2}%");
        Console.WriteLine($"Outros: {CalcularPercentual(outros, faturamentoTotal):F2}%");
    }

    // Método para calcular percentual
    static double CalcularPercentual(double valor, double total)
    {
        return (valor / total) * 100;
    }


    // Questão 5

    static void StringInvertida()
    {

        Console.WriteLine($"");
        Console.WriteLine($"------/------");
        Console.WriteLine($"DESAFIO 5:");

        // Entrada da string pelo usuário
        Console.Write("Digite uma palavra ou frase para inverter: ");
        string input = Console.ReadLine();

        // Chamada da função para inverter a string
        string invertida = InverterString(input);

        // Exibição do resultado
        Console.WriteLine($"String invertida: {invertida}");
    }

    // Método para inverter a string manualmente
    static string InverterString(string str)
    {
        char[] caracteres = new char[str.Length]; // Array para armazenar os caracteres invertidos
        int j = 0;

        // Percorre a string de trás para frente
        for (int i = str.Length - 1; i >= 0; i--)
        {
            caracteres[j] = str[i];
            j++;
        }

        return new string(caracteres);
    }

}










