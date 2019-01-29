using System.Threading.Tasks;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                TipRecalculate();
                TotalRecalculate();
            }
        }

        private int _generosity;
        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);

                TipRecalculate();
                TotalRecalculate();
            }
        }

        private double _tip;

        public double Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        private double _totalAmount;
        public double TotalAmount
        {
            get => _totalAmount;
            set
            {
                _totalAmount = value;
                RaisePropertyChanged(() => TotalAmount);
            }
        }

        private void TipRecalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }

        private void TotalRecalculate()
        {
            TotalAmount = _calculationService.TotalAmount(SubTotal, Tip);
        }
    }
}
