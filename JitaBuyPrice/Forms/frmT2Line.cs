using JitaBuyPrice.Classes;
using JitaBuyPrice.ObjectsJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JitaBuyPrice.Commons;

namespace JitaBuyPrice.Forms
{
    public partial class frmT2Line : Form
    {
        double dT2Rate = 0.02;
        double dComRate = 0.10;
        const string strBuyPrice = "挂单价格总和：";
        const string strLineSum = "总流程数：";
        const string strBaseSellPrice = "吉他卖价：";

        public frmT2Line()
        {
            InitializeComponent();
            lvBase.Columns.Add("材料", 130);
            lvBase.Columns.Add("数量", 60);

            lvHigher.Columns.Add("材料", 90);
            lvHigher.Columns.Add("数量", 75);
            lvHigher.Columns.Add("流程数", 45);

            lvLower.Columns.Add("材料", 90);
            lvLower.Columns.Add("数量", 60);
            lvLower.Columns.Add("流程数", 45);

            lvMoon.Columns.Add("材料", 90);
            lvMoon.Columns.Add("数量", 60);
        }
        private List<Objects.Reaction> lstT2ComponentReaction = new List<Objects.Reaction>();
        private void LoadT2ComponentReaction()
        {
            lstT2ComponentReaction.Clear();
            //感应器
            //反应堆 反物质  聚变 引力子反应器 M核
            //脉冲发生器
            //微处理器
            //推进器
            //火控装置 A激光器定焦水晶 G粒子加速装置 C超导体轨道 M热核反应击发装置
            //护盾发生器
            //附甲
            //电容器         超立方 震荡 C标量 M电解
            //主要金属材料  A碳化钨         C碳化钛 M菲尔合金碳化物

            LoadAmarrReaction();
            LoadCaldariReaction();
            LoadGallenteReaction();
            LoadMinmatarReaction();

        }
        private void LoadAmarrReaction()
        {
            Objects.Reaction item = new Objects.Reaction();
            item.Name = "超立方电容器单元";
            item.Output = 1;
            item.Input.Add("碳化钨", 27);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("太赫兹超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "电磁发生器";
            item.Output = 1;
            item.Input.Add("碳化钨", 22);
            item.Input.Add("酚合成物", 7);
            item.Input.Add("纳米晶体管", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "反物质反应堆组件";
            item.Output = 1;
            item.Input.Add("碳化钨", 9);
            item.Input.Add("费米子冷凝物", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "激光器定焦水晶";
            item.Output = 1;
            item.Input.Add("碳化钨", 31);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("超级突触纤维", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "聚变推进器";
            item.Output = 1;
            item.Input.Add("碳化钨", 13);
            item.Input.Add("酚合成物", 3);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "雷达感应器组";
            item.Output = 1;
            item.Input.Add("碳化钨", 22);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("超级突触纤维", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "纳米电子微处理器";
            item.Output = 1;
            item.Input.Add("碳化钨", 17);
            item.Input.Add("酚合成物", 6);
            item.Input.Add("纳米晶体管", 2);
            item.Input.Add("太赫兹超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "碳化钨附甲";
            item.Output = 1;
            item.Input.Add("碳化钨", 44);
            item.Input.Add("多晶碳化硅纤维", 11);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "线性护盾能量发射器";
            item.Output = 1;
            item.Input.Add("碳化钨", 22);
            item.Input.Add("多晶碳化硅纤维", 9);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);
        }
        private void LoadGallenteReaction()
        {
            Objects.Reaction item = new Objects.Reaction();
            item.Name = "震荡电容器单元";
            item.Output = 1;
            item.Input.Add("碳化晶体", 27);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("光子超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "等离子脉冲发生器";
            item.Output = 1;
            item.Input.Add("碳化晶体", 22);
            item.Input.Add("酚合成物", 7);
            item.Input.Add("纳米晶体管", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "聚变反应堆机组";
            item.Output = 1;
            item.Input.Add("碳化晶体", 9);
            item.Input.Add("费米子冷凝物", 2);
            lstT2ComponentReaction.Add(item);


            item = new Objects.Reaction();
            item.Name = "粒子加速装置";
            item.Output = 1;
            item.Input.Add("碳化晶体", 31);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("超级突触纤维", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "离子推进器";
            item.Output = 1;
            item.Input.Add("碳化晶体", 13);
            item.Input.Add("酚合成物", 3);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "磁力感应器组";
            item.Output = 1;
            item.Input.Add("碳化晶体", 22);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("超级突触纤维", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "光子微处理器";
            item.Output = 1;
            item.Input.Add("碳化晶体", 17);
            item.Input.Add("酚合成物", 6);
            item.Input.Add("纳米晶体管", 2);
            item.Input.Add("光子超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "碳化晶体附甲";
            item.Output = 1;
            item.Input.Add("碳化晶体", 44);
            item.Input.Add("多晶碳化硅纤维", 11);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "脉冲护盾发射器";
            item.Output = 1;
            item.Input.Add("碳化晶体", 22);
            item.Input.Add("多晶碳化硅纤维", 9);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);


        }
        private void LoadCaldariReaction()
        {
            Objects.Reaction item = new Objects.Reaction();
            item.Name = "标量电容器单元";
            item.Output = 1;
            item.Input.Add("碳化钛", 27);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("非线性超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "引力子脉冲发生器";
            item.Output = 1;
            item.Input.Add("碳化钛", 22);
            item.Input.Add("酚合成物", 7);
            item.Input.Add("纳米晶体管", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "引力子反应器机组";
            item.Output = 1;
            item.Input.Add("碳化钛", 9);
            item.Input.Add("费米子冷凝物", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "超导体轨道";
            item.Output = 1;
            item.Input.Add("碳化钛", 31);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("超级突触纤维", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "磁脉冲推进器";
            item.Output = 1;
            item.Input.Add("碳化钛", 13);
            item.Input.Add("酚合成物", 3);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "引力感应器组";
            item.Output = 1;
            item.Input.Add("碳化钛", 22);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("超级突触纤维", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "量子微处理器";
            item.Output = 1;
            item.Input.Add("碳化钛", 17);
            item.Input.Add("酚合成物", 6);
            item.Input.Add("纳米晶体管", 2);
            item.Input.Add("非线性超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "迪波特钛合金附甲";
            item.Output = 1;
            item.Input.Add("碳化钛", 44);
            item.Input.Add("多晶碳化硅纤维", 11);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "恒定护盾发射器";
            item.Output = 1;
            item.Input.Add("碳化钛", 22);
            item.Input.Add("多晶碳化硅纤维", 9);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);

        }
        private void LoadMinmatarReaction()
        {
            Objects.Reaction item = new Objects.Reaction();
            item.Name = "电解电容器单元";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 27);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("等离子体超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "核脉冲发生器";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 22);
            item.Input.Add("酚合成物", 7);
            item.Input.Add("纳米晶体管", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "核反应堆机组";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 9);
            item.Input.Add("费米子冷凝物", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "热核反应击发装置";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 31);
            item.Input.Add("富勒化合物", 11);
            item.Input.Add("超级突触纤维", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "等离子推进器";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 13);
            item.Input.Add("酚合成物", 3);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "光雷达感应器组";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 22);
            item.Input.Add("纳米晶体管", 1);
            item.Input.Add("超级突触纤维", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "纳米机械微处理器";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 17);
            item.Input.Add("酚合成物", 6);
            item.Input.Add("纳米晶体管", 2);
            item.Input.Add("等离子体超材料", 2);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "碳化菲尔金属合成物附甲";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 44);
            item.Input.Add("多晶碳化硅纤维", 11);
            lstT2ComponentReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "偏阻护盾发射器";
            item.Output = 1;
            item.Input.Add("菲尔合金碳化物", 22);
            item.Input.Add("多晶碳化硅纤维", 9);
            item.Input.Add("铁磁胶体", 1);
            lstT2ComponentReaction.Add(item);

        }

        private List<Objects.Reaction> lstHigherReaction = new List<Objects.Reaction>();
        private void LoadHigherReaction()
        {
            Objects.Reaction item = new Objects.Reaction();
            item.Name = "碳化钨";
            item.Output = 10000;
            item.Input.Add("轧制钨合金", 100);
            item.Input.Add("硫酸", 100);
            item.Input.Add("氮燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "碳化晶体";
            item.Output = 10000;
            item.Input.Add("微晶合金", 100);
            item.Input.Add("碳聚合物", 100);
            item.Input.Add("氦燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "碳化钛";
            item.Output = 10000;
            item.Input.Add("铬化钛", 100);
            item.Input.Add("二硼硅", 100);
            item.Input.Add("氧燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "菲尔合金碳化物";
            item.Output = 10000;
            item.Input.Add("菲尔合金", 100);
            item.Input.Add("陶瓷粉末", 100);
            item.Input.Add("氢燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "纳米晶体管";
            item.Output = 1500;
            item.Input.Add("硫酸", 100);
            item.Input.Add("铂锝合金", 100);
            item.Input.Add("新汞合金", 100);
            item.Input.Add("氮燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "酚合成物";
            item.Output = 2200;
            item.Input.Add("二硼硅", 100);
            item.Input.Add("镉化铯", 100);
            item.Input.Add("铪化钒", 100);
            item.Input.Add("氧燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "费米子冷凝物";
            item.Output = 200;
            item.Input.Add("镉化铯", 100);
            item.Input.Add("镝汞合金", 100);
            item.Input.Add("熔融冷凝物", 100);
            item.Input.Add("稀土钷", 100);
            item.Input.Add("氦燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "富勒化合物";
            item.Output = 3000;
            item.Input.Add("碳聚合物", 100);
            item.Input.Add("铂锝合金", 100);
            item.Input.Add("氮燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "多晶碳化硅纤维";
            item.Output = 6000;
            item.Input.Add("陶瓷粉末", 100);
            item.Input.Add("六元复合物", 100);
            item.Input.Add("氦燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "超级突触纤维";
            item.Output = 750;
            item.Input.Add("铯铬合金", 100);
            item.Input.Add("镝汞合金", 100);
            item.Input.Add("铪化钒", 100);
            item.Input.Add("氧燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铁磁胶体";
            item.Output = 400;
            item.Input.Add("六元复合物", 100);
            item.Input.Add("超氟化物", 100);
            item.Input.Add("铁磁流体", 100);
            item.Input.Add("稀土钷", 100);
            item.Input.Add("氢燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "太赫兹超材料";
            item.Output = 300;
            item.Input.Add("轧制钨合金", 100);
            item.Input.Add("钷汞合金", 100);
            item.Input.Add("氦燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "光子超材料";
            item.Output = 300;
            item.Input.Add("微晶合金", 100);
            item.Input.Add("铥铪合金", 100);
            item.Input.Add("氧燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "非线性超材料";
            item.Output = 300;
            item.Input.Add("铬化钛", 100);
            item.Input.Add("铁磁流体", 100);
            item.Input.Add("氮燃料块", 5);
            lstHigherReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "等离子体超材料";
            item.Output = 300;
            item.Input.Add("菲尔合金", 100);
            item.Input.Add("新汞合金", 100);
            item.Input.Add("氢燃料块", 5);
            lstHigherReaction.Add(item);

        }

        private List<Objects.Reaction> lstLowerReaction = new List<Objects.Reaction>();
        private void LoadLowerReaction()
        {
            Objects.Reaction item = new Objects.Reaction();
            item.Name = "微晶合金";
            item.Output = 200;
            item.Input.Add("钴", 100);
            item.Input.Add("镉", 100);
            item.Input.Add("氦燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "碳聚合物";
            item.Output = 200;
            item.Input.Add("烃类", 100);
            item.Input.Add("硅酸盐", 100);
            item.Input.Add("氦燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "硫酸";
            item.Output = 200;
            item.Input.Add("标准大气", 100);
            item.Input.Add("蒸发岩沉积物", 100);
            item.Input.Add("氮燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铂锝合金";
            item.Output = 200;
            item.Input.Add("铂", 100);
            item.Input.Add("锝", 100);
            item.Input.Add("氮燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "新汞合金";
            item.Output = 200;
            item.Input.Add("汞", 100);
            item.Input.Add("钕", 100);
            item.Input.Add("氦燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "二硼硅";
            item.Output = 200;
            item.Input.Add("蒸发岩沉积物", 100);
            item.Input.Add("硅酸盐", 100);
            item.Input.Add("氧燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "镉化铯";
            item.Output = 200;
            item.Input.Add("镉", 100);
            item.Input.Add("铯", 100);
            item.Input.Add("氧燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铪化钒";
            item.Output = 200;
            item.Input.Add("钒", 100);
            item.Input.Add("铪", 100);
            item.Input.Add("氢燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "镝汞合金";
            item.Output = 200;
            item.Input.Add("汞", 100);
            item.Input.Add("镝", 100);
            item.Input.Add("氦燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "熔融冷凝物";
            item.Output = 200;
            item.Input.Add("钕", 100);
            item.Input.Add("铥", 100);
            item.Input.Add("氧燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "稀土钷";
            item.Output = 200;
            item.Input.Add("镉", 100);
            item.Input.Add("钷", 100);
            item.Input.Add("氧燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "陶瓷粉末";
            item.Output = 200;
            item.Input.Add("蒸发岩沉积物", 100);
            item.Input.Add("硅酸盐", 100);
            item.Input.Add("氢燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "六元复合物";
            item.Output = 200;
            item.Input.Add("铬", 100);
            item.Input.Add("铂", 100);
            item.Input.Add("氮燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铯铬合金";
            item.Output = 200;
            item.Input.Add("铬", 100);
            item.Input.Add("铯", 100);
            item.Input.Add("氧燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "超氟化物";
            item.Output = 200;
            item.Input.Add("钒", 100);
            item.Input.Add("钷", 100);
            item.Input.Add("氮燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铁磁流体";
            item.Output = 200;
            item.Input.Add("铪", 100);
            item.Input.Add("镝", 100);
            item.Input.Add("氢燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铥铪合金";
            item.Output = 200;
            item.Input.Add("铪", 100);
            item.Input.Add("铥", 100);
            item.Input.Add("氢燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "轧制钨合金";
            item.Output = 200;
            item.Input.Add("钨", 100);
            item.Input.Add("铂", 100);
            item.Input.Add("氮燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "铬化钛";
            item.Output = 200;
            item.Input.Add("钛", 100);
            item.Input.Add("铬", 100);
            item.Input.Add("氧燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "菲尔合金";
            item.Output = 10000;
            item.Input.Add("钪", 100);
            item.Input.Add("钒", 100);
            item.Input.Add("氢燃料块", 5);
            lstLowerReaction.Add(item);

            item = new Objects.Reaction();
            item.Name = "钷汞合金";
            item.Output = 200;
            item.Input.Add("汞", 100);
            item.Input.Add("钷", 100);
            item.Input.Add("氦燃料块", 5);
            lstLowerReaction.Add(item);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            OpenFileDialog diaFile = new OpenFileDialog();
            diaFile.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            diaFile.CheckFileExists = true;
            diaFile.Filter = "xlsx|*.xlsx";
            diaFile.ShowDialog();

            string strFilePath = diaFile.FileName;

            if (string.IsNullOrEmpty(strFilePath))
            {
                return;
            }
            //读取蓝图数据
            Classes.CEVEMarketFile.ExcelT2Work(strFilePath);

            cmbT2Copy.Items.Clear();
            foreach (Objects.T2Product Item in Classes.CEVEMarketFile.lstT2Product)
            {
                cmbT2Copy.Items.Add(Item);
            }
            cmbT2Copy.DisplayMember = "Name";
        }

        private void frmT2Line_Load(object sender, EventArgs e)
        {

            lstT2ComponentReaction.Clear();
            LoadT2ComponentReaction();

            lstHigherReaction.Clear();
            LoadHigherReaction();

            lstLowerReaction.Clear();
            LoadLowerReaction();
        }

        private void cmbT2Copy_SelectedValueChanged(object sender, EventArgs e)
        {
            string strT2Rate = this.txtT2Rate.Text;
            string strComRate = this.txtComRate.Text;
            this.dT2Rate = Commons.ReadDouble(strT2Rate) / 100;
            this.dComRate = Commons.ReadDouble(strComRate) / 100;

            if (dT2Rate == 0 || dComRate == 0)
            {
                return;
            }

            Objects.T2Product item = (Objects.T2Product)cmbT2Copy.SelectedItem;
            Objects.Item target = CEVEMarketFile.lstItem.Find(obj => obj.Name == item.Name);
            Dictionary<string, Price> dicResult = CEVEMarketAPI.SearchPriceJson(new List<string>() { target.TypeID });
            this.lblTargetSell.Text = strBaseSellPrice + string.Format("{0:C}", dicResult[target.TypeID].sell.min * item.Volume).Trim('¥');

            if (item != null)
            {
                lvBase.Items.Clear();
                double dPriceSumBase = 0;
                foreach (string strKey in item.Items.Keys)
                {
                    ListViewItem li = new ListViewItem(strKey);
                    li.UseItemStyleForSubItems = false;

                    //材料效率减免
                    int nItem = (int)Math.Ceiling(item.Items[strKey] * (1 - dT2Rate));
                    li.SubItems.Add(string.Format("{0:N}", nItem));
                    lvBase.Items.Add(li);

                    //价格查询
                    target = CEVEMarketFile.lstItem.Find(obj => obj.Name == strKey);
                    dicResult = CEVEMarketAPI.SearchPriceJson(new List<string>() { target.TypeID });
                    dPriceSumBase += nItem * dicResult[target.TypeID].sell.min;
                }
                this.lblBuyPrice0.Text = strBuyPrice + string.Format("{0:C}", dPriceSumBase).Trim('¥');
                DoCalComponentCost();
            }
        }

        private void DoCalComponentCost()
        {
            lvHigher.Items.Clear();
            //材料列表
            List<Objects.SearchingItem> lstOthers = new List<Objects.SearchingItem>();

            //组件列表
            foreach (ListViewItem Target in lvBase.Items)
            {

                Objects.Reaction reaction = this.lstT2ComponentReaction.Find(X => { return X.Name == Target.Text; });
                if (reaction != null)
                {
                    //有反应配方
                    foreach (string strKey in reaction.Input.Keys)
                    {
                        Objects.SearchingItem item = lstOthers.Find(X => { return X.Name == strKey; });
                        if (item != null)
                        {
                            //材料个数
                            int nVol = (int)Math.Ceiling(reaction.Input[strKey] * (1 - dComRate) * ReadDouble(Target.SubItems[1].Text));
                            //每流程一个的材料不可缩减
                            item.Volume += nVol < ReadDouble(Target.SubItems[1].Text) ? (int)ReadDouble(Target.SubItems[1].Text) : nVol;
                            item.Size += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text) / reaction.Output);
                        }
                        else
                        {
                            item = new Objects.SearchingItem();
                            item.Name = strKey;

                            //材料个数
                            int nVol = (int)Math.Ceiling(reaction.Input[strKey] * (1 - dComRate) * ReadDouble(Target.SubItems[1].Text));
                            //每流程一个的材料不可缩减
                            item.Volume = nVol < ReadDouble(Target.SubItems[1].Text) ? (int)ReadDouble(Target.SubItems[1].Text) : nVol;
                            item.Size += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text) / reaction.Output);
                            lstOthers.Add(item);
                        }
                    }
                }
                else
                {
                    //无反应配方
                    Objects.SearchingItem item = lstOthers.Find(X => { return X.Name == Target.Text; });
                    if (item != null)
                    {
                        item.Volume += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text));
                    }
                    else
                    {
                        item = new Objects.SearchingItem();
                        item.Name = Target.Text;
                        item.Volume = (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text));
                        lstOthers.Add(item);
                    }
                }
            }

            int nLineSum = 0;
            double dPriceSumHigher = 0;
            foreach (Objects.SearchingItem Result in lstOthers)
            {
                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                li.SubItems.Add(string.Format("{0:N}", Result.Volume));
                Objects.Reaction reaction = this.lstHigherReaction.Find(X => { return X.Name == Result.Name; });
                if (reaction != null)
                {
                    int nLineNumHigher = (int)Math.Ceiling(Result.Volume / reaction.Output);
                    li.SubItems.Add(string.Format("{0:N}", nLineNumHigher));
                    nLineSum += nLineNumHigher;
                }
                lvHigher.Items.Add(li);

                //价格查询
                Objects.Item target = CEVEMarketFile.lstItem.Find(obj => obj.Name == Result.Name);
                Dictionary<string, Price> dicResult = CEVEMarketAPI.SearchPriceJson(new List<string>() { target.TypeID });
                dPriceSumHigher += Result.Volume * dicResult[target.TypeID].sell.min;
            }
            this.lblBuyPrice1.Text = strBuyPrice + string.Format("{0:C}", dPriceSumHigher).Trim('¥');
            this.lblLineSum1.Text = strLineSum + nLineSum.ToString();
            DoCalHigherCost();
        }

        private void DoCalHigherCost()
        {
            lvLower.Items.Clear();
            //材料列表
            List<Objects.SearchingItem> lstOthers = new List<Objects.SearchingItem>();
            Objects.SearchingItem FuelC = new Objects.SearchingItem();
            FuelC.Name = "氮燃料块";
            lstOthers.Add(FuelC);
            Objects.SearchingItem FuelA = new Objects.SearchingItem();
            FuelA.Name = "氦燃料块";
            lstOthers.Add(FuelA);
            Objects.SearchingItem FuelG = new Objects.SearchingItem();
            FuelG.Name = "氧燃料块";
            lstOthers.Add(FuelG);
            Objects.SearchingItem FuelM = new Objects.SearchingItem();
            FuelM.Name = "氢燃料块";
            lstOthers.Add(FuelM);

            //组件列表
            foreach (ListViewItem Target in lvHigher.Items)
            {

                Objects.Reaction reaction = this.lstHigherReaction.Find(X => { return X.Name == Target.Text; });
                if (reaction != null)
                {
                    //有反应配方
                    foreach (string strKey in reaction.Input.Keys)
                    {
                        Objects.SearchingItem item = lstOthers.Find(X => { return X.Name == strKey; });
                        if (item != null)
                        {
                            //item.Volume += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text) / reaction.Output * reaction.Input[strKey]);
                            item.Volume += (int)(ReadDouble(Target.SubItems[2].Text) * reaction.Input[strKey]);
                        }
                        else
                        {
                            item = new Objects.SearchingItem();
                            item.Name = strKey;
                            //item.Volume = (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text) / reaction.Output * reaction.Input[strKey]);
                            item.Volume += (int)(ReadDouble(Target.SubItems[2].Text) * reaction.Input[strKey]);
                            lstOthers.Add(item);
                        }
                    }
                }
                else
                {
                    //无反应配方
                    Objects.SearchingItem item = lstOthers.Find(X => { return X.Name == Target.Text; });
                    if (item != null)
                    {
                        item.Volume += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text));
                    }
                    else
                    {
                        item = new Objects.SearchingItem();
                        item.Name = Target.Text;
                        item.Volume = (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text));
                        lstOthers.Add(item);
                    }
                }
            }

            int nLineSum = 0;
            double dPriceSumLower = 0;
            foreach (Objects.SearchingItem Result in lstOthers)
            {
                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                li.SubItems.Add(string.Format("{0:N}", Result.Volume));
                Objects.Reaction reaction = this.lstLowerReaction.Find(X => { return X.Name == Result.Name; });
                //计算流程数
                if (reaction != null)
                {
                    int nLineNumLower = (int)Math.Ceiling(Result.Volume / reaction.Output);
                    li.SubItems.Add(string.Format("{0:N}", nLineNumLower));
                    nLineSum += nLineNumLower;
                }
                lvLower.Items.Add(li);

                //价格查询
                Objects.Item target = CEVEMarketFile.lstItem.Find(obj => obj.Name == Result.Name);
                Dictionary<string, Price> dicResult = CEVEMarketAPI.SearchPriceJson(new List<string>() { target.TypeID });
                dPriceSumLower += Result.Volume * dicResult[target.TypeID].sell.min;
            }
            this.lblBuyPrice2.Text = strBuyPrice + string.Format("{0:C}", dPriceSumLower).Trim('¥');
            this.lblLineSum2.Text = strLineSum + nLineSum.ToString();
            DoCalLowerCost();
        }

        private void DoCalLowerCost()
        {
            lvMoon.Items.Clear();
            //材料列表
            List<Objects.SearchingItem> lstOthers = new List<Objects.SearchingItem>();
            Objects.SearchingItem FuelC = new Objects.SearchingItem();
            FuelC.Name = "氮燃料块";
            lstOthers.Add(FuelC);
            Objects.SearchingItem FuelA = new Objects.SearchingItem();
            FuelA.Name = "氦燃料块";
            lstOthers.Add(FuelA);
            Objects.SearchingItem FuelG = new Objects.SearchingItem();
            FuelG.Name = "氧燃料块";
            lstOthers.Add(FuelG);
            Objects.SearchingItem FuelM = new Objects.SearchingItem();
            FuelM.Name = "氢燃料块";
            lstOthers.Add(FuelM);

            //组件列表
            foreach (ListViewItem Target in lvLower.Items)
            {

                Objects.Reaction reaction = this.lstLowerReaction.Find(X => { return X.Name == Target.Text; });
                if (reaction != null)
                {
                    //有反应配方
                    foreach (string strKey in reaction.Input.Keys)
                    {
                        Objects.SearchingItem item = lstOthers.Find(X => { return X.Name == strKey; });
                        if (item != null)
                        {
                            //item.Volume += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text) / reaction.Output * reaction.Input[strKey]);
                            item.Volume += (int)(ReadDouble(Target.SubItems[2].Text) * reaction.Input[strKey]);
                        }
                        else
                        {
                            item = new Objects.SearchingItem();
                            item.Name = strKey;
                            //item.Volume = (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text) / reaction.Output * reaction.Input[strKey]);
                            item.Volume += (int)(ReadDouble(Target.SubItems[2].Text) * reaction.Input[strKey]);
                            lstOthers.Add(item);
                        }
                    }
                }
                else
                {
                    //无反应配方
                    Objects.SearchingItem item = lstOthers.Find(X => { return X.Name == Target.Text; });
                    if (item != null)
                    {
                        item.Volume += (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text));
                    }
                    else
                    {
                        item = new Objects.SearchingItem();
                        item.Name = Target.Text;
                        item.Volume = (int)Math.Ceiling(ReadDouble(Target.SubItems[1].Text));
                        lstOthers.Add(item);
                    }
                }
            }

            double dPriceSumMoon = 0;
            foreach (Objects.SearchingItem Result in lstOthers)
            {
                ListViewItem li = new ListViewItem(Result.Name);
                li.UseItemStyleForSubItems = false;

                li.SubItems.Add(string.Format("{0:N}", Result.Volume));
                lvMoon.Items.Add(li);

                //价格查询
                Objects.Item target = CEVEMarketFile.lstItem.Find(obj => obj.Name == Result.Name);
                Dictionary<string, Price> dicResult = CEVEMarketAPI.SearchPriceJson(new List<string>() { target.TypeID });
                dPriceSumMoon += Result.Volume * dicResult[target.TypeID].sell.min;
            }
            this.lblBuyPrice3.Text = strBuyPrice + string.Format("{0:C}", dPriceSumMoon).Trim('¥');
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            string strBuyList = string.Empty;
            if (lvMoon.Items.Count > 0)
            {
                foreach (ListViewItem Target in lvMoon.Items)
                {
                    strBuyList += Target.Text + "\t" + Target.SubItems[1].Text + "\r\n";
                }
                Clipboard.Clear();
                Clipboard.SetText(strBuyList);
                MessageBox.Show("成功复制到剪贴板");
            }
        }
    }
}
