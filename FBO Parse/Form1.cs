using System.Diagnostics;
using System.Text.RegularExpressions;

namespace FBO_Parse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputData = textBox1.Text;

            //토큰화 전 유효성 검사
            if (inputData == "")
            {
                MessageBox.Show("수식을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Regex.IsMatch(inputData, @"[^+\-*/0-9\.]"))
            {
                MessageBox.Show("수식에 숫자, 연산자 외의 다른 요소가 존재합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> tokenList = InputTokenization.Tokenization(inputData);

            //토큰화 후 유효성 검사
            //숫자 - (반복)(기호 - 숫자) 구조여야 하므로 3이상인 홀수여야 함
            if (tokenList.Count < 3 | tokenList.Count % 2 == 0)
            {
                MessageBox.Show("수식이 잘못되었습니다. 다시 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //0번째 먼저 검사
            if (NumOpeCheck.IsOperator(tokenList[0]))
            {
                MessageBox.Show("수식이 잘못되었습니다. 다시 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //기호 - 숫자인지 검사
            for (int i = 1; i < tokenList.Count; i += 2)
            {
                if (NumOpeCheck.IsOperator(tokenList[i]) & NumOpeCheck.IsNumber(tokenList[i + 1]))
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("수식이 잘못되었습니다. 다시 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //숫자 유효성 검사
            for (int i = 0; i < tokenList.Count; i++)
            {
                if (NumOpeCheck.IsNumber(tokenList[i]))
                {
                    if (decimal.TryParse(tokenList[i], out decimal buffer) == false)
                    {
                        MessageBox.Show("잘못된 숫자, 혹은 연산이 불가능한 숫자가 존재합니다. 다시 확인해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            //연산 제한 검사

            //연산
            while (tokenList.Count != 1)
            {
ExitRepeat:
                for (int i = 0; i < tokenList.Count; i++)
                {
                    if (NumOpeCheck.IsOperator(tokenList[i]))
                    {
                        if (tokenList[i] == "*")
                        {
                            decimal buffer = decimal.Parse(tokenList[i - 1]) * decimal.Parse(tokenList[i + 1]);
                            tokenList[i - 1] = buffer.ToString();
                            tokenList.RemoveAt(i);
                            tokenList.RemoveAt(i);
                            Debug.WriteLine(buffer);
                            goto ExitRepeat;
                        }
                        if (tokenList[i] == "/")
                        {
                            decimal buffer = decimal.Parse(tokenList[i - 1]) / decimal.Parse(tokenList[i + 1]);
                            tokenList[i - 1] = buffer.ToString();
                            tokenList.RemoveAt(i);
                            tokenList.RemoveAt(i);
                            Debug.WriteLine(buffer);
                            goto ExitRepeat;
                        }
                    }
                }
                for (int i = 0; i < tokenList.Count; i++)
                {
                    if (NumOpeCheck.IsOperator(tokenList[i]))
                    {
                        if (tokenList[i] == "+")
                        {
                            decimal buffer = decimal.Parse(tokenList[i - 1]) + decimal.Parse(tokenList[i + 1]);
                            tokenList[i - 1] = buffer.ToString();
                            tokenList.RemoveAt(i);
                            tokenList.RemoveAt(i);
                            Debug.WriteLine(buffer);
                            goto ExitRepeat;
                        }
                        if (NumOpeCheck.IsOperator(tokenList[i]))
                        {
                            if (tokenList[i] == "-")
                            {
                                decimal buffer = decimal.Parse(tokenList[i - 1]) - decimal.Parse(tokenList[i + 1]);
                                tokenList[i - 1] = buffer.ToString();
                                tokenList.RemoveAt(i);
                                tokenList.RemoveAt(i);
                                Debug.WriteLine(buffer);
                                goto ExitRepeat;
                            }
                        }
                    }
                }
            }
            Debug.WriteLine("result: " + tokenList[0]);
            textBox2.Text = tokenList[0];
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NumOpeCheck.IsNumber(e.KeyChar.ToString()) == false & NumOpeCheck.IsOperator(e.KeyChar.ToString()) == false & e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
    public class InputTokenization
    {
        public static List<string> Tokenization(string inputData)
        {
            List<string> tokenList = new List<string>();
            List<char> inputDataList = new List<char>(inputData);

            string tokenNumberBuffer = "";

            while (inputDataList.Count != 0)
            {
                //연산자인 경우
                if (Regex.IsMatch(inputDataList[0].ToString(), @"[+\-*/]") == true)
                {
                    //토큰넘버에 숫자가 있으면 먼저 저장
                    if (tokenNumberBuffer != "")
                    {
                        tokenList.Add(tokenNumberBuffer);
                        tokenNumberBuffer = "";
                    }

                    //연산자 저장
                    if (inputDataList[0] == '+')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                        continue;
                    }
                    if (inputDataList[0] == '-')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                        continue;
                    }
                    if (inputDataList[0] == '*')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                        continue;
                    }
                    if (inputDataList[0] == '/')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                        continue;
                    }
                }
                //숫자인 경우
                else
                {
                    tokenNumberBuffer += inputDataList[0].ToString();
                    inputDataList.RemoveAt(0);
                    continue;
                }
            }

            //마지막 남은 숫자 저장
            if (tokenNumberBuffer != "")
            {
                tokenList.Add(tokenNumberBuffer);
                tokenNumberBuffer = "";
            }

            return tokenList;
        }
    }
    public class NumOpeCheck
    {
        public static bool IsNumber(string checkData)
        {
            return Regex.IsMatch(checkData, @"[0-9]");
        }
        public static bool IsOperator(string checkData)
        {
            return Regex.IsMatch(checkData, @"[+\-*/]");
        }
    }
}