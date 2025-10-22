﻿using BarberBoss.Communication.Enums;
using System.ComponentModel.DataAnnotations;

namespace BarberBoss.Communication.Request
{
    public class InvoiceRequest
    {
       
        public DateOnly Date { get; set; }       
        public string BarberName { get; set; } = string.Empty;      
        public string ClientName { get; set; } = string.Empty;      
        public string ServiceName { get; set; } = string.Empty;      
        public decimal Amount { get; set; }     
        public PaymentMethod PaymentMethod { get; set; }       
        public InvoiceStatus Status { get; set; }      
        public string? Notes { get; set; }
    }
}
