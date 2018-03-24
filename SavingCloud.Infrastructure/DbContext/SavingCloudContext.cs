using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Infrastructure
{
    public class SavingCloudContext : SavingCloudContainer
    {
        static SavingCloudContext _current;
        public static SavingCloudContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SavingCloudContext();
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
