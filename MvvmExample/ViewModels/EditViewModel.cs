using MvvmExample.Commands;
using MvvmExample.Models;
using MvvmExample.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmExample.ViewModels
{
    public class EditViewModel:BaseViewModel
    {
		public EditWindow EditWindow { get; set; }
		private Printer printer;

		public Printer EditPrinter
        {
			get { return printer; }
			set { printer = value; OnPropertyChanged(); }
		}

		public RelayCommand	SaveCommand { get; set; }
		public EditViewModel()
		{
			EditPrinter = new Printer();

			SaveCommand = new RelayCommand((obj) =>
			{
				EditWindow.Close();
            });
		}

	}
}
