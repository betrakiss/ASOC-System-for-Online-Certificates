﻿using SusiAPIClient;
using SusiAPICommon.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AffirmationBar.ViewModels
{
    public class CertificateOptionsViewModel : BaseViewModel
    {
        private SusiClient susiClient = new SusiClient();

        public CertificateOptionsViewModel(StudentInfo studentInfo)
        {
            this.Student = studentInfo;
        }

        public StudentInfo Student { get; set; }

        public IList<string> Reasons { get; set; } = new List<string>()
        {
            "БДЖ",
            "Градски транспорт",
            "НОИ",
            "ПСБО"
        };
        
        public async Task<byte[]> GetCertificateAsync()
        {
            IsLoading = true;
            byte[] bytes = await susiClient.GetCertificate(Student);
            IsLoading = false;

            return bytes;
        }

        private bool isLoading;
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return Student.Names.Split(' ')[0];
            }
        }

        private string selected;
        public string Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }
    }
}