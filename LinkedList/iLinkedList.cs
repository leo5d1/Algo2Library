using System.ComponentModel;
using System.Data;

namespace LinkList
{
	internal interface iLinkedList
	{
		public void Add<T>(T value);

		public void Insert<T>(T value, int index);

		public int Count();

		public T Get<T>(int index);

		public void Remove<T>();

		public void RemoveAt<T>(int index);

		public T RemoveLast<T>();

		public string ToString<T>();

		public void Clear<T>();

		public int Search<T>(T value);
	}
}