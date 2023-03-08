using MvvmExample.Commands;
using MvvmExample.Models;
using MvvmExample.Repositories;
using MvvmExample.Views;
using MvvmExample.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MvvmExample.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public FakeRepo PrinterRepository { get; set; }

		private ObservableCollection<Printer> allPrinters;

		public ObservableCollection<Printer> AllPrinters
        {
			get { return allPrinters; }
			set { allPrinters = value; OnPropertyChanged(); }
		}


		private Printer printer;

		public Printer Printer
		{
			get { return printer; }
			set { printer = value; OnPropertyChanged(); }
		}


		public RelayCommand SelectedCommand { get; set; }
		public RelayCommand EditCommand { get; set; }
		public RelayCommand AddPrinterCommand { get; set; }
		public StackPanel StackPanel { get; set; }
		public MainViewModel(StackPanel stackPanel)
		{
			PrinterRepository = new FakeRepo();
			AllPrinters = new ObservableCollection<Printer>(PrinterRepository.GetAll());
			Printer = new Printer();

			StackPanel = stackPanel;
			foreach (var item in AllPrinters)
			{
				var vm = new SpecialUCViewModel();
				vm.Data = item.Id.ToString();
				var uc = new SpecialUC();
				uc.DataContext = vm;

				StackPanel.Children.Add(uc);
			}


			SelectedCommand = new RelayCommand((obj) =>
			{
				var item = obj as Printer;
				Printer = item;
			});

			EditCommand = new RelayCommand((o) =>
			{
				EditWindow window = new EditWindow();

				EditViewModel vm = new EditViewModel();
				vm.EditWindow = window;
				vm.EditPrinter = Printer;

				window.DataContext = vm;
				window.ShowDialog();
			}, (pred) =>
			{
				if (Printer.Id == 0)
				{
					return false;
				}
				return true;
			});

			AddPrinterCommand = new RelayCommand((obj) =>
			{
				var printer = new Printer
				{
					Id = 1,
					Model = "ER202",
					Vendor = "Canon",
					Color = "SpringGreen"
				};
				AllPrinters.Add(printer);
				MessageBox.Show("Printer Added Successfully");
			});
		}
	}
}
