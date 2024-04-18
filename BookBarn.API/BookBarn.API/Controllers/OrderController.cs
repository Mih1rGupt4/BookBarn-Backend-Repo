using BookBarn.API.Models.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookBarn.API.Controllers
{
    public class OrderController : ApiController
    {
        public static List<Order> orders = new List<Order>
{

    new Order
    {
        Id = 1,
        OrderDate = DateTime.Parse("2024-04-01"),
        ShippingAddress = new Address { Street = "123 Main St", City = "City A", State = "State A", PostalCode = "12345", Country = "Country A" },
        PaymentDetails = new PaymentDetails { Amount = 50.25, TransactionId = "trans_123", PaymentSource = "Credit Card" },
        User = new Usertemp { Id = 1, UserName = "userA" },
        Books = new List<Booktemp> { new Booktemp { Id = 1, BookTitle = "Book 1" }, new Booktemp { Id = 2, BookTitle = "Book 2" } },
        Status = OrderStatus.Ordered
    },
    new Order
    {
        Id = 2,
        OrderDate = DateTime.Parse("2024-04-02"),
        ShippingAddress = new Address { Street = "456 Elm St", City = "City B", State = "State B", PostalCode = "23456", Country = "Country B" },
        PaymentDetails = new PaymentDetails { Amount = 75.50, TransactionId = "trans_456", PaymentSource = "PayPal" },
        User = new Usertemp { Id = 2, UserName = "userB" },
        Books = new List<Booktemp> { new Booktemp { Id = 3, BookTitle = "Book 3" }, new Booktemp { Id = 4, BookTitle = "Book 4" } },
        Status = OrderStatus.Dispatched
    },
    new Order
    {
        Id = 3,
        OrderDate = DateTime.Parse("2024-04-03"),
        ShippingAddress = new Address { Street = "789 Oak St", City = "City C", State = "State C", PostalCode = "34567", Country = "Country C" },
        PaymentDetails = new PaymentDetails { Amount = 100.00, TransactionId = "trans_789", PaymentSource = "Debit Card" },
        User = new Usertemp { Id = 3, UserName = "userC" },
        Books = new List<Booktemp> { new Booktemp { Id = 5, BookTitle = "Book 5" }, new Booktemp { Id = 6, BookTitle = "Book 6" } },
        Status = OrderStatus.Packed
    },
    new Order
    {
        Id = 4,
        OrderDate = DateTime.Parse("2024-04-04"),
        ShippingAddress = new Address { Street = "1011 Pine St", City = "City D", State = "State D", PostalCode = "45678", Country = "Country D" },
        PaymentDetails = new PaymentDetails { Amount = 125.75, TransactionId = "trans_1011", PaymentSource = "Bank Transfer" },
        User = new Usertemp { Id = 4, UserName = "userD" },
        Books = new List<Booktemp> { new Booktemp { Id = 7, BookTitle = "Book 7" }, new Booktemp { Id = 8, BookTitle = "Book 8" } },
        Status = OrderStatus.OnTheWay
    },
    new Order
    {
        Id = 5,
        OrderDate = DateTime.Parse("2024-04-13"),
        ShippingAddress = new Address { Street = "1315 Cedar St", City = "City M", State = "State M", PostalCode = "13131", Country = "Country M" },
        PaymentDetails = new PaymentDetails { Amount = 200.50, TransactionId = "trans_1315", PaymentSource = "Credit Card" },
        User = new Usertemp { Id = 13, UserName = "userM" },
        Books = new List<Booktemp> { new Booktemp { Id = 19, BookTitle = "Book 19" }, new Booktemp { Id = 20, BookTitle = "Book 20" } },
        Status = OrderStatus.ReturnCompleted
    },
    new Order
    {
        Id = 6,
        OrderDate = DateTime.Parse("2024-04-14"),
        ShippingAddress = new Address { Street = "1416 Maple St", City = "City N", State = "State N", PostalCode = "14141", Country = "Country N" },
        PaymentDetails = new PaymentDetails { Amount = 215.25, TransactionId = "trans_1416", PaymentSource = "PayPal" },
        User = new Usertemp { Id = 14, UserName = "userN" },
        Books = new List<Booktemp> { new Booktemp { Id = 21, BookTitle = "Book 21" }, new Booktemp { Id = 22, BookTitle = "Book 22" } },
        Status = OrderStatus.ReplacedRequested
    }
};

    }
}
