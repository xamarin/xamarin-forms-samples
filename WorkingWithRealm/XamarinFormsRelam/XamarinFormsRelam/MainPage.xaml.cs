using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsRelam.Models;
using Realms;
namespace XamarinFormsRelam
{
    public partial class MainPage : ContentPage
    {
        List<OptionItems> optionItems = new List<OptionItems>();
        Student editStudent;
        public MainPage()
        {
            InitializeComponent();
            imgBanner.Source = ImageSource.FromResource("XamarinFormsRelam.images.banner.png");
            var realmDB = Realm.GetInstance();

            List<Student> studentList = realmDB.All<Student>().ToList();
            listStudent.ItemsSource=studentList;
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var students= realmDB.All<Student>().ToList();
            var maxStudentId = 0;
            if (students.Count!=0)
            {

                 maxStudentId = students.Max(s=>s.StudentID);
            }
            Student student = new Student()
            {
                StudentID = maxStudentId + 1,
                StudentName = txtStudentName.Text
            };
            realmDB.Write(() =>
            {
                realmDB.Add(student);
            });
            txtStudentName.Text = string.Empty;
            List<Student> studentList = realmDB.All<Student>().ToList();
            listStudent.ItemsSource = studentList;

        }
        private async void listOptions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var realmDB = Realm.GetInstance();
            OptionItems selectedItem = optionList.SelectedItem as OptionItems;
            if (selectedItem != null)
            {
                switch (selectedItem.OptionText)
                {

                    case "Edit":
                        popupOptionView.IsVisible = false;
                        popupEditView.IsVisible = true;
                        editStudent = realmDB.All<Student>().First(b => b.StudentID == selectedItem.StudentId);
                        txtEditStudentName.Text = editStudent.StudentName;
                        break;

                    case "Delete":
                        var removeStudent = realmDB.All<Student>().First(b => b.StudentID == selectedItem.StudentId);
                        using (var db = realmDB.BeginWrite())
                        {
                            realmDB.Remove(removeStudent);
                            db.Commit();
                        }
                        await DisplayAlert("Success", "Student Deleted", "OK");
                        popupOptionView.IsVisible = false;
                        List<Student> studentList = realmDB.All<Student>().ToList();
                        listStudent.ItemsSource = studentList;
                        break;

                    default:
                        popupOptionView.IsVisible = false;
                        break;
                }

                optionList.SelectedItem = null;
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var realmDb = Realm.GetInstance();
        }

        private void listStudent_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Student selectedStudent = listStudent.SelectedItem as Student;
            
            if(selectedStudent!=null)
            {
                optionItems.Add(new OptionItems { OptionText = "Edit",StudentId=selectedStudent.StudentID});
                optionItems.Add(new OptionItems { OptionText = "Delete", StudentId = selectedStudent.StudentID });
                optionItems.Add(new OptionItems { OptionText = "Cancel"});
                optionList.ItemsSource = optionItems;
                popupOptionView.IsVisible = true;
            }
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            popupEditView.IsVisible = false;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var realmDB = Realm.GetInstance();
            var selectedStudent = realmDB.All<Student>().First(b => b.StudentID == editStudent.StudentID);
            using (var db = realmDB.BeginWrite())
            {
                editStudent.StudentName = txtEditStudentName.Text;
                db.Commit();
            }
            await DisplayAlert("Success", "Student Updated","OK");
            txtEditStudentName.Text = string.Empty;
            popupEditView.IsVisible = false;

        }
    }
}
