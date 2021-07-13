using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestProject.DB;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for ModifyDataWindow.xaml
    /// </summary>
    public partial class ModifyDataWindow : Window
    {
        public ModifyDataWindow()
        {
            InitializeComponent();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var newName = TxtBox_AddData_Name.Text;
            var newManufacturer = TxtBox_AddData_Manuf.Text;
            var newQuantity = TxtBox_AddData_Quantity.Text;
            var newDate = DatePicker_AddData_Date.SelectedDate;

            try
            {
                if (newName != null && newManufacturer != null && newDate != null && newQuantity != null)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        db.CarSalesTable.Add(new Entities.CarSales
                        {
                            Name = newName,
                            Manufacturer = newManufacturer,
                            NumberOfSold = Convert.ToInt32(newQuantity),
                            DateOfSale = (DateTime)newDate
                        });
                        MessageBox.Show("Данные о новом автомобиле успешно добавлены", "Операция выполнена");
                        db.SaveChanges();
                    }
                }
                else MessageBox.Show("Все поля должны быть заполнены", "Не все поля заполнены");
            }
            catch (Exception)
            {
                MessageBox.Show("Поля должны быть заполнены надлежащими значениями", "Введен неверный тип данных");
            }
        }


        private void BtnChangeData_Click(object sender, RoutedEventArgs e)
        {
            var oldName = TxtBox_ChngData_OldName.Text;
            var oldManufacturer = TxtBox_ChngData_OldManuf.Text;

            var changedName = TxtBox_ChngData_NewName.Text;
            var changedManuf = TxtBox_ChngData_NewManuf.Text;
            var changedQuantity = TxtBox_ChngData_NewQuantity.Text;
            var changedDate = DatePicker_ChngData_NewDate.SelectedDate;

            try
            {
                if (oldName != null && oldManufacturer != null && changedName != null && changedManuf != null && changedDate != null && changedQuantity != null)
                {
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var selectedCarData = db.CarSalesTable.FirstOrDefault(c => c.Name == oldName && c.Manufacturer == oldManufacturer);

                        if (selectedCarData != null)
                        {
                            selectedCarData.Name = changedName;
                            selectedCarData.Manufacturer = changedManuf;
                            selectedCarData.NumberOfSold = Convert.ToInt32(changedQuantity);
                            selectedCarData.DateOfSale = (DateTime)changedDate;

                            MessageBox.Show("Данные об указанном автомобиле успешно изменены", "Операция выполнена");
                            db.SaveChanges();
                        }
                        else MessageBox.Show("Невозможно изменить данные: в базе данных не существует информации о продаже автомобиля с теми данными, которые вы указали", "Ошибка");
                    }
                }
                else MessageBox.Show("Все поля должны быть заполнены", "Не все поля заполнены");
            }
            catch (Exception)
            {
                MessageBox.Show("Поля должны быть заполнены надлежащими значениями", "Введен неверный тип данных");
            }
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var nameToDelete = TxtBox_DeleteData_Name.Text;
            var manufacturerToDelete = TxtBox_DeleteData_Manuf.Text;

            if (nameToDelete != null && manufacturerToDelete != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var carDataToDelete = db.CarSalesTable.FirstOrDefault(c => c.Name == nameToDelete && c.Manufacturer == manufacturerToDelete);

                    if (carDataToDelete != null)
                    {
                        db.CarSalesTable.Remove(carDataToDelete);

                        MessageBox.Show("Данные о новом автомобиле успешно добавлены", "Операция выполнена");
                        db.SaveChanges();
                    }
                    else MessageBox.Show("Невозможно удалить данные: в базе данных не существует информации о продаже автомобиля с теми данными, которые вы указали", "Ошибка");
                }
            }
            else MessageBox.Show("Все поля должны быть заполнены", "Не все поля заполнены");
        }
    }
}

