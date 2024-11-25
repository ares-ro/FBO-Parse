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

            ////��ūȭ �� ��ȿ�� �˻�
            //����ִ��� Ȯ��
            if (inputData == "")
            {
                MessageBox.Show("������ �Է��ϼ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //��Ģ���� ��ȣ�� ���� ���� �ٸ��� �ִ��� Ȯ��
            else if (Regex.IsMatch(inputData, @"[^+\-*/0-9]"))
            {
                MessageBox.Show("���Ŀ� ����, ������ ���� �ٸ� ��Ұ� �����մϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> tokenList = InputTokenization.Tokenization(inputData);

            ////��ūȭ �� ��ȿ�� �˻�

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
                //�������� ���
                if (Regex.IsMatch(inputDataList[0].ToString(), @"[+\-*/]") == true)
                {
                    //��ū�ѹ��� ���ڰ� ������ ���� ����
                    if (tokenNumberBuffer != "")
                    {
                        tokenList.Add(tokenNumberBuffer);
                        tokenNumberBuffer = "";
                    }

                    //������ ����
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
                //������ ���
                else
                {
                    tokenNumberBuffer += inputDataList[0].ToString();
                    inputDataList.RemoveAt(0);
                }
            }

            //������ ���� ���� ����
            if (tokenNumberBuffer != "")
            {
                tokenList.Add(tokenNumberBuffer);
                tokenNumberBuffer = "";
            }

            return tokenList;
        }
    }
}
