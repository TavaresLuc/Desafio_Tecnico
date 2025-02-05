using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // Execução das funções dos desafios
        CalcularSoma();
        VerificarFibonacci();
        VetorFaturamento();
        FaturamentoUF();
        StringInvertida();
    }

    // ------------------------------- DESAFIO 1 -------------------------------
    static void CalcularSoma()
    {
        Console.WriteLine("\n------/------");
        Console.WriteLine("DESAFIO 1:");

        int INDICE = 13, SOMA = 0, K = 0;

        while (K < INDICE)
        {
            K++;
            SOMA += K;
        }

        Console.WriteLine("O valor da variável SOMA é: " + SOMA);
    }

    // ------------------------------- DESAFIO 2 -------------------------------
    static void VerificarFibonacci()
    {
        Console.WriteLine("\n------/------");
        Console.WriteLine("DESAFIO 2:");

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


    // ------------------------------- DESAFIO 3 -------------------------------


    static void VetorFaturamento()
    {
        Console.WriteLine("\n------/------");
        Console.WriteLine("DESAFIO 3:");

        try
        {
            // Lendo o JSON do arquivo
            string json = File.ReadAllText("faturamento.json");

            // Desserializando diretamente para uma lista de objetos
            var dados = JsonConvert.DeserializeObject<List<FaturamentoDiario>>(json);

            if (dados == null || dados.Count == 0)
            {
                Console.WriteLine("Erro: O arquivo JSON está vazio ou não contém dados válidos.");
                return;
            }

            // Filtrando apenas os dias com faturamento > 0 (ignorando feriados e finais de semana)
            var faturamentoValido = dados.Where(d => d.Valor > 0).ToList();

            if (faturamentoValido.Count == 0)
            {
                Console.WriteLine("Nenhum dia útil com faturamento encontrado.");
                return;
            }

            // Calculando valores
            double menorFaturamento = faturamentoValido.Min(d => d.Valor);
            double maiorFaturamento = faturamentoValido.Max(d => d.Valor);
            double mediaMensal = faturamentoValido.Average(d => d.Valor);

            // Contando dias com faturamento acima da média
            int diasAcimaDaMedia = faturamentoValido.Count(d => d.Valor > mediaMensal);

            // Exibindo os resultados
            Console.WriteLine("\n--- Análise do Faturamento Diário ---");
            Console.WriteLine($"Menor faturamento: R$ {menorFaturamento:F2}");
            Console.WriteLine($"Maior faturamento: R$ {maiorFaturamento:F2}");
            Console.WriteLine($"Dias com faturamento acima da média mensal: {diasAcimaDaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar o JSON: {ex.Message}");
        }
    }

    // Classe para mapear corretamente os objetos do JSON
    class FaturamentoDiario
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }


    // ------------------------------- DESAFIO 4 -------------------------------
    static void FaturamentoUF()
    {
        Console.WriteLine("\n------/------");
        Console.WriteLine("DESAFIO 4:");

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

    // ------------------------------- DESAFIO 5 -------------------------------
    static void StringInvertida()
    {
        Console.WriteLine("\n------/------");
        Console.WriteLine("DESAFIO 5:");

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
