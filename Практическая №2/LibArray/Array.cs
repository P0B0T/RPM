using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

namespace LibArray
{
    public class Array<T>
    {
        private T[] _items;
        private int _capacity;
        private readonly int _defaultCapacity = 8;
        /// <summary>
        /// Конструктор класса Array
        /// </summary>
        /// <param name="capacity">Длина массива (одномерного)</param>
        public Array(int capacity)
        {
            _items = new T[capacity];
            Capacity = capacity;
        }

        public Array()
        {
            _items = new T[_defaultCapacity];
            Capacity = _defaultCapacity;
        }
        public int Lenght { get; private set; }
        /// <summary>
        /// Индексатор класса Array
        /// </summary>
        /// <param name="index">Индекс массива (одномерного)</param>
        /// <returns>Значение элемента</returns>
        public T this[int index]
        {
            
            get { return _items[index]; }
            set { _items[index] = value; }
        }
        /// <summary>
        /// Свойство длины массива _items (одномерного)
        /// </summary>
        public int Capacity
        {
            get => _capacity; // получение значения из поля _capacity
            private set // устанавливаем значение для поля _capacity
            {
                if (value == _capacity)
                {
                    return;
                }
                _capacity = value;
                Array.Resize(ref _items, value);
            }
        }
        /// <summary>
        /// Расширение длины массива _items
        /// </summary>
        /// <param name="itemsLenght"></param>
        /// <returns></returns>
        private int EnsureCapacity(int itemsLenght = 0)
        {
            int tempCapacity = Capacity;
            while (itemsLenght + Lenght >= tempCapacity)
            {
                tempCapacity *= 2;
            }
            return tempCapacity;
        }
        /// <summary>
        /// Добавление значение для массива _items
        /// </summary>
        /// <param name="item">Значения которое мы получаем от пользователя</param>
        public void Add(T item)
        {
            Capacity = EnsureCapacity();
            _items[Lenght++] = item;
        }
        /// <summary>
        /// Добавление нескольких значений в массив _items
        /// </summary>
        /// <param name="items">Значение которое мы получаем от пользователя</param>
        public void AddRange(T[] items)
        {
            Capacity = EnsureCapacity(items.Length);
            Array.Copy(items, 0, _items, Lenght, items.Length);
            Lenght += items.Length;
        }
        /// <summary>
        /// Очистка массива и полей
        /// </summary>
        public void Clear()
        {
            Capacity = _defaultCapacity;
            Lenght = 0;
            _items = new T[Capacity];
        }
        /// <summary>
        /// Удаление введенных элементов из массива _items
        /// </summary>
        /// <param name="item">Значение которое мы получаем от пользователя</param>
        /// <returns>Измененный массив _items с удаленными элементами, которые мы получали от пользователя</returns>
        public bool Remove(T item)
        {
            //bool check = false;
            //List<T> vs = new List<T>();
            //for (int i = 0; i < _items.Length; i++)
            //{
            //    T val = _items[i];
            //    if (Convert.ToInt32(val) != 0)
            //    {
            //        vs.Add(val);
            //        if (vs.Remove(item))
            //        {
            //            check = true;
            //            Lenght--;
            //        }
            //    }
            //}
            //_items = vs.ToArray();

            int indexRemove = Array.IndexOf(_items, item);
            if (indexRemove == -1)
            {
                return false;
            }

            Array.Copy(_items, indexRemove + 1, _items, indexRemove, _items.Length - indexRemove - 1);
            Lenght--;
            return true;
        }
        /// <summary>
        /// Класс для сохранения или считывания данных в бинарном виде
        /// </summary>
        static private readonly BinaryFormatter _formatter = new BinaryFormatter();
        
        /// <summary>
        /// Сохраняет данные с двумерного массива _items
        /// </summary>
        /// <param name="data">Значения для сохранения</param>
        /// <param name="path">Путь для сохранения данных</param>
        public void Save(object data, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(stream, data);
            }
        }
        /// <summary>
        /// Считывает данные с файла в двумерный массив _items
        /// </summary>
        /// <param name="path">Путь для считывания данных</param>
        /// <returns>Данные с файла в массив _items</returns>
        public object Open(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return _formatter.Deserialize(stream);
            }
        }
        /// <summary>
        /// Сохраняет данные в поток байтов
        /// </summary>
        /// <param name="path">Путь для сохранения данных</param>
        public void Serialize(string path)
        {
            Save(_items, string.Concat(path));
        }
        /// <summary>
        /// Считывает данные с файла и преобразует в поток байтов
        /// </summary>
        /// <param name="path">Путь для считывания данных с файла в массив _items</param>
        public void Deserialize(string path)
        {
            _items = (T[])Open(string.Concat(path));

        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            int countItems  = _items.Take(Lenght).ToArray().Length;
            for (int i = 0; i < countItems; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < countItems; i++)
            {
                row[i] = _items[i];
            }
            res.Rows.Add(row);
            return res;
        }
        /// <summary>
        /// Добавление нескольких элементов для массива _items
        /// </summary>
        public DataTable ToDataTable2()
        {
            var res = new DataTable();
            for (int i = 0; i < Lenght; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < Lenght; i++)
            {
                row[i] = _items[i];
            }
            res.Rows.Add(row);
            return res;
        }
    }
}