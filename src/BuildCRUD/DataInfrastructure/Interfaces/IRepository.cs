using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataInfrastructure.Interfaces
{
	// Interface that exposes all the necessary functions that each Controller class will need
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> GetAll(string limiter);
		T Get(int id);
		T Add(T item);
        T Add(T item, int id);
		void Remove(int id);
		bool Update(T item);
        bool Update(T item, int id);
        void Dispose();
	}
}
