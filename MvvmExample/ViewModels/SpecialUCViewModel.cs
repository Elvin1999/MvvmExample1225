using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmExample.ViewModels
{
    public class SpecialUCViewModel:BaseViewModel
    {
		private string data;

		public string Data
		{
			get { return data; }
			set { data = value; OnPropertyChanged(); }
		}

		public SpecialUCViewModel()
		{
			Data = "No";
		}
	}
}
