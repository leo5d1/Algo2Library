using System.ComponentModel;

namespace BinarySearchTree
{
	internal interface iBST
	{
		public void Add<T>(T value);

		public bool Contains<T>(T value);

		public void Remove<T>(T value);

		public void Clear<T>();

		public int Count();

		public int Height<T>();

		public T[] ToArray<T>();

		public string InOrder<T>();

		public string PreOrder<T>();

		public string PostOrder<T>();
	}
}