// Simple_Data_Struct.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <cassert>

using std::cout;
using std::endl;
using std::cin;

class IndexOutOfBoundsException
{
};

template <typename T>
class Array
{
private:

	T *m_ptr = nullptr;
	int m_size = 0;

public:
	Array() = default;
	explicit Array(int size)
	{
		if (size != 0)
		{
			m_ptr = new T[size]{};
			m_size = size;
		}
	}

	Array(const Array& source)
	{
		if (!source.IsEmpty())
		{
			m_size = source.m_size;

			m_ptr = new T[m_size]{};
			for (int i = 0; i < m_size; i++)
			{
				m_ptr[i] = source.m_ptr[i];
			}
		}
	}
	Array(Array&& source)
	{
		m_ptr = source.m_ptr;
		m_size = source.m_size;

		source.m_ptr = nullptr;
		source.m_size = 0;
	}

	~Array()
	{
		delete[] m_ptr;
	}

	int Size() const
	{
		return m_size;
	}

	bool IsEmpty() const
	{
		return (m_size == 0);
	}

	bool IsValidIndex(int index) const
	{
		return (index >= 0) && (index < m_size);
	}

	friend void Swap(Array& a, Array& b) noexcept
	{
		std::swap(a.m_ptr, b.m_ptr);
		std::swap(a.m_size, b.m_size);
	}

	Array& operator=(Array source)
	{
		Swap(*this, source);

		return *this;
	}

	T& operator[](int index)
	{
		if (!IsValidIndex(index))
		{
			throw IndexOutOfBoundsException{};
		}
		return m_ptr[index];
	}

	T operator[](int index) const
	{
		if (!IsValidIndex(index))
		{
			throw IndexOutOfBoundsException{};
		}
		return m_ptr[index];
	}
};

template <typename T>
class GenericArray
{
private:

	T *m_elements = nullptr;
	int m_size = 0;

	bool IsEmpty() const
	{
		return (m_size == 0);
	}

	bool IsValidIndex(int index) const
	{
		return (index >= 0) && (index < m_size);
	}

	bool ChangeArraySize(int size)
	{
		try
		{
			T *tempArr = m_elements;

			m_elements = new T[size] {};
			m_size = size;

			for (int i = 0; i < m_size - 1; i++)
			{
				m_elements[i] = tempArr[i];
			}

			delete[] tempArr;

			return true;
		}
		catch (const std::exception&)
		{
			return false;
		}
	}

	friend void Swap(GenericArray& a, GenericArray& b) noexcept
	{
		std::swap(a.m_elements, b.m_elements);
		std::swap(a.m_size, b.m_size);
	}

public:

	GenericArray() = default;
	explicit GenericArray(int size)
	{
		if (size != 0)
		{
			m_elements = new T[size]{};
			m_size = size;
		}
	}

	GenericArray(const GenericArray& source)
	{
		if (!source.IsEmpty())
		{
			m_size = source.m_size;
			m_elements = new T[m_size]{};

			for (int i = 0; i < m_size; i++)
			{
				m_elements[i] = source.m_elements[i];
			}
		}
	}
	GenericArray(GenericArray&& source)
	{
		m_elements = source.m_elements;
		m_size = source.m_size;

		source.m_elements = nullptr;
		source.m_size = 0;
	}

	~GenericArray()
	{
		delete[] m_elements;
	}

	int Size() const
	{
		return m_size;
	}

	bool Add(T& element)
	{
		int newSize = m_size + 1;

		if (ChangeArraySize(newSize))
		{
			m_elements[newSize - 1] = element;

			return true;
		}
		else
		{
			return false;
		}
	}

	bool RemoveAt(int index)
	{

	}

	bool Remove(T& element)
	{
		ChangeArraySize(m_size - 1);
	}

	bool Remove()
	{
		if (ChangeArraySize(m_size - 1))
		{
			return true;
		}
		return false;
	}

	int Find(const T element)
	{
		for (int i = 0; i < Size(); i++)
		{
			if (m_elements[i] == element)
			{
				return i;
			}
		}

		return -1;
	}

	T& FindElement(const T element)
	{
		for (int i = 0; i < Size(); i++)
		{
			if (m_elements[i] == element)
			{
				return m_elements[i];
			}
		}

		return nullptr;
	}

	GenericArray& operator=(GenericArray source)
	{
		Swap(*this, source);

		return *this;
	}

	T& operator[](int index)
	{
		if (!IsValidIndex(index))
		{
			throw IndexOutOfBoundsException{};
		}

		return m_elements[index];
	}

	T operator[](int index) const
	{
		if (!IsValidIndex(index))
		{
			throw IndexOutOfBoundsException{};
		}

		return m_elements[index];
	}

};

int main()
{
	GenericArray<int> arr{};

	for (int i = 0; i < 50; i++)
	{
		int t = i + 1;
		arr.Add(t);
	}

	for (int i = 0; i < arr.Size(); i++)
	{
		cout << arr[i] << endl;
	}

	arr.Remove();

	cout << "Removed" << endl;
	for (int i = 0; i < arr.Size(); i++)
	{
		cout << arr[i] << endl;
	}
}
