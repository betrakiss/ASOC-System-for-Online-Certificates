﻿using AffirmationBar.ViewModels;
using SusiAPICommon.Models;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace AffirmationBar.WPF.Views
{
	/// <summary>
	/// Interaction logic for StudentInfoWindow.xaml
	/// </summary>
	public partial class StudentInfoWindow : Window
	{
        
        public CertificateOptionsViewModel certificateOptions { get; set; } 

		public StudentInfoWindow(StudentInfo studentInfo)
		{
            InitializeComponent();

            certificateOptions = new CertificateOptionsViewModel(studentInfo);

            this.DataContext = certificateOptions;
        }

        

        private async void getDoc_Click(object sender, RoutedEventArgs e)
        {
            await certificateOptions.GetCertificateAsync();
        }

        
    }
}
