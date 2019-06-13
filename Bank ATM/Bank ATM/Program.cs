﻿using System;

namespace Bank_ATM
{
    public class Program
    {
        public static double balance = 5000.00;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mocking Bird Bank ATM");

            try
            {
                UserInterface();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thank you for using Mocking Bird Bank.");
            }
        }

        static void UserInterface()
        {
            Console.WriteLine("Please choose from one of the following options:");
            Console.WriteLine("1) View Balance");
            Console.WriteLine("2) Withdraw Money");
            Console.WriteLine("3) Deposit Money");
            Console.WriteLine("4) Exit");

            string userSelection = Console.ReadLine();
            int actionSelection = Convert.ToInt32(userSelection);

            switch (actionSelection)
            {
                case 1:
                    ViewBalance();
                    AdditionalTransaction();
                    break;
                case 2:
                    WithdrawMoney(WithdrawRequest());
                    AdditionalTransaction();
                    break;
                case 3:
                    DepositMoney();
                    AdditionalTransaction();
                    break;
                case 4:
                    Exit();
                    break;
                default:
                    Exit();
                    break;
            }
        }

        static void ViewBalance()
        {
            Console.WriteLine($"The current balance is: {balance}");

        }

        public static double WithdrawMoney(double approvedWithdrawAmount)
        {
            if(approvedWithdrawAmount > balance)
            {
                approvedWithdrawAmount = 0;
                balance = balance - approvedWithdrawAmount;
                return balance;
            }
            else
            {
                balance = balance - approvedWithdrawAmount;
                return balance;
            }   
        }

        static double WithdrawRequest()
        {
            double withdrawAmount = ConfirmTransactionAmount("withdrawal");

            if (withdrawAmount > balance)
            {
                Console.WriteLine("Unable to withdraw more than current balance.");
                return withdrawAmount = 0;
            }
            else
            { 
                return withdrawAmount;
            }
        }

        public static double DepositMoney()
        {

        }


        static double DepositRequest()
        {
            double depositAmount = ConfirmTransactionAmount("deposit");

            if (depositAmount < 0)
            {
                Console.WriteLine("Unable to deposit a negative amount.");
                return depositAmount = 0;
            }
            else
            {
                return depositAmount;
            }
        }


        static void Exit()
        {
            Environment.Exit(0);
        }

        static void AdditionalTransaction()
        {
            Console.WriteLine("Would you like to conduct another transaction? (Y/N)");

            string userResponse = Console.ReadLine();
            string userDecision = userResponse.ToUpper();

            if(userDecision == "Y")
            {
                UserInterface();
            }
            else if(userDecision == "N")
            {
                Exit();
            }
            else
            {
                UserInterface();
            }
        }

        static double ConfirmTransactionAmount(string transcationType)
        {
            Console.WriteLine($"Please enter a dollar amount to {transcationType}");

            try
            {
                string amount = Console.ReadLine();
                double transactionAmount = Convert.ToDouble(amount);
                return transactionAmount;
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw;
            }

            
        }
    }
}
