using System.Diagnostics.CodeAnalysis;

namespace VaquinhaWeb.Util
{
    public class MesComparer : IEqualityComparer<MesAno>
    {
        public bool Equals(MesAno? x, MesAno? y)
        {
            if(x == null || y == null)
                return false;
            
            if(ReferenceEquals(x,y))
                return true;

            return x.MesComAno == y.MesComAno;
        }

        public int GetHashCode([DisallowNull] MesAno obj)
        {
            if(obj == null || obj.MesInteiro == null)
                return 0;
            
            return obj.MesInteiro.GetHashCode();
        }
    }
}