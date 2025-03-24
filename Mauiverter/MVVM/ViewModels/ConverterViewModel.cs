using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitsNet;

namespace Mauiverter.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ConverterViewModel
    {
        public string QuantityName { get; set; }
        public ObservableCollection<string> FromMeasure {  get; set; }
        public ObservableCollection<string> ToMeasure { get; set; }

        public string CurrentFromMeasure { get; set; }
        public string CurrentToMeasure { get; set; }

        public double FromValue { get; set; } = 1;
        public double ToValue { get; set; }

        public ICommand ReturnCommand =>
            new Command(() =>
            {
                Convert();
            });

        public ConverterViewModel(string quantityName)
        {
            QuantityName = quantityName;
            FromMeasure = LoadMeasures();
            ToMeasure = LoadMeasures();
            CurrentFromMeasure = FromMeasure.FirstOrDefault();
            CurrentToMeasure = ToMeasure.Skip(1).FirstOrDefault();
            Convert();
        }

        //public ConverterViewModel()
        //{
        //    QuantityName = "Length";
        //    FromMeasure = LoadMeasures();
        //    ToMeasure = LoadMeasures();
        //    CurrentFromMeasure = "Meter";
        //    CurrentToMeasure = "Centimeter";
        //    Convert();
        //}

        private ObservableCollection<string> LoadMeasures()
        {
            var types = Quantity.Infos.FirstOrDefault(x => x.Name == QuantityName).UnitInfos.Select(u => u.Name);
            return new ObservableCollection<string>(types);
        }

        public void Convert()
        {
            var result = UnitConverter.ConvertByName(FromValue, QuantityName, CurrentFromMeasure, CurrentToMeasure);
            ToValue = result;
        }
    }
}
