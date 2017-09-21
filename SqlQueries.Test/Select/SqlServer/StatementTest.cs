using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlQueries.Parts;

namespace SqlQueries.Test.Select.SqlServer
{
    [TestClass]
    public class StatementTest
    {
        #region Conditions

        private const string ConditionExpected = "SELECT [Orders].[OrderID], [Customers].[CustomerName] FROM [Orders] INNER JOIN [Customers] ON [Orders].[CustomerID] = [Customers].[CustomerID] WHERE [Customers].[Country] = @p0 GROUP BY [Orders].[OrderID], [Customers].[CustomerName] HAVING AVG([Order].[Amount]) > @p1 ORDER BY [Customers].[CustomerName], [Orders].[OrderID]";

        [TestMethod]
        public void FluentConditions()
        {
            string statement = new SqlQueries.Select()
                .Columns("Orders.OrderID, Customers.CustomerName").From("Orders")
                .Join("Customers", JoinType.Inner, "Orders.CustomerID", "Customers.CustomerID")
                .Where("Customers.Country", "Germany")
                .GroupBy("Orders.OrderID, Customers.CustomerName")
                .OrderBy("Customers.CustomerName, Orders.OrderID")
                .Having(new Average("Order.Amount"), SqlOperator.GreaterThan, 500)  
                .ToString();

            Assert.AreEqual(ConditionExpected, statement);
        }

        [TestMethod]
        public void FluentConditions2()
        {
            string statement = new SqlQueries.Select()
                .Columns("Orders.OrderID, Customers.CustomerName").From("Orders")
                .Join("Customers", JoinType.Inner).Equal("Orders.CustomerID", "Customers.CustomerID")
                .Where().EqualToValue("Customers.Country", "Germany")
                .GroupBy("Orders.OrderID, Customers.CustomerName")
                .OrderBy("Customers.CustomerName, Orders.OrderID")
                .Having().GreaterThanValue(new Average("Order.Amount"), 500)
                .ToString();

            Assert.AreEqual(ConditionExpected, statement);
        }

        #endregion
    }
}
