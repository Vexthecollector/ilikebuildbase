using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace ilikebuildbase
{
    [StaticConstructorOnStartup]
    public class MapComponent_ILikeBuildBase : MapComponent
    {
        int i = 0;
        public MapComponent_ILikeBuildBase(Map map) : base(map)
        {
        }

        public override void MapComponentTick()
        {
            i++;
            if ((i % 1024) == (i & 1))
            {

                Storyteller storyteller = Find.Storyteller;
                
                bool flag2 = storyteller.def.defName == "VEX_ILikeBuildBase";
                if (flag2)
                {
                    float wealthPerPawn = (Find.CurrentMap.PlayerWealthForStoryteller / Find.CurrentMap.PlayerPawnsForStoryteller.Count());
                    storyteller.def.populationIntentFactorFromPopCurve = new SimpleCurve { { new CurvePoint(0, wealthPerPawn), true }, { new CurvePoint(50, wealthPerPawn/5), true }, { new CurvePoint(100, 0), true } };
                    //storyteller.def.populationIntentFactorFromPopAdaptDaysCurve = new SimpleCurve { { new CurvePoint(0, 20), true }, { new CurvePoint(20, 10), true } };
                    /*
                    // Creates a Wanderer Spawns event every so often
                    int curvepoint = (int)Math.Round(3600000/(Find.CurrentMap.PlayerWealthForStoryteller / Find.CurrentMap.PlayerPawnsForStoryteller.Count()));
                    if (i% curvepoint*2048 == 0)
                    {
                        IncidentParms parms = new IncidentParms();
                        parms.target = Find.CurrentMap;
                        IncidentDefOf.WandererJoin.Worker.TryExecute(parms);
                    }*/
                }
            }
            base.MapComponentTick();
        }
    }
}
