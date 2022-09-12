using System;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace GuiCalculator
{
    public class CalculatorGui : Form
    {
        private Label _display;
        private Button _btnOne;
        private Button _btnTwo;
        private Button _btnThree;
        private Button _btnFour;
        private Button _btnFive;
        private Button _btnSix;
        private Button _btnSeven;
        private Button _btnEight;
        private Button _btnNine;
        private Button _btnZero;
        private Button _btnPlus;
        private Button _btnMinus;
        private Button _btnTimes;
        private Button _btnDivide;
        private Button _btnEquals;
        private Button _btnClear;
        private Button _btnPoint;
        private Button _btnBackSpace;

        private readonly Calculator _calculator;
        private bool _pointActive;
        private bool _hadResult = false;

        Font font = new Font("Consolas", 30);

        public CalculatorGui()
        {
            _calculator = new Calculator();
            Initialization();
            SetCulture();
        }
        
        private void SetCulture()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-GB");
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var ci = new CultureInfo(currentCulture)
            {
                NumberFormat = { NumberDecimalSeparator = "." },
                DateTimeFormat = { DateSeparator = "." }
            };
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        private void Initialization()
        {
            Size = new Size(366, 558);
            Text = "Calculator";

            _display = new Label();
            _display.Size = new Size(330, 75);
            _display.Location = new Point(10, 10);
            _display.BorderStyle = BorderStyle.FixedSingle;
            _display.TextAlign = ContentAlignment.MiddleRight;
            _display.Font = font;
            _display.BackColor = Color.White;

            _btnOne = new Button();
            InitNumberButton(_btnOne, 10, 350, "1");

            _btnTwo = new Button();
            InitNumberButton(_btnTwo, 95, 350, "2");

            _btnThree = new Button();
            InitNumberButton(_btnThree, 180, 350, "3");

            _btnFour = new Button();
            InitNumberButton(_btnFour, 10, 265, "4");

            _btnFive = new Button();
            InitNumberButton(_btnFive, 95, 265, "5");

            _btnSix = new Button();
            InitNumberButton(_btnSix, 180, 265, "6");

            _btnSeven = new Button();
            InitNumberButton(_btnSeven, 10, 180, "7");

            _btnEight = new Button();
            InitNumberButton(_btnEight, 95, 180, "8");

            _btnNine = new Button();
            InitNumberButton(_btnNine, 180, 180, "9");

            _btnZero = new Button();
            InitNumberButton(_btnZero, 95, 435, "0");

            _btnPlus = new Button();
            InitButton(_btnPlus, 265, 435, "+");
            _btnPlus.Click += BtnPlusOnClick;

            _btnMinus = new Button();
            InitButton(_btnMinus, 265, 350, "-");
            _btnMinus.Click += BtnMinusOnClick;

            _btnTimes = new Button();
            InitButton(_btnTimes, 265, 265, "*");
            _btnTimes.Click += BtnTimesOnClick;

            _btnDivide = new Button();
            InitButton(_btnDivide, 265, 180, "/");
            _btnDivide.Click += BtnDivideOnClick;

            _btnEquals = new Button();
            InitButton(_btnEquals, 180, 435, "=");
            _btnEquals.Click += BtnEqualsOnClick;

            _btnClear = new Button();
            InitButton(_btnClear, 10, 95, "C");
            _btnClear.Click += BtnClearOnClick;

            _btnPoint = new Button();
            InitButton(_btnPoint, 10, 435, ".");
            _btnPoint.Click += BtnPointOnClick;

            _btnBackSpace = new Button();
            InitButton(_btnBackSpace, 265, 95, "←");
            _btnBackSpace.Click += BtnBackSpaceOnClick;

            Controls.Add(_btnOne);
            Controls.Add(_btnTwo);
            Controls.Add(_btnThree);
            Controls.Add(_btnFour);
            Controls.Add(_btnFive);
            Controls.Add(_btnSix);
            Controls.Add(_btnSeven);
            Controls.Add(_btnEight);
            Controls.Add(_btnNine);
            Controls.Add(_btnZero);
            Controls.Add(_btnPlus);
            Controls.Add(_btnMinus);
            Controls.Add(_btnTimes);
            Controls.Add(_btnDivide);
            Controls.Add(_btnEquals);
            Controls.Add(_btnClear);
            Controls.Add(_btnPoint);
            Controls.Add(_display);
            Controls.Add(_btnBackSpace);
        }

        private void InitNumberButton(Button button, int x, int y, string label)
        {
            InitButton(button, x, y, label);
            button.Click += ClickOnNumberButton;
        }

        private void InitButton(Button button, int x, int y, string label)
        {
            button.Size = new Size(75, 75);
            button.Location = new Point(x, y);
            button.Text = label;
            button.Font = font;
            button.TextAlign = ContentAlignment.MiddleCenter;
        }


        private void BtnBackSpaceOnClick(object sender, EventArgs e)
        {
            if (_display.Text.Length < 1)
                return;
            _display.Text = _display.Text.Substring(0, _display.Text.Length - 1);
        }

        private void BtnPlusOnClick(object sender, EventArgs e)
        {
            _calculator.Plus(GetNumberFromDisplay());
            ResetGui();
        }

        private void BtnMinusOnClick(object sender, EventArgs e)
        {
            _calculator.Minus(GetNumberFromDisplay());
            ResetGui();
        }

        private void BtnTimesOnClick(object sender, EventArgs e)
        {
            _calculator.Times(GetNumberFromDisplay());
            ResetGui();
        }

        private void BtnDivideOnClick(object sender, EventArgs e)
        {
            _calculator.Divide(GetNumberFromDisplay());
            ResetGui();
        }

        private void ResetGui()
        {
            _display.Text = "";
            _pointActive = false;
            _hadResult = false;
        }

        private void BtnEqualsOnClick(object sender, EventArgs e)
        {
            _display.Text = Math.Round(_calculator.Equals(GetNumberFromDisplay()), 5)
                .ToString(CultureInfo.CurrentCulture);
            _hadResult = true;
        }

        private void BtnClearOnClick(object sender, EventArgs e)
        {
            _calculator.Clear();
            _display.Text = "";
            _pointActive = false;
        }

        private void BtnPointOnClick(object sender, EventArgs e)
        {
            if (!_pointActive)
            {
                _display.Text += ".";
                _pointActive = true;
            }
        }

        private void ClickOnNumberButton(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            _display.Text += clickedButton.Text;
            if (_hadResult)
            {
                _calculator.Clear();
                _hadResult = false;
            }
        }

        private double GetNumberFromDisplay()
        {
            if (double.TryParse(_display.Text, out double number))
            {
                return number;
            }

            return 0;
        }
    }
}