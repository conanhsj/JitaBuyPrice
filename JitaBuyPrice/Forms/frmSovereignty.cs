using JitaBuyPrice.Classes;
using JitaBuyPrice.Helper;
using JitaBuyPrice.ObjectsJson;
using Newtonsoft.Json;
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

namespace JitaBuyPrice.Forms
{
    public partial class frmSovereignty : Form
    {
        public frmSovereignty()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //List<JOSovereignty> joSov = CEVESwaggerAPI.SovereigntyMap();
            //FilesHelper.OutputJsonFile("Sovereignty\\Map", JsonConvert.SerializeObject(joSov, Formatting.Indented));
            string strSov = FilesHelper.ReadJsonFile("Sovereignty\\Map");
            List<JOSovereignty> joSov = JsonConvert.DeserializeObject<List<JOSovereignty>>(strSov);

            //string strUniverse = FilesHelper.ReadJsonFile("Sovereignty\\UniverseSystem");
            //List<JOSolarSystem> lstSolar = JsonConvert.DeserializeObject<List<JOSolarSystem>>(strUniverse);

            //string strFactions = FilesHelper.ReadJsonFile("Sovereignty\\Factions");
            //List<JOFaction> lstFactions = JsonConvert.DeserializeObject<List<JOFaction>>(strFactions);

            string strCorporation = FilesHelper.ReadJsonFile("Sovereignty\\Corporation");
            List<JOCorporation> lstCorporation = JsonConvert.DeserializeObject<List<JOCorporation>>(strCorporation);

            string strAlliance = FilesHelper.ReadJsonFile("Sovereignty\\Alliance");
            List<JOAlliance> lstAlliance = JsonConvert.DeserializeObject<List<JOAlliance>>(strAlliance);

            List<long> lstUnknowID = new List<long>();
            foreach (JOSovereignty sov in joSov)
            {
                //JOSolarSystem joSol = lstSolar.Find(sol => sol.system_id == sov.system_id);
                //if (joSol != null)
                //{
                //    sov.system_name = joSol.system_name;
                //    sov.constellation_name = joSol.constellation_name;
                //    sov.region_name = joSol.region_name;
                //}
                //else
                //{
                //    lstUnknowID.Add(sov.system_id);
                //}

                //if (sov.faction_id != 0)
                //{
                //    JOFaction joFac = lstFactions.Find(sol => sol.faction_id == sov.faction_id);
                //    if (joFac != null)
                //    {
                //        sov.faction_name = joFac.name;
                //    }
                //    else
                //    {
                //        lstUnknowID.Add(sov.faction_id);
                //    }
                //}

                if (sov.corporation_id != 0)
                {
                    JOCorporation joCorp = lstCorporation.Find(corp => corp.corporation_id == sov.corporation_id);
                    if (joCorp != null)
                    {
                        sov.corporation_name = joCorp.corporation_name;
                    }
                    else
                    {
                        if (!lstUnknowID.Contains(sov.corporation_id))
                        {
                            lstUnknowID.Add(sov.corporation_id);
                        }
                    }
                }

                if (sov.alliance_id != 0)
                {
                    JOAlliance joAlli = lstAlliance.Find(Alli => Alli.alliance_id == sov.alliance_id);
                    if (joAlli != null)
                    {
                        sov.alliance_name = joAlli.alliance_name;
                    }
                    else
                    {
                        if (!lstUnknowID.Contains(sov.alliance_id))
                        {
                            lstUnknowID.Add(sov.alliance_id);
                        }
                    }
                }
            }

            //List<JOIDtoName> lstResult = CEVESwaggerAPI.SovereigntyGetNames(lstUnknowID);
            //foreach (JOIDtoName name in lstResult)
            //{
            //    if (name.category == "corporation")
            //    {
            //        JOCorporation joCorp = new JOCorporation();
            //        joCorp.corporation_id = name.id;
            //        joCorp.corporation_name = name.name;
            //        lstCorporation.Add(joCorp);
            //    }

            //    if (name.category == "alliance")
            //    {
            //        JOAlliance joAlli = new JOAlliance();
            //        joAlli.alliance_id = name.id;
            //        joAlli.alliance_name = name.name;
            //        lstAlliance.Add(joAlli);
            //    }
            //}
            //FilesHelper.OutputJsonFile("Sovereignty\\Alliance", JsonConvert.SerializeObject(lstAlliance, Formatting.Indented));


            FilesHelper.OutputJsonFile("Sovereignty\\Map", JsonConvert.SerializeObject(joSov, Formatting.Indented));
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            string strSov = FilesHelper.ReadJsonFile("Sovereignty\\Map");
            List<JOSovereignty> joSov = JsonConvert.DeserializeObject<List<JOSovereignty>>(strSov);


            List<JOSovereignty> lstNoHome = new List<JOSovereignty>();

            foreach (JOSovereignty sov in joSov)
            {
                if (sov.faction_id == 0 && sov.corporation_id == 0 && sov.alliance_id == 0)
                {
                    lstNoHome.Add(sov);
                }
            }
            string strResult = string.Empty;
            foreach (JOSovereignty sov in lstNoHome)
            {
                strResult += sov.system_name + " > " + sov.constellation_name + " > " + sov.region_name + "\n";
            }
            MessageBox.Show(strResult);
        }
    }
}
