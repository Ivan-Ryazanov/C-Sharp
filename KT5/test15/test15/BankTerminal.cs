using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT5
{
    public class BankTerminal
    {
        private float _balanse;
        private int _numberOfTransactions = 0;

        public BankTerminal(int balanse)
        {
            _balanse = balanse;
        }

        public void Deposit(float sum) // Вносит средства.
        {

            _balanse += sum;
            _numberOfTransactions += 1;
            Console.WriteLine($"На счет поступила сумма в размере {sum} руб.");
        }

        public void Withdraw(int sum) // Снимает средства.
        {
            if (_numberOfTransactions == 5)
            {
                throw new LimitExceededException("Превышен лимит операций!");
            }
            else if (sum < 0)
            {
                throw new InvalidSumException("Отрицательная сумма!");
            }
            else if (_balanse <= sum)
            {
                throw new InsufficientFundsException("На счете недостаточно средств для списания!");
            }
            else
            {
                _balanse -= sum;
                _numberOfTransactions += 1;
                Console.WriteLine($"Со счета снялась сумма в размере {sum} руб.");
            } 
        }

        public void Transfer(int sum, BankTerminal terminal) // Переводит средства.
        {
            if (_numberOfTransactions == 5)
            {
                throw new LimitExceededException("Превышен лимит операций!");
            }
            else if (sum < 0)
            {
                throw new InvalidSumException("Отрицательная сумма!");
            }
            else if (_balanse <= sum)
            {
                throw new InsufficientFundsException("На счете недостаточно средств для списания!");
            }
            else
            {
                terminal.Deposit(sum);
                Withdraw(sum);
                _numberOfTransactions += 1;
                Console.WriteLine($"Со счета был выполнен перевод в размере {sum} руб.");
            }
        }
    }

    public class InvalidSumException : Exception 
        // Проверка на положительное целое число.
    {
        public InvalidSumException(string message) : base(message) { }
    }

    public class InsufficientFundsException : Exception 
        // Проверка на баланс (сумма списания < баланса)
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class LimitExceededException : Exception 
        // Проверка на кол-во операций, не больше 5 штук на счет.
    {
        public LimitExceededException(string message) : base(message) { }
    }
}