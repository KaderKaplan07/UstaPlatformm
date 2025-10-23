using System;
using System.Collections.Generic;
using UstaPlatform.Domain.Entities;

namespace UstaPlatform.Domain.Collections
{
    public class Schedule
    {
        private readonly Dictionary<DateOnly, List<IsEmri>> _workOrders = new();

        // Bu, Dizinleyici (Indexer) özelliğidir
        public List<IsEmri> this[DateOnly gun]
        {
            get
            {
                if (!_workOrders.ContainsKey(gun))
                {
                    _workOrders[gun] = new List<IsEmri>();
                }
                return _workOrders[gun];
            }
        }

        public void AddWorkOrder(IsEmri order)
        {
            DateOnly gun = DateOnly.FromDateTime(order.PlanlananTarih);
            this[gun].Add(order); // Dizinleyiciyi burada kullanıyoruz
        }
    }
}
