using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
        public class SingletonBase<T> where T : class, new()
        {
            private static T _instance;
            private static readonly object _lock = new object();
            protected ArtDbContext _context = new ArtDbContext();

            public static T Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new T();
                            }
                        }
                    }
                    return _instance;
                }
            }
        }
    
}
