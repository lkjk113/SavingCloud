using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Infrastructure
{
    public class DefaultDbContext : SavingCloudContainer
    {
        static DefaultDbContext _current;
        public static DefaultDbContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new DefaultDbContext();
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
