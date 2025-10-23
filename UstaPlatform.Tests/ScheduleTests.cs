// UstaPlatform.Tests/ScheduleTests.cs
using System;
using UstaPlatform.Domain.Collections;
using UstaPlatform.Domain.Entities;
using Xunit; // xUnit kütüphanesi

namespace UstaPlatform.Tests
{
    public class ScheduleTests
    {
        [Fact] // Bu, bir test metodu olduðunu belirtir
        public void Indexer_ShouldReturnCorrectListOfWorkOrders_ForAGivenDate()
        {
            // 1. Arrange (Hazýrlýk)
            var schedule = new Schedule();
            var testDate = new DateOnly(2025, 10, 25);
            var testOrder = new IsEmri
            {
                ID = 1,
                PlanlananTarih = new DateTime(2025, 10, 25)
                // Diðer property'ler test için önemli deðil
            };

            // 2. Act (Eylem)
            schedule.AddWorkOrder(testOrder);

            // Dizinleyiciyi burada test ediyoruz
            var gununIsleri = schedule[testDate];

            // 3. Assert (Doðrulama)
            Assert.NotNull(gununIsleri); // Listenin boþ (null) olmadýðýný doðrula
            Assert.Single(gununIsleri); // Listenin içinde 1 eleman olduðunu doðrula
            Assert.Equal(1, gununIsleri[0].ID); // O elemanýn bizim eklediðimiz iþ emri olduðunu doðrula
        }

        [Fact]
        public void Indexer_ShouldReturnEmptyList_ForADateWithNoWorkOrders()
        {
            // 1. Arrange
            var schedule = new Schedule();
            var testDate = new DateOnly(2025, 11, 1);

            // 2. Act
            var gununIsleri = schedule[testDate]; // Hiç iþ eklemedik

            // 3. Assert
            Assert.NotNull(gununIsleri); // Liste null olmamalý
            Assert.Empty(gununIsleri);   // Liste boþ olmalý
        }
    }
}