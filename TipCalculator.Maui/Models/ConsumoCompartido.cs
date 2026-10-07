namespace TipCalculator.Maui.Models
{
    public class ConsumoCompartido
    {
        private decimal _importeDelConsumo;
        private decimal _porcentajeDePropina;
        private int _numeroDePersonas;

        public decimal ImportePropina
            => _importeDelConsumo * _porcentajeDePropina / 100.0m;
        public decimal ImporteDelConsumoConPropina
            => _importeDelConsumo + ImportePropina;
        public decimal ImporteDelConsumoPorPersona
            => _importeDelConsumo / _numeroDePersonas;
        public decimal ImportePropinaPorPersona
            => ImportePropina / _numeroDePersonas;
        public decimal ImporteDelConsumoConPropinaPorPersona
            => ImporteDelConsumoConPropina / _numeroDePersonas;


        public ConsumoCompartido(
            decimal consumo, 
            decimal porcentajeDePropina, 
            int numeroDePersonas = 1)
        {
            _importeDelConsumo = consumo;
            _porcentajeDePropina = porcentajeDePropina;
            _numeroDePersonas = numeroDePersonas;
        }


    }
}
