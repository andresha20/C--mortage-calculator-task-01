using static System.Console;
using System;

namespace mortgageCalculator
{
    internal class Program
    {
        public const int MONTHS_IN_A_YEAR = 12;
        static void Main(string[] args) {
            double loan = 10;
            float annualInterestRate = 0.04F;
            int years = 2;
            String outputChatbox;
            try {
                outputChatbox = "What's the loan amount?";
                WriteLine(outputChatbox);
                loan = double.Parse(ReadLine());
                outputChatbox = "What's the annual interest rate?";
                WriteLine(outputChatbox);
                annualInterestRate = float.Parse(ReadLine());
                outputChatbox = "Term in years?";
                WriteLine(outputChatbox);
                years = int.Parse(ReadLine());
            } catch (Exception e) {
                outputChatbox = "Something went wrong. Insert a valid value.";
                WriteLine(outputChatbox);
                Environment.Exit(-1);
            }
            if (loan == 0 || annualInterestRate == 0 || years == 0) {
                outputChatbox = "You cannot insert empty or 0 values.";
                WriteLine(outputChatbox);
                Environment.Exit(-1);
            }
            float monthlyInterestRate = annualInterestRate / MONTHS_IN_A_YEAR;
            int numberOfMonthlyPayments = years * MONTHS_IN_A_YEAR;
            double discountRate = Math.Pow(1 + monthlyInterestRate, numberOfMonthlyPayments);
            double mortgage = loan * ((monthlyInterestRate * discountRate) / (discountRate - 1));
            outputChatbox = $"Your mortgage value is: {mortgage:C}";
            WriteLine(outputChatbox);
            outputChatbox = $"Payback: {numberOfMonthlyPayments * mortgage:C}";
            WriteLine(outputChatbox);
            outputChatbox = "Success! Closing...";
            WriteLine(outputChatbox);
            Environment.Exit(-1);
        }
    }
}
