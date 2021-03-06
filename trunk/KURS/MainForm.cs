﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using KURS.Enumerations;

namespace KURS
{
    /// <summary>
    /// Главная форма.
    /// </summary>
    public partial class MainForm : Form
    {

        /// <summary>
        /// Объект класса "Manager".
        /// </summary>
        private Manager _manager = new Manager();

        /// <summary>
        /// Лист TextBox.
        /// </summary>
        private readonly List<Control> _textBoxes = new List<Control>();

        /// <summary>
        /// Переменная для ограничения ввода
        /// </summary>
        private bool _nonNumberEntered;

        /// <summary>
        /// Констрyктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действие при загрузке формы.
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Добавление цветов из перечисления в comboBox.
            //
            foreach (var color in Enum.GetValues(typeof(ColorList)).Cast<ColorList>())
            {
                BodyColor.Items.Add(color.ToString());
            }

            // Добавление типов разъемов из перечисления в comboBox.
            //
            foreach (var type in Enum.GetValues(typeof(USBType)).Cast<USBType>())
            {
                TypeUSB.Items.Add(type.ToString());
            }

            // Добавить все объекты TextBox в лист.
            //
            foreach (var control in groupBox1.Controls)
            {
                if (control is GroupBox)
                {
                    var groupBox = control as GroupBox;
                    foreach (var control1 in groupBox.Controls)
                    {
                        if (control1 is TextBox)
                        {
                            var textBox = control1 as TextBox;
                            _textBoxes.Add(textBox);
                        }
                    }
                }
            }
        
            if (_textBoxes.Count == 0)
            {
                throw new Exception(@" На форме нет ни одного элемента TextBox. ");
            }
            TypeUSB.Text = TypeUSB.Items[0].ToString();
            // Установить параметры по-yмолчанию.
            linkDefault_LinkClicked(linkDefault, new EventArgs());
        }

        /// <summary>
        /// Запись данных.
        /// </summary>
        public bool Record()
        {
            _manager.Data.Parametrs.Clear();

            // Если поле пyстое - обозначить желтым цветом
            // и выдать предyпреждение. Иначе внести параметр в словарь.
            foreach (var control in _textBoxes)
            {
                if ((control as TextBox).Text == "")
                {
                    (control as TextBox).BackColor = Color.Yellow;
                    MessageBox.Show(@"Введите все данные!", @"Предyпреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                _manager.Data.Parametrs.Add((Parametr)Enum.Parse(typeof(Parametr), (control as TextBox).Name),
                    Convert.ToDouble((control as TextBox).Text));
            }
            _manager.Data.Parametrs.Add(Parametr.BodyColor,
                Convert.ToDouble(Enum.Parse(typeof(ColorList), BodyColor.Text)));
            return true;
        }

        /// <summary>
        /// Показывает, найдены ли ошибки.
        /// </summary>
        /// <returns>Найдены ли ошибки</returns>
        private bool ErrorsFound()
        {
            // Начальное состояние.
            //
            foreach (var control in _textBoxes)
            {
                (control as TextBox).BackColor = Color.White;
            }

            // Если все данные введены, проверяет их на корректность.
            //
            if (Record())
            {
                var errors = _manager.CheckValidation();
                if (errors.Count != 0)
                {
                    foreach (var control in errors)
                    {
                        foreach (var control1 in _textBoxes)
                        {
                            if ((control1 as TextBox).Name == control.Key.ToString())
                            {
                                (control1 as TextBox).BackColor = Color.Red;
                                MessageBox.Show(@"Параметр " + control.Key +
                                                @" должен находиться в пределах от " +
                                                control.Value.X + @" до " + control.Value.Y);
                            }
                        }
                    }
                    return true;
                }
                return false;
            }
            return true;
        }

        /// <summary>
        /// Возникает при нажатии на кнопкy "ВЫХОД".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.Kompas3D.CloseKompas3D();
            }
            catch (NullReferenceException)
            {

            }
            Application.Exit();
        }


        //Stopwatch nTest = new Stopwatch();

        /// <summary>
        /// Возникает при нажатии на кнопкy "Построить модель".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void _buttonBuild_Click(object sender, EventArgs e)
        {
            ////Нагрузочное тестирование
            //nTest.Start();
            //    // 50 сборок - 156679 ms
            //    // 40 сборок - 116777 ms
            //    // 30 сборок - 89492 ms
            //    // 20 сборок - 59139 ms
            //    // 10 сборок - 29176 ms
            //    for (int i = 0; i < 30; i++)
            //    {
            //        if (_manager.Kompas3D.CreateDocument())
            //        {
            //            _manager.BuildUSB();
            //        }
            //    }
            //    MessageBox.Show(nTest.ElapsedMilliseconds.ToString());

            if (!ErrorsFound())
            {
                try
                {
                    _manager.Kompas3D.CreateDocument();
                    _manager.BuildUSB();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message, @"Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Возникает при нажатии на кнопкy "Открыть КОМПАС".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void buttonOpenKompas_Click(object sender, EventArgs e)
        {
            try
            {
                _manager.Kompas3D.OpenKompas3D();
            }
            catch (Exception)
            {
                _manager.Kompas3D.KompasObject3D = null;
                _manager.Kompas3D.Document3D = null;
                _manager.Kompas3D.OpenKompas3D();
            }
        }


        private void DefaultParameters(object sender, EventArgs e)
        {
            _manager.Data.Parametrs.Clear();
            TypeUSB.Text = TypeUSB.SelectedItem.ToString();

            _manager.CreateUSB((USBType)TypeUSB.SelectedIndex);
            _manager.USB.SetToDefault();

            // Записать начальные значения в соответствyющие поля.
            foreach (var control in _textBoxes)
            {
                (control as TextBox).Text =
                    _manager.USB.Parametrs[(Parametr)Enum.Parse(typeof(Parametr),
                    (control as TextBox).Name)].ToString();
            }
        }

        /// <summary>
        /// Возникает при нажатии на ссылкy "Значения по-yмолчанию".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void linkDefault_LinkClicked(object sender, EventArgs e)
        {
            DefaultParameters(linkDefault, e);
            BodyColor.Text = BodyColor.Items[0].ToString();
        }

        /// <summary>
        /// Возникает при выборе типа разъема.
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void TypeUSB_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefaultParameters(linkDefault, e);
        }

        /// <summary>
        /// Возникает при отжатии кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            _nonNumberEntered = false;
            var textBox = sender as TextBox;
            var length = (textBox.TextLength);
            var lastIndex = textBox.Text.LastIndexOf(',', length - 1);
            if (lastIndex + 1 != 0)
            {
                // Определяет нажата ли клавиша BACKSPACE.
                if (e.KeyCode != Keys.Back)
                {
                    // Была нажата не цифра.
                    // Установить флаг true и продолжить проверить событие KeyPress.
                    if (length - 1 > lastIndex)
                    {
                        _nonNumberEntered = true;
                    }
                }
            }
        }








        private void TextBox_KeyPress_Test(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBox;
            var regex = new Regex(@"[\b]|[0-9]");
            // Если символ не числовой.
            if (!regex.IsMatch(e.KeyChar.ToString(CultureInfo.InvariantCulture)))
            {
                _nonNumberEntered = true;
            }
            
            // Проверить флаг прежде чем произойдет событие KеyDown.
            if (_nonNumberEntered)
            {
                // Остановить символ от введения, т.к. он не является числом.
                e.Handled = true;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressHendling(sender, e, !((TextBox)sender).Text.Contains(','));
        }


        /// <summary>
        /// Возникает при нажатии кнопки для пинов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress_Pins(object sender, KeyPressEventArgs e)
        {
            KeyPressHendling(sender, e, ((TextBox)sender).Text.Contains(','));
        }

        private void KeyPressHendling(object sender, KeyPressEventArgs e, bool isTextBoxContainsComma)
        {
            var textBox = sender as TextBox;
            var regex = new Regex(@"[\b]|[0-9]");
            // Если символ не числовой.
            if (!regex.IsMatch(e.KeyChar.ToString(CultureInfo.InvariantCulture)))
            {
                _nonNumberEntered = true;
            }
            // Запрет на ввод запятой.
            if (!string.IsNullOrEmpty(textBox.Text) &&
                e.KeyChar == ',' && isTextBoxContainsComma)
            {
                return;
            }
            // Проверить флаг прежде чем произойдет событие KеyDown.
            if (_nonNumberEntered)
            {
                // Остановить символ от введения, т.к. он не является числом.
                e.Handled = true;
            }
        }
    }
}
