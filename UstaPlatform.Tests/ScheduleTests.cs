
using System;
using UstaPlatform.Domain.Collections;
using UstaPlatform.Domain.Entities;
using Xunit; 

namespace UstaPlatform.Tests
{
    public class ScheduleTests
    {
        public void Indexer_ShouldReturnCorrectListOfWorkOrders_ForAGivenDate()
        {
            var schedule = new Schedule();
            var testDate = new DateOnly(2025, 10, 25);
            var testOrder = new IsEmri
            {
                ID = 1,
                PlanlananTarih = new DateTime(2025, 10, 25)
            };

            schedule.AddWorkOrder(testOrder);

            var gununIsleri = schedule[testDate];

            Assert.NotNull(gununIsleri); 
            Assert.Single(gununIsleri); 
            Assert.Equal(1, gununIsleri[0].ID); 
        }

        [Fact]
        public void Indexer_ShouldReturnEmptyList_ForADateWithNoWorkOrders()
        {
            var schedule = new Schedule();
            var testDate = new DateOnly(2025, 11, 1);

            var gununIsleri = schedule[testDate]; 

            Assert.NotNull(gununIsleri);
            Assert.Empty(gununIsleri);  
        }
    }
}