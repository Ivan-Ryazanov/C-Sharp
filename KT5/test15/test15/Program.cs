using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using KT5;

namespace KT5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankTerminal terminal1 = new(0);
            BankTerminal terminal2 = new(0);
            terminal1.Deposit(5000);
            terminal1.Deposit(5000);
            terminal1.Withdraw(2500);
            terminal1.Transfer(2500, terminal2);
            terminal1.Transfer(100, terminal2); // Тут должна быть ошибка
        }
    }
}
