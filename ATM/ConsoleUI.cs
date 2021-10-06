﻿using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM.Services
{
    public class ConsoleUI
    {
        public static (string, string, AccountType) getDataForAccountCreation()
        {
            string name;
            int pin;
            AccountType accountType;
            Console.WriteLine("\n____ACCOUNT CREATION____\n");
            Console.Write("Please Enter your name : ");
            string selectedName = Console.ReadLine();
            if (String.IsNullOrEmpty(selectedName))
            {
                Console.WriteLine("Invalid Name");
                return (null, null, (AccountType)0);
            }
            name = selectedName;

            Console.Write("Please set a 4-digit PIN : ");
            string selectedPin = Console.ReadLine();

            if (selectedPin.Length != 4)
            {
                Console.WriteLine("Invalid PIN");
                return (null, null, (AccountType)0);
            }

            try
            {
                pin = Convert.ToInt32(selectedPin);
            }
            catch
            {
                Console.WriteLine("Invalid PIN");
                return (null, null, (AccountType)0);
            }

            Console.WriteLine("\n__ACCOUNT TYPE__\n");
            int i = 1;
            foreach (string type in Enum.GetNames(typeof(AccountType)))
            {
                Console.WriteLine(i + ". " + type);
                i++;
            }
            Console.Write("\nSelect an Account type : ");
            string selectedType = Console.ReadLine();

            try
            {
                accountType = (AccountType)Convert.ToInt32(selectedType);
                if ((int)accountType <= 0 || (int)accountType >= i)
                {
                    Console.WriteLine("Invalid Account Type");
                    return (null, null, (AccountType)0);
                }
            }
            catch
            {
                Console.WriteLine("Invalid Account Type");
                return (null, null, (AccountType)0);
            }

            return (name, Convert.ToString(pin), accountType);

        }

        public static Account selectAccount(List<Account> accounts)
        {
            Console.WriteLine("\n____ALL ACCOUNTS____\n");
            foreach (Account acc in accounts)
            {
                Console.WriteLine(acc.accountNumber + ". " + acc.accountHoldersName);
            }
            Console.Write("\nSelect your account : ");
            string choice = Console.ReadLine();
            try
            {
                int selectedaccountNumber = Convert.ToInt32(choice);
                Account selectedAccount = accounts.FirstOrDefault(acc => acc.accountNumber == selectedaccountNumber);
                return selectedAccount;
            }
            catch
            {
                return null;
            }
        }

        public static decimal getAmount(char amtFor)
        {
            decimal amount;
            switch (amtFor)
            {
                case 'd':
                    Console.WriteLine("\n____DEPOSIT____\n");
                    Console.Write("Enter Amount to be deposited : ");
                    break;
                case 'w':
                    Console.WriteLine("\n____WITHDRAW____\n");
                    Console.Write("Enter Amount to be withdrawn : ");
                    break;
                case 't':
                    Console.WriteLine("\n\n____TRANSFER____\n");
                    Console.Write("Enter Amount to be transferred : ");
                    break;
            }
            string userInput = Console.ReadLine();
            try
            {
                amount = decimal.Parse(userInput);
            }
            catch
            {
                amount = -1;
            }
            return amount;
        }

        public static string getPinFromUser()
        {
            Console.WriteLine("\n____AUTHENTICATION____\n");
            Console.Write("Enter PIN : ");
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static Account selectTransferToAccount(int fromAccNo, List<Account> accounts)
        {
            Account selectedAccount;
            Console.WriteLine();
            foreach (Account acc in accounts)
            {
                if (fromAccNo != acc.accountNumber)
                {
                    Console.WriteLine(acc.accountNumber + ". " + acc.accountHoldersName);
                }
            }
            Console.Write("Select an Account to transfer money to : ");
            string userInput = Console.ReadLine();
            try
            {
                int selectedaccountNumber = int.Parse(userInput);
                if (selectedaccountNumber > 0 && selectedaccountNumber <= accounts.Count && selectedaccountNumber != fromAccNo)
                {
                    selectedAccount = accounts[selectedaccountNumber - 1];
                }
                else
                {
                    selectedAccount = null;
                    StandardMessages.invalidOptionMsg();
                }
            }
            catch
            {
                selectedAccount = null;
                StandardMessages.invalidOptionMsg();
            }
            return selectedAccount;
        }

        public static void printTransactions(List<Transaction> transactions, decimal availBal)
        {
            Console.WriteLine("\n____TRANSACTION HISTORY____\n");
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction.timeStamp + "\t" + transaction.transactionType + "\tRs. " + transaction.transactionAmount);
            }
            Console.WriteLine("\t\tAvailable Balance : " + availBal);
        }

        public static string existingOrCreate()
        {
            Console.WriteLine("\n____ATM____\n");
            Console.WriteLine("1. Create New Account\n2. Exixting User");
            Console.Write("\nSelect an Option (Enter 'e' to exit) : ");
            string option = Console.ReadLine();
            return option;
        }

        public static string selectOperation()
        {
            Console.WriteLine("\n____OPERATIONS____\n");
            Console.WriteLine("1. Deposit\n2. Withdraw\n3. Transfer\n4. Show Transaction History");
            Console.Write("\nSelect an operation (Enter 'b' to go back) : ");
            string operation = Console.ReadLine();
            return operation;
        }
    }
}
