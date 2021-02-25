using System;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace BankAccount
{
    public class TransactionInfo
    {
        public TransactionInfo(float Out_Withdraw, float In_Deposit)
        {
           this.Withdraw = Out_Withdraw;
           this.Deposit = In_Deposit;
           this.TimeStamps = DateTime.Now;
        }

       public float Withdraw { get; set; }
       public float Deposit { get; set; }
       public override string ToString()
        {
            return null;
        }
       public DateTime TimeStamps { get; set; }
        
    }
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
       protected List<TransactionInfo> TS = new List<TransactionInfo>();
        public float Balance;
        public BankAccount(float balance)
        {
            
            this.Balance = balance;
        }
        public virtual void Withdraw(float amount)
        {
            this.Balance -= amount;
            TS.Add(new TransactionInfo(amount, 0));
            
           
            
        }
        public virtual void Deposit (float amount)
        {
            this.Balance += amount;
            TS.Add(new TransactionInfo(0, amount));
            
            
            
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

            return TS; 
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
            TS.Add(new TransactionInfo(0, amount));
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
            TS.Add(new TransactionInfo(amount + DebitFee,0));
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
                var test = PremiumCostumer.GetTransactionList();
                WriteLine(
                    "Premium kundens saldo " + BalanceInformation + "\nNormal Kundens Saldo " + NormalBalanceInformation + "\n" + test);
                ReadKey();
            }
        }
    }
}
