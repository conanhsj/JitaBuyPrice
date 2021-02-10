using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class Ships
    {
        public Dictionary<string, string> dicShipsID = new Dictionary<string, string>();

        private void LoadOthersShips()
        {
            //护卫
            dicShipsID.Add("冲锋者级", "");

        }

        private void LoadAmarrShips()
        {
            //巡洋
            dicShipsID.Add("启示级", "");
            dicShipsID.Add("奥格诺级", "");

            //战巡
            dicShipsID.Add("预言级", "");

        }
        private void LoadCaldariShips()
        {
            //护卫
            dicShipsID.Add("狮鹫级", "");
            dicShipsID.Add("茶隼级", "");
            dicShipsID.Add("苍鹭级", "");
            dicShipsID.Add("秃鹫级", "");
            dicShipsID.Add("矮脚鸡级", "");
            dicShipsID.Add("小鹰级", "");

            //驱逐
            dicShipsID.Add("渡鸦级", "");
            dicShipsID.Add("海燕级", "");

            //巡洋
            dicShipsID.Add("黑鸟级", "");
            dicShipsID.Add("狞獾级", "");
            dicShipsID.Add("鱼鹰级", "");
            dicShipsID.Add("巨鸟级", "");
        }
        private void LoadGallenteShips()
        {
            //护卫
            dicShipsID.Add("特里斯坦级", "");
            dicShipsID.Add("因卡萨斯级", "");
            dicShipsID.Add("伊米卡斯级", "");
            dicShipsID.Add("毛鲁斯级", "");
            dicShipsID.Add("纳维达斯级", "");
            dicShipsID.Add("阿特龙级", "");

            //驱逐
            dicShipsID.Add("促进级", "");
            dicShipsID.Add("阿尔格斯级", "");

            //巡洋
            dicShipsID.Add("狂怒者级", "");
            dicShipsID.Add("星空级", "");
            dicShipsID.Add("送葬者级", "");
            dicShipsID.Add("托勒克斯级", "");
        }
        private void LoadMinmatarShips()
        {
            //护卫
            dicShipsID.Add("爆发级", "");
            dicShipsID.Add("分裂者级", "");
            dicShipsID.Add("守夜者级", "");
            dicShipsID.Add("探索级", "");
            dicShipsID.Add("裂谷级", "");
            dicShipsID.Add("伐木者级", "");

            //驱逐
            dicShipsID.Add("弯刀级", "");
            dicShipsID.Add("长尾鲛级", "");

            //巡洋
            dicShipsID.Add("刺客级", "");
            dicShipsID.Add("挑战级", "");
            dicShipsID.Add("断崖级", "");
            dicShipsID.Add("镰刀级", "");

            //战巡
            dicShipsID.Add("龙卷风级", "");
        }
        public Ships()
        {
            LoadAmarrShips();
            LoadCaldariShips();
            LoadGallenteShips();
            LoadMinmatarShips();
            LoadOthersShips();
        }
    }
}
