using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFListViewSamples.Common;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages.HeaderAndFooter
{
    public class ListViewFooterViewModel : BaseViewModel
    {
        public List<IncomeExpenseModel> incomeExpenses = new List<IncomeExpenseModel>();
        public List<IncomeExpenseModel> IncomeExpenses
        {
            get { return incomeExpenses; }
            set { SetProperty(ref incomeExpenses, value); }
        }

        private int totalIncome;
        public int TotalIncome
        {
            get { return totalIncome; }
            set { SetProperty(ref totalIncome, value); }
        }

        private int totalExpense;
        public int TotalExpense
        {
            get { return totalExpense; }
            set { SetProperty(ref totalExpense, value); }
        }

        private int totalSavings;
        public int TotalSavings
        {
            get { return totalSavings; }
            set { SetProperty(ref totalSavings, value); }
        }

        private double expensePercentage;
        public double ExpensePercentage
        {
            get { return expensePercentage; }
            set { SetProperty(ref expensePercentage, value); }
        }

        private double savingsPercentage;
        public double SavingsPercentage
        {
            get { return savingsPercentage; }
            set { SetProperty(ref savingsPercentage, value); }
        }

        bool isItemsLoaded = false;
        public bool IsItemsLoaded
        {
            get { return isItemsLoaded; }
            set { SetProperty(ref isItemsLoaded, value); }
        }


        public ListViewFooterViewModel()
        {
            IsItemsLoaded = false;

            Task.Run(async () =>
            {
                var incomeExpenseData = new IncomeExpenseDataService();
                IncomeExpenses = (await incomeExpenseData.GetItemsAsync(1, 50)).ToList();

                TotalExpense = IncomeExpenses.Sum(x => x.Expense);
                TotalIncome = IncomeExpenses.Sum(x => x.Income);
                TotalSavings = TotalIncome - TotalExpense;

                ExpensePercentage = ((double)TotalExpense / (double)TotalIncome) * 100;
                SavingsPercentage = 100 - ExpensePercentage;
                IsItemsLoaded = true;
            });
        }
    }
}
