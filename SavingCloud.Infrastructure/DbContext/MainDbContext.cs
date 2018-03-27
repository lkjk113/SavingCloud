using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Infrastructure
{
    public class MainDbContext : SavingCloudContainer
    {
        static MainDbContext _current;
        public static MainDbContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new MainDbContext();
                }

                return _current;
            }
            set
            {
                _current = value;
            }
        }

        internal void Commit()
        {
            _current.SaveChanges();
        }
    }
}
