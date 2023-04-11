using CRM_MED.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRM_MED.Views
{
    /// <summary>
    /// Логика взаимодействия для AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
       
        public Gender Gender { get; set; }
        public List<Gender> genders { get; set; }
        public string? path = null;
        public bool isUpdate = false;
        public Patient patient = new Patient();
        public AddPatientWindow()
        {
            InitializeComponent();
            var context = new CRMmedContext();
            genders = context.Genders.ToList();
            BtnText.Text = "Добавить";
            birthday.DisplayDateEnd = DateTime.Now.AddYears(-18);
            DataContext = this;
        }
        public AddPatientWindow(Patient pat)
        {
            InitializeComponent();
            var context = new CRMmedContext();
            BtnText.Text = "Изменить";
            genders = context.Genders.ToList();
            FillTextBox(pat);
            
            birthday.DisplayDateEnd = DateTime.Now.AddYears(-18);
            patient = pat;
            DataContext = this;
        }
        public void FillTextBox(Patient pat)
        {
            var context = new CRMmedContext();
            name.Text = pat.Name;
            surname.Text = pat.Surname;
            patronymic.Text = pat.Patronymic;
            phone.Text = pat.PhoneNumber;
            hronick.Text = pat.ChronicDiseases;
            pass.Text = pat.Passport;
            snils.Text = pat.SNILS;
            //photo.Text = pat.PhotoPath;
            policy.Text = pat.PolicyNumber;
            reg.Text = pat.PlaceOfRegistration;
            birthday.Text = pat.BirthDay.ToString();
            //gender = pat.GenderCodeNavigation.Code;
            //gender.SelectedItem = context.Genders.FirstOrDefault(g =>g.GenderId == pat.GenderCodeNavigation.GenderId);


        }


        private void AddBtn(object sender, RoutedEventArgs e)
        {
            if (grid.Children.OfType<TextBox>().Any(tb => tb.Text.Trim() == string.Empty) || phone.Text.Contains("_") || pass.Text.Contains("_") || policy.Text.Contains("_") || reg.Text == string.Empty || birthday.Text == string.Empty)
            {
                MessageBox.Show("Заполнены не все поля");
            }
            else
            {
                var context = new CRMmedContext();
                if (patient.PatientId==0)
                {
                    patient.Name = name.Text;
                    patient.Surname = surname.Text;
                    patient.Patronymic = patronymic.Text;
                    patient.GenderCodeNavigation = Gender;
                    patient.PhoneNumber = phone.Text;
                    patient.ChronicDiseases = hronick.Text;
                    patient.Passport = pass.Text;
                    patient.SNILS = snils.Text;
                    //patient.PhotoPath = photo.Text;
                    patient.PolicyNumber = policy.Text;
                    patient.PlaceOfRegistration = reg.Text;
                    patient.BirthDay = Convert.ToDateTime(birthday.Text);
                    context.Attach(Gender);
                    context.Patients.Add(patient);
                    isUpdate = true;
                }
                else
                {
                    patient.Name = name.Text;
                    patient.Surname = surname.Text;
                    patient.Patronymic = patronymic.Text;
                    patient.GenderCodeNavigation = Gender;
                    patient.PhoneNumber = phone.Text;
                    patient.ChronicDiseases = hronick.Text;
                    patient.Passport = pass.Text;
                    patient.SNILS = snils.Text;
                    //patient.PhotoPath = photo.Text;
                    patient.PolicyNumber = policy.Text;
                    patient.PlaceOfRegistration = reg.Text;
                    patient.BirthDay = Convert.ToDateTime(birthday.Text);
                    //context.Attach(Gender);
                    context.Patients.Update(patient);
                    
                }
                try { context.SaveChanges(); Close(); } catch { }

            }

        }

        private void validNoNum(object sender, TextCompositionEventArgs e)
        {
            char inp = e.Text[0];
            if (inp < 'А' || inp > 'Я' && inp < 'а' || inp > 'я')
            {
                e.Handled = true;
            }
        }

        private void AddMainPhoto(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Png Images|*.png"
            };
            var result = dialog.ShowDialog();
            if (result != true)
            {
                return;
            }
            string newFilename = Guid.NewGuid().ToString().Replace("-", "") + ".png";
            string pathToCopy = $"Photos/{newFilename}";

            try
            {
                File.Copy(dialog.FileName, pathToCopy);
                path = newFilename;


            }
            catch
            {
                MessageBox.Show("Ошибка при копировании файла!");
            }
        }
    }
}
