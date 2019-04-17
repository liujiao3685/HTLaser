using System;
using System.Configuration;
using System.Windows.Forms;
using CS_Line_Control;
using ServiceStack.Redis;

namespace ProductManage.Forms
{
    /**
     * Redis 服务端可同时接受多个客户端的信息
     * 
     * */
    public partial class FormRedisService : Form
    {
        private Action OPTestReceiveSlaveHandle = null;//Test通道

        private Action OP01ReceiveSlaveHandle = null;//OP01

        private string ChannelName;

        public FormRedisService()
        {
            InitializeComponent();
        }

        private void FormRedisTest_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            ChannelName = ConfigurationManager.AppSettings["LineName"];

            if (OPTestReceiveSlaveHandle == null)
            {
                OPTestReceiveSlaveHandle = Recive_OPTest;
            }
            OPTestReceiveSlaveHandle.BeginInvoke(null, null);

            if (OP01ReceiveSlaveHandle == null)
            {
                OP01ReceiveSlaveHandle = Recive_OP01;
            }
            OP01ReceiveSlaveHandle.BeginInvoke(null, null);


            if (RedisCacheHelper.Get<string>("OPTest_Name") == null || RedisCacheHelper.Get<string>("OPTest_Age") == null)
            {
                RedisCacheHelper.Add<string>("OPTest_Name", "");
                RedisCacheHelper.Add<string>("OPTest_Age", "");
            }
        }

        private void Recive_OP01()
        {
            try
            {
                using (var consumer = new RedisClient(ConfigurationManager.AppSettings["RedisClient"], 6379))
                {
                    IRedisSubscription subscription = consumer.CreateSubscription();
                    subscription.OnMessage = (channel, msg) =>
                    {
                        BeginInvoke(new Action(() =>
                        {
                            listBox1.Items.Add(string.Format("OP01_Msg:{0}", msg));
                        }));
                        string stname = "OP01_Client";

                        Recive_Client(msg, stname);
                    };
                    subscription.OnSubscribe = channel => {/* Console.WriteLine("订阅客户端：开始订阅" + channel); */};
                    subscription.OnUnSubscribe = a => { /*Console.WriteLine("订阅客户端：取消订阅");*/ };
                    subscription.SubscribeToChannels(ChannelName + "_OP01");
                }
            }
            catch (Exception)
            {
            }
        }

        public void Recive_OPTest()
        {
            try
            {
                using (var consumer = new RedisClient(ConfigurationManager.AppSettings["RedisClient"], 6379))
                {
                    IRedisSubscription subscription = consumer.CreateSubscription();
                    subscription.OnMessage = (channel, msg) =>
                    {
                        BeginInvoke(new Action(() =>
                        {
                            listBox1.Items.Add(string.Format("OPTest_Msg:{0}", msg));
                        }));
                        string stname = "OPTest_Client";

                        Recive_Client(msg, stname);

                    };
                    subscription.OnSubscribe = channel => {/* Console.WriteLine("订阅客户端：开始订阅" + channel); */};
                    subscription.OnUnSubscribe = a => { /*Console.WriteLine("订阅客户端：取消订阅");*/ };
                    subscription.SubscribeToChannels(ChannelName + "_OPTest");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Recive_Client(string msg, string stname)
        {
            string[] cmd = msg.Split(',');
            switch (cmd[0])
            {
                case "ReadName":
                    SendMsgToClient(stname, RedisCacheHelper.Get<string>("OPTest_Name"));

                    break;
                case "ReadAge":
                    SendMsgToClient(stname, RedisCacheHelper.Get<string>("OPTest_Age"));

                    break;
                case "WriteName":
                    RedisCacheHelper.Add<string>("OPTest_Name", cmd[1]);
                    SendMsgToClient(stname, "WriteNameOK");

                    break;
                case "WriteAge":
                    RedisCacheHelper.Add<string>("OPTest_Age", cmd[1]);
                    SendMsgToClient(stname, "WriteAgeOK");

                    break;
            }
        }

        public void SendMsgToClient(string opName, string msg)
        {
            try
            {
                using (IRedisClient publisher = new RedisClient(ConfigurationManager.AppSettings["RedisClient"], 6379))
                {
                    publisher.PublishMessage(ChannelName + "_" + opName, msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = textBox1.Text;
            SendMsgToClient("OPTest_Client", msg);
        }
    }
}
