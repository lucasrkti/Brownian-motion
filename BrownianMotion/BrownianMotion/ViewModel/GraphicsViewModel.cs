using BrownianMotion.Drawables;
using BrownianMotion.Model;
using BrownianMotion.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Text;

namespace BrownianMotion.ViewModel
{
    public partial class GraphicsViewModel : ObservableObject
    {
        GraphicDrawable csDraw = new GraphicDrawable();

        [ObservableProperty]
        string initialPrice;

        [ObservableProperty]
        string sigma; // valotilidade media

        [ObservableProperty]
        string mean; // retorno medio

        [ObservableProperty]
        string numDays;

        [RelayCommand]
        public async void GerarSimulacao()
        {
            StringBuilder entrysVazias = new StringBuilder();

            if (string.IsNullOrEmpty(InitialPrice)) entrysVazias.Append("Preco Inicial" + "\n\n");
            if (string.IsNullOrEmpty(Sigma)) entrysVazias.Append("Volatilidade Media" + "\n\n");
            if (string.IsNullOrEmpty(Mean)) entrysVazias.Append("Retorno Medio" + "\n\n");
            if (string.IsNullOrEmpty(NumDays)) entrysVazias.Append("Tempo(dias)" + "\n\n");

            if (entrysVazias.ToString() != string.Empty)
            {
                await InformarEntryVazia(entrysVazias);
                return;
            }

            double valorDouble;
            if (!double.TryParse(InitialPrice, out valorDouble) || !double.TryParse(Sigma, out valorDouble)
                || !double.TryParse(Mean, out valorDouble) || (!double.TryParse(NumDays, out valorDouble)))
            {
                await Shell.Current.DisplayAlert("Favor Preencher os valores somente com números! ", "\n", "Ok");
                return;
            }

            var prices = GenerateBrownian.GenerateBrownianMotian(Convert.ToDouble(Sigma), Convert.ToDouble(Mean), Convert.ToDouble(InitialPrice), Convert.ToInt32(NumDays));
            Graphic.priceModel = prices;
            //chamada método Draw
        }

        public async Task InformarEntryVazia(StringBuilder entrys) => await Shell.Current.DisplayAlert("Favor Preencher os dados para gerar o Grafico: ", "\n" + entrys, "Ok");
    }
}
