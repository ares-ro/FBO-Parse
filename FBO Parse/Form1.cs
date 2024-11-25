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
            string inputData = richTextBox1.Text;

            ////토큰화 전 유효성 검사
            //비어있는지 확인
            if (inputData == "")
            {
                MessageBox.Show("수식을 입력하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //사칙연산 기호와 숫자 외의 다른게 있는지 확인
            else if (Regex.IsMatch(inputData, @"[^+\-*/0-9]"))
            {
                MessageBox.Show("수식에 숫자, 연산자 외의 다른 요소가 존재합니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> tokenList = InputTokenization.Tokenization(inputData);

            ////토큰화 후 유효성 검사

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
                    }
                    if (inputDataList[0] == '-')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                    }
                    if (inputDataList[0] == '*')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                    }
                    if (inputDataList[0] == '/')
                    {
                        tokenList.Add(inputDataList[0].ToString());
                        inputDataList.RemoveAt(0);
                    }
                }
                //숫자인 경우
                else
                {
                    tokenNumberBuffer += inputDataList[0].ToString();
                    inputDataList.RemoveAt(0);
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
}
