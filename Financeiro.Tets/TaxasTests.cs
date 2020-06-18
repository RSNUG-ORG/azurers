using Financeiro;
using Xunit;

namespace Refactoring.Financial
{
    public class TaxasTests
    {
        private Taxas _taxa = new Taxas();

        [Fact]
        public void ShouldReturnNegativeTax()
        {
            Assert.Equal(-16.211412M, _taxa.CalcularTaxaJuros(15000, 500, 10));    
        }

        [Fact]
        public void ShouldReturnPositiveTax()
        {
            Assert.Equal(5.604464M, _taxa.CalcularTaxaJuros(15000, 2000, 10));    
        }
            

        //Testar casos limitrofes
    }
}