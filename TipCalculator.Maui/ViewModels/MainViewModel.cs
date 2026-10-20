using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TipCalculator.Maui.Models;

namespace TipCalculator.Maui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private ConsumoCompartido _consumo;
        [ObservableProperty]
        private string _importeDelConsumo = string.Empty;
        [ObservableProperty]
        private string _numeroDePersonas = "1";
        [ObservableProperty]
        private string _porcentajeDePropina = "10";
        [ObservableProperty]
        private string _importeConsumoPorPersona = string.Empty;
        [ObservableProperty]
        private string _importePropina = string.Empty;
        [ObservableProperty]
        private string _importePropinaPorPersona = string.Empty;
        [ObservableProperty]
        private string _importeConsumoConPropina = string.Empty;
        [ObservableProperty]
        private string _importeConsumoConPropinaPorPersona = string.Empty;

        public MainViewModel()
        {
            _consumo = new ConsumoCompartido(0.0m, 10.0m);
            //CalcularCommand = new Command(CalcularPropina);
            //LimpiarCommand = new Command(LimpiarDatos);
            //PorcentajeDePropinaCommand = 
            //    new Command<string>(ActualizarPorcentajeDePropina);
        }

        [RelayCommand]
        private void Calcular()
        {
            bool consumoEsValido = false;
            bool numeroDePersonasEsValido = false;
            bool porcentajeDePropinaEsValido = false;
            decimal importeDelConsumo;
            int numeroDePersonas;
            decimal porcentajeDePropina;
            consumoEsValido = decimal
                .TryParse(ImporteDelConsumo, out importeDelConsumo);
            numeroDePersonasEsValido = int
                .TryParse(NumeroDePersonas, out numeroDePersonas);
            porcentajeDePropinaEsValido = decimal
                .TryParse(PorcentajeDePropina, out porcentajeDePropina);
            if (consumoEsValido 
                && numeroDePersonasEsValido 
                && porcentajeDePropinaEsValido)
            {
                _consumo = new ConsumoCompartido(
                    importeDelConsumo, porcentajeDePropina, numeroDePersonas);
                ImporteConsumoPorPersona = _consumo
                    .ImporteDelConsumoPorPersona.ToString("F2");
                //ImporteDelConsumo = _consumo.ImporteDelConsumo.ToString("F2");
                ImportePropina = _consumo.ImportePropina.ToString("F2");
                ImportePropinaPorPersona = _consumo
                    .ImportePropinaPorPersona.ToString("F2");
                ImporteConsumoConPropina = _consumo
                    .ImporteDelConsumoConPropina.ToString("F2");
                ImporteConsumoConPropinaPorPersona = _consumo
                    .ImporteDelConsumoConPropinaPorPersona.ToString("F2");
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            ImporteDelConsumo = string.Empty;
            NumeroDePersonas = "1";
            PorcentajeDePropina = "10";

            ImporteConsumoPorPersona = string.Empty;
            ImportePropina = string.Empty;
            ImportePropinaPorPersona = string.Empty;
            ImporteConsumoConPropina = string.Empty;
            ImporteConsumoConPropinaPorPersona = string.Empty;
        }

        [RelayCommand]
        private void ActualizarPorcentajeDePropina(string nuevoPorcentaje)
        {
            PorcentajeDePropina = nuevoPorcentaje;
        }
    }
}
