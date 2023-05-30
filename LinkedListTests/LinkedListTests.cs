using LinkList;

namespace LinkedListTests
{
	[TestClass]
	public class LinkedListTests
	{
		// Add Test Methods
		[TestMethod]
		public void TestAddHappyPath()
		{
			// Tests adding any number to lists

			// test single linked add
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			Assert.AreEqual(1, slList.Count());

			// test double linked add
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			Assert.AreEqual(1, dlList.Count());

		}

		[TestMethod]
		public void TestAddNull()
		{
			// Tests adding null to lists

			// test single linked add
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add((string)null);
			Assert.AreEqual(1, slList.Count());

			// test double linked add
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add((string)null);
			Assert.AreEqual(1, dlList.Count());
		}

		// Insert Test Methods
		[TestMethod]
		public void TestInsertHappyPath()
		{
			// Tests inserting at an index within list

			// test single linked add
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.Add(5);

			slList.Insert(6, 4);

			Assert.AreEqual("6", slList.Get<int>(4));

			// test double linked add
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			dlList.Add(5);

			dlList.Insert(6, 4);

			Assert.AreEqual("6", dlList.Get<int>(4));
		}

		[TestMethod]
		public void TestInsertOutOfBounds()
		{
			// Tests inserting at an index outside list

			// test single linked add
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.Add(5);

			Assert.ThrowsException<IndexOutOfRangeException>(() => slList.Insert(6, 7));

			// test double linked add
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			dlList.Add(5);

			Assert.ThrowsException<IndexOutOfRangeException>(() => dlList.Insert(6, 7));
		}

		// Count Test Methods
		[TestMethod]
		public void TestCountHappyPath()
		{
			// Tests the count for both lists

			// test single linked count
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			Assert.AreEqual(4, slList.Count());

			// test double linked count
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			Assert.AreEqual(4, dlList.Count());
		}

		[TestMethod]
		public void TestCountRemove()
		{
			// Tests the count for both lists after removing one

			// test single linked count remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.Remove<int>();
			Assert.AreEqual(3, slList.Count());

			// test double linked count remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			slList.Remove<int>();
			Assert.AreEqual(3, dlList.Count());
		}

		// Clear Test Methods
		[TestMethod]
		public void ClearHappyPath()
		{
			// Tests the clear function on a populated list

			// test single linked count remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.Clear<int>();
			Assert.AreEqual(0, slList.Count());

			// test double linked count remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			dlList.Clear<int>();
			Assert.AreEqual(0, dlList.Count());
		}

		[TestMethod]
		public void ClearEmptyList()
		{
			// Tests the clear function on an empty list

			// test single linked count remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Clear<int>();
			Assert.AreEqual(0, slList.Count());

			// test double linked count remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Clear<int>();
			Assert.AreEqual(0, dlList.Count());
		}

		// Get Test Methods
		[TestMethod]
		public void GetHappyPath()
		{
			// Tests the get function on a populated list

			// test single linked get
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			Assert.AreEqual(3, slList.Get<int>(2));

			// test double linked get
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			Assert.AreEqual(2, dlList.Get<int>(1));
		}

		[TestMethod]
		public void GetEmptyList()
		{
			// Tests the get function on an empty list

			// test single linked get
			SingleLinkedList slList = new SingleLinkedList();
			Assert.ThrowsException<IndexOutOfRangeException>(() => slList.Get<int>(2));

			// test double linked get
			DoubleLinkedList dlList = new DoubleLinkedList();
			Assert.ThrowsException<IndexOutOfRangeException>(() => dlList.Get<int>(2));
		}

		// Remove Test Methods
		[TestMethod]
		public void RemoveHappyPath()
		{
			// Tests the remove for both lists

			// test single linked remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.Remove<int>();
			Assert.AreEqual(3, slList.Count());

			// test double linked remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			dlList.Remove<int>();
			Assert.AreEqual(3, dlList.Count());
		}

		[TestMethod]
		public void RemoveEmptyList()
		{
			// Tests the count for both lists after removing one

			// test single linked count remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Remove<int>();
			Assert.AreEqual(0, slList.Count());

			// test double linked count remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Remove<int>();
			Assert.AreEqual(0, slList.Count());
		}

		// RemoveAt Test Methods
		[TestMethod]
		public void RemoveAtHappyPath()
		{
			// Tests the removeat for both lists

			// test single linked removeat
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.RemoveAt<int>(3);
			Assert.AreEqual(3, slList.Count());

			// test double linked removeat
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			dlList.RemoveAt<int>(2);
			Assert.AreEqual(3, dlList.Count());
		}

		[TestMethod]
		public void RemoveAtBadIndex()
		{
			// Tests the removeat for both lists on index outside of list

			// test single linked removeat
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			Assert.ThrowsException<IndexOutOfRangeException>(() => slList.RemoveAt<int>(-1));

			// test double linked removeat
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			Assert.ThrowsException<IndexOutOfRangeException>(() => dlList.RemoveAt<int>(-1));
		}

		// RemoveLast Test Methods
		[TestMethod]
		public void RemoveLastHappyPath()
		{
			// Tests the removelast for both lists

			// test single linked remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			slList.RemoveLast<int>();
			Assert.AreEqual(3, slList.Count());

			// test double linked remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			dlList.RemoveLast<int>();
			Assert.AreEqual(3, dlList.Count());
		}

		[TestMethod]
		public void RemoveLastEmptyList()
		{
			// Tests the removelast for both unpopulated lists 

			// test single linked count remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.RemoveLast<int>();
			Assert.AreEqual(0, slList.Count());

			// test double linked count remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.RemoveLast<int>();
			Assert.AreEqual(0, slList.Count());
		}

		// Search Test Methods
		[TestMethod]
		public void SearchHappyPath()
		{
			// Tests the search for both lists

			// test single linked remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			Assert.AreEqual(2, slList.Search<int>(3));

			// test double linked remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			Assert.AreEqual(3, dlList.Search<int>(4));
		}

		[TestMethod]
		public void SearchNotFound()
		{
			// Tests the search for both lists on value not in list

			// test single linked remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			Assert.AreEqual(-1, slList.Search<int>(7));

			// test double linked remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			Assert.AreEqual(-1, dlList.Search<int>(7));
		}

		// ToString Test Methods
		[TestMethod]
		public void ToStringHappyPath()
		{
			// Tests the ToString for both lists

			// test single linked remove
			SingleLinkedList slList = new SingleLinkedList();
			slList.Add(1);
			slList.Add(2);
			slList.Add(3);
			slList.Add(4);
			Assert.AreEqual("1, 2, 3, 4", slList.ToString());

			// test double linked remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			dlList.Add(1);
			dlList.Add(2);
			dlList.Add(3);
			dlList.Add(4);
			Assert.AreEqual("1, 2, 3, 4", dlList.ToString());
		}

		[TestMethod]
		public void ToStringEmptyList()
		{
			// Tests the ToString for both lists

			// test single linked remove
			SingleLinkedList slList = new SingleLinkedList();
			Assert.AreEqual("", slList.ToString());

			// test double linked remove
			DoubleLinkedList dlList = new DoubleLinkedList();
			Assert.AreEqual("", dlList.ToString());
		}
	}
}