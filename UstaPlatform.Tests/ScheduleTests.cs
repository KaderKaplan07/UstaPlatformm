// UstaPlatform.Tests/ScheduleTests.cs
using System;
using UstaPlatform.Domain.Collections;
using UstaPlatform.Domain.Entities;
using Xunit; // xUnit k�t�phanesi

namespace UstaPlatform.Tests
{
    public class ScheduleTests
    {
        [Fact] // Bu, bir test metodu oldu�unu belirtir
        public void Indexer_ShouldReturnCorrectListOfWorkOrders_ForAGivenDate()
        {
            // 1. Arrange (Haz�rl�k)
            var schedule = new Schedule();
            var testDate = new DateOnly(2025, 10, 25);
            var testOrder = new IsEmri
            {
                ID = 1,
                PlanlananTarih = new DateTime(2025, 10, 25)
                // Di�er property'ler test i�in �nemli de�il
            };

            // 2. Act (Eylem)
            schedule.AddWorkOrder(testOrder);

            // Dizinleyiciyi burada test ediyoruz
            var gununIsleri = schedule[testDate];

            // 3. Assert (Do�rulama)
            Assert.NotNull(gununIsleri); // Listenin bo� (null) olmad���n� do�rula
            Assert.Single(gununIsleri); // Listenin i�inde 1 eleman oldu�unu do�rula
            Assert.Equal(1, gununIsleri[0].ID); // O eleman�n bizim ekledi�imiz i� emri oldu�unu do�rula
        }

        [Fact]
        public void Indexer_ShouldReturnEmptyList_ForADateWithNoWorkOrders()
        {
            // 1. Arrange
            var schedule = new Schedule();
            var testDate = new DateOnly(2025, 11, 1);

            // 2. Act
            var gununIsleri = schedule[testDate]; // Hi� i� eklemedik

            // 3. Assert
            Assert.NotNull(gununIsleri); // Liste null olmamal�
            Assert.Empty(gununIsleri);   // Liste bo� olmal�
        }
    }
}