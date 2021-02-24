using System;
using System.Collections.Generic;
using static System.Console;

namespace BankAccount
{
    
    public interface IBankAccount
    {
        void Withdraw(float amount);
        void Deposit(float amount);

        float GetBalance();
        string GetBalanceInformation();
        List<TransactionInfo> GetTransactionList();
    }
    
    public abstract class BankAccount : IBankAccount
    {
        
        public float Balance;
        public BankAccount(float balance)
        {
            
            this.Balance = balance;
        }
        public virtual void Withdraw(float amount)
        {
            this.Balance -= amount;
        }
        public virtual void Deposit (float amount)
        {
            this.Balance += amount;
        }

        public float GetBalance()
        {
            return this.Balance; 
        }

        public string GetBalanceInformation()
        {
            return this.Balance.ToString();
        }

        public List<TransactionInfo> GetTransactionList()
        {
            throw new NotImplementedException();
        }
    }
    

    class PremiumBankAccount : BankAccount
    {
        public PremiumBankAccount(int balance) : base(balance)
        {
        }
        public override void Withdraw(float amount)
        {
            base.Withdraw(amount);
        }
        public override void Deposit(float amount)
        {
            base.Deposit(amount);
        }
        
    }

    class NormalBankAccount : BankAccount 
    {
        public NormalBankAccount(int balance) : base(balance)
        {
        }
        public override void Withdraw(float amount)
        {
            int DebitFee = 250;
            base.Withdraw(amount + DebitFee);
        }
        public override void Deposit(float amount)
        {
            base.Deposit(amount);
        }

        class Program
        {
            static void Main(string[] args)
            {
                PremiumBankAccount PremiumCostumer = new PremiumBankAccount(1000);
                NormalBankAccount NormalCostumer = new NormalBankAccount(1000);
                PremiumCostumer.Withdraw(100);
                NormalCostumer.Withdraw(400);

               float currentSaldo =  PremiumCostumer.GetBalance();
                string BalanceInformation = PremiumCostumer.GetBalanceInformation();
                float CurrentSaldoNormal = NormalCostumer.GetBalance();
                string NormalBalanceInformation = NormalCostumer.GetBalanceInformation();

                WriteLine(
                    "Premium kundens saldo " + BalanceInformation + "\nNormal Kundens Saldo " + NormalBalanceInformation);
                ReadKey();
            }
        }
    }
}
