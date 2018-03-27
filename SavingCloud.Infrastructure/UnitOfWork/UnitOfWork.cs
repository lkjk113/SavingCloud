using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingCloud.Infrastructure
{
    public class UnitOfWork : IDisposable
    {
        DefaultDbContext context;

        private UnitOfWork()
        {
            context = DefaultDbContext.Current;
        }

        public static UnitOfWork Begin()
        {
            return new UnitOfWork();
        }


        public virtual void Commit()
        {
            context.Commit();
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                    DefaultDbContext.Current = null;
                }
                // TODO: 将大型字段设置为 null。
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
