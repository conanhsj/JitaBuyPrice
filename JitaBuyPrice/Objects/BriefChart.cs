﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JitaBuyPrice.Objects
{
    public class BriefChart
    {
        //http://eve.grismar.net/ore/full.php
        //Batch	Tri	Pye	Mex	Iso	Noc	Zyd	Meg	Mor
        //三钛
        double strTritanium = 0;
        //类胶
        double strPyerite = 0;
        //类银
        double strMexallon = 0;
        //同位素原矿
        double strIsogen = 0;
        //超新星诺克石
        double strNocxium = 0;
        //晶状石英核岩
        double strZydrine = 0;
        //超噬矿
        double strMegacyte = 0;

        public double Tri { get => strTritanium; set => strTritanium = value; }
        public double Pye { get => strPyerite; set => strPyerite = value; }
        public double Mex { get => strMexallon; set => strMexallon = value; }
        public double Iso { get => strIsogen; set => strIsogen = value; }
        public double Noc { get => strNocxium; set => strNocxium = value; }
        public double Zyd { get => strZydrine; set => strZydrine = value; }
        public double Meg { get => strMegacyte; set => strMegacyte = value; }
    }
}
