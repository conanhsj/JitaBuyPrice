using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JitaBuyPrice.Forms
{
    public partial class frmSalvage : Form
    {
        public frmSalvage()
        {
            InitializeComponent();
            lvBase.Columns.Add("T1材料", 130);
            lvBase.Columns.Add("T1数量", 60);
            lvBase.Columns.Add("T2材料", 130);
            lvBase.Columns.Add("T2数量", 60);
        }

        private Dictionary<string, int> dicT1Salvage = new Dictionary<string, int>();
        private Dictionary<string, int> dicT2Salvage = new Dictionary<string, int>();

        private void frmSalvage_Load(object sender, EventArgs e)
        {

        }

        private void LoadT1Salvage()
        {
            dicT1Salvage.Clear();
            dicT1Salvage.Add("三钛合金条", 0);
            dicT1Salvage.Add("烧毁的遥感探测处理器", 0);
            dicT1Salvage.Add("有故障的电力泵", 0);
            dicT1Salvage.Add("出故障的护盾发射器", 0);
            dicT1Salvage.Add("装甲附甲板", 0);
            dicT1Salvage.Add("推进装置控制台", 0);
            dicT1Salvage.Add("缠绕的能量管道", 0);
            dicT1Salvage.Add("堆砌的能源电路", 0);
            dicT1Salvage.Add("烧焦的微电路", 0);
            dicT1Salvage.Add("损毁的触发机关", 0);
            dicT1Salvage.Add("损坏的人工神经网络", 0);
            dicT1Salvage.Add("受污染的纳米聚合体", 0);
            dicT1Salvage.Add("烧焦的接口电路", 0);
            dicT1Salvage.Add("烧毁的逻辑电路", 0);
            dicT1Salvage.Add("防御控制台", 0);
            dicT1Salvage.Add("被污染的洛伦兹流体", 0);
            dicT1Salvage.Add("聚合导体", 0);
            dicT1Salvage.Add("短路的电容器控制台", 0);
            dicT1Salvage.Add("损坏的无人机调制器", 0);
        }
        private void LoadT2Salvage()
        {
            dicT2Salvage.Clear();
            dicT2Salvage.Add("单晶体超合金工字钢", 0);
            dicT2Salvage.Add("遥感探测处理器", 0);
            dicT2Salvage.Add("电力泵", 0);
            dicT2Salvage.Add("完好的护盾发生器", 0);
            dicT2Salvage.Add("完好的装甲附甲", 0);
            dicT2Salvage.Add("推进器控制台", 0);
            dicT2Salvage.Add("能源管道", 0);
            dicT2Salvage.Add("能源电路", 0);
            dicT2Salvage.Add("微电路", 0);
            dicT2Salvage.Add("触发机关", 0);
            dicT2Salvage.Add("人工神经网络", 0);
            dicT2Salvage.Add("纳米聚合体", 0);
            dicT2Salvage.Add("接口电路", 0);
            dicT2Salvage.Add("逻辑电路", 0);
            dicT2Salvage.Add("加强的防御控制台", 0);
            dicT2Salvage.Add("洛伦兹流体", 0);
            dicT2Salvage.Add("传导性热塑塑料", 0);
            dicT2Salvage.Add("电容器控制台", 0);
            dicT2Salvage.Add("无人机调制器", 0);

        }
        private void ShowListViewBase()
        {
            lvBase.Items.Clear();
            ListViewItem li = new ListViewItem("三钛合金条");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["三钛合金条"]));
            li.SubItems.Add("单晶体超合金工字钢");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["单晶体超合金工字钢"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("烧毁的遥感探测处理器");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["烧毁的遥感探测处理器"]));
            li.SubItems.Add("遥感探测处理器");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["遥感探测处理器"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("有故障的电力泵");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["有故障的电力泵"]));
            li.SubItems.Add("电力泵");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["电力泵"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("出故障的护盾发射器");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["出故障的护盾发射器"]));
            li.SubItems.Add("完好的护盾发生器");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["完好的护盾发生器"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("装甲附甲板");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["装甲附甲板"]));
            li.SubItems.Add("完好的装甲附甲");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["完好的装甲附甲"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("推进装置控制台");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["推进装置控制台"]));
            li.SubItems.Add("推进器控制台");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["推进器控制台"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("缠绕的能量管道");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["缠绕的能量管道"]));
            li.SubItems.Add("能源管道");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["能源管道"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("堆砌的能源电路");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["堆砌的能源电路"]));
            li.SubItems.Add("能源电路");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["能源电路"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("烧焦的微电路");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["烧焦的微电路"]));
            li.SubItems.Add("微电路");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["微电路"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("损毁的触发机关");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["损毁的触发机关"]));
            li.SubItems.Add("触发机关");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["触发机关"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("损坏的人工神经网络");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["损坏的人工神经网络"]));
            li.SubItems.Add("人工神经网络");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["人工神经网络"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("受污染的纳米聚合体");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["受污染的纳米聚合体"]));
            li.SubItems.Add("纳米聚合体");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["纳米聚合体"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("烧焦的接口电路");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["烧焦的接口电路"]));
            li.SubItems.Add("接口电路");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["接口电路"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("烧毁的逻辑电路");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["烧毁的逻辑电路"]));
            li.SubItems.Add("逻辑电路");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["逻辑电路"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("防御控制台");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["防御控制台"]));
            li.SubItems.Add("加强的防御控制台");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["加强的防御控制台"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("被污染的洛伦兹流体");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["被污染的洛伦兹流体"]));
            li.SubItems.Add("洛伦兹流体");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["洛伦兹流体"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("聚合导体");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["聚合导体"]));
            li.SubItems.Add("传导性热塑塑料");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["传导性热塑塑料"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("短路的电容器控制台");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["短路的电容器控制台"]));
            li.SubItems.Add("电容器控制台");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["电容器控制台"]));
            lvBase.Items.Add(li);

            li = new ListViewItem("损坏的无人机调制器");
            li.SubItems.Add(string.Format("{0:D}", dicT1Salvage["损坏的无人机调制器"]));
            li.SubItems.Add("无人机调制器");
            li.SubItems.Add(string.Format("{0:D}", dicT2Salvage["无人机调制器"]));
            lvBase.Items.Add(li);
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            LoadT1Salvage();
            LoadT2Salvage();

            string strInput = txtSalvage.Text;
            string[] strSalvages = strInput.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> lstOther = new List<string>();

            foreach (string strLine in strSalvages)
            {
                string[] strItems = strLine.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                string strName = strItems[0];
                int nVol = (int)Commons.ReadDouble(strItems[1]);

                if (dicT1Salvage.ContainsKey(strName))
                {
                    dicT1Salvage[strName] += nVol;
                }
                else if (dicT2Salvage.ContainsKey(strName))
                {
                    dicT2Salvage[strName] += nVol;
                }
                else
                {
                    if (!lstOther.Contains(strName))
                    {
                        lstOther.Add(strName);
                    }
                    else
                    {
                        MessageBox.Show("下次记得堆叠一下");
                    }
                }
            }

            ShowListViewBase();

        }

    }
}
