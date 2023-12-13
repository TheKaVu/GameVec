using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinXPP.GameVec.Simulated
{
    internal class EntityTypeDoubleRegistrationException : Exception
    {
        public EntityTypeDoubleRegistrationException() : base("Tried to register same entity type twice.") { }
    }
}
