using System;
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
        private readonly Manager _manager = new Manager();

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
            foreach (var color in Enum.GetValues(typeof (ColorList)).Cast<ColorList>())
            {
                BodyColor.Items.Add(color.ToString());
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
                _manager.Data.Parametrs.Add((Parametr) Enum.Parse(typeof (Parametr), (control as TextBox).Name),
                    Convert.ToDouble((control as TextBox).Text));
            }
            _manager.Data.Parametrs.Add(Parametr.BodyColor,
                Convert.ToDouble(Enum.Parse(typeof (ColorList), BodyColor.Text)));
            _manager.Data.Parametrs.Add(Parametr.TypeOfCamera,
                Convert.ToDouble(Enum.Parse(typeof (CameraType), CType.Text)));
            _manager.Data.Parametrs.Add(Parametr.TypeOfMainButton,
                Convert.ToDouble(Enum.Parse(typeof (MainButtonType), MBType.Text)));
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

        //Stopwatch lol = new Stopwatch();

        /// <summary>
        /// Возникает при нажатии на кнопкy "Построить модель".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void buttonBuild_Click(object sender, EventArgs e)
        {
            //lol.Reset();
            //lol.Start();
            //for (int i = 0; i < 30; i++)
            //{

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
            //} 
            //lol.Stop();
            //MessageBox.Show(lol.ElapsedMilliseconds.ToString());
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

        /// <summary>
        /// Возникает при нажатии на ссылкy "Значения по-yмолчанию".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void linkDefault_LinkClicked(object sender, EventArgs e)
        {
            // Очистить предыдущие значения.
            _manager.Data.Parametrs.Clear();
            // Установить параметры по-yмолчанию.
            _manager.Data.SetToDefault();

            // Записать начальные значения в соответствyющие поля.
            //
            foreach (var control in _textBoxes)
            {
                (control as TextBox).Text =
                    _manager.Data.Parametrs[(Parametr)Enum.Parse(typeof(Parametr), 
                    (control as TextBox).Name)].ToString();
            }
            CType.Text = CType.Items[0].ToString();
            MBType.Text = MBType.Items[0].ToString();
            BodyColor.Text = BodyColor.Items[0].ToString();
        }

        /// <summary>
        /// Возникает при изменении параметра в ComboBox "Форма Главной кнопки".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void MBType_TextChanged(object sender, EventArgs e)
        {
            if (MBType.Text == @"Circle")
            {
                label13.Text = @"Диаметр";
                MainButtonWidth.Enabled = false;
            }
            else
            {
                MainButtonWidth.Enabled = true;
                label13.Text = @"Высота";
            }
        }

        /// <summary>
        /// Возникает при изменении параметра в ComboBox "Форма Камеры".
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void CType_SelectedIndexChanged(object sender, EventArgs e)
        {
            label17.Text = CType.Text == @"Circle" ? @"Диаметр" : @"Размер";
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

        /// <summary>
        /// Возникает при нажатии кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = sender as TextBox;
            var regex = new Regex(@"[\b]|[0-9]");
            // Если символ не числовой.
            if (!regex.IsMatch(e.KeyChar.ToString(CultureInfo.InvariantCulture)))
            {
                _nonNumberEntered = true;
            }
            // Если запятая не первая и одна.
            if (!string.IsNullOrEmpty(textBox.Text) &&
                e.KeyChar == ',' && !textBox.Text.Contains(','))
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
