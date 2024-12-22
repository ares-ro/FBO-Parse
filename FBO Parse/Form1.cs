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

            //��ūȭ �� ��ȿ�� �˻�
            if (inputData == "")
            {
                MessageBox.Show("������ �Է��ϼ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Regex.IsMatch(inputData, @"[^+\-*/0-9\.]"))
            {
                MessageBox.Show("���Ŀ� ����, ������ ���� �ٸ� ��Ұ� �����մϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> tokenList = InputTokenization.Tokenization(inputData);

            //��ūȭ �� ��ȿ�� �˻�
            //���� - (�ݺ�)(��ȣ - ����) �������� �ϹǷ� 3�̻��� Ȧ������ ��
            if (tokenList.Count < 3 | tokenList.Count % 2 == 0)
            {
                MessageBox.Show("������ �߸��Ǿ����ϴ�. �ٽ� Ȯ�����ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //0��° ���� �˻�
            if (NumOpeCheck.IsOperator(tokenList[0]))
            {
                MessageBox.Show("������ �߸��Ǿ����ϴ�. �ٽ� Ȯ�����ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //��ȣ - �������� �˻�
            for (int i = 1; i < tokenList.Count; i += 2)
            {
                if (NumOpeCheck.IsOperator(tokenList[i]) & NumOpeCheck.IsNumber(tokenList[i + 1]))
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("������ �߸��Ǿ����ϴ�. �ٽ� Ȯ�����ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            //���� ��ȿ�� �˻�
            for (int i = 0; i < tokenList.Count; i++)
            {
                if (NumOpeCheck.IsNumber(tokenList[i]))
                {
                    if (decimal.TryParse(tokenList[i], out decimal buffer) == false)
                    {
                        MessageBox.Show("�߸��� ����, Ȥ�� ������ �Ұ����� ���ڰ� �����մϴ�. �ٽ� Ȯ�����ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            //���� ���� �˻�

            //����
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
                //������ ���
                else
                {
                    tokenNumberBuffer += inputDataList[0].ToString();
                    inputDataList.RemoveAt(0);
                    continue;
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