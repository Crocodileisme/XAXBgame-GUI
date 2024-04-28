using System.Diagnostics.Metrics;

namespace XAXBgame
{
    public partial class Form1 : Form
    {
        private XaXbEngine xaxb;

        private int counter;
        public Form1()
        {
            InitializeComponent();
            xaxb = new XaXbEngine();
            counter = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userNum = UserInput.Text.Trim(); // �����J���Ʀr
            if (xaxb.IsLegalNumber(userNum)) // �ˬd��J���Ʀr�O�_���T
            {
                counter++; // �q�����ƥ[�@
                string result = xaxb.GetResult(userNum); // ���G
                results.Items.Add($"{userNum}: {result}�A �q������: {counter}"); // ��ܵ��׵��G
                if (result == "3A0B") // ����F
                {
                    results.Items.Add("���ߧA�A�q��F!"); // ��ܮ��߰T��
                    guessbotton.Enabled = false; // �T�βq�����s
                }
            }
            else
            {
                MessageBox.Show("��J����Ƥ���A�Ϊ��פ���!!�Э��s��J!!"); 
            }
            UserInput.Clear(); // �M�ſ�J���a��
        }
    }
    internal class XaXbEngine
    {
        private string luckynumber;

        public XaXbEngine()
        {
            GenerateLuckyNumber(); // �ͦ����B�Ʀr
        }

        public void GenerateLuckyNumber()
        {
            Random random = new Random();
            int[] tem = new int[3];
            tem[0] = random.Next(0, 9);
            tem[1] = random.Next(0, 9);
            tem[2] = random.Next(0, 9);
            while (tem[0] == tem[1] ^ tem[1] == tem[2] ^ tem[0] == tem[2])
            {
                tem[1] = random.Next(0, 9);
                tem[2] = random.Next(0, 9);
            }
            luckynumber = $"{tem[0]}{tem[1]}{tem[2]}";
        }

        public bool IsLegalNumber(string number)
        {
            char[] tem = number.ToCharArray();
            if (tem.Length == 3)
            {
                if (tem[0] != tem[1] && tem[1] != tem[2] && tem[0] != tem[2]) //�Ʀr������
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //�Ʀr���פ��O3
            {
                return false;
            }
        }

        public string GetResult(string guess)
        {
            char[] user = guess.ToCharArray();
            char[] ans = this.luckynumber.ToCharArray();
            int a = 0, b = 0;
            for (int i = 0; i < user.Length; i++)
            {
                for (int j = 0; j < ans.Length; j++)
                {
                    if (user[i] == ans[j])
                    {
                        if (i == j)
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                    }
                }
            }
            return $"{a}A{b}B";
        }
        public bool IsGameOver(string guess)
        {
            return GetResult(guess) == "3A0B"; // �P�_�O�_�q�������Ʀr�M��m
        }
    }
}