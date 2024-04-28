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
            string userNum = UserInput.Text.Trim(); // 獲取輸入的數字
            if (xaxb.IsLegalNumber(userNum)) // 檢查輸入的數字是否正確
            {
                counter++; // 猜測次數加一
                string result = xaxb.GetResult(userNum); // 結果
                results.Items.Add($"{userNum}: {result}， 猜測次數: {counter}"); // 顯示答案結果
                if (result == "3A0B") // 答對了
                {
                    results.Items.Add("恭喜你，猜對了!"); // 顯示恭喜訊息
                    guessbotton.Enabled = false; // 禁用猜測按鈕
                }
            }
            else
            {
                MessageBox.Show("輸入的資料不對，或長度不對!!請重新輸入!!"); 
            }
            UserInput.Clear(); // 清空輸入的地方
        }
    }
    internal class XaXbEngine
    {
        private string luckynumber;

        public XaXbEngine()
        {
            GenerateLuckyNumber(); // 生成幸運數字
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
                if (tem[0] != tem[1] && tem[1] != tem[2] && tem[0] != tem[2]) //數字不重複
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //數字長度不是3
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
            return GetResult(guess) == "3A0B"; // 判斷是否猜中全部數字和位置
        }
    }
}