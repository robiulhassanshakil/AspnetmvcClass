using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDemoExercise.Services
{
    public class SimpleDatabaseServicecs : IDatabaseService
    {
        private IDriverServicecs _driverServicecs;

        public SimpleDatabaseServicecs(IDriverServicecs driverServicecs)
        {
            _driverServicecs = driverServicecs;
        }

        public string GetName()
        {
            return "simpleDatabaseServices";
        }
    }
}
